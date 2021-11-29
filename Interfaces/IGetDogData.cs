using System.Collections.Generic;
using API.Models;

namespace API.Interfaces
{
    public interface IGetDogData
    {
        List<Dog> GetAllDogs(string saleType);
        Dog GetDog(int id);
    }
}