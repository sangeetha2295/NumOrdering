using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NumOrdering.Contract;
using NumOrdering.Controllers;
using NumOrdering.Engine;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NumOrderingUnitTest
{
    public class TestOrderingController
    {
        private OrderingEngine _engine = new OrderingEngine();

        [Fact]
        public void GetTypeResult()
        {
            // Act
            var inputs = GetInputs();
            // Assert
            Assert.IsType<List<int>>(inputs as List<int>);

        }

        [Fact]
        public void CheckBubbleSort()
        {
            // Act
            var input = GetInputs();
            var output = _engine.SortBubble(input, 5);
            input.Sort();

            // Assert
            Assert.True(input.SequenceEqual(output));

        }

        [Fact]
        public void CheckInsertionSort()
        {
            // Act
            var input = GetInputs();
            var output = _engine.SortInsertion(input, 5);
            input.Sort();

            // Assert
            Assert.True(input.SequenceEqual(output));

        }

        [Fact]
        public void CheckMergeSort()
        {
            // Act
            var input = GetInputs();
            var output = _engine.SortMerge(input);
            input.Sort();

            // Assert
            Assert.True(input.SequenceEqual(output));

        }

        public List<int> GetInputs()
        {
            var testInputs = new List<int>();
            testInputs.Add(1000000);
            testInputs.Add(0);
            testInputs.Add(5555);
            testInputs.Add(45);
            testInputs.Add(0);
            testInputs.Add(5);
            return testInputs;
        }
    }
}
