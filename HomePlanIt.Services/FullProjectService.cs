using HomePlanIt.Data;
using HomePlanIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Services
{
    public class FullProjectService
    {
        private readonly Guid _userId;

        public FullProjectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFullProject(FullProjectCreate model)
        {
            var entity = new FullProject()
            {
                OwnerId = _userId,
                FullProjectId = model.FullProjectId,
                DIYId = model.DIYId,
                SupplyId = model.SupplyId,
                RoadblockId = model.RoadblockId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FullProjects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FullProjectListItem> GetFullProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .FullProjects
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new FullProjectListItem
                        {
                            FullProjectId = e.FullProjectId,
                            DIYId = e.DIYId,
                            SupplyId = e.SupplyId,
                            RoadblockId = e.RoadblockId
                        }
                        );
                return query.ToArray();
            }
        }

        public FullProjectDetail GetFullProjectById(int fullProjectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .FullProjects
                    .Single(e => e.FullProjectId == fullProjectId && e.OwnerId == _userId);
                return new FullProjectDetail
                {
                    FullProjectId = entity.FullProjectId,
                    DIYId = entity.DIYId,
                    ProjectName = entity.DIY.ProjectName,
                    StartDate = entity.DIY.StartDate,
                    EndDate = entity.DIY.EndDate,
                    BudgetedAmount = entity.DIY.BudgetedAmount,
                    FinalCost = entity.DIY.FinalCost,
                    SupplyId = entity.SupplyId,
                    Brand = entity.Supply.Brand,
                    Color = entity.Supply.Color,
                    Quantity = entity.Supply.Quantity,
                    SupplyName = entity.Supply.SupplyName,
                    TotalCost = entity.Supply.TotalCost,
                    RoadblockId = entity.RoadblockId,
                    Plan = entity.Roadblock.Plan
                };
            }
        }

        public bool DeleteFullProject(int fullProjectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .FullProjects
                    .Single(e => e.FullProjectId == fullProjectId && e.OwnerId == _userId);
                ctx.FullProjects.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
