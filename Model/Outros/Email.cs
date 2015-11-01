using System;
using System.IO;

namespace Model
{
    class Email
    {

        private string email;
        private string senha;
        private string host;
        private int port;


        public string EnderecoEmail
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }
        public string Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }
        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

            
        //TODO: Sistema de E-mail base (Save/Load).

        /// <summary>
        ///  Configurando e enviando e-mail.
        /// </summary>
        /// <param name="NomeUsuario"></param>
        public void Enviar(string NomeUsuario,string EmailUsuario, string NomeEmpresa, string MenssagemBase)
        {
            Email EmailBase = new Email();
            EmailBase = EmailBase.Load();//Carregando informações do servidor.

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();   //Servidor
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(); //Menssagem
            mail.From = new System.Net.Mail.MailAddress(EmailBase.EnderecoEmail);


            //Configurando servidor
            smtp.Host = EmailBase.Host;
            smtp.Port = EmailBase.Port;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailBase.EnderecoEmail, EmailBase.Senha);//Passando Login e senha do e-mail da empresa(para enviar)


            //Parte da "Menssagem do E-mail"

            if (!string.IsNullOrWhiteSpace(EmailUsuario))
            {
                mail.To.Add(new System.Net.Mail.MailAddress(EmailUsuario));
            }

            mail.Subject = string.Format("Serviço pronto - {0}", NomeEmpresa); //Assunto do e-mail
            mail.Body = MenssagemBase; //Menssagem do e-mail


            smtp.Send(mail); //Mandando o E-mail.

        }

        /// <summary>
        /// Criando arquivo de configuração do email
        /// </summary>
        /// <param name="_EnderecoEmail"></param>
        /// <param name="_Senha"></param>
        /// <param name="_Host"></param>
        /// <param name="_Port"></param>
        /// <returns></returns>
        public string Configurar(string _EnderecoEmail, string _Senha, string _Host, int _Port)
        {
            string Saida = "";

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("Email.dat");

                sw.WriteLine(_EnderecoEmail);
                sw.WriteLine(_Senha);
                sw.WriteLine(_Host);
                sw.WriteLine(_Port);

                Saida = "Arquivo de configuração gerado com sucesso!";
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);

                Saida = "Ocorreu um erro ao tentar configurar! um arquivo de Log foi criado no diretorio do seu software com mais informações";
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
            return Saida;
        }

        /// <summary>
        /// Carrega as informações do arquivo de configuração do E-mail.
        /// </summary>
        /// <returns></returns>
        public Email Load()
        {
            Email EmailBase = new Email();
            StreamReader sr = null;

            try
            {
                sr = new StreamReader("Email.dat");

                EmailBase.EnderecoEmail = sr.ReadLine();
                EmailBase.Senha = sr.ReadLine();
                EmailBase.Host = sr.ReadLine();
                EmailBase.Port = int.Parse(sr.ReadLine());
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
            return EmailBase;
        }
    }
}
