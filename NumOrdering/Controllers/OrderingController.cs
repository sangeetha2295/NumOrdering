using Microsoft.AspNetCore.Mvc;
using NumOrdering.Contract;
using System.Net;

namespace NumOrdering.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderingController : ControllerBase
    {
        IConfiguration _iconfiguration;
        IOrderingEngine _iorderingengine;
        public OrderingController(IConfiguration iconfiguration, IOrderingEngine iorderingengine)
        {
            _iconfiguration = iconfiguration;
            _iorderingengine = iorderingengine;
        }

        [HttpPost]
        [Route("GetSortedNumbersUsingBubbleSort")]
        public IActionResult GetSortedNumbersUsingBubbleSort(IList<int> num)
        {
            int count = num.Count - 1;

            var sortedNum = _iorderingengine.SortBubble(num, count);

            string filePath = _iconfiguration.GetValue<string>("EnvironmentSettings:DownloadPath");
            System.IO.File.WriteAllLines(filePath,
            sortedNum.Select(n => n.ToString()));

            FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes(filePath), "application/txt")
            {
                FileDownloadName = "SortedNumbers.txt"
            };

            return result;

        }

        [HttpPost]
        [Route("GetSortedNumbersUsingInsertionSort")]
        public IActionResult GetSortedNumbersUsingInsertionSort(IList<int> num)
        {
            int count = num.Count;

            var sortedNum = _iorderingengine.SortInsertion(num, count);

            string filePath = _iconfiguration.GetValue<string>("EnvironmentSettings:DownloadPath");
            System.IO.File.WriteAllLines(filePath,
            num.Select(n => n.ToString()));

            FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes(filePath), "application/txt")
            {
                FileDownloadName = "SortedNumbers.txt"
            };

            return result;

        }

        [HttpPost]
        [Route("GetSortedNumbersUsingMergeSort")]
        public IActionResult GetSortedNumbersUsingMergeSort(IList<int> num)
        {
            int count = num.Count;
            
            var sortedNum = _iorderingengine.SortMerge(num);
            
            string filePath = _iconfiguration.GetValue<string>("EnvironmentSettings:DownloadPath");
            System.IO.File.WriteAllLines(filePath,
            sortedNum.Select(n => n.ToString()));

            FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes(filePath), "application/txt")
            {
                FileDownloadName = "SortedNumbers.txt"
            };

            return result;

        }
    }
}
