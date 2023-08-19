using Krypton.Toolkit;
using NAudio.Wave;
using QuranSeving.Seveing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuranSeving.Mushaf
{
    public partial class Frm_Mushaf : KryptonForm
    {
        #region Filed


        QuranLibrary.QuranLibrary library = new QuranLibrary.QuranLibrary();
        public Color ColorMouseHover = Color.FromArgb(70, 185, 215, 252);
        public Color ColorMouseLeave = Color.FromArgb(0, 255, 255, 255);
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;
        private string fileName;
        int startSurahMP3 = 1;
        int startAyahMP3 = 1;
        int endSurahMP3 = 1;
        int endAyahMP3 = 7;
        string pathK;
        int ImageNum1 = 1;
        int ImageNum2 = 1;
        bool result;
        int startSurah = 0;
        int startAyahPage = 0;
        private Label LBL_S1_A1;
        private Label Rich_teb_1;

        int CountStartAyahPage = 1;
        int CountStartAyahPage2 = 1;
        #endregion
        #region Constoer
        public Frm_Mushaf()
        {
            InitializeComponent();


        }
        public Frm_Mushaf(string pathK)
        {
            InitializeComponent();
            this.pathK = pathK;

        }
        public Frm_Mushaf(string pathK, int ImageNum1 = 1, int ImageNum2 = 2, int startSurah = 0, int CountStartAyahPage = 0)
        {
            InitializeComponent();
            this.pathK = pathK;
            this.startSurah = startSurah;
            this.CountStartAyahPage = CountStartAyahPage;
            this.ImageNum1 = ImageNum1;
            this.ImageNum2 = ImageNum2;
        }
        #endregion
        #region Player
        private void BeginPlayback(string filename)
        {
            try
            {
                Debug.Assert(wavePlayer == null);
                wavePlayer = CreateWavePlayer();
                audioFileReader = new AudioFileReader(filename);
                wavePlayer.Init(audioFileReader);
                wavePlayer.PlaybackStopped += OnPlaybackStopped;
                wavePlayer.Play();
            }
            catch (Exception ex)
            {

                //throw;
            }
          


        }
        void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            // we want to be always on the GUI thread and be able to change GUI components
            Debug.Assert(!InvokeRequired, "PlaybackStopped on wrong thread");
            // we want it to be safe to clean up input stream and playback device in the handler for PlaybackStopped
            CleanUp();

            if (e.Exception != null)
            {
                MessageBox.Show(String.Format("Playback Stopped due to an error {0}", e.Exception.Message));
            }
        }

        private void CleanUp()
        {
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }
        }
        private IWavePlayer CreateWavePlayer()
        {

            return new WaveOut();

        }
        #endregion

        #region ColorMouse
        public void setColorMouseHover(int sura, int ayah)
        {
            try
            {

                if (P1.Controls.Count > 1)
                {
                    var g = P1.Controls.Find(string.Format("Page{0}_S{1}_A{2}", ImageNum1, sura, ayah), true);
                    if (g.Length > 0)
                    {
                        Label lb = (Label)g[0];
                        lb.BackColor = ColorMouseHover;
                    }
                    var R = P1.Controls.Find(string.Format("Rich{0}_S{1}_A{2}", ImageNum1, sura, ayah), true);
                    if (R.Length > 0)
                    {
                        Label Rich = (Label)R[0];
                        Rich.BackColor = ColorMouseHover;
                        Rich.ForeColor = Color.Blue;
                    }
                }
                if (P2.Controls.Count > 1)
                {
                    var g = P2.Controls.Find(string.Format("Page{0}_S{1}_A{2}", ImageNum1, sura, ayah), true);
                    if (g.Length > 0)
                    {
                        Label lb = (Label)g[0];
                        lb.BackColor = ColorMouseHover;
                    }
                    var R = P2.Controls.Find(string.Format("Rich{0}_S{1}_A{2}", ImageNum1, sura, ayah), true);
                    if (R.Length > 0)
                    {
                        Label Rich = (Label)R[0];
                        Rich.BackColor = ColorMouseHover;
                        Rich.ForeColor = Color.Blue;
                    }
                }
            }
            catch
            {

                return;
            }




        }
        public void setColorMouseLeave(int sura, int ayah)
        {
            try
            {
                if (P1.Controls.Count > 1)
                {
                    var g = P1.Controls.Find(string.Format("Page{0}_S{1}_A{2}", ImageNum1, sura, ayah), true);
                    if (g.Length > 0)
                    {
                        Label lb = (Label)g[0];
                        lb.BackColor = ColorMouseLeave;
                    }
                    var R = P1.Controls.Find(string.Format("Rich{0}_S{1}_A{2}", ImageNum1, sura, ayah), true);
                    if (R.Length > 0)
                    {
                        Label Rich = (Label)R[0];
                        Rich.BackColor = ColorMouseLeave;
                        Rich.ForeColor = Color.Black;
                    }
                }
                if (P2.Controls.Count > 1)
                {
                    var g = P2.Controls.Find(string.Format("Page{0}_S{1}_A{2}", ImageNum1, sura, ayah), true);
                    if (g.Length > 0)
                    {
                        Label lb = (Label)g[0];
                        lb.BackColor = ColorMouseLeave;
                    }
                    var R = P2.Controls.Find(string.Format("Rich{0}_S{1}_A{2}", ImageNum1, sura, ayah), true);
                    if (R.Length > 0)
                    {
                        Label Rich = (Label)R[0];
                        Rich.BackColor = ColorMouseLeave;
                        Rich.ForeColor = Color.Black;
                    }
                }

            }
            catch
            {

                return;
            }



        }
        #endregion
        #region void

        

        public void SetControlsToPanel(Control cot, int startSurah, int startAyah, int Page)
        {
            try
            {
                cot.Controls.Clear();
                int PagesSub = Page - 1;
                //=====================================================================
                int f = library.QuranMetaData.PagesContainer._pages[PagesSub].aya - 1;

                int Surah = library.QuranMetaData.PagesContainer._pages[PagesSub].sura - 1;
                int K = library.QuranMetaData.SurahsContainer._suras[Surah].ayas - 1;
                int r = Page;
                int v = library.QuranMetaData.PagesContainer._pages[r].aya;
                if (library.QuranMetaData.PagesContainer._pages[PagesSub].sura == library.QuranMetaData.PagesContainer._pages[r].sura)
                {
                    startAyah = v;
                }
                else
                {
                    startAyah = v + K;
                }
                //==================================================================
                for (int i = f; i < startAyah; i++)
                {
                    if (library.q.surahs[Surah].ayat[i].Page == null) return;
                    int Pages = int.Parse(library.q.surahs[Surah].ayat[i].Page);
                    if (Pages == Page)
                    {
                       
                        
                        int X = int.Parse(library.q.surahs[Surah].ayat[i].X);
                        int Y = int.Parse(library.q.surahs[Surah].ayat[i].Y);

                        int width = int.Parse(library.q.surahs[Surah].ayat[i].width);
                        int height = int.Parse(library.q.surahs[Surah].ayat[i].height);


                        LBL_S1_A1 = new Label();
                        LBL_S1_A1.BackColor = Color.Transparent;
                        LBL_S1_A1.Location = new Point(X, Y);
                        LBL_S1_A1.Name = string.Format("Page{0}_S{1}_A{2}", Page, Surah, i);
                        LBL_S1_A1.Size = new Size(width, height);
                        LBL_S1_A1.MouseClick += new MouseEventHandler(this.LBL_S1_A1_MouseClick);
                        LBL_S1_A1.MouseLeave += new EventHandler(this.LBL_S1_A6_2_MouseLeave);
                        LBL_S1_A1.MouseHover += new EventHandler(this.LBL_S1_A6_2_MouseHover);
                        cot.Controls.Add(LBL_S1_A1);
                    }

                }

            }
            catch
            {

                return;
            }


        }
        public void SetControlsTranslatorToPanel(Control cot, int startSurah, int startAyah, int Page)
        {
            try
            {
                cot.Controls.Clear();
                int wid = 404;
                int hgt = 200;
                int margin = 5;
                int x = margin;
                int y = margin;
                int num_columns = 1;
                int xmax = num_columns * (wid + margin);
                int PagesSub = Page - 1;
                //=====================================================================
                int f = library.QuranMetaData.PagesContainer._pages[PagesSub].aya - 1;

                int Surah = library.QuranMetaData.PagesContainer._pages[PagesSub].sura - 1;
                int K = library.QuranMetaData.SurahsContainer._suras[Surah].ayas - 1;
                int r = Page;
                int v = library.QuranMetaData.PagesContainer._pages[r].aya;
                if (library.QuranMetaData.PagesContainer._pages[PagesSub].sura == library.QuranMetaData.PagesContainer._pages[r].sura)
                {
                    startAyah = v;
                }
                else
                {
                    startAyah = v + K;
                }

                for (int i = f; i < startAyah; i++)
                {
                    startAyahPage = i + 1;
                    if (library.q.surahs[Surah].ayat[i].Page == null) return;
                    int Pages = int.Parse(library.q.surahs[Surah].ayat[i].Page);
                    if (Pages == Page)
                    {

                        Rich_teb_1 = new Label();

                        // Rich_teb_1
                        hgt = library.TM.surahs[Surah].ayat[i].text.Length / 2;
                        Rich_teb_1.Name = string.Format("Rich{0}_S{1}_A{2}", Page, Surah, i);
                        Rich_teb_1.Text = string.Format("({0}) {1}", startAyahPage, library.TM.surahs[Surah].ayat[i].text);
                        Rich_teb_1.BorderStyle = BorderStyle.FixedSingle;
                        Rich_teb_1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(178)));
                        Rich_teb_1.Size = new Size(wid, hgt);
                        Rich_teb_1.ForeColor = Color.Black;

                        Rich_teb_1.Location = new Point(x, y);
                        Rich_teb_1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                        Rich_teb_1.MouseClick += new MouseEventHandler(Rich_teb_1_MouseClick);
                        Rich_teb_1.MouseLeave += new EventHandler(this.Rich_teb_1_MouseLeave);
                        Rich_teb_1.MouseHover += new EventHandler(this.Rich_teb_1_MouseHover);
                        x += wid + margin;
                        if (x > xmax)
                        {
                            x = margin;
                            y += hgt + margin;
                        }

                        cot.Controls.Add(Rich_teb_1);



                    }

                }

            }
            catch
            {

                return;
            }


        }

        void Rich_teb_1_MouseHover(object sender, EventArgs e)
        {
            Label txt = (Label)sender;
            txt.BackColor = ColorMouseHover;
        }

        void Rich_teb_1_MouseLeave(object sender, EventArgs e)
        {
            Label txt = (Label)sender;
            txt.BackColor = ColorMouseLeave;
        }

        void Rich_teb_1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        /// <summary>
        /// grab list of start and end ayahs for each surah
        /// </summary>
        /// <param name="startSurah"></param>
        /// <param name="startAyah"></param>
        /// <param name="endSurah"></param>
        /// <param name="endAyah"></param>
        /// <returns></returns>
        private string Mp3List(int startSurah, int startAyah, int endSurah, int endAyah)
        {
            //TEST case
            //Page 600: start surah 100, start ayah 10, end surah 102, end ayah 8 ( 100:10 to 100:11, then 101:01 to 101:11, followed by 102:01 to 102:08)

            string path = Application.StartupPath + string.Format(@"\Quran\{0}\", pathK);
            string c = string.Empty;
            for (int surah = startSurah; surah <= endSurah; surah++)
            {
                int finalAyah = endAyah;

                if (surah != startSurah)
                    startAyah = 0;


                if (surah < endSurah) //if this surah is not the last on the page, then all the ayahs will be used up until end of this surah
                    finalAyah = library.QuranMetaData.SurahsContainer._suras[surah - 1].ayas;

                for (int ayah = startAyah; ayah <= finalAyah; ayah++)
                {
                    if (ayah == 0)
                    {
                        c = Path.Combine(path, "001001.mp3"); //Add Bismillah
                    }
                    else
                        c = Path.Combine(path, surah.ToString().PadLeft(3, '0') + ayah.ToString().PadLeft(3, '0') + ".mp3");
                }
            }
            if (startSurah == 100)
                System.Threading.Thread.Sleep(1);
            return c;
        }
        #endregion
        #region MouseHoverAndLeave
        private void LBL_S1_A6_2_MouseHover(object sender, EventArgs e)
        {
            Label lb = (Label)sender;

            int NameLengthSurah = lb.Name.Length == 11 ? 7 : 8;
            int NameLengthAyah = lb.Name.Length == 11 ? 10 : 11;

            switch (lb.Name.Length)
            {
                case 11:
                    startSurahMP3 = int.Parse(lb.Name.Substring(NameLengthSurah, 1));
                    startAyahMP3 = int.Parse(lb.Name.Substring(NameLengthAyah, 1));
                    break;
                case 12:
                    startSurahMP3 = int.Parse(lb.Name.Substring(NameLengthSurah, 1));
                    startAyahMP3 = int.Parse(lb.Name.Substring(NameLengthAyah, 2));
                    break;
                default:
                    break;
            }




            if (P1.Controls.Count > 1)
            {
                try
                {
                    lb.BackColor = ColorMouseHover;
                    var g = P1.Controls.Find(string.Format("Rich{0}_S{1}_A{2}", ImageNum1, startSurahMP3, startAyahMP3), true);
                    if (g.Length > 0)
                    {
                        Label Rich = (Label)g[0];
                        Rich.BackColor = ColorMouseHover;
                        Rich.ForeColor = Color.Blue;
                    }


                }
                catch
                {

                    return;
                }


            }
            if (P2.Controls.Count > 1)
            {
                try
                {
                    lb.BackColor = ColorMouseHover;
                    var g = P2.Controls.Find(string.Format("Rich{0}_S{1}_A{2}", ImageNum1, startSurahMP3, startAyahMP3), true);

                    if (g.Length > 0)
                    {
                        Label Rich = (Label)g[0];
                        Rich.BackColor = ColorMouseHover;
                        Rich.ForeColor = Color.Blue;
                    }
                }
                catch
                {

                    return;
                }


            }




        }

        private void LBL_S1_A6_2_MouseLeave(object sender, EventArgs e)
        {
            Label lb = (Label)sender;


            lb.BackColor = ColorMouseLeave;

            try
            {
                if (P1.Controls.Count > 1)
                {
                    var g = P1.Controls.Find(string.Format("Rich{0}_S{1}_A{2}", ImageNum1, startSurahMP3, startAyahMP3), true);

                    if (g.Length > 0)
                    {
                        Label Rich = (Label)g[0];
                        Rich.ForeColor = Color.Black;
                        Rich.BackColor = ColorMouseLeave;
                    }
                }
                if (P2.Controls.Count > 1)
                {
                    var g = P2.Controls.Find(string.Format("Rich{0}_S{1}_A{2}", ImageNum1, startSurahMP3, startAyahMP3), true);

                    if (g.Length > 0)
                    {
                        Label Rich = (Label)g[0];
                        Rich.ForeColor = Color.Black;
                        Rich.BackColor = ColorMouseLeave;
                    }
                }
            }
            catch
            {

                return;
            }





        }
        #endregion
        #region MouseEvent
        private void LBL_S1_A1_MouseClick(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;

            int NameLengthSurah = lb.Name.Length == 11 ? 7 : 8;
            int NameLengthAyah = lb.Name.Length == 11 ? 10 : 11;

            switch (lb.Name.Length)
            {
                case 11:
                    startSurahMP3 = int.Parse(lb.Name.Substring(NameLengthSurah, 1)) + 1;
                    startAyahMP3 = int.Parse(lb.Name.Substring(NameLengthAyah, 1)) + 1;
                    endSurahMP3 = int.Parse(lb.Name.Substring(NameLengthSurah, 1)) + 1;
                    endAyahMP3 = int.Parse(lb.Name.Substring(NameLengthAyah, 1)) + 1;
                    break;
                case 12:

                    startSurahMP3 = int.Parse(lb.Name.Substring(NameLengthSurah, 1)) + 1;
                    startAyahMP3 = int.Parse(lb.Name.Substring(NameLengthAyah, 2)) + 1;
                    endSurahMP3 = int.Parse(lb.Name.Substring(NameLengthSurah, 1)) + 1;
                    endAyahMP3 = int.Parse(lb.Name.Substring(NameLengthAyah, 1)) + 1;
                    break;
                default:
                    break;
            }


            int indexSurah = startSurahMP3 - 1;
            int indexAyah = startAyahMP3 - 1;


            fileName = Mp3List(startSurahMP3, startAyahMP3, endSurahMP3, endAyahMP3);
            if (fileName != null)
            {
                BeginPlayback(fileName);
            }
        }
        #endregion

        

       
        private void Frm_Mushaf_Load(object sender, EventArgs e)
        {
            if (ImageNum1 == 1 || ImageNum1 == 77)
            {

                P2.BackColor = Color.White;
                P2.BackgroundImage = null;
                P1.BackgroundImage = Image.FromFile(Application.StartupPath + string.Format("\\images\\{0}.PNG", ImageNum1));
                SetControlsToPanel(P1, startSurah, CountStartAyahPage, ImageNum1);
                SetControlsTranslatorToPanel(P2, startSurah, CountStartAyahPage, ImageNum1);

                result = false;
            }

            if (ImageNum1 == 2 || ImageNum1 == 50)
            {

                P1.BackColor = Color.White;
                P1.BackgroundImage = null;
                P2.BackgroundImage = Image.FromFile(Application.StartupPath + string.Format("\\images\\{0}.PNG", ImageNum1));
                SetControlsToPanel(P2, startSurah, CountStartAyahPage, ImageNum1);
                SetControlsTranslatorToPanel(P1, startSurah, CountStartAyahPage, ImageNum1);
                result = true;
            }
            //=======================================================================================================
            Frm_Seva.eventSDataChanged += new EventSDataChanged((sura, ayah, state) =>
            {
                if (state)
                {
                    setColorMouseHover(sura, ayah);
                    startSurahMP3 = sura;
                }
                else
                {
                    setColorMouseLeave(sura, ayah);
                    startSurahMP3 = sura;
                }

            });
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            ImageNum1 = ImageNum1 + 1;
            if (ImageNum1 == 604) ImageNum1 = 604;
            try
            {

                if (!result)
                {

                    P1.BackColor = Color.White;
                    P1.BackgroundImage = null;
                    SetControlsToPanel(P2, startSurah, CountStartAyahPage, ImageNum1);
                    SetControlsTranslatorToPanel(P1, startSurah, CountStartAyahPage, ImageNum1);
                    P2.BackgroundImage = Image.FromFile(Application.StartupPath + string.Format("\\images\\{0}.PNG", ImageNum1));
                    result = true;

                }
                else
                {

                    P2.BackColor = Color.White;
                    P2.BackgroundImage = null;
                    SetControlsToPanel(P1, startSurah, CountStartAyahPage, ImageNum1);
                    SetControlsTranslatorToPanel(P2, startSurah, CountStartAyahPage, ImageNum1);
                    P1.BackgroundImage = Image.FromFile(Application.StartupPath + string.Format("\\images\\{0}.PNG", ImageNum1));

                    result = false;

                }

            }
            catch
            {

                return;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ImageNum1 = ImageNum1 - 1;
            if (ImageNum1 == 0) ImageNum1 = 1;
            try
            {

                if (!result)
                {

                    P1.BackColor = Color.White;
                    P1.BackgroundImage = null;
                    P2.BackgroundImage = Image.FromFile(Application.StartupPath + string.Format("\\images\\{0}.PNG", ImageNum1));
                    SetControlsToPanel(P2, startSurah, CountStartAyahPage, ImageNum1);
                    SetControlsTranslatorToPanel(P1, startSurah, CountStartAyahPage, ImageNum1);
                    result = true;
                }
                else
                {

                    P2.BackColor = Color.White;
                    P2.BackgroundImage = null;
                    P1.BackgroundImage = Image.FromFile(Application.StartupPath + string.Format("\\images\\{0}.PNG", ImageNum1));
                    SetControlsToPanel(P1, startSurah, CountStartAyahPage, ImageNum1);
                    SetControlsTranslatorToPanel(P2, startSurah, CountStartAyahPage, ImageNum1);
                    result = false;
                }

            }
            catch
            {

                return;
            }
        }

        private void Frm_Mushaf_FormClosing(object sender, FormClosingEventArgs e)
        {
            Frm_Seva.eventSDataChanged = null;
            if (wavePlayer != null)
            {
                wavePlayer.Stop();
            }
            CleanUp();
        }
    }
}
