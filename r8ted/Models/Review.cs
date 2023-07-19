namespace r8ted.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string User_id {get; set;}
        public int Movie_id { get; set; }
        public string Description { get; set;}
        public string Title { get; set;}
        public int Likes {get; set;}
        public bool IsPrivate { get; set;}
        public bool JoshRated { get; set;}

        public Profile Creator { get; set;}
    }
}