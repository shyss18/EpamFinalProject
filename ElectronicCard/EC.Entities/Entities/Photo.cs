namespace EC.Entities.Entities
{
    public class Photo
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
