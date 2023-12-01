using AutoMapper;
using Dapper;
using DotNetCourseAPI.Modules;
using DotNetCourseAPI.ProgrammingConcepts.IndexersDemo;
using DotNetCourseAPI.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Data;
using System.Data.Common;
using System.Text.Json;

namespace DotNetCourseAPI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Employee emp = new(1001, "James", "Engineer", "R&D", "London", 70000);

            Console.WriteLine(emp[0]);
            Console.WriteLine(emp[1]);
            Console.WriteLine(emp[2]);
            Console.WriteLine(emp[3]);
            Console.WriteLine(emp[4]);
            Console.WriteLine(emp[5]);
            Console.WriteLine(emp[6]);


            emp[0] = 102;
            emp[2] = "Senior Engineer";

            Console.WriteLine(emp[0]);
            Console.WriteLine(emp[1]);
            Console.WriteLine(emp[2]);
            Console.WriteLine(emp[3]);
            Console.WriteLine(emp[4]);
            Console.WriteLine(emp[5]);

            Console.WriteLine();
            emp["Ename"] = "Ana";
            Console.WriteLine(emp["Eno"]);
            Console.WriteLine(emp["Ename"]);
            Console.WriteLine(emp["Job"]);
            Console.WriteLine(emp["Dname"]);
            Console.WriteLine(emp["Location"]);
            Console.WriteLine(emp["Salary"]);
        



        }
       
        public static void SerializeAndDeserialiseJson()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            DapperUtility dapper = new DapperUtility(configuration);

            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.GetFullPath(Path.Combine(path, "..\\..\\..\\") + "\\Computers.json");



            string computerJsonData = File.ReadAllText(relativePath);
            //Console.WriteLine(computerJsonData);
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            IEnumerable<Computer>? computerEnum1 = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computerJsonData, jsonSerializerOptions);


            IEnumerable<Computer>? computerEnum = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computerJsonData);
            if (computerEnum != null)
            {
                foreach (Computer computer in computerEnum)
                {
                    string values = @"Values ('" + EscapeSequenceSingleQuote(computer.Motherboard)
                + "','" + computer.HasWifi
                + "','" + computer.HasLTE
                + "','" + computer.ReleaseDate
                + "','" + computer.Price
                + "','" + EscapeSequenceSingleQuote(computer.VideoCard)
                + "')";
                    string sqlSquery1 = @"Insert into TutorialAppSchema.Computer (Motherboard, HasWifi, HasLTE, ReleaseDate, Price, VideoCard) " + values;

                    dapper.RowsUpdatedFromQueryExecution(sqlSquery1);

                }
            }
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string relativePath1 = Path.GetFullPath(Path.Combine(path, "..\\..\\..\\") + "\\NewComputers.json");
            string serializeText = JsonConvert.SerializeObject(computerEnum, serializerSettings);


            string relativePath2 = Path.GetFullPath(Path.Combine(path, "..\\..\\..\\") + "\\SystemSerialize.json");
            string sysSerialize = System.Text.Json.JsonSerializer.Serialize(computerEnum, jsonSerializerOptions);

            File.WriteAllText(relativePath1, serializeText);
            File.WriteAllText(relativePath2, sysSerialize);

        }

        public static void FileReadWriteDemo()
        {
          /*  Computer computer = new Computer()
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
          */

        }

        public static void DBDemoCode()
        {
           /* string configFilePath = "";
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
        private static string EscapeSequenceSingleQuote(string input)
        {
            string text = input.Replace("'", "''");
            return text;
        }
    }
}
