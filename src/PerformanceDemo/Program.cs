using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Api.Common;
using Vision.Cms.MvcComponents.Calendar.Api.Request;
using Vision.Cms.MvcComponents.Calendar.Api.Response;

namespace PerformanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ################################ C# ################################ 
            var stringToSearch = RandomString(100);
            var charEval = 'A';
            var stringEval = "A";
            var iterations = 5000000;

            // Contains using Char
            var watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                if (stringToSearch.Contains(charEval))
                {
                    continue;
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("Contains using Char: {0} ms", watch.ElapsedMilliseconds));
            watch = null;

            // Index Of using Char
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                if (stringToSearch.IndexOf(charEval) > -1)
                {
                    continue;
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("IndexOf using Char: {0} ms", watch.ElapsedMilliseconds));
            watch = null;
            Console.Write(Environment.NewLine);

            // Contains using String
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                if (stringToSearch.Contains(stringEval))
                {
                    continue;
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("Contains using String: {0} ms", watch.ElapsedMilliseconds));
            watch = null;

            // Index Of using String
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                if (stringToSearch.IndexOf(stringEval) > -1)
                {
                    continue;
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("IndexOf using String: {0} ms", watch.ElapsedMilliseconds));
            watch = null;
            Console.Write(Environment.NewLine);

            // ==
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                if (stringToSearch == stringEval)
                {
                    continue;
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("Equals Operator \"==\": {0} ms", watch.ElapsedMilliseconds));
            watch = null;

            // Equals
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                if (stringToSearch.Equals(stringEval))
                {
                    continue;
                }
            }
            watch.Stop();
            Console.WriteLine(string.Format("Equals Function: {0} ms", watch.ElapsedMilliseconds));
            watch = null;
            Console.Write(Environment.NewLine);

            var string1 = RandomString(256);
            var string2 = RandomString(256);
            var string3 = RandomString(256);


            // Using String Builder()
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                var sb = new StringBuilder();
                sb.Append(string1);
                sb.Append(string2);
                sb.Append(string3);
            }
            watch.Stop();
            Console.WriteLine(string.Format("String Builder (.Append(string)): {0} ms", watch.ElapsedMilliseconds));
            watch = null;

            // Concatenating Strings
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                var concat = "";
                concat = concat + string1;
                concat = concat + string2;
                concat = concat + string3;
            }
            watch.Stop();
            Console.WriteLine(string.Format("Concatenating Strings (string + string): {0} ms", watch.ElapsedMilliseconds));
            watch = null;

            // One-line Concatenating Strings
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                var concat = string1 + string2 + string3;
            }
            watch.Stop();
            Console.WriteLine(string.Format("One-line Concatenating Strings (string + string): {0} ms", watch.ElapsedMilliseconds));
            watch = null;
            Console.Write(Environment.NewLine);

