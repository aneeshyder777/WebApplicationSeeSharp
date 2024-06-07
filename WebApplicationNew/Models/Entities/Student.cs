namespace WebApplicationNew.Models.Entities
{
    public class Student
    {
        public Guid id { get; set; }
        public required string Name { get; set; }

        public required string Email { get; set; }

        public int Phone { get; set; }

        public bool Subscribed { get; set; }
    }

}
