using Dolo.MovieStarPlanet;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace MovieStarPlanet
{
    public partial class Form1 : Form
    {

        private MspClient mspClient;

        public Form1()
        {
            InitializeComponent();

            foreach (var server in MspClientHelper.GetAllServer())
                comboBox1.Items.Add(server.ToString());

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Username &' Password Required!", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBox1.SelectedItem is null)
            {
                MessageBox.Show("Selet a Server!", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LockControl();

            mspClient = new MspClient(new MspClientOption
            {
                KeepAlive = true,
                Server = MspClientHelper.ParseToServer(comboBox1.SelectedItem.ToString())
            });

            var Result = await mspClient.Login(textBox1.Text, textBox2.Text);

            if (!Result.LoggedIn)
            {
                ReleaseControl();

                MessageBox.Show($"Fatal Error\n{Result.Status}", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReleaseControl();

            label1.Text = $"StarCoins: {Result.Actor.StarCoins:N0}";
            label2.Text = $"Diamonds: {Result.Actor.Diamonds:N0}";
            label3.Text = $"Level: {Result.Actor.Level}";

            Size = new Size(500, 210);

            MessageBox.Show($"Hello! {Result.Actor.Username}", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LockControl()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            comboBox1.Enabled = false;

            button1.Text = "LoggingIn ..";

        }
        private void ReleaseControl()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            comboBox1.Enabled = true;

            button1.Text = "Login";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (mspClient is null || !mspClient.User.LoggedIn)
            {
                MessageBox.Show($"You are not LoggedIn!", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show($"Username Required!", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LockControl();

            var Result = await mspClient.GetActorIdByName(textBox3.Text);

            if (!Result.Success)
            {
                ReleaseControl();

                MessageBox.Show($"Server-Error! Try again", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Result.Result.Value == 0)
            {
                ReleaseControl();

                MessageBox.Show($"Error!\nUser {textBox3.Text} not exist on {mspClient.User.Server}", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ReleaseControl();

            label4.Text = $"ID: {Result.Result}";


        }

        private void button3_Click(object sender, EventArgs e)
        {

            string ID = label4.Text.Split()[1];

            if (!string.IsNullOrEmpty(ID) && ID != "0")
            {
                Clipboard.SetText(ID);
                MessageBox.Show($"ID: {ID} saved to clipboard", "mspLib Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
