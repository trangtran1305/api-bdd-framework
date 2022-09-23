using System;
using System.Collections.Generic;
using System.Text;

namespace CNBike.Model
{
    public static class TypeFormControl
    {
        public const string Input = "Input";
        public const string DropDownList = "DropDownList";
        public const string BtnYesNo = "BtnYesNo";

    }
    public static class CoverType
    {
        public const string Comprehensive = "Comprehensive";
        public const string ThirdPartyOnly = "Third Party Only";
        public const string ThirdPartyFireTheft = "Third Party, Fire and Theft";

    }
    public static class ContactType
    {
        public const string Post = "Post";
        public const string Phone = "Phone";
        public const string Email = "Email";
        public const string SMS = "SMS";

    }

    public class VehicleDetail
    {
        public string registrationNumber { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string engine { get; set; }
        public string fuel { get; set; }
        public string transmission { get; set; }
        public string manufactureDate { get; set; }
        public DateType boughtDate { get; set; }
        public string abiCode { get; set; }
        public string estimatedMotorcycle { get; set; }
        public string fromToYear { get; set; }
        public int mainDriverId { get; set; }
        public string vehicleSpecific { get; set; } // new 
    }
    public class DateType
    {
        public string day { get; set; }
        public string month { get; set; }
        public string years { get; set; }
    }

    public class VehicleModifications
    {
        public List<ModificationItem> modificationItem { get; set; }
        public string yesNoModification { get; set; }
    }

    public class ModificationItem
    {
        public int modificationIndex { get; set; }
        public string modificationName { get; set; }
    }
    public class VehicleSecurity
    {
        public string electronicOption { get; set; }
        public string immobiliserOption { get; set; }
        public string trackingOption { get; set; }
        public string yesNoTrackingDevice { get; set; }
        public string securityOption { get; set; }
        public string yesNoSecurityDevices { get; set; }
    }


    public class MotorcycleUse
    {
        public string vehicleStorageLocation { get; set; }
        public string postCode { get; set; }
        public string estimatedMiles { get; set; }
        public string yesNoPillionPassengers { get; set; }
        public string motorcycleParked { get; set; }
    }

    public class Motorcycle
    {
        public int index { get; set; }
        public VehicleDetail vehicleDetail { get; set; } = new VehicleDetail();
        public VehicleModifications vehicleModifications { get; set; } = new VehicleModifications();
        public VehicleSecurity vehicleSecurity { get; set; } = new VehicleSecurity();
        public MotorcycleUse motorcycleUse { get; set; } = new MotorcycleUse();
    }



    public class PersonalDetails
    {
        public string title { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public string yourMaritalStatus { get; set; }
        public string yesNoPermanentResident { get; set; }
        public DateType dateOfBirth { get; set; }
        public string permanentResidentMonth { get; set; } //new
        public string permanentResidentYear { get; set; }//new
        public string relationshipStatus { get; set; }
        public string gender { get; set; }

    }


    public class Address2
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public string addressLine4 { get; set; }
        public string selectedAddress { get; set; }
    }


    public class Address
    {
        public string postCode { get; set; }
        public string address { get; set; }
        public string homeOwner { get; set; }
        public string email { get; set; }
        public string phoneContact { get; set; }
    }



    public class RiderEmployment
    {
        public string employmentStatusOption { get; set; }
        public string employmentStudentOption { get; set; }
        public string employmentMainJobOption { get; set; }
        public string employmentIndustryJobOption { get; set; }
        public string yesNoAdditionalPartTimeJob { get; set; }
        public string employmenPartTimeJobStatusJobOption { get; set; }
        public string employmenIndustryPartTimeJobInJobOption { get; set; }
        public string employmenPartTimeJobInJobOption { get; set; }

    }

    public class YourRiding
    {
        public string motorcycleLicenceType { get; set; }
        public string yearsOfLicence { get; set; }
        public string monthsOfLicence { get; set; }
        public string motoringOrganisation { get; set; }
        public string advancedRiderQualifications { get; set; }
        public string dateCBT { get; set; }
        public string licenceDate { get; set; }
        public bool isUpdateRider { get; set; }
        public bool holdCbtCertificate { get; set; }
        public string carLicenceDate { get; set; }
        public bool isUpdateLicenceDate { get; set; }
    }

