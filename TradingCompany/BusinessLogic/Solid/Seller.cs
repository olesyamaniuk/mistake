using BusinessLogic.Interfaces;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Solid
{
    public class Seller : ISeller
    {
        private readonly ISellerDAL _sellerDAL;



        public Seller(ISellerDAL sellerDAL)
        {
            _sellerDAL = sellerDAL;
        }

        public SellerDTO AddSeller(SellerDTO seller)
        {
            Console.WriteLine("Enter Full Name, Mail, Login, Password");
            seller = new SellerDTO
            {
                FullName = Console.ReadLine(),
                Mail = Console.ReadLine(),
                Login = Console.ReadLine(),
                Password = Convert.ToByte(Console.ReadLine())
            };



            return _sellerDAL.CreateSeller(seller);
        }


        

        public SellerDTO GetSellerById(int id)
        {
            return _sellerDAL.GetSellerById(id);
        }

        public void ShowSellers()
        {
            Console.WriteLine("All sellers:\n");
            Console.WriteLine("Id\tFullName\tLogin");
            foreach (var seller in _sellerDAL.GetSellers())
            {
                Console.WriteLine($"{seller.ID}\t{seller.FullName}\t{seller.Login}");

            }
        }

        

        public SellerDTO UpdateSeller(SellerDTO seller)
        {
            Console.WriteLine("Change seller inf0: \n");
            Console.WriteLine("FullName, Mail");
            seller = new SellerDTO
            {
                FullName = Console.ReadLine(),
                Mail = Console.ReadLine(),
              
            };


            return _sellerDAL.UpdateSeller(seller);
        }

        public SellerDTO GetSellerByName(string Name)
        {
            return _sellerDAL.GetSellerByName(Name);
        }
    }

}

