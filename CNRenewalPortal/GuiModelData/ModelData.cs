using System;
using System.Collections.Generic;
using System.Text;

namespace CNRenewalPortal.Pages.GuiModelData
{
   public class VehicleData
    {
        public string RegNumber { get; set; }

        public string IsLowProfileCampervan { get; set; }
        public string IsLowProfileMotorhome { get; set; }
        public string IsEuropeanAClassMotorhome { get; set; }
        public string IsAmericanAClassMotorhome { get; set; }
        public string IsDIYConversion { get; set; }
        public string IsFixedHighRisingRoofCampervan { get; set; }
        public string IsCoachbuiltMotorhome { get; set; }
        public string IsAmericanCClassMotorhome { get; set; }
        public string IsDayVanLeisureVan { get; set; }

        public string VehicleMake { get; set; }
        public string ManufacturerOrConverter { get; set; }
        public string VehicleModel { get; set; }
        public string YearOfManufacture { get; set; }
        public string EngineCC { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string NumberOfDoors { get; set; }
        public string NumOfSeats { get; set; }

        public string IsTrackingDeviceYes { get; set; }
        public string IsTrackingDeviceNo { get; set; }
        public string IsLeftHand { get; set; }
        public string IsRightHand { get; set; }
        public string EstimateValue { get; set; }
        public string IsConvertedPurposeBuiltYes { get; set; }
        public string IsConvertedPurposeBuiltNo { get; set; }
        public string HasManufacturerOrConverterYes { get; set; }
        public string HasManufacturerOrConverterNo { get; set; }
        public string OwnsVehicle { get; set; }
        public string IsRegisteredKeeperYes { get; set; }
        public string IsRegisteredKeeperNo { get; set; }
        public string ParkOvernightAtHomeYes { get; set; }
        public string ParkOvernightAtHomeNo { get; set; }
        public string Miles { get; set; }
        public string DrivingInEUYes { get; set; }
        public string DrivingInEUNo { get; set; }
        public string ParkOverNightOnDriveWay { get; set; }
        public string ParkOverNightOnTheRoad { get; set; }
        public string ParkOverNightInLockedGarage { get; set; }
        public string ImmobiliserType { get; set; }
        public string TrakingType { get; set; }
        public string Modification1 { get; set; }
        public string KeptPostCode { get; set; }

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
        public string UKResidentMonth { get; set; }
        public string UKResidentYear { get; set; }
        public string MaritalStatus { get; set; }
        public string DVLAYes { get; set; }
        public string DVLANo { get; set; }
        public string HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactTelNumber { get; set; }
        public string EmploymentStatus { get; set; }
        public string MainJob { get; set; }
        public string MainJobBusiness { get; set; }
        public string PartTimeStatus { get; set; }
        public string PartTimeYes { get; set; }
        public string PartTimeNo { get; set; }
        public string PartTimeJob { get; set; }
        public string PartTimeJobBusiness { get; set; }
        public string DrivingLicenceType { get; set; }
        public string DrivingLicenceDate { get; set; }
        public string DrivingLicenceDay { get; set; }
        public string DrivingLicenceMonth { get; set; }
        public string DrivingLicenceYear { get; set; }
        public string NCBYear { get; set; }
        public string NumOfVehicle { get; set; }
        public string PersonalVehicleStatus { get; set; }
        public string CaravanVehicleYes { get; set; }
        public string CaravanVehicleNo { get; set; }
    }

    public class AdditionalDriverData
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string BirthDay { get; set; }

        public string BirthMonth { get; set; }
        public string BirthYear { get; set; }
        public string UKResidentSinceBirthYes { get; set; }
        public string UKResidentSinceBirthNo { get; set; }
        public string UKResidentMonth { get; set; }
        public string UKResidentYear { get; set; }
        public string RelationshipToProposer { get; set; }
        public string DVLANotifiedYes { get; set; }
        public string DVLANotifiedNo { get; set; }

        public string MaritalStatus { get; set; }
        public string EmploymentStatus { get; set; }
        public string MainJob { get; set; }
        public string MainJobBusiness { get; set; }
        public string PartTimeStatus { get; set; }
        public string PartTimeYes { get; set; }
        public string PartTimeNo { get; set; }
        public string PartTimeJob { get; set; }
        public string PartTimeJobBusiness { get; set; }
        public string DrivingLicenceType { get; set; }
        public string DrivingLicenceDate { get; set; }
        public string DrivingLicenceDay { get; set; }
        public string DrivingLicenceMonth { get; set; }
        public string DrivingLicenceYear { get; set; }
        public string OtherVehicleAccess { get; set; }
        public string MainDriverYes { get; set; }
        public string MainDriverNo { get; set; }

    }

    //hien add 31/5
    public class DriverHistoryData
    {
        public string FirstClaimYes { get; set; }
        public string FirstClaimNo { get; set; }
        public string FirstClaimDriver { get; set; }
        public string FirstClaimDay { get; set; }
        public string FirstClaimMonth { get; set; }
        public string FirstClaimYear { get; set; }
        public string FirstClaimCause { get; set; }
        public string FirstClaimCost { get; set; }
        public string FirstClaimAffectedYes { get; set; }
        public string FirstClaimAffectedNo { get; set; }
        public string FirstConvictionYes { get; set; }
        public string FirstConvictionNo { get; set; }
        public string FirstConvictionDriver { get; set; }
        public string FirstConvictionDay { get; set; }
        public string FirstConvictionMonth { get; set; }
        public string FirstConvictionYear { get; set; }
        public string FirstConvictionCode { get; set; }
        public string FirstConvictionPenaltyPoints { get; set; }
        public string FirstConvictionFineYes { get; set; }
        public string FirstConvictionFineNo { get; set; }
        public string FirstConvictionBannedDriverYes { get; set; }
        public string FirstConvictionBannedDriverNo { get; set; }
        public string IsCoverTypeComprehensive { get; set; }
        public string IsCoverTypeThirdPartyAndFireAndTheft { get; set; }
        public string IsCoverTypeThirdPartyOnly { get; set; }
        public string StartInsuranceDate { get; set; }
        public string IsInsurancePayByMonthly { get; set; }
        public string IsInsurancePayByAnnualy { get; set; }
        public string IsInsuranceNotExisted { get; set; }
        public string IsContactByEmail { get; set; }
        public string IsContactBySMS { get; set; }
    }
    public class InformationQuote
    {
        public string WebReference { get; set; }
        public string TotalAnnualPayment { get; set; }
        public string Deposit { get; set; }
        public string Then11InstalmentsOf { get; set; }
        public string FinanceCharge { get; set; }
        public string TotalAmountPayable { get; set; }
        public string APRRepresentative        { get; set; }
        public string InterestRate { get; set; }

    }
}
