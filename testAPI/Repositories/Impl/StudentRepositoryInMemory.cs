using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testAPI.Exceptions;
using testAPI.Models;

namespace testAPI.Repositories.Impl
{
    /// <summary>
    /// Репозиторий студентов в памяти
    /// </summary>
    public class StudentRepositoryInMemory : IStudentRepository
    {
        private List<Student> _students;

        /// <summary>
        /// Создание класса <see cref="StudentRepositoryInMemory"/>
        /// </summary>
        public StudentRepositoryInMemory()
        {
            _students = new List<Student>
            {
                new Student { Faculty = "Информационных технологий", Name = "Иван", Surname = "Иванов"},
                new Student { Faculty = "Информационных технологий", Name = "Марина", Surname = "Сидорова"},
                new Student { Faculty = "Информационных технологий", Name = "Петр", Surname = "Петров"},
                new Student { Faculty = "Психологии", Name = "Александра", Surname = "Сидорова"},
                new Student { Faculty = "Психологии", Name = "Иван", Surname = "Дмитров"},
                new Student { Faculty = "Психологии", Name = "Маша", Surname = "Чуйкова"},
                new Student { Faculty = "Психологии", Name = "Рубин", Surname = "Шалов"},
                new Student { Faculty = "Физики", Name = "Валерия", Surname = "Ханова"},
                new Student { Faculty = "Физики", Name = "Эмиль", Surname = "Кубинов"},
            };
        }

        ///<inheritdoc/>
        public string AddStudent(Student student)
        {
            _students.Add(student);

            return student.Id;
        }

        ///<inheritdoc/>
        public void DeleteStudent(string id)
        {
            var student = _students.FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException(id, typeof(Student));

            _students.Remove(student);
        }

        ///<inheritdoc/>
        public Student GetStudentById(string id)
        {
            return _students.FirstOrDefault(x => x.Id == id) ?? throw new NotFoundException(id, typeof(Student));
        }

        ///<inheritdoc/>
        public IEnumerable<Student> GetStudents() => _students;

        ///<inheritdoc/>
        public void UpdateStudent(string id, Student student)
        {
            var stud = _students.FirstOrDefault(x => x.Id == id)
                ?? throw new NotFoundException(id, typeof(Student));

            stud.Faculty = student.Faculty;
            stud.Name = student.Name;
            stud.Surname = student.Surname;
        }

    }
}
