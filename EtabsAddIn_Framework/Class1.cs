using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ETABSv17;

namespace EtabsAddIn_Framework
{
    public class cPlugin
    {
        public void Main(ref cSapModel SapModel, ref cPluginCallback ISapPlugin)
        {
            Form1 form = new Form1(ref SapModel, ref ISapPlugin);
            form.Show();
        }
        public long Info(ref string text)
        {
            text = "Etabs plug create by Glenn Cai";
            return 0;
        }

        public string Message()
        {
            string s = "This is a message";
            return s;
        }

        public void runSampleModel(int ret, cSapModel SapModel)
        {
            //set the following flag to true to attach to an existing instance of the program 
            //otherwise a new instance of the program will be started 

            bool AttachToInstance;
            AttachToInstance = false;

            //set the following flag to true to manually specify the path to ETABS.exe
            //this allows for a connection to a version of ETABS other than the latest installation
            //otherwise the latest installed version of ETABS will be launched
            bool SpecifyPath;
            SpecifyPath = false;

            //if the above flag is set to true, specify the path to ETABS below
            //string ProgramPath;
            //ProgramPath = "C:\\Program Files (x86)\\Computers and Structures\\ETABS 17\\ETABS.exe";

            //full path to the model 
            //set it to an already existing folder 
            string ModelDirectory = "C:\\Users\\gcai\\Desktop\\ETABSAPI";
            try
            {
                System.IO.Directory.CreateDirectory(ModelDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create directory: " + ModelDirectory);
            }

            string ModelName = "ETABS_API_Example.edb";
            string ModelPath = ModelDirectory + System.IO.Path.DirectorySeparatorChar + ModelName;

            //dimension the ETABS Object as cOAPI type
            ETABSv17.cOAPI myETABSObject = null;

            //Use ret to check if functions return successfully (ret = 0) or fail (ret = nonzero) 
 
            if (AttachToInstance)
            {
                //attach to a running instance of ETABS 
                try
                {
                    //get the active ETABS object
                    myETABSObject = (ETABSv17.cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No running instance of the program found or failed to attach.");
                    return;
                }
            }

            ret = SapModel.InitializeNewModel();
            //Create steel deck template model
            ret = SapModel.PropFrame.ImportProp("MT2X3", "A992Fy50", "AISC14.xml", "MT2X3");
            //ret = SapModel.File.NewSteelDeck(2, 12, 12, 3, 3, 24, 24);
            //ret = SapModel.File.NewGridOnly(2, 12, 12, 3, 3, 24, 24);
            ret = SapModel.File.NewBlank();
            double length = 96;//inch
            double xi = 0;
            double yi = 0;
            double zi = 0;
            double xj = length;
            double yj = 0;
            double zj = 0;
            string name = "Test Frame";
            ret = SapModel.FrameObj.AddByCoord(xi, yi, zi, xj, yj, zj, ref name,"MT2X3");
            //Save model
            ret = SapModel.File.Save(ModelPath);

            //Run analysis
            //ret = SapModel.Analyze.RunAnalysis();

            //Close ETABS
            //myETABSObject.ApplicationExit(false);
            //Check ret value 

            if (ret == 0)
            {
                MessageBox.Show("API script completed successfully.");
            }
            else
            {
                MessageBox.Show("API script FAILED to complete.");
            }
    }

        public void createFrame(int ret, cSapModel SapModel, String[] csvData)
        {
            double factor = 12;//feet to inch
            foreach (string line in csvData)
            {
                string[] split = line.Split(',');
                double xi = Convert.ToDouble(split[0])*factor;
                double yi = Convert.ToDouble(split[1])*factor;
                double zi = Convert.ToDouble(split[2])*factor;
                double xj = Convert.ToDouble(split[3])*factor;
                double yj = Convert.ToDouble(split[4])*factor;
                double zj = Convert.ToDouble(split[5])*factor;
                string name = split[6];
                string proName = split[7];
                ret = SapModel.FrameObj.AddByCoord(xi, yi, zi, xj, yj, zj, ref name, proName);
            }

        }
        private string[] GetFrameNameList(int ret, cSapModel SapModel)
        {
            int numberNames = 0;
            string [] uniqueNames = null;
            ret = SapModel.FrameObj.GetNameList(ref numberNames, ref uniqueNames);
            return uniqueNames;
        }

        private void GetSectionData(int ret, cSapModel SapModel, out List<string> sectionLoadList)
        {
            string[] uniqueNames =  GetFrameNameList(ret, SapModel);

            sectionLoadList = new List<string>();
            List<string> beamList = new List<string>();
            List<string> columnList = new List<string>();

            foreach (string uniqueName in uniqueNames)
            {
                string frameLabel = "";
                string frameStory = "";
                string category = "";
                string sectionToLoad = "";
                ret = SapModel.FrameObj.GetLabelFromName(uniqueName, ref frameLabel, ref frameStory);

                if (frameLabel.Contains("B") || frameLabel.Contains("D"))
                {
                    category = "BEAM";
                    string propName = "";
                    string sAuto = "";
                    ret = SapModel.FrameObj.GetSection(uniqueName, ref propName, ref sAuto);
                }

                if (frameLabel.Contains("C"))
                {
                    category = "COLUMN";
                    string propName = "";
                    string sAuto = "";
                    ret = SapModel.FrameObj.GetSection(uniqueName, ref propName, ref sAuto);


                }
            }
           

        }

    }
}
