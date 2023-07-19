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
    }
}