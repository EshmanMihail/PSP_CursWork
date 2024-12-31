namespace Races
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
            this.glControl1 = new OpenTK.GLControl();
            this.PlayLan = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.Button();
            this.IPtext = new System.Windows.Forms.TextBox();
            this.PlayerOneLaps = new System.Windows.Forms.Label();
            this.PlayerTwoLaps = new System.Windows.Forms.Label();
            this.PlayerOneFuel = new System.Windows.Forms.Label();
            this.PlayerTwoFuel = new System.Windows.Forms.Label();
            this.PlayerOneTires = new System.Windows.Forms.Label();
            this.PlayerTwoTires = new System.Windows.Forms.Label();
            this.SlowingPlayerOne = new System.Windows.Forms.Label();
            this.SlowingPlayerTwo = new System.Windows.Forms.Label();
            this.WinPanel = new System.Windows.Forms.Label();
            this.GameName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.BackgroundImage = global::Races.Properties.Resources.фон;
            this.glControl1.Location = new System.Drawing.Point(1, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(796, 453);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // PlayLan
            // 
            this.PlayLan.AutoSize = true;
            this.PlayLan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.PlayLan.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayLan.Location = new System.Drawing.Point(351, 159);
            this.PlayLan.Name = "PlayLan";
            this.PlayLan.Size = new System.Drawing.Size(406, 80);
            this.PlayLan.TabIndex = 1;
            this.PlayLan.Text = "Игра по сети";
            this.PlayLan.UseVisualStyleBackColor = false;
            this.PlayLan.Click += new System.EventHandler(this.PlayLan_Click);
            // 
            // Connect
            // 
            this.Connect.AutoSize = true;
            this.Connect.BackColor = System.Drawing.Color.Lime;
            this.Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Connect.Location = new System.Drawing.Point(351, 317);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(270, 49);
            this.Connect.TabIndex = 2;
            this.Connect.Text = "Подключиться";
            this.Connect.UseVisualStyleBackColor = false;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Create
            // 
            this.Create.AutoSize = true;
            this.Create.BackColor = System.Drawing.Color.Red;
            this.Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Create.Location = new System.Drawing.Point(351, 363);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(168, 49);
            this.Create.TabIndex = 3;
            this.Create.Text = "Создать";
            this.Create.UseVisualStyleBackColor = false;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // IPtext
            // 
            this.IPtext.BackColor = System.Drawing.Color.WhiteSmoke;
            this.IPtext.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IPtext.Location = new System.Drawing.Point(351, 266);
            this.IPtext.Name = "IPtext";
            this.IPtext.Size = new System.Drawing.Size(270, 45);
            this.IPtext.TabIndex = 4;
            // 
            // PlayerOneLaps
            // 
            this.PlayerOneLaps.AutoSize = true;
            this.PlayerOneLaps.BackColor = System.Drawing.Color.Yellow;
            this.PlayerOneLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerOneLaps.Location = new System.Drawing.Point(12, 9);
            this.PlayerOneLaps.Name = "PlayerOneLaps";
            this.PlayerOneLaps.Size = new System.Drawing.Size(211, 32);
            this.PlayerOneLaps.TabIndex = 5;
            this.PlayerOneLaps.Text = "PlayerOneLaps";
            this.PlayerOneLaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerTwoLaps
            // 
            this.PlayerTwoLaps.AutoSize = true;
            this.PlayerTwoLaps.BackColor = System.Drawing.Color.Yellow;
            this.PlayerTwoLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerTwoLaps.Location = new System.Drawing.Point(13, 9);
            this.PlayerTwoLaps.Name = "PlayerTwoLaps";
            this.PlayerTwoLaps.Size = new System.Drawing.Size(223, 32);
            this.PlayerTwoLaps.TabIndex = 6;
            this.PlayerTwoLaps.Text = "PlayerTwoLaps";
            this.PlayerTwoLaps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerOneFuel
            // 
            this.PlayerOneFuel.AutoSize = true;
            this.PlayerOneFuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerOneFuel.Location = new System.Drawing.Point(12, 56);
            this.PlayerOneFuel.Name = "PlayerOneFuel";
            this.PlayerOneFuel.Size = new System.Drawing.Size(205, 32);
            this.PlayerOneFuel.TabIndex = 7;
            this.PlayerOneFuel.Text = "PlayerOneFuel";
            this.PlayerOneFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerTwoFuel
            // 
            this.PlayerTwoFuel.AutoSize = true;
            this.PlayerTwoFuel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.PlayerTwoFuel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerTwoFuel.Location = new System.Drawing.Point(13, 56);
            this.PlayerTwoFuel.Name = "PlayerTwoFuel";
            this.PlayerTwoFuel.Size = new System.Drawing.Size(217, 32);
            this.PlayerTwoFuel.TabIndex = 8;
            this.PlayerTwoFuel.Text = "PlayerTwoFuel";
            this.PlayerTwoFuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PlayerTwoFuel.Click += new System.EventHandler(this.PlayerTwoFuel_Click);
            // 
            // PlayerOneTires
            // 
            this.PlayerOneTires.AutoSize = true;
            this.PlayerOneTires.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerOneTires.Location = new System.Drawing.Point(11, 107);
            this.PlayerOneTires.Name = "PlayerOneTires";
            this.PlayerOneTires.Size = new System.Drawing.Size(248, 32);
            this.PlayerOneTires.TabIndex = 9;
            this.PlayerOneTires.Text = "Ускорение: false";
            this.PlayerOneTires.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerTwoTires
            // 
            this.PlayerTwoTires.AutoSize = true;
            this.PlayerTwoTires.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerTwoTires.Location = new System.Drawing.Point(12, 107);
            this.PlayerTwoTires.Name = "PlayerTwoTires";
            this.PlayerTwoTires.Size = new System.Drawing.Size(248, 32);
            this.PlayerTwoTires.TabIndex = 10;
            this.PlayerTwoTires.Text = "Ускорение: false";
            this.PlayerTwoTires.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlowingPlayerOne
            // 
            this.SlowingPlayerOne.AutoSize = true;
            this.SlowingPlayerOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SlowingPlayerOne.Location = new System.Drawing.Point(12, 159);
            this.SlowingPlayerOne.Name = "SlowingPlayerOne";
            this.SlowingPlayerOne.Size = new System.Drawing.Size(273, 32);
            this.SlowingPlayerOne.TabIndex = 11;
            this.SlowingPlayerOne.Text = "Замедление: false";
            this.SlowingPlayerOne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlowingPlayerTwo
            // 
            this.SlowingPlayerTwo.AutoSize = true;
            this.SlowingPlayerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SlowingPlayerTwo.Location = new System.Drawing.Point(11, 159);
            this.SlowingPlayerTwo.Name = "SlowingPlayerTwo";
            this.SlowingPlayerTwo.Size = new System.Drawing.Size(273, 32);
            this.SlowingPlayerTwo.TabIndex = 12;
            this.SlowingPlayerTwo.Text = "Замедление: false";
            this.SlowingPlayerTwo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SlowingPlayerTwo.Click += new System.EventHandler(this.PTCountBullets_Click);
            // 
            // WinPanel
            // 
            this.WinPanel.AutoSize = true;
            this.WinPanel.BackColor = System.Drawing.Color.Indigo;
            this.WinPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WinPanel.ForeColor = System.Drawing.Color.Yellow;
            this.WinPanel.Location = new System.Drawing.Point(323, 9);
            this.WinPanel.Name = "WinPanel";
            this.WinPanel.Size = new System.Drawing.Size(293, 69);
            this.WinPanel.TabIndex = 13;
            this.WinPanel.Text = "WinPanel";
            this.WinPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameName
            // 
            this.GameName.AutoSize = true;
            this.GameName.BackColor = System.Drawing.Color.BurlyWood;
            this.GameName.Font = new System.Drawing.Font("Wide Latin", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameName.ForeColor = System.Drawing.Color.Crimson;
            this.GameName.Location = new System.Drawing.Point(4, 0);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(605, 74);
            this.GameName.TabIndex = 14;
            this.GameName.Text = "RacesUDP";
            this.GameName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Races.Properties.Resources.image_2024_12_30_02_50_161;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameName);
            this.Controls.Add(this.WinPanel);
            this.Controls.Add(this.SlowingPlayerTwo);
            this.Controls.Add(this.SlowingPlayerOne);
            this.Controls.Add(this.PlayerTwoTires);
            this.Controls.Add(this.PlayerOneTires);
            this.Controls.Add(this.PlayerTwoFuel);
            this.Controls.Add(this.PlayerOneFuel);
            this.Controls.Add(this.PlayerTwoLaps);
            this.Controls.Add(this.PlayerOneLaps);
            this.Controls.Add(this.IPtext);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.PlayLan);
            this.Controls.Add(this.glControl1);
            this.Name = "Form1";
            this.Text = "Races";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Button PlayLan;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.TextBox IPtext;
        private System.Windows.Forms.Label PlayerOneLaps;
        private System.Windows.Forms.Label PlayerTwoLaps;
        private System.Windows.Forms.Label PlayerOneFuel;
        private System.Windows.Forms.Label PlayerTwoFuel;
        private System.Windows.Forms.Label PlayerOneTires;
        private System.Windows.Forms.Label PlayerTwoTires;
        private System.Windows.Forms.Label SlowingPlayerOne;
        private System.Windows.Forms.Label SlowingPlayerTwo;
        private System.Windows.Forms.Label WinPanel;
        private System.Windows.Forms.Label GameName;
    }
}