    public class Rider
    {
        public int id { get; set; }
        public int index { get; set; }
        public PersonalDetails personalDetails { get; set; } = new PersonalDetails();
        public Address address { get; set; } = new Address();
        public RiderEmployment riderEmployment { get; set; } = new RiderEmployment();
        public YourRiding yourRiding { get; set; } = new YourRiding();

    }

    public class Claim
    {
        public string riderName { get; set; }
        public string claimDate { get; set; }
        public string claimCause { get; set; }
        public string totalEstimatedCost { get; set; }
        public string claimBonusAffected { get; set; }
        public bool personalInjury { get; set; }
        public bool? thisPolicy { get; set; }
        public string thirdPartyCost { get; set; }
    }

    public class Conviction
    {
        public string convictionDate { get; set; }
        public string convictionCause { get; set; }
        public string valueOfFine { get; set; }
        public string convictionRiderName { get; set; }
        public string penaltyPoints { get; set; }
        public string isFineControl { get; set; }
        public string isBannedControl { get; set; }
        public string numberOfMonth { get; set; }
        public string drinkReading { get; set; }
        public string drinkReadingLevel { get; set; }
    }

    public class NoClaimsBonus
    {
        public string yearsOfNCB { get; set; }
        public string haveOwnedAMotorcycle { get; set; }
        public string styleOfMotorcycle { get; set; }
        public string engineSizeOfMotorcycle { get; set; }
        public string yearOfManufactureTheMotorcycle { get; set; }
        public string quantityYearsOwnTheMotorcycle { get; set; }
        public string quantityYearsNCBHaveOnMotorcycle { get; set; }
        public string timeLastRideTheMotorcycle { get; set; }
        public string protectedBonus { get; set; }
    }


    public class YourCover
    {
        public string motorcycleUsed { get; set; }
        public string typeOfCover { get; set; }
        public string insuranceStart { get; set; }
        public string lastInsurance { get; set; }
    }

    public class ContactYou
    {
        public string contactType { get; set; }
        public string yesNoGroupPartners { get; set; }
    }

    public class Cover
    {
        public YourCover yourCover { get; set; } = new YourCover();
        public ContactYou contactYou { get; set; } = new ContactYou();
    }



    public class QuoteRequestModel
    {
        public string WebReference { get; set; }
        public List<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();
        public List<Rider> Riders { get; set; } = new List<Rider>();
        public List<Claim> Claims { get; set; } = new List<Claim>();
        public List<Conviction> Convictions { get; set; } = new List<Conviction>();
        public NoClaimsBonus NoClaimsBonus { get; set; } = new NoClaimsBonus();
        public Cover Cover { get; set; } = new Cover();
        public string VoluntaryExcess { get; set; }
        public string Affinity { get; set; }
        public string SchemeCode { get; set; }
        public bool IsIgnoreException { get; set; }
        public bool RegisteredKeeper { get; set; }
        public bool isQuoteFromRecall { get; set; }
        public bool IsAggregator { get; set; }
        public string ChannelCode { get; set; }
        public List<DuqTypeModel> ExtraDuqs { get; set; }
        public PreviousInsuranceModel PreviousInsurance { get; set; }
        public List<MembershipModel> Membership { get; set; }
        public List<MedicalConditionModel> MedicalConditions { get; set; }
        public QuoteSummary QuoteSummary { get; set; }

    }

    public class QuoteSummary {
        public string Type { get; set; }
        public string Deposit { get; set; }
        public string InstalmentsOf { get; set; }
        public string FinanceCharge { get; set; }
        public string TotalAmount { get; set; }
        public string APRRepresentative { get; set; }
        public string InterestRate { get; set; }
        public string TotalPayment { get; set; }
        public string TotalMonthPayment { get; set; }
        public string VoluntaryExcess { get; set; }

    }

    public class MedicalConditionModel
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public bool? NotifiedDvla { get; set; }
        public bool? RestrictionDvla { get; set; }
        public string Claims { get; set; }
        public string Status { get; set; }
        public bool? VehicleModified { get; set; }
        public bool? Treatment { get; set; }
    }

    public class PreviousInsuranceModel
    {
        public string type { get; set; }
        public DateTime expiryDate { get; set; }
    }
    public class MembershipModel
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class DuqTypeModel
    {
        public uint Number { get; set; }
        public string Value { get; set; }
    }

    public class ReferralEmailModel
    {
        public string WebReference { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string Affinity { get; set; }
    }
}
