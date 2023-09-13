namespace DoctorModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfExperience { get; set; }
        public string Specialization { get; set; }

        public void TakeDoctorDeatilsFromConsole()
        {
            Console.WriteLine("Please enter the doctor's name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the Year Of Experience");
            YearOfExperience = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter The Specialization doctor's have");
            Specialization = Console.ReadLine();
        }
        public override string ToString()
        {
            return $"Doctor Id : {Id} \n " +
                $"Doctor Name : {Name} \n" +

                $"Doctor Year Of Experience : {YearOfExperience} \n" +
                $"Doctor Type : {Specialization}";
        }
        public override bool Equals(object? obj)
        {
            Doctor d1, d2;
            d1 = (Doctor)obj;
            d2 = this;
            if (d1.Id == d2.Id)
                return true;
            return false;
        }
    }
}