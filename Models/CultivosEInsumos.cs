public class CultivosEInsumos
{
    public int Id { get; set; }  
    public int CultivoId { get; set; } 
    public string Cultivo { get; set; }  

    public int InsumoId { get; set; }  
    public string Insumo { get; set; }  

    public int FornecedorId { get; set; } 
    public string Fornecedor { get; set; }  

    public decimal Price { get; set; }  // Preço do cultivo e insumo
}