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
    public class Goods : IGoodsDAL
    {
        private readonly IGoodsDAL _goodsDAL;


        public Goods(IGoodsDAL goodsDAL)
        {
            _goodsDAL = goodsDAL;
        }

        public GoodsDTO CreateGoods(GoodsDTO goods)
        {
            Console.WriteLine("GoodsName, GoodsPrice, GoodsDescription, GoodsAmount");
            goods = new GoodsDTO
            {
                GoodsName = Console.ReadLine(),
                GoodsPrice = Console.ReadLine(),
                GoodsDescription = Console.ReadLine(),
                GoodsAmount = Console.ReadLine()
            };



            return _goodsDAL.CreateGoods(goods);
        }

        public void DeleteGoods(int id)
        {
            Console.WriteLine("Enter ID to delete:");
            GoodsDTO goods = new GoodsDTO();
            goods.GoodsID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Deleting user ID: {goods.GoodsID}");
            _goodsDAL.DeleteGoods(goods.GoodsID);
        }

        public List<GoodsDTO> GetGoods()
        {
            Console.WriteLine("All Goods:\n");
            Console.WriteLine("GoodsID\tGoodsPrice\tGoodsAmount");
            foreach (var goods in _goodsDAL.GetGoods())
            {
                Console.WriteLine($"{goods.GoodsID}\t{goods.GoodsName}\t{goods.GoodsPrice}\t{goods.GoodsAmount}");

            }
            return _goodsDAL.GetGoods();
        }

        public List<GoodsDTO> SortedGoods(int n)
        {
            Console.WriteLine("Enter number to get items sorted \n 1:ID \n 2:Name \n 3:Price \n or show all");
            Console.WriteLine("Id\tName\tPrice\tPriceAmount");
            foreach (var goods in _goodsDAL.GetGoods())
            {
                Console.WriteLine($"{goods.GoodsID}\t{goods.GoodsName}\t{goods.GoodsPrice}\t{goods.GoodsAmount}");

            }
            return _goodsDAL.SortedGoods(n);
        }

        public GoodsDTO GetGoodsById(int id)
        {
            return _goodsDAL.GetGoodsById(id);
        }

        public GoodsDTO GetGoodsByName(string name)
        {
            return _goodsDAL.GetGoodsByName(name);
        }

        public GoodsDTO UpdateGoods(GoodsDTO goods)
        {
            Console.WriteLine("Change goods inf0: \n");
            Console.WriteLine("Full name,Mail");
            goods = new GoodsDTO
            {
                GoodsName = Console.ReadLine(),
                GoodsPrice = Console.ReadLine(),
                GoodsDescription = Console.ReadLine()
                
            };


            return _goodsDAL.UpdateGoods(goods);
        }
    }
}
