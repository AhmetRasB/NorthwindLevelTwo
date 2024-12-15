using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService; 
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService) // Constructor
        {
            _cartService = cartService; // Dependency Injection
            _cartSessionHelper = cartSessionHelper; // Dependency Injection
            _productService = productService; // Dependency Injection
        }
        public IActionResult AddToCart(int productId) // Sepete Ürün Ekleme
        {
            Product product = _productService.GetById(productId); // Ürünü Çek
            var cart = _cartSessionHelper.getCart("cart"); // Sepeti Çek
            _cartService.AddToCart(cart, product); // Sepete Ekle
            _cartSessionHelper.setCart("cart",cart); // Sepeti Güncelle
            TempData.Add("message", product.ProductName + " sepete eklendi!");
            return RedirectToAction("Index", "Product"); // Ürünlerin Listelendiği Sayfaya Yönlendir
            
            
        }
        public IActionResult RemoveFromCart(int productId) // Sepetten Ürün Çıkarma
        {
            Product product = _productService.GetById(productId); // Ürünü Çek
            var cart = _cartSessionHelper.getCart("cart"); // Sepeti Çek
            _cartService.RemoveFromCart(cart, productId); // Sepetten Ürünü Çıkar
            _cartSessionHelper.setCart("cart",cart); // Sepeti Güncelle
            TempData.Add("deleteMessage", product.ProductName + " Sepetten silindi!");
            return RedirectToAction("Index", "Cart"); // Ürünlerin Listelendiği Sayfaya Yönlendir
            
        }
        public IActionResult Index()
        {
            var model = new CartlistViewModel
            {
                Cart = _cartSessionHelper.getCart("cart")
            };
            return View(model);
        }

        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("completeMessage", "Siparişiniz alındı, teşekkür ederiz!");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Cart");
        }
    }
}
