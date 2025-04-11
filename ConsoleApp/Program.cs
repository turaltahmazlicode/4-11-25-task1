using System.Reflection;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*            
            User clasi yaradin{
            private id,
            private name,
            private surname
            private static age

            void GetFullName() methodu name+fullname consola yazdirir
            static void ChangeAge(int age) methodu age deyerini deyisir
            }
            Reflection ilə edin

            obyekt instance - sını yaradın.
            Propertilərin dəyərini set edin daha sonra consola yazdırın.
            methodları call edin
            */
            var userType = typeof(User);

            var userInstance = userType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, []).Invoke([]);

            var idField = userType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
            var nameField = userType.GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);
            var surnameField = userType.GetField("surname", BindingFlags.NonPublic | BindingFlags.Instance);
            var ageField = userType.GetField("age", BindingFlags.NonPublic | BindingFlags.Static);
            var getFullNameMethod = userType.GetMethod("GetFullName", BindingFlags.NonPublic | BindingFlags.Instance);
            var changeAgeMethod = userType.GetMethod("ChangeAge", BindingFlags.NonPublic | BindingFlags.Static);
            var showInfoMethod = userType.GetMethod("ShowInfo", BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine("Before:");
            showInfoMethod.Invoke(userInstance, []);

            idField.SetValue(userInstance, Guid.NewGuid());

            nameField.SetValue(userInstance, "Tural");

            surnameField.SetValue(userInstance, "Tahmazli");

            changeAgeMethod.Invoke(userInstance, [20]);

            Console.WriteLine("\nAfter:");

            getFullNameMethod.Invoke(userInstance, []);

            Console.WriteLine(ageField.GetValue(userInstance));

            Console.WriteLine();
            showInfoMethod.Invoke(userInstance, []);
        }
        private class User
        {
            Guid id;
            string? name;
            string? surname;
            static int age;
            User()
            {

            }
            void GetFullName()
            {
                Console.WriteLine($"{name} {surname}");
            }
            static void ChangeAge(int newAge)
            {
                age = newAge;
            }
            void ShowInfo()
            {
                Console.WriteLine($"Id: {id}\nName: {name}\nSurname: {surname}\nAge: {age}");
            }
        }
    }
}
