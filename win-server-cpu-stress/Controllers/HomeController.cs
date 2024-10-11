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

        /**
            * Get all prime numbers up to a given number
            * @param max The maximum number to check
            * @return A list of all prime numbers up to the input
            *
            * This method is not efficient, but it is simple and easy to understand.
            * It checks if each number is prime using the IsPrime method.
            * If the number is prime, it is added to the list of primes.
            * Finally, the list of primes is returned.
        */
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

        /**
            * Check if a number is prime
            * @param num The number to check
            * @return True if the number is prime, false otherwise
            * 
            * This method is not efficient, but it is simple and easy to understand.
            * It checks if the number is divisible by any number from 2 to the square root of the number.
            * If it is divisible by any of these numbers, then it is not prime.
            * If it is not divisible by any of these numbers, then it is prime, finally.
        */
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
