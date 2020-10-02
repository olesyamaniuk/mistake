using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPurchaseStatusDAL
    {
        PurchaseStatusDTO GetStatusById(int id);
        List<PurchaseStatusDTO> GetStatuses();
        PurchaseStatusDTO UpdateStatuse(PurchaseStatusDTO purchaseStatus);
        PurchaseStatusDTO CreateStatus(PurchaseStatusDTO purchaseStatus);
        void DeleteStatus(int id);
    }
}
