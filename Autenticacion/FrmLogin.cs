using Pupuseria.Modulos;
using Pupuseria.Forms;



namespace pupus
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var principal = new FrmPrincipal();
            principal.FormClosed += (s, args) => Close();
            principal.Show();
            Hide();
        }
    }
}
