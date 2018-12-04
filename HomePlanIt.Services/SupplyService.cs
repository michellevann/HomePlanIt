using HomePlanIt.Data;
using HomePlanIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Services
{
    public class SupplyService
    {
        private readonly Guid _ownerId;

        public SupplyService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateSupply(SupplyCreate model)
        {
            var entity = new Supply()
            {
                OwnerId = _ownerId,
                //DIYId = model.DIYId,
                Brand = model.Brand,
                Color = model.Color,
                Quantity = model.Quantity,
                SupplyName = model.SupplyName,
                TotalCost = model.TotalCost,
                AlreadyHave = model.AlreadyHave
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProjectDetail> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Items
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                        e =>
                        new ProjectDetail
                        {
                            SupplyId = e.SupplyId,
                            //DIYId = e.DIYId,
                            SupplyName = e.SupplyName,
                            Brand = e.Brand,
                            Color = e.Color,
                            Quantity = e.Quantity,
                            TotalCost = e.TotalCost,
                            AlreadyHave = e.AlreadyHave
                        }
                     );
                return query.ToArray();
            }
        }

        public ProjectDetail GetItemById(int supplyId)
        {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx
                        .Items
                        .Single(e => e.SupplyId == supplyId && e.OwnerId == _ownerId);
                    return
                        new ProjectDetail
                        {
                            SupplyId = entity.SupplyId,
                            SupplyName = entity.SupplyName,
                            //DIYId = entity.DIYId,
                            Brand = entity.Brand,
                            Color = entity.Color,
                            Quantity = entity.Quantity,
                            TotalCost = entity.TotalCost,
                            AlreadyHave = entity.AlreadyHave
                        };
                }
        }

        public bool UpdateSupply(SupplyEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Items
                    .Single(e => e.SupplyId == model.SupplyId && e.OwnerId == _ownerId);

                entity.SupplyName = model.SupplyName;
                entity.Brand = model.Brand;
                entity.Color = model.Color;
                entity.Quantity = model.Quantity;
                entity.TotalCost = model.TotalCost;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSupply(int supplyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Items
                    .Single(e => e.SupplyId == supplyId && e.OwnerId == _ownerId);
                ctx.Items.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
