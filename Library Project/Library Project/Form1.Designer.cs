namespace Library_Project
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.dateAdvancementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manUserBut = new System.Windows.Forms.Button();
            this.checkOutBut = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkInBut = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(229, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateAdvancementToolStripMenuItem,
            this.importDataToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(37, 20);
            this.Menu.Text = "File";
            // 
            // dateAdvancementToolStripMenuItem
            // 
            this.dateAdvancementToolStripMenuItem.Name = "dateAdvancementToolStripMenuItem";
            this.dateAdvancementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.dateAdvancementToolStripMenuItem.Text = "Date Advancement";
            this.dateAdvancementToolStripMenuItem.Click += new System.EventHandler(this.dateAdvancementToolStripMenuItem_Click);
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.importDataToolStripMenuItem.Text = "Import Data";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // manUserBut
            // 
            this.manUserBut.Location = new System.Drawing.Point(26, 212);
            this.manUserBut.Name = "manUserBut";
            this.manUserBut.Size = new System.Drawing.Size(177, 23);
            this.manUserBut.TabIndex = 4;
            this.manUserBut.Text = "Manage Users";
            this.manUserBut.UseVisualStyleBackColor = true;
            this.manUserBut.Click += new System.EventHandler(this.manUserBut_Click);
            // 
            // checkOutBut
            // 
            this.checkOutBut.Location = new System.Drawing.Point(26, 154);
            this.checkOutBut.Name = "checkOutBut";
            this.checkOutBut.Size = new System.Drawing.Size(177, 23);
            this.checkOutBut.TabIndex = 2;
            this.checkOutBut.Text = "Check Out";
            this.checkOutBut.UseVisualStyleBackColor = true;
            this.checkOutBut.Click += new System.EventHandler(this.checkOutBut_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Manage Books";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkInBut
            // 
            this.checkInBut.Location = new System.Drawing.Point(26, 125);
            this.checkInBut.Name = "checkInBut";
            this.checkInBut.Size = new System.Drawing.Size(177, 23);
            this.checkInBut.TabIndex = 1;
            this.checkInBut.Text = "Check In";
            this.checkInBut.UseVisualStyleBackColor = true;
            this.checkInBut.Click += new System.EventHandler(this.checkInBut_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Print Lists";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Library Solutions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Making your job eaiser than it should be";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 295);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkOutBut);
            this.Controls.Add(this.checkInBut);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.manUserBut);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button manUserBut;
        private System.Windows.Forms.Button checkOutBut;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button checkInBut;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem dateAdvancementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
    }
}

