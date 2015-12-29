using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace LojaServer
{
    public partial class Autorizacao : Form
    {
        private Socket socket;
        private Thread thread;
        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;
        TcpListener escuta;
    
        public Autorizacao()
        {
            InitializeComponent();
            thread = new Thread(new ThreadStart(RunServer));
            thread.Start();
        }
      
        private void AddToListBox(object oo)
        {
            Invoke(new MethodInvoker(delegate { listBoxpedidos.Items.Add(oo); }));
        }
        //Servidor
        public void RunServer()
        {
            try
            {
                IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2001); // IP,Porta
                escuta = new TcpListener(ipendpoint);
                escuta.Start();
                AddToListBox("Servidor habilitado e escutando porta..." + "LojaServer");
                socket = escuta.AcceptSocket();
                networkStream = new NetworkStream(socket); //fluxo de dados
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);

                AddToListBox("Conexão recebida!" + "LojaServer");
                //binaryWriter.Write("Conexão efetuada!");

                string messageReceived = "";
                do
                {
                    messageReceived = binaryReader.ReadString();
                    AddToListBox(messageReceived);
                    //MessageBox.Show("" + messageReceived + "");
                } while (socket.Connected);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de Comunicação!\n"+ex.Message);
            }
            finally
            {
                if (binaryReader != null)
                {
                    binaryReader.Close();
                }
                if (binaryWriter != null)
                {
                    binaryWriter.Close();
                }
                if (networkStream != null)
                {
                    networkStream.Close();
                }
                if (socket != null)
                {
                    socket.Close();
                }
                MessageBox.Show("Conexão finalizada!");
                AddToListBox("Conexão finalizada!");
            }
        }

        private void BotaoAutoriza_Click(object sender, EventArgs e)
        {
            try
            {
                binaryWriter.Write("Autorizado");
                
            }
            catch (SocketException sex)
            {
                MessageBox.Show("Não conectado ao Cliente!\n " + sex.Message, "Erro");
            }
            catch (Exception sex)
            {
                MessageBox.Show("Não conectado ao Cliente!\n " + sex.Message, "Erro");
            }
        }

        private void BotaoDesautoriza_Click(object sender, EventArgs e)
        {
            try
            {
                binaryWriter.Write("Desautorizado");
            }
            catch (SocketException sex)
            {
                MessageBox.Show("Não conectado ao Cliente!\n "+sex.Message, "Erro");
            }
            catch (Exception sex)
            {
                MessageBox.Show("Não conectado ao Cliente!\n "+sex.Message, "Erro");
            }
        }

        private void Autorizacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            escuta.Stop();
            Environment.Exit(0);
        }
    }
}
