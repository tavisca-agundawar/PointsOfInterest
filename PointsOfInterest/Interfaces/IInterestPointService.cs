using PointsOfInterest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PointsOfInterest.Interfaces
{
    public interface IInterestPointService
    {
        Task<List<InterestPoint>> ParseFile(string filePath);
        Task AddPointsToDatabase(List<InterestPoint> interestPoints);

        Task<List<InterestPoint>> GetAllPoints();
    }
}
