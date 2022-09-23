namespace AtlantaApi.Utils.ServiceVersionsManagement
{
    public class ServiceVersion0 : ServiceVersionBase
    {
        public override ServiceEndpointName SetEndpoint()
        {
            var serviceEndpointName = new ServiceEndpointName();
            serviceEndpointName.IdentityServer = "/api/token/authorize";
            serviceEndpointName.Address = "/api/data-collection/addresses?postcode={postCode}&houseNumber={houseNumber}";
            serviceEndpointName.Quotes = "/api/quote/quotes";
            serviceEndpointName.SaveDebit = "/api/quote/save-debit";
            serviceEndpointName.ValidateBankDetails = "/api/quote/validate-bank-details";
            serviceEndpointName.ReferenceDataMetadata = "/api/reference-data/metadata";
            serviceEndpointName.ReferenceDataByKeyword = "/api/reference-data/metadata-bykeyword";
            serviceEndpointName.ReferenceDataByValue = "/api/reference-data/metadata-by-value";
            serviceEndpointName.Cache = "/api/infrastructure/cache/save";
            serviceEndpointName.PullCache = "/api/infrastructure/cache/pull";
            serviceEndpointName.SaveMarketing = "/api/quote/save-marketing";
            serviceEndpointName.ReCall = "/api/Quote/recall";
            serviceEndpointName.ModelList = "/api/data-collection/manufacturer/models?VehicleType={vehicleType}&ManufacturerName={manufacturerName}";
            serviceEndpointName.SaveCardConsent = "/api/quote/save-card-consent";
            return serviceEndpointName;
        }
        public override ResourcePath SetResource()
        {
            var resourcePath = new ResourcePath();
            resourcePath.Quotes = @"QuoteService\Quotes\V0\";
            resourcePath.Address = @"AddressService\V0\";
            resourcePath.SaveDebit = @"QuoteService\SaveDebit\V0\";
            resourcePath.ValidateBankDetails = @"ValidateBankDetails\V0\ValidateBankDetails.json";
            resourcePath.ReferenceDataMetadata = @"ReferenceDataService\V0\";
            resourcePath.ReferenceDataByKeyword = @"ReferenceDataService\V0\";
            resourcePath.ReferenceDataByValue = @"ReferenceDataService\V0\";
            resourcePath.ValidateBankDetails = @"ValidateBankDetails\V0\";
            resourcePath.Cache = @"CacheService\V0\";
            resourcePath.ReCall = @"QuoteService\Recall\V0\";
            resourcePath.PullCache = @"CacheService\V0\";
            resourcePath.SaveCardConsent = @"SaveCardConsentService\V0\";
            return resourcePath;
        }

    }



}

