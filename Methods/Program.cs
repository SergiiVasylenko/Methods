using System;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = GetInformation();
            Display(user);

            Console.ReadKey();
        }

        static (string Name, string LastName, int Age, bool IsPet, int CountPets, string[] PetNames, int CountColors, string[] ColorNames) GetInformation()
        {
            (string Name, string LastName, int Age, bool IsPet, int CountPets, string[] PetNames, int CountColors, string[] ColorNames) user;

            user.CountPets = 0;
            user.PetNames = new string[0];

            Console.Write("Enter Name: ");
            user.Name = Console.ReadLine();

            Console.Write("\nEnter LastName: ");
            user.LastName = Console.ReadLine();

            user.Age = GetNumber("Enter Age");

            Console.Write("\nDou you have pets? Enter true or false ");
            user.IsPet = bool.Parse(Console.ReadLine());

            if (user.IsPet)
            {
                Console.Write("\nHow many pets do you have?");
                user.CountPets = GetNumber("Enter count of pets");
                user.PetNames = GetArrayFromKey("Enter pet names", user.CountPets);
            }
            
            user.CountColors = GetNumber("Enter count of colors");
            user.ColorNames = GetArrayFromKey("Enter color names", user.CountColors);

            return user;
        }

        static int GetNumber(string question)
        {
            bool isNumber;
            int result;
            do
            {
                Console.Write("\n{0}: ", question);
                var numStr = Console.ReadLine();
                isNumber = int.TryParse(numStr, out result);
            } while (!(isNumber && result > 0));

            return result;

        }
        static string[] GetArrayFromKey(string question, int count)
        {
            var array = new string[count];

            for (int i = 0; i < count; i++)
            {
                Console.Write("\n{0}:", question);
                array[i] = Console.ReadLine();
            }

            return array;
        }

        static void Display((string Name, string LastName, int Age, bool IsPet, int CountPets, string[] PetNames, int CountColors, string[] ColorNames) User)
        {
            Console.WriteLine("Name:{0}", User.Name);
            Console.WriteLine("LastName:{0}", User.LastName);
            Console.WriteLine("Age:{0}", User.Age);
            Console.WriteLine("IsPet:{0}", User.IsPet);
            Console.WriteLine("CountPets:{0}", User.CountPets);
            Console.WriteLine("PetNames:{0}", string.Join(", ", User.PetNames));
            Console.WriteLine("CountColors:{0}", User.CountColors);
            Console.WriteLine("ColorNames:{0}", string.Join(", ", User.ColorNames));
        }

    }
}
