using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969
{
    internal class ComboBoxItem
    {
        public string Text { get; set; } //the customer name
        public int CustomerId { get; set; }


        public ComboBoxItem(string text, int customerId)
        {
            Text = text;
            CustomerId = customerId;
        }

        public override string ToString()
        {
            return Text; //customer name
        }
    }
}
