using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input; 
using System.Threading; 



namespace keyboard_press_external_detected
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


      
        bool isRunning = true;
        private object key;

        private void Form1_Load(object sender, EventArgs e)
        {

            Thread TH = new Thread(Keyboardd);
            TH.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            TH.Start(); 
        }




        /**
        * To use Keyboard class you need to add references 
        * PresentationCore and System.Xml.Ling, I am not sure if included with System.Xml 
         */
        void Keyboardd()
        {
            while(isRunning)
            {
                Thread.Sleep(40);

                if ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0)
                {

                    label1.Text = "D Pressed";

                    Console.WriteLine(label1.Text); 

                } 
                else
                {
                    label1.Text = "D Not Pressed";
                    Console.WriteLine(label1.Text);
                } 
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            isRunning = false;
        }
    }
}
