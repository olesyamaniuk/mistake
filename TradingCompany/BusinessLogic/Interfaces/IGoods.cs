using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IGoods
    {
        GoodsDTO GetGoodsById(int ID);
        GoodsDTO GetGoodsByName(string Name);
        GoodsDTO CreateGoods(GoodsDTO goods);
        GoodsDTO UpdateGoods(GoodsDTO goods);
        void SortedGoods(int n);
 
    }
}
