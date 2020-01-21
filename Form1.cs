using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GlobalKeyHook.KeyboardHook;

namespace GlobalKeyHook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            startListen();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            stopListen();
        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyDown
            Console.WriteLine("按下按鍵" + e.KeyValue);
        }

        //按鍵鉤子
        private KeyEventHandler myKeyEventHandeler = null;
        private KeyboardHook k_hook = new KeyboardHook();

        //開始全域鍵盤監聽
        public void startListen()
        {
            myKeyEventHandeler = new KeyEventHandler(hook_KeyDown);
            k_hook.KeyDownEvent += myKeyEventHandeler;//鉤住鍵按下
            k_hook.Start();//安裝鍵盤鉤子
        }
        //停止全域鍵盤監聽
        public void stopListen()
        {
            if (myKeyEventHandeler != null)
            {
                k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按鍵事件
                myKeyEventHandeler = null;
                k_hook.Stop();//關閉鍵盤鉤子
            }
        }
    }
}
