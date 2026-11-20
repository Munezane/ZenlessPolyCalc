using System.Drawing.Printing;
using System.Windows.Forms.VisualStyles;
using ZenlessPolyCalc.Config;

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
                //TO DO! HANDLE REST
                if (!string.IsNullOrWhiteSpace(wishlistItem.ImageLocation))
                {
                    if (lstWishlist.LargeImageList == null)
                    {
                        lstWishlist.LargeImageList = new ImageList();
                    }
                    if (lstWishlist.SmallImageList == null)
                    {
                        lstWishlist.SmallImageList = new ImageList();
                    }
                    lstWishlist.LargeImageList.Images.Add(wishlistItem.ID, Image.FromFile(wishlistItem.ImageLocation));
                    lstWishlist.SmallImageList.Images.Add(wishlistItem.ID, Image.FromFile(wishlistItem.ImageLocation));
                    listViewItem.ImageKey = wishlistItem.ID;
                }
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
                        configManager.WishlistItems.Remove(configManager.WishlistItems.Where(x=> x.ID == selectedWishlistItem.ID).SingleOrDefault());
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
    }
}
