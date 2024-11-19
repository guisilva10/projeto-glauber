using Microsoft.AspNetCore.Mvc;

using projetopim.Services;


namespace projetopim.Controllers
{
    public class InsumosController : Controller
    {
        private readonly InsumoService _insumoService;

        public InsumosController(InsumoService insumoService)
        {
            _insumoService = insumoService;
        }

        
        public async Task<IActionResult> Index()
        {
            var insumos = await _insumoService.GetAllInsumos();
            return View(insumos); 
        }

     
        public IActionResult Criar()
        {
            return View(new CultivosEInsumos());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(CultivosEInsumos cultivoInsumo)
        {
            
            if (ModelState.IsValid)
            {
                await _insumoService.CreateInsumo(cultivoInsumo); 
                return RedirectToAction(nameof(Index));  
            }
            return View(cultivoInsumo);  
        }

        public async Task<IActionResult> Editar(int id)
        {
            var cultivoInsumo = await _insumoService.GetInsumoById(id);
            if (cultivoInsumo == null)
            {
                return NotFound(); 
            }
            return View(cultivoInsumo); 
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(CultivosEInsumos cultivoInsumo)
        {
            if (ModelState.IsValid)
            {
                await _insumoService.UpdateInsumo(cultivoInsumo); 
                return RedirectToAction(nameof(Index));
            }
            return View(cultivoInsumo); 
        }
  
        public async Task<IActionResult> ApagarConfirmacao(int id)
        {
            var cultivoInsumo = await _insumoService.GetInsumoById(id);
            if (cultivoInsumo == null)
            {
                return NotFound(); 
            }
            return View(cultivoInsumo); 
        }


        [HttpPost, ActionName("ApagarConfirmacao")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apagar(int id)
        {
            await _insumoService.DeleteInsumo(id); 
            return RedirectToAction(nameof(Index)); 
        }
    }
}
