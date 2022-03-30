using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IServiceRepInfoRepository<ServiceRepInfo>
    {
        IEnumerable<ServiceRepInfo> GetAllServiceRep();
        ServiceRepInfo GetServiceRepByServiceRepId(int ServiceRepid);   
        bool SaveServiceRep(ServiceRepInfo serviceRepInfo);
        bool DeleteServiceRep(ServiceRepInfo serviceRepInfo);
        bool UpdateServiceRep(ServiceRepInfo serviceRepInfo);
    }
}
