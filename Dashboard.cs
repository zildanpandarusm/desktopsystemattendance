using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopAttendanceSystem
{
    public partial class Dashboard : Form
    {
        private DatabaseManager dbManager;
        public Dashboard()
        {
            InitializeComponent();
            SetButtonVisibility(Login.currentUserSession.UserRole);
            UIDesain();
            dbManager = new DatabaseManager();
        }

        private void UIDesain()
        {
            string userEmail = Login.currentUserSession.Email;
            int userRole = Login.currentUserSession.UserRole;

            textBox1.Text = userEmail;
            if (userRole == 1)
            { 
                textBox2.Text = "Admin";
            } else if(userRole == 2)
            {
                textBox2.Text = "Operator";
            } else if(userRole == 3)
            {
                textBox2.Text = "User";
            }
            
        }

       private void SetButtonVisibility(int userRole)
        {
            // Setel visibilitas tombol berdasarkan peran pengguna
            switch (userRole)
            {
                case 1: // Administrator
                    btnUsers.Visible = true;
                    btnAttendance.Visible = true;
                    btnEvent.Visible = true;
                    break;
                case 2: // Operator/Instructor
                    btnUsers.Enabled = false;
                    btnAttendance.Visible = true;
                    btnEvent.Visible = true;
                    break;
                case 3: // Participant
                    btnUsers.Enabled = false;
                    btnAttendance.Visible = true;
                    btnEvent.Enabled = false;
                    break;
                default:
                    // Setel nilai default sesuai kebutuhan
                    btnUsers.Visible = false;
                    btnAttendance.Visible = false;
                    btnEvent.Visible = false;
                    break;
            }
        }


        private void usersBtn(object sender, EventArgs e)
        {
            this.Hide();
            Users user = new Users();
            user.Show();
        }

        private void attendanceBtn(object sender, EventArgs e)
        {
            this.Hide();
            Attendance attend = new Attendance();
            attend.Show();
        }

        private void eventBtn(object sender, EventArgs e)
        {
            this.Hide();
            Event @event = new Event(); 
            @event.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login.currentUserSession.ClearSession();

            Login loginForm = new Login();
            loginForm.Show();

            this.Close();
        }

    }
}
