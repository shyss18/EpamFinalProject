namespace EC.Entities.Entities
{
    public class Photo
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string ImageType { get; set; }

        public int UserId { get; set; }
    }
}
