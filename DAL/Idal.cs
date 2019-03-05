using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface Idal
    {

        bool AddReport(Report report);
        bool RemoveReport(int id);
        bool UpdateReport(Report report);

        bool AddDrop(Drop drop);
        bool RemoveDrop(int id);
        bool UpdateDrop(Drop drop);

        IEnumerable<Report> getReportList(Func<Report, bool> predicate = null);
        IEnumerable<Drop> getDropList(Func<Drop, bool> predicate = null);

        Drop GetDrop(int id);
        Report GetReport(int id);

    }
}
