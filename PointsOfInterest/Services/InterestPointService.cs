using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PointsOfInterest.Interfaces;
using PointsOfInterest.Models;

namespace PointsOfInterest.Services
{
    public class InterestPointService : IInterestPointService
    {
        private readonly string _filePath;
        private readonly List<InterestPoint> _interestPoints;

        public InterestPointService(string filePath)
        {
            _filePath = filePath;
        }

        public Task AddPointsToDatabase(List<InterestPoint> interestPoints)
        {
            throw new NotImplementedException();
        }

        public Task<List<InterestPoint>> GetAllPoints()
        {
            throw new NotImplementedException();
        }

        public Task<List<InterestPoint>> ParseFile(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
