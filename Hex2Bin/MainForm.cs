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

namespace Hex2Bin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void txtHexFile_DoubleClick(object sender, EventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "请选择你要打开的hex文件";
            //op.Multiselect = true;
            string str = @"D:\temp\MdkHexFiles";
            op.InitialDirectory = str;
            op.Filter = "hex文件|*.hex";  
            op.ShowDialog();
 
            //try
            //{
                string pth = op.FileName;
                txtHexFile.Text = pth;
                txtBinFile.Text = pth.Substring(0, pth.Length - 4) + ".bin";
                ReadHexFile(pth);
            //}
            //catch
            //{ 
            //    return;
            //}  
        }

        public bool ReadHexFile(string fileName)
        {
            if (fileName == null || fileName.Trim() == "")  //文件存在
            {
                return false;
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Open))  //open file
            {
                StreamReader HexReader = new StreamReader(fs);    //读取数据流
                string szLine = "";
                string szHex = "";
                string szAddress = "";
                string szLength = "";
                while (true)
                {
                    szLine = HexReader.ReadLine();      //读取Hex中一行
                    if (szLine == null) { break; }          //读取完毕，退出
                    if (szLine.Substring(0, 1) == ":")    //判断首字符是”:”
                    {
                        if (szLine.Substring(1, 8) == "00000001") { break; }  //文件结束标识
                        //直接解析数据类型标识为 : 00 和 01 的格式
                        if ((szLine.Substring(8, 1) == "0") || (szLine.Substring(8, 1) == "1"))
                        {
                            szHex += szLine.Substring(9, szLine.Length - 11);  //所有数据分一组 
                            szAddress += szLine.Substring(3, 4); //所有起始地址分一组
                            szLength += szLine.Substring(1, 2); //所有数据长度归一组
                        }
                    }
                }
                //将数据字符转换为Hex，并保存在数组 szBin[]
                Int32 j = 0;
                Int32 Length = szHex.Length;      //获取长度
                byte[] szBin = new byte[Length / 2];
                for (Int32 i = 0; i < Length; i += 2)
                {
                    szBin[j] = (byte)Int16.Parse(szHex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);   //两个字符合并一个Hex 
                    j++;
                }
                //将起始地址的字符转换为Hex，并保存在数组 szAdd []
                j = 0;
                Length = szAddress.Length;      //get bytes number of szAddress
                Int32[] szAdd = new Int32[Length / 4];
                for (Int32 i = 0; i < Length; i += 4)
                {
                    szAdd[j] = Int32.Parse(szAddress.Substring(i, 4), System.Globalization.NumberStyles.HexNumber);  //两个字符合并一个Hex
                    j++;
                }
                //将长度字符转换为Hex，并保存在数组 szLen []
                j = 0;
                Length = szLength.Length;      //get bytes number of szAddress
                byte[] szLen = new byte[Length / 2];
                for (Int32 i = 0; i < Length; i += 2)
                {
                    szLen[j] = (byte)Int16.Parse(szLength.Substring(i, 2), System.Globalization.NumberStyles.HexNumber); // merge two bytes to a hex number
                    j++;
                }
                array_show_data(szAdd, szBin, szLen);   //对重排后的数据显示
            }
            return true;
        }

        private void array_show_data(Int32[] address, byte[] data, byte[] length)
        {
            //1.整理数据所需参数
            string temp = "";
            string stringshow = "  ";
            int jcount = 0;
            fileDataShow.Items.Clear();      //清除已有数据
            temp = "";
            fileDataShow.Items.Add(temp);    //添加一个空行
            int max_address = (address[(address.Length) - 1]) + 16;
            byte[] all_show_data = new byte[max_address];  //存储解析完成的数据数组
            for (Int32 i = 0; i < all_show_data.Length; i++) { all_show_data[i] = 255; }  //默认全为0

            //2.从address[]数组中获取HEX对应地址
            for (Int32 i = 0; i < address.Length; i++)
            {
                if (i >= 1) { jcount += length[i - 1]; }  //从length[]数组中获取数据对应的长度大小
                for (int j = 0; j < length[i]; j++)
                {
                    all_show_data[address[i] + j] = data[jcount + j]; //all_show_data[]数组中添加数据
                }
            }
            //3.在listbox控件fileDataShow中显示整理后的值（对应自定义的控件名称）
            for (Int32 i = 0; i < (Int32)((all_show_data.Length) / 16); i++)
            {
                jcount = i * 16;  //每行16个数据，根据需要设置
                //左侧显示具体地址 
                temp = Convert.ToString(jcount, 16).PadLeft(4, '0').ToUpper();
                stringshow = temp + "h" + "\t";
                for (Int32 j = 0; j < 16; j++)
                {
                    temp = Convert.ToString(all_show_data[jcount + j], 16).PadLeft(2, '0').ToUpper(); //转换为2位对其字符
                    stringshow += temp + " ";
                }
                fileDataShow.Items.Add(stringshow);    //fileDataShow中添加数据
                stringshow = "  ";
            }

            string path = txtBinFile.Text;
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Write(all_show_data, 0, all_show_data.Length);
            fs.Close();
        }
    }
}
