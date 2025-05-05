using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quasar.Server.Extensions
{
    class ListViewItemComparer : IComparer
    {
        private int col;
        private int code;

        public ListViewItemComparer(int nCol, int nCode)
        {
            col = nCol;
            code = nCode;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;

            if (int.TryParse(((ListViewItem)x).SubItems[col].Text, out returnVal) && int.TryParse(((ListViewItem)y).SubItems[col].Text, out returnVal))
            {
                returnVal = int.Parse(((ListViewItem)x).SubItems[col].Text) > int.Parse(((ListViewItem)y).SubItems[col].Text) ? 1 : -1;
            }
            else
            {
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            }

            returnVal *= code;

            return returnVal;
        }
    }

}
