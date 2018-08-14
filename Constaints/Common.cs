using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanVeXe_Web.Constaints
{
    public class Common
    {
        # region Ticket

        public const string SESSIONSUMMARY_NAME = "SummaryBooking";
        public const decimal TAX = 200000;
        public const decimal FEE = 2000000;
        #endregion Ticket

        #region Plane
        public const int CHAIR_ROWS = 10;
        public const int CHAIR_COLS = 6;
        #endregion Plane
    }
}
