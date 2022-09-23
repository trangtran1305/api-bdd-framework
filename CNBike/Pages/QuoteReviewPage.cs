using CNBike.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CNBike.Pages
{
    public class QuoteReviewPage: BasePage
    {
        private By pageTitle = By.Id("QuoteReviewForm");
        private By QuoteReviewIntroduceEmail = By.Id("QuoteReview_Introduce_Email");
        private By QuoteReviewIntroducePhone = By.Id("QuoteReview_Introduce_Phone");
        private By Motorcycle0 = By.XPath("//span[@id='QuoteReview_Motorcycle_Hide_0']/../../..");
        private By Motorcycle0List= By.XPath("//span[@id='QuoteReview_Motorcycle_Hide_0']/../../../div//div[@class='your-motorcycle']/span");
        private By Motorcycle0List1= By.XPath("//span[@id='QuoteReview_Motorcycle_Hide_0']/../../../div//h5[text() ='Your Motorcycle']/following-sibling::span[1]");
        //private By QuoteReviewIntroducePhone = By.Id("QuoteReview_Introduce_Phone");
        private By QuoteReviewMotorcycleView0 = By.Id("QuoteReview_Motorcycle_View_0");
        private By QuoteReviewMotorcycleView1 = By.Id("QuoteReview_Motorcycle_View_1");
        private By QuoteReviewMotorcycleView2 = By.Id("QuoteReview_Motorcycle_View_2");
        private By QuoteReviewMotorcycleView3 = By.Id("QuoteReview_Motorcycle_View_3");
        private By QuoteReviewMotorcycleView4 = By.Id("QuoteReview_Motorcycle_View_4");


        private By QuoteReviewRiderYourDetailView = By.Id("QuoteReview_Rider_YourDetail_View");
        private By QuoteReviewRiderRider0View = By.Id("QuoteReview_Rider_Rider0_View");
        private By QuoteReviewRiderRider1View = By.Id("QuoteReview_Rider_Rider1_View");
        private By QuoteReviewRiderRider2View = By.Id("QuoteReview_Rider_Rider2_View");
        private By QuoteReviewRiderRider3View = By.Id("QuoteReview_Rider_Rider3_View");
        private By QuoteReviewRiderHistoryView = By.Id("QuoteReview_RiderHistory_View");
        private By btnPostPolicyDocument = By.Id("btnPost_PolicyDocument");
        private By btnEmailPolicyDocument = By.Id("btnEmail_PolicyDocument");
        private By txtQuoteMotorcycleReviewRegistration0 = By.Id("Quote_Motorcycle_Review_Registration_0");
        private By txtQuoteMotorcycleReviewRegistration1 = By.Id("Quote_Motorcycle_Review_Registration_1");
        private By txtQuoteMotorcycleReviewRegistration2 = By.Id("Quote_Motorcycle_Review_Registration_2");
        private By txtQuoteMotorcycleReviewRegistration3 = By.Id("Quote_Motorcycle_Review_Registration_3");
        private By txtQuoteMotorcycleReviewRegistration4 = By.Id("Quote_Motorcycle_Review_Registration_4");
        private By btnConfirm = By.Id("btnConfirm");
        private By btnNext = By.Id("btnNext");


        public void VerifyPageTitle(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                Assert.True(IsElementDisplayed(pageTitle));
            }
        }

        public void CheckIntroduction(string input)
        {
            if (input.Equals("Required"))
            {
                var cacheModel = getCookie();
                var mainRider = cacheModel.Riders[0];
                CheckAssertData(QuoteReviewIntroduceEmail, mainRider.address.email, TypeFormControl.Input);
                CheckAssertData(QuoteReviewIntroducePhone, mainRider.address.phoneContact, TypeFormControl.Input);
            }
        }

        public void CheckRiderHistory(string input)
        {
            if (input.Equals("Required"))
            {
                if (CheckElementExists(QuoteReviewRiderHistoryView))
                {
                    Click(QuoteReviewRiderHistoryView);
                }
                var cacheModel = getCookie();
                CheckClaims(cacheModel.Claims, cacheModel.Riders);
                CheckConvictions(cacheModel.Convictions, cacheModel.Riders, cacheModel.Claims.Count);
            }
        }

        public void CheckPolicyDocument(string input)
        {
            if (input.Equals("Required"))
            {
                Assert.True(IsElementDisplayed(btnPostPolicyDocument));
                Assert.True(IsElementDisplayed(btnEmailPolicyDocument));
            }
        }

        public void CheckPayment(string input)
        {
            if (input.Equals("Required"))
            {
                var cacheModel = getCookie();
                var cacheSummary = cacheModel.QuoteSummary;
                if (cacheModel.QuoteSummary.Type == "month")
                {
                    var TotalMonthPayment = GenderTextPayment(" Total monthly payment ");
                    var Deposit = GenderTextPayment(" Deposit (payable today) ");
                    var InstalmentsOf = GenderTextPayment(" Then 12 instalments of ");
                    var FinanceCharge = GenderTextPayment(" Finance charge ");
                    var TotalAmount = GenderTextPayment(" Total amount payable ");
                    var APRRepresentative = GenderTextPayment(" APR representative ");
                    var InterestRate = GenderTextPayment(" Interest rate ");
                   
                    CheckAssertData(cacheSummary.TotalMonthPayment, TotalMonthPayment);
                    CheckAssertData(cacheSummary.Deposit, Deposit);
                    CheckAssertData(cacheSummary.InstalmentsOf, InstalmentsOf);
                    CheckAssertData(cacheSummary.FinanceCharge, FinanceCharge);
                    CheckAssertData(cacheSummary.TotalAmount, TotalAmount);
                    CheckAssertData(cacheSummary.APRRepresentative, APRRepresentative);
                    CheckAssertData(cacheSummary.InterestRate, InterestRate);
                    
                } else
                {
                    var TotalPayment = GenderTextPayment(" Total payment ");
                    CheckAssertData(cacheSummary.TotalPayment, TotalPayment);
                }
            }
        }

        public void CheckClaims(List<Claim> Claims, List<Rider> Riders)
        {
            if (Claims.Count > 0)
            {
                for (int i = 0; i < Claims.Count; i++)
                {
                    CheckDetailClaim(Claims[i], i, Riders);
                }
            }
        }

        public void CheckConvictions(List<Conviction> Convictions, List<Rider> Riders, int claimIndex)
        {
            if (Convictions.Count > 0)
            {
                for (int i = 0; i < Convictions.Count; i++)
                {
                    CheckDetailConviction(Convictions[i], i, Riders, claimIndex);
                }
            }
        }

        public void CheckDetailConviction(Conviction conviction, int index, List<Rider> Riders,int claimIndex)
        {
            var Id = $"QuoteReview_Rider_RiderHistory_Edit_{claimIndex + index}";
            var ConvictionIndex = $"Conviction {index + 1}";
            var RiderName = GenderTextRiderHistoryFromUi(Id, ConvictionIndex, "Rider");
            var ConvictionDate = GenderTextRiderHistoryFromUi(Id, ConvictionIndex, "Date of conviction");
            var ConvictionCause = GenderTextRiderHistoryFromUi(Id, ConvictionIndex, "Conviction type");
            var PenaltyPoints = GenderTextRiderHistoryFromUi(Id, ConvictionIndex, "Penalty points");
            var ValueOfFine = GenderTextRiderHistoryFromUi(Id, ConvictionIndex, "Fine amount £");
            var NumberOfMonth = GenderTextRiderHistoryFromUi(Id, ConvictionIndex, "Banned");
            if (Riders.Count == 1)
            {
                var NameMainRider = Riders[0].personalDetails.title + " " + Riders[0].personalDetails.firstName + " " + Riders[0].personalDetails.surName;
                CheckAssertData(NameMainRider, RiderName);
            }
            else
            {
                CheckAssertData(conviction.convictionRiderName, RiderName);
            }
            CheckAssertData(conviction.convictionDate, ConvictionDate);
            CheckAssertData(conviction.convictionCause, ConvictionCause);
            CheckAssertData(conviction.penaltyPoints, PenaltyPoints);
            CheckAssertData($"£{conviction.valueOfFine}", ValueOfFine);
            CheckAssertData($"{conviction.numberOfMonth} month", NumberOfMonth);
        }
        public void CheckDetailClaim(Claim claim, int index, List<Rider> Riders)
        {
            var Id = $"QuoteReview_Rider_RiderHistory_Edit_{index}";
            var ClaimIndex = $"Claim {index + 1}";
            var RiderName = GenderTextRiderHistoryFromUi(Id, ClaimIndex, "Rider");
            var ClaimDate = GenderTextRiderHistoryFromUi(Id, ClaimIndex, "Date of claim");
            var ClaimCause = GenderTextRiderHistoryFromUi(Id, ClaimIndex, "Cause");
            var TotalEstimatedCost = GenderTextRiderHistoryFromUi(Id, ClaimIndex, "Estimated claim cost");
            var ClaimBonusAffected = GenderTextRiderHistoryFromUi(Id, ClaimIndex, "No Claims Bonus affected");

            if (Riders.Count == 1)
            {
                var NameMainRider = Riders[0].personalDetails.title + " " + Riders[0].personalDetails.firstName + " " + Riders[0].personalDetails.surName;
                CheckAssertData(NameMainRider, RiderName);
            } else
            {
                CheckAssertData(claim.riderName, RiderName);
            }
            CheckAssertData(claim.claimDate, ClaimDate);
            CheckAssertData(claim.claimCause, ClaimCause);
            CheckAssertData($"£{claim.totalEstimatedCost}", TotalEstimatedCost);
            CheckAssertData(claim.claimBonusAffected, ClaimBonusAffected);
        }

        public void CheckYourCover(string input)
        {
            if (input.Equals("Required"))
            {

            }
        }
        public void openMotorcycle(string Id, int Index)
        {
            if (CheckElementExists(By.Id($"QuoteReview_Motorcycle_View_{Index}"))) {
                Click(By.Id($"QuoteReview_Motorcycle_View_{Index}"));
            }
        }

        public void CheckMotorcycles(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var cacheModel = getCookie();
                var motorcycleList = cacheModel.Motorcycles;
                if (motorcycleList.Count > 0)
                {
                    for (int i = 0; i < motorcycleList.Count; i++)
                    {
                        openMotorcycle($"QuoteReview_Motorcycle_View_{i}", i);
                        CheckDetailMotorcycle(motorcycleList[i], i);
                    }
                }
            }
        }
        public void openRider(int index)
        {
                switch (index)
                {
                    case 0:
                    if(CheckElementExists(QuoteReviewRiderYourDetailView) == true) Click(QuoteReviewRiderYourDetailView);
                        break;
                    case 1:
                    if (CheckElementExists(QuoteReviewRiderRider0View) == true) Click(QuoteReviewRiderRider0View);
                        break;
                    case 2:
                    if (CheckElementExists(QuoteReviewRiderRider1View) == true) Click(QuoteReviewRiderRider1View);
                        break;
                    case 3:
                    if (CheckElementExists(QuoteReviewRiderRider2View) == true) Click(QuoteReviewRiderRider2View);
                        break;
                    case 4:
                    if (CheckElementExists(QuoteReviewRiderRider3View) == true) Click(QuoteReviewRiderRider3View);
                        break;
                }
        }

        public void CheckRider(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                var cacheModel = getCookie();
                var riderList = cacheModel.Riders;
                if (riderList.Count > 0)
                {
                    for (int i = 0; i < riderList.Count; i++)
                    {
                        openRider(i);
                        CheckDetailRider(riderList[i], i);

                    }
                }
            }
        }

        public void CheckDetailRider(Rider rider, int index)
        {
            var personalDetails = rider.personalDetails;
            var address = rider.address;
            var riderEmployment = rider.riderEmployment;
            var yourRiding = rider.yourRiding;
            var riderGenderParentId = RiderGenderParentId(index);
            var YourName = GenderTextRiderFromUi(1, riderGenderParentId, " Your name ");
            var DateOfBirth = GenderTextRiderFromUi(1, riderGenderParentId, " Date of birth ");
            var YourMaritalStatus = GenderTextRiderFromUi(1, riderGenderParentId, " Marital status ");
            var PermanentUKresident = GenderTextRiderFromUi(1, riderGenderParentId, " Permanent UK resident ");
            var MotorcycleLicenceType = GenderTextRiderFromUi(1, riderGenderParentId, " Licence type ");
            var MonthsOfLicence = GenderTextRiderFromUi(1, riderGenderParentId, " Licence date ");
            var MotoringOrganisation = GenderTextRiderFromUi(1, riderGenderParentId, " Motoring organisation ");
            var AdvancedRiderQualifications = GenderTextRiderFromUi(1, riderGenderParentId, " Advanced rider qualification ");
            //var YourAddress = GenderTextRiderFromUi(1, riderGenderParentId, " Your address ");
            var HomeOwner = GenderTextRiderFromUi(1, riderGenderParentId, " Homeowner ");
            var EmploymentStatusOption = GenderTextRiderFromUi(1, riderGenderParentId, " Employment status ");
            var EmploymentMainJobOption = GenderTextRiderFromUi(1, riderGenderParentId, " Main job ");
            var EmploymentIndustryJobOption = GenderTextRiderFromUi(1, riderGenderParentId, " Business Type / Industry ");
            var YesNoAdditionalPartTimeJob = GenderTextRiderFromUi(1, riderGenderParentId, " Part-time employment status ");
            var EmploymenPartTimeJobStatusJobOption = GenderTextRiderFromUi(1, riderGenderParentId, " Part-time employment status ");
            var EmploymenIndustryPartTimeJobInJobOption = GenderTextRiderFromUi(1, riderGenderParentId, " Part-time job ");
            //var EmploymenPartTimeJobInJobOption = GenderTextRiderFromUi(1, riderGenderParentId, " Business Type / Industry ");
            var fullNameFromCache = $"{personalDetails.title} {personalDetails.firstName} {personalDetails.surName}";
            var dateOfBirthFromCache = $"{personalDetails.dateOfBirth.day}/{personalDetails.dateOfBirth.month}/{personalDetails.dateOfBirth.years}";
            //var addressFullFromUI = YourAddress.Replace("\r\n", " ");
            var addressFullFromCache = address.address + " " + address.postCode;
            //CheckAssertData(addressFullFromCache, addressFullFromUI);
            CheckAssertData(fullNameFromCache, YourName);
            CheckAssertData(dateOfBirthFromCache, DateOfBirth);
            CheckAssertData(personalDetails.yourMaritalStatus, YourMaritalStatus);
            if (personalDetails.yesNoPermanentResident.Equals("Yes"))
            {
                //CheckAssertData(personalDetails., PermanentUKresident);
            }
            CheckAssertData(yourRiding.motorcycleLicenceType, MotorcycleLicenceType);
            CheckAssertData(yourRiding.monthsOfLicence, MonthsOfLicence);
            CheckAssertData(yourRiding.motoringOrganisation, MotoringOrganisation);
            CheckAssertData(yourRiding.advancedRiderQualifications, AdvancedRiderQualifications);
            CheckAssertData(address.homeOwner, HomeOwner);
            CheckAssertData(riderEmployment.employmentStatusOption, EmploymentStatusOption);
            CheckAssertData(!String.IsNullOrEmpty(riderEmployment.employmenPartTimeJobStatusJobOption)? riderEmployment.employmenPartTimeJobStatusJobOption: "None", EmploymenPartTimeJobStatusJobOption);
            CheckAssertData(riderEmployment.employmenIndustryPartTimeJobInJobOption, EmploymenIndustryPartTimeJobInJobOption);
        }

        public string RiderGenderParentId(int index)
        {
            var parentId = "";
            switch (index)
            {
                case 0:
                    parentId = "QuoteReview_Rider_YourDetail_Hide";
                    break;
                case 1:
                    parentId = "QuoteReview_Rider_Rider0_Hide";
                    break;
                case 2:
                    parentId = "QuoteReview_Rider_Rider1_Hide";
                    break;
                case 3:
                    parentId = "QuoteReview_Rider_Rider2_Hide";
                    break;
                case 4:
                    parentId = "QuoteReview_Rider_Rider3_Hide";
                    break;
            }
            return parentId;
        }
        public void CheckDetailMotorcycle(Motorcycle Motorcycle, int Index)
        {
            var vehicleDetail = Motorcycle.vehicleDetail;
            var vehicleSecurity = Motorcycle.vehicleSecurity;
            var motorcycleUse = Motorcycle.motorcycleUse;
            var vehicleModifications = Motorcycle.vehicleModifications;
            var boughtDate = "";
            if (vehicleDetail.boughtDate != null)
            {
                boughtDate = vehicleDetail.boughtDate.day + "/" + vehicleDetail.boughtDate.month + "/" + vehicleDetail.boughtDate.years;
            } else
            {
                boughtDate = "Not purchased yet";
            }
            var MotorcycleParentId = $"QuoteReview_Motorcycle_Hide_{Index}";
            var Make = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Your Motorcycle");
            var Model = GenderTextMotorcycleFromUi(2, MotorcycleParentId, "Your Motorcycle");
            var Engine = GenderTextMotorcycleFromUi(3, MotorcycleParentId, "Your Motorcycle");
            var ManufactureDate = GenderTextMotorcycleFromUi(4, MotorcycleParentId, "Your Motorcycle");
            var BoughtDate = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Date purchased");
            var EstimatedMotorcycle = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Estimated market value");
            var ImmobiliserOption = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Immobiliser / Alarm fitted");
            var TrackingOption = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Tracking device fitted");
            var SecurityOption = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Security tags fitted");
            var YesNoSecurityDevices = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Physical security device");
            var EstimatedMiles = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Annual mileage");
            var YesNoPillionPassengers = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Carry pillion passengers");
            var VehicleStorageLocation = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Overnight parking location");
            var PostCode = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Postcode where parked overnight");
            var Modification1 = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Modification 1");
            var Modification2 = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Modification 2");
            var Modification3 = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Modification 3");
            var Modification4 = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Modification 4");
            var Modification5 = GenderTextMotorcycleFromUi(1, MotorcycleParentId, "Modification 5");
            //
            if (vehicleDetail.registrationNumber == null)
            {
                CheckAssertData(vehicleDetail.make, Make);
                CheckAssertData(vehicleDetail.model, Model);
                CheckAssertData($"{vehicleDetail.engine}cc", Engine);
                CheckAssertData(vehicleDetail.manufactureDate, ManufactureDate);
            }
            CheckAssertData(boughtDate, BoughtDate);
            CheckAssertData($"£ {vehicleDetail.estimatedMotorcycle}", EstimatedMotorcycle);
            CheckAssertData(vehicleSecurity.trackingOption != null ? vehicleSecurity.trackingOption : "None", TrackingOption);
            CheckAssertData(vehicleSecurity.securityOption, SecurityOption);
            CheckAssertData(vehicleSecurity.yesNoSecurityDevices, YesNoSecurityDevices);
            CheckAssertData(motorcycleUse.estimatedMiles, EstimatedMiles);
            CheckAssertData(motorcycleUse.yesNoPillionPassengers, YesNoPillionPassengers);
            //CheckAssertData(motorcycleUse.postCode, PostCode);
            if (vehicleModifications.yesNoModification.Equals("Yes"))
            {
                var ModificationCache1 = vehicleModifications.modificationItem.Find(el => el.modificationIndex == 0);
                var ModificationCache2 = vehicleModifications.modificationItem.Find(el => el.modificationIndex == 1);
                var ModificationCache3 = vehicleModifications.modificationItem.Find(el => el.modificationIndex == 2);
                var ModificationCache4 = vehicleModifications.modificationItem.Find(el => el.modificationIndex == 3);
                var ModificationCache5 = vehicleModifications.modificationItem.Find(el => el.modificationIndex == 4);
                CheckAssertModification(ModificationCache1, Modification1);
                CheckAssertModification(ModificationCache2, Modification2);
                CheckAssertModification(ModificationCache3, Modification3);
                CheckAssertModification(ModificationCache4, Modification4);
                CheckAssertModification(ModificationCache5, Modification5);
            }
        }

        public void CheckAssertModification(ModificationItem ModificationCache, string ModificationCacheFromUI)
        {
            if (ModificationCache != null && !String.IsNullOrEmpty(ModificationCache.modificationName))
            {
                CheckAssertData(ModificationCache.modificationName, ModificationCacheFromUI);
            }
        }

        public void CheckAssertData(string dataFromCache, string dataFromUI)
        {
            if (!String.IsNullOrEmpty(dataFromUI))
            {
                Assert.True(dataFromCache.Equals(dataFromUI, StringComparison.CurrentCultureIgnoreCase));
            } else
            {
                Assert.True(true);
            }
        }

        public string GenderTextMotorcycleFromUi(int Index, string Id, string ParentTxt)
        {
            try
            {
                var XPathString = By.XPath($"//span[@id='{Id}']/../../../div//h5[text() ='{ParentTxt}']/following-sibling::span[{Index}]");
                return _driver.FindElement(XPathString).Text;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GenderTextRiderFromUi(int Index, string Id, string ParentTxt)
        {
            try
            {
                var XPathString = By.XPath($"//span[@id='{Id}']/../../../div//div[text()='{ParentTxt}']/following-sibling::div[{Index}]");
                return _driver.FindElement(XPathString).Text;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GenderTextRiderHistoryFromUi (string Id, string parentTxt, string subParentTxt)
        {
            //ex id = QuoteReview_Rider_RiderHistory_Edit_0
            // parentTxt = Claim 1
            //subparent = Rider
            try
            {
                var XPathString = By.XPath($"//a[@id='{Id}']/../../..//span[text()='{parentTxt}']/../..//h5[text()='{subParentTxt}']/following-sibling::p[1]");
                return _driver.FindElement(XPathString).Text;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GenderTextPayment(string parantText)
        {
            try
            {
                var XPathString = By.XPath($"//h5[text()='Payment']/..//div[text()='{parantText}']/following-sibling::div[1]");
                return _driver.FindElement(XPathString).Text;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void InputMotorcycleRegistration0(string input)
        {
            if(!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtQuoteMotorcycleReviewRegistration0, input);

            }
        }
        public void InputMotorcycleRegistration1(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtQuoteMotorcycleReviewRegistration1, input);
            }
        }
        public void InputMotorcycleRegistration2(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtQuoteMotorcycleReviewRegistration2, input);
            }
        }
        public void InputMotorcycleRegistration3(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtQuoteMotorcycleReviewRegistration3, input);
            }
        }
        public void InputMotorcycleRegistration4(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                TypeInElement(txtQuoteMotorcycleReviewRegistration4, input);
            }
        }

        public void ClickConfirm(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnConfirm);
            }
        }
        public void ClickBtnNext(string input)
        {
            if (input.Equals("Required"))
            {
                Click(btnNext);
                WaitForLoadingIconDisappear();
                if(_driver.FindElements(pageTitle).Count > 0)
                {
                    Click(btnNext);
                    WaitForLoadingIconDisappear();
                }
            }
        }
    }

}
