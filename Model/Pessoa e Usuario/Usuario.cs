using System;
using System.IO;
using System.Collections.Generic;

namespace Model.Pessoa_e_Usuario
{
    public class Usuario
    {
        private String nome;
        private String senha;
        private String nivelAcesso;

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
        public string NivelAcesso
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
                    Usuario UsuarioBase = new Usuario();

                    UsuarioBase.Nome = _Nome;
                    UsuarioBase.Senha = _Senha;
                    UsuarioBase.NivelAcesso = _NivelAcesso;

                    sr.WriteLine(UsuarioBase.Nome);
                    sr.WriteLine(UsuarioBase.Senha);
                    sr.WriteLine(UsuarioBase.NivelAcesso);

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

        public Usuario Load(string _Nome)
        {
            StreamReader sr = null;
            Usuario UsuarioBase = new Usuario();


            try
            {
                sr = new StreamReader(string.Format("Usuario/{0}.dat", _Nome));

                UsuarioBase.Nome = sr.ReadLine();
                UsuarioBase.Senha = sr.ReadLine();
                UsuarioBase.NivelAcesso = sr.ReadLine();

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

            return UsuarioBase;
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
