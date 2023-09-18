using _15._09._23.CW.DAL;
using _15._09._23.CW.DAL.Entity;
using _15._09._23.CW.DAL.Repositories;
using Newtonsoft.Json;

namespace _15._09._23.CW
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new StudentsContext();
            Menu(context);
        }

        private static void Menu(StudentsContext context)
        {
            var repositoryCards = new Repository<StudentCard>(context);

            CardProvider cardProvider = new CardProvider(repositoryCards);

            { var cards = cardProvider.GetAllCards(); }

            var repositoryStudents = new Repository<Student>(context);

            StudentsProvider studentProvider = new StudentsProvider(repositoryStudents);

            int choice = -1;

            while(choice != 0)
            {
                Console.WriteLine("\nВведiть свiй вибiр\n");
                Console.WriteLine("1 - Показати всю iнформацiю");
                Console.WriteLine("2 - Показати всiх студентiв");
                Console.WriteLine("3 - Показати всi студентськi бiлети");
                Console.WriteLine();
                Console.WriteLine("4 - Знайти студента за ID");
                Console.WriteLine("5 - Знайти студентський бiлет за ID");
                Console.WriteLine("6 - Знайти студента за ID студентського бiлету");
                Console.WriteLine();
                Console.WriteLine("7 - Додати нового студента");
                Console.WriteLine("8 - Оновити данi про студента");
                Console.WriteLine("9 - Оновити данi про студентський бiлет");
                Console.WriteLine();
                Console.WriteLine("10 - Показати усi неактивнi студентськi бiлети");
                Console.WriteLine("11 - Показати студентiв у алфавiтному порядку");
                Console.WriteLine("12 - Показати всiх студентiв з певним прiзвищем");
                Console.WriteLine("13 - Показати всiх студентiв вiд наймолодшого до найстаршого");
                Console.WriteLine("14 - Показати всiх студентiв вiд найстаршого до наймолодшого");
                Console.WriteLine("15 - Показати всi студентськi бiлети, що починаються з певного тексту");
                Console.WriteLine();
                Console.WriteLine("16 - Видалити iснуючого студента");
                Console.WriteLine("17 - Видалити iснуючий студентський бiлет");
                Console.WriteLine();
                Console.WriteLine("0 - Вихiд");

                if(int.TryParse(Console.ReadLine(), out choice) == false)
                {
                    choice = -1;
                }

                switch(choice)
                {
                    case 1:
                        Console.Clear();
                        studentProvider.PrintAll(studentProvider.GetAllStudents());
                        break;
                    case 2:
                        Console.Clear();
                        studentProvider.PrintStudents(studentProvider.GetAllStudents());
                        break;
                    case 3:
                        Console.Clear();
                        cardProvider.PrintCards(cardProvider.GetAllCards());
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Введiть ID студента, котрого хочете знайти");
                        int id;

                        if(int.TryParse(Console.ReadLine(), out id))
                        {
                            studentProvider.PrintStudents(new List<Student>()
                            { studentProvider.GetStudent(id) });
                        }

                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Введiть ID студентського бiлету, котрий хочете знайти");

                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            cardProvider.PrintCards(new List<StudentCard>()
                            { cardProvider.GetCard(id) });
                        }

                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Введiть ID студентського бiлету студента, котрого хочете знайти");

                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            studentProvider.PrintAll(new List<Student>()
                            { studentProvider.GetStudentByCardID(id) });
                        }
                        
                        break;
                    case 7:
                        Console.Clear();
                        studentProvider.AddStudent(StudentsProvider.GetNewStudentFromConsole(cardProvider));
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Введiть ID студента, iнформацiю про якого ви хочете оновити");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            studentProvider.UpdateStudent(id);
                        }
                        break;
                    case 9:
                        Console.Clear();
                        Console.WriteLine("Введiть ID студентського бiлету, iнформацiю про який ви хочете оновити");
                        if(int.TryParse(Console.ReadLine(), out id))
                        {
                            cardProvider.UpdateCard(id);
                        }
                        
                        break;
                    case 10:
                        Console.Clear();
                        cardProvider.PrintCards(cardProvider.GetAllInactiveCards());
                        break;
                    case 11:
                        Console.Clear();
                        studentProvider.PrintStudents(studentProvider.GetStudentsSortedByLastname());
                        break;
                    case 12:
                        Console.Clear();
                        Console.Write("Введiть прiзвище: ");
                        string lastname = Console.ReadLine();
                        studentProvider.PrintStudents(studentProvider.GetStudentsByLastname(lastname));
                        break;
                    case 13:
                        Console.Clear();
                        studentProvider.PrintStudents(studentProvider.GetStudentsSortedByAge(true));
                        break;
                    case 14:
                        Console.Clear();
                        studentProvider.PrintStudents(studentProvider.GetStudentsSortedByAge(false));
                        break;
                    case 15:
                        Console.Clear();
                        Console.WriteLine("Введiть початок студентського бiлету");
                        string cardStart = Console.ReadLine();

                        cardProvider.PrintCards(cardProvider.GetCardsStartsWith(cardStart));
                        break;
                    case 16:
                        Console.Clear();
                        Console.WriteLine("Введiть ID студента, якого хочете видалили");
                        while(int.TryParse(Console.ReadLine(), out id) == false)
                        {
                            Console.WriteLine("Неправильний формат даних!");
                        }

                        try
                        {
                            studentProvider.Remove(id);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 17:
                        Console.Clear();
                        Console.WriteLine("Введiть ID студентського бiлету, який хочете видалили");
                        while (int.TryParse(Console.ReadLine(), out id) == false)
                        {
                            Console.WriteLine("Неправильний формат даних!");
                        }

                        try
                        {
                            cardProvider.RemoveCard(id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Помилковий вибiр");
                        break;
                }
            }
        }

        private static void AddTestData(string jsonPath, StudentsProvider provider)
        {
            string contents = File.ReadAllText(jsonPath);

            ListStudents testStudents = JsonConvert.DeserializeObject<ListStudents>(contents);

            var students = testStudents.Students;

            provider.AddStudents(students);
        }
    }

    public class ListStudents
    {
        public List<Student> Students;
    }
}