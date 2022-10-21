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

        public static int AnimaleUniqApp(int IDApplication, int IDAnimal)
        {
            return bd_connection.connection.Application_Animal.Count(x => x.ID_Animal == IDAnimal && x.ID_Application == IDApplication);
        }

        public static void SaveAnimalUser(User_Animal userAnimal)
        {
            bd_connection.connection.User_Animal.Add(userAnimal);
        }

        public static void SaveAnimalApplication(Application_Animal applicationAnimal)
        {
            bd_connection.connection.Application_Animal.Add(applicationAnimal);
        }

        public static void DeleteUserAnimal(User user, User_Animal animal)
        {
            var selectedAnimal = user.User_Animal.FirstOrDefault(x => x.IDAnimal == animal.IDAnimal && x.IDUser == animal.IDUser);
            user.User_Animal.Remove(selectedAnimal);
        }

        public static void DeleteApplicationAnimal(Applictioon applictioon, Application_Animal animal)
        {
            var selectedAnimal = applictioon.Application_Animal.FirstOrDefault(x => x.ID_Animal == animal.ID_Animal && x.ID_Application == animal.ID_Application);
            applictioon.Application_Animal.Remove(selectedAnimal);
        }

        public static void SaveAnimalApplicqation(List<Application_Animal> applicationAnimals)
        {
            foreach(var i in applicationAnimals)
            {
                bd_connection.connection.Application_Animal.Add(i);
            }
            bd_connection.connection.SaveChanges();
        }
    }
}
