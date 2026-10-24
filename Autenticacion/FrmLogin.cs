using pupus.FormulariosMenus;

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
            try
            {
                FrmPrincipal principal = new FrmPrincipal();
                principal.Show();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al abrir la pantalla: " + ex.Message);
            }
        }
    }
}
