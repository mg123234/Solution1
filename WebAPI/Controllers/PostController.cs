using DomainLayer.Custom;
using DomainLayer.DTO;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostService _service;
        private readonly UserManager<AppUser> _userManager;
        public PostController(IPostService service, UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        // GET: PostController
        [HttpGet]
        public IActionResult Index(PostVM vModel)
        {
            IActionResult result;
            if (vModel.PageInfo == null)
            {
                vModel.PageInfo = new PageInfo()
                {
                    Controller="Post"
                };
            }
            result = View(vModel);
            vModel.PostList = _service.Index(vModel.PageInfo);
            vModel.PageSizeSelectList = new SelectList(vModel.PageInfo.PageSizeList);
            return result;
        }

        // GET: PostController/Details/5
        [HttpGet("{id:int}")]
        public IActionResult Details(int id)
        {
            IActionResult result;
            PostDetailsVM vModel = new()
            {
                PostDetailsDTO = _service.Details(id) 
            };
            List<SelectListItem> list = new();
            foreach(var item in vModel.PostDetailsDTO.CategoryList)
            {
                list.Add(new SelectListItem()
                {
                    Text=item.CategorySelectDTO.Name
                });
            }
            vModel.CategorySelectList = list;
            result = View(vModel);
            return result;
        }

        // GET: PostController/Create
        public IActionResult Create()
        {
            IActionResult result;
            PostCreateVM vModel = new ()
            {
                CategorySelectList = new SelectList(_service.CategorySelectList(), "Id", "Name").ToList()
            };
            result = View(vModel);
            return result;

        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(PostCreateVM vModel)
        {
            IActionResult result;
            //try
            //{
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(this.User);
                    vModel.PostCreateDTO.UserId = user.Id;
                    _service.Create(vModel.PostCreateDTO);
                    result = RedirectToAction(nameof(Index));
                }
                else
                {
                    vModel.CategorySelectList = new SelectList(_service.CategorySelectList(), "Id", "Name").ToList();
                    vModel.CategorySelectList.Insert(0, new SelectListItem()
                    {
                        Text = "No Parent",
                        Value = null
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

        // GET: PostController/Edit/5
        public IActionResult Edit(int id)
        {
            IActionResult result;
            PostEditVM vModel = new()
            {
                CategorySelectList = new MultiSelectList(_service.CategorySelectList(), "Id", "Name").ToList(),
                PostEditDTO = _service.Edit(id)
            };
            vModel.PostEditDTO.CategoryIdList = vModel.PostEditDTO.PostCategories.Select(x => x.CategoryId).ToList();
            result = View(vModel);
            return result;
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PostEditVM vModel)
        {
            IActionResult result;
            //try
            //{
                if (ModelState.IsValid)
                {
                    _service.Update(vModel.PostEditDTO);
                    result = RedirectToAction(nameof(Index));
                }
                else
                {
                    vModel.CategorySelectList = new SelectList(_service.CategorySelectList(), "Id", "Name").ToList();
                    result = View(vModel);
                }
            //}
            //catch
            //{
            //    result = StatusCode(500, "Internal server error");
            //}
            return result;
        }

        // GET: PostController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
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
