using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SDM.CompulsoryTestCases.Service
{
    public class ReviewRepository
    {
        private List<BeReview> _reviewList;

        public ReviewRepository()
        {
            var json = File.ReadAllText("../../../New_Ratings.json");
            _reviewList = JsonConvert.DeserializeObject<List<BeReview>>(json);
        }

        public List<BeReview> GetAllReviews()
        {
            return _reviewList;
        }
    }
}