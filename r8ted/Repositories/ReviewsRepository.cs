namespace r8ted.Repositories
{
    public class ReviewsRepository
    {
        private readonly IDbConnection _db;
        public ReviewsRepository(IDbConnection db)
        {
        _db = db;
        }

        internal List<Review> GetReviews()
        {
            string sql = @"
            SELECT 
            rev.*,
            act.*
            FROM review rev
            JOIN accounts act ON rev.user_id = act.id;
            ";
            List<Review> review = _db.Query<Review, Profile, Review>(sql, (review, prof)=>
            {
                review.Creator = prof;
                return review;
            }).ToList();
            return review;
        }
        internal List<Review> GetReviewsByMovie(int id)
        {
            string sql = @"
            SELECT 
            rev.*,
            act.*
            FROM review rev
            JOIN accounts act ON rev.user_id = act.id
            WHERE rev.movie_id = @id;
            ";
            List<Review> review = _db.Query<Review, Profile, Review>(sql, (review, prof)=>
            {
                review.Creator = prof;
                return review;
            }, new {id}).ToList();
            return review;
        }

        internal Review GetOneReview(int id)
        {
            string sql = @"
            SELECT
            rev.*,
            act.*
            FROM review rev
            JOIN accounts act ON rev.user_id = act.id
            WHERE rev.id = @id;
            ";
            Review review = _db.Query<Review, Profile, Review>(sql, (review, prof)=>
            {
                review.Creator = prof;
                return review;
            }, new { id }).FirstOrDefault();
            return review;
        }

        internal Review CreateReview(Review reviewData)
        {
            string sql = @"
            INSERT INTO review
            (title, movie_id, description, isPrivate, user_id, catOne, catTwo)
            VALUES
            (@title, @movie_id, @description, @isPrivate, @user_id, @catOne, @catTwo)
            RETURNING id;
            ";
            int id = _db.ExecuteScalar<int>(sql, reviewData);
            reviewData.Id = id;
            return reviewData;
        }

        internal int UpdateReview(Review original)
        {
            string sql = @"
            UPDATE review
            SET
            title = @title,
            description = @description,
            isPrivate = @IsPrivate
            WHERE id = @id;
            ";
            int rows = _db.Execute(sql, original);
            return rows;
        }

        internal bool DeleteReview(int id)
        {
            string sql = @"
            DELETE FROM review WHERE id = @id;
            ";
            int rows = _db.Execute(sql, new{id});
            return rows == 1;
        }
    }
}