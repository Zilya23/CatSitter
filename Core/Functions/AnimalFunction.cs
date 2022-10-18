using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core.Functions
{
    public class AnimalFunction
    {
        public static List<Animal> GetAnimals()
        {
            return bd_connection.connection.Animal.ToList();
        }

        public static int AnimaleUniq(int IDUser, int IDAnimal)
        {
            return bd_connection.connection.User_Animal.Count(x => x.IDAnimal == IDAnimal && x.IDUser == IDUser);
        }

        public static void SaveAnimalUser(User_Animal userAnimal)
        {
            bd_connection.connection.User_Animal.Add(userAnimal);
        }

        public static List<User_Animal> GetUserAnimals(int IDUser)
        {
            return bd_connection.connection.User_Animal.Where(x => x.IDUser == IDUser).ToList();
        }

        public static void DeleteUserAnimal(int IDUser, int IDAnimal)
        {
            var selectUserAnimal = bd_connection.connection.User_Animal.ToList().Find(x => x.IDUser == IDUser && x.IDAnimal == IDAnimal);
            bd_connection.connection.User_Animal.Remove(selectUserAnimal);
        }

        public static void DeleteUserAnimal(User user, User_Animal animal)
        {
            var selectedAnimal = user.User_Animal.FirstOrDefault(x => x.IDAnimal == animal.IDAnimal && x.IDUser == animal.IDUser);
            user.User_Animal.Remove(selectedAnimal);
        }
    }
}
