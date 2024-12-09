namespace ProfilesApi.Domain
{
    public class DoctorProfile
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? MiddleName { get; set; }
        public required string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public required string Specialization { get; set; }
        public required string Office { get; set; }
        public DateOnly CareerStartYear { get; set; }
        public required string Status { get; set; }
    }
}
