using _15._09._23.CW.DAL.Entity;
using _15._09._23.CW.DAL.Repositories;

namespace _15._09._23.CW
{
    public class StudentsProvider
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentsProvider(IRepository<Student> repository)
        {
            _studentRepository = repository;
        }

        public void AddStudents(List<Student> students)
        {
            students.ForEach(s => AddStudent(s));
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.Get(id);
        }

        public Student GetStudentByCardID(int id)
        {
            var res = GetAllStudents().Where(s => s.StudentCard.ID == id);

            return res.Count() != 0 ? res.First() : null;
        }

        public IEnumerable<Student> GetAllStudents()
        { 
            return _studentRepository.GetAll();
        }

        public void Remove(int id)
        {
            var student = GetStudent(id);
            _studentRepository.Remove(student);
        }

        public void UpdateStudent(int id)
        {
            Student student = GetStudent(id);
            if (student != null)
            {
                Console.WriteLine("Нове iм'я (Enter - залишити поточне):");
                string name = Console.ReadLine();
                name = string.IsNullOrWhiteSpace(name) ? student.Name : name;

                Console.WriteLine("Нове прiзвище (Enter - залишити поточне):");
                string lastName = Console.ReadLine();
                lastName = string.IsNullOrWhiteSpace(lastName) ? student.LastName : lastName;

                Console.WriteLine("Нова дата народження (YYYY-MM-DD) (Enter - залишити поточну):");
                string dateOfBirthInput = Console.ReadLine();
                DateTime dateOfBirth;
                if (!DateTime.TryParse(dateOfBirthInput, out dateOfBirth))
                {
                    dateOfBirth = student.DateOfBirth;
                }

                Console.WriteLine("Нова електронна пошта (Enter - залишити поточну):");
                string mail = Console.ReadLine();
                mail = string.IsNullOrWhiteSpace(mail) ? student.Mail : mail;

                Console.WriteLine("Новий номер телефону (Enter - залишити поточний):");
                string phone = Console.ReadLine();
                phone = string.IsNullOrWhiteSpace(phone) ? student.Phone : phone;

                Student newStudent = new Student()
                {
                    ID = student.ID,
                    Name = name,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    Mail = mail,
                    Phone = phone,
                    StudentCard = student.StudentCard
                };

                _studentRepository.Update(id, newStudent);
            }
        }

        public static Student GetNewStudentFromConsole(CardProvider cardProvider)
        {
            Console.Write("Iм'я студенту: ");
            string name = Console.ReadLine();
            while (name == "")
            {
                Console.WriteLine("Iм'я не може бути пустим!");
                Console.Write("\nIм'я студенту: ");
                name = Console.ReadLine();
            }

            Console.Write("Прiзвище студенту: ");
            string lastname = Console.ReadLine();
            while (lastname == "")
            {
                Console.WriteLine("Прiзвище не може бути пустим!");
                Console.Write("\nПрiзвище студенту: ");
                lastname = Console.ReadLine();
            }

            Console.Write("Дата народження студенту (YYYY-MM-DD): ");
            DateTime dateOfBirth;
            while (DateTime.TryParse(Console.ReadLine(), out dateOfBirth) == false)
            {
                Console.WriteLine("Неправильнi данi");
                Console.Write("\nДата народження студенту (YYYY-MM-DD): ");
            }

            Console.Write("Електронна адреса: ");
            string mail = Console.ReadLine();
            while(mail == "")
            {
                Console.WriteLine("Електронна адреса не може бути пустою!");
                Console.Write("\nЕлектронна адреса: ");
                mail = Console.ReadLine();
            }

            Console.Write("Номер телефону: ");
            string phone = Console.ReadLine();
            while(phone == "")
            {
                Console.WriteLine("Номер телефону не може бути пустим!");
                Console.Write("\nНомер телефону: ");
                phone = Console.ReadLine();
            }

            StudentCard newCard = CardProvider.GetNewStudentCardFromConsole();

            Student newStudent = new Student()
            {
                Name = name,
                LastName = lastname,
                DateOfBirth = dateOfBirth,
                Mail = mail,
                Phone = phone,
                StudentCard = newCard
            };

            return newStudent;
        }

        public IEnumerable<Student> GetStudentsSortedByLastname()
        {
            return GetAllStudents().OrderBy(s => s.LastName);
        }
        public IEnumerable<Student> GetStudentsSortedByAge(bool sort)
        {
            if (sort)
            {
                return GetAllStudents().OrderByDescending(s => s.DateOfBirth);
            }
            else
            {
                return GetAllStudents().OrderBy(s => s.DateOfBirth);
            }
        }

        public IEnumerable<Student> GetStudentsByLastname(string lastname)
        {
            return GetAllStudents().Where(s => s.LastName.ToLower() == lastname.ToLower());
        }

        public void PrintAll(IEnumerable<Student> students)
        {
            Console.WriteLine($"{"ID".ToString().PadRight(5)}" +
                    $"{"Name".PadRight(15)}" +
                    $"{"LastName".PadRight(15)}" +
                    $"{"DateOfBirth".PadRight(15)}" +
                    $"{"Mail".PadRight(25)}" +
                    $"{"Phone".PadRight(15)}" +
                    $"{"Card ID".PadRight(10)}" +
                    $"{"Card Number".PadRight(15)}" +
                    $"{"Start Date".PadRight(15)}" +
                    $"{"Status".PadRight(15)}");

            Console.WriteLine();

            foreach (var student in students)
            { 
                if (student == null)
                {
                    continue;
                }

                Console.Write($"{student.ID.ToString().PadRight(5)}" +
                    $"{student.Name.PadRight(15)}" +
                    $"{student.LastName.PadRight(15)}" +
                    $"{student.DateOfBirth.ToShortDateString().PadRight(15)}" +
                    $"{student.Mail.PadRight(25)}" +
                    $"{student.Phone.PadRight(15)}" +
                    $"{student.StudentCard?.ID.ToString().PadRight(10)}" +
                    $"{student.StudentCard?.CardNumber.PadRight(15)}" +
                    $"{student.StudentCard?.StartDate.ToShortDateString().PadRight(15)}");
                if(student.StudentCard != null)
                {
                    Console.WriteLine($"{(student.StudentCard.IsActive ? "Active" : "Inactive").PadRight(15)}");
                }   
            }
        }
        public void PrintStudents(IEnumerable<Student> students)
        {
            Console.WriteLine($"{"ID".ToString().PadRight(5)}" +
                    $"{"Name".PadRight(15)}" +
                    $"{"LastName".PadRight(15)}" +
                    $"{"DateOfBirth".PadRight(15)}" +
                    $"{"Mail".PadRight(25)}" +
                    $"{"Phone".PadRight(15)}");

            Console.WriteLine();

            foreach (var student in students)
            {
                if(student == null)
                {
                    continue;
                }

                Console.WriteLine($"{student.ID.ToString().PadRight(5)}" +
                    $"{student.Name.PadRight(15)}" +
                    $"{student.LastName.PadRight(15)}" +
                    $"{student.DateOfBirth.ToShortDateString().PadRight(15)}" +
                    $"{student.Mail.PadRight(25)}" +
                    $"{student.Phone.PadRight(15)}");
            }
        }
    }
}
