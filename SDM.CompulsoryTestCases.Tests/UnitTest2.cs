using System.IO;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest2
    {
        private ReviewService _reviewService;
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        
        //Test: GetAverageRateFromReviewer Method
        
        [Test]
        public void TestReviewerWithIdZero()
        {
            var input = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetAverageRateFromReviewer(input));
        }
        [Test]
        public void TestReviewerWithNoReviews()
        {
            var input = 5;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetAverageRateFromReviewer(input));
        }
        [Test]
        public void TestAverageReviewerGrade()
        {
            var expectedResult = 3.6666666666666665d;
            var input = 3;
            var result = _reviewService.GetAverageRateFromReviewer(input);
            Assert.That(result,Is.EqualTo(expectedResult));
        }
    }
}