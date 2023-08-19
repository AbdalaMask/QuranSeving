using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.CoreAudioApi;
namespace QuranSeving.Tag
{
    public partial class Frm_Teg : KryptonForm
    {
        private IWavePlayer waveOut;
        private AudioFileReader audioFileReader;
        private readonly bool devicePanel;
        private MMDevice device;
        private readonly AudioSessionControl session;
        public Frm_Teg()
        {
            this.devicePanel = true;
            var deviceEnumerator = new MMDeviceEnumerator();
            device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            InitializeComponent();
        }
        private IWavePlayer CreateWavePlayer()
        {

            return new WaveOut();

        }
        private void BeginPlayback(string filename)
        {
            CleanUp();

            waveOut = CreateWavePlayer();
            audioFileReader = new AudioFileReader(filename);
            waveOut.Init(audioFileReader);

            waveOut.Play();

        }
        private void CleanUp()
        {

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
        }
        public void SetAH(string FileName)
        {
            Teb_g.SelectedIndex = 4;
            Rich_teb_3.LoadFile(Application.StartupPath + string.Format("\\Word\\Teg\\{0}.rtf", FileName));
        }
       
       
        private void Frm_Teg_Load(object sender, EventArgs e)
        {
            Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Teg\\00.rtf");
        }

        private void tsMistakes_Click(object sender, EventArgs e)
        {
            Teb_g.SelectedIndex = 0;
        }

        private void tsProvisions_Click(object sender, EventArgs e)
        {
            Teb_g.SelectedIndex = 1;
        }

        private void ts_Varied_cats_Click(object sender, EventArgs e)
        {
            Teb_g.SelectedIndex = 2;
        }

        private void ts_Character_exits_Click(object sender, EventArgs e)
        {
            Teb_g.SelectedIndex = 3;
        }

        private void btn_Island_board_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\MoTon\\GA.mp3");
            Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Teg\\MaTon\\1.rtf");
        }

        private void btn_Childrens_masterpiece_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\MoTon\\TO.mp3");
            Rich_teb_2.LoadFile(Application.StartupPath + "\\Word\\Teg\\MaTon\\2.rtf");
        }

        private void kryptonLabel26_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T23.wav");
            lblSelected.Text = "ل";
        }

        private void kryptonLabel27_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T25.wav");
            lblSelected.Text = "ن";
        }
        private void labelControl28_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T10.wav");
            lblSelected.Text = "ر";
        }

        private void labelControl41_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T16.wav");
            lblSelected.Text = "ط";
        }

        private void labelControl42_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T08.wav");
            lblSelected.Text = "د";
        }

        private void labelControl43_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T03.wav");
            lblSelected.Text = "ت";
        }

        private void labelControl29_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T15.wav");
            lblSelected.Text = "ض";
        }

        private void labelControl30_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T05.wav");
            lblSelected.Text = "ج";
        }

        private void labelControl31_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T13.wav");
            lblSelected.Text = "ش";
        }

        private void labelControl32_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T28.wav");
            lblSelected.Text = "ي";
        }

        private void labelControl33_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T22.wav");
            lblSelected.Text = "ك";
        }

        private void labelControl34_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T21.wav");
            lblSelected.Text = "ق";
        }

        private void labelControl35_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T19.wav");
            lblSelected.Text = "غ";
        }

        private void labelControl36_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T07.wav");
            lblSelected.Text = "خ";
        }

        private void labelControl37_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T18.wav");
            lblSelected.Text = "ع";
        }

        private void labelControl38_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T06.wav");
            lblSelected.Text = "ح";
        }

        private void labelControl39_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T01.wav");
            lblSelected.Text = "أ";
        }

        private void labelControl40_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T26.wav");
            lblSelected.Text = "ه";
        }

        private void labelControl44_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T17.wav");
            lblSelected.Text = "ظ";
        }

        private void labelControl45_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T04.wav");
            lblSelected.Text = "ث";
        }

        private void labelControl46_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T09.wav");
            lblSelected.Text = "ذ";
        }

        private void labelControl47_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T11.wav");
            lblSelected.Text = "ز";
        }

        private void labelControl48_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T12.wav");
            lblSelected.Text = "س";
        }

        private void labelControl49_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T14.wav");
            lblSelected.Text = "ص";
        }

        private void labelControl50_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T02.wav");
            lblSelected.Text = "ب";
        }

        private void labelControl52_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T20.wav");
            lblSelected.Text = "ف";
        }

        private void labelControl51_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T27.wav");
            lblSelected.Text = "و";
        }

        private void labelControl53_Click(object sender, EventArgs e)
        {
            BeginPlayback(Application.StartupPath + "\\Media\\Teg\\T24.wav");
            lblSelected.Text = "م";
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            SetAH("20");
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            SetAH("13");
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            SetAH("10");
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            SetAH("19");
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {
            SetAH("2");
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {
            SetAH("18");
        }

        private void labelControl7_Click(object sender, EventArgs e)
        {
            SetAH("14");
        }

        private void labelControl8_Click(object sender, EventArgs e)
        {
            SetAH("16");
        }

        private void labelControl17_Click(object sender, EventArgs e)
        {
            SetAH("5");
        }

        private void labelControl16_Click(object sender, EventArgs e)
        {
            SetAH("8");
        }

        private void labelControl18_Click(object sender, EventArgs e)
        {
            SetAH("6");
        }

        private void labelControl23_Click(object sender, EventArgs e)
        {
            SetAH("12");
        }

        private void labelControl25_Click(object sender, EventArgs e)
        {
            SetAH("1");
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {
            SetAH("4");
        }

        private void labelControl10_Click(object sender, EventArgs e)
        {
            SetAH("22");
        }

        private void labelControl12_Click(object sender, EventArgs e)
        {
            SetAH("9");
        }

        private void labelControl13_Click(object sender, EventArgs e)
        {
            SetAH("15");
        }

        private void labelControl14_Click(object sender, EventArgs e)
        {
            SetAH("3");
        }

        private void labelControl15_Click(object sender, EventArgs e)
        {
            SetAH("17");
        }

        private void Frm_Teg_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanUp();
        }

        private void Teb_g_SelectedPageChanged(object sender, EventArgs e)
        {
            CleanUp();
        }

        private void kryptonLabel12_Paint(object sender, PaintEventArgs e)
        {
            SetAH("11");
        }
    }
}
