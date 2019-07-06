namespace GMTGUI
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.GMTDocsLink = new System.Windows.Forms.LinkLabel();
            this.GMTDiscordLink = new System.Windows.Forms.LinkLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(354, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Remove Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(354, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Configure Game";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(335, 342);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // GMTDocsLink
            // 
            this.GMTDocsLink.AutoSize = true;
            this.GMTDocsLink.Location = new System.Drawing.Point(354, 303);
            this.GMTDocsLink.Name = "GMTDocsLink";
            this.GMTDocsLink.Size = new System.Drawing.Size(136, 13);
            this.GMTDocsLink.TabIndex = 4;
            this.GMTDocsLink.TabStop = true;
            this.GMTDocsLink.Text = "Read GMT documentation!";
            this.GMTDocsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GMTDocsLink_LinkClicked);
            // 
            // GMTDiscordLink
            // 
            this.GMTDiscordLink.AutoSize = true;
            this.GMTDiscordLink.Location = new System.Drawing.Point(354, 326);
            this.GMTDiscordLink.Name = "GMTDiscordLink";
            this.GMTDiscordLink.Size = new System.Drawing.Size(127, 13);
            this.GMTDiscordLink.TabIndex = 5;
            this.GMTDiscordLink.TabStop = true;
            this.GMTDiscordLink.Text = "Visit GMT Discord server!";
            this.GMTDiscordLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GMTDiscordLink_LinkClicked);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(354, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Launch Game";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 365);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.GMTDiscordLink);
            this.Controls.Add(this.GMTDocsLink);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "GMTogether GUI by nkrapivin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.LinkLabel GMTDocsLink;
        private System.Windows.Forms.LinkLabel GMTDiscordLink;
        private System.Windows.Forms.Button button4;
    }
}

