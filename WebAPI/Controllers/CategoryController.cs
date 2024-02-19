using AutoMapper;
using DomainLayer.Custom;
using DomainLayer.DTO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ServiceLayer.Service;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Areas.Admin.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        // GET: CategoryController
        public IActionResult Index(CategoryVM vModel)
        {
            IActionResult result;
            if (vModel.PageInfo == null)
            {
                vModel.PageInfo = new PageInfo()
                {
                    Controller = "Category"
                };
            }
            vModel.CategoryList = _service.Index(vModel.PageInfo);
            vModel.PageSizeSelectList = new SelectList(vModel.PageInfo.PageSizeList);
            result = View(vModel);
            return result;
        }

        // GET: CategoryController/Details/5
        public IActionResult Details(int id)
        {
            IActionResult result;
            CategoryDetailsVM vModel = new()
            {
                CategoryDetailsDTO = _service.Details(id)
            };
            result = View(vModel);
            return result;
        }

        // GET: CategoryController/Create
        public IActionResult Create()
        {
            IActionResult result;
            CategoryCreateVM vModel = new()
            {
                CategorySelectList = new SelectList(_service.CategorySelectList(), "Id", "Name").ToList()
            };
            vModel.CategorySelectList.Insert(0, new SelectListItem()
            {
                Text = "No Parent",
                Value = ""
            });
            result = View(vModel);
            return result;

        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateVM vModel)
        {
            IActionResult result;
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Create(vModel.CategoryCreateDTO);
                    result = RedirectToAction(nameof(Index));
                }
                else
                {
                    vModel.CategorySelectList = new SelectList(_service.CategorySelectList(), "Id", "Name").ToList();
                    vModel.CategorySelectList.Insert(0, new SelectListItem()
                    {
                        Text = "No Parent",
                        Value = "null"
                    });
                    result = View(vModel);
                }
            }
            catch
            {
                result = StatusCode(500, "Internal server error");
            }
            return result;
        }

        // GET: CategoryController/Edit/5
        public IActionResult Edit(int id)
        {
            IActionResult result;
            CategoryEditVM vModel = new()
            {
                CategorySelectList = new SelectList(_service.CategorySelectList(), "Id", "Name").ToList(),
                CategoryEditDTO = _service.Edit(id)
            };
            vModel.CategorySelectList.Insert(0, new SelectListItem()
            {
                Value = "",
                Text = "No Parent"
            });
            result = View(vModel);
            return result;
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditVM vModel)
        {
            IActionResult result;
            //try
            //{
                if (ModelState.IsValid)
                {
                    _service.Update(vModel.CategoryEditDTO);
                    result = RedirectToAction(nameof(Index));
                }
                else
                {
                    vModel.CategorySelectList = new SelectList(_service.CategorySelectList(), "Id", "Name").ToList();
                    vModel.CategorySelectList.Insert(0, new SelectListItem()
                    {
                        Value = null,
                        Text = "No Parent"
                    });
                    result = View(vModel);
                }
            //}
            //catch
            //{
            //    result = StatusCode(500, "Internal server error");
            //}
            return result;
        }

        // GET: CategoryController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(List<int> idList)
        {
            IActionResult result;
            try
            {
                foreach (var item in idList)
                {
                    _service.Delete(item);
                }
                result = Json(true);
            }
            catch
            {
                result = View();
            }

            return result;
        }
    }
}
