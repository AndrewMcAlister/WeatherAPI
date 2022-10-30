using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WeatherAPI.Models
{
    /// <summary>
    /// Although this is class is not really required for this exercise,
    /// I wanted to highlight it because in a real situation it is an efficient way to return data and errors
    /// because it avoids errors bubling up and possibly being re-thrown in the situation where one Api calls another Api (as at my previous company)
    /// Throwing a lot of errors is undesirable as it is resource intensive.
    /// This class can be used to catch a business logic error and return the expected result, but with an error status code
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class APIResponse<T>
    {
        public T? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
