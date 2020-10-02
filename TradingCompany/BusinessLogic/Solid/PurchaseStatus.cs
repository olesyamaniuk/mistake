using BusinessLogic.Interfaces;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Solid
{
    public class PurchaseStatus : IPurchaseStatus
    {
        private readonly IPurchaseStatusDAL _purchaseStatusDAL;



        public PurchaseStatus(IPurchaseStatusDAL purchaseStatusDAL)
        {
            _purchaseStatusDAL = purchaseStatusDAL;
        }

        public PurchaseStatusDTO AddStatus(PurchaseStatusDTO purchaseStatus)
        {
            Console.WriteLine("Enter Status Name,PurchaseStatus, Date and Time");
            purchaseStatus = new PurchaseStatusDTO
            {
                StatusName = Console.ReadLine(),
                PurchaseStatus = Convert.ToBoolean(Console.ReadLine()),
                DateTime = Convert.ToDateTime(Console.ReadLine())
            };



            return _purchaseStatusDAL.CreateStatus(purchaseStatus);
        }


        public void RemoveStatus(int ItemID)
        {
            Console.WriteLine("Enter ID to delete:");
            PurchaseStatusDTO purchaseStatus = new PurchaseStatusDTO();
            purchaseStatus.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting PurchaseStatus ID: {purchaseStatus.ID}");
            _purchaseStatusDAL.DeleteStatus(purchaseStatus.ID);
        }

        public PurchaseStatusDTO GetStatuses(int id)
        {
            return _purchaseStatusDAL.GetStatusById(id);
        }

        public void ShowStatuses()
        {
            Console.WriteLine("All PurchaseStatuses:\n");
            Console.WriteLine("Id\tName\tStatus");
            foreach (var purchaseStatus in _purchaseStatusDAL.GetStatuses())
            {
                Console.WriteLine($"{purchaseStatus.ID}\t{purchaseStatus.StatusName}\t{purchaseStatus.PurchaseStatus}");

            }
        }

        public PurchaseStatusDTO ChangeStatus(PurchaseStatusDTO purchaseStatus)
        {
            Console.WriteLine("Change PurchaseStatus inf0: \n");
            Console.WriteLine("ItemID, new Price, left OnStock");
            Console.WriteLine("Enter StatusName, PurchaseStatus, Date and Time");
            purchaseStatus = new PurchaseStatusDTO
            {
                StatusName = Console.ReadLine(),
                PurchaseStatus = Convert.ToBoolean(Console.ReadLine()),
                DateTime = Convert.ToDateTime(Console.ReadLine())
            };


            return _purchaseStatusDAL.UpdateStatuse(purchaseStatus);
        }

       
    }
}

