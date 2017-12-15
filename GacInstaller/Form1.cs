using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
namespace GacInstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Event();


            
        }
        public void Event()
        {
            System.EnterpriseServices.Internal.Publish foo = new
   System.EnterpriseServices.Internal.Publish();
            string folder = Settings1.Default.Folder;
            DirectoryInfo info = new DirectoryInfo(folder);

            foreach (var item in info.GetFiles())
            {
                if (item.Extension.Equals(".dll") && !item.Name.Contains("Microsoft"))
                {
                    foo.GacRemove(item.FullName);
                    foo.GacInstall(item.FullName);
                }
                else
                {
                }

            } 
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Event();


        }
    }
}
