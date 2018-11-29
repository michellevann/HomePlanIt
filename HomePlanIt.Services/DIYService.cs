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
    }
}
