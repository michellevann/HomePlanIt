using HomePlanIt.Data;
using HomePlanIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Services
{
    public class RoadblockService
    {
        private readonly Guid _ownerId;

        public RoadblockService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateRoadblock(RoadblockCreate model)
        {
            var entity = new Roadblock()
            {
                    OwnerId = _ownerId,
                    RoadblockName = model.RoadblockName,
                    IsComplete = model.IsComplete,
                    Plan = model.Plan,
                    DIY = model.DIY,
                    DIYId = model.DIYId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Roadblocks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RoadblockListItem> GetRoadblocks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Roadblocks
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                        e => new RoadblockListItem
                        {
                            RoadblockId = e.RoadblockId,
                            RoadblockName = e.RoadblockName,
                            IsComplete = e.IsComplete,
                            Plan = e.Plan,
                            DIY = e.DIY,
                            DIYId = e.DIYId
                        }
                        );
                return query.ToArray();
            }
        }

        public RoadblockDetail GetRoadblockById(int roadblockId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Roadblocks
                    .Single(e => e.RoadblockId == roadblockId && e.OwnerId == _ownerId);
                return new RoadblockDetail
                {
                    RoadblockId = entity.RoadblockId,
                    RoadblockName = entity.RoadblockName,
                    IsComplete = entity.IsComplete,
                    Plan = entity.Plan,
                    DIY = entity.DIY,
                    DIYId = entity.DIYId
                };
            }
        }

        public bool UpdateRoadblock(RoadblockEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Roadblocks
                    .Single(e => e.RoadblockId == model.RoadblockId && e.OwnerId == _ownerId);

                entity.RoadblockName = model.RoadblockName;
                entity.IsComplete = model.IsComplete;
                entity.Plan = model.Plan;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSupply(int roadblockId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Roadblocks
                    .Single(e => e.RoadblockId == roadblockId && e.OwnerId == _ownerId);
                ctx.Roadblocks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
