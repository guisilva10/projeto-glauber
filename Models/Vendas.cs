public class Vendas
{
    public int Id { get; set; }  
    public int ClienteId { get; set; }  
    public string Cliente { get; set; } 

    public string Produto { get; set; }  
    public int Quantidade { get; set; } 
    public decimal Valor { get; set; } 
    public string FormaDePagamento { get; set; }  
    
}
