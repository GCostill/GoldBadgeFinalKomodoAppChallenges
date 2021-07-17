using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClass.POCO
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorList { get; set; } = new List<string>();

        public Badge()
        {

        }
        public Badge(List<string> DoorList)
        {
            this.DoorList = DoorList;
        }
    }
}
