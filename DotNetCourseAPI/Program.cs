using Dapper;
using DotNetCourseAPI.Modules;
using DotNetCourseAPI.Utilities;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DotNetCourseAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           DapperUtility dapper = new DapperUtility();
            string query = "Select GETDATE() ";
            DateTime currentTime = dapper.GetSingleData<DateTime>(query);
            Console.WriteLine($"Current Time: {currentTime}");

            Computer computer = new Computer()
            {
                Motherboard = "Z700",
                HasWifi = true,
                HasLTE = false,
                ReleasedDate = DateTime.Now,
                Price = 989.87m,
                VideoCard = "RTX 2070"
            };

            /*string sqlSquery =
                                @" Insert into TutorialAppSchema.Computer (Motherboard, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) 
                                Values ('" + computer.Motherboard
                                + "','" + computer.HasWifi
                                + "','" + computer.HasLTE
                                + "','" + computer.ReleasedDate
                                + "','" + computer.Price
                                + "','" + computer.VideoCard
                                + "')";*/
            string values = @"Values ('" +computer.Motherboard
                + "','" + computer.HasWifi
                + "','" + computer.HasLTE
                + "','" + computer.ReleasedDate
                +"','" + computer.Price
                +"','" + computer.VideoCard
                + "')";
            string sqlSquery = @"Insert into TutorialAppSchema.Computer (Motherboard, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) "+values;

            Console.WriteLine(sqlSquery);
            bool rowsAffected = dapper.ExecuteQuery(sqlSquery);

            Console.WriteLine($"Rows Effected: {rowsAffected}");
                                
                        
                               

            /*
            Console.WriteLine($"MotherBoard : {computer.Motherboard}");
            Console.WriteLine($"HasWifi: {computer.HasWifi}");
            Console.WriteLine($"HasLTE: {computer.HasLTE}");
            Console.WriteLine($"ReleasedDate: {computer.ReleasedDate}");
            Console.WriteLine($"Price: {computer.Price}");
            Console.WriteLine($"VideoCard: {computer.VideoCard}");
            */
        }
    }
}
