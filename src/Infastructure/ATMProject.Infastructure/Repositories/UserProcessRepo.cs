using ATMProject.Domain.Entities;
using ATMProject.Domain.Repositories;
using ATMProject.Infastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Infastructure.Repositories
{
    public class UserProcessRepo : BaseRepo<UserProcess>, IUserProcessRepo
    {
        public UserProcessRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
