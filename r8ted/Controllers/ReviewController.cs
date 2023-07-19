namespace r8ted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly Auth0Provider _auth;
        private readonly ReviewService _reviewService;


        public ReviewController(ReviewService reviewService, Auth0Provider auth)
        {
            _reviewService = reviewService;
            
            _auth = auth;
        }

    [HttpGet]
    public async Task<ActionResult<List<Review>>> GetReviews()
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        List<Review> review = _reviewService.GetReviews(userInfo?.Id);
        return Ok(review);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetOneReview(int id)
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Review review = _reviewService.GetOneReview(id, userInfo?.Id);
        return Ok(review);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Authorize]
    async public Task<ActionResult<Review>> CreateReview([FromBody] Review reviewData)
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        reviewData.User_id = userInfo.Id;
        Review review = _reviewService.CreateReview(reviewData);
        review.Creator = userInfo;
        return Ok(review);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Review>> UpdateReview(int id, [FromBody] Review reviewData)
    {
        try 
        {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Review review = _reviewService.UpdateReview(id, reviewData, userInfo);
        return Ok(review);
        }
        catch (Exception e)
        {
        return BadRequest(e.Message);
        }
    }



    }
}