using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CigarShop.DataAccess.Entities
{
    public partial class CigarShopDbContext : DbContext
    {
        public CigarShopDbContext()
        {
        }

        public CigarShopDbContext(DbContextOptions<CigarShopDbContext> options)
            : base(options)
        {
        }

    }
}
