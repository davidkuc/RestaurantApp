using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Components.Exceptions
{
    public class InvalidInputException : Exception
    {

        public InvalidInputException(string message)
        {
            Console.WriteLine($"Invalid input: {message}");
        }

        
    }
}
