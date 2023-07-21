namespace r8ted.Services
{
    public class ReviewService
    {

        private readonly ReviewsRepository _repo;
        public ReviewService(ReviewsRepository repo)
        {
            _repo = repo;
        }
        internal List<Review> GetReviews(string id)
        {
            List<Review> review = _repo.GetReviews();
            review = review.FindAll(r => r.User_id == id);
            return review;
        }
        internal Review GetOneReview(int id, string userId)
        {
            Review review = _repo.GetOneReview(id);
            if(review == null) throw new Exception($"No Review with that id: {id} ");
            return review;
        }

        internal Review CreateReview(Review reviewData)
        {
            Review review = _repo.CreateReview(reviewData);
            return review;
        }

        internal Review UpdateReview(int id, Review reviewData, Account userInfo)
        {
            Review original = this.GetOneReview(id, userInfo.Id);
            if(original.User_id != userInfo.Id) throw new Exception("You Cant Edit that");
            original.Title = reviewData.Title != null ? reviewData.Title : original.Title;
            original.Description = reviewData.Description != null ? reviewData.Description : original.Description;
            original.catOne = reviewData.catOne != 0 ? reviewData.catOne : original.catOne;
            original.catTwo = reviewData.catTwo != 0 ? reviewData.catTwo : original.catTwo;
            // FIXME ADD MORE CATS BASED ON DATA AND Qs
            original.IsPrivate = reviewData.IsPrivate ? true : original.IsPrivate;

            int rowsAffected = _repo.UpdateReview(original);
            if(rowsAffected == 0) throw new Exception("Could Not Update that Review, try Again.");
            if(rowsAffected > 1) throw new Exception($"This broke! Check the database because there were {rowsAffected} rows affected.");
            return original;
        }

        internal string DeleteReview(int id, Account userInfo)
        {
            Review review = this.GetOneReview(id, userInfo.Id);
            bool result = _repo.DeleteReview(id);
            if(review.User_id != userInfo.Id) throw new Exception("You cant do that bud");
            return $"Deleted {review.Title}";
        }

    }
}