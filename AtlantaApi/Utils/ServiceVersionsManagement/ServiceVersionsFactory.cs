namespace AtlantaApi.Utils.ServiceVersionsManagement
{
    public class ServiceVersionsFactory
    {
        public ServiceVersionBase GetServiceByVersion(ServiceVersion version)
        {
            ServiceVersionBase serviceVersionBase = null;
            switch (version)
            {
                case ServiceVersion.V0:
                    serviceVersionBase = new ServiceVersion0();
                    break;
                case ServiceVersion.V1:
                    serviceVersionBase = new ServiceVersion1();
                    break;
                case ServiceVersion.V2:
                    serviceVersionBase = new ServiceVersion2();
                    break;
                case ServiceVersion.V3:
                    serviceVersionBase = new ServiceVersion3();
                    break;
            }
            return serviceVersionBase;
        }
    }
}
