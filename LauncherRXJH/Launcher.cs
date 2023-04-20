using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LauncherRXJH
{
    public partial class Launcher : Form
    {
        // localhost IP address
        private readonly byte[] localhostIP = Encoding.ASCII.GetBytes("127.0.0.1");

        // String "Can Not Connect GameServer !!" in Client.exe
        private readonly byte[] PatchFind = { 0x43, 0x61, 0x6E, 0x20, 0x4E, 0x6F, 0x74, 0x20,
                                              0x43, 0x6F, 0x6E, 0x6E, 0x65, 0x63, 0x74, 0x20,
                                              0x47, 0x61, 0x6D, 0x65, 0x53, 0x65, 0x72, 0x76,
                                              0x65, 0x72, 0x20, 0x21, 0x21, 0x00, 0x00, 0x00 };

        private List<byte> byteList = new(new byte[32]);

        private readonly byte[] blankByte = { 0x00 };

        private readonly string clientExe = "Client.exe";
        private readonly string launcherIpPort = @"launcher.dat";

        private string serverIp;
        private string serverPort;

        private byte[] serverIpBytes;
        private byte[] fileContent;

        ProcessStartInfo runCLient = new();

        public Launcher()
        {
            InitializeComponent();

            // Check if File Exists
            if (File.Exists(launcherIpPort))
            {
                // Read File and Set TextBox strings
                string[] readLauncherFile = File.ReadAllLines(launcherIpPort, Encoding.UTF8);
                serverIpTextBox.Text = readLauncherFile[0];
                serverPortTextBox.Text = readLauncherFile[1];
            }
        }

        #region Find Bytes in Byte Array
        private bool DetectPatch(byte[] sequence, int position)
        {
            // Find byte array in clientExe and return true or false
            if (position + PatchFind.Length > sequence.Length) return false;
            for (int p = 0; p < PatchFind.Length; p++)
            {
                if (PatchFind[p] != sequence[position + p]) return false;
            }
            return true;
        }
        #endregion

        #region Write Byte Array to File
        private void PatchFile(string originalFile, string patchedFile)
        {
            // Set serverIp byte array
            serverIpBytes = Encoding.ASCII.GetBytes(serverIp);

            // Insert new IP and localhost IP into byte array
            byteList.InsertRange(PatchFind.Length, serverIpBytes);
            byteList.InsertRange(PatchFind.Length + serverIpBytes.Length, blankByte);
            byteList.InsertRange(PatchFind.Length + serverIpBytes.Length + blankByte.Length, localhostIP);
            byteList.InsertRange(PatchFind.Length + serverIpBytes.Length + blankByte.Length + localhostIP.Length, blankByte);
            byteList.ToArray();

            // Read file bytes.
            fileContent = File.ReadAllBytes(originalFile);

            // Detect and patch file.
            for (int p = 0; p < fileContent.Length; p++)
            {
                if (!DetectPatch(fileContent, p)) continue;

                for (int w = 0; w < byteList.ToArray().Length; w++)
                {
                    fileContent[p + w] = byteList[w];
                }
            }

            // Save it to location.
            File.WriteAllBytes(patchedFile, fileContent);
        }
        #endregion

        #region Start Game Button Functions
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            // Set IP and Port
            serverIp = serverIpTextBox.Text;
            serverPort = serverPortTextBox.Text;

            // Get IP and Port to write to launcher file
            string[] setIpPortStrings = { serverIp, serverPort };
            File.WriteAllLines(launcherIpPort, setIpPortStrings);

            // Check if clientExe exists
            if (File.Exists(clientExe))
            {
                // Try to patch clientExe
                try
                {
                    // Run Patching code; Format (input, output)
                    PatchFile(clientExe, clientExe);

                    // Sleep thread after patching
                    Thread.Sleep(200);
                }
                // If patching fails, display error and exit
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Environment.Exit(0);
                }
                
                // Run Client with command line arguments
                try
                {
                    runCLient = new ProcessStartInfo(clientExe) { Arguments = serverIp + " " + serverPort };
                    Process.Start(runCLient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                // Close launcher
                this.Close();
            }
            else
            {
                // If clientExe is missing, display error
                MessageBox.Show("Could not find " + clientExe + Environment.NewLine + "Please place Launcher inside Client folder!");
            }
        } 
        #endregion
    }
}
