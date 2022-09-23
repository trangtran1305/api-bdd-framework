namespace AtlantaApi.Utils.ServiceVersionsManagement
{
    public class ServiceVersion2:ServiceVersionBase
    {
        public override ServiceEndpointName SetEndpoint()
        {
            var serviceEndpointName = new ServiceEndpointName();
            serviceEndpointName.IdentityServer = "/api/token/authorize";
            serviceEndpointName.Address = "/api/v2/address/search?postcode={postCode}&houseNumber={houseNumber}&policyType={policyType}";
            serviceEndpointName.Quotes = "/api/v2/quote/quotes";
            serviceEndpointName.SaveDebit = "/api/v2/quote/save-debit";
            serviceEndpointName.VehicleSearch = "/api/V2/vehicles/search";
            serviceEndpointName.ReCall = "/api/V2/Quote/recall";
            serviceEndpointName.StorePartialQuote = "/api/v2/quote/store-partial-quote";
            serviceEndpointName.Register = "/api/V2/payment/register";
            serviceEndpointName.SaveMarketing = "/api/V1/quote/save-marketing";
            serviceEndpointName.SavePaymentInfo = "/api/V1/quote/save-payment-info";
            serviceEndpointName.Outcome = "/api/V2/payment/outcome/AT-CN-CNS-MC-6258";
            serviceEndpointName.SaveCardConsent = "/api/quote/save-card-consent";
            serviceEndpointName.OutcomeSG = "/api/v2/payment/outcome/";
            return serviceEndpointName;
        }
        public override ResourcePath SetResource()
        {
            var resourcePath = new ResourcePath();
            resourcePath.Address = @"AddressService\V2\";
            resourcePath.Quotes = @"QuoteService\Quotes\V2\";
            resourcePath.SaveDebit = @"QuoteService\SaveDebit\V2\";
            resourcePath.SavePaymentInfo = @"QuoteService\SavePaymentInfo\V2\";
            resourcePath.VehicleService = @"VehicleService\V2\";
            resourcePath.VehicleSearch = @"VehicleService\V2\";
            resourcePath.ReCall = @"QuoteService\Recall\V2\";
            resourcePath.StorePartialQuote = @"QuoteService\PartialQuote\V2\";
            resourcePath.Register = @"PaymentService\V2\";
            resourcePath.SaveMarketing = @"QuoteService\SaveMarketing\V1\";
            resourcePath.SavePaymentInfo = @"QuoteService\SavePaymentInfo\V1\";
            resourcePath.Outcome = @"WebHookService\V2\";
            resourcePath.SaveCardConsent = @"SaveCardConsentService\V2\";

            return resourcePath;
        }
    }
}
