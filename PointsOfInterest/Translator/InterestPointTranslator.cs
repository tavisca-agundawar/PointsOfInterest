using System;
using System.Collections.Generic;
using System.Text;
using PointsOfInterest.Messages;
using PointsOfInterest.Models;

namespace PointsOfInterest.Translator
{
    public class InterestPointTranslator
    {
        internal InterestPoint Translate(string line)
        {
            try
            {
                var fields = line?.Split('|');
                if (fields is null)
                {
                    Console.WriteLine(ErrorMessages.NoFieldsFound);
                    return null;
                }
                InterestPoint interestPoint = new InterestPoint();
                int i = 0;
                interestPoint.RegionID = fields[i++];
                interestPoint.RegionName = fields[i++];
                interestPoint.RegionNameLong = fields[i++];
                interestPoint.Latitude = fields[i++];
                interestPoint.Longitude = fields[i++];
                interestPoint.SubClassification = fields[i++];
                return interestPoint;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occurred!");
                Console.WriteLine($"{e.Message} \n {e.StackTrace}");
                Console.WriteLine(Environment.NewLine);
                return null;
            }
        }
    }
}
