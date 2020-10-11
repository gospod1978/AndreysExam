namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public int Add(DetailsViewModel detailsViewModel)
        {
            var genderAsEnum = Enum.Parse<Gender>(detailsViewModel.Gender);
            var categoryAsEnum = Enum.Parse<Category>(detailsViewModel.Category);

            var product = new Product
            {
                Name = detailsViewModel.Name,
                Description = detailsViewModel.Description,
                ImageUrl = detailsViewModel.ImageUrl,
                Price = detailsViewModel.Price,
                Gender = genderAsEnum,
                Category = categoryAsEnum,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return product.Id;
        }

        public void Delete(int id)
        {
            var product = this.GetDetails(id);
            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public IEnumerable<ProductInfoViewModel> GetAll()
        => this.db.Products.Select(x => new ProductInfoViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
            }).ToArray();


        public Product GetDetails(int id)
        => this.db.Products.FirstOrDefault(x => x.Id == id);
    }
}
