using App.Domain.Core.PostAgg.Contracts;
using App.Infrastructures.EfCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Repositories.PostAgg
{
    public class PostRepo(AppDbContext appDbContext) : IPostRepo
    {
    }
}
