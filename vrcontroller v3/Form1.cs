using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace vrcontroller_v3
{
    // Import the user32.dll
   
    public partial class Form1 : Form
    {


        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int VK_LBUTTON = 0x01;
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        public const int VK_RCONTROL = 0xA3; //Right Control key code
        public const int LEFT_SHIFT = 0x81;
        public const int A_CHAR = 0x41;




        string[] ports = SerialPort.GetPortNames();
        string str;
        private Point coordinate;
        

        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = ports[0];
          

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
           

        }

        private object PointToScreen(object y)
        {
            throw new NotImplementedException();
        }

      

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            str = serialPort1.ReadExisting();
            
           // MessageBox.Show(str);
            //        Invoke(new MouseEventHandler(edit));
            int x = 0, y = 0;
            textBox1.Text = str;
            if (str == "RT")
            {
                x = System.Windows.Forms.Cursor.Position.X + 100;
                y = System.Windows.Forms.Cursor.Position.Y;
                set_position(x, y);
            }
            else if (str == "RU")
            {
                //MouseManipulator.VirtualMouse.RightUp();
                x = System.Windows.Forms.Cursor.Position.X + 100;
                y = System.Windows.Forms.Cursor.Position.Y - 100 ;
                set_position(x, y);
            }
            else if (str == "RD")
            {
                x = System.Windows.Forms.Cursor.Position.X + 100;
                y = System.Windows.Forms.Cursor.Position.Y + 100;
                set_position(x, y);
            }
            else if (str == "LF")
            {
                x = System.Windows.Forms.Cursor.Position.X - 100;
                y = System.Windows.Forms.Cursor.Position.Y;
                set_position(x, y);
            }

            if (str == "LU")
            {
                x = System.Windows.Forms.Cursor.Position.X -100 ;
                y = System.Windows.Forms.Cursor.Position.Y -100;
                set_position(x, y);

            }
            else if (str == "LD")
            {
                x = System.Windows.Forms.Cursor.Position.X -100;
                y = System.Windows.Forms.Cursor.Position.Y +100;
                set_position(x, y);
            }
            else if (str =="UP")
            {
                x = System.Windows.Forms.Cursor.Position.X ;
                y = System.Windows.Forms.Cursor.Position.Y - 100;
                set_position(x, y);
            }
            else if(str =="DN")
            {
                x = System.Windows.Forms.Cursor.Position.X ;
                y = System.Windows.Forms.Cursor.Position.Y + 100;
                set_position(x, y);
            }
            else if(str == "PN")
            {
               keybd_event(VK_LBUTTON, 0, KEYEVENTF_KEYUP, 0);
                //  System.Windows.Forms.Keys.A;
                //MouseManipulator.VirtualMouse.DoMouseClick();
           }
            else if (str == "PF")
            {

            }
            


        }
        private void edit(object sender, MouseEventArgs e)
        {
            textBox1.Text = str;
            int x = 0, y = 0;
            MouseManipulator m = new MouseManipulator();
            if (str == "LU")
            {
                x = e.X - 10;
                y = e.Y + 10;
                set_position(x, y);
                
                
                MouseManipulator.VirtualMouse.MoveTo(-2, 0);
            }
               
            else if (str == "LD")
                MouseManipulator.VirtualMouse.LeftDown();
            else if (str == "RU")
                MouseManipulator.VirtualMouse. RightUp();
            else if (str == "RD")
                MouseManipulator.VirtualMouse.RightDown();
            



        }
        private void set_position (int x , int y)
        {
            PointConverter pc = new PointConverter();
            Point pt = new Point();
            

            pt.X = x;
            pt.Y = y;

            Cursor.Position = pt;
        }
        private void key (object sender, KeyPressEventArgs e)
        {
            e.KeyChar = 'A';
        }
        private void modify (object sender, MouseEventArgs e)
        {

           
            /*
            char[] delimeters = { ' ' , '\\'};
            string[] strarr = str.Split(delimeters);
            if (strarr.Count() == 2 && ! ((strarr[0].Contains("\\")) && (strarr[0].Contains("\\")) ))
            {
                try
                {
                    double vx = (double .Parse(strarr[0]) + 300) / 200;  
                    double vy = -(double.Parse(strarr[1]) - 100) / 200;
                }
                catch
                {
                    textBox1.Text = "fill data";
                }
               // textBox1.Text = vx.ToString() ;
               // textBox2.Text = vy.ToString();

            }
            */


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 'A')
            {
                MessageBox.Show("Enter key pressed");
            }
            if (e.KeyChar == 13)
            {
                MessageBox.Show("Enter key pressed");
            }
        }
    }
}
