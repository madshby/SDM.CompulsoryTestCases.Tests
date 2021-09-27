using System.Collections.Generic;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest7
    {
        private ReviewService _reviewService;
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        
        //Test: GetMoviesWithHighestNumberOfTopRates Method

        [Test]
        public void TestList()
        {
            var expectedResult = new List<int> {999999,999998,999997,999996,999995};
            var result = _reviewService.GetMoviesWithHighestNumberOfTopRates();
            Assert.That(result,Is.EqualTo(expectedResult));

        }
    }
}