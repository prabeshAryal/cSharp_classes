namespace MVCfromEmpty.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Brand { get; set; }

        public BookModel(int Id, string Title, string Description, string Author, string Brand)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Author = Author;
            this.Brand = Brand;
        }
    }
}

