using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ServiceRecordInfoImpliment : IServiceRecordInfoRepository<ServiceRecordInfo>
    {
        public bool DeleteServiceRecodes(ServiceRecordInfo serviceRecordInfo)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var service = dbContext.ServiceRecordInfoes.Where(x => x.ServiceRefNo == serviceRecordInfo.ServiceRefNo).FirstOrDefault();
                dbContext.ServiceRecordInfoes.Remove(service);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<ServiceRecordInfo> GetAllServiceRecords()
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var servicesRecord = dbContext.ServiceRecordInfoes.ToList();
                return servicesRecord;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ServiceRecordInfo GetServiceRecordInfoByServiceRefNo(int servicerefno)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var serviceRecord = dbContext.ServiceRecordInfoes.Where(x => x.ServiceRefNo == servicerefno).FirstOrDefault();
                return serviceRecord;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool SaveServiceRecodes(ServiceRecordInfo serviceRecordInfo)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                dbContext.ServiceRecordInfoes.Add(serviceRecordInfo);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateServiceRecodes(ServiceRecordInfo serviceRecordInfo)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var service = dbContext.ServiceRecordInfoes.Where(x => x.ServiceRefNo == serviceRecordInfo.ServiceRefNo).FirstOrDefault();
                service.ServiceRefNo = serviceRecordInfo.ServiceRefNo;
                service.CustId = serviceRecordInfo.CustId;
                service.ModelNo= serviceRecordInfo.ModelNo;
                service.ServiceDate = serviceRecordInfo.ServiceDate;
                service.NextServiceDate= serviceRecordInfo.NextServiceDate;
                service.ServiceRepId= serviceRecordInfo.ServiceRepId;
                dbContext.SaveChanges();
                return true;

            }catch (Exception ex)
            { return false;}
        }
    }
}
