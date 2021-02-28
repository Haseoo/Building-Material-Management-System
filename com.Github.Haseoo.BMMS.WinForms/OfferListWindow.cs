using System.Windows.Forms;
using com.Github.Haseoo.BMMS.Data;

namespace com.Github.Haseoo.BMMS.WinForms
{
    public partial class OfferListWindow : Form
    {
        public OfferListWindow()
        {
            SessionManager.Instance.AcquireNewSession();
            InitializeComponent();
        }
    }
}
