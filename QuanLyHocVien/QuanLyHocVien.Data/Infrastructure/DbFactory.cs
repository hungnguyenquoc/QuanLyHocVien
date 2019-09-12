using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private QuanLyHocVienDbContext dbContext;

        public QuanLyHocVienDbContext Init()
        {
            return dbContext ?? (dbContext = new QuanLyHocVienDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
