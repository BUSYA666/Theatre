namespace Theater
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ProductionsButtton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.TheaterButton = new System.Windows.Forms.Button();
            this.ActorButton = new System.Windows.Forms.Button();
            this.PlaysButtton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 100);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(344, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(112, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Главная";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(23, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 65);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // ProductionsButtton
            // 
            this.ProductionsButtton.BackColor = System.Drawing.Color.Tan;
            this.ProductionsButtton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductionsButtton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductionsButtton.Location = new System.Drawing.Point(216, 134);
            this.ProductionsButtton.Name = "ProductionsButtton";
            this.ProductionsButtton.Size = new System.Drawing.Size(118, 36);
            this.ProductionsButtton.TabIndex = 10;
            this.ProductionsButtton.Text = "Постановки";
            this.ProductionsButtton.UseVisualStyleBackColor = false;
            this.ProductionsButtton.Click += new System.EventHandler(this.ProductionsButton_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.TheaterButton);
            this.panel2.Controls.Add(this.ActorButton);
            this.panel2.Controls.Add(this.PlaysButtton);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.ProductionsButtton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 400);
            this.panel2.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tan;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(216, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 54);
            this.button1.TabIndex = 14;
            this.button1.Text = "График актеров";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TheaterButton
            // 
            this.TheaterButton.BackColor = System.Drawing.Color.Tan;
            this.TheaterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TheaterButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.TheaterButton.Location = new System.Drawing.Point(29, 263);
            this.TheaterButton.Name = "TheaterButton";
            this.TheaterButton.Size = new System.Drawing.Size(118, 36);
            this.TheaterButton.TabIndex = 13;
            this.TheaterButton.Text = "Театры";
            this.TheaterButton.UseVisualStyleBackColor = false;
            this.TheaterButton.Click += new System.EventHandler(this.TheaterButton_Click);
            // 
            // ActorButton
            // 
            this.ActorButton.BackColor = System.Drawing.Color.Tan;
            this.ActorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActorButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ActorButton.Location = new System.Drawing.Point(29, 198);
            this.ActorButton.Name = "ActorButton";
            this.ActorButton.Size = new System.Drawing.Size(118, 36);
            this.ActorButton.TabIndex = 12;
            this.ActorButton.Text = "Актеры";
            this.ActorButton.UseVisualStyleBackColor = false;
            this.ActorButton.Click += new System.EventHandler(this.ActorButton_Click);
            // 
            // PlaysButtton
            // 
            this.PlaysButtton.BackColor = System.Drawing.Color.Tan;
            this.PlaysButtton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlaysButtton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlaysButtton.Location = new System.Drawing.Point(29, 134);
            this.PlaysButtton.Name = "PlaysButtton";
            this.PlaysButtton.Size = new System.Drawing.Size(118, 36);
            this.PlaysButtton.TabIndex = 11;
            this.PlaysButtton.Text = "Запросы";
            this.PlaysButtton.UseVisualStyleBackColor = false;
            this.PlaysButtton.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 400);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button ProductionsButtton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ActorButton;
        private System.Windows.Forms.Button PlaysButtton;
        private System.Windows.Forms.Button TheaterButton;
        private System.Windows.Forms.Button button1;
    }
}