namespace Notepad
{
    public partial class Notepad : Form /* Inherit from Form as it have capability of form */
    {

        /* Flag to check if file opened or not */
        string Path;
        /* Flag to check if any change occurs in file */
        bool IsChange;
        float fontSize;

        /* To carry text cut,copy,.. */
        string storage;

        /*
         *Form is a representation of class.
         *Each control into the form is also a representation of class.
         */
        public Notepad()
        {
            InitializeComponent();

            Path = null;
            IsChange = false;
            fontSize = RichTB.Font.Size;
            storage = null;


            /*** This code will be changed when save code made ***/
            this.Text = "Untitled - Notepad";

            //if (IsChange == true)
            //{
            //    this.Text += "*";
            //}


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            IsChange = true;
        }

        private void arToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "مفكرة - بلاعنوان";

            this.fileToolStripMenuItem.Text = "ملف";
            this.newToolStripMenuItem.Text = "جديد";
            this.openToolStripMenuItem.Text = "فتح";
            this.saveToolStripMenuItem.Text = "حفظ";
            this.saveAsToolStripMenuItem.Text = "..حفظ ك";
            this.editToolStripMenuItem.Text = "تعديل";
            this.cutToolStripMenuItem.Text = "قص";
            this.copyToolStripMenuItem.Text = "نسخ";
            this.pasteToolStripMenuItem.Text = "لصق";
            this.deleteToolStripMenuItem.Text = "حذف";
            this.viewToolStripMenuItem.Text = "عرض";
            this.zoomToolStripMenuItem.Text = "حجم";
            this.zoomInToolStripMenuItem.Text = "تكبير";
            this.zoomOutToolStripMenuItem.Text = "تصغير";
            this.formatToolStripMenuItem.Text = "الشكل";
            this.fontToolStripMenuItem.Text = "الخط";
            this.colorToolStripMenuItem.Text = "اللون";
            this.languageToolStripMenuItem.Text = "اللغة";
            this.arToolStripMenuItem.Text = "عربي";
            this.eNToolStripMenuItem.Text = "انجليزي";


        }

        private void eNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;

            this.Text = "Untitled - Notepad";
            this.fileToolStripMenuItem.Text = "File";
            this.newToolStripMenuItem.Text = "New";
            this.openToolStripMenuItem.Text = "Open";
            this.saveToolStripMenuItem.Text = "Save";
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.editToolStripMenuItem.Text = "Edit";
            this.cutToolStripMenuItem.Text = "Cut";
            this.copyToolStripMenuItem.Text = "Copy";
            this.pasteToolStripMenuItem.Text = "Paste";
            this.deleteToolStripMenuItem.Text = "Delete";
            this.viewToolStripMenuItem.Text = "View";
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.formatToolStripMenuItem.Text = "Format";
            this.fontToolStripMenuItem.Text = "Font";
            this.colorToolStripMenuItem.Text = "Color";
            this.languageToolStripMenuItem.Text = "Language";
            this.arToolStripMenuItem.Text = "AR...";
            this.eNToolStripMenuItem.Text = "EN..";

        }

        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( Path == null && IsChange == true)
            {
                DialogResult result = MessageBox.Show("Do you want save changes?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(RichTB.Text != "")
            {
                DialogResult result = MessageBox.Show("Do you want save changes?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(null, null);
                    this.Text = "Untitled - Notepad";
                }
            }
            
            Path = null;
            RichTB.Clear();
            IsChange = false;

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* check opened dialog if ok clicked or cancel */
            if(SaveFD.ShowDialog() == DialogResult.OK)
            {
                /* Save file with declared name & format in path which detected in FileName */
                RichTB.SaveFile(SaveFD.FileName);

                Path = SaveFD.FileName;
                IsChange = false;

                this.Text = System.IO.Path.GetFileNameWithoutExtension(SaveFD.FileName) + " - Notepad";

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(OpenFD.ShowDialog() == DialogResult.OK)
            {
                /* Load selected file in rich textBox */
                RichTB.LoadFile(OpenFD.FileName);

                /* Edit title of your program */
                this.Text = System.IO.Path.GetFileNameWithoutExtension(OpenFD.SafeFileName)+" - Notepad";

                /* Store path of opened file */
                Path = OpenFD.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //created => Save As.
           // opened => save.

            /* If file is opened */
            if(Path != null)
            {
                /* Save changes at stored path */
                RichTB.SaveFile(Path);
                IsChange = false;

            }
            else /* First save acts as Save-As */
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(IsChange == false)
            {
                this.Close();
            }
            else
            {
                this.Notepad_FormClosing(null, null);
            }
        }


        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTB.Font = new Font(RichTB.Font.FontFamily, fontSize+=3 , RichTB.Font.Style);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTB.Font = new Font(RichTB.Font.FontFamily, fontSize -= 3, RichTB.Font.Style);

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FontD.ShowDialog() == DialogResult.OK)
            {
                if(RichTB.SelectedText != "")
                {
                    RichTB.SelectionFont = FontD.Font;
                }
                else
                {
                    RichTB.Font = FontD.Font;
                }
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ColorD.ShowDialog() == DialogResult.OK)
            {
                if(RichTB.SelectedText != "")
                {
                    RichTB.SelectionColor = ColorD.Color;
                }
                else
                {
                    RichTB.ForeColor = ColorD.Color;
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RichTB.SelectedText != "")
            {
                storage = RichTB.SelectedText;
            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
                copyToolStripMenuItem_Click(null, null);
                RichTB.SelectedText = "";
            
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTB.SelectedText = storage;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTB.SelectedText = "";

        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ColorD.ShowDialog() == DialogResult.OK)
            {

                RichTB.BackColor = ColorD.Color;
            }
        }
    }
}