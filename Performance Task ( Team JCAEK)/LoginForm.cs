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
            try
            {
                // Basic input validation
                string username = textBox1.Text?.Trim();
                string password = textBox2.Text ?? string.Empty;
                // checks if textbox empty
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Input required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AuthManager auth = new AuthManager("users.txt");

                bool isAuthenticated = auth.AuthenticateUser(username, password);
                // wrong user or pass
                if (!isAuthenticated)
                {
                    MessageBox.Show("Invalid username or password.", "Authentication failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show main form
                this.Hide();
                using (var Form = new MainForm())
                {
                    Form.ShowDialog();
                }
                this.Show();

            }
            catch (Exception ex)
            {
                // Simple top-level exception handler to prevent app crash and inform the user
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                //set password mask if designer hasn't
                if (textBox2 != null && textBox2.PasswordChar == '\0')
                {
                    textBox2.PasswordChar = '•';
                }
            }
            catch (Exception)
            {
                //Swallow minor UI errors on load; avoid crashing the app
            }
        }
    }
}
