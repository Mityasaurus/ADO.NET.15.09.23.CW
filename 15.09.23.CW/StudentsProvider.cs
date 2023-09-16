using _15._09._23.CW.DAL.Entity;
using _15._09._23.CW.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<Student> GetAllStudents()
        { 
            return _studentRepository.GetAll();
        }

        public void Remove(int id)
        {
            var student = GetStudent(id);
            _studentRepository.Remove(student);
        }
    }
}
