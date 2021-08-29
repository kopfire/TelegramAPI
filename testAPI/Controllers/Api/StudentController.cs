using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using testAPI.Attributes;
using testAPI.DTO;
using testAPI.Exceptions;
using testAPI.Models;
using testAPI.Repositories;

namespace testAPI.Controllers.Api
{
    /// <summary>
    /// Контроллер для работы со списком студентов
    /// </summary>
    [TypeFilter(typeof(BasicAuthFilter))]
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// Констурктор класса <see cref="StudentController"/>
        /// </summary>
        /// <param name="studentRepository">Репозиторий студентов</param>
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        /// <summary>
        /// Список студентов
        /// </summary>
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }

        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="data">Данные</param>
        [HttpPost]
        public ActionResult AddStudent(StudentDTO data)
        {
            var student = StudentDTO2Student(data);

            //Возвращаем id студента
            var id = _studentRepository.AddStudent(student);

            return Ok(id);
        }

        /// <summary>
        /// Изменение данных студента
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        /// <param name="data">Данные студента</param>
        /// <returns></returns>
        [HttpPatch("{id}/update")]
        public IActionResult UpdateStudent(string id, [FromBody]StudentDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var student = StudentDTO2Student(data);

            try
            {
                _studentRepository.UpdateStudent(id, student);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }

            return Ok();
        }

        /// <summary>
        /// Удаление студента из списка
        /// </summary>
        /// <param name="id">Идентификатор студента</param>
        [HttpDelete("{id}/delete")]
        public IActionResult DeleteStudent(string id)
        {
            try
            {
                _studentRepository.DeleteStudent(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }

            return Ok();
        }


        private Student StudentDTO2Student(StudentDTO data)
        {
            return new Student
            {
                Faculty = data.Faculty,
                Name = data.Name,
                Surname = data.Surname
            };
        }
    }
}
