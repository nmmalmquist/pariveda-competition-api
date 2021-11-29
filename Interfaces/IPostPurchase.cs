using API.Models;

namespace API.Interfaces
{
    public interface IPostPurchase
    {
         void AddPurchase (Purchase newPurchase);
    }
}