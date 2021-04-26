using BL.Bases;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BL.AppServices
{
    public class ProductWishListAppService: AppServiceBase
    {

        public List<ProductWishListViewModel> GetAllProductWishList()
        {

            return Mapper.Map<List<ProductWishListViewModel>>(TheUnitOfWork.ProductWishList.GetAllProductWishList());
        }
        //public OrderViewModel GetOrder(int id)
        //{
        //    return Mapper.Map<OrderViewModel>(TheUnitOfWork.Order.GetOrderById(id));
        //}



        public bool SaveNewProductWishlist(ProductWishListViewModel productWishListViewModel)
        {
            bool result = false;
            var productWishList = Mapper.Map<ProductWishList>(productWishListViewModel);
            if (TheUnitOfWork.ProductWishList.Insert(productWishList))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteProductWishList(int id)
        {
            bool result = false;

            TheUnitOfWork.ProductWishList.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        //public bool UpdateOrder(OrderViewModel orderViewModel)
        //{
        //    var order = Mapper.Map<Order>(orderViewModel);
        //    TheUnitOfWork.Order.Update(order);
        //    TheUnitOfWork.Commit();

        //    return true;
        //}




        //public bool CheckOrderExists(OrderViewModel orderViewModel)
        //{
        //    Order order = Mapper.Map<Order>(orderViewModel);
        //    return TheUnitOfWork.Order.CheckOrderExists(order);
        //}
    }
}
