using System;
using System.IO;
using Spartacus.Utils;
using Model;
using System.Net.Mail;
using Model.Ordem_de_Servico;
using Model.Pessoa_e_Usuario;

namespace Controller
{
    public static class ControllerEmail
    {
        //TODO:Desenvolver sistema para salvar relaorio em uma pasta TEMP no diretório do software

        /// <summary>
        /// Carrega as informações do email enviado quando é finalizada uma Ordem de Serviço
        /// </summary>
        /// <returns></returns>
        public static string CarregarEmailFinalizacaoOS()
        {
            StreamReader sr = null;
            string Saida;
            string CaminhoDoArquivo = String.Format("{0}/Menssagem.dat", Ferramentas.ObterCaminhoDoExecutavel());

            try
            {
                sr = new StreamReader(CaminhoDoArquivo);

                Saida = sr.ReadToEnd();

            }
            catch (System.Exception exc)
            {
                Saida = "Ocorreu um arro ao tentar ler o arquivo com as informações.";
                ControllerArquivoLog.GeraraLog(exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return Saida;
        }

        /// <summary>
        /// Carrega as informações do arquivo de configuração do E-mail.
        /// </summary>
        /// <returns></returns>
        public static Email CarregarInformacoesLoginServidor()
        {
            Cryptor cr;
            string CaminhoDoArquivo = String.Format("{0}/Email.dat", Ferramentas.ObterCaminhoDoExecutavel());
            Email EmailBase = new Email();
            StreamReader sr = null;
            cr = new Cryptor("p@$$w0rd");

            try
            {
                sr = new StreamReader(CaminhoDoArquivo);

                EmailBase.email = cr.Decrypt(sr.ReadLine());
                EmailBase.Senha = cr.Decrypt(sr.ReadLine());
                EmailBase.Host = cr.Decrypt(sr.ReadLine());
                EmailBase.Port = int.Parse(cr.Decrypt(sr.ReadLine()));
            }
            catch (System.Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
            return EmailBase;
        }

        /// <summary>
        /// Salvando E-mail base(padrão) que é enviado para todos os clientes quando o serviço termina.
        /// </summary>
        /// <param name="Texto"></param>
        /// <returns></returns>
        public static string SalvarEmailFinalizacaoOS(string Texto)
        {
            string saida = " ";
            string CaminhoDoArquivo = String.Format("{0}/Menssagem.dat", Ferramentas.ObterCaminhoDoExecutavel());
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(CaminhoDoArquivo);

                sw.WriteLine(Texto);

                saida = "Arquivo de Email Base gerado com sucesso!";
            }
            catch (System.Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);
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
        /// Criando arquivo com as informações de Login e Servidor que são utilizados para enviar o e-mail para os clientes.
        /// </summary>
        /// <param name="EnderecoEmail"></param>
        /// <param name="Senha"></param>
        /// <param name="Host"></param>
        /// <param name="Port"></param>
        /// <returns></returns>
        public static string SalvarInformacoesLoginServidor(string EnderecoEmail, string Senha, string Host, int Port)
        {
            Cryptor cr;
            string Saida = "";
            string CaminhoDoArquivo = String.Format("{0}/Email.dat", Ferramentas.ObterCaminhoDoExecutavel());
            StreamWriter sw = null;
            cr = new Cryptor("p@$$w0rd");

            try
            {
                sw = new StreamWriter(CaminhoDoArquivo);

                sw.WriteLine(cr.Encrypt(EnderecoEmail));
                sw.WriteLine(cr.Encrypt(Senha));
                sw.WriteLine(cr.Encrypt(Host));
                sw.WriteLine(cr.Encrypt(Port.ToString()));

                Saida = "Arquivo de configuração gerado com sucesso!";
            }
            catch (System.Exception exc)
            {
                ControllerArquivoLog.GeraraLog(exc);

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
        ///  Configurando e enviando e-mail. (Decodificando)
        /// </summary>
        /// <param name="NomeUsuario"></param>
        public static string EnviarInformacoesOSFinalizada(string NomeCliente, string EmailCliente, string NomeEmpresa, string EmailFInalizacaoOS)
        {
            string Saida = " ";

            Email EmailBase = new Email();

            EmailBase = ControllerEmail.CarregarInformacoesLoginServidor();//Carregando informações do servidor.

            SmtpClient smtp = new SmtpClient(EmailBase.Host, EmailBase.Port);   //Servidor
            MailMessage mail = new MailMessage(); //Menssagem
            mail.From = new MailAddress(EmailBase.email);


            //Configurando servidor.
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailBase.email, EmailBase.Senha);//Passando Login e senha do e-mail da empresa(para enviar)


            //Assunto do email.
            mail.Subject = String.Format("Serviço pronto [ {0} ]", NomeEmpresa);

            //Informando sobre o corpo.
            mail.IsBodyHtml = true;

            //Conteúdo do email.
            mail.Body = EmailFInalizacaoOS;

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
                ControllerArquivoLog.GeraraLog(exc);

                Saida = "Ocorreu um erro ao enviar o Email " + exc.Message;
            }

            return Saida;
        }

        /// <summary>
        ///  Enviando Email inicial, quando e aberto uma Ordem de Serviço
        /// </summary>
        /// <param name="NomeUsuario"></param>
        public static string EnviarOrdemDeServiço(OrdemServico OS, Empresa InfoEmpresa, Pessoa cliente)
        {
            string Saida = " ";
            string MenssagemBase = string.Format("Olá {0}, sua ordem de serviço n° {1} foi criado com sucesso! O arquivo segue em anexo a este e-mail", cliente.Nome, OS.ID);


            Email EmailBase = new Email();

            EmailBase = ControllerEmail.CarregarInformacoesLoginServidor();//Carregando informações do servidor.

            SmtpClient smtp = new SmtpClient(EmailBase.Host, EmailBase.Port);   //Servidor
            MailMessage mail = new MailMessage(); //Menssagem
            mail.From = new MailAddress(EmailBase.email);


            //Configurando servidor.
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailBase.email, EmailBase.Senha);//Passando Login e senha do e-mail da empresa(para enviar)


            //Assunto do email.
            mail.Subject = String.Format("Ordem de serviço [ {0} ]", InfoEmpresa.Nome);

            //Informando sobre o corpo.
            mail.IsBodyHtml = true;

            //Conteúdo do email.
            mail.Body = MenssagemBase;

            //Adicionando E-mail do cliente para enviar.
            mail.To.Add(cliente.Email);

            //Prioridade de Envio.
            mail.Priority = MailPriority.High;
            // Criar o arquivo anexo para esse e-mail.
            string file = String.Format("{0}/OS.pdf", Path.GetTempPath());//TODO:Rever Esse Código.

            Attachment data = new Attachment(file);

            data.Name = String.Format("{0}.pdf", OS.ID); //Mudando o nome do arquivo antes de enviar o E-mail.

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
                ControllerArquivoLog.GeraraLog(exc);

                Saida = "Ocorreu um erro ao enviar o Email " + exc.Message;
            }

            return Saida;
        }

        /// <summary>
        ///  Configurando e enviando e-mail. (Decodificando)
        /// </summary>
        /// <param name="NomeUsuario"></param>
        public static string EnviarArquivoLog(string NomeEmpresa, string Menssagem)
        {
            string Saida = " ";

            Email EmailBase = new Email();
            EmailBase = ControllerEmail.CarregarInformacoesLoginServidor();


            SmtpClient smtp = new SmtpClient(EmailBase.Host, EmailBase.Port);   //Servidor
            MailMessage mail = new MailMessage(); //Menssagem
            mail.From = new MailAddress(EmailBase.email);


            //Configurando servidor.
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(EmailBase.email, EmailBase.Senha);//Passando Login e senha do e-mail da empresa(para enviar)


            //Assunto do email.
            mail.Subject = String.Format("Arquivo de log [ {0} ]", NomeEmpresa);

            //Informando sobre o corpo.
            mail.IsBodyHtml = true;

            //Conteúdo do email.
            mail.Body = Menssagem;

            //Adicionando E-mail do cliente para enviar.
            mail.To.Add("contato@cristianoprogramador.com");

            //Prioridade de Envio.
            mail.Priority = MailPriority.High;


            if (System.IO.File.Exists("Log.txt"))
            {
                // Criar o arquivo anexo para esse e-mail.
                Attachment data = new Attachment("Log.txt");

                //Inclui o arquivo anexo.
                mail.Attachments.Add(data); //Caminho de onde o arquivo da Ordem de serviço é salvo.
            }


            try
            {
                //Envia o email.
                smtp.Send(mail);

                Saida = "E-mail enviado com sucesso!";
            }
            catch (System.Exception exc)
            {
                //Gerando arquivo de Log
                ControllerArquivoLog.GeraraLog(exc);
                Saida = "Ocorreu um erro ao enviar o Email " + exc.Message;
            }

            return Saida;
        }

        /// <summary>
        /// Decodificando informações do E-mail com as informações da finalização de Ordem de Serviço. EX: **Cliente = Nome do Cliente
        /// </summary>
        /// <param name="EmailBase"></param>
        public static string DecodificarEmailFinalizacaoOS(string TextoEmailBase, string NomeEmpresa, string NomeCliente, string NomeEquipamento)
        {
            string TextoEmail;
            string EmailTemporario;

            TextoEmail = ControllerEmail.CarregarEmailFinalizacaoOS();

            //Transformando os "Códigos digitados pelo usuario" em seu resultado;
            EmailTemporario = TextoEmail.Replace("**Cliente", NomeCliente);

            EmailTemporario = EmailTemporario.Replace("**Empresa", NomeEmpresa);

            EmailTemporario = EmailTemporario.Replace("**Equipamento", NomeEquipamento);

            EmailTemporario = EmailTemporario.Replace("**Data", DateTime.Now.ToString());
            TextoEmail = EmailTemporario;

            return TextoEmail;
        }

        public static bool VerificarInformacoesDoServidorSMTP(Email InformacoesServidor)
        {
            SmtpClient smtp = new SmtpClient(InformacoesServidor.Host, InformacoesServidor.Port);   //Servidor
            MailMessage mail = new MailMessage(); //Menssagem
            mail.From = new MailAddress(InformacoesServidor.email);


            //Configurando servidor.
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(InformacoesServidor.email, InformacoesServidor.Senha);//Passando Login e senha do e-mail da empresa(para enviar)


            //Assunto do email.
            mail.Subject = String.Format("Email de testes Software Ordem de Serviço");

            //Informando sobre o corpo.
            mail.IsBodyHtml = true;

            //Conteúdo do email.
            mail.Body = "Email configurado com sucesso!";

            //Adicionando E-mail do cliente para enviar.
            mail.To.Add("contato@cristianoprogramador.com");

            //Prioridade de Envio.
            mail.Priority = MailPriority.High;


            try
            {
                //Envia o email.
                smtp.Send(mail);

                return true;
            }
            catch (System.Exception exc)
            {
                //Gerando arquivo de Log
                ControllerArquivoLog.GeraraLog(exc);
                return false;
            }
        }
    }
}
