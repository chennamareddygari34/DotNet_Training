using DoctorBLLibrary;
using DoctorDALLibrary;
using DoctorModelLibrary;
namespace DoctorsApp
{
    internal class Program
    {


        ManageDoctor manageDoctor = new ManageDoctor();
        void InitializingApplication()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to the Doctors Data Application");
                Console.WriteLine("1. Enter the Doctors name");
                Console.WriteLine("2. List the Doctors");
                Console.WriteLine("3. List Doctor by Specialization");
                Console.WriteLine("4. List Doctor by Age");
                Console.WriteLine("0. Exit App");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Byeeeeeee");
                        break;
                    case 1:
                        InitiazeDoctorsName();
                        break;
                    case 2:
                        ListOfDoctors();
                        break;
                    case 3:
                        ListBySpecialization();
                        break;
                    case 4:
                        ListByDoctorAge();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 0);
        }

        private void ListBySpecialization()
        {
            Console.WriteLine("Please enter the Specialization of Doctor ");
            try
            {
                string type = Console.ReadLine().ToLower();
                List<Doctor> doctors = manageDoctor.GetDoctorByType(type).ToList();
                PrintDoctors(doctors);
            }
            catch (DoctorsNotAvailableException dnae)
            {
                Console.WriteLine(dnae.Message);
            }
            catch (InvalidDoctorException ide)
            {
                Console.WriteLine(ide.Message);
            }
        }
        private void ListByDoctorAge()
        {
            try
            {
                Console.WriteLine("Please enter the min AGE");
                int min = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the max AGE");
                int max = Convert.ToInt32(Console.ReadLine());
                List<Doctor> doctors = manageDoctor.GetPizzasByYearOfExperience(min, max).ToList();
                PrintDoctors(doctors);
            }
            catch (DoctorsNotAvailableException dnae)
            {
                Console.WriteLine(dnae.Message);
            }
            catch (InvalidDoctorException ide)
            {
                Console.WriteLine(ide.Message);
            }
        }
        void PrintDoctors(ICollection<Doctor> doctors)
        {
            foreach (Doctor p in doctors)
            {
                Console.WriteLine(p);
            }
        }
        void ListOfDoctors()
        {
            List<Doctor> doctors = manageDoctor.GetDoctor().ToList();
            PrintDoctors(doctors);
        }
        void InitiazeDoctorsName()
        {
            do
            {
                Console.WriteLine("Please enter the Doctors Details");
                Doctor doctor = new Doctor();
                doctor.TakeDoctorDeatilsFromConsole();
                manageDoctor.AddANewDoctor(doctor);
                Console.WriteLine("Search For Another Doctor");
                string choice = Console.ReadLine().ToLower();
                if (choice != "yes")
                    break;

            } while (true);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.InitializingApplication();

            Console.ReadKey();
        }

    }
}