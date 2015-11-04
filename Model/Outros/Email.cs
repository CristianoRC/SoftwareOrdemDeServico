using System;
using System.IO;
using Spartacus.Utils;

namespace Model
{
    public class Email
    {
        //TODO: Sistema de enviar cópia da OS para o cliente quando ela for criada.

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

        /// <summary>
        /// Carrega as informações do arquivo de email base.
        /// </summary>
        /// <returns></returns>
        public string LoadEmailBase()
        {
            StreamReader sr = null;
            string Saida;

            try
            {
                sr = new StreamReader("Menssagem.dat");

                Saida = sr.ReadToEnd();

            }
            catch (Exception exc)
            {
                Saida = "Ocorreu um arro ao tentar ler o arquivo com as informações.";

                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return Saida;
        }

        /// <summary>
        /// Salvando E-mail base(padrão) que é enviado para todos os clientes quando o serviço termina.
        /// </summary>
        /// <param name="Texto"></param>
        /// <returns></returns>
        public string SaveEmailBase(string Texto)
        {
            string saida = " ";

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("Menssagem.dat");

                sw.WriteLine(Texto);

                saida = "Arquivo de Email Base gerado com sucesso!";
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);

                saida = "Ocorreu um erro ao tentar criar o Email Base! um arquivo de Log foi criado no diretorio do seu software com mais informações";
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }


            return saida;
        }

        /// <summary>
        ///  Configurando e enviando e-mail. (Decodificando)
        /// </summary>
        /// <param name="NomeUsuario"></param>
        public bool Enviar(string NomeCliente, string EmailCliente, string NomeEmpresa, string MenssagemBase)
        {
            bool Saida = false;

            Email EmailBase = new Email();
            EmailBase = EmailBase.LoadConfig();//Carregando informações do servidor.

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(EmailBase.Host, EmailBase.Port);   //Servidor
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(); //Menssagem
            mail.From = new System.Net.Mail.MailAddress(EmailBase.EnderecoEmail);


            //Configurando servidor.
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailBase.EnderecoEmail, EmailBase.Senha);//Passando Login e senha do e-mail da empresa(para enviar)


            //Assunto do email.
            mail.Subject = String.Format("Serviço pronto - {0}",NomeEmpresa);

            //Informando sobre o corpo.
            mail.IsBodyHtml = true;

            //Conteúdo do email.
            mail.Body = MenssagemBase;

            //Adicionando E-mail do cliente para enviar.
            mail.To.Add(EmailCliente);

            //Prioridade de Envio.
            mail.Priority = System.Net.Mail.MailPriority.High;

            try
            {
                //Envia o email.
                smtp.Send(mail);

                Saida = true;
            }
            catch(Exception exc)
            {
                //Gerando arquivo de Log
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);

                Saida = false;
            }

            return Saida;
        }

        /// <summary>
        /// Criando arquivo de configuração do email
        /// </summary>
        /// <param name="_EnderecoEmail"></param>
        /// <param name="_Senha"></param>
        /// <param name="_Host"></param>
        /// <param name="_Port"></param>
        /// <returns></returns>
        public string SaveConfig(string _EnderecoEmail, string _Senha, string _Host, int _Port)
        {
            Cryptor cr;
            string Saida = "";

            StreamWriter sw = null;
            cr = new Spartacus.Utils.Cryptor("p@$$w0rd");

            try
            {
                sw = new StreamWriter("Email.dat");

                sw.WriteLine(cr.Encrypt(_EnderecoEmail));
                sw.WriteLine(cr.Encrypt(_Senha));
                sw.WriteLine(cr.Encrypt(_Host));
                sw.WriteLine(cr.Encrypt(_Port));

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
        public Email LoadConfig()
        {
            Cryptor cr;

            Email EmailBase = new Email();
            StreamReader sr = null;
            cr = new Spartacus.Utils.Cryptor("p@$$w0rd");

            try
            {
                sr = new StreamReader("Email.dat");

                EmailBase.EnderecoEmail = cr.Decrypt(sr.ReadLine());
                EmailBase.Senha = cr.Decrypt(sr.ReadLine());
                EmailBase.Host = cr.Decrypt(sr.ReadLine());
                EmailBase.Port = int.Parse(cr.Decrypt(sr.ReadLine()));
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

        /// <summary>
        /// Decodificando informações do E-mail base EX: **Cliente = Nome do Cliente
        /// </summary>
        /// <param name="EmailBase"></param>
        public string DecodificarEmailBase(string TextoEmailBase, string NomeEmpresa, string NomeCliente)
        {
            string TextoEmail;
            string EmailTemporario;
            Email EmailBase = new Email();
            TextoEmail = EmailBase.LoadEmailBase();

            //Transformando os "Códigos digitados pelo usuario" em seu resultado;
            EmailTemporario = TextoEmail.Replace("**Cliente",NomeCliente);
            EmailTemporario = TextoEmail.Replace("**Empresa",NomeEmpresa);
            EmailTemporario = TextoEmail.Replace("**Data", DateTime.Now.ToString());
            TextoEmail = EmailTemporario;

            return TextoEmail;
        }
    }
}
