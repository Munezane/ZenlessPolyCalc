namespace ZenlessPolyCalc
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblEndDate = new Label();
            lstWishlist = new ListView();
            dtPatchEndDate = new DateTimePicker();
            lblCurrentPolys = new Label();
            lblCurrentTapes = new Label();
            numCurrentTapes = new NumericUpDown();
            numCurrentPolys = new NumericUpDown();
            lblWishlist = new Label();
            lblRemainingEventPolys = new Label();
            ttEventPolys = new ToolTip(components);
            numRemainingEventPolys = new NumericUpDown();
            ttAssumeShiyuARank = new ToolTip(components);
            chkAssumeShiyuARank = new CheckBox();
            lblAssumeShiyuARank = new Label();
            lblFinalPolys = new Label();
            lblFinalPolysResult = new Label();
            lblFinalPulls = new Label();
            lblFinalPullsResult = new Label();
            btnSave = new Button();
            lblSaveChanges = new Label();
            lblCalculatePolys = new Label();
            btnCalcFinalPolys = new Button();
            ttCurrentTapes = new ToolTip(components);
            btnAddToWishlist = new Button();
            ((System.ComponentModel.ISupportInitialize)numCurrentTapes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCurrentPolys).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRemainingEventPolys).BeginInit();
            SuspendLayout();
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(12, 12);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(129, 15);
            lblEndDate.TabIndex = 0;
            lblEndDate.Text = "Current patch end date";
            // 
            // lstWishlist
            // 
            lstWishlist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lstWishlist.Location = new Point(782, 44);
            lstWishlist.Name = "lstWishlist";
            lstWishlist.Size = new Size(284, 551);
            lstWishlist.TabIndex = 2;
            lstWishlist.UseCompatibleStateImageBehavior = false;
            // 
            // dtPatchEndDate
            // 
            dtPatchEndDate.Location = new Point(147, 6);
            dtPatchEndDate.Name = "dtPatchEndDate";
            dtPatchEndDate.Size = new Size(200, 23);
            dtPatchEndDate.TabIndex = 3;
            // 
            // lblCurrentPolys
            // 
            lblCurrentPolys.AutoSize = true;
            lblCurrentPolys.Location = new Point(12, 46);
            lblCurrentPolys.Name = "lblCurrentPolys";
            lblCurrentPolys.Size = new Size(119, 15);
            lblCurrentPolys.TabIndex = 4;
            lblCurrentPolys.Text = "Current Polychromes";
            // 
            // lblCurrentTapes
            // 
            lblCurrentTapes.AutoSize = true;
            lblCurrentTapes.Location = new Point(267, 48);
            lblCurrentTapes.Name = "lblCurrentTapes";
            lblCurrentTapes.Size = new Size(96, 15);
            lblCurrentTapes.TabIndex = 5;
            lblCurrentTapes.Text = "Current Tapes (?)";
            // 
            // numCurrentTapes
            // 
            numCurrentTapes.Location = new Point(369, 44);
            numCurrentTapes.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numCurrentTapes.Name = "numCurrentTapes";
            numCurrentTapes.Size = new Size(120, 23);
            numCurrentTapes.TabIndex = 7;
            // 
            // numCurrentPolys
            // 
            numCurrentPolys.Location = new Point(137, 46);
            numCurrentPolys.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numCurrentPolys.Name = "numCurrentPolys";
            numCurrentPolys.Size = new Size(120, 23);
            numCurrentPolys.TabIndex = 8;
            // 
            // lblWishlist
            // 
            lblWishlist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblWishlist.AutoSize = true;
            lblWishlist.Location = new Point(782, 14);
            lblWishlist.Name = "lblWishlist";
            lblWishlist.Size = new Size(48, 15);
            lblWishlist.TabIndex = 9;
            lblWishlist.Text = "Wishlist";
            // 
            // lblRemainingEventPolys
            // 
            lblRemainingEventPolys.AutoSize = true;
            lblRemainingEventPolys.Location = new Point(12, 84);
            lblRemainingEventPolys.Name = "lblRemainingEventPolys";
            lblRemainingEventPolys.Size = new Size(184, 15);
            lblRemainingEventPolys.TabIndex = 10;
            lblRemainingEventPolys.Text = "Remaining Event Polychromes (?)";
            // 
            // numRemainingEventPolys
            // 
            numRemainingEventPolys.Location = new Point(202, 82);
            numRemainingEventPolys.Name = "numRemainingEventPolys";
            numRemainingEventPolys.Size = new Size(120, 23);
            numRemainingEventPolys.TabIndex = 11;
            // 
            // chkAssumeShiyuARank
            // 
            chkAssumeShiyuARank.AutoSize = true;
            chkAssumeShiyuARank.Location = new Point(159, 158);
            chkAssumeShiyuARank.Name = "chkAssumeShiyuARank";
            chkAssumeShiyuARank.RightToLeft = RightToLeft.Yes;
            chkAssumeShiyuARank.Size = new Size(15, 14);
            chkAssumeShiyuARank.TabIndex = 13;
            chkAssumeShiyuARank.UseVisualStyleBackColor = true;
            // 
            // lblAssumeShiyuARank
            // 
            lblAssumeShiyuARank.AutoSize = true;
            lblAssumeShiyuARank.Location = new Point(16, 157);
            lblAssumeShiyuARank.Name = "lblAssumeShiyuARank";
            lblAssumeShiyuARank.Size = new Size(137, 15);
            lblAssumeShiyuARank.TabIndex = 12;
            lblAssumeShiyuARank.Text = "Assume Shiyu A Rank (?)";
            // 
            // lblFinalPolys
            // 
            lblFinalPolys.AutoSize = true;
            lblFinalPolys.Location = new Point(14, 319);
            lblFinalPolys.Name = "lblFinalPolys";
            lblFinalPolys.Size = new Size(337, 15);
            lblFinalPolys.TabIndex = 14;
            lblFinalPolys.Text = "Amount of Polychromes expected by end of the current patch:";
            // 
            // lblFinalPolysResult
            // 
            lblFinalPolysResult.AutoSize = true;
            lblFinalPolysResult.Location = new Point(361, 319);
            lblFinalPolysResult.Name = "lblFinalPolysResult";
            lblFinalPolysResult.Size = new Size(16, 15);
            lblFinalPolysResult.TabIndex = 15;
            lblFinalPolysResult.Text = "...";
            // 
            // lblFinalPulls
            // 
            lblFinalPulls.AutoSize = true;
            lblFinalPulls.Location = new Point(16, 380);
            lblFinalPulls.Name = "lblFinalPulls";
            lblFinalPulls.Size = new Size(191, 15);
            lblFinalPulls.TabIndex = 16;
            lblFinalPulls.Text = "Total pulls by end of current patch:";
            // 
            // lblFinalPullsResult
            // 
            lblFinalPullsResult.AutoSize = true;
            lblFinalPullsResult.Location = new Point(213, 380);
            lblFinalPullsResult.Name = "lblFinalPullsResult";
            lblFinalPullsResult.Size = new Size(16, 15);
            lblFinalPullsResult.TabIndex = 17;
            lblFinalPullsResult.Text = "...";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(107, 213);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 18;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblSaveChanges
            // 
            lblSaveChanges.AutoSize = true;
            lblSaveChanges.Location = new Point(21, 217);
            lblSaveChanges.Name = "lblSaveChanges";
            lblSaveChanges.Size = new Size(80, 15);
            lblSaveChanges.TabIndex = 19;
            lblSaveChanges.Text = "Save Changes";
            // 
            // lblCalculatePolys
            // 
            lblCalculatePolys.AutoSize = true;
            lblCalculatePolys.Location = new Point(21, 273);
            lblCalculatePolys.Name = "lblCalculatePolys";
            lblCalculatePolys.Size = new Size(261, 15);
            lblCalculatePolys.TabIndex = 20;
            lblCalculatePolys.Text = "Calcuate expected polychromes by end of patch";
            // 
            // btnCalcFinalPolys
            // 
            btnCalcFinalPolys.Location = new Point(288, 269);
            btnCalcFinalPolys.Name = "btnCalcFinalPolys";
            btnCalcFinalPolys.Size = new Size(113, 23);
            btnCalcFinalPolys.TabIndex = 21;
            btnCalcFinalPolys.Text = "Calc final polys";
            btnCalcFinalPolys.UseVisualStyleBackColor = true;
            btnCalcFinalPolys.Click += btnCalcFinalPolys_Click;
            // 
            // btnAddToWishlist
            // 
            btnAddToWishlist.Location = new Point(836, 12);
            btnAddToWishlist.Name = "btnAddToWishlist";
            btnAddToWishlist.Size = new Size(75, 23);
            btnAddToWishlist.TabIndex = 22;
            btnAddToWishlist.Text = "Add";
            btnAddToWishlist.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1078, 607);
            Controls.Add(btnAddToWishlist);
            Controls.Add(btnCalcFinalPolys);
            Controls.Add(lblCalculatePolys);
            Controls.Add(lblSaveChanges);
            Controls.Add(btnSave);
            Controls.Add(lblFinalPullsResult);
            Controls.Add(lblFinalPulls);
            Controls.Add(lblFinalPolysResult);
            Controls.Add(lblFinalPolys);
            Controls.Add(chkAssumeShiyuARank);
            Controls.Add(lblAssumeShiyuARank);
            Controls.Add(numRemainingEventPolys);
            Controls.Add(lblRemainingEventPolys);
            Controls.Add(lblWishlist);
            Controls.Add(numCurrentPolys);
            Controls.Add(numCurrentTapes);
            Controls.Add(lblCurrentTapes);
            Controls.Add(lblCurrentPolys);
            Controls.Add(dtPatchEndDate);
            Controls.Add(lstWishlist);
            Controls.Add(lblEndDate);
            Name = "frmMain";
            Text = "Zenless Polychrome Calculator";
            ((System.ComponentModel.ISupportInitialize)numCurrentTapes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCurrentPolys).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRemainingEventPolys).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEndDate;
        private ListView lstWishlist;
        private DateTimePicker dtPatchEndDate;
        private Label lblCurrentPolys;
        private Label lblCurrentTapes;
        private NumericUpDown numCurrentTapes;
        private NumericUpDown numCurrentPolys;
        private Label lblWishlist;
        private Label lblRemainingEventPolys;
        private TextBox textBox1;
        private ToolTip ttEventPolys;
        private NumericUpDown numRemainingEventPolys;
        private ToolTip ttAssumeShiyuARank;
        private CheckBox chkAssumeShiyuARank;
        private Label lblAssumeShiyuARank;
        private Label lblFinalPolys;
        private Label lblFinalPolysResult;
        private Label lblFinalPulls;
        private Label lblFinalPullsResult;
        private Button btnSave;
        private Label lblSaveChanges;
        private Label lblCalculatePolys;
        private Button btnCalcFinalPolys;
        private ToolTip ttCurrentTapes;
        private Button btnAddToWishlist;
    }
}
