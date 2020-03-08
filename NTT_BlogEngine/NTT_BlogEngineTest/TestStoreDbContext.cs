using NTT_BlogEngine.DAL;
using NTT_BlogEngine.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT_BlogEngineTest
{
    class TestStoreDbContext : ApplicationDbContext
    {
        public override int SaveChanges()
        {
            return 0;
        }
    }
}
