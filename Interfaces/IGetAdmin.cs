using API.Models;
using System.Collections.Generic;

namespace API.Interfaces
{
    public interface IGetAdmin
    {
         Admin GetAdmin(string email);
         List<Admin> GetAllAdmins();

    }
}