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
using System.Diagnostics;

namespace Album_Extractor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FromBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                if (File.Exists(path))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FromBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                FromBox.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }
        }

        private void ToBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                if (Directory.Exists(path))
                {
                    e.Effect = DragDropEffects.Copy;
                }

                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ToBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                ToBox.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }
        }

        private void FromBrowse_Click(object sender, EventArgs e)
        {
            if (FromBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                FromBox.Text = FromBrowseDialog.FileName;
            }
        }

        private void ToBrowse_Click(object sender, EventArgs e)
        {
            if (ToBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                ToBox.Text = ToBrowseDialog.SelectedPath;
            }
        }

        private void RunButton_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void RunButton_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (paths.Length == 1)
                {
                    if (File.Exists(paths[0]))
                    {
                        FromBox.Text = paths[0];
                    }
                    else if (Directory.Exists(paths[0]))
                    {
                        ToBox.Text = paths[0];
                    }
                }
                else
                {
                    foreach (string path in paths)
                    {
                        if (File.Exists(path))
                        {
                            FromBox.Text = path;
                        }
                    }

                    foreach (string path in paths)
                    {
                        if (Directory.Exists(path))
                        {
                            ToBox.Text = path;
                        }
                    }
                }
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists(FromBox.Text))
            {
                LogBox.Text = "上のテキストボックスにはファイルのパスを入力してください。";
            }
            else if (!Directory.Exists(ToBox.Text))
            {
                LogBox.Text = "下のテキストボックスにはディレクトリのパスを入力してください。";
            }
            else
            {
                string arguments = $"\"{FromBox.Text}\" \"{ToBox.Text}\" {F.Value} {S.Value}";

                using (var process = new Process())
                {
                    process.StartInfo = new ProcessStartInfo
                    {
                        FileName = @"AE.exe",
                        Arguments = arguments,
                    };
                    process.Start();
                    process.WaitForExit();
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            GroupBox.Enabled = CheckBox.Checked;
        }
    }
}
