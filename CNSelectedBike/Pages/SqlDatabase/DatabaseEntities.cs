using System;
using System.Collections.Generic;
using System.Text;

namespace CNSBike.Pages.SqlDatabase
{
    public class CacheDb
    {
        public string Id { get; set; }
        public string CodeReference { get; set; }
        public string StoredInformation { get; set; }
        public string ExpiryOffset { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string DateExpiry { get; set; }
    }

    public class QuoteDb
    {
        public string Id { get; set; }
        public string SessionId { get; set; }
        public string WebReference { get; set; }
        public string QuoteResponse { get; set; }
        public string PurchaseDetail { get; set; }
        public string IsLock { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string QuoteRequest { get; set; }
    }
}
