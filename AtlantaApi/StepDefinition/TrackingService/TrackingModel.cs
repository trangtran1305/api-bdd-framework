using System;
using System.Collections.Generic;
using System.Text;

namespace AtlantaApi.StepDefinition.TrackingService
{
    public class TrackingModel
    {
        public Guid Id { get; set; }
        public Guid? InternalId { get; set; }
        public string WebReference { get; set; }
        public string PolicyType { get; set; }
        public string AffinityCode { get; set; }
        public string CompanyCode { get; set; }
        public string RequestType { get; set; }
        public string RequestXML { get; set; }
        public string ResponseXML { get; set; }
        public string TrackingOrder { get; set; }
        public bool IsError { get; set; }
        public long ElapsedTime { get; set; }
        public DateTime DateCreated { get; set; }
        public bool EmailSent { get; set; }
        public byte[] RowVers { get; set; }
    }
}
