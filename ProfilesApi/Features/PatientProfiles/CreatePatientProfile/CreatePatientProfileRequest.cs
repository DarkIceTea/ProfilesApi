﻿namespace ProfilesApi.Features.PatientProfiles.CreatePatientProfile
{
    public class CreatePatientProfileRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string MiddleName { get; set; } = null!;
        public required string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
