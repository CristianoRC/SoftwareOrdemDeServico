namespace Model.Ordem_de_Servico
{
	public class OrdemServico
	{
		public int ID { get; set; }
		public string Situacao { get; set; }
		public string Defeito { get; set; }
		public string Descricao { get; set; }
		public string Observacao { get; set; }
		public string NumeroSerie { get; set; }
		public string Equipamento { get; set; }
		public string dataEntradaServico { get; set; }
		public int IDCliente { get; set; }
		public int IDTecnico { get; set; }
		public double ValorOrcamento { get; set;}
	}
}
