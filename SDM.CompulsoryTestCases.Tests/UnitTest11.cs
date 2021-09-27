using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest11
    {
        private ReviewService _reviewService;
        
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        
        //Test: GetReviewersByMovie Method

        [Test]
        public void TestReviewerWithIdZero()
        {
            var input = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetReviewersByMovie(input));
        }
        
        [Test]
        public void TestMovieWithZeroReviews()
        {
            var input = 10;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetReviewersByMovie(input));
        }
        
        [Test]
        public void TestAverageReviewerGrade()
        {
            var expectedResult = new List<int> {33, 34, 31, 32};            
            var input = 777777;
            var result = _reviewService.GetReviewersByMovie(input);
            Assert.That(result,Is.EqualTo(expectedResult));
        }
    }
}