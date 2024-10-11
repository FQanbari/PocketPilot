using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExpenseTracking.API.Helper;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ExpenseController : ControllerBase
{
    private static List<ExpenseDto> _expenses = new();
    private const string BaseCurrency = "USD"; // You can change the base currency here
    //private const string ApiKey = "YOUR_API_KEY"; // Replace with your currency conversion API key
    //private const string ApiUrl = "https://openexchangerates.org/api/latest.json";

    public ExpenseController() { }

    // Get all expenses with optional currency conversion
    [HttpGet]
    public async Task<IActionResult> GetAllExpenses([FromQuery] string currency = null)
    {
        if (string.IsNullOrEmpty(currency))
        {
            return Ok(_expenses); // Return in original currency
        }

        // Convert all expenses to the requested currency
        var convertedExpenses = new List<ExpenseDto>();
        

        foreach (var expense in _expenses)
        {
            var convertedExpense = new ExpenseDto
            {
                Id = expense.Id,
                PaymentWay = expense.PaymentWay,
                CategoryId = expense.CategoryId,
                CategoryTitle = expense.CategoryTitle,
                Description = expense.Description,
                Amount = expense.Amount.ConvertCurrency(expense.Currency.ToUpper(),currency.ToUpper()),
                Currency = currency
            };
            convertedExpenses.Add(convertedExpense);
        }

        return Ok(convertedExpenses);
    }

    // Add a new expense
    [HttpPost]
    public IActionResult CreateExpense(ExpenseDto expense)
    {
        if (expense == null)
        {
            return BadRequest();
        }

        expense.Id = _expenses.Count + 1;
        _expenses.Add(expense);
        return Ok(expense);
    }

    // Update an existing expense
    [HttpPut("{id}")]
    public IActionResult UpdateExpense(int id, ExpenseDto updatedExpense)
    {
        var existingExpense = _expenses.FirstOrDefault(e => e.Id == id);
        if (existingExpense == null)
        {
            return NotFound();
        }

        existingExpense.PaymentWay = updatedExpense.PaymentWay;
        existingExpense.CategoryId = updatedExpense.CategoryId;
        existingExpense.CategoryTitle = updatedExpense.CategoryTitle;
        existingExpense.Description = updatedExpense.Description;
        existingExpense.Amount = updatedExpense.Amount;
        existingExpense.Currency = updatedExpense.Currency;

        return Ok(existingExpense);
    }

    // Delete an expense
    [HttpDelete("{id}")]
    public IActionResult DeleteExpense(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense == null)
        {
            return NotFound();
        }

        _expenses.Remove(expense);
        return Ok();
    }

    // Method to convert the currency
    //private decimal ConvertCurrency(decimal amount, decimal exchangeRate)
    //{
    //    return amount * exchangeRate;
    //}

    // Method to fetch exchange rates from an API
    //private async Task<decimal> GetExchangeRateAsync(string fromCurrency, string toCurrency)
    //{
    //    using (var client = new HttpClient())
    //    {
    //        var response = await client.GetStringAsync($"{ApiUrl}?app_id={ApiKey}&symbols={toCurrency}");
    //        var json = XObject.Parse(response);
    //        decimal exchangeRate = (decimal)json["rates"][toCurrency];
    //        return exchangeRate;
    //    }
    //}
}

// Expense DTO
// DTOs/ExpenseDto.cs
public class ExpenseDto
{
    public int? Id { get; set; }
    public PaymentWay PaymentWay { get; set; }
    public int CategoryId { get; set; }
    public string CategoryTitle { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime? Date { get; set; }
}

// Models/PaymentWay.cs
public enum PaymentWay
{
    Cash,
    CreditCard,
    BankTransfer,
    PayPal
}
