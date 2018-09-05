using LMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Service
{
    public interface ICategoriesServices
    {
        string createCategories(categories category);
        categories getCategory(categories category);
        string updateCategory(categories category);
        IEnumerable<categories> getAllCategories();
    }
}
