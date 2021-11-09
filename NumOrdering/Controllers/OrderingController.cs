using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NumOrdering.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderingController : ControllerBase
    {
        IConfiguration _iconfiguration;
        public OrderingController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        [HttpPost(Name = "GetSortedNumbers")]
        public IActionResult Get(IList<int> num)
        {
            int count = num.Count - 1;
            for (int i = 0; i < count; i++)
            {
                for (int j = count; j > i; j--)
                {
                    if (((IComparable)num[j - 1]).CompareTo(num[j]) > 0)
                    {
                        int temp = num[j - 1];
                        num[j - 1] = num[j];
                        num[j] = temp;
                    }
                }
            }

            string filePath = _iconfiguration.GetValue<string>("EnvironmentSettings:DownloadPath");
            System.IO.File.WriteAllLines(filePath,
            num.Select(n => n.ToString()));

            FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes(filePath), "application/txt")
            {
                FileDownloadName = "SortedNumbers.txt"
            };

            return result;

        }
    }
}
