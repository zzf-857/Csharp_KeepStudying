using System;
using System.Timers;
using System.Windows.Forms;

namespace DelegateandEvent
{
    //事件五大角色
    public class MyEvent
    {

    }
    //事件的响应者
    class Controller
    {
        //事件的拥有者
        private Form form;

        //事件的处理器
        public Controller(Form form)
        {
            if (form != null)
            {
                this.form = form;
                //Click为事件，+=为事件订阅
                this.form.Click += this.FormClicked;
            }
        }

        //事件处理器
        private void FormClicked(object sender, EventArgs e)
        {
            this.form.Text = DateTime.Now.ToString();
        }
    }

}
