using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoMVC.EntitiesFrameWork.Entites;

namespace WebDemoMVC.CategoryManager
{
    public interface ICategory
    {
        List<Category> Categories_GetList(int cateId, string Name);
        int Category_InsertUpdate(Category category , int IsUpdate);
        int Category_Delete(int CateId);
    }
}
