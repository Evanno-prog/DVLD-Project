using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WinForm_PresentationLayer
{
    public partial class PersonInfoScreen : Form
    {
        private int _PersonID = 0;
        public PersonInfoScreen(int personID)
        {
            InitializeComponent();
            _PersonID = personID;   
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonInfoScreen_Load(object sender, EventArgs e)
        {
            ctrlPersonInformation1.LoadPersonInfoData(_PersonID);
        }
    }
}
