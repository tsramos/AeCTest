using AecTest.Core.Contracts.Services;
using AecTest.Core.Entities;
using AeCTest.Infra;
using AeCTest.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AeCTest.Web.Controllers
{
    [Authorize]
    public class EnderecosController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public EnderecosController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
           string? loginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var enderecos = _mapper.Map<IEnumerable<EnderecoViewModel>>(
                                        await _addressService.GetAll(loginId));
            return View(enderecos);
        }

        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = new EnderecoViewModel
            {
                UsuarioId = userId!
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                var endereco = _mapper.Map<Endereco>(enderecoViewModel);
                string? loginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _addressService.Create(endereco, loginId);
                return RedirectToAction(nameof(Index));
            }
            return View(enderecoViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var endereco = _addressService.GetById(id);

            if (endereco == null)
            {
                return NotFound();
            }

            var enderecoViewModel = _mapper.Map<EnderecoViewModel>(endereco);
            return View(enderecoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                var endereco = _mapper.Map<Endereco>(enderecoViewModel);
                await _addressService.Update(endereco);
                return RedirectToAction(nameof(Index));
            }

            return View(enderecoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var endereco = _addressService.GetById(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _addressService.Delete(endereco);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExportCsv()
        {
            string? loginId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var csvStream = await _addressService.ExportCsv(loginId!);
            return File(csvStream, "text/csv", "enderecos.csv");
        }
    }
}
