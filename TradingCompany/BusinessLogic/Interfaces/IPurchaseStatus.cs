using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPurchaseStatus
    {
        PurchaseStatusDTO AddStatus(PurchaseStatusDTO supplierStatus);
        PurchaseStatusDTO ChangeStatus(PurchaseStatusDTO supplierStatus);
        void ShowStatuses();
        void RemoveStatus(int ID);
        PurchaseStatusDTO GetStatuses(int ID);
    }
}
