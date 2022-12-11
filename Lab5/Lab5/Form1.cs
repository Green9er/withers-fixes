using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const string PROGRAMMER = "hayden withers";

        private int GetRandom(int minNum, int maxNum)
        {
            /*name:GetTandom
         * sent: 2 Ints, minNum and maxNum
         * returned: 1 int, random number between min and max
         * does:
         */
            Random login = new Random();
            int logCode = login.Next( maxNum, minNum);
            lblCode.Text = logCode.ToString();
            return logCode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {// things to be executed on the loading of the form
            const int MAXNUM = 100000;
            const int MINNUM = 200000;
            grpChoose.Visible = false;
            grpStats.Visible = false; 
            grpText.Visible = false; 
            txtCode.Focus();
            GetRandom(MINNUM, MAXNUM);
        }

        private void ResetTextGroup()
        {
            /*name: ResetTextGroup
            * sent: none
            * returned: none
            * does: resets one of the group boxes, text
             */
            txtString1.Text = "";
            txtString2.Text="";
            lblResults.Text = "";
            chkSwap.Checked = false;
            txtString1.Focus();
        }
        private void ResetStatsGroup()
        {
            /*name:ResetStatsGroup
            * sent: none
            *returned: none
            * does: resets the stats grp box
             */
            nudHowMany.Value = 10;
            lblMean.Text = "";
            lblOdd.Text = "";
            lblSum.Text = "";
            lstNumbers.Items.Clear();
        }
        private void SettupOption()
        {    /*name: SettupOption
             * sent: none
             * returned: none
             * does: changes the visible grp box depending on the chk button
             */

            if (radStats.Checked ==true)
            {
                grpText.Hide();
                grpStats.Show();
            }

            else
            {
                grpText.Show();
                grpStats.Hide();    
            }
        }
        private void Swap(ref string txtOne, ref string txtTwo)
        { 
            /*name: Swap
             * sent: 2 strings, ment to be from txt boxes
             * returned: none
             * does: swaps the location of 2 strings in ram
             */
            string filler = "";
            filler = txtOne;
            txtOne = txtTwo;
            txtTwo = filler;            
        }
        private bool CheckInput()
        {    /*name: CheckInput
             * sent: none
             * returned: Bool, either true of false
             * does: checks if the user has entered info into a txt  box
             */
            bool check;
            if (txtString1.Text == "" && txtString2.Text == "")
            {
                check = false;
            }
            else 
            { 
               check = true;
            }
            return check;
        }

        int attempt = 0;
        private void btnLogin_Click(object sender, EventArgs e)
        {// checks to see if user entered the right code and either closes or lets the user thru into the program (3 attempts)
            
            const int TRIES = 2;
            if (lblCode.Text == txtCode.Text)
            {
                grpChoose.Visible = true;
                grpLogin.Enabled = false;
            }
            else if (TRIES != attempt)
            {
                attempt++;
                MessageBox.Show(attempt + " incorrect code(s)!" + "\n" + "try again - only 3 attempts allowed", PROGRAMMER);
            }
            else 
            {
                MessageBox.Show("3 attempts to log in" + "\n" + "account locked - closeing program", PROGRAMMER);
                this.Close();
            }
        }
        int addTotal = 0;
        int lstIndex = 0;
        private int  AddList()
        {    /*name: AddList
             * sent: None
             * returned: 1 int, all items in lst box added up
             * does: adds all the items in the list box and displays it to the user
             */
            int itemCount = lstNumbers.Items.Count-1;
            lstIndex = 0;
            lstIndex = 0;
            addTotal = 0;
            while (itemCount  >= 0)
            {
               addTotal += Convert.ToInt16(lstNumbers.Items[lstIndex]) ;
                itemCount--;              
                lstIndex++;
            }
            lblSum.Text = addTotal.ToString("n0");
            itemCount = 0;
            return addTotal;
        }
        private int CountOdd()
        {    /*name: CountOdd
             * sent: None
             * returned: 1 int, number of odds
             * does:counts the number of ODD numbers and displays it to the user
             */
            int itemCount = 1;
            int oddCount = 0;
            lstIndex = 0;
            do
            {
                if (Convert.ToInt16(lstNumbers.Items[lstIndex]) % 2 == 1)
                oddCount++;
                lstIndex++;
                itemCount++;
               
            }while (itemCount <=lstNumbers.Items.Count);
            lblOdd.Text = oddCount.ToString();
            itemCount = 0;
            return oddCount;
        }


        private void btnReset_Click(object sender, EventArgs e)
        {//calls reset functions
            ResetTextGroup();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {//calls reset functions
            ResetStatsGroup();
        }

        private void radText_CheckedChanged(object sender, EventArgs e)
        {//calls function to change visible grp box
            SettupOption();
        }

        private void radStats_CheckedChanged(object sender, EventArgs e)
        {//calls function to change visible grp box
            SettupOption();
        }

        private void chkSwap_CheckedChanged(object sender, EventArgs e)
        {//code and function call to swap strings in ram
            string stringOne = txtString1.Text;
            string stringTwo = txtString2.Text;
            Swap(ref stringOne, ref stringTwo);
            txtString1.Text = stringOne;
            txtString2.Text = stringTwo;
            lblResults.Text = "string have been swapped!";
        }
       
        private void btnJoin_Click(object sender, EventArgs e)
        {// checks if user input data (with function), if they did, it add the strings together
            if (CheckInput() = true)
            {
                lblResults.Text = "first string= "+ txtString1.Text +"\n"+"second string="+ txtString2.Text+"\n" +"joined = "+txtString1.Text +"-->"+txtString2.Text;
            }

        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {//checks if user input data with function, if they did, it counts and displays the number of characters in the strings
            string stringOne = txtString1.Text;
            string stringTwo = txtString2.Text;
            if (CheckInput() == true)
            {
                int lengthOne = stringOne.Length;
                int lengthTwo = stringTwo.Length;
                lblResults.Text = "first string="+txtString1.Text+"\n"+"characters= "+lengthOne + "\n" + "second string=" + txtString2.Text + "\n" + "characters= " + lengthTwo;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {// generates random numbers and does some math (and calls some functions )to get all numbers added up, the number of ODD numbers and the mean
            lstNumbers.Items.Clear();
            const int  MAXNUM= 1000;
            const int MINNUM = 5000;
            Random numbers = new Random(733);
            for (int i = 0; i< nudHowMany.Value; i++ )
            {
                int randNum = numbers.Next(MAXNUM, MINNUM);
                lstNumbers.Items.Add(randNum);  
            }
            AddList();
            CountOdd();
            int formatting =addTotal / lstNumbers.Items.Count;
            lblMean.Text = formatting.ToString("n2");
        }
    }
}
