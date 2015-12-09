using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace Controller.Outros
{
    public class TermosDeGarantia
    {

        /// <summary>
        /// Criando um novo PDF com os termos de serviço.
        /// </summary>
        /// <param name="Texto"></param>
        public string CreatPDF(string Texto)
        {

            Document Documento = new Document();
            string local = String.Format("TermosDeGarantia.pdf");
            PdfWriter.GetInstance(Documento, new FileStream(local, FileMode.Create));
            ControllerEmpresa controllerEmpresa = new ControllerEmpresa();
            string saida;


            try
            {
                Paragraph Termos = new Paragraph();

                Termos.Add(Texto); //Texto é o parametro que é passado para a método.

                Documento.Open();

                Documento.Add(Termos);

                Documento.Close();

                Process.Start(local);

                saida = "Os termos de garantia foram salvos com sucesso!";
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(exc);

                saida = "Ocorreu um erro ao tentar gerar o PDF dos termos de garantia - " + exc.Message;
            }

            return saida;
        }

        public string Opem()
        {
            string local = String.Format("TermosDeGarantia.pdf");
            string saida;

            try
            {
                Process.Start(local);

                saida = "O arquivo foi aberto com sucesso";
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(exc);

                saida = "Ocorreu um erro ao tentar abrir o PDF dos termos de garantia - " + exc.Message;
            }

            return saida;
        }

        /// <summary>
        /// Salvando os termos de garantia no arquivo.
        /// </summary>
        /// <param name="Texto"></param>
        /// <returns></returns>
        public string Save(string Texto)
        {
            string saida;

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("TermosDeGarantia.dat");

                sw.WriteLine(Texto);

                saida = "Termos de garantia foram salvos com sucesso!";
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(exc);

                saida = "Ocorreu um erro ao tentar salvar os termos de garantia - " + exc.Message;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return saida;
        }

        /// <summary>
        /// Carregando informaçoes dos termos de garantia.
        /// </summary>
        /// <returns></returns>
        public string Load()
        {
            StreamReader sr = null;
            string saida;

            try
            {
                saida = sr.ReadToEnd();
            }
            catch (Exception exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(exc);

                saida = "Ocorreu um erro ao tentar carregar os termos de garantia - " + exc.Message;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            return saida;
        }
    }
}
