using System.Collections.Generic;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest8
    {
        private ReviewService _reviewService;
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        
        //Test: GetMostProductiveReviewers Method

        [Test]
        public void TestList()
        {
            var expectedResult = new List<int> {1,2,3,11,12};
            var result = _reviewService.GetMostProductiveReviewers();
            Assert.That(result,Is.EqualTo(expectedResult));

        }
    }
}