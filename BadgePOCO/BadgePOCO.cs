using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeClass.POCO
{
    public class BadgePOCO
    {
        public int BadgeID { get; set; }
        public List<string> DoorList { get; set; } = new List<string>();

        public BadgePOCO()
        {

        }
        public BadgePOCO(int badgeID, List<string> DoorList)
        {
            this.BadgeID = badgeID;
            this.DoorList = DoorList;
        }
    }
}
