using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZenlessPolyCalc.Config;

namespace ZenlessPolyCalc
{
    public partial class frmWishlist : Form
    {
        WishlistItem WishListItem = new WishlistItem();
        ConfigManager configManager;
        frmMain main;
        public frmWishlist(ConfigManager ConfigManager, frmMain Main, WishlistItem? SavedItem = null)
        {
            configManager = ConfigManager;
            InitializeComponent();
            if (SavedItem != null)
            {
                WishListItem = SavedItem;
                LoadWishlistItem();
            }
            main = Main;
        }

        private void LoadWishlistItem()
        {
            txtName.Text = WishListItem.CharacterName;
            chkWeapon.Checked = WishListItem.IsWeapon;
            txtImageOverride.Text = WishListItem.ImageLocation;
            imgCharacterImage.ImageLocation = WishListItem.ImageLocation;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WishListItem.CharacterName = txtName.Text;
            WishListItem.ImageLocation = txtImageOverride.Text;
            WishListItem.IsWeapon = chkWeapon.Checked;
            //TO DO! Standard/discount banner et!
            configManager.AddWishlistItem(WishListItem);
            main.RefreshWishList();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            openImage.ShowDialog();
        }

        private void openImage_FileOk(object sender, CancelEventArgs e)
        {
            imgCharacterImage.ImageLocation = "";
            if (!string.IsNullOrWhiteSpace(openImage.FileName))
            {
                imgCharacterImage.ImageLocation = openImage.FileName;
                txtImageOverride.Text =openImage.FileName;
            }
        }
    }

}
