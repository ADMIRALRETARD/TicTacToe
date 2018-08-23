using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace wf_TAASHAATOE
{
    public partial class Form1 : Form
    {

        bool turn = true;
        int turn_count = 0;

        SoundPlayer sp1,sp2;

        public Form1()
        {
            InitializeComponent();
            sp1 = new SoundPlayer();
            sp1.Stream = Properties.Resources.taaaa;
            sp2 = new SoundPlayer();
            sp2.Stream = Properties.Resources.shaa;
        }

       private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                
                b.Text = "ТАА";
            
            
            else
                b.Text = "ШАА";

            turn = !turn;
            b.Enabled = false;

            turn_count++;
            if (b.Text == "ТАА")
            {
                sp1.Play();
            }
            else
                sp2.Play();
            CheckForWinner();
        }

      

        private void CheckForWinner()
        {
            bool there_is_a_winner = false;
            //horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) 
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text)&& (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text)&&(!C1.Enabled))
                there_is_a_winner = true;
            //vertical check

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //diagonal check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_a_winner = true;


            if (there_is_a_winner)
            {
                disableButtons();


                String winner = " ";
                if (turn)
                    winner = "ШАА";
                else
                    winner = "ТАА";

                MessageBox.Show(winner + "   КРАСАВА ЕЖЖИ!");
            }
            else
            {
                if(turn_count==9)
                    MessageBox.Show("ХВАТИТ ТУТ ХУЛИГАНИТЬ!!");
            }
        } //Checkforwinner

        private void disableButtons()
        {
            try
            {


                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//foreach
            }//try
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
            try
            {


                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = " ";
                }//foreach
            }//try
            catch { }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Скажу: безделье — игрушка дьявола — во-первых.Во-вторых — занимайтесь программированием, не надо там по углам курить, шабить, дрочить, мастурбировать, что, конечно, многим одно и то же. Просто безделье это игрушка дьявола, я повторяюсь ежже. Ну, весь мир будет против меня — я буду программировать ежжи! Я вдохновляюсь этим ежжи. Итак, пацаны, голову не теряйте, во-первых. И всех благ вам, ежжи.");


        }
    }
    }

