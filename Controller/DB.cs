namespace Controller
{
    public static class DB
    {
        public static string GetStrConection()
        {
            return string.Format("{0}/DataBase.db",Ferramentas.ObterCaminhoDoExecutavel());
        }
    }
}

