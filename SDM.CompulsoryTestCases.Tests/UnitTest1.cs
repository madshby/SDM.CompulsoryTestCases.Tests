using NUnit.Framework;
using SDM.CompulsoryTestCases.Service;

namespace SDM.CompulsoryTestCases.Tests
{
    public class Tests
    {
        private ReviewService _reviewService;
        [SetUp]
        public void Setup()
        {
            _reviewService = new ReviewService();
        }
        //Test: GetNumberOfReviewsFromReviewer Method
        [Test]
        public void TestReviewerWithNoReviews()
        {
            var expectedResult = 0;
            var input = 0;
            var result = _reviewService.GetNumberOfReviewsFromReviewer(input);
            Assert.That(result,Is.EqualTo(expectedResult));
        }
        [Test]
        public void TestReviewerThree()
        {
            var expectedResult = 24;
            var input = 3;
            var result = _reviewService.GetNumberOfReviewsFromReviewer(input);
            Assert.That(result,Is.EqualTo(expectedResult));
        }

    }
}