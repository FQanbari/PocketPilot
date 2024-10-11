//using ExpenseTracking.Application.DTO;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ExpenseTracking.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ExpenseController : ControllerBase
//    {
//        private static List<ExpenseDto> _budgets = new();
//        public ExpenseController() { }

//        [HttpGet]
//        public IActionResult Index()
//        {

//            return Ok(_budgets);
//        }
//        [HttpPost]
//        public IActionResult Create(ExpenseDto budget)
//        {
//            if (budget == null)
//            {
//                return BadRequest();
//            }
//            _budgets.Add(budget);
//            return Ok(_budgets);
//        }
//    }
//}
