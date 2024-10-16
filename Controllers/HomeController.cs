using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckPrimes(int number)
        {
            var primes = GetPrimesUpTo(number);
            return View("Results", primes);
        }

        /// <summary>
        /// Get all prime numbers up to a given number.
        /// </summary>
        /// <param name="max">The maximum number to check.</param>
        /// <returns>A list of all prime numbers up to the input.</returns>
        /// <remarks>
        /// This method is not efficient, but it is simple and easy to understand.
        /// It checks if each number is prime using the IsPrime method.
        /// If the number is prime, it is added to the list of primes.
        /// Finally, the list of primes is returned.
        /// </remarks>
        private List<int> GetPrimesUpTo(int max)
        {
            var primes = new List<int>();
            for (int num = 2; num <= max; num++)
            {
                if (IsPrime(num))
                {
                    primes.Add(num);
                }
            }
            return primes;
        }

        /// <summary>
        /// Check if a number is prime.
        /// </summary>
        /// <param name="num">The number to check.</param>
        /// <returns>True if the number is prime, false otherwise.</returns>
        /// <remarks>
        /// This method is not efficient, but it is simple and easy to understand.
        /// It checks if the number is divisible by any number from 2 to the square root of the number.
        /// If it is divisible by any of these numbers, then it is not prime.
        /// If it is not divisible by any of these numbers, then it is prime.
        /// </remarks>
        private bool IsPrime(int num)
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}
