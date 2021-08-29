using System;

namespace testAPI.Models
{
    /// <summary>
    /// Студент
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Констурктор класса <see cref="Student"/>
        /// </summary>
        public Student()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Идентфиикатор студента
        /// </summary>
        public string Id { get;}

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Факультет
        /// </summary>
        public string Faculty { get; set; }
    }
}
