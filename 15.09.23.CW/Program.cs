using _15._09._23.CW.DAL;
using _15._09._23.CW.DAL.Entity;
using _15._09._23.CW.DAL.Repositories;
using Newtonsoft.Json;

namespace _15._09._23.CW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string jsonPath = "E:\\Шаг\\Домашки\\ADO.NET\\Классные работы\\9\\[--15.09.23.CW--]\\15.09.23.CW\\15.09.23.CW\\Students.json";

            //string contents = File.ReadAllText(jsonPath);

            //ListStudents testStudents = JsonConvert.DeserializeObject<ListStudents>(contents);

            //var students = testStudents.Students;

            var context = new StudentsContext();

            var repositoryCards = new Repository<StudentCard>(context);

            CardProvider cardProvider = new CardProvider(repositoryCards);

            var cards = cardProvider.GetAllCards();

            //provider.AddStudents(students);

            foreach(var card in cards)
            {
                Console.WriteLine($"{card.ID.ToString().PadRight(5)}" +
                    $"{card.CardNumber.PadRight(15)}" +
                    $"{card.StartDate.ToShortDateString().PadRight(15)}" +
                    $"{card.IsActive}");
            }

            var repository = new Repository<Student>(context);

            StudentsProvider provider = new StudentsProvider(repository);

            var students = provider.GetAllStudents();

            foreach (var student in students)
            {
                Console.WriteLine($"{student.ID.ToString().PadRight(5)}" +
                    $"{student.Name.PadRight(15)}" +
                    $"{student.LastName.PadRight(15)}" +
                    $"{student.DateOfBirth.ToShortDateString().PadRight(15)}" +
                    $"{student.Mail.PadRight(25)}" +
                    $"{student.Phone.PadRight(15)}" +
                    $"{student.StudentCard.ID.ToString().PadRight(5)}" +
                    $"{student.StudentCard.CardNumber.PadRight(15)}" +
                    $"{student.StudentCard.StartDate.ToShortDateString().PadRight(15)}" +
                    $"{student.StudentCard.IsActive}");
            }
        }
    }

    public class ListStudents
    {
        public List<Student> Students;
    }
}