using PointsOfInterest.Interfaces;
using PointsOfInterest.Services;
using System;

namespace PointsOfInterest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter file path: ");
            string path = Console.ReadLine();
            IInterestPointService service = new InterestPointService(path);
            service.ParseFile().ConfigureAwait(true).GetAwaiter().GetResult();
            service.AddPointsToDatabase().ConfigureAwait(true).GetAwaiter().GetResult();
        }
    }
}
