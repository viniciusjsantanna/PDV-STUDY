using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PDV.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRestClient http;
        public ProductController(IRestClient http)
        {
            this.http = http;
            this.http.BaseUrl = new Uri("https://localhost:44382/");
        }

        //HTTP -> POST, PUT, DELETE, GET
        //Request - Response
        //Códigos
        //200 - OK
        //404 - Bad Request
        //500 - internal server error
        [HttpGet]
        public IActionResult Get()
        {
            var uri = "api/Inventory";

            var request = new RestRequest(uri, Method.GET);

            var response = http.Execute(request);
            if (response.IsSuccessful)
            {

                var dto = JsonConvert.DeserializeObject<ResponseDTO>(response.Content);
                return Ok(response.Content);
            }

            return BadRequest(response.ErrorMessage);
        }

    }
}
