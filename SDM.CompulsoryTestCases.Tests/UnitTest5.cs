using System.IO;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest5
    {
        private ReviewService _reviewService;

        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        //Test: GetAverageRateOfMovie Method
        
        [Test]
        public void TestMovieWithIdZero()
        {
            var input = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetAverageRateOfMovie(input));
        }
        [Test]
        public void TestMovieWithNoReviews()
        {
            var input = 5;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetAverageRateOfMovie(input));
        }
        [Test]
        public void TestAverageMovieGrade()
        {
            var expectedResult = 5d;
            var input = 696969;
            var result = _reviewService.GetAverageRateOfMovie(input);
            Assert.That(result,Is.EqualTo(expectedResult));
        }
    }
}