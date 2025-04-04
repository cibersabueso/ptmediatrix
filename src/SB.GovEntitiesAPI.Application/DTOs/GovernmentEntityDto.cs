namespace SB.GovEntitiesAPI.Application.DTOs
{
    public class GovernmentEntityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string Description { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public bool IsActive { get; set; }
        public GovernmentEntityDto()
        {
            Name = string.Empty;
            Acronym = string.Empty;
            Description = string.Empty;
        }
    }
}