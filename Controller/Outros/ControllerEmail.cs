using System;
using System.IO;
using Spartacus.Utils;
using Model;
using System.Net.Mail;

namespace Controller
{
    public class ControllerEmail
    {

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
            catch (System.Exception exc)
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
            catch (System.Exception exc)
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
        public string Enviar(string NomeCliente, string EmailCliente, string NomeEmpresa, string MenssagemBase)
        {
            string Saida = " ";

            Email EmailBase = new Email();
            ControllerEmail controllerEmail = new ControllerEmail();

            EmailBase = controllerEmail.LoadConfig();//Carregando informações do servidor.

            SmtpClient smtp = new SmtpClient(EmailBase.Host, EmailBase.Port);   //Servidor
            MailMessage mail = new MailMessage(); //Menssagem
            mail.From = new MailAddress(EmailBase.EnderecoEmail);


            //Configurando servidor.
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailBase.EnderecoEmail, EmailBase.Senha);//Passando Login e senha do e-mail da empresa(para enviar)


            //Assunto do email.
            mail.Subject = String.Format("Serviço pronto [ {0} ]", NomeEmpresa);

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

                Saida = "E-mail enviado com sucesso!";
            }
            catch (System.Exception exc)
            {
                //Gerando arquivo de Log
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);

                Saida = "Ocorreu um erro ao enviar o Email " + exc.Message;
            }

            return Saida;
        }

        /// <summary>
        ///  Configurando e enviando e-mail. (Decodificando)
        /// </summary>
        /// <param name="NomeUsuario"></param>
        public string EnviarOrdemDeServiço(string NomeCliente, string EmailCliente, string NomeEmpresa, string NumeroDaOrdem)
        {
            string Saida = " ";
            string MenssagemBase = string.Format("Olá {0}, sua ordem de serviço n° {1} foi criado com sucesso! O arquivo segue em anexo a este e-mail", NomeCliente, NumeroDaOrdem);


            Email EmailBase = new Email();
            ControllerEmail controllerEmail = new ControllerEmail();

            EmailBase = controllerEmail.LoadConfig();//Carregando informações do servidor.

            SmtpClient smtp = new SmtpClient(EmailBase.Host, EmailBase.Port);   //Servidor
            MailMessage mail = new MailMessage(); //Menssagem
            mail.From = new MailAddress(EmailBase.EnderecoEmail);


            //Configurando servidor.
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailBase.EnderecoEmail, EmailBase.Senha);//Passando Login e senha do e-mail da empresa(para enviar)


            //Assunto do email.
            mail.Subject = String.Format("Ordem de serviço [ {0} ]", NomeEmpresa);

            //Informando sobre o corpo.
            mail.IsBodyHtml = true;

            //Conteúdo do email.
            mail.Body = MenssagemBase;

            //Adicionando E-mail do cliente para enviar.
            mail.To.Add(EmailCliente);

            //Prioridade de Envio.
            mail.Priority = MailPriority.High;
            // Criar o arquivo anexo para esse e-mail.
            string file = String.Format("{0}/OS.pdf", Path.GetTempPath());

            Attachment data = new Attachment(file);

            data.Name = String.Format("{0}.pdf", NumeroDaOrdem); //Mudando o nome do arquivo antes de enviar o E-mail.

            //Inclui o arquivo anexo.
            mail.Attachments.Add(data); //Caminho de onde o arquivo da Ordem de serviço é salvo.

            try
            {
                //Envia o email.
                smtp.Send(mail);

                Saida = "E-mail enviado com sucesso!";
            }
            catch (System.Exception exc)
            {
                //Gerando arquivo de Log
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();
                Log.ArquivoExceptionLog(exc);

                Saida = "Ocorreu um erro ao enviar o Email " + exc.Message;
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
        public string SaveConfig(string EnderecoEmail, string Senha, string Host, int Port)
        {
            Cryptor cr;
            string Saida = "";

            StreamWriter sw = null;
            cr = new Cryptor("p@$$w0rd");

            try
            {
                sw = new StreamWriter("Email.dat");

                sw.WriteLine(cr.Encrypt(EnderecoEmail));
                sw.WriteLine(cr.Encrypt(Senha));
                sw.WriteLine(cr.Encrypt(Host));
                sw.WriteLine(cr.Encrypt(Port.ToString()));

                Saida = "Arquivo de configuração gerado com sucesso!";
            }
            catch (System.Exception exc)
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
            cr = new Cryptor("p@$$w0rd");

            try
            {
                sr = new StreamReader("Email.dat");

                EmailBase.EnderecoEmail = cr.Decrypt(sr.ReadLine());
                EmailBase.Senha = cr.Decrypt(sr.ReadLine());
                EmailBase.Host = cr.Decrypt(sr.ReadLine());
                EmailBase.Port = int.Parse(cr.Decrypt(sr.ReadLine()));
            }
            catch (System.Exception exc)
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
        public string DecodificarEmailBase(string TextoEmailBase, string NomeEmpresa, string NomeCliente, string NomeEquipamento)
        {
            string TextoEmail;
            string EmailTemporario;
            ControllerEmail controllerEmail = new ControllerEmail();

            TextoEmail = controllerEmail.LoadEmailBase();

            //Transformando os "Códigos digitados pelo usuario" em seu resultado;
            EmailTemporario = TextoEmail.Replace("**Cliente", NomeCliente);

            EmailTemporario = EmailTemporario.Replace("**Empresa", NomeEmpresa);

            EmailTemporario = EmailTemporario.Replace("**Equipamento", NomeEquipamento);

            EmailTemporario = EmailTemporario.Replace("**Data", DateTime.Now.ToString());
            TextoEmail = EmailTemporario;

            return TextoEmail;
        }
    }
}
