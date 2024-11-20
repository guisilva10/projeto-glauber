using Microsoft.AspNetCore.Mvc;
using projetopim.Services;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font;
using iText.IO.Font.Constants;
using System.IO;


namespace projetopim.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendasService _vendasService;

        public VendasController(VendasService vendaService)
        {
            _vendasService = vendaService;
        }

        public async Task<IActionResult> Index()
        {
            var venda = await _vendasService.GetAllVendas();
            return View(venda); 
        }

      
        public IActionResult Criar()
        {
            return View(new Vendas()); 
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Vendas vendaInsumo)
        {
            
            if (ModelState.IsValid)
            {
                await _vendasService.CreateVendas(vendaInsumo); 
                return RedirectToAction(nameof(Index));  
            }
            return View(vendaInsumo);  
        }

     
        public async Task<IActionResult> Editar(int id)
        {
            var vendaInsumo = await _vendasService.GetVendasById(id);
            if (vendaInsumo == null)
            {
                return NotFound(); 
            }
            return View(vendaInsumo); 
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Vendas vendaInsumo)
        {
            if (ModelState.IsValid)
            {
                await _vendasService.UpdateVendas(vendaInsumo); 
                return RedirectToAction(nameof(Index)); 
            }
            return View(vendaInsumo); 
        }

       
        public async Task<IActionResult> ApagarConfirmacao(int id)
        {
            var vendaInsumo = await _vendasService.GetVendasById(id);
            if (vendaInsumo == null)
            {
                return NotFound(); 
            }
            return View(vendaInsumo); 
        }

       
        [HttpPost, ActionName("ApagarConfirmacao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            await _vendasService.DeleteVendas(id); 
            return RedirectToAction(nameof(Index)); 
        }

      
public async Task<IActionResult> GerarRelatorio()
{
    // Obtenha a lista de vendas do banco de dados
    var vendas = await _vendasService.GetAllVendas();  // Assumindo que GetAllVendas() retorna uma lista de objetos Vendas

    // Caminho do arquivo (em um ambiente real, use o Response para oferecer o download)
    var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "RelatorioVendas.pdf");

    // Verifique se o arquivo já existe e, se sim, exclua-o para evitar conflito
    if (System.IO.File.Exists(caminhoArquivo))
    {
        System.IO.File.Delete(caminhoArquivo);
    }

    // Crie o arquivo PDF
    using (var writer = new PdfWriter(caminhoArquivo))
    {
        using (var pdf = new PdfDocument(writer))
        {
            var document = new Document(pdf);

            // Registra a fonte padrão Helvetica-Bold sem precisar do BouncyCastle
            var boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            // Adicione um título
            var titulo = new Paragraph("Relatório de Vendas")
                .SetFont(boldFont)
                .SetFontSize(18);
            document.Add(titulo);

            // Adicione os dados das vendas em uma tabela
            var tabela = new Table(5); // Número de colunas (Id, Cliente, Produto, Quantidade, Valor)
            tabela.AddCell("ID");
            tabela.AddCell("Cliente");
            tabela.AddCell("Produto");
            tabela.AddCell("Quantidade");
            tabela.AddCell("Valor");

            // Adicione as vendas na tabela
            foreach (var venda in vendas)
            {
                tabela.AddCell(venda.Id.ToString());
                tabela.AddCell(venda.Cliente);
                tabela.AddCell(venda.Produto);
                tabela.AddCell(venda.Quantidade.ToString());
                tabela.AddCell(venda.Valor.ToString("C")); // Formato monetário
            }

            document.Add(tabela);

            // Finaliza o documento corretamente
            document.Close();
        }
    }

    // Agora, o arquivo está fechado e podemos acessá-lo para download
    var fileBytes = System.IO.File.ReadAllBytes(caminhoArquivo);
    return File(fileBytes, "application/pdf", "RelatorioVendas.pdf");
}
    }
}
