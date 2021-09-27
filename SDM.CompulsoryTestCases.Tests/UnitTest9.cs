using System.Collections.Generic;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest9
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
            //TODO: Do this
        }
    }
}