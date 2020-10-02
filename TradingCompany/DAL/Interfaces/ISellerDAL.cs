using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISellerDAL
    {
        SellerDTO GetSellerById(int id);
        SellerDTO GetSellerByName(string name);
        List<SellerDTO> GetSellers();
        SellerDTO UpdateSeller(SellerDTO seller);
        SellerDTO CreateSeller(SellerDTO seller);
        void DeleteSeller(int id);
    }
}
