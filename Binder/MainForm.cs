using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binder
{
    public partial class BinderForm : Form
    {

        private string exeFile;
        private string pdfFile;

        public BinderForm()
        {
            InitializeComponent();
        }  


        private void btn_EXE_Click(object sender, EventArgs e)
        {
            //选择文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            //文件格式
            openFileDialog.Filter = "EXE文件|*.exe";
            //还原当前目录
            openFileDialog.RestoreDirectory = true;
            //默认的文件格式
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                exeFile = openFileDialog.FileName;
                txtBx_exe.Text = exeFile; 
            }
            else
            {
                txtBx_exe.Text = "";
                exeFile = "";
            }
        }

        private void BinderForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            //选择文件
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            //文件格式
            openFileDialog.Filter = "PDF文件|*.pdf";
            //还原当前目录
            openFileDialog.RestoreDirectory = true;
            //默认的文件格式
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pdfFile = openFileDialog.FileName;
                txtBx_pdf.Text = pdfFile;
            }
            else
            {
                pdfFile = "";
                txtBx_pdf.Text = "";
            }
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            if (File.Exists(exeFile) && File.Exists(pdfFile)) {
                FileStream exeFileStream = null;
                FileStream pdfFileStream = null;
                try
                {
                    byte[] buffer = new byte[1024];
                    byte[] offsetChar = new byte[8];
                    for (int i = 0; i < 8; i++)
                    {
                        offsetChar[i] = (byte)'0';
                    }

                    exeFileStream = new FileStream(exeFile,FileMode.Open);
                   // BinaryReader exeReader  = new BinaryReader(exeFileStream, Encoding.ASCII);

                    pdfFileStream = new FileStream(pdfFile, FileMode.Append, FileAccess.Write);
                   // BinaryWriter pdfWriter = new BinaryWriter(pdfFileStream, Encoding.ASCII);

                    long offset = pdfFileStream.Position;
                    Console.WriteLine("offset:" + offset);
                    string offsetStr = offset.ToString();
                    for (int i = offsetStr.Length - 1, j = 7; i >= 0 && j >= 0; i--, j--) {
                        offsetChar[j] = (byte)offsetStr[i];
                    }

                    int numRead;
                    do
                    {
                        numRead = exeFileStream.Read(buffer, 0, 1024);
                        pdfFileStream.Write(buffer, 0, numRead);
                    } while (numRead == 1024);

                    pdfFileStream.Write(offsetChar, 0, 8);
                    //write the offset of exefile to the end of the pdf.

                    MessageBox.Show("绑定成功！");

                    
                } catch(System.IO.IOException){

                } catch(System.NotSupportedException) {
                    
                }

                finally
                {

                    if (exeFileStream != null)
                    {
                        exeFileStream.Close();
                    }
                    if (pdfFileStream != null)
                    {
                        pdfFileStream.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择文件！" );
            }
        }
    }
}
