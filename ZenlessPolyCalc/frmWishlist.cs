using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
            else
            {
                LoadDefaults();
            }
            main = Main;
            ttBannerType.SetToolTip(lblBannerType, "Discount banners are rare, where you get the first 10 pulls for the cost of 8 and you are guarranteed to get what you want when you hit hard pity (90 for characters, 80 for weapons)");
        }

        private void LoadDefaults()
        {
            chkNormalBanner.Checked = true;
        }

        private void LoadWishlistItem()
        {
            txtName.Text = WishListItem.CharacterName;
            chkWeapon.Checked = WishListItem.IsWeapon;
            txtImageOverride.Text = WishListItem.ImageLocation;
            imgCharacterImage.ImageLocation = WishListItem.ImageLocation;
            //note, can't be both
            chkNormalBanner.Checked = WishListItem.NormalBanner;
            chkDiscountBanner.Checked = WishListItem.DiscountBanner;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool validationPassed = true;
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name is required");
                validationPassed = false;
            }
            if (!chkNormalBanner.Checked && !chkDiscountBanner.Checked)//if both are unchecked somehow
            {
                MessageBox.Show("Banner type is required");
                validationPassed = false;
            }

            if (validationPassed)
            {
                WishListItem.CharacterName = txtName.Text;
                WishListItem.ImageLocation = txtImageOverride.Text;
                WishListItem.IsWeapon = chkWeapon.Checked;
                WishListItem.NormalBanner = chkNormalBanner.Checked;
                WishListItem.DiscountBanner = chkDiscountBanner.Checked;
                configManager.AddWishlistItem(WishListItem);
                main.RefreshWishList();
                this.Close();
            }
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
                txtImageOverride.Text = openImage.FileName;
            }
        }

        private void chkNormalBanner_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNormalBanner.Checked)
            {
                chkDiscountBanner.Checked = false;
            }
        }

        private void chkDiscountBanner_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscountBanner.Checked)
            {
                chkNormalBanner.Checked = false;
            }
        }
    }

}
