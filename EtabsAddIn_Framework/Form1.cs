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
using ETABSv17;

namespace EtabsAddIn_Framework
{
    public partial class Form1 : Form
    {
        private cPluginCallback _Plugin = null;
        private cSapModel _SapModel = null;

        public Form1(ref cSapModel SapModel, ref cPluginCallback Plugin)
        {
            _Plugin = Plugin;
            _SapModel = SapModel;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Plugin.Finish(0);
        }

        private void openCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                pathBox.Text = fileName;
                var reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var value = line.Split(' ');
                    foreach (string s in value)
                    {
                        watchBox.Items.Add(s);
                    }
                }

            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
           
            cPlugin cp = new cPlugin();
            string[] csvData = watchBox.Items.OfType<string>().ToArray();
            cp.createFrame(0, _SapModel, csvData);
          //cp.runSampleModel(0, _SapModel);
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
