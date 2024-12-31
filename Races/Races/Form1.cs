using OpenTK;
using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using EngineLibrary;
using NetworkLibrary;
using GameLibrary;
using System.Drawing;
using GameLibrary.Map;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Races
{
    public partial class Form1 : Form
    {
        Game game = new Game();

        public Form1()
        {
            InitializeComponent();

            GameEvents.ChangeLaps += ChangeLaps;
            GameEvents.ChangeFuel += ChangeFuel;
            GameEvents.ChangeTires += ChangeTires;
            GameEvents.ChangeSlowing += ChangeSlowing;
            GameEvents.EndGame += EndGame;

            PlayerOneLaps.Visible = false;
            PlayerTwoLaps.Visible = false;
            PlayerOneFuel.Visible = false;
            PlayerTwoFuel.Visible = false;
            PlayerOneTires.Visible = false;
            PlayerTwoTires.Visible = false;
            WinPanel.Visible = false;
            WinPanel.Location = new Point((this.ClientSize.Width - WinPanel.Width) / 2, this.ClientSize.Height - WinPanel.Height);
            SlowingPlayerOne.Visible = false;
            SlowingPlayerTwo.Visible = false;

            this.Width = 1314;
            this.Height = 765;
            //this.Width = 714;
            //this.Height = 465;

            glControl1.Dock = DockStyle.Fill;

            int spacing = 30; 
            // Расстояние между элементами
            PlayLan.Location = new Point((this.ClientSize.Width - PlayLan.Width) / 2, (this.ClientSize.Height - PlayLan.Height) / 2 - spacing * 3);
            IPtext.Location = new Point((this.ClientSize.Width - IPtext.Width) / 2, (this.ClientSize.Height - IPtext.Height) / 2 - spacing);
            Create.Location = new Point((this.ClientSize.Width - Create.Width) / 2, (this.ClientSize.Height - Create.Height) / 2 + spacing * 3);
            Connect.Location = new Point((this.ClientSize.Width - Connect.Width) / 2, (this.ClientSize.Height - Connect.Height) / 2 + spacing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool _loaded;
        private bool isRendring = false;

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.Texture2D);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.ClearColor(Color.Gray);

            _loaded = true;

            glControl1.Invalidate();

            glControl1.Visible = false;
            IPtext.Visible = false;
            Create.Visible = false;
            Connect.Visible = false;
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (isRendring)
                Render();

            glControl1.Invalidate();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!_loaded)
                return;
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            glControl1.Invalidate();
        }

        private void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //GL.ClearColor(System.Drawing.Color.CornflowerBlue);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, glControl1.Width, glControl1.Height, 0, 0, 1);
            game.Rendering();

            glControl1.SwapBuffers();
        }

        private void PlayLan_Click(object sender, EventArgs e)
        {
            PlayLan.Visible = false;
            IPtext.Visible= true;
            Create.Visible = true;
            Connect.Visible = true;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            IPtext.Visible = false;
            Create.Visible = false;
            Connect.Visible = false;
            GameName.Visible = false;

            glControl1.Visible = true;

            var seed = new Random().Next();
            var server = new Server();
            server.OnDataGot += (o) => OnClientServed(server, seed);
            OnClientServed(server, seed);
            //server.UpdateData("connect");
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            IPtext.Visible = false;
            Create.Visible = false;
            Connect.Visible = false;

            glControl1.Visible = true;

            var address = IPtext.Text;
            Client client = new Client(address);
            client.OnDataGot += (o) => OnServerResponsed(client, o);
            OnServerResponsed(client, address);
        }

        private void OnServerResponsed(INetworkHandler handler, object obj)
        {
            GameName.Visible = false;
            PlayerTwoLaps.Visible = true;
            PlayerTwoFuel.Visible = true;
            PlayerTwoTires.Visible = true;
            SlowingPlayerTwo.Visible = true;

            var seed = (string)obj;
            handler.ClearListeners();
            //Console.WriteLine("Seed = " + seed);
            game.ChengeScene(new LevelScene(handler, "PlayerTwo", "PlayerOne"));

            BackgroundImage = null;
            isRendring = true;
            glControl1.Visible = true;
        }

        private void OnClientServed(INetworkHandler handler, int seed)
        {
            GameName.Visible = false;
            PlayerOneLaps.Visible = true;
            PlayerOneFuel.Visible = true;
            PlayerOneTires.Visible = true;
            SlowingPlayerOne.Visible = true;

            handler.ClearListeners();
            game.ChengeScene(new LevelScene(handler, "PlayerOne", "PlayerTwo"));
            BackgroundImage = null;

            isRendring = true;

            glControl1.Visible = true;
        }


        private void ChangeLaps(string player, int value)
        {

            if (player == "PlayerOne")
            {
                PlayerOneLaps.Text = value.ToString();
            }
            else
            {
                PlayerTwoLaps.Text = value.ToString();
            }
        }

        private void ChangeFuel(string player, float value)
        {
            if (player == "PlayerOne")
            {
                if (value < 0) value = 0;
                PlayerOneFuel.Text = "Топливо:" + value.ToString("0.00");
            }
            else
            {
                if (value < 0) value = 0;
                PlayerTwoFuel.Text = "Топливо:" + value.ToString("0.00");
            }
        }

        private void ChangeTires(string player, bool value)
        {
            if (player == "PlayerOne") 
            { 
                PlayerOneTires.Text = "Ускорение: " + value.ToString();
                PlayerOneTires.ForeColor = value ? Color.Green : Color.Red;
            } 
            else 
            { 
                PlayerTwoTires.Text = "Ускорение: " + value.ToString();
                PlayerTwoTires.ForeColor = value ? Color.Green : Color.Red;
            }
        }

        private void ChangeSlowing(string player, int count, bool value)
        {
            if (player == "PlayerOne")
            {
                SlowingPlayerOne.Text = "Замедление:" + value.ToString();
                SlowingPlayerOne.ForeColor = value ? Color.Red : Color.Green;
            }
            else
            {
                SlowingPlayerTwo.Text = "Замедление:" + value.ToString();
                SlowingPlayerTwo.ForeColor = value ? Color.Red : Color.Green;
            }
        }

        private void EndGame(string winPlayer)
        {
            if (winPlayer == "PlayerOne")
            {
                WinPanel.Text = "Red player win";
            }
            else
            {
                WinPanel.Text = "Blue player win";
            }

            WinPanel.Visible = true;

            GameEvents.EndGame -= EndGame;
            GameEvents.ChangeLaps -= ChangeLaps;
            GameEvents.ChangeFuel -= ChangeFuel;
            GameEvents.ChangeTires -= ChangeTires;
            GameEvents.ChangeSlowing -= ChangeSlowing;
        }

        private void PlayerTwoFuel_Click(object sender, EventArgs e)
        {

        }

        private void PTCountBullets_Click(object sender, EventArgs e)
        {

        }
    }
}
