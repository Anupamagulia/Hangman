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
    public partial class easy : PhoneApplicationPage
    {
        public easy()
        {
            InitializeComponent();
        }
        private string tbWord;                  
        string[] wordList = new string[30];
        string[] hintList = new string[30];     
        int advanceCounter = 0;                 
        string newWord;
        int score=0;
        
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            
            wordList[0] = "Cat";
            wordList[1] = "Mat";
            wordList[2] = "Hat";
            wordList[3] = "Bat";
            wordList[4] = "Rat";
            wordList[5] = "Heart";
            wordList[6] = "India";
            wordList[7] = "dog";
            wordList[8] = "Delhi";
            wordList[9] = "Gym";
            wordList[10] = "kids"; wordList[15] = "Coal"; wordList[11] = "Mobile"; wordList[12] = "Wanted"; wordList[13] = "Calm"; wordList[14] = "Car";
            wordList[16] = "Dhoni"; wordList[17] = "Kashmir"; wordList[18] = "Chelsea"; wordList[19] = "Hulk"; wordList[20] = "Bodyguard";
            wordList[21] = "Tennis"; wordList[22] = "archery"; wordList[23] = "Bhajji"; wordList[24] = "Sania"; wordList[25] = "Computer";
            wordList[26] = "Sholay"; wordList[27] = "Boom"; wordList[28] = "Miami"; wordList[29] = "Vijender";
            hintList[0] = "The word is an animal"; hintList[1] = "Kind of management exam"; hintList[2] = "used to cover head"; hintList[3] = "superhero named after it";
            hintList[4] = "The word is an animal"; hintList[6] = "Name of a country"; hintList[7] = "Loyal animal"; hintList[8] = "Heart of India";
            hintList[5] = "Love is impossibe without it";hintList[9]="Every one should go there";hintList[10]="Every ones loves them";
            hintList[15]="Black in colour";hintList[11]="Necessary as food";hintList[12]="Hit movie of Salman khan";hintList[13]="State of mind";hintList[14]="Very easy no need of hint";
            hintList[16]="Last name of indian player";hintList[17]="Famous for Ice";hintList[18]="Football club";hintList[19]="Hollywood movie";hintList[20]="Bollywood movie";
            hintList[21]="Famous sport";hintList[22]="Sport";hintList[23]="Nick name of Indian player";hintList[24]="First name of Indian Player";hintList[25]="Popular invention";
            hintList[26]="Bollywood movie";hintList[27]="Bollywood movie";hintList[28]="Famous for its beaches";wordList[29]="Indian olympian who took part in 2012 olympics";
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
            if (advanceCounter > 15)
            {
                advanceCounter = 0;
            }
            newWord = wordList[advanceCounter];     
            MessageBox.Show(hintList[advanceCounter]);
            advanceCounter++;                       
            int strLen = newWord.Length;
            enableLetters();                        
            button11.IsEnabled = false;
            textBox3.Text = strLen.ToString();                    
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


            int strLen = wordToGuess.Length;        

            int guessesLeft = int.Parse(textBox3.Text); 

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

                    newChar = wordToGuess.Substring((result), 1);   

                    tbWord = tbWord.Remove(result, 1);              

                    tbWord = tbWord.Insert(result, newChar);        
                    guessedCorrectlyCounter++;
                }
            }
            if (guessedCorrectlyCounter == 0)
            {
                guessesLeft = guessesLeft - 1;
                textBox3.Text = guessesLeft.ToString();
            }

           
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
                
                ab.Text = tbWord;

                if (tbWord == wordToGuess)      
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
    

    
    

