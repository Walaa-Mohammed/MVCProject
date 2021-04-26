using BL.Bases;
using BL.ViewModels;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class CartAppService : AppServiceBase
    {
        #region CURD

        public List<CartViewModel> GetAllCarts()
        {

            return Mapper.Map<List<CartViewModel>>(TheUnitOfWork.Cart.GetAllCart());
        }
        public CartViewModel GetCart(int id)
        {
            return Mapper.Map<CartViewModel>(TheUnitOfWork.Cart.GetById(id));
        }



        public bool SaveNewCart(CartViewModel cartViewModel)
        {

            bool result = false;
            var cart = Mapper.Map<Cart>(cartViewModel);
            if (TheUnitOfWork.Cart.Insert(cart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        /*public bool UpdateCategory(OrderViewModel orderViewModel)
        {
            var category = Mapper.Map<Category>(orderViewModel);
            TheUnitOfWork.Category.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }*/


        public bool DeleteCart(int id)
        {
            bool result = false;

            TheUnitOfWork.Cart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        /*public bool CheckCategoryExists(OrderViewModel orderViewModel)
        {
            Category category = Mapper.Map<Category>(orderViewModel);
            return TheUnitOfWork.Category.CheckCategoryExists(category);
        }*/
        #endregion
    }
}
