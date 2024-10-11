namespace ExpenseTracking.API.Helper;

public static class CurrencyManager
{
    private static Dictionary<string, decimal> _exchangeRates = new()
    {
        { "USD", 1m },     // Base currency
        { "EUR", 0.85m },
        { "GBP", 0.75m },
        { "JPY", 110m }
    };
    public static decimal ConvertCurrency(this decimal amount, string fromCurrency, string toCurrency)
    {
        if (!_exchangeRates.ContainsKey(fromCurrency) || !_exchangeRates.ContainsKey(toCurrency))
        {
            throw new Exception("Invalid currency.");
        }

        // Convert to base currency (USD), then to target currency
        decimal amountInBaseCurrency = amount / _exchangeRates[fromCurrency];
        return amountInBaseCurrency * _exchangeRates[toCurrency];
        //// Call an API to get the exchange rate
        //decimal exchangeRate = GetExchangeRate(fromCurrency, toCurrency);

        //// Convert the amount
        //return amount * exchangeRate;
    }

    private static decimal GetExchangeRate(this string fromCurrency, string toCurrency)
    {
        // Use an external API like OpenExchangeRates or Fixer to fetch the rate
        // For demonstration, returning a mock exchange rate
        return 1.12m; // Mock exchange rate for USD to EUR
    }

}
