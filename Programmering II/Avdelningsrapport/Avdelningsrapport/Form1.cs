using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avdelningsrapport
{
    public partial class Form1 : Form
    {
                                          // kod ansluter till server
        TcpClient klinet = new TcpClient();
        int port = 12345;
        IPAddress address = IPAddress.Parse("127.0.0.1");

                                               // skapa en lista
        List<Bok> boklista = new List<Bok>();
                                               // deklarera variabler
        FileLoader f = new FileLoader();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        public async void koppling()
        {
            klinet.NoDelay = true;
            try
            {

               
                await klinet.ConnectAsync(address, port);
            }
            catch (Exception error)
            {
                                                // om server inte fungerar ger avändare error.
                MessageBox.Show(error.Message, Text);
                return;
            }





        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                                      // när användare klicka på button 1, connect med server och ger grönn färg
            koppling();


        }

        private void button2_Click(object sender, EventArgs e)
        {
                                               // denna knapp att ladda lista 
            if (klinet.Connected)
            {

                if (f.boklista.Count > 0)
                {
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        sending("\n" +listBox1.Items[i].ToString());    // adding new lines like below.
                        Thread.Sleep(55);
                    }
                }


            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)     // tillägg listbox knäpp.
        { 


        }

        public async void  sending(String message)
        {
                                                       //anslutning till servern och skicka ett meddelande.
            byte[] utData = Encoding.Unicode.GetBytes(message);
            try
            {
             await klinet.GetStream().WriteAsync(utData, 0, utData.Length);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message, Text);
                return;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
                                                        // denna knapp fungerar att skicka alla objct
           
                if (f.boklista.Count > 0)
                {

                
                    foreach (Bok bok in f.boklista)
                        {
                    listBox1.Items.Add(bok);


                }


            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (klinet.Connected)
            {
             
                if (f.boklista.Count > 0)
                {
                    if (listBox1.SelectedItems.Count == 1)
                    {
                                             //skickar boken som är markerat och tas bort från listan och skickas till servern
                        sending(listBox1.SelectedItem.ToString());
                        f.boklista.RemoveAt(listBox1.SelectedIndex);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                    }
                }


            }
        }
    }
        }
    