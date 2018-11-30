using HomePlanIt.Data;
using HomePlanIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePlanIt.Services
{
    public class DIYService
    {
        private readonly Guid _userId;

        public DIYService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDIY(DIYCreate model)
        {
            var entity =
                new DIY()
                {
                    OwnerId = _userId,
                    ProjectName = model.ProjectName,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    BudgetedAmount = model.BudgetedAmount,
                    FinalCost = model.FinalCost
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.DIYs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DIYListItem> GetDIYs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .DIYs
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new DIYListItem
                                {
                                    ProjectName = e.ProjectName,
                                    StartDate = e.StartDate,
                                    EndDate = e.EndDate,
                                    BudgetedAmount = e.BudgetedAmount,
                                    FinalCost = e.FinalCost
                                }
                        );
                return query.ToArray();
            }
        }
        public SupplyListItem GetDIYById(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DIYs
                        .Single(e => e.ProjectId == projectId && e.OwnerId == _userId);
                return
                    new SupplyListItem
                    {
                        ProjectId = entity.ProjectId,
                        ProjectName = entity.ProjectName,
                        StartDate = entity.StartDate,
                        EndDate = entity.EndDate,
                        BudgetedAmount = entity.BudgetedAmount,
                        FinalCost = entity.FinalCost
                    };
            }
        }
        public bool UpdateDIY (DIYEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DIYs
                        .Single(e => e.ProjectId == model.ProjectId && e.OwnerId == _userId);

                entity.ProjectName = model.ProjectName;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.BudgetedAmount = model.BudgetedAmount;
                entity.FinalCost = model.FinalCost;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteDIY(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .DIYs
                        .Single(e => e.ProjectId == projectId && e.OwnerId == _userId);

                ctx.DIYs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    
    }
}
