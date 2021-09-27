using System.IO;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest6
    {
        private ReviewService _reviewService;
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        
        //Test: GetNumberOfRates Method
        
        [Test]
        public void TestIfMovieExists()
        {
            var inputMovie = 0;
            var inputGrade = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetNumberOfRates(inputMovie,inputGrade));
        }
        
        [Test]
        public void TestGradeIsBelowZero()
        {
            var inputMovie = 696969;
            var inputGrade = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetNumberOfRates(inputMovie,inputGrade));
        }
        
        [Test]
        public void TestGradeIsAboveFive()
        {
            var inputMovie = 696969;
            var inputGrade = 6;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetNumberOfRates(inputMovie,inputGrade));
        }
        
        [Test]
        public void TestAmountOfReviews()
        {
            var expectedResult = 1;
            var inputMovie = 696969;
            var inputGrade = 5;
            var result = _reviewService.GetNumberOfRates(inputMovie,inputGrade);
            Assert.That(result,Is.EqualTo(expectedResult));
        }
    }
}