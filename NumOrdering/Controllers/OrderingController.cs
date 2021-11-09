using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NumOrdering.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderingController : ControllerBase
    {
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
            System.IO.File.WriteAllLines("C:\\Users\\dell\\source\\repos\\NumOrdering\\NumOrdering\\Downloads\\file.txt",
            num.Select(n => n.ToString()));

            FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes("C:\\Users\\dell\\source\\repos\\NumOrdering\\NumOrdering\\Downloads\\file.txt"), "application/txt")
            {
                FileDownloadName = "SortedNumbers.txt"
            };

            return result;

        }
    }
}
