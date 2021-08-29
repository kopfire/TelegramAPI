using Microsoft.AspNetCore.Mvc;

namespace testAPI.Controllers.Api
{
    [ApiController]
    [Route("api/math")]
    public class MathController : ControllerBase
    {
        /// <summary>
        /// Сумма чисел
        /// </summary>
        /// <param name="firstValue">Первое число</param>
        /// <param name="secondValue">Второе число</param>
        /// <returns>Сумма</returns>
        [HttpGet("sum")]
        public ActionResult<long> GetSum(int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        /// <summary>
        /// Произведение чисел
        /// </summary>
        /// <param name="firstValue">Первое число</param>
        /// <param name="secondValue">Второе число</param>
        /// <returns>Произведение</returns>
        [HttpGet("multiplication")]
        public ActionResult<long> GetMultiplication(int firstValue, int secondValue)
        {
            return firstValue * secondValue;
        }

        /// <summary>
        /// Сложение слов
        /// </summary>
        /// <param name="firstWord">Первое слово</param>
        /// <param name="secondWord">Второе слово</param>
        /// <param name="upper">Флаг верхнего регистра</param>
        /// <returns>Фраза</returns>
        [HttpGet("getPhrase")]
        public ActionResult<string> GetPhrase(string firstWord, string secondWord, bool? upper)
        {
            var result = $"{firstWord} {secondWord}";

            if (upper.HasValue && upper.Value)
                return result.ToUpper();

            return result;
        }
    }
}
