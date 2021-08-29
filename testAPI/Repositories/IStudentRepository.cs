using System.Collections.Generic;
using testAPI.Models;

namespace testAPI.Repositories
{
    /// <summary>
    /// Репозиторий для списка студентов
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Получить список студентов
        /// </summary>
        public IEnumerable<Student> GetStudents();

        /// <summary>
        /// Добавить студента
        /// </summary>
        /// <param name="student">Данные студента</param>
        /// <returns>Идентификатор студента</returns>
        public string AddStudent(Student student);

        /// <summary>
        /// Обновить данные
        /// </summary>
        /// <param name="id">Идентфикатор студента</param>
        /// <param name="student">Данные студента</param>
        public void UpdateStudent(string id, Student student);

        /// <summary>
        /// Данные студента по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        public Student GetStudentById(string id);

        /// <summary>
        /// Удалить студента
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        public void DeleteStudent(string id);
    }
}
