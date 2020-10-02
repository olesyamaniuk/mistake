using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISeller
    {
        SellerDTO AddSeller(SellerDTO user);
        SellerDTO UpdateSeller(SellerDTO user);
        void ShowSellers();
        SellerDTO GetSellerById(int ID);
        SellerDTO GetSellerByName(string Name);
    }
}
