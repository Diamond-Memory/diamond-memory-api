namespace DIAMOND.MEMORY.Domain.Catalog;
    public class Rating{
        public int Stars { get; set; }
        public string? UserName { get; set; }
        public string? Review { get; set; }
        public List<Rating> Ratings { get; set; } = new List<Rating>();
    public Rating (int stars, string userName, string review){
        if(stars < 1 || stars > 5){
            throw new ArgumentException("Stars must be between 1 and 5.");
        }
        if(string.IsNullOrEmpty(userName)){
            throw new ArgumentException("User name is required.");
        }
        this.Stars = stars;
        this.UserName = userName;
        this.Review = review;
    }
    public void AddRating(Rating rating){
        this.Ratings.Add(rating);
    }
}