﻿namespace ProfilesApi.Features.PatientProfiles.UpdatePatientProfile
{
    public class UpdatePatientProfileRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? MiddleName { get; set; }
        public required string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
