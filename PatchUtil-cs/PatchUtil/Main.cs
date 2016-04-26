using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Main : Form
    {
        private String newFileName, oldFileName,saveFileName;

        public Main()
        {
            InitializeComponent();
            this.MaximizeBox = false;//使最大化窗口失效
        }       

        private void btnSelectOldFile_Click(object sender, EventArgs e)
        {
            DialogResult dr=openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK) {
                if (((Button)sender).Name == btnSelectOldFile_1.Name) {
                    tbOldFileName_1.Text = openFileDialog1.FileName;
                } else {
                    tbOldFileName_2.Text= openFileDialog1.FileName;
                }
                oldFileName = openFileDialog1.FileName;
            }
            
        }

        private void btnSelectNewFile_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {                
                if (((Button)sender).Name == btnSelectNewFile_1.Name)
                {
                    tbNewFileName_1.Text = openFileDialog1.FileName;                    
                }
                else {
                    tbNewFileName_2.Text = openFileDialog1.FileName;
                }
                newFileName = openFileDialog1.FileName;
            }
        }
        private void btnSelectSaveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = genPatchFileName(((Button)sender).Name == btnSelectSaveFile_1.Name ? false : true,Path.GetFileName(oldFileName),Path.GetFileName(newFileName));
            DialogResult dr = saveFileDialog1.ShowDialog();
            
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                if (((Button)sender).Name == btnSelectSaveFile_1.Name)
                {
                    tbSaveFileName1.Text = saveFileDialog1.FileName;
                }
                else
                {
                    tbSaveFileName2.Text = saveFileDialog1.FileName;
                }
                saveFileName = saveFileDialog1.FileName;
            }
        }
        private void btnPatch_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == btnGenPatch.Name)
            {
                genPatchFile();
            }
            else {
                applyPatchFile();
            }
        }
        public bool genPatchFile() {
            return onPreExecute(false);           
        }
        public bool applyPatchFile()
        {
            return onPreExecute(true); ;
        }
        public bool onPreExecute(bool isApplyPatch) {
            String oldFileName,newFileName,saveFileName;
            StringBuilder fileNameCmd = new StringBuilder(System.AppDomain.CurrentDomain.BaseDirectory);//"C:\\Users\\Penn\\Documents\\Visual Studio 2015\\Projects\\WindowsFormsApplication2\\WindowsFormsApplication2\\bin\\Debug\\"
            StringBuilder argCmd = new StringBuilder();
            fileNameCmd.Append("lib\\");           
            if (isApplyPatch) {
                fileNameCmd.Append("bspatch.exe");
                oldFileName = tbOldFileName_2.Text;
                newFileName = tbNewFileName_2.Text;
                saveFileName = tbSaveFileName2.Text;
            }
            else {
                fileNameCmd.Append("bsdiff.exe");
                oldFileName = tbOldFileName_1.Text;
                newFileName = tbNewFileName_1.Text;
                saveFileName = tbSaveFileName1.Text;
            }
            argCmd.Append("\"");
            argCmd.Append(oldFileName);
            argCmd.Append("\"");
            argCmd.Append("  ");
            
            if (isApplyPatch)
            {
                argCmd.Append("\"");
                argCmd.Append(saveFileName);
                argCmd.Append("\"");
                argCmd.Append("  ");
                argCmd.Append("\"");
                argCmd.Append(newFileName);
                argCmd.Append("\"");

            }
            else {
                argCmd.Append("\"");
                argCmd.Append(newFileName);
                argCmd.Append("\"");
                argCmd.Append("  ");
                argCmd.Append("\"");
                argCmd.Append(saveFileName);
                argCmd.Append("\"");
            }
            
            return onExecute(fileNameCmd.ToString(), argCmd.ToString());
        }

       

        public String genPatchFileName(bool isApplyPatch,String oldFileName, String newFileName) {

            StringBuilder sbPatchFileName = new StringBuilder();
            //sbPatchFileName.Append("\"");       
            //sbPatchFileName.Append(directoryName);     
            //if(!isApplyPatch) sbPatchFileName.Append("patch\\");
            //if (!Directory.Exists(sbPatchFileName.ToString().Trim('\"')))
            //{
            //    Directory.CreateDirectory(sbPatchFileName.ToString().Trim('\"'));
            //}
            sbPatchFileName.Append(oldFileName.Substring(0, oldFileName.LastIndexOf('.')));
            sbPatchFileName.Append("_");
            sbPatchFileName.Append(newFileName.Substring(0, newFileName.LastIndexOf('.')));
            sbPatchFileName.Append(!isApplyPatch? ".patch" :oldFileName.Substring(oldFileName.LastIndexOf('.')));
            //sbPatchFileName.Append("\"");
            return sbPatchFileName.ToString();
        }
       
        public bool onExecute(String fileName,String arguments) {
            try
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = fileName;
                p.StartInfo.Arguments = arguments;
                p.Start();
            }
            catch(Exception e) {
                return false;
            }
            return true;
        }

        private void openWebSite(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", ((Label)sender).Text);
        }

    }
   

}
