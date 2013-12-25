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
using IronPython;
using Microsoft.Scripting;
using System.Diagnostics;
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
        public static void RunPythonScript(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;// 获得python文件的绝对路径     
            p.StartInfo.FileName = @"python";
            string sArguments = path;
            if (teps.Length > 0)
            {
                foreach (string sigstr in teps)
                {
                    sArguments += " " + sigstr;//传递参数
                }
            }
            if (args.Length > 0)
            {

                sArguments += " " + args;

            }

            p.StartInfo.Arguments = sArguments;

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardOutput = false;

            p.StartInfo.RedirectStandardInput = false;

            p.StartInfo.RedirectStandardError = false;

            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            Console.ReadLine();
            p.WaitForExit();
        }
        //输出打印的信息
        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                AppendText(e.Data + Environment.NewLine);
            }
        }
        public delegate void AppendTextCallback(string text);
        public static void AppendText(string text)
        {
            Console.WriteLine(text);

        }
        //dosCommand Dos命令语句  
        public string Execute(string dosCommand)
        {
            return Execute(dosCommand, 0);
        }
        /// <summary>  
        /// 执行DOS命令，返回DOS命令的输出  
        /// </summary>  
        /// <param name="dosCommand">dos命令</param>  
        /// <param name="milliseconds">等待命令执行的时间（单位：毫秒），  
        /// 如果设定为0，则无限等待</param>  
        /// <returns>返回DOS命令的输出</returns>  
        public static string Execute(string command, int seconds)
        {
            string output = ""; //输出字符串  
            if (command != null && !command.Equals(""))
            {
                Process process = new Process();//创建进程对象  
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";//设定需要执行的命令  
                startInfo.Arguments = "/C " + command;//“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动  
                startInfo.RedirectStandardInput = false;//不重定向输入  
                startInfo.RedirectStandardOutput = true; //重定向输出  
                startInfo.CreateNoWindow = true;//不创建窗口  
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())//开始进程  
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();//这里无限等待进程结束  
                        }
                        else
                        {
                            process.WaitForExit(seconds); //等待进程结束，等待时间为指定的毫秒  
                        }
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出  
                    }
                }
                catch
                {
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }  
        private void btn_create_Click(object sender, EventArgs e)
        {
            if (File.Exists(exeFile) && File.Exists(pdfFile)) {
                FileStream exeFileStream = null;
                FileStream pdfFileStream = null;
                string[] strArr = {pdfFile};//参数列表
                //string sArguments = @"sud0.py";//这里是python的文件名字
                //RunPythonScript(sArguments, "-u", strArr);
                // var engine = IronPython.Hosting.Python.CreateEngine();
                // engine.CreateScriptSourceFromFile("sud0.py").Execute();
                //note: blank between args
                string dosCommand = "sud0.py" + " " + pdfFile + " " + "-u";
                Console.WriteLine(Execute(dosCommand));
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
