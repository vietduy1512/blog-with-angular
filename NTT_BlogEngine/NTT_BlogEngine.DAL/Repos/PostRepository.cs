using NTT_BlogEngine.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT_BlogEngine.DAL.Data
{
    public class PostRepository : EntityRepository, IPostRepository
    {
        public PostRepository(IDbContext context) : base(context)
        {
        }

    }
}
