using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeeAPI.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CitizenshipId { get; set; }
        public int CitizenshipLegislationCode { get; set; }
        public string CitizenshipStatus { get; set; }
        public DateTime CitizenshipToDate { get; set; }
        public string CorrespondenceLanguage { get; set; }
        public DateTime CreationDate { get; set; }
        public string DisplayName { get; set; }
        public int DriversLicenseId { get; set; }
        public string DriversLicenseIssuingCountry { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public string Ethnicity { get; set; }
        public string HomeFaxAreaCode { get; set; }
        public string HomeFaxCountryCode { get; set; }
        public string HomeFaxExtension { get; set; }
        public string HomeFaxLegislationCode { get; set; }
        public string HomeFaxNumber { get; set; }
        public string HomePhoneAreaCode { get; set; }
        public string HomePhoneCountryCode { get; set; }
        public string HomePhoneExtension { get; set; }
        public string HomePhoneLegislationCode { get; set; }
        public string HomePhoneNumber { get; set; }
        public string Honors { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int LegalEntityId { get; set; }
        public string LicenseNumber { get; set; }
        public string MaritalStatus { get; set; }
        public string MilitaryVetStatus { get; set; }
        public string NameSuffix { get; set; }
        public string NationalId { get; set; }
        public string NationalIdCountry { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
