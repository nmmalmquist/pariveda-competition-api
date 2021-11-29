using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API.Models;
using API.Interfaces;
using API.database;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class purchaseController : ControllerBase
    {
        // GET: api/purchase
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/purchase/5
        [HttpGet("{id}", Name = "GetPurchase")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/purchase
        [EnableCors("dogDBPolicy")]
        [HttpPost]
        public void Post([FromBody] Purchase newPurchase)
        {
            IPostPurchase purchObj = new SavePurchase();
            purchObj.AddPurchase(newPurchase);
        }

        // PUT: api/purchase/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/purchase/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
