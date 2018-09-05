using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LMS.Service;
using LMS.Data.Models;

namespace LMS.Web.Controllers
{
    public class CatalogController : Controller
    {

        private readonly ICategoriesServices _categoriesServices;

        public CatalogController(ICategoriesServices categoriesServices)
        {
            _categoriesServices = categoriesServices;

        }

        public IActionResult Index()
        {
            IEnumerable<CatagoryModel> listCatagorydto = Mapper.Map<IEnumerable<categories>, IEnumerable<CatagoryModel>>(_categoriesServices.getAllCategories());
            return View(listCatagorydto);
        }

       
        public IActionResult CreateCatalog(CatagoryModel catagory)
        {
            if (ModelState.IsValid)
            {
                catagory.category_id = Guid.NewGuid();
                categories catagorydto = Mapper.Map<CatagoryModel, categories>(catagory);
                _categoriesServices.createCategories(catagorydto);
                ViewBag.Message = catagory.title + "Successfully Registered.";
            }
            return View();
        }


        public IActionResult GetResult()
        {
            IEnumerable<CatagoryModel> listCatagorydto = Mapper.Map<IEnumerable<categories>, IEnumerable<CatagoryModel>>(_categoriesServices.getAllCategories());
            return View(listCatagorydto);
        }

    }
}
