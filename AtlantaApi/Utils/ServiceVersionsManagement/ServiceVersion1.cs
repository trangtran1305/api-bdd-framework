namespace AtlantaApi.Utils.ServiceVersionsManagement
{
    public class ServiceVersion1:ServiceVersionBase
    {
        public override ServiceEndpointName SetEndpoint()
        {
            var serviceEndpointName = new ServiceEndpointName();
            serviceEndpointName.IdentityServer = "/api/token/authorize";
            serviceEndpointName.Address = "/api/v1/address/search?postcode={postCode}&houseNumber={houseNumber}";
            serviceEndpointName.Quotes = "/api/v1/quote/quotes";
            serviceEndpointName.SaveDebit = "/api/v1/quote/save-debit";
            serviceEndpointName.SaveMarketing = "/api/V1/quote/save-marketing";
            serviceEndpointName.SavePaymentInfo = "/api/V1/quote/save-payment-info";
            serviceEndpointName.Branding = "/api/v1/branding/open-hours";
            serviceEndpointName.Manufactures = "/api/v1/vehicles/manufactures";
            serviceEndpointName.VehicleSearch = "/api/V1/vehicles/search";
            serviceEndpointName.VehicleTypes = "/api/v1/vehicles/vehicle-types";
            serviceEndpointName.ModelList = "/api/v1/vehicles/models?ManufacturerId={ManufacturerId}&year=2019";
            serviceEndpointName.Models = "/api/v1/vehicles/models";
            serviceEndpointName.ReCall = "/api/V1/Quote/recall";
            serviceEndpointName.Register = "/api/V1/payment/register";
            serviceEndpointName.Outcome = "/api/V1/payment/outcome";
            serviceEndpointName.Lookup = "/api/V1/vehicle/lookup?RegistrationNumber={RegistrationNumber}";
            serviceEndpointName.StorePartialQuote = "/api/v1/quote/store-partial-quote";
            serviceEndpointName.SaveCardConsent = "/api/quote/save-card-consent";
            serviceEndpointName.VehicleMakeList = "/api/v1/vehicles/basevehiclemake";
            serviceEndpointName.ModelListSG = "/api/v1/vehicles/models?ManufacturerId={ManufacturerId}&vehicletypeID={VehicleTypeID}";
            serviceEndpointName.ManufacturesList = "/api/v1/vehicles/manufactures?VehicleTypeId={VehicleTypeId}";
            serviceEndpointName.ModelListScenicMH = "/api/v1/vehicles/models?ManufacturerId={ManufacturerId}&VehicletypeID={VehicleTypeID}";
            serviceEndpointName.BrandingPhone = "/api/v1/branding/aggregator";
            return serviceEndpointName;
        }
        public override ResourcePath SetResource()
        {
            var resourcePath = new ResourcePath();
            resourcePath.Address = @"AddressService\V1\";
            resourcePath.Quotes = @"QuoteService\Quotes\V1\";
            resourcePath.SaveDebit = @"QuoteService\SaveDebit\V1\";
            resourcePath.SaveMarketing = @"QuoteService\SaveMarketing\V1\";
            resourcePath.SavePaymentInfo = @"QuoteService\SavePaymentInfo\V1\";
            resourcePath.VehicleService = @"VehicleService\V1\";
            resourcePath.ReCall = @"QuoteService\Recall\V1\";
            resourcePath.Register = @"PaymentService\V1\";
            resourcePath.VehicleSearch = @"VehicleService\V1\";
            resourcePath.Outcome = @"WebHookService\V1\";
            resourcePath.StorePartialQuote = @"QuoteService\PartialQuote\V1\";
            resourcePath.SaveCardConsent = @"SaveCardConsentService\V2\";

            return resourcePath;
        }
    }
}
