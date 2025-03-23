namespace SB.GovEntitiesAPI.Domain.Entities
{
    public class GovernmentEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Acronym { get; set; }
        public required string Description { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}