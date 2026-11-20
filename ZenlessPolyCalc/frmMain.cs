using System.Drawing.Printing;
using System.Windows.Forms.VisualStyles;
using ZenlessPolyCalc.Config;

namespace ZenlessPolyCalc
{
    public partial class frmMain : Form
    {
        ConfigManager configManager = new ConfigManager();
        PolychromeManager polychromeManager;
        public frmMain()
        {
            polychromeManager = new PolychromeManager(configManager);
            InitializeComponent();
            SetMaxNumericValues();
            SetTooltips();

            Application.SetColorMode(SystemColorMode.Dark);
            LoadSavedSettings();
            RefreshWishList();
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
            ttCurrentCharacterPity.SetToolTip(lblCurrentCharacterPity, "The amount of pulls you've spent on the character banner since your last S rank");
            ttCurrentWeaponPity.SetToolTip(lblCurrentWeaponPity, "The amount of pulls you've spent on the weapon banner since your last S rank");
            ttWonLastCharacterRateUp.SetToolTip(chkWonCharacterRateUp, "Did you get the rate up character the last time you got an S rank on the character banner?");
            ttWonLastWeaponRateUp.SetToolTip(chkWonWeaponRateUp, "Did you get the rate up weapon the last time you got an S rank on the weapon banner?");
        }
        private void LoadSavedSettings()
        {
            configManager.LoadConfig();
            numCurrentPolys.Value = configManager.CurrentPolychromes;
            numCurrentTapes.Value = configManager.CurrentTapes;
            numRemainingEventPolys.Value = configManager.RemainingEventPolychromes;
            chkAssumeShiyuARank.Checked = configManager.AssumeShiyuARank;
            dtPatchEndDate.Value = configManager.PatchEndDate;
            numCurrentCharacterPity.Value = configManager.CurrentCharacterPity;
            numCurrentWeaponPity.Value = configManager.CurrentWeaponPity;
            chkWonWeaponRateUp.Checked = configManager.WonLastWeaponRateUp;
            chkWonCharacterRateUp.Checked = configManager.WonLastCharacterRateUp;
        }
        private void SaveSettings()
        {
            configManager.CurrentPolychromes = ((int)numCurrentPolys.Value);
            configManager.CurrentTapes = ((int)numCurrentTapes.Value);
            configManager.RemainingEventPolychromes = ((int)numRemainingEventPolys.Value);
            configManager.AssumeShiyuARank = chkAssumeShiyuARank.Checked;
            configManager.PatchEndDate = dtPatchEndDate.Value;
            configManager.CurrentCharacterPity = (int)numCurrentCharacterPity.Value;
            configManager.CurrentWeaponPity = (int)numCurrentWeaponPity.Value;
            configManager.WonLastCharacterRateUp = chkWonCharacterRateUp.Checked;
            configManager.WonLastWeaponRateUp = chkWonWeaponRateUp.Checked;
            configManager.SaveConfig();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnCalcFinalPolys_Click(object sender, EventArgs e)
        {
            SaveSettings(); //save any changes first
            PolychromeResultDTO results = polychromeManager.CalculateResults();
            lblFinalPolysResult.Text = results.TotalPolychromes.ToString();
            lblFinalPullsResult.Text = results.TotalPulls.ToString();
        }

        private void btnAddToWishlist_Click(object sender, EventArgs e)
        {
            OpenWishlistForm();
        }
        private void OpenWishlistForm(WishlistItem? editItem = null)
        {
            frmWishlist AddWishlist = new frmWishlist(configManager, this, editItem);
            AddWishlist.ShowDialog();
        }
        public void RefreshWishList()
        {
            lstWishlist.Items.Clear();
            foreach (var wishlistItem in configManager.WishlistItems)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Name = wishlistItem.ID;
                listViewItem.Text = wishlistItem.CharacterName;
                if (wishlistItem.IsWeapon)
                {
                    listViewItem.Text += "'s (WEAPON)";
                }
                //icon
                if (!string.IsNullOrWhiteSpace(wishlistItem.ImageLocation))
                {
                    if (lstWishlist.SmallImageList == null)
                    {
                        lstWishlist.SmallImageList = new ImageList();
                    }
                    lstWishlist.SmallImageList.Images.Add(wishlistItem.ID, Image.FromFile(wishlistItem.ImageLocation));
                    listViewItem.ImageKey = wishlistItem.ID;
                }
                //show how many pulls you need
                listViewItem.Text = $"{listViewItem.Text} | NEED {polychromeManager.PullsNeededForWishlistItem(wishlistItem)} PULLS";

                lstWishlist.Items.Add(listViewItem);
            }
        }

        private void lstWishlist_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedWishlistItem();
        }
        private void EditSelectedWishlistItem()
        {
            if (lstWishlist.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lstWishlist.SelectedItems[0]; //selection mode is single so can't have multiple selected
                WishlistItem? selectedWishlistItem = configManager.WishlistItems.SingleOrDefault(x => x.ID == selectedItem.Name);
                OpenWishlistForm(selectedWishlistItem);

            }
        }
        private void DeleteSelectedWishlistItem()
        {

            if (lstWishlist.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lstWishlist.SelectedItems[0]; //selection mode is single so can't have multiple selected
                WishlistItem? selectedWishlistItem = configManager.WishlistItems.SingleOrDefault(x => x.ID == selectedItem.Name);
                if (selectedWishlistItem != null)
                {
                    //confirmation!
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedWishlistItem.CharacterName}?", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        configManager.WishlistItems.Remove(configManager.WishlistItems.Where(x => x.ID == selectedWishlistItem.ID).SingleOrDefault());
                        configManager.SaveWishlistItems(configManager.WishlistItems);
                        RefreshWishList();
                    }
                }
            }
        }
        private void cmsWishlistItemRightClick_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem != null && lstWishlist.SelectedItems.Count > 0)
            {
                switch (e.ClickedItem.Name)
                {
                    case "contextEdit":
                        EditSelectedWishlistItem();
                        break;
                    case "contextDelete":
                        DeleteSelectedWishlistItem();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnRefreshWishlist_Click(object sender, EventArgs e)
        {
            SaveSettings();
            RefreshWishList();
        }
    }
}
