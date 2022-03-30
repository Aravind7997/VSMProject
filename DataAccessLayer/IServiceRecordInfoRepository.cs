using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IServiceRecordInfoRepository<ServiceRecordInfo>
    {
        IEnumerable<ServiceRecordInfo> GetAllServiceRecords();
        ServiceRecordInfo GetServiceRecordInfoByServiceRefNo(int servicerefno);
        bool DeleteServiceRecodes(ServiceRecordInfo serviceRecordInfo);
        bool UpdateServiceRecodes(ServiceRecordInfo serviceRecordInfo);
        bool SaveServiceRecodes(ServiceRecordInfo serviceRecordInfo);
    }
}
