using Flash_Card.Entity;
using Flash_Card.Model;
using Flash_Card.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Net;

namespace Flash_Card.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly ApplicationDbContext _db;
        //public CategoryController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}

        //[HttpPost]
        //public  async Task<IActionResult> create([FromForm] CategoryModel model) 
        //{
        // Category category=new Category();
        //    category.CategoryName=model.CategoryName;
        //    category.CategoryDescription=model.CategoryDescription;
        //    _db.Categories.Add(category);
        //    _db.SaveChanges();
        //    return Ok();

        //}
        private readonly ICategoryService _Categoryservice;
        private readonly IStringLocalizer<CategoryController> _localization;


        public CategoryController(ICategoryService categoryservice, IStringLocalizer<CategoryController> localization)
        {
            _Categoryservice = categoryservice;
            _localization = localization;

        }

        //[HttpGet()]
        //public async Task<IActionResult> GetAll()
        //{
        //    var Result = await _Categoryservice.GetAllAsync();
        //    return Ok(Result);
        //}
        //client.DefaultRequestHeaders.AcceptLanguage.TryParseAdd("fr-FR");
        [HttpGet()]
        public async Task<IActionResult> GetAllProducts()
        {
            var Result = await _Categoryservice.GetAllCProducts();
  
            return Ok(Result);
        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var Result = _Categoryservice.GetById(id);
           
            return Ok(Result);
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Create([FromForm] CategoryModel model)
        {
            try
            {
                await _Categoryservice.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] CategoryUpdate model)
        {

            try
            {
                await _Categoryservice.Update(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {

            _Categoryservice.Delete(id);
            return Ok();
        }


    }
}
