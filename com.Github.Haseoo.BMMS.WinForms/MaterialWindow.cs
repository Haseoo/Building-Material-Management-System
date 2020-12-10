using com.Github.Haseoo.BMMS.Business.DTOs;
using System.Windows.Forms;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class MaterialWindow : Form
    {
        public MaterialWindow(MaterialDto materialDto=null)
        {
            this.Text = (materialDto != null) ? $"Edit {materialDto.Name}" : "Add new material";
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
