using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer.People
{
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }

        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);
        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFindPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack?.Invoke(this, ctrlPersonCardWithFilter1.PersonID);
        }
    }
}
