using LMS.Data;
using LMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LMS.Service
{
    public class CategoriesServices : ICategoriesServices
    {

        private SmartLMSDbContext _context;
        public CategoriesServices(SmartLMSDbContext context)
        {
            _context = context;
        }

        public string createCategories(categories category)
        {
            string returnMsg = string.Empty;
            var _category = _context.categories.FirstOrDefault(a => a.title == category.title);

            if (_category == null)
            {
                _context.Add(category);
                _context.SaveChanges();
                returnMsg = "Sucessfully added";
            }
            else
            {
                returnMsg = "Error in adding with existing ";
            }
            return returnMsg;

        }

        public IEnumerable<categories> getAllCategories()
        {
            return _context.categories;
        }

        public categories getCategory(categories category)
        {
            if (category.category_id != Guid.Empty)
                return _context.categories.FirstOrDefault(cat => cat.category_id == category.category_id);
            else
                return _context.categories.FirstOrDefault(cat => cat.title == category.title);

        }

        public string updateCategory(categories category)
        {
            var dbcat = _context.categories
            .Where(cat => cat.category_id == category.category_id)
            .SingleOrDefault();

            if (dbcat != null)
            {
                try
                {
                    dbcat = category;
                    _context.SaveChanges();
                    return "sucessfully updated the category";
                }
                catch (Exception ex)
                {
                    return "unsucessfully in updating" + ex.Message;
                }

            }
            else
                return "no record exists with this catagory id";
        }

    }
}
