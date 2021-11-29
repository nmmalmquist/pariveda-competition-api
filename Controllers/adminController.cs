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
    public class adminController : ControllerBase
    {
        // GET: api/admin
        [EnableCors("dogDBPolicy")]
        [HttpGet]
        public List<Admin> Get()
        {
            IGetAdmin readObj = new GetAdmins();
            return readObj.GetAllAdmins();
        }

        // GET: api/admin/5
        [EnableCors("dogDBPolicy")]
        [HttpGet("{email}", Name = "GetAdmin")]
        public Admin Get(string email)
        {
            IGetAdmin readObject = new GetAdmins();
            return readObject.GetAdmin(email);

        }

        // POST: api/admin
        [EnableCors("dogDBPolicy")]
        [HttpPost]
        public void Post([FromBody] Admin newAdmin)
        {
            ICreateAdmin createObj = new SaveAdmin();
            createObj.AddAdmin(newAdmin);

        }

        // PUT: api/admin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/admin/5
        [EnableCors("dogDBPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteAdmin deleteObj = new DeleteAdmin();
            deleteObj.DeleteAdmin(id);
        }
    }
}
