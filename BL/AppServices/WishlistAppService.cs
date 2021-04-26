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
    public class WishlistAppService : AppServiceBase
    {
        #region CURD

        public List<WishlistViewModel> GetAllWishlists()
        {
            return Mapper.Map<List<WishlistViewModel>>(TheUnitOfWork.Wishlist.GetAllWishlist());
        }
        public WishlistViewModel GetWishlist(int id)
        {
            return Mapper.Map<WishlistViewModel>(TheUnitOfWork.Wishlist.GetById(id));
        }



        public bool SaveNewWishlist(WishlistViewModel wishlistViewModel)
        {

            bool result = false;
            var wishlist = Mapper.Map<Wishlist>(wishlistViewModel);
            if (TheUnitOfWork.Wishlist.Insert(wishlist))
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


        public bool DeleteWishlist(int id)
        {
            bool result = false;

            TheUnitOfWork.Wishlist.Delete(id);
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
