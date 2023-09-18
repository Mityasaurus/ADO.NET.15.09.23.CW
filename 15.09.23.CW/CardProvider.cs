using _15._09._23.CW.DAL.Entity;
using _15._09._23.CW.DAL.Repositories;

namespace _15._09._23.CW
{
    public class CardProvider
    {
        private readonly IRepository<StudentCard> _repository;

        public CardProvider(IRepository<StudentCard> repository)
        {
            _repository = repository;
        }

        public void AddCards(List<StudentCard> cards)
        {
            cards.ForEach(c => AddCard(c));
        }

        public void AddCard(StudentCard card)
        {
            _repository.Add(card);
        }

        public void RemoveCard(int Id)
        {
            var card = GetCard(Id);
            _repository.Remove(card);
        }

        public StudentCard GetCard(int Id)
        {
            return _repository.Get(Id);
        }

        public IEnumerable<StudentCard> GetAllCards()
        {
            return _repository.GetAll();
        }

        public void UpdateCard(int id)
        {
            StudentCard card = GetCard(id);
            if(card != null) 
            {
                Console.WriteLine("Новий номер студентського бiлету (Enter - залишити поточний) :");
                string number = Console.ReadLine();

                number = number == "" ? card.CardNumber : number;

                Console.WriteLine("Нова дата початку дiї (YYYY-MM-DD) (Enter - залишити поточну):");
                string date = Console.ReadLine();
                DateTime startDate;
                if(DateTime.TryParse(date, out startDate) == false)
                {
                    startDate = card.StartDate;
                }

                Console.WriteLine($"Змiнити статус \"{(card.IsActive ? "Active" : "Inactive")}\" на протилежний? (1 - Так | 0 - Нi)");
                string ans = Console.ReadLine();
                bool isActive = card.IsActive;
                if(ans == "1")
                {
                    isActive = card.IsActive ? false : true;
                }

                StudentCard newCard = new StudentCard()
                {
                    ID = card.ID,
                    CardNumber = number,
                    StartDate = startDate,
                    IsActive = isActive
                };

                _repository.Update(id, newCard);
            }
        }

        public IEnumerable<StudentCard> GetAllInactiveCards()
        {
            return _repository.GetAll().Where(c => c.IsActive == false);
        }

        public IEnumerable<StudentCard> GetCardsStartsWith(string start)
        {
            return _repository.GetAll().Where(c => c.CardNumber.ToLower().StartsWith(start.ToLower()));
        }

        public static StudentCard GetNewStudentCardFromConsole()
        {
            Console.Write("Номер студентського бiлету: ");
            string number = Console.ReadLine();
            while(number == "")
            {
                Console.WriteLine("Номер студентського бiлету не може бути пустим!");
                Console.Write("\nНомер студентського бiлету: ");
                number = Console.ReadLine();
            }

            Console.Write("Дата початку дiї (YYYY-MM-DD): ");
            DateTime startDate;
            while (DateTime.TryParse(Console.ReadLine(), out startDate) == false)
            {
                Console.WriteLine("Неправильнi данi");
                Console.Write("\nДата початку дiї (YYYY-MM-DD): ");
            }

            Console.Write("Статус студентського бiлету (1 - Активний | 0 - Неактивний) : ");
            string status = Console.ReadLine();
            bool isActive = false;
            if(status == "1")
            {
                isActive = true;
            }

            StudentCard newCard = new StudentCard()
            {
                CardNumber = number,
                StartDate = startDate,
                IsActive = isActive
            };

            return newCard;
        }

        public void PrintCards(IEnumerable<StudentCard> cards)
        {
            Console.WriteLine($"{"ID".PadRight(5)}" +
                $"{"Card Number".PadRight(15)}" +
                $"{"Start Date".PadRight(15)}" +
                $"{"Status".PadRight(15)}");

            Console.WriteLine();

            foreach (var card in cards)
            {
                if (card == null)
                {
                    continue;
                }

                Console.WriteLine($"{card.ID.ToString().PadRight(5)}" +
                    $"{card.CardNumber.PadRight(15)}" +
                    $"{card.StartDate.ToShortDateString().PadRight(15)}" +
                    $"{(card.IsActive ? "Active" : "Inactive").PadRight(15)}");
            }
        }
    }
}
