using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.database;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dogController : ControllerBase
    {
        // GET: api/dog
        [EnableCors("dogDBPolicy")]
        [HttpGet]
        public List<Dog> Get()
        {
            IGetDogData readObject = new GetDog();
            return readObject.GetAllDogs("All"); //the 'All' string argument has to be put in because GetAllDogs needs a string, within GetAllDogs, the argument determines the sql statement
        }

        // GET: api/dog/buy
        [EnableCors("dogDBPolicy")]
        [HttpGet("{saleType}", Name = "GetSaleType")]
        //salesType valid inputs: all, buy, or rent
        public List<Dog> Get(string saleType)
        {
            IGetDogData readObject = new GetDog();
            return readObject.GetAllDogs(saleType);
        }
        // GET: api/dog/buy
        [EnableCors("dogDBPolicy")]
        [HttpGet("all/get/recent", Name = "GetMostRecentDog")]
        public Dog GetMostRecentDog()
        {
            GetDog readObject = new GetDog();
            return readObject.GetMostRecentDog();
        }

        // GET: api/dog/rent/5
        [EnableCors("dogDBPolicy")]
        [HttpGet("{salesType}/{id}", Name = "GetId")]
        public Dog Get(string saleType, int id)
        {
            IGetDogData readObject = new GetDog();
            return readObject.GetDog(id);
        }

        // POST: api/dog
        [EnableCors("dogDBPolicy")]
        [HttpPost]
        public void Post([FromBody] Dog dog) //using [FromBody] refers to what object will be passed in from the fetch call. In this case, we say in the fetch POST that the body is a json string, so it will take that string and turn it into a c# dog object 
        {
            ISaveDog saveObject = new SaveDog();
            saveObject.CreateDog(dog);
        }

        // PUT: api/dog/5
        [EnableCors("dogDBPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Dog dog)
        {

            ISaveDog saveObject = new SaveDog();
            saveObject.SaveDog(dog);
        }

        // DELETE: api/dog/5
        [EnableCors("dogDBPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteDog deleteObject = new DeleteDog();
            deleteObject.DeleteDog(id);
        }
    }
}
