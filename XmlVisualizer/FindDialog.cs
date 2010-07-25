using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XmlViewer
{
    public delegate void FindHandler( string findWhat );
    public partial class FindDialog : Form
    {
        public event FindHandler Find;
        public string FindWhat = "";

        public FindDialog()
        {
            InitializeComponent();
            tbFindWhat.Text = FindWhat;
        }

        private void DoFind()
        {
            if( Find != null )
                Find( tbFindWhat.Text );
            Close();
        }

        private void btnFind_Click( object sender, EventArgs e )
        {
            DoFind();
        }

        private void tbFindWhat_KeyPress( object sender, KeyPressEventArgs e )
        {
            if( e.KeyChar == '\r' )
                DoFind();
        }
    }
}
