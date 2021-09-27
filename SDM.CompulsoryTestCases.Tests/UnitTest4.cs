using System.IO;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest4
    {
        private ReviewService _reviewService;
        
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        //Test: GetNumberOfReviews Method
        [Test]
        public void TestMovieWithIdZeroOrBelow()
        {
            var input = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetNumberOfReviews(input));
        }
        [Test]
        public void TestAverageReviewerGrade()
        {
            var input = 696969;
            var expectedResult = 1;
            var result = _reviewService.GetNumberOfReviews(input);
            Assert.That(result,Is.EqualTo(expectedResult));
        }
        
        
    }
}