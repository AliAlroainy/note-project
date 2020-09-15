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


namespace note
{
    public partial class Form1 : Form
    {
        //string path = "";
        private bool isFileAlreadySaved;
        private bool isFileDirty;
        private String currOpenFileName;
        FontDialog fontdialog = new FontDialog();
        public static string findtext;


        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                isFileDirty = true;
                redoToolStripMenuItem1.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
                pastToolStripMenuItem.Enabled = true;
                undoToolStripMenuItem1.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem1.Enabled = true;
                pasteToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                searchToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem1.Enabled = true;
                redoToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;


            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
               
                undoToolStripMenuItem1.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                //pasteToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
               
                //PasteToolStripButton.Enabled = false;
             
                copyToolStripMenuItem1.Enabled = false;
                //pasteToolStripMenuItem1.Enabled = false;
                cutToolStripMenuItem1.Enabled = false;
                searchToolStripMenuItem.Enabled = false;
            }
        }

        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void selcatAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void conacatWithUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
            DialogResult result = openfiledialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(openfiledialog.FileName) == ".txt")
                    richTextBox1.LoadFile(openfiledialog.FileName, RichTextBoxStreamType.PlainText);
                if (Path.GetExtension(openfiledialog.FileName) == ".rtf")
                    richTextBox1.LoadFile(openfiledialog.FileName, RichTextBoxStreamType.RichText);
              
                isFileAlreadySaved = true;
                isFileDirty = false;
                currOpenFileName = openfiledialog.FileName;
                UndoRedoEnabled(false);
               

            }
        }

        private void UndoRedoEnabled(bool enable)
        {
            undoToolStripMenuItem.Enabled = enable;
            redoToolStripMenuItem.Enabled = enable;
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileMenue();
        }

        private void SaveFileMenue()
        {
            if (isFileAlreadySaved)
            {
                if (Path.GetExtension(currOpenFileName) == ".txt")
                    richTextBox1.SaveFile(currOpenFileName, RichTextBoxStreamType.PlainText);

                if (Path.GetExtension(currOpenFileName) == ".rft")
                    richTextBox1.SaveFile(currOpenFileName, RichTextBoxStreamType.RichText);
                
                isFileDirty = false;

            }
            else
            {
                if (isFileDirty)
                {
                    SaveAsFileMenue();

                }
                else
                {
                    ClearScreen();
                }
            }
        }
        private void ClearScreen()
        {
            richTextBox1.Clear();
            this.Text = "Untitled - Notepad";
            isFileDirty = false;
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;

            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cr.Color;
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this note pade is first vergion ..come on man it's easy to use ");
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("done by eng.Ali AL-Roainy .. aliabduh.2020@gmail.com ");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("welcome ^_^ ..");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f = new Font("Arial",15,FontStyle.Regular);
            e.Graphics.DrawString(richTextBox1.Text, f,Brushes.Black,10,10);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text=="")
            MessageBox.Show("empty");
            else
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                MessageBox.Show("empty");
            else
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search r2 = new search();
            r2.ShowDialog();

            if (findtext != "")
            {
                int d = richTextBox1.Find(findtext);
            }
            else
            {
                MessageBox.Show("not found word for search it,enter word", "notebade", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsFileMenue();
        }


        private void SaveAsFileMenue()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog.FileName) == ".txt")
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);

                if (Path.GetExtension(saveFileDialog.FileName) == ".rft")
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                
                isFileAlreadySaved = true;
                isFileDirty = false;
                currOpenFileName = saveFileDialog.FileName;

            }
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
            }
        }

        private void pastToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.SelectedText = Clipboard.GetText();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                Clipboard.SetText(richTextBox1.SelectedText);
               richTextBox1.SelectedText = "";
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();

        }

        private void redoToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


    }
}
