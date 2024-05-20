namespace AtvOne.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Login { get; set; }
        public byte[]? Foto { get; set; }

    }
}
