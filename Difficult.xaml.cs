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
    public partial class Difficult : PhoneApplicationPage
    {
        public Difficult()
        {
            InitializeComponent();
        }
        private string tbWord;                  //HOLDS THE WORD FROM TEXTBOX
        string[] wordList = new string[25];
        string[] hintList = new string[25];     //WORD ARRAY
        int advanceCounter = 0;                 //USED TO GET THE NEXT WORD
        string newWord;
        int score = 0;
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            wordList[0] = "Education";
            wordList[1] = "Directory";
            wordList[2] = "Exams";
            wordList[3] = "Authentication";
            wordList[4] = "Poverty";
            wordList[5] = "Turmoil";
            wordList[6] = "Habit";
            wordList[7] = "Counsellor";
            wordList[8] = "Free";
            wordList[9] = "Braveheart";
            wordList[10] = "Titanic"; wordList[15] = "Caesar"; wordList[11] = "shakespeare"; wordList[12] = "Kaalia"; wordList[13] = "Shatrughan"; wordList[14] = "Impasse";
            wordList[16] = "Vestberg"; wordList[17] = "Clamour"; wordList[18] = "Beagle"; wordList[19] = "Chevrolet"; wordList[20] = "Utopias";
            wordList[21] = "Abyss"; wordList[22] = "Apocalyptic"; wordList[23] = "Saxophone"; wordList[24] = "Abet";
            hintList[0] = "It is necessary for country growth"; hintList[1] = "It is useful in implementing storage mechanism"; hintList[2] = "Gives goosebump to everyone"; hintList[3] = "Necessary to maintain identity";
            hintList[4] = "Biggest problem of India"; hintList[6] = "This thing makes a man successful"; hintList[7] = "Help others"; hintList[8] = "This word gives smile on anybody's face";
            hintList[5] = "Violent agitation"; hintList[9] = "Oscar winning movie of 90s"; hintList[10] = "Best movie of all time from Hollywood";
            hintList[15] = "I came, I saw, I conquered.Who said these lines"; hintList[11] = "A fool thinks himself to be wise,but a wise man knows himself to be a fool.Who said this quote:"; hintList[12] = "Hum jaha pe khade ho jaate hein, line wahi se shuru hoti hai.This famous dialogue belong to which movie"; hintList[13] = "Who said this famous dialogue.Jali ko aag kehte hai, bhuji ko raakh kehte hai..aur jis raakh se barood bane..use Vishwanath kehte hai!"; hintList[14] = "A difficult sitution";
            hintList[16] = "Second name of Ericsson CEO"; hintList[17] = "Demanding something in noisy way"; hintList[18] = "Famous family dog breed"; hintList[19] = "Famous car brand"; hintList[20] = "Costliest beer in the world";
            hintList[21] = "A deep hole in the ground"; hintList[22] = "Refer to somthing very destructive.It is an adjective"; hintList[23] = "Popular music instrument"; hintList[24] = "Encourage someone to do something";
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