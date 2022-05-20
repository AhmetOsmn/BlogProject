using BusinessLayer.Abstract.Generic;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogListWithCategoryByWriter(int id);
        List<Blog> GetBlogListByWriter(int id);
        List<Blog> GetBlogById(int id);
        List<Blog> GetLast3Blog();
    }
}
