using BL.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModels;
using DAL.Models;

namespace BL.AppServices
{
     public class ProductCartAppService: AppServiceBase
    {
        public List<ProductCartViewModel> GetAllProductCart()
        {

            return Mapper.Map<List<ProductCartViewModel>>(TheUnitOfWork.ProductCart.GetAllProductCart());
        }
        //public OrderViewModel GetOrder(int id)
        //{
        //    return Mapper.Map<OrderViewModel>(TheUnitOfWork.Order.GetOrderById(id));
        //}



        public bool SaveNewProductCart(ProductCartViewModel productCartViewModel)
        {
            bool result = false;
            var productCart = Mapper.Map<ProductCart>(productCartViewModel);
            if (TheUnitOfWork.ProductCart.Insert(productCart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteProductCart(int id)
        {
            bool result = false;

            TheUnitOfWork.ProductCart.Delete(id);
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


        //public bool DeleteOrder(int id)
        //{
        //    bool result = false;

        //    TheUnitOfWork.Order.Delete(id);
        //    result = TheUnitOfWork.Commit() > new int();

        //    return result;
        //}

        //public bool CheckOrderExists(OrderViewModel orderViewModel)
        //{
        //    Order order = Mapper.Map<Order>(orderViewModel);
        //    return TheUnitOfWork.Order.CheckOrderExists(order);
        //}
    }
}
