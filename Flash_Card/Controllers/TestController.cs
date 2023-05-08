using Flash_Card.Dtos;
using Flash_Card.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Flash_Card.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IStringLocalizer<TestController> _localization;
        private readonly ApplicationDbContext _db;
       
        public TestController(ApplicationDbContext db,IStringLocalizer<TestController> localization)
        {
            _localization = localization;
            _db = db;
        }

        [HttpGet("{name}")]
        public IActionResult Get()
        {
            var data = _db.Categories.ToList();
            var welcomeMessage=new List<string>();
            foreach (var category in data) 
            {
                //var name = category.CategoryName[0];
            welcomeMessage.Add( string.Format(_localization[category.CategoryName.ToString()]));

              
            }
           
            return Ok(welcomeMessage);
        }
        //[HttpGet("{data.CategoryName}")]
        //public IActionResult Get()
        //{
        //    var data = _db.Categories.FirstOrDefault();

        //    var welcomeMessage = string.Format(_localization["data.CategoryName"], data.CategoryName);
        //    return Ok(welcomeMessage);
        //}
        [HttpPost]
        public IActionResult Get(CreateTestDto dto)
        {
            var welcomeMessage = string.Format(_localization["welcome"], dto.Name);
            return Ok(welcomeMessage);
        }
    }
}