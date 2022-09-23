
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCore.ApiCore.Common;
using ProjectCore.SQL;
using SqlKata;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AtlantaApi.StepDefinition.QuoteService
{
    public class PrePurchaseHelper
    {
        public object GetPurchaseDetailPropValue(object purchaseObj, string propertyName)
        {
            return purchaseObj.GetType().GetProperty(propertyName).GetValue(purchaseObj, null);
        }
    }

    public class PrepurchaseResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }

        [JsonProperty(Required = Required.Default)]
        public bool ResultObj { get; set; }
    }

    public class PrepurchaseResponse1
    {
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }

        [JsonProperty(Required = Required.Default)]
        public JObject ResultObj { get; set; }
    }

    public class PurchaseDetailsFromDb
    {
        public Debit Debit { get; set; }
        public MarketingInfo MarketingInfo { get; set; }
        public ExtraInfo ExtraInfo { get; set; }
    }

    public class Debit
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
        public string Card { get; set; }
        public string SessionId { get; set; }
    }

    public class MarketingInfo
    {
        public bool AgreementConfirmation { get; set; }
        public string PreferredDeliveryMethod { get; set; }
        public string RegNumber { get; set; }
        public string PaymentMethodType { get; set; }
        public string MarkTel { get; set; }
        public string MarkSms { get; set; }
        public string MarkEm { get; set; }
        public string MarkP { get; set; }
        public string SessionId { get; set; }
    }

    public class ExtraInfo
    {
        public int NcbYears { get; set; }
        public int NumOfOtherVehicles { get; set; }
        public string AccessToOtherVehicles { get; set; }

        [JsonProperty(Required = Required.Default)]
        public Duq429 Duq429 { get; set; }

        [JsonProperty(Required = Required.Default)]
        public Duq430 Duq430 { get; set; }

        public string AgreementHolderDOB { get; set; }
        public string AgreementInceptionDate { get; set; }
        public AddressOfPerson AddressOfPerson { get; set; }
    }

    public class AddressOfPerson
    {
        public string PostCode { get; set; }
        public string HouseNameOrNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
    }

    public class Duq430
    {
        public string Response { get; set; }
        public string ShortResponse { get; set; }
    }

    public class Duq429
    {
        public string Response { get; set; }
        public string ShortResponse { get; set; }
    }
}