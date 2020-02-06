using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuranSeving.Seveing
{
    public partial class Frm_other_red : KryptonForm
    {
        public Frm_other_red()
        {
            InitializeComponent();
        }

        private void kryptonTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Node1":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\1.rtf");
                    break;
                case "Node2":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\2.rtf");
                    break;
                case "Node3":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\3.rtf");
                    break;
                case "Node4":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\4.rtf");
                    break;
                case "Node5":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\5.rtf");
                    break;
                case "Node6":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\6.rtf");
                    break;
                case "Node7":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\7.rtf");
                    break;
                case "Node8":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\8.rtf");
                    break;
                case "Node9":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\9.rtf");
                    break;
                case "Node10":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\10.rtf");
                    break;
                case "Node11":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\11.rtf");
                    break;
                case "Node12":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\12.rtf");
                    break;
                case "Node13":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\13.rtf");
                    break;
                case "Node14":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\14.rtf");
                    break;
                case "Node15":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\15.rtf");
                    break;
                case "Node16":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\16.rtf");
                    break;
                case "Node17":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\17.rtf");
                    break;
                case "Node18":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\18.rtf");
                    break;
                case "Node19":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\19.rtf");
                    break;
                case "Node20":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\20.rtf");
                    break;
                case "Node21":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\21.rtf");
                    break;
                case "Node22":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\22.rtf");
                    break;
                case "Node23":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\23.rtf");
                    break;
                case "Node24":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\24.rtf");
                    break;
                case "Node25":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\25.rtf");
                    break;
                case "Node26":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\asas.rtf");
                    break;
                case "Node27":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\beg.rtf");
                    break;
                case "Node28":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k 2 1.rtf");

                    break;
                case "Node29":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k 2 2.rtf");

                    break;
                case "Node30":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k 2 3.rtf");

                    break;
                case "Node31":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k1.rtf");

                    break;
                case "Node32":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k2.rtf");

                    break;
                case "Node33":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k3.rtf");

                    break;
                case "Node34":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k4.rtf");

                    break;
                case "Node35":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k5.rtf");

                    break;
                case "Node36":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k6.rtf");

                    break;
                case "Node37":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k7.rtf");

                    break;
                case "Node38":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k8.rtf");

                    break;
                case "Node39":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\k9.rtf");

                    break;
                case "Node40":
                    Rich_teb_4.LoadFile(Application.StartupPath + "\\Word\\Creative ways to save the Koran\\not keep all.rtf");

                    break;
                default:

                    break;
            }

        }
    }
}
