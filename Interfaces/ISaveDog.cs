using API.Models;

namespace API.Interfaces
{
    public interface ISaveDog
    {
         void CreateDog(Dog myDog);
         void SaveDog(Dog myDog);
    }
}