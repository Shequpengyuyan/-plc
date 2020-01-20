using ActUtlTypeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLCModule
{
    public partial class Form1 : Form
    {

        ActUtlType _PLC = new ActUtlType();
        


        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _PLC.ActLogicalStationNumber = 404;
                int a = _PLC.Open();
                if (a == 0)
                {
                    richTextBox1.AppendText("链接PLC成功\r\n");
                }
                else
                {
                    richTextBox1.AppendText("链接PLC失败\r\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText(ex.Message + "\r\n");
            }

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
            int output;
            output = 0;
            for (int i = 0; i < 101; i++)
            {
                _PLC.ReadDeviceBlock("D"+i , 1, out output);
                richTextBox1.AppendText(output + "\r\n");
            }
            

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
          //  richTextBox1.Text = " ";
         //   int lplData;
          //  lplData =Convert .ToInt32(txtAddress.Text);
            short[] datas = new short[100];
            for (int i = 0; i < 100; i++)
            {
                datas[i] = (short)i;
               // _PLC.ReadBuffer
            }
            _PLC.WriteDeviceBlock2("D300", 100, ref datas[0]);
            richTextBox1.AppendText("输入成功" + "\r\n");
        }
    }
      
    

}



