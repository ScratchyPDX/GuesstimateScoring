using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuesstimateScoring;

namespace GuesstimateScoringUI
{
    public partial class Form1 : Form
    {
        List<Player> players = new List<Player>();
        int Round = 1;

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
        }

        private List<Player> GetPlayersList(int numberOfPlayers)
        {
            for (int i = 1; i < numberOfPlayers + 1; i++)
            {
                var player = new Player(i);
                if (i == 1) { player.Name = nameOfPlayerTextBox1.Text; }
                if (i == 2) { player.Name = nameOfPlayerTextBox2.Text; }
                if (i == 3) { player.Name = nameOfPlayerTextBox3.Text; }
                if (i == 4) { player.Name = nameOfPlayerTextBox4.Text; }
                if (i == 5) { player.Name = nameOfPlayerTextBox5.Text; }
                if (i == 6) { player.Name = nameOfPlayerTextBox6.Text; }
                if (i == 7) { player.Name = nameOfPlayerTextBox7.Text; }
                if (i == 8) { player.Name = nameOfPlayerTextBox8.Text; }
                if (i == 9) { player.Name = nameOfPlayerTextBox9.Text; }
                if (i == 10) { player.Name = nameOfPlayerTextBox10.Text; }
                if (i == 11) { player.Name = nameOfPlayerTextBox11.Text; }
                if (i == 12) { player.Name = nameOfPlayerTextBox12.Text; }
                if (i == 13) { player.Name = nameOfPlayerTextBox13.Text; }
                if (i == 14) { player.Name = nameOfPlayerTextBox14.Text; }
                if (i == 15) { player.Name = nameOfPlayerTextBox15.Text; }
                players.Add(player);
            }
            return players;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            List<Guess> guesses = new List<Guess>();
            GetPlayerGuesses(players, ref guesses);
            CalculateVariances(ref guesses, Convert.ToInt32(actualValueTextBox.Text.Replace(",", "")));
            differenceRichTextBox.Text = DisplayPlayerGuesses(players, guesses);
            ScoreRound(ref players, guesses);
            scoresRichTextBox.Text = PlayerScores(players);
            if (MessageBox.Show("Play another round?", "Round complete", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                ClearGuesses();
                roundLabel.Text = $"Round #{++Round}";
                guessValueTextBox1.Focus();
            }
            groupBox1.Enabled = false;
            tableLayoutPanel.Enabled = false;
            closeButton.Visible = true;
        }

        private void GetPlayerGuesses(List<Player> players, ref List<Guess> guesses)
        {
            int i = 0;
            foreach (var player in players)
            {
                var guess = new Guess(player.Id);
                if (i == 0) { guess.GuessValue = Convert.ToInt32(guessValueTextBox1.Text.Replace(",", "")); }
                if (i == 1) { guess.GuessValue = Convert.ToInt32(guessValueTextBox2.Text.Replace(",", "")); }
                if (i == 2) { guess.GuessValue = Convert.ToInt32(guessValueTextBox3.Text.Replace(",", "")); }
                if (i == 3) { guess.GuessValue = Convert.ToInt32(guessValueTextBox4.Text.Replace(",", "")); }
                if (i == 4) { guess.GuessValue = Convert.ToInt32(guessValueTextBox5.Text.Replace(",", "")); }
                if (i == 5) { guess.GuessValue = Convert.ToInt32(guessValueTextBox6.Text.Replace(",", "")); }
                if (i == 6) { guess.GuessValue = Convert.ToInt32(guessValueTextBox7.Text.Replace(",", "")); }
                if (i == 7) { guess.GuessValue = Convert.ToInt32(guessValueTextBox8.Text.Replace(",", "")); }
                if (i == 8) { guess.GuessValue = Convert.ToInt32(guessValueTextBox9.Text.Replace(",", "")); }
                if (i == 9) { guess.GuessValue = Convert.ToInt32(guessValueTextBox10.Text.Replace(",", "")); }
                if (i == 10) { guess.GuessValue = Convert.ToInt32(guessValueTextBox11.Text.Replace(",", "")); }
                if (i == 11) { guess.GuessValue = Convert.ToInt32(guessValueTextBox12.Text.Replace(",", "")); }
                if (i == 12) { guess.GuessValue = Convert.ToInt32(guessValueTextBox13.Text.Replace(",", "")); }
                if (i == 13) { guess.GuessValue = Convert.ToInt32(guessValueTextBox14.Text.Replace(",", "")); }
                if (i == 14) { guess.GuessValue = Convert.ToInt32(guessValueTextBox15.Text.Replace(",", "")); }
                guesses.Add(guess);
                i++;
            }
        }

        private void CalculateVariances(ref List<Guess> guesses, int actualValue)
        {
            foreach (var guess in guesses)
            {
                var difference = Math.Abs(guess.GuessValue - actualValue);
                guesses.Where(x => x.PlayerId == guess.PlayerId).First().OverUnderValue = difference;
            }
        }

        private string DisplayPlayerGuesses(List<Player> players, List<Guess> guesses)
        {
            string results = string.Empty;
            var guessesList = guesses.OrderBy(x => x.OverUnderValue).ToList();
            foreach (var guess in guessesList)
            {
                var playerName = players.Where(x => x.Id == guess.PlayerId).FirstOrDefault().Name;
                results += $"{playerName} \t {String.Format("{0:n0}",guess.OverUnderValue)}\n";
            }
            return results;
        }

        private void ScoreRound(ref List<Player> players, List<Guess> guesses)
        {
            var win = guesses.OrderBy(x => x.OverUnderValue).ToList()[0].PlayerId;
            var place = guesses.OrderBy(x => x.OverUnderValue).ToList()[1].PlayerId;
            var show = guesses.OrderBy(x => x.OverUnderValue).ToList()[2].PlayerId;
            players.Where(x => x.Id == win).First().Score += 5;
            players.Where(x => x.Id == place).First().Score += 3;
            players.Where(x => x.Id == show).First().Score += 1;
        }

        private string PlayerScores(List<Player> players)
        {
            string results = string.Empty;
            foreach (var player in players.OrderByDescending(x => x.Score).ToList())
            {
                results += $"{player.Name} \t {string.Format("{0:n0}", player.Score)}\n";
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
            Close();
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
