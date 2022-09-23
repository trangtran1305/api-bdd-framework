using System;
using System.Collections.Generic;
using System.Text;

namespace AtlantaApi.StepDefinition.QuoteService
{

        public class Quote
        {
            public string Id { get; set; }
            public Object SessionId { get; set; }
            public string WebReference { get; set; }
            public string QuoteResponse { get; set; }
            public string PurchaseDetail { get; set; }
            public string IsLock { get; set; }
            public string DateCreated { get; set; }
            public string DateUpdated { get; set; }
            public string QuoteRequest { get; set; }
        }
}
