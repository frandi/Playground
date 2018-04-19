using PG.Common;
using PG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.BLL
{
    public interface ISiteService
    {
        Site GetById(int id);
        PagedList<Site> GetByName(string name, int pageIndex = 0, int pageSize = 20);
    }
}
