using _15._09._23.CW.DAL.Entity;
using _15._09._23.CW.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
