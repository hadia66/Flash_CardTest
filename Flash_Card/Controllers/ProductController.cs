using Flash_Card.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Flash_Card.Model;
using Flash_Card.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Flash_Card.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductservice _Productservice;
        public ProductController(IProductservice productservice)
        {
            _Productservice = productservice;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var Result = await _Productservice.GetAllAsync();
            return Ok(Result);
        }


        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var Result = _Productservice.GetById(id);
            return Ok(Result);
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Create([FromForm] ProductModel model)
        {
            try
            {
                await _Productservice.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ProductUpdate model)
        {

            try
            {
                await _Productservice.Update(id, model);
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

            _Productservice.Delete(id);
            return Ok();
        }

    }
}
