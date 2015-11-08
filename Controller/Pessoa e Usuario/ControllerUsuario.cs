using System;
using System.IO;
using System.Collections.Generic;
using Model.Pessoa_e_Usuario;

namespace Controller
{
    public class ControllerUsuario
    {

        /// <summary>
        /// Salvando novo usuário
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Senha"></param>
        /// <param name="NivelAcesso"></param>
        /// <returns></returns>
        public String Save(String Nome, String Senha, string NivelAcesso)
        {
            StreamWriter sr = null;
            string Saida = "";

            if (Verificar(Nome) == false)
            {
                try
                {
                    sr = new StreamWriter(String.Format("Usuario/{0}.dat", Nome));
                    Usuario UsuarioBase = new Usuario();

                    UsuarioBase.Nome = Nome;
                    UsuarioBase.Senha = Senha;
                    UsuarioBase.NivelAcesso = NivelAcesso;

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

        /// <summary>
        /// Carregando Lista com nome de todos usuarios.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Carregando usuario.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns>Usuario</returns>
        public Usuario Load(string Nome)
        {
            StreamReader sr = null;
            Usuario UsuarioBase = new Usuario();


            try
            {
                sr = new StreamReader(string.Format("Usuario/{0}.dat", Nome));

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

        /// <summary>
        /// Verificando de o suario existe.
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public bool Verificar(string Nome)
        {
            bool UsuarioEncontrado = false;

            try
            {

                if (File.Exists(String.Format("Usuario/{0}.dat", Nome)))
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
