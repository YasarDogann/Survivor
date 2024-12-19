namespace Survivor.Dtos
{
    public class CompetitorWithCategoryDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string CategoryName { get; set; }
    }
}
