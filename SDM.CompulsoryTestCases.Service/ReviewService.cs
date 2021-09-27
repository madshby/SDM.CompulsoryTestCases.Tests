using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SDM.CompulsoryTestCases.Service
{
    public class ReviewService
    {
        private ReviewRepository _repo;
        
        public ReviewService()
        {
            _repo = new ReviewRepository();
        }

        //1. On input N, what are the number of reviews from reviewer N?
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            List<BeReview> allReviews = _repo.GetAllReviews();
            int counter = 0;
            foreach (var review in allReviews)
            {
                if (review.Reviewer == reviewer)
                {
                    counter++;
                }
            }
            return counter;
        }
        
        //2. On input N, what is the average rate that reviewer N had given?
        public double GetAverageRateFromReviewer(int reviewer)
        {
            double averageReviewScore = 0.0;
            int counter = 0;
            List<BeReview> allReviews = _repo.GetAllReviews();
            if (reviewer <= 0)
            {
                throw new InvalidDataException("ID can't be 0 or below");
            }
            foreach (var review in allReviews)
            {
                if (review.Reviewer == reviewer)
                {
                    averageReviewScore += review.Grade;
                    counter++;
                }
            }
            if (counter == 0)
            {
                throw new InvalidDataException("This reviewer has no reviews");
            }
            var result = averageReviewScore / counter;
            return result;
        }
        
        //3. On input N and R, how many times has reviewer N given rate R?
        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            int counter = 0;
            List<BeReview> allReviews = _repo.GetAllReviews();
            if (reviewer <= 0)
            {
                throw new InvalidDataException("ID can't be 0 or below");
            }
            if (rate is < 1 or > 5)
            {
                throw new InvalidDataException("Grade must be between 1-5");
            }
            foreach (var review in allReviews)
            {
                if (review.Reviewer == reviewer && review.Grade == rate)
                {
                    counter++;
                }
            }
            return counter;
        }
        
        //4. On input N, how many have reviewed movie N?
        public int GetNumberOfReviews(int movie)
        {
            int counter = 0;
            List<BeReview> allReviews = _repo.GetAllReviews();
            if (movie <= 0)
            {
                throw new InvalidDataException("Movie ID can't be 0 or below");
            }
            foreach (var review in allReviews)
            {
                if (review.Movie == movie)
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                throw new InvalidDataException("This movie has no reviews");
            }
            return counter;
        }
        
        //5. On input N, what is the average rate the movie N had received?
        public double GetAverageRateOfMovie(int movie)
        {
            double averageReviewScore = 0.0;
            int counter = 0;
            List<BeReview> allReviews = _repo.GetAllReviews();
            if (movie <= 0)
            {
                throw new InvalidDataException("Movie ID can't be 0 or below");
            }
            foreach (var review in allReviews)
            {
                if (review.Movie == movie)
                {
                    averageReviewScore += review.Grade;
                    counter++;
                }
            }
            if (counter == 0)
            {
                throw new InvalidDataException("This movie has no reviews");
            }
            var result = averageReviewScore / counter;
            return result;
        }
        
        //6. On input N and R, how many times had movie N received rate R?
        public int GetNumberOfRates(int movie, int rate)
        {
            int counter = 0;
            List<BeReview> allReviews = _repo.GetAllReviews();
            if (movie <= 0)
            {
                throw new InvalidDataException("Movie ID can't be 0 or below");
            }
            if (rate is < 1 or > 5)
            {
                throw new InvalidDataException("Grade must be between 1-5");
            }
            foreach (var review in allReviews)
            {
                if (review.Movie == movie && review.Grade == rate)
                {
                    counter++;
                }
            }
            return counter;
        }
        
        //7. What is the id(s) of the movie(s) with the highest number of top rates (5)?
        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            List<BeReview> allReviews = _repo.GetAllReviews();
            List<int> listOfTopRatedMovies = new List<int>();
            foreach (var review in allReviews)
            {
                if (review.Grade == 5)
                {
                    listOfTopRatedMovies.Add(review.Movie);
                }
            }

            var most = listOfTopRatedMovies
                .GroupBy(i => i)
                .OrderByDescending(grp => grp
                    .Count())
                .Select(grp => grp.Key)
                .Take(5)
                .ToList();
            return most;
        }
        
        //8. What reviewer(s) had done most reviews?
        public List<int> GetMostProductiveReviewers()
        {
            List<BeReview> allReviews = _repo.GetAllReviews();
            List<int> listOfTopReviewers = new List<int>();
            foreach (var review in allReviews)
            {
                listOfTopReviewers.Add(review.Reviewer);
            }

            var most = listOfTopReviewers
                .GroupBy(i => i)
                .OrderByDescending(grp => grp
                    .Count())
                .Select(grp => grp.Key)
                .Take(5)
                .ToList();
            return most;
        }
        
        //9. On input N, what is top N of movies? The score of a movie is its average rate.
        public List<int> GetTopRatedMovies(int amount)
        {
            return _repo.GetAllReviews()
                .GroupBy(i => i.Movie)
                .OrderByDescending(g => g.Average(i => i.Grade))
                .Select(grp => grp.Key)
                .Take(amount)
                .ToList();
        }
        
        //10. On input N, what are the movies that reviewer N has reviewed? The list should
        //be sorted decreasing by rate first, and date secondly.
        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            List<BeReview> allReviews = _repo.GetAllReviews();
            List<BeReview> newListOfReviews = new List<BeReview>();
            List<int> result = new List<int>();
            if (reviewer <= 0)
            {
                throw new InvalidDataException("ID can't be 0 or below");
            }
            foreach (var review in allReviews)
            {
                if (review.Reviewer == reviewer)
                {
                    newListOfReviews.Add(review);
                }
            }

            if (!newListOfReviews.Any())
            {
                throw new InvalidDataException("This List is empty, the reviewer hasn't reviewed anything.");

            }
            var sortedList = newListOfReviews.OrderByDescending(review => review.Grade).ThenBy(review => review.Date).ToList();
            foreach (var review in sortedList)
            {
                result.Add(review.Movie);
            }
            return result;
        }
        
        //11. On input N, who are the reviewers that have reviewed movie N? The list
        //should be sorted decreasing by rate first, and date secondly.
        public List<int> GetReviewersByMovie(int movie)
        {
            List<BeReview> allReviews = _repo.GetAllReviews();
            List<BeReview> newListOfReviews = new List<BeReview>();
            List<int> result = new List<int>();
            if (movie <= 0)
            {
                throw new InvalidDataException("Movie ID can't be 0 or below");
            }
            foreach (var review in allReviews)
            {
                if (review.Movie == movie)
                {
                    newListOfReviews.Add(review);
                }
            }
            if (!newListOfReviews.Any())
            {
                throw new InvalidDataException("This list is empty, the movie hasn't received any reviews yet.");
            }
            var sortedList = newListOfReviews.OrderByDescending(review => review.Grade).ThenBy(review => review.Date).ToList();
            foreach (var review in sortedList)
            {
                result.Add(review.Reviewer);
            }
            return result;
        }
    }
}