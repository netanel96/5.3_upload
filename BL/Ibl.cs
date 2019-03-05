using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    interface Ibl
    {
    
        bool AddReport(Report report);
        bool RemoveReport(int id);
        bool UpdateReport(Report report);
        Report GetReportById(int id);

       bool AddDrop(Drop drop);
       bool RemoveDrop(int id);
       bool UpdateDrop(Drop Drop);
       Drop GetDropById(int id);
       void GetCoordinate(string address);//צריך לממש ולהחזיר LAT LOG
       void GetCoordinateFromExif(string imagePath);//צריך לממש ולהחזיר LAT LOG

    }

}