//################################ SQL ################################ 
            NorthwindDataContext dataContext = new NorthwindDataContext();
            iterations = 100;

            // SQL Linq Memory Query
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                var categories = dataContext.Categories.ToList();
                var firstCategory = categories.Where(a => a.CategoryName.IndexOf('a') > 0).FirstOrDefault();

            }
            watch.Stop();
            Console.WriteLine(string.Format("SQL Select All of Data Function: {0} ms", watch.ElapsedMilliseconds));
            watch = null;

            // SQL Linq SQL Query 
            watch = Stopwatch.StartNew();
            for (int x = 0; x < iterations; x++)
            {
                var firstCategory = dataContext.Categories.Where(a => a.CategoryName.IndexOf('a') > 0).ToList();

            }
            watch.Stop();
            Console.WriteLine(string.Format("SQL Linq SQL Query: {0} ms", watch.ElapsedMilliseconds));
            watch = null;
            Console.Write(Environment.NewLine);

            //// ################################ Web / API Services ################################ 
            //iterations = 5;

            //// Vision API without Filter
            //watch = Stopwatch.StartNew();
            //for (int x = 0; x < iterations; x++)
            //{
            //    var client = new XmlApiClient("http://dev5.visioninternet.com/CMS6_Dev/API", "d57b530d-dfa5-4746-94f1-3eaafcfe2bf2", "{54DA8EAC-491C-4EB2-BA56-A29A41667FCA}");
            //    var request = new EventFindRequest();
            //    request.PageIndex = 1;
            //    request.PageSize = 100;
            //    request.StartDate = null;
            //    request.EndDate = null;
            //    request.Filter = null;
            //    request.CategoryIDsConstraint = null;
            //    request.DepartmentIDsConstraint = null;
            //    request.IncludeLocation = null;
            //    var response = client.Execute<EventFindRequest, EventFindResponse>(request);
            //    var result = response.PagingList.Content.Where(a => a.Title.Contains("Neighborhood Emergency Response Meeting"));

            //    client = null;
            //    request = null;
            //    response = null;
            //}
            //watch.Stop();
            //Console.WriteLine(string.Format("Vision API without Filter: {0} ms", watch.ElapsedMilliseconds));
            //watch = null;

            //// Vision API with Filter with "Neighborhood Emergency Response Meeting"
            //watch = Stopwatch.StartNew();
            //for (int x = 0; x < iterations; x++)
            //{
            //    var client = new XmlApiClient("http://dev5.visioninternet.com/CMS6_Dev/API", "d57b530d-dfa5-4746-94f1-3eaafcfe2bf2", "{54DA8EAC-491C-4EB2-BA56-A29A41667FCA}");
            //    var request = new EventFindRequest();
            //    request.PageIndex = 1;
            //    request.PageSize = 100;
            //    request.StartDate = DateTime.Parse("10/1/2012");
            //    request.EndDate = DateTime.Parse("10/31/2012");
            //    request.Filter = "Neighborhood Emergency Response Meeting";
            //    request.CategoryIDsConstraint = null;
            //    request.DepartmentIDsConstraint = null;
            //    request.IncludeLocation = null;
            //    var response = client.Execute<EventFindRequest, EventFindResponse>(request);

            //    client = null;
            //    request = null;
            //    response = null;
            //}
            //watch.Stop();
            //Console.WriteLine(string.Format("Vision API with Filter: {0} ms", watch.ElapsedMilliseconds));
            //watch = null;
            //Console.Write(Environment.NewLine);

            //// Vision API find 2 content without Caching
            //watch = Stopwatch.StartNew();
            //for (int x = 0; x < iterations; x++)
            //{
            //    var client = new XmlApiClient("http://dev5.visioninternet.com/CMS6_Dev/API", "d57b530d-dfa5-4746-94f1-3eaafcfe2bf2", "{54DA8EAC-491C-4EB2-BA56-A29A41667FCA}");

            //    var request = new EventFindRequest();
            //    request.PageIndex = 1;
            //    request.PageSize = 100;
            //    request.StartDate = null;
            //    request.EndDate = null;
            //    request.Filter = null;
            //    request.CategoryIDsConstraint = null;
            //    request.DepartmentIDsConstraint = null;
            //    request.IncludeLocation = null;
            //    var responseNoCache = client.Execute<EventFindRequest, EventFindResponse>(request);
            //    var result1 = responseNoCache.PagingList.Content.Where(a => a.Title.Contains("City"));

            //    var request2 = new EventFindRequest();
            //    request2.PageIndex = 1;
            //    request2.PageSize = 100;
            //    request2.StartDate = null;
            //    request2.EndDate = null;
            //    request2.Filter = null;
            //    request2.CategoryIDsConstraint = null;
            //    request2.DepartmentIDsConstraint = null;
            //    request2.IncludeLocation = null;
            //    var responseNoCache2 = client.Execute<EventFindRequest, EventFindResponse>(request2);
            //    var result2 = responseNoCache2.PagingList.Content.Where(a => a.Title.Contains("Meeting"));

            //    client = null;
            //    request = null;
            //    responseNoCache = null;
            //    request2 = null;
            //    responseNoCache2 = null;
            //}
            //watch.Stop();
            //Console.WriteLine(string.Format("Vision API find 2 content without Caching: {0} ms", watch.ElapsedMilliseconds));
            //watch = null;

            //// Vision API find 2 content with Caching
            //watch = Stopwatch.StartNew();
            //for (int x = 0; x < iterations; x++)
            //{
            //    var client = new XmlApiClient("http://dev5.visioninternet.com/CMS6_Dev/API", "d57b530d-dfa5-4746-94f1-3eaafcfe2bf2", "{54DA8EAC-491C-4EB2-BA56-A29A41667FCA}");

            //    var request = new EventFindRequest();
            //    request.PageIndex = 1;
            //    request.PageSize = 100;
            //    request.StartDate = null;
            //    request.EndDate = null;
            //    request.Filter = null;
            //    request.CategoryIDsConstraint = null;
            //    request.DepartmentIDsConstraint = null;
            //    request.IncludeLocation = null;
            //    var responseWithCache = client.Execute<EventFindRequest, EventFindResponse>(request);
            //    var result1 = responseWithCache.PagingList.Content.Where(a => a.Title.Contains("City"));
            //    var result2 = responseWithCache.PagingList.Content.Where(a => a.Title.Contains("Meeting"));

            //    client = null;
            //    request = null;
            //    responseWithCache = null;
            //}
            //watch.Stop();
            //Console.WriteLine(string.Format("Vision API find 2 content with Caching: {0} ms", watch.ElapsedMilliseconds));
            //watch = null;
            //Console.Write(Environment.NewLine);


            Console.ReadKey();
            Console.ReadKey();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
