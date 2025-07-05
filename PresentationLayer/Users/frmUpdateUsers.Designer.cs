namespace PresentationLayer.Users
{
    partial class frmUpdateUsers
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateUsers));
            listView1 = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            setPermissionsToToolStripMenuItem = new ToolStripMenuItem();
            imgBig = new ImageList(components);
            imgSmall = new ImageList(components);
            rbList = new RadioButton();
            rbTile = new RadioButton();
            rbLargeIcon = new RadioButton();
            rbDetails = new RadioButton();
            rbSmallIcon = new RadioButton();
            gbView = new GroupBox();
            lblRecords = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            btnCLose = new Button();
            contextMenuStrip1.SuspendLayout();
            gbView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.BackColor = Color.White;
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.LargeImageList = imgBig;
            listView1.Location = new Point(12, 423);
            listView1.Name = "listView1";
            listView1.Size = new Size(1057, 406);
            listView1.SmallImageList = imgSmall;
            listView1.StateImageList = imgSmall;
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem, toolStripMenuItem1, setPermissionsToToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(188, 86);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Image = Properties.Resources.Delete_32_2;
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(187, 38);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(184, 6);
            // 
            // setPermissionsToToolStripMenuItem
            // 
            setPermissionsToToolStripMenuItem.Image = Properties.Resources.edit_32;
            setPermissionsToToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            setPermissionsToToolStripMenuItem.Name = "setPermissionsToToolStripMenuItem";
            setPermissionsToToolStripMenuItem.Size = new Size(187, 38);
            setPermissionsToToolStripMenuItem.Text = "Set Permissions To";
            // 
            // imgBig
            // 
            imgBig.ColorDepth = ColorDepth.Depth32Bit;
            imgBig.ImageStream = (ImageListStreamer)resources.GetObject("imgBig.ImageStream");
            imgBig.TransparentColor = Color.Transparent;
            imgBig.Images.SetKeyName(0, "Male 512.png");
            imgBig.Images.SetKeyName(1, "Female 512.png");
            // 
            // imgSmall
            // 
            imgSmall.ColorDepth = ColorDepth.Depth32Bit;
            imgSmall.ImageStream = (ImageListStreamer)resources.GetObject("imgSmall.ImageStream");
            imgSmall.TransparentColor = Color.Transparent;
            imgSmall.Images.SetKeyName(0, "Male 512.png");
            imgSmall.Images.SetKeyName(1, "Female 512.png");
            // 
            // rbList
            // 
            rbList.AutoSize = true;
            rbList.Font = new Font("Sitka Subheading Semibold", 12F, FontStyle.Bold);
            rbList.ForeColor = Color.Black;
            rbList.Location = new Point(31, 78);
            rbList.Name = "rbList";
            rbList.Size = new Size(55, 27);
            rbList.TabIndex = 1;
            rbList.TabStop = true;
            rbList.Text = "List";
            rbList.UseVisualStyleBackColor = true;
            rbList.CheckedChanged += rbList_CheckedChanged;
            // 
            // rbTile
            // 
            rbTile.AutoSize = true;
            rbTile.Font = new Font("Sitka Subheading Semibold", 12F, FontStyle.Bold);
            rbTile.ForeColor = Color.Black;
            rbTile.Location = new Point(169, 78);
            rbTile.Name = "rbTile";
            rbTile.Size = new Size(56, 27);
            rbTile.TabIndex = 2;
            rbTile.TabStop = true;
            rbTile.Text = "Tile";
            rbTile.UseVisualStyleBackColor = true;
            rbTile.CheckedChanged += rbTile_CheckedChanged;
            // 
            // rbLargeIcon
            // 
            rbLargeIcon.AutoSize = true;
            rbLargeIcon.Font = new Font("Sitka Subheading Semibold", 12F, FontStyle.Bold);
            rbLargeIcon.ForeColor = Color.Black;
            rbLargeIcon.Location = new Point(31, 38);
            rbLargeIcon.Name = "rbLargeIcon";
            rbLargeIcon.Size = new Size(105, 27);
            rbLargeIcon.TabIndex = 3;
            rbLargeIcon.TabStop = true;
            rbLargeIcon.Text = "Large Icon";
            rbLargeIcon.UseVisualStyleBackColor = true;
            rbLargeIcon.CheckedChanged += rbLargeIcon_CheckedChanged;
            // 
            // rbDetails
            // 
            rbDetails.AutoSize = true;
            rbDetails.Font = new Font("Sitka Subheading Semibold", 12F, FontStyle.Bold);
            rbDetails.ForeColor = Color.Black;
            rbDetails.Location = new Point(169, 38);
            rbDetails.Name = "rbDetails";
            rbDetails.Size = new Size(78, 27);
            rbDetails.TabIndex = 4;
            rbDetails.TabStop = true;
            rbDetails.Text = "Details";
            rbDetails.UseVisualStyleBackColor = true;
            rbDetails.CheckedChanged += rbDetails_CheckedChanged;
            // 
            // rbSmallIcon
            // 
            rbSmallIcon.AutoSize = true;
            rbSmallIcon.Font = new Font("Sitka Subheading Semibold", 12F, FontStyle.Bold);
            rbSmallIcon.ForeColor = Color.Black;
            rbSmallIcon.Location = new Point(307, 38);
            rbSmallIcon.Name = "rbSmallIcon";
            rbSmallIcon.Size = new Size(105, 27);
            rbSmallIcon.TabIndex = 5;
            rbSmallIcon.TabStop = true;
            rbSmallIcon.Text = "Small Icon";
            rbSmallIcon.UseVisualStyleBackColor = true;
            rbSmallIcon.CheckedChanged += rbSmallIcon_CheckedChanged;
            // 
            // gbView
            // 
            gbView.Controls.Add(rbSmallIcon);
            gbView.Controls.Add(rbDetails);
            gbView.Controls.Add(rbLargeIcon);
            gbView.Controls.Add(rbTile);
            gbView.Controls.Add(rbList);
            gbView.Font = new Font("Sitka Subheading Semibold", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbView.ForeColor = Color.IndianRed;
            gbView.Location = new Point(61, 292);
            gbView.Name = "gbView";
            gbView.Size = new Size(457, 125);
            gbView.TabIndex = 6;
            gbView.TabStop = false;
            gbView.Text = "View";
            // 
            // lblRecords
            // 
            lblRecords.Anchor = AnchorStyles.Left;
            lblRecords.AutoSize = true;
            lblRecords.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRecords.Location = new Point(133, 852);
            lblRecords.Margin = new Padding(4, 0, 4, 0);
            lblRecords.Name = "lblRecords";
            lblRecords.Size = new Size(36, 20);
            lblRecords.TabIndex = 21;
            lblRecords.Text = "???";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 852);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 20;
            label3.Text = "Records :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(192, 0, 0);
            label2.Location = new Point(414, 241);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(241, 39);
            label2.TabIndex = 24;
            label2.Tag = "MainTitle";
            label2.Text = "Update Users";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = Properties.Resources.Users_2_400;
            pictureBox1.Location = new Point(414, 12);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(265, 226);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // btnCLose
            // 
            btnCLose.Image = Properties.Resources.Close_32;
            btnCLose.Location = new Point(949, 835);
            btnCLose.Name = "btnCLose";
            btnCLose.Size = new Size(108, 42);
            btnCLose.TabIndex = 25;
            btnCLose.UseVisualStyleBackColor = true;
            btnCLose.Click += btnCLose_Click;
            // 
            // frmUpdateUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1081, 889);
            Controls.Add(btnCLose);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(lblRecords);
            Controls.Add(label3);
            Controls.Add(gbView);
            Controls.Add(listView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmUpdateUsers";
            Text = "7";
            Load += frmUpdateUsers_Load;
            contextMenuStrip1.ResumeLayout(false);
            gbView.ResumeLayout(false);
            gbView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ImageList imgSmall;
        private ImageList imgBig;
        private RadioButton rbList;
        private RadioButton rbTile;
        private RadioButton rbLargeIcon;
        private RadioButton rbDetails;
        private RadioButton rbSmallIcon;
        private GroupBox gbView;
        private ContextMenuStrip contextMenuStrip1;
        private Label lblRecords;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem setPermissionsToToolStripMenuItem;
        private Button btnCLose;
    }
}