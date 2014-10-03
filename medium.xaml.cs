using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Hangman
{
    public partial class medium : PhoneApplicationPage
    {
        public medium()
        {
            InitializeComponent();
        }
        private string tbWord;                  //HOLDS THE WORD FROM TEXTBOX
        string[] wordList = new string[25];     //WORD ARRAY
        string[] hintList = new string[25];
        int advanceCounter = 0;                 //USED TO GET THE NEXT WORD
        string newWord;
        int score = 0;             

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            wordList[0] = "Linux";
            wordList[1] = "Tiger";
            wordList[2] = "Water";
            wordList[3] = "Orange";
            wordList[4] = "Bricks";
            wordList[5] = "Sachin";
            wordList[6] = "Ramdev";
            wordList[7] = "Health";
            wordList[8] = "Death";
            wordList[9] = "Kidney";
            wordList[10] = "Jail"; wordList[15] = "Friend"; wordList[11] = "Extempore"; wordList[12] = "Beautiful"; wordList[13] = "Sehwag"; wordList[14] = "Bolt";
            wordList[16] = "Mario"; wordList[17] = "Oxygen"; wordList[18] = "Soccer"; wordList[19] = "Gymnastics"; wordList[20] = "Leaflet";
            wordList[21] = "Google"; wordList[22] = "Education"; wordList[23] = "Aieee"; wordList[24] = "Doctor";
            hintList[0] = "Rival of windows"; hintList[1] = "The word is an animal"; hintList[2] = "Everybody needs this"; hintList[3] = "It is fruit";
            hintList[4] = "Everyone want this of gold"; hintList[6] = "Popular anti corruption activist "; hintList[7] = "It is the biggest wealth"; hintList[8] = "It comes to everybody";
            hintList[5] = "Another name of God in INDIA"; hintList[9] = "One of the body organs"; hintList[10] = "No one wants to go there";
            hintList[15] = "Everyone needs atleast one"; hintList[11] = "Only 2 min to think in this competion"; hintList[12] = "The word is an adjective"; hintList[13] = "Second name Team India opener"; hintList[14] = "Second name of greatest global athlete";
            hintList[16] = "Popular video game"; hintList[17] = "Important to live"; hintList[18] = "popular sport"; hintList[19] = "Need flexible body for this"; hintList[20] = "Used in advertisement";
            hintList[21] = "Best teacher in world"; hintList[22] = "Very important to make this better world"; hintList[23] = "Competitive exam in india"; hintList[24] = "Another face of god";
            disableLetters();
        }
        void enableLetters()
        {
            A.IsEnabled = true;
            B.IsEnabled = true;
            C.IsEnabled = true;
            D.IsEnabled = true;
            E.IsEnabled = true;
            F.IsEnabled = true;
            G.IsEnabled = true;
            H.IsEnabled = true;
            I.IsEnabled = true;
            J.IsEnabled = true;
            K.IsEnabled = true;
            L.IsEnabled = true;
            M.IsEnabled = true;
            N.IsEnabled = true;
            O.IsEnabled = true;
            P.IsEnabled = true;
            Q.IsEnabled = true;
            R.IsEnabled = true;
            S.IsEnabled = true;
            T.IsEnabled = true;
            U.IsEnabled = true;
            V.IsEnabled = true;
            W.IsEnabled = true;
            X.IsEnabled = true;
            Y.IsEnabled = true;
            Z.IsEnabled = true;
        }
        void disableLetters()
        {
            A.IsEnabled = false;
            B.IsEnabled = false;
            C.IsEnabled = false;
            D.IsEnabled = false;
            E.IsEnabled = false;
            F.IsEnabled = false;
            G.IsEnabled = false;
            H.IsEnabled = false;
            I.IsEnabled = false;
            J.IsEnabled = false;
            K.IsEnabled = false;
            L.IsEnabled = false;
            M.IsEnabled = false;
            N.IsEnabled = false;
            O.IsEnabled = false;
            P.IsEnabled = false;
            Q.IsEnabled = false;
            R.IsEnabled = false;
            S.IsEnabled = false;
            T.IsEnabled = false;
            U.IsEnabled = false;
            V.IsEnabled = false;
            W.IsEnabled = false;
            X.IsEnabled = false;
            Y.IsEnabled = false;
            Z.IsEnabled = false;

        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            ab.IsEnabled = true;
            ab.Text = "";
            if (advanceCounter > 24)
            {
                advanceCounter = 0;
            }
            newWord = wordList[advanceCounter];     //GET A NEW WORD
            MessageBox.Show(hintList[advanceCounter]);
            advanceCounter++;                       //ADVANCE THE COUNTER FOR THE ARRAY
            int strLen = newWord.Length;
            enableLetters();                        //ENABLE ALL THE LETTER BUTTONS
            button11.IsEnabled = false;
            textBox3.Text = strLen.ToString();                    //SET THE NUMBER OF GUESSES
            for (int i = 0; i < strLen; i++)
            {
                ab.Text += "*";
            }
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), A.Name, A);
        }
         private void checkGuessedLetter(string wordToGuess, string guessedLetter, Button butName)
        {
            tbWord = ab.Text;


            int strLen = wordToGuess.Length;        //USE THE LENGTH PROPERTY OF THE wordToGuess STRING

            int guessesLeft = int.Parse(textBox3.Text); //SEE HOW MANY GUESSES A PLAYER HAS LEFT

            int result = 0;
            int counter = 0;
            int foundLen = 0;
            string newChar = "";
            int guessedCorrectlyCounter = 0;

            for (int i = 0; i < strLen; i++)
            {
                result = wordToGuess.IndexOf(guessedLetter, foundLen, strLen - foundLen);

                if (result != -1)
                {
                    foundLen = result + 1;
                    counter++;

                    newChar = wordToGuess.Substring((result), 1);   //grab the letter to be replaced

                    tbWord = tbWord.Remove(result, 1);              //Remove the * character at this position

                    tbWord = tbWord.Insert(result, newChar);        //insert the new character
                    guessedCorrectlyCounter++;
                }
            }
            if (guessedCorrectlyCounter == 0)
            {
                guessesLeft = guessesLeft - 1;
                textBox3.Text = guessesLeft.ToString();
            }

            //=================================================
            //          CHECK HOW MANY GUESSESS LEFT. 
            //          IF ZERO - GAME OVER, AND RESET
            //=================================================
            if (guessesLeft == 0)
            {
                MessageBox.Show("You Lost. The word was " + wordToGuess);
                disableLetters();
                button11.IsEnabled = true;
                ab.Text = "";
                if (score == 0)
                {
                    int i = 0;
                    textBox4.Text = i.ToString();
                }
                else
                {
                    score = score - 1;
                    textBox4.Text = score.ToString();
                }
                textBox4.IsEnabled = false;
                textBox3.IsEnabled = false;
                textBox2.IsEnabled = false;
                textBox1.IsEnabled = false;
                ab.IsEnabled = false;
            }
            else
            {
                //PLACE THE NEW VERSION OF THE WORD BACK INTO THE TEXTBOX
                ab.Text = tbWord;

                if (tbWord == wordToGuess)      //CHECK IF PLAYER HAS WON
                {
                    score = score + 1;
                    MessageBox.Show("You Won - Well Done!");
                    disableLetters();
                    button11.IsEnabled = true;
                    ab.Text = "";
                    textBox4.Text = score.ToString();
                    textBox4.IsEnabled = false;
                    textBox3.IsEnabled = false;
                    textBox2.IsEnabled = false;
                    textBox1.IsEnabled = false;
                    ab.IsEnabled = false;
                }

            }
            //=================================================================================
            //      THIS IS WHERE WE USE THE BUTTON OBJECT THAT WE PASSED OVER TO THE METHOD.
            //      ALL WE'RE DOING IS SWITCHING THE LETTER BUTTON OFF
            //=================================================================================
            butName.IsEnabled = false;

        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), B.Name, B);
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), C.Name, C);
        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), D.Name, D);
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), E.Name, E);
        }

        private void F_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), F.Name, F);
        }

        private void G_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), G.Name, G);
        }

        private void H_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), H.Name, H);
        }

        private void I_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), I.Name, I);
        }

        private void J_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), J.Name, J);
        }

        private void K_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), K.Name, K);
        }

        private void L_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), L.Name, L);
        }

        private void M_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), M.Name, M);
        }

        private void N_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), N.Name, N);
        }

        private void O_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), O.Name, O);
        }

        private void P_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), P.Name, P);
        }

        private void Q_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), Q.Name, Q);
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), R.Name, R);
        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), S.Name, S);
        }

        private void T_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), T.Name, T);
        }

        private void U_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), U.Name, U);
        }

        private void V_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), V.Name, V);
        }

        private void W_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), W.Name, W);
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), X.Name, X);
        }

        private void Y_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), Y.Name, Y);
        }

        private void Z_Click(object sender, RoutedEventArgs e)
        {
            checkGuessedLetter(newWord.ToUpper(), Z.Name, Z);
        }

    }
}

        
           