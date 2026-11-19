namespace ZenlessPolyCalc
{
    partial class frmWishlist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            lblWeapon = new Label();
            lblImage = new Label();
            imgCharacterImage = new PictureBox();
            chkWeapon = new CheckBox();
            txtName = new TextBox();
            lblImageOverrideSelection = new Label();
            txtImageOverride = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            openImage = new OpenFileDialog();
            btnSelectImage = new Button();
            ((System.ComponentModel.ISupportInitialize)imgCharacterImage).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(24, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Name";
            // 
            // lblWeapon
            // 
            lblWeapon.AutoSize = true;
            lblWeapon.Location = new Point(24, 60);
            lblWeapon.Name = "lblWeapon";
            lblWeapon.Size = new Size(67, 15);
            lblWeapon.TabIndex = 1;
            lblWeapon.Text = "Weapon (?)";
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new Point(24, 165);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(40, 15);
            lblImage.TabIndex = 2;
            lblImage.Text = "Image";
            // 
            // imgCharacterImage
            // 
            imgCharacterImage.Location = new Point(83, 165);
            imgCharacterImage.Name = "imgCharacterImage";
            imgCharacterImage.Size = new Size(285, 257);
            imgCharacterImage.SizeMode = PictureBoxSizeMode.Zoom;
            imgCharacterImage.TabIndex = 3;
            imgCharacterImage.TabStop = false;
            // 
            // chkWeapon
            // 
            chkWeapon.AutoSize = true;
            chkWeapon.Location = new Point(105, 61);
            chkWeapon.Name = "chkWeapon";
            chkWeapon.Size = new Size(15, 14);
            chkWeapon.TabIndex = 4;
            chkWeapon.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            txtName.Location = new Point(105, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(263, 23);
            txtName.TabIndex = 5;
            // 
            // lblImageOverrideSelection
            // 
            lblImageOverrideSelection.AutoSize = true;
            lblImageOverrideSelection.Location = new Point(24, 110);
            lblImageOverrideSelection.Name = "lblImageOverrideSelection";
            lblImageOverrideSelection.Size = new Size(74, 15);
            lblImageOverrideSelection.TabIndex = 8;
            lblImageOverrideSelection.Text = "Select image";
            // 
            // txtImageOverride
            // 
            txtImageOverride.Location = new Point(105, 107);
            txtImageOverride.Name = "txtImageOverride";
            txtImageOverride.ReadOnly = true;
            txtImageOverride.Size = new Size(182, 23);
            txtImageOverride.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(229, 442);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(310, 442);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // openImage
            // 
            openImage.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            openImage.FileOk += openImage_FileOk;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(293, 110);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(75, 23);
            btnSelectImage.TabIndex = 12;
            btnSelectImage.Text = "Browse";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // frmWishlist
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 477);
            Controls.Add(btnSelectImage);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtImageOverride);
            Controls.Add(lblImageOverrideSelection);
            Controls.Add(txtName);
            Controls.Add(chkWeapon);
            Controls.Add(imgCharacterImage);
            Controls.Add(lblImage);
            Controls.Add(lblWeapon);
            Controls.Add(lblName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmWishlist";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Wishlist";
            ((System.ComponentModel.ISupportInitialize)imgCharacterImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblWeapon;
        private Label lblImage;
        private PictureBox imgCharacterImage;
        private CheckBox chkWeapon;
        private TextBox txtName;
        private Label lblImageOverrideSelection;
        private TextBox txtImageOverride;
        private Button btnSave;
        private Button btnCancel;
        private OpenFileDialog openImage;
        private Button btnSelectImage;
    }
}