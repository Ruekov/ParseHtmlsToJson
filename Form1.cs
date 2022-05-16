using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ParseHtmls
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void filesPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                TxtBoxPath.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void procedureStart_Click(object sender, EventArgs e)
        {
            BttnProcedure.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();


            Stream myStream;
            SaveFileDialog saveJsonProcedureFileDialog = new SaveFileDialog();

            saveJsonProcedureFileDialog.Filter = "JSON files (*.json)|*.json";
            saveJsonProcedureFileDialog.FilterIndex = 2;
            saveJsonProcedureFileDialog.RestoreDirectory = true;

            if (saveJsonProcedureFileDialog.ShowDialog() == DialogResult.OK)
            {
                ParseToJson parseToJson = new ParseToJson();

                parseToJson.getAllHtmls(TxtBoxPath.Text);

                if ((myStream = saveJsonProcedureFileDialog.OpenFile()) != null)
                {
                    JsonSerializer.SerializeAsync(myStream, parseToJson.phrases);
                    myStream.Close();
                }
            }

            BttnProcedure.Enabled = true;
            Cursor.Current = Cursors.Default;
            Application.DoEvents();
        }
    }
}
