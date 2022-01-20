using IQTestLibrary;

namespace IQTestFormsApp
{
    public partial class UserInfoForm : Form
    {
        private User user;
        public UserInfoForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                MessageBox.Show("Введите свое имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user.Name = NameTextBox.Text;
            Close();
        }
    }
}
