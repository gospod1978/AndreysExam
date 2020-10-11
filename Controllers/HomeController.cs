namespace Andreys.App.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IProductsService productsService;

        public HomeController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("/")] 
        public HttpResponse IndexSlash ()
        {
            return this.Index();
        }

        public HttpResponse Index()
        {
            return this.View();
        }

        public HttpResponse Home()
        {
            if (this.IsUserLoggedIn())
            {
                var products = productsService.GetAll();
                return this.View(products, "Home");
            }

            return this.Index();
        }
    }
}
