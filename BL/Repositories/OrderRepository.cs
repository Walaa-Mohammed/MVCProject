using BL.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using DAL.Models;

namespace BL.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        private DbContext EC_DbContext;

        public OrderRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<Order> GetAllOrder()
        {
            return GetAll().Include(order=>order.appUser).ToList();
        }

        public bool InsertOrder(Order order)
        {
            return Insert(order);
        }
        public void UpdateOrder(Order order)
        {
            Update(order);
        }
        public void DeleteOrder(int id)
        {
            Delete(id);
        }

        public bool CheckOrderExists(Order order)
        {
            return GetAny(l => l.Id == order.Id);
        }
        public Order GetOrderById(int id)
        {
            return GetFirstOrDefault(l => l.Id == id);
        }
        #endregion
    }
}
