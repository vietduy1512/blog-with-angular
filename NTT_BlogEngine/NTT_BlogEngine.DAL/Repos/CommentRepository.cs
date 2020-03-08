using NTT_BlogEngine.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT_BlogEngine.DAL.Data
{
    public class CommentRepository : EntityRepository, ICommentRepository
    {
        public CommentRepository(IDbContext context) : base(context)
        {
        }
    }
}
