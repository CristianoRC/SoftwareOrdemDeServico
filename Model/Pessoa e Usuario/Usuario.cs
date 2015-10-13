using System;
using System.IO;
using System.Collections.Generic;

namespace Model.Pessoa_e_Usuario
{
    public class Usuario
    {
        private String nome;
        private String senha;
        private Char nivelAcesso;

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
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
        public char NivelAcesso
        {
            get
            {
                return nivelAcesso;
            }

            set
            {
                nivelAcesso = value;
            }
        }


        public String Save(String _Nome, String _Senha, string _NivelAcesso)
        {
            StreamWriter sr = null;
            string Saida = "";

            if (Verificar(_Nome) == false)
            {
                try
                {
                    sr = new StreamWriter(String.Format("Usuario/{0}.dat", _Nome));

                    sr.WriteLine(_Nome);
                    sr.WriteLine(_Senha);
                    sr.WriteLine(_NivelAcesso);

                    Saida = "Usuario registrado com sucesso!";

                }
                catch (Exception Exc)
                {
                    Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                    Log.ArquivoExceptionLog(Exc);

                    Saida = "Ocorreu um erro inesperado!";
                }
                finally
                {
                    if (sr != null)
                    {
                        sr.Close();

                    }
                }
            }

            return Saida;
        }

        public List<string> LoadList()
        {
            Usuario UsuarioBase = new Usuario();
            List<string> ListaDeUsuarios = new List<string>();
            string[] Linha = new string[3];

            try
            {

                DirectoryInfo NomesArquivos = new DirectoryInfo("Usuario/");
                string[] NovoItem = new string[2];


                //Ira pegar todas os nomes dos arquivos do diretorio ira separar um por um e um array separado por '.' e lgo apos salvar o nome do arquivo sem o seu formato.

                foreach (var item in NomesArquivos.GetFiles())
                {
                    NovoItem = item.ToString().Split('.');

                    ListaDeUsuarios.Add(NovoItem[0]);

                }


            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);
            }

            return ListaDeUsuarios;
        }

        public List<string> Load(string _Nome)
        {
            StreamReader sr = null;
            List<string> ListaPessoa = new List<string>();


            try
            {
                sr = new StreamReader(string.Format("Usuario/{0}.dat", _Nome));

                while (!sr.EndOfStream)
                {
                    ListaPessoa.Add(sr.ReadLine());
                }

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

            return ListaPessoa;
        }

        public bool Verificar(string _nome)
        {
            bool UsuarioEncontrado = false;

            try
            {

                if (File.Exists(String.Format("Usuario/{0}.dat", _nome)))
                {
                    UsuarioEncontrado = true;
                }


            }
            catch (FileNotFoundException)
            {
                UsuarioEncontrado = false;
            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);

                UsuarioEncontrado = false;
            }

            return UsuarioEncontrado;
        }
    }
}
