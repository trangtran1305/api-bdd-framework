using System;

namespace AtlantaApi.Utils.ServiceVersionsManagement
{
    public abstract class ServiceVersionBase
    {          
        public Tuple<ServiceEndpointName, ResourcePath> GetInformationByVersion()
        {
            return new Tuple<ServiceEndpointName, ResourcePath>(SetEndpoint(), SetResource());
        }
        public abstract ServiceEndpointName SetEndpoint();
        public abstract ResourcePath SetResource();
    }
}
