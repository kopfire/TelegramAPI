using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TelegramAPI.Models;
using TelegramAPI.Repository;

namespace testAPI.Controllers.Api
{
    /// <summary>
    /// Контроллер для принятия сообщений из бота
    /// </summary>
    [ApiController]
    [Route("api/telegram")]
    public class MessageController : ControllerBase
    {

        private readonly ICitiesRepository _citiesService;
        private readonly ICountriesRepository _countriesService;
        private readonly IFacultiesRepository _facultiesService;
        private readonly ISpecialtiesRepository _specialtiesService;
        private readonly ITimeTableRepository _timeTableService;
        private readonly IUniversitiesRepository _universitiesService;
        private readonly IUsersRepository _usersService;

        public MessageController(ICitiesRepository citiesRepository, 
            ICountriesRepository countriesRepository, 
            IFacultiesRepository facultiesRepository, 
            ISpecialtiesRepository specialtiesRepository, 
            ITimeTableRepository timeTableService, 
            IUniversitiesRepository universitiesRepository, 
            IUsersRepository usersService)
        {
            _citiesService = citiesRepository;
            _countriesService = countriesRepository;
            _facultiesService = facultiesRepository;
            _specialtiesService = specialtiesRepository;
            _timeTableService = timeTableService;
            _universitiesService = universitiesRepository;
            _usersService = usersService;
        }

        /// <summary>
        /// Получение расписания
        /// </summary>
        /// <param name="UserID">Идентификатор пользователя</param>
        /// <returns>Расписание</returns>
        [HttpGet("message")]
        public async Task<IActionResult> AdoptionMessageAsync(long UserID)
        {
            var timeTables = await _timeTableService.GetTimeTable(_usersService.GetTimeTable(UserID).Result);
            return Ok(timeTables);
        }

        /// <summary>
        /// Получение стран
        /// </summary>
        /// <returns>Список стран</returns>
        [HttpGet("countries")]
        public async Task<IActionResult> AdoptionCountriesAsync()
        {
            var countries = await _countriesService.GetCounties();
            return Ok(countries);
        }

        /// <summary>
        /// Получение городов
        /// </summary>
        /// <param name="CountriesID">Идентификатор страны</param>
        /// <returns>Список городов</returns>
        [HttpGet("cities")]
        public async Task<IActionResult> AdoptionCitiesAsync(string CountriesID)
        {
            var cities = await _citiesService.GetCities(CountriesID);
            return Ok(cities);
        }

        /// <summary>
        /// Получение университетов
        /// </summary>
        /// <param name="CitiesID">Идентификатор города</param>
        /// <returns>Список университетов</returns>
        [HttpGet("universities")]
        public async Task<IActionResult> AdoptionUniversitiesAsync(string CitiesID)
        {
            var universities = await _universitiesService.GetUniversities(CitiesID);
            return Ok(universities);
        }

        /// <summary>
        /// Получение факультетов
        /// </summary>
        /// <param name="UniversitiesID">Идентификатор университета</param>
        /// <returns>Список факультетов</returns>
        [HttpGet("faculties")]
        public async Task<IActionResult> AdoptionFacultiesAsync(string UniversitiesID)
        {
            var faculties = await _facultiesService.GetFaculties(UniversitiesID);
            return Ok(faculties);
        }

        /// <summary>
        /// Получение специальностей
        /// </summary>
        /// <param name="FacultiesID">Идентификатор факультета</param>
        /// <returns>Список специальностей</returns>
        [HttpGet("specialties")]
        public async Task<IActionResult> AdoptionSpecialtiesAsync(string FacultiesID)
        {
            var specialties = await _specialtiesService.GetSpecialties(FacultiesID);
            return Ok(specialties);
        }

        /// <summary>
        /// Получение групп
        /// </summary>
        /// <param name="SpecialtiesID">Идентификатор специальности</param>
        /// <returns>Список групп</returns>
        [HttpGet("timeTables")]
        public async Task<IActionResult> AdoptionTimeTablesAsync(string SpecialtiesID)
        {
            var timeTables = await _timeTableService.GetTimeTables(SpecialtiesID);
            return Ok(timeTables);
        }
    }
}
