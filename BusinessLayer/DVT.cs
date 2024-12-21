using DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class DVT
    {
        Entities db;

        // constructor
        public DVT()
        {
            db = Entities.CreateEntities();
        }

        public List<DONVITINH> GetList()
        {
            return db.DONVITINHs.ToList();
        }
    }
}
