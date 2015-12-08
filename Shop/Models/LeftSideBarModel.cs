using System.Collections.Generic;

namespace Shop.Models
{
    public class LeftSideBarModel
    {
        public IEnumerable<ZeroLevelCategotyModel> CategoryModel { get; set; }
    }

    public class ZeroLevelCategotyModel
    {
        public CategoryModel ZeroLevelModel { get; set; }
        public int ProductCount { get; set; }
        public IEnumerable<FirstLevelCategoryModel> FirstLevelCategoies { get; set; }
    }

    public class SecondLevelCategoryModel
    {
        public CategoryModel SecondLevelCategory { get; set; }
        public int ProductCount { get; set; }
    }

    public class FirstLevelCategoryModel
    {
        public CategoryModel FirstLevelCategory { get; set; }
        public IEnumerable<SecondLevelCategoryModel> SecondLevelCategories { get; set; }
        public int ProductCount { get; set; }
    }
}