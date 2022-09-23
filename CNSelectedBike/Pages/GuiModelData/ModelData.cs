using System;
using System.Collections.Generic;
using System.Text;

namespace CNSBike.Pages.GuiModelData
{
    public class YourMotorcycleData
    {
        public string RegNumber { get; set; }
        public string PurchaseDay { get; set; }
        public string PurchaseMonth { get; set; }
        public string PurchaseYear { get; set; }

        public string EstimateValue { get; set; }
        public string IsModifiedYes { get; set; }
        public string IsModifiedNo { get; set; }
        public string ImmobiliserType { get; set; }
        public string IsImmobilisedFitted { get; set; }
        public string TrackerFittedYes { get; set; }
        public string TrackerFittedNo { get; set; }
        public string SecurityTagFitted { get; set; }
        public string OtherSecurityDevicesFittedYes { get; set; }
        public string OtherSecurityDevicesFittedNo { get; set; }
        public string AnnualMileage { get; set; }
        public string CarryPillionPassengersYes { get; set; }
        public string CarryPillionPassengersNo { get; set; }
        public string ParkOvernight { get; set; }
        public string ParkOvernightAtHomeYes { get; set; }
        public string ParkOvernightAtHomeNo { get; set; }
        public string KeptPostcode { get; set; }
        public string Modification1 { get; set; }

    }

    public class AboutYouData
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }

        public string BirthMonth { get; set; }
        public string BirthYear { get; set; }
        public string UKResidentSinceBirthYes { get; set; }
        public string UKResidentSinceBirthNo { get; set; }
        public string MaritalStatus { get; set; }
        public string PostCode { get; set; }
        public string HomeownerYes { get; set; }
        public string HomeownerNo { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string EmploymentStatus { get; set; }
        public string DrivingLicenceType { get; set; }
        public string DrivingLicenceDate { get; set; }
        public string DrivingLicenceMonth { get; set; }
        public string MemberOfOrganisationOrClub { get; set; }
        public string AdvancedRiderQualifications { get; set; }

    }

    public class AdditionalRiderData
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }

        public string BirthMonth { get; set; }
        public string BirthYear { get; set; }
        public string UKResidentSinceBirthYes { get; set; }
        public string UKResidentSinceBirthNo { get; set; }
        public string MaritalStatus { get; set; }
        public string EmploymentStatus { get; set; }
        public string RelationshipToProposer { get; set; }
        public string DrivingLicenceType { get; set; }
        public string DrivingLicenceDate { get; set; }

    }
    public class RiderHistoryData
    {
        public string ClaimCustomer1 { get; set; }
        public string DateInputDay_ClaimDate1 { get; set; }
        public string DateInputMonth_ClaimDate1 { get; set; }
        public string DateInputYear_ClaimDate1 { get; set; }
        public string ClaimType1 { get; set; }
        public string ConvictionCustomer1 { get; set; }
        public string ConvictionDay1 { get; set; }
        public string ConvictionMonth1 { get; set; }
        public string ConvictionYear1 { get; set; }
        public string ConvictionCode1 { get; set; }

    }

    public class YourCoverData
    {
        public string VehicleUse { get; set; }
        public string CoverTypeComprehensive { get; set; }
        public string CoverTypeThirdPartyFireTheft { get; set; }
        public string DateInputYear_ClaimDate1 { get; set; }
        public string StartDate { get; set; }

    }
}
