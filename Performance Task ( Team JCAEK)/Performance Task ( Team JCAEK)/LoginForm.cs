using System;
using System.Windows.Forms;

namespace Performance_Task___Team_JCAEK_
{
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // insert Stream here for username/password.txt



            /*
             
            if (Username == valid && Password == valid) {
            initialize main form
            } else {
            try catch wrong username/password
            }
             
             */
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }
    }
}
