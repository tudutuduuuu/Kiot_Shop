using DataLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class SYS_FUNC
    {
        Entities db;

        // constructor
        public SYS_FUNC()
        {
            db = Entities.CreateEntities();
        }

        public List<DataLayer.SYS_FUNC> GetParent()
        {
            return db.SYS_FUNC.Where(x => x.ISGROUP == true && x.MENU == true).OrderBy(x => x.SORT).ToList();
        }

        public List<DataLayer.SYS_FUNC> GetChild(string parent)
        {
            return db.SYS_FUNC.Where(x => x.ISGROUP == true && x.MENU == true && x.PARENT == parent).OrderBy(x => x.SORT).ToList();
        }
    }
}
