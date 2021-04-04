using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBManager
{
    public partial class ColinputFrm : Form
    {
        public ColinputFrm(string sTitle = "input")
        {
            sTITLE = sTitle;
            // ColName.Text = sTitle; // -> 초기화되지 않은 상태에서 값을 넣어주려 함
            InitializeComponent();
        }
        private void ColinputFrm_Load(object sender, EventArgs e)
        {
            ColName.Text = sTITLE;  // 로드될 때에 생성자 변수 초기화
        }

        public string sInput;
        string sTITLE;
        private void tbColName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                this.DialogResult = DialogResult.OK;
                sInput = tbColName.Text;
                Close();
            }

            else if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
