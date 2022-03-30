using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ServiceRepInfoImpliment : IServiceRepInfoRepository<ServiceRepInfo>
    {
        public bool DeleteServiceRep(ServiceRepInfo serviceRepInfo)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var serviceRep = dbContext.ServiceRepInfoes.Where(x => x.ServiceRepId == serviceRepInfo.ServiceRepId).FirstOrDefault();
                dbContext.ServiceRepInfoes.Remove(serviceRep);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<ServiceRepInfo> GetAllServiceRep()
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var serviceRep = dbContext.ServiceRepInfoes.ToList();
                return serviceRep;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ServiceRepInfo GetServiceRepByServiceRepId(int ServiceRepid)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var serviceRep = dbContext.ServiceRepInfoes.Where(x => x.ServiceRepId ==ServiceRepid).FirstOrDefault();
                return serviceRep;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveServiceRep(ServiceRepInfo serviceRepInfo)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                dbContext.ServiceRepInfoes.Add(serviceRepInfo);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateServiceRep(ServiceRepInfo serviceRepInfo)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var serviceRep = dbContext.ServiceRepInfoes.Where(x => x.ServiceRepId == serviceRepInfo.ServiceRepId).FirstOrDefault();
                serviceRep.ServiceRepId = serviceRepInfo.ServiceRepId;
                serviceRep.FirstName= serviceRepInfo.FirstName;
                serviceRep.LastName= serviceRepInfo.LastName;
                serviceRep.ConatactNo= serviceRepInfo.ConatactNo;
                dbContext.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
