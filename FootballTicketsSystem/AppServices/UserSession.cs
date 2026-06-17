using FootballTicketsSystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTicketsSystem.AppServices
{
    public static class UserSession
    {
        public static Users CurrentUser { get; set; }
        public static bool HasSeenTomorrowNotification { get; set; } = false;
    }
}
