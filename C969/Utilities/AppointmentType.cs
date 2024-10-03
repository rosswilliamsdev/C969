using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    internal class AppointmentType
    {
        public static List<string> GetAppointmentTypes()
        {
            return new List<string> {"Consultation", "Meeting", "Personal", "Other" };
        }
    }
}
