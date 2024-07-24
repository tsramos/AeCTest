using AeCTest.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AeCTest.Web.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly Context _context;

        public EnderecosController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Enderecos.ToListAsync());
        }
    }
}
