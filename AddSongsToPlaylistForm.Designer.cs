using System.Windows.Forms;

namespace MusicPlayer
{
    partial class AddSongsToPlaylistForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button doneButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.doneButton = new System.Windows.Forms.Button();

            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(400, 500);
            this.flowLayoutPanel1.TabIndex = 0;

            // 
            // doneButton
            // 
            this.doneButton.Text = "Gata";
            this.doneButton.Width = 100;
            this.doneButton.Height = 30;
            this.doneButton.Margin = new Padding(10);
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);

            // Adăugăm butonul la flowLayoutPanel
            this.flowLayoutPanel1.Controls.Add(this.doneButton);

            // 
            // AddSongsToPlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AddSongsToPlaylistForm";
            this.Text = "Adaugă melodii în playlist";
            this.ResumeLayout(false);
        }
    }
}
