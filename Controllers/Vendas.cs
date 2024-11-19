using Microsoft.AspNetCore.Mvc;

using projetopim.Services;


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
    }
}
