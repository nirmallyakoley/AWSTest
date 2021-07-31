using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using ContosoGamingAPI.BL;
using ContosoGamingAPI.PoCo;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoGamingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IOperation objLandMarkOperation;
        public RouteController(IOperation _objLandMarkOperation)
        {
            objLandMarkOperation = _objLandMarkOperation;
        }
        // GET: api/<RouteController>
        [HttpGet("{nodes}/{route}")]
        public IActionResult Get(string nodes, string route)
        {
            string[] nodeArr = nodes.Trim().Split(',');

            foreach (string element in nodeArr)
            {
                objLandMarkOperation.CreateLandmarkNode(element.Trim());
            }
            int distance = objLandMarkOperation.CalculateDistance(route.Trim());

            var result = new Result()
            {
                Distance = distance < 0 ? "Path not found" : distance.ToString(),
                Stop = objLandMarkOperation.Stop.ToString()
            };
            return Ok(result);
        }


    }
}
