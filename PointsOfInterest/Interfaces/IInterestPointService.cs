using PointsOfInterest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PointsOfInterest.Interfaces
{
    public interface IInterestPointService
    {
        Task ParseFile();
        Task AddPointsToDatabase();
        Task<List<InterestPoint>> GetAllPoints();
    }
}
