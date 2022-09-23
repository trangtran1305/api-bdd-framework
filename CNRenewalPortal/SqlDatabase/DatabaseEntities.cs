using System;
using System.Collections.Generic;
using System.Text;

namespace CNRenewalPortal.Pages.SqlDatabase
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
}
