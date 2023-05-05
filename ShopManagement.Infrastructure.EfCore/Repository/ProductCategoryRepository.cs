using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository:IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public void Create(ProductCategory entity)
        {
            _shopContext.ProductCategories.Add(entity);
        }

        public void Update(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public ProductCategory Get(long id)
        {
            return _shopContext.ProductCategories.Find(id);
        }

        public List<ProductCategory> GetAll()
        {
            return _shopContext.ProductCategories.ToList();
        }

        public bool Exists(Expression<Func<ProductCategory, bool>> expression)
        {

          return  _shopContext.ProductCategories.Any(expression);
        }

        public void SaveChanges()
        {
            _shopContext.SaveChanges();
        }

        public EditProductCategory? GetDetails(long id)
        {
            return _shopContext.ProductCategories.Select(x => new EditProductCategory()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureDescription = x.PictureDescription,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription
                    ,Slug = x.Slug }).FirstOrDefault(x => x.Id == id);
            ;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {

            var query = _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                CreationDate = x.CreationDate.ToString(),
                ProductCount = 0
                });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
