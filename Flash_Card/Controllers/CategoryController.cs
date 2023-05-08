using Flash_Card.Entity;
using Flash_Card.Model;
using Flash_Card.Service;
using Google.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Net;
using System.Text;
using Google.Cloud.Translation.V2;

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
        private readonly ITranslationService _Translate;

        public CategoryController(ICategoryService categoryservice,
            IStringLocalizer<CategoryController> localization,
            ITranslationService translate)
        {
            _Categoryservice = categoryservice;
            _localization = localization;
            _Translate = translate;
        }

        //[HttpGet()]
        //public async Task<IActionResult> GetAll()
        //{
        //    var Result = await _Categoryservice.GetAllAsync();
        //    return Ok(Result);
        //}

        [HttpGet()]
        public async Task<IActionResult> GetData()
        {
            var data = await _Categoryservice.GetAllAsync();
          
            var welcomeMessage = new List<string>();
            foreach (var category in data)
            {
                //var name = category.CategoryName[0];
                welcomeMessage.Add(string.Format(_localization[category.CategoryName.ToString()]));


            }

            return Ok(welcomeMessage);
        }
        //[HttpGet()]
        //public async Task<IActionResult> GetAll(string ln)
        //{

        //    var Result = await _Categoryservice.GetAllAsync();
        //    var Response = _Translate.Translate(Result[0].CategoryName,ln);
        //    return Ok(Response);
        //}


        //[HttpGet()]
        //public async Task<IActionResult> GetAllProducts()
        //{
        //    var Result = await _Categoryservice.GetAllCProducts();

        //    return Ok(Result);
        //}


        //[HttpGet("{id}")]
        //public IActionResult Get([FromRoute] int id)
        //{
        //    var Result = _Categoryservice.GetById(id);

        //    return Ok(Result);
        //}

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
