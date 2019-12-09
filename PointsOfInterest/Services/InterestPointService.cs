using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PointsOfInterest.Interfaces;
using PointsOfInterest.Messages;
using PointsOfInterest.Models;
using PointsOfInterest.Provider;
using PointsOfInterest.Translator;

namespace PointsOfInterest.Services
{
    public class InterestPointService : IInterestPointService
    {
        private readonly string _filePath;
        private readonly List<InterestPoint> _interestPoints;
        private readonly InterestPointTranslator _translator;
        private readonly MySqlConnectionProvider _mySqlConnectionProvider;

        public InterestPointService(string filePath)
        {
            _filePath = filePath;
            _interestPoints = new List<InterestPoint>();
            _translator = new InterestPointTranslator();
            _mySqlConnectionProvider = new MySqlConnectionProvider();
        }

        public async Task AddPointsToDatabase()
        {
            if (_interestPoints?.Count == 0 || _interestPoints is null)
            {
                Console.WriteLine(ErrorMessages.NoInterestPointsFound);
                return;
            }
            string storedProcedure = "sp_AddInterestPoint";
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    command.Connection = _mySqlConnectionProvider.GetConnection();
                    command.CommandText = storedProcedure;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection?.Open();
                    for (int i = 0; i < _interestPoints.Count; i++)
                    {
                        AddParameters(command, _interestPoints[i]);
                        await command.ExecuteNonQueryAsync();
                    }
                    Console.WriteLine($"Added {_interestPoints.Count} points to database");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception Occurred!");
                    Console.WriteLine($"{e.Message} \n {e.StackTrace}");
                    Console.WriteLine(Environment.NewLine);
                }
            }
        }

        private void AddParameters(MySqlCommand command, InterestPoint interestPoint)
        {
            command?.Parameters?.Clear();
            command.Parameters.AddWithValue("@RegionId", interestPoint.RegionID);
            command.Parameters.AddWithValue("@RegionName", interestPoint.RegionName);
            command.Parameters.AddWithValue("@RegionNameLong", interestPoint.RegionNameLong);
            command.Parameters.AddWithValue("@Latitude", interestPoint.Latitude);
            command.Parameters.AddWithValue("@Longitude", interestPoint.Longitude);
            command.Parameters.AddWithValue("@SubClassification", interestPoint.SubClassification);
        }

        public Task<List<InterestPoint>> GetAllPoints()
        {
            throw new NotImplementedException();
        }

        public async Task ParseFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    //Discard the first line (Column headers)
                    string line = await reader.ReadLineAsync();
                    int counter = 0;
                    int successCounter = 0;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        InterestPoint interestPoint = _translator.Translate(line);
                        if (interestPoint is null)
                        {
                            Console.WriteLine(ErrorMessages.UnableToParseLine + line);
                            counter++;
                            continue;
                        }
                        counter++;
                        successCounter++;
                        _interestPoints.Add(interestPoint);
                    }
                    Console.WriteLine($"Total lines parsed: {counter} \nLines parsed successfully: {successCounter}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occurred!");
                Console.WriteLine($"{e.Message} \n {e.StackTrace}");
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
