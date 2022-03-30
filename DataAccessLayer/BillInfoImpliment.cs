using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BillInfoImpliment : IBillInfoRepository<BillInfo>
    {
        public bool DeleteBill(BillInfo bill)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var b = dbContext.BillInfoes.Where(x => x.Id == bill.Id).FirstOrDefault();
                dbContext.BillInfoes.Remove(b);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<BillInfo> GetAllBill()
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var b = dbContext.BillInfoes.ToList();
                return b;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public BillInfo GetBillById(int Billid)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var b = dbContext.BillInfoes.Where(x => x.Id == Billid).FirstOrDefault();
                return b;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveBill(BillInfo bill)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                dbContext.BillInfoes.Add(bill);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateBill(BillInfo bill)
        {
            try
            {
                VSMSEntities dbContext = new VSMSEntities();
                var b = dbContext.BillInfoes.Where(x => x.Id == bill.Id).FirstOrDefault();
                b.Id=bill.Id;
                b.ServiceRefNo = bill.ServiceRefNo;
                b.ItemId = bill.ItemId;
                b.Price = bill.Price;
                b.Qty = bill.Qty;
                b.ItemAmount= bill.ItemAmount;
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
