using System.IO;
using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class UnitTest3
    {
        private ReviewService _reviewService;
        
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        
        //Test: GetNumberOfRatesByReviewer Method
        
        [Test]
        public void TestIfReviewerExists()
        {
            var inputReviewer = 0;
            var inputGrade = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetNumberOfRatesByReviewer(inputReviewer,inputGrade));
        }
        
        [Test]
        public void TestGradeIsBelowZero()
        {
            var inputReviewer = 1;
            var inputGrade = 0;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetNumberOfRatesByReviewer(inputReviewer,inputGrade));
        }
        
        [Test]
        public void TestGradeIsAboveFive()
        {
            var inputReviewer = 1;
            var inputGrade = 6;
            Assert.Throws<InvalidDataException>( () => _reviewService.GetNumberOfRatesByReviewer(inputReviewer,inputGrade));
        }
        
        [Test]
        public void TestAmountOfReviews()
        {
            var expectedResult = 1;
            var inputReviewer = 4;
            var inputGrade = 5;
            var result = _reviewService.GetNumberOfRatesByReviewer(inputReviewer,inputGrade);
            Assert.That(result,Is.EqualTo(expectedResult));
        }
        
    }
}