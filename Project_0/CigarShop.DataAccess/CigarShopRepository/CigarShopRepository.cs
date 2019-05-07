using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CigarShop.Library.Interfaces;
using CigarShop.DataAccess.Entities;
using NLog;
using Microsoft.EntityFrameworkCore;

namespace CigarShop.DataAccess.CigarShopRepository
{
    public class CigarShopRepository //: ICigarShop
    {
        private readonly Project0Context _dbContext;

        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public CigarShopRepository(Project0Context dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<Library.Models.Cigar> GetCigars(string search = null)
        {
            IQueryable<Cigar> items = _dbContext.Cigar.Include(m => m.ManufacturerId).AsNoTracking();
            if (search != null)
            {
                items = items.Where(m => m.Name.Contains(search));
            }
            return Mapper.Map(items);
        }

        public Library.Models.Cigar GetCigarById(int cigarId) => Mapper.Map(_dbContext.Cigar.Find(cigarId));

        public void Save()
        {
            _dbContext.SaveChanges();

        }
        #region Idisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
