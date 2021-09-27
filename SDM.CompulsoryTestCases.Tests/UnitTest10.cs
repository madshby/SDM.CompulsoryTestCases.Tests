using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest10
    {
        private ReviewService _reviewService;
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        
        //Test: GetTopMoviesByReviewer Method

        [Test]
        public void TestReviewerWithIdZero()
        {
            var input = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetTopMoviesByReviewer(input));
        }
        
        [Test]
        public void TestReviewerWithZeroReviews()
        {
            var input = 10;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetTopMoviesByReviewer(input));
        }
        
        [Test]
        public void TestAverageReviewerGrade()
        {
            var expectedResult = new List<int> {888882,888881,888883,888884,888885};            
            var input = 21;
            var result = _reviewService.GetTopMoviesByReviewer(input);
            Assert.That(result,Is.EqualTo(expectedResult));
        }
    }
}