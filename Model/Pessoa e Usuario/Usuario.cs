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


        public String Save(String _Nome, String _Senha, Char _NivelAcesso)
        {
            StreamWriter sr = null;
            string Saida = "";

            if (Verificar(_Nome) == false)
            {
                try
                {
                    sr = new StreamWriter("Usuarios.csv", true);

                    sr.WriteLine("{0},{1},{2}", _Nome, _Senha, _NivelAcesso);

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

        public List<Usuario> LoadList()
        {
            List<Usuario> ListraDeUsuarios = new List<Usuario>();
            Usuario UsuarioBase = new Usuario();

            StreamReader sw = null;
            string[] Linha = new string[3];
            string LinhaBase = "";

            try
            {
                sw = new StreamReader("usuarios.csv");

                do
                {
                    LinhaBase = sw.ReadLine();

                    Linha = LinhaBase.Split(',');

                    UsuarioBase.Nome = Linha[0];
                    UsuarioBase.Senha = Linha[1];
                    UsuarioBase.NivelAcesso = Convert.ToChar(Linha[2]);

                    ListraDeUsuarios.Add(UsuarioBase);

                }
                while (!sw.EndOfStream);


            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception Exc)
            {
                Arquivos.ArquivoLog Log = new Arquivos.ArquivoLog();

                Log.ArquivoExceptionLog(Exc);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return ListraDeUsuarios;
        }

        public bool Verificar(String _nome)
        {
            StreamReader sw = null;
            string[] Linha = new string[3];
            string LinhaBase = "";
            bool UsuarioEncontrado = false;
            bool Verificador = true;

            try
            {
                sw = new StreamReader("Usuarios.csv");

                do
                {
                    LinhaBase = sw.ReadLine();

                    Linha = LinhaBase.Split(',');

                    if (Linha[0] == _nome)
                    {
                        UsuarioEncontrado = true;

                        Verificador = false;
                    }
                }
                while (Verificador == false || sw.EndOfStream);


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
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return UsuarioEncontrado;
        }
    }
}
