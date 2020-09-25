using Dolo.MovieStarPlanet;
using System.Windows.Forms;
using System;

namespace MovieStarPlanet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (var server in ServerParser.GetAllServer())
                comboBox1.Items.Add(server.ToString());
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Username &' Password Required!", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Selet a Server!", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var mspClient = new MspClient(new MspClientSocket()
            {
                KeepAlive = true,
                Server = ServerParser.ParseToServer(comboBox1.SelectedItem.ToString())
            });

            LockControl();

            var Result = await mspClient.Login(textBox1.Text, textBox2.Text);

            if(!Result.LoggedIn)
            {
                ReleaseControl();

                MessageBox.Show($"Fatal Error\n{Result.Status}", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReleaseControl();

            label1.Text = $"StarCoins: {Result.Actor.Starcoins:N0}";
            label2.Text = $"Diamonds: {Result.Actor.Diamonds:N0}";
            label3.Text = $"Level: {Result.Actor.Level}";

            MessageBox.Show($"Hello! {Result.Actor.Username}", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LockControl()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox1.Enabled = false;
            button1.Enabled = false;
            button1.Text = "LoggingIn ..";

        }
        private void ReleaseControl()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox1.Enabled = true;
            button1.Enabled = true;
            button1.Text = "Login";
        }

    }
}
