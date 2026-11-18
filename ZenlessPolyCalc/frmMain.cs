using System.Drawing.Printing;
using System.Windows.Forms.VisualStyles;

namespace ZenlessPolyCalc
{
    public partial class frmMain : Form
    {
        ConfigManager configManager = new ConfigManager();
        PolychromeManager polychromeManager = new PolychromeManager();
        public frmMain()
        {
            InitializeComponent();
            SetMaxNumericValues();
            SetTooltips();

            Application.SetColorMode(SystemColorMode.Dark);
            LoadSavedSettings();
        }
        private void SetMaxNumericValues()
        {
            numCurrentPolys.Maximum = Int32.MaxValue;
            numCurrentTapes.Maximum = Int32.MaxValue;
            numRemainingEventPolys.Maximum = Int32.MaxValue;
        }

        private void SetTooltips()
        {
            ttEventPolys.SetToolTip(lblRemainingEventPolys, "The remaining possible polychromes listed on the events page");
            ttAssumeShiyuARank.SetToolTip(lblAssumeShiyuARank, "Assume you will always get a max of A rank on Shiyu Defence (so will get 80 less polychromes per Shiyu cycle)");
            ttCurrentTapes.SetToolTip(lblCurrentTapes, "The amount of actual tapes you already have. Not the amount you can buy! But just what you currently have!");
        }
        private void LoadSavedSettings()
        {
            configManager.LoadConfig();
            numCurrentPolys.Value = configManager.CurrentPolychromes;
            numCurrentTapes.Value = configManager.CurrentTapes;
            numRemainingEventPolys.Value = configManager.RemainingEventPolychromes;
            chkAssumeShiyuARank.Checked = configManager.AssumeShiyuARank;
            dtPatchEndDate.Value = configManager.PatchEndDate;
        }
        private void SaveSettings()
        {
            configManager.CurrentPolychromes = ((int)numCurrentPolys.Value);
            configManager.CurrentTapes = ((int)numCurrentTapes.Value);
            configManager.RemainingEventPolychromes = ((int)numRemainingEventPolys.Value);
            configManager.AssumeShiyuARank = chkAssumeShiyuARank.Checked;
            configManager.PatchEndDate = dtPatchEndDate.Value;
            configManager.SaveConfig();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnCalcFinalPolys_Click(object sender, EventArgs e)
        {
            SaveSettings(); //save any changes first
            PolychromeResultDTO results = polychromeManager.CalculateResults(configManager);
            lblFinalPolysResult.Text = results.TotalPolychromes.ToString();
            lblFinalPullsResult.Text = results.TotalPulls.ToString();
        }
    }
}
