using System.ComponentModel.DataAnnotations;

namespace ProfilesApi.Features.Profiles.Domain
{
    public class PatientProfile
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        public required string MiddleName { get; set; }
        public required string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
