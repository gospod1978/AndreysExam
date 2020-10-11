namespace Andreys.Services
{
    using System.Collections.Generic;
    using Andreys.Models;
    using Andreys.ViewModels.Products;

    public interface IProductsService
    {
        int Add(DetailsViewModel detailsViewModel);

        Product GetDetails(int id);

        IEnumerable<ProductInfoViewModel> GetAll();

        void Delete(int productId);
    }
}
