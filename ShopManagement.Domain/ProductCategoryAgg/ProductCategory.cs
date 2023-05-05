using _0_Framework.Domain;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory:EntityBase
    {
        public string Name { get;private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureDescription { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }

        public ProductCategory(string name, string description, string picture,
                               string pictureAlt, string pictureDescription,
                               string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureDescription = pictureDescription;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
        public void Edit(string name, string description, string picture,
                         string pictureAlt, string pictureDescription,
                         string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureDescription = pictureDescription;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }
}
