using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCalc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/calculations")]
    public class CalculationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CalculationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Вычисляет заданное выражение и сохраняет результат в базу данных.
        /// </summary>
        /// <param name="login">Логин для которого ведутся вычисления</param>
        /// <param name="expression">Выражение для обчисление</param>
        /// <returns>Результат вычисления или код 400, если выражение - некоретное.</returns>
        [HttpPost]
        public async Task<IActionResult> Calculate(string login, string expression)
        {
            object result;
            try
            {
                result = new Expression(expression).Evaluate();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }

            var model = new Calculation
            {
                Login = login,
                Expression = expression,
                Result = result.ToString()
            };

            await _dbContext.Calculations.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return Ok(result);
        }
        /// <summary>
        /// Возвращает все сохраненные вычисления
        /// </summary>
        /// <returns>Все сохраненные вычисления <see cref="WebApp.Models.Calculation"/></returns>
        [HttpGet]
        public IActionResult GetCalculations()
        {
            return Ok(_dbContext.Calculations);
        }
    }
}
