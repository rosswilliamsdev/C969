using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969.Appointments
{
    public partial class EditAppointmentForm : Form
    {
        public EditAppointmentForm()
        {
            InitializeComponent();
            dateDTP.Format = DateTimePickerFormat.Short;
            //set default date value to original appointment date
            startTimeDTP.Format = DateTimePickerFormat.Time;
            startTimeDTP.ShowUpDown = true;
            endTimeDTP.Format = DateTimePickerFormat.Time;
            endTimeDTP.ShowUpDown = true;
        }
    }
}
