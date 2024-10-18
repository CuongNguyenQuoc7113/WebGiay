using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Project_WEBSITE.Models;
using Project_WEBSITE.Repositories;
using System.Diagnostics;

namespace Project_WEBSITE.Controllers
{
	public class HomeController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;

		public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository) 
		{
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}
		public async Task<IActionResult> Index()
		{
			var product = await _productRepository.GetAllAsync();
			return View(product);
		}
		
	}
}