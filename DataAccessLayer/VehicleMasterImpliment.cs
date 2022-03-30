using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class VehicleMasterImpliment : IVehicleMasterRepository<VehicleMaster>
    {
        public bool DeleteVehicle(VehicleMaster vehicle)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var v = dbContext.VehicleMasters.Where(x => x.ModelNo==vehicle.ModelNo).FirstOrDefault();
                dbContext.VehicleMasters.Remove(v);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<VehicleMaster> GetAllVehicle()
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var v = dbContext.VehicleMasters.ToList();
                return v;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public VehicleMaster GetVehicle(int modeNo)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var v = dbContext.VehicleMasters.Where(x => x.ModelNo == modeNo).FirstOrDefault();
                return v;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveVehicle(VehicleMaster vehicle)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                dbContext.VehicleMasters.Add(vehicle);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateVehicle(VehicleMaster vehicle)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var v = dbContext.VehicleMasters.Where(x => x.ModelNo == vehicle.ModelNo).FirstOrDefault();
                v.ModelNo = vehicle.ModelNo;
                v.ModelName = vehicle.ModelName;
                v.ModelYear = vehicle.ModelYear;
                v.VehicleType = vehicle.VehicleType;
                v.ServiceSchedule = vehicle.ServiceSchedule;
                v.SoldDate = vehicle.SoldDate;
                v.CustId = vehicle.CustId;
                dbContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
