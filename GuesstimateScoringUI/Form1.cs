using GuesstimateScoring;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace GuesstimateScoringUI
{
    public partial class Form1 : Form
    {
        List<Player> players = new List<Player>();
        int Round = 1;

        const bool LOCALHOST = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetPlayerVisibility();
            PlayerFieldsLocked(false);
            actualValueTextBox.Visible = false;
            actualValueLabel.Visible = false;
            roundLabel.Visible = false;
            roundLabel.Text = $"Round #1";

            // TODO remove these lines before using in Release
            nameOfPlayerTextBox1.Text = "David";
            nameOfPlayerTextBox2.Text = "Sue";
            nameOfPlayerTextBox3.Text = "Katie";
        }

        private void gameOverButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetPlayerVisibility();
        }

        private void SetPlayerVisibility()
        {
            nameOfPlayerTextBox1.Visible = (numericUpDown.Value >= 1);
            guessValueTextBox1.Visible = (numericUpDown.Value >= 1);

            nameOfPlayerTextBox2.Visible = (numericUpDown.Value >= 2);
            guessValueTextBox2.Visible = (numericUpDown.Value >= 2);

            nameOfPlayerTextBox3.Visible = (numericUpDown.Value >= 3);
            guessValueTextBox3.Visible = (numericUpDown.Value >= 3);

            nameOfPlayerTextBox4.Visible = (numericUpDown.Value >= 4);
            guessValueTextBox4.Visible = (numericUpDown.Value >= 4);

            nameOfPlayerTextBox5.Visible = (numericUpDown.Value >= 5);
            guessValueTextBox5.Visible = (numericUpDown.Value >= 5);

            nameOfPlayerTextBox6.Visible = (numericUpDown.Value >= 6);
            guessValueTextBox6.Visible = (numericUpDown.Value >= 6);

            nameOfPlayerTextBox7.Visible = (numericUpDown.Value >= 7);
            guessValueTextBox7.Visible = (numericUpDown.Value >= 7);

            nameOfPlayerTextBox8.Visible = (numericUpDown.Value >= 8);
            guessValueTextBox8.Visible = (numericUpDown.Value >= 8);

            nameOfPlayerTextBox9.Visible = (numericUpDown.Value >= 9);
            guessValueTextBox9.Visible = (numericUpDown.Value >= 9);

            nameOfPlayerTextBox10.Visible = (numericUpDown.Value >= 10);
            guessValueTextBox10.Visible = (numericUpDown.Value >= 10);

            nameOfPlayerTextBox11.Visible = (numericUpDown.Value >= 11);
            guessValueTextBox11.Visible = (numericUpDown.Value >= 11);

            nameOfPlayerTextBox12.Visible = (numericUpDown.Value >= 12);
            guessValueTextBox12.Visible = (numericUpDown.Value >= 12);

            nameOfPlayerTextBox13.Visible = (numericUpDown.Value >= 13);
            guessValueTextBox13.Visible = (numericUpDown.Value >= 13);

            nameOfPlayerTextBox14.Visible = (numericUpDown.Value >= 14);
            guessValueTextBox14.Visible = (numericUpDown.Value >= 14);

            nameOfPlayerTextBox15.Visible = (numericUpDown.Value >= 15);
            guessValueTextBox15.Visible = (numericUpDown.Value >= 15);
        }

        private void PlayerFieldsLocked(bool areEnabled)
        {
            numericUpDown.Enabled = !areEnabled;
            nameOfPlayerTextBox1.ReadOnly = areEnabled;
            nameOfPlayerTextBox2.ReadOnly = areEnabled;
            nameOfPlayerTextBox3.ReadOnly = areEnabled;
            nameOfPlayerTextBox4.ReadOnly = areEnabled;
            nameOfPlayerTextBox5.ReadOnly = areEnabled;
            nameOfPlayerTextBox6.ReadOnly = areEnabled;
            nameOfPlayerTextBox7.ReadOnly = areEnabled;
            nameOfPlayerTextBox8.ReadOnly = areEnabled;
            nameOfPlayerTextBox9.ReadOnly = areEnabled;
            nameOfPlayerTextBox10.ReadOnly = areEnabled;
            nameOfPlayerTextBox11.ReadOnly = areEnabled;
            nameOfPlayerTextBox12.ReadOnly = areEnabled;
            nameOfPlayerTextBox13.ReadOnly = areEnabled;
            nameOfPlayerTextBox14.ReadOnly = areEnabled;
            nameOfPlayerTextBox15.ReadOnly = areEnabled;

            guessValueTextBox1.Enabled = areEnabled;
            guessValueTextBox2.Enabled = areEnabled;
            guessValueTextBox3.Enabled = areEnabled;
            guessValueTextBox4.Enabled = areEnabled;
            guessValueTextBox5.Enabled = areEnabled;
            guessValueTextBox6.Enabled = areEnabled;
            guessValueTextBox7.Enabled = areEnabled;
            guessValueTextBox8.Enabled = areEnabled;
            guessValueTextBox9.Enabled = areEnabled;
            guessValueTextBox10.Enabled = areEnabled;
            guessValueTextBox11.Enabled = areEnabled;
            guessValueTextBox12.Enabled = areEnabled;
            guessValueTextBox13.Enabled = areEnabled;
            guessValueTextBox14.Enabled = areEnabled;
            guessValueTextBox15.Enabled = areEnabled;
            actualValueTextBox.Enabled = areEnabled;
            actualValueTextBox.Visible = areEnabled;
            actualValueLabel.Visible = areEnabled;
            roundLabel.Visible = areEnabled;
            submitButton.Enabled = areEnabled;
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            PlayerFieldsLocked(true);
            GetPlayersList(Convert.ToInt32(numericUpDown.Value));
            guessValueTextBox1.Focus();

            // TODO remove these lines before using in Release
            guessValueTextBox1.Text = "2";
            guessValueTextBox2.Text = "3";
            guessValueTextBox3.Text = "7";
            actualValueTextBox.Text = "6";
        }

        private List<Player> GetPlayersList(int numberOfPlayers)
        {
            var url = LOCALHOST ? $"http://localhost:8081/player" : $"https://scoreround-1612473730352.azurewebsites.net/player";

            if (nameOfPlayerTextBox1.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox1.Text}", "POST"); }
            if (nameOfPlayerTextBox2.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox2.Text}", "POST"); }
            if (nameOfPlayerTextBox3.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox3.Text}", "POST"); }
            if (nameOfPlayerTextBox4.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox4.Text}", "POST"); }
            if (nameOfPlayerTextBox5.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox5.Text}", "POST"); }
            if (nameOfPlayerTextBox6.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox6.Text}", "POST"); }
            if (nameOfPlayerTextBox7.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox7.Text}", "POST"); }
            if (nameOfPlayerTextBox8.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox8.Text}", "POST"); }
            if (nameOfPlayerTextBox9.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox9.Text}", "POST"); }
            if (nameOfPlayerTextBox10.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox10.Text}", "POST"); }
            if (nameOfPlayerTextBox11.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox11.Text}", "POST"); }
            if (nameOfPlayerTextBox12.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox12.Text}", "POST"); }
            if (nameOfPlayerTextBox13.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox13.Text}", "POST"); }
            if (nameOfPlayerTextBox14.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox14.Text}", "POST"); }
            if (nameOfPlayerTextBox15.Text != string.Empty) { MakeHttpRequest($"{url}/{nameOfPlayerTextBox15.Text}", "POST"); }

            var result = MakeHttpRequest($"{url}/{nameOfPlayerTextBox15.Text}", "GET");
            players = JsonConvert.DeserializeObject<List<Player>>(result);
            return players;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            var guesses = GetPlayerGuesses(players);
            guesses = CalculateVariances(guesses, Convert.ToInt32(actualValueTextBox.Text.Replace(",", "")));
            differenceRichTextBox.Text = DisplayPlayerGuesses(players, guesses);
            players = ScoreRound(guesses);
            scoresRichTextBox.Text = DisplayPlayerScores(players);
            if (MessageBox.Show("Play another round?", "Round complete", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                ClearGuesses();
                roundLabel.Text = $"Round #{++Round}";
                guessValueTextBox1.Focus();
            }
            else
            {
                groupBox1.Enabled = false;
                tableLayoutPanel.Enabled = false;
                closeButton.Visible = true;
            }
        }

        private List<Guess> GetPlayerGuesses(List<Player> players)
        {
            int i = 0;
            List<Guess> guesses = new List<Guess>();
            foreach (var player in players)
            {
                var guess = new Guess(player.id);
                if (i == 0) { guess.guessValue = Convert.ToInt32(guessValueTextBox1.Text.Replace(",", "")); }
                if (i == 1) { guess.guessValue = Convert.ToInt32(guessValueTextBox2.Text.Replace(",", "")); }
                if (i == 2) { guess.guessValue = Convert.ToInt32(guessValueTextBox3.Text.Replace(",", "")); }
                if (i == 3) { guess.guessValue = Convert.ToInt32(guessValueTextBox4.Text.Replace(",", "")); }
                if (i == 4) { guess.guessValue = Convert.ToInt32(guessValueTextBox5.Text.Replace(",", "")); }
                if (i == 5) { guess.guessValue = Convert.ToInt32(guessValueTextBox6.Text.Replace(",", "")); }
                if (i == 6) { guess.guessValue = Convert.ToInt32(guessValueTextBox7.Text.Replace(",", "")); }
                if (i == 7) { guess.guessValue = Convert.ToInt32(guessValueTextBox8.Text.Replace(",", "")); }
                if (i == 8) { guess.guessValue = Convert.ToInt32(guessValueTextBox9.Text.Replace(",", "")); }
                if (i == 9) { guess.guessValue = Convert.ToInt32(guessValueTextBox10.Text.Replace(",", "")); }
                if (i == 10) { guess.guessValue = Convert.ToInt32(guessValueTextBox11.Text.Replace(",", "")); }
                if (i == 11) { guess.guessValue = Convert.ToInt32(guessValueTextBox12.Text.Replace(",", "")); }
                if (i == 12) { guess.guessValue = Convert.ToInt32(guessValueTextBox13.Text.Replace(",", "")); }
                if (i == 13) { guess.guessValue = Convert.ToInt32(guessValueTextBox14.Text.Replace(",", "")); }
                if (i == 14) { guess.guessValue = Convert.ToInt32(guessValueTextBox15.Text.Replace(",", "")); }
                guesses.Add(guess);
                i++;
            }
            return guesses;
        }

        private List<Guess> CalculateVariances(List<Guess> guesses, int actualValue)
        {
            //foreach (var guess in guesses)
            //{
            //    var difference = Math.Abs(guess.GuessValue - actualValue);
            //    guesses.Where(x => x.PlayerId == guess.PlayerId).First().OverUnderValue = difference;
            //}

            var url = LOCALHOST ? $"http://localhost:8080/calc/actual/{actualValue}" : $"https://calculatevariance-1612473730352.azurewebsites.net/calc/actual/{actualValue}";
            var result = MakeHttpRequest(url, "POST", JsonConvert.SerializeObject(guesses));
            var responseGuesses = JsonConvert.DeserializeObject<List<Guess>>(result);
            return responseGuesses;
        }

        private string DisplayPlayerGuesses(List<Player> players, List<Guess> guesses)
        {
            string results = string.Empty;
            var guessesList = guesses.OrderBy(x => x.overUnderValue).ToList();
            foreach (var guess in guessesList)
            {
                var playerName = players.Where(x => x.id == guess.playerId).FirstOrDefault().name;
                results += $"{playerName} \t {String.Format("{0:n0}",guess.overUnderValue)}\n";
            }
            return results;
        }

        //private void ScoreRound(ref List<Player> players, List<Guess> guesses)
        private List<Player> ScoreRound(List<Guess> guesses)
        {
            //var win = guesses.OrderBy(x => x.overUnderValue).ToList()[0].playerId;
            //var place = guesses.OrderBy(x => x.overUnderValue).ToList()[1].playerId;
            //var show = guesses.OrderBy(x => x.overUnderValue).ToList()[2].playerId;
            //players.Where(x => x.id == win).First().score += 5;
            //players.Where(x => x.id == place).First().score += 3;
            //players.Where(x => x.id == show).First().score += 1;

            var url = LOCALHOST ? $"http://localhost:8081/player/score/all" : $"https://scoreround-1612473730352.azurewebsites.net/player/score/all";
            var result = MakeHttpRequest(url, "PUT", JsonConvert.SerializeObject(guesses));
            var players = JsonConvert.DeserializeObject<List<Player>>(result);
            return players;
        }

        private string DisplayPlayerScores(List<Player> players)
        {
            string results = string.Empty;
            foreach (var player in players.OrderByDescending(x => x.score).ToList())
            {
                results += $"{player.name} \t {string.Format("{0:n0}", player.score)}\n";
            }
            return results;
        }

        private void ClearGuesses()
        {
            guessValueTextBox1.Text = string.Empty;
            guessValueTextBox2.Text = string.Empty;
            guessValueTextBox3.Text = string.Empty;
            guessValueTextBox4.Text = string.Empty;
            guessValueTextBox5.Text = string.Empty;
            guessValueTextBox6.Text = string.Empty;
            guessValueTextBox7.Text = string.Empty;
            guessValueTextBox8.Text = string.Empty;
            guessValueTextBox9.Text = string.Empty;
            guessValueTextBox10.Text = string.Empty;
            guessValueTextBox11.Text = string.Empty;
            guessValueTextBox12.Text = string.Empty;
            guessValueTextBox13.Text = string.Empty;
            guessValueTextBox14.Text = string.Empty;
            guessValueTextBox15.Text = string.Empty;
            actualValueTextBox.Text = string.Empty;
            actualValueTextBox.Text = string.Empty;
            actualValueLabel.Text = string.Empty;
        }

        private void guessValueTextBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.FormatNumeric();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            var url = LOCALHOST ? $"http://localhost:8081/player/all" : $"https://scoreround-1612473730352.azurewebsites.net/player/all";
            MakeHttpRequest(url, "DELETE");
            Close();
        }

        private string MakeHttpRequest(string url, string httpMethod, string jsonString = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = httpMethod;

            if (jsonString != null) {
                var data = Encoding.Default.GetBytes(jsonString);
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                var newStream = request.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
            }

            string result = string.Empty;
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
    public static class MyExtensions
    {
        public static string FormatNumeric(this string numericString)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(numericString))
            {
                string valueString = numericString.Replace(",", "");
                int value = int.Parse(valueString);
                result = string.Format("{0:n0}", value);
            }
            return result;
        }

    }
}
