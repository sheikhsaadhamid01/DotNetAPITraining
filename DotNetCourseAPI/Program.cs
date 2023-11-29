using Dapper;
using DotNetCourseAPI.Modules;
using DotNetCourseAPI.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace DotNetCourseAPI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            FileReadWriteDemo();
        }
        public static void FileReadWriteDemo()
        {
            Computer computer = new Computer()
            {
                Motherboard = "Z700",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 989.87m,
                VideoCard = "RTX 2070"
            };


            string sqlSquery =
                                @" Insert into TutorialAppSchema.Computer (Motherboard, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) 
                                Values ('" + computer.Motherboard
                                + "','" + computer.HasWifi
                                + "','" + computer.HasLTE
                                + "','" + computer.ReleaseDate
                                + "','" + computer.Price
                                + "','" + computer.VideoCard
                                + "')";
            string values = @"Values ('" + computer.Motherboard
                + "','" + computer.HasWifi
                + "','" + computer.HasLTE
                + "','" + computer.ReleaseDate
                + "','" + computer.Price
                + "','" + computer.VideoCard
                + "')";

            File.WriteAllText("log.txt", sqlSquery);
            using StreamWriter writer = new StreamWriter("log.txt", append: true);
            writer.WriteLine("");
            writer.WriteLine(sqlSquery);
            writer.Close();

            string fileData = File.ReadAllText("log.txt");
            Console.WriteLine($"File Data: {fileData}");

        }

        public static void DBDemoCode()
        {
            string configFilePath = "";
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


            DapperUtility dapper = new DapperUtility(config);
            // DataContextEF ef = new DataContextEF(config);
            string query = "Select GETDATE() ";
            DateTime currentTime = dapper.GetSingleData<DateTime>(query);
            Console.WriteLine($"Current Time: {currentTime}");

            Computer computer = new Computer()
            {
                Motherboard = "Z700",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 989.87m,
                VideoCard = "RTX 2070"
            };

            // ef.Add(computer);
            //ef.SaveChanges();

            string sqlSquery =
                                @" Insert into TutorialAppSchema.Computer (Motherboard, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) 
                                Values ('" + computer.Motherboard
                                + "','" + computer.HasWifi
                                + "','" + computer.HasLTE
                                + "','" + computer.ReleaseDate
                                + "','" + computer.Price
                                + "','" + computer.VideoCard
                                + "')";
            string values = @"Values ('" + computer.Motherboard
                + "','" + computer.HasWifi
                + "','" + computer.HasLTE
                + "','" + computer.ReleaseDate
                + "','" + computer.Price
                + "','" + computer.VideoCard
                + "')";
            string sqlSquery1 = @"Insert into TutorialAppSchema.Computer (Motherboard, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) " + values;

            Console.WriteLine(sqlSquery);
            bool rowsAffected = dapper.ExecuteQuery(sqlSquery);

            Console.WriteLine($"Rows Effected: {rowsAffected}");


            /*  IEnumerable<Computer> listOfComputers = ef.Computer.ToList<Computer>();            
              if(listOfComputers != null)
              {
                 // Console.WriteLine("Motherboard", "HasWifi", "HasLTE", "ReleaseDate", "Price", "VideoCard");
                  //Console.WriteLine();
                  foreach (Computer singleComputer in listOfComputers)
                  {
                      Console.WriteLine("'" + singleComputer.ComputerId
                  + "','" + singleComputer.Motherboard
                  + "','" + singleComputer.HasWifi
                  + "','" + singleComputer.HasLTE
                  + "','" + singleComputer.ReleaseDate
                  + "','" + singleComputer.Price
                  + "','" + singleComputer.VideoCard
                  + "')");
                  }
              }*/
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
