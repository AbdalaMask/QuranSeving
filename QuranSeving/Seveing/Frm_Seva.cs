using ComponentFactory.Krypton.Toolkit;
using QuranSeving.Mushaf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.IO;
using System.Data;
using QuranSeving.DB;
using Microsoft.VisualBasic.CompilerServices;
using System.Net;
using System.Diagnostics;

namespace QuranSeving.Seveing
{
    public delegate void EventSDataChanged(int sura, int ayah, bool state);
    public partial class Frm_Seva : KryptonForm
    {
      
        public static EventSDataChanged eventSDataChanged = null;
        private IWavePlayer waveOut;
        private string fileName;
        private AudioFileReader audioFileReader;
        public Color ColorMouseHover = Color.FromArgb(70, 185, 215, 252);
        public Color ColorMouseLeave = Color.FromArgb(0, 255, 255, 255);

      
        private readonly bool devicePanel;
        private MMDevice device;
        private readonly AudioSessionControl session;

        public MMDevice Device
        {
            get
            {
                return device;
            }
        }

        public event EventHandler DeviceChanged;
        public event EventHandler<MuteEventArgs> MuteChanged;
        public event EventHandler<VolumeEventArgs> VolumeChanged;
        List<string> mp3sToWrapArray = new List<string>();
        QuranLibrary.QuranLibrary library = new QuranLibrary.QuranLibrary();
        string[] c1 = { "المنشاوى", "البنا", "محمد ايوب", "عبد الباسط", "ابو بكر الشاطرى" };
        public string[] c2 = { "سورة الفاتحة", "سورة البقرة", "سورة ال عمران", "سورة النساء", "سورة المائدة", "سورة الانعام", "سورة الاعراف", "سورة الانفال", "سورة التوبة", "سورة يونس", "سورة هود", "سورة يوسف", "سورة الرعد", "سورة ابراهيم", "سورة الحجر", "سورة النحل", "سورة الاسراء", "سورة الكهف", "سورة مريم", "سورة طه", "سورة الانبياء", "سورة الحج", "سورة المؤمنون", "سورة النور", "سورة الفرقان", "سورة الشعراء", "سورة النمل", "سورة القصص", "سورة العنكبوت", "سورة الروم", "سورة لقمان", "سورة السجدة", "سورة الاحزاب", "سورة سبا", "سورة فاطر", "سورة يس", "سورة الصافات", "سورة ص", "سورة الزمر", "سورة غافر", "سورة فصلت", "سورة الشورى", "سورة الزخرف", "سورة الدخان", "سورة الجاثية", "سورة الاحقاف", "سورة محمد", "سورة الفتح", "سورة الحجرات", "سورة ق", "سورة الزاريات", "سورة الطور", "سورة النجم", "سورة القمر", "سورة الرحمن", "سورة الواقعة", "سورة الحديد", "سورة المجادلة", "سورة الحشر", "سورة الممتحنة", "سورة الصف", "سورة الجمعة", "سورة المنافقون", "سورة التغابن", "سورةالطلاق", "سورة التحريم", "سورة الملك", "سورة القلم", "سورة الحاقة", "سورة المعارج", "سورة نوح", "سورة الجن", "سورة المزمل", "سورة المدثر", "سورة القيامة", "سورة الانسان", "سورة المرسلات", "سورة النبا", "سورة النازعات", "سورة عبس", "سورة التكوير", "سورة الانفطار ", "سورة المطففين", "سورة الانشقاق", "سورة البروج ", "سورة الطارق", "سورة الاعلى", "سورة الغاشية", "سورة الفجر", "سورة البلد", "سورة الشمس", "سورة الليل", "سورة الضحى", "سورةالشرح", "سورةالتين", "سورة العلق", "سورة القدر", "سورة البينة", "سورةالزلزلة", "سورة العاديات", "سورة القارعة", "سورة التكاثر", "سورة العصر", "سورة الهمزة", "سورة الفيل", "سورة قريش", "سورة الماعون", "سورة الكوثر", "سورة الكافرون", "سورة النصر", "سورة المسد", "سورة الاخلاص", "سورة الفلق", "سورة الناس" };

        int startSurah = 1;
        int startAyah = 1;
        //=======================================================================
        int startSurahMP3 = 1;
        int startAyahMP3 = 1;
        int endSurahMP3 = 1;
        int endAyahMP3 = 7;
        //=======================================================================
        int current = 0;
        int currentendAyah = 0;
        string pathK;
        int ImageNum1 = 4;
        int ImageNum2 = 5;


        int CountStartAyahPage = 1;
        int CountStartAyahPage2 = 1;
        public Frm_Seva()
        {
            this.devicePanel = true;
            var deviceEnumerator = new MMDeviceEnumerator();
            device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            InitializeComponent();
        }

        private void btn_Frm_Kep_Click(object sender, EventArgs e)
        {
            FrmMain form = Application.OpenForms["FrmMain"] as FrmMain;
            Frm_Kep frm = new Frm_Kep();
            frm.MdiParent = form;
            frm.Show();
        }
        public void tim_data(ref TextBox txt_timerec, ref TextBox txt_dayrec, ref TextBox txt_morec, ref TextBox txt_yearrec)
        {
            txt_timerec.Text = DateTime.Today.ToShortTimeString();
            txt_dayrec.Text = DateTime.Today.ToShortDateString();
            txt_morec.Text = DateTime.Today.Month.ToString();
            txt_yearrec.Text = DateTime.Today.Year.ToString();
        }
         
        private IWavePlayer CreateWavePlayer()
        {

            return new WaveOut();

        }
        MediaFoundationReader mf; WaveOutEvent wo;
        private void BeginPlayback(string filename)
        {

            waveOut = CreateWavePlayer();
            if (RNotNet.Checked)
            {
                audioFileReader = new AudioFileReader(filename);
                waveOut.Init(audioFileReader);
                waveOut.Play();
            }
            else if (RNet.Checked)
            {
               
                using ( mf = new MediaFoundationReader(filename))
                using ( wo = new WaveOutEvent())
                {
                    wo.Init(mf);
                    wo.Play();
                    while (wo.PlaybackState == PlaybackState.Playing)
                    {
                        Application.DoEvents();
                    }
                }
            }


             

            if (eventSDataChanged != null) eventSDataChanged(startSurah, currentendAyah, true);
            
            

        }
        void SetNext()
        {
            if (eventSDataChanged != null) eventSDataChanged(startSurah, currentendAyah, false);
            current = current + 1;
            currentendAyah++;
            buttonPlay.PerformClick();
        }
        private void CleanUp()
        {
            mp3sToWrapArray.Clear();
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
        /// <summary>
        /// grab list of start and end ayahs for each surah
        /// </summary>
        /// <param name="startSurah"></param>
        /// <param name="startAyah"></param>
        /// <param name="endSurah"></param>
        /// <param name="endAyah"></param>
        /// <returns></returns>
        private string[] Mp3List(int startSurah, int startAyah, int endSurah, int endAyah)
        {
            //TEST case
            //Page 600: start surah 100, start ayah 10, end surah 102, end ayah 8 ( 100:10 to 100:11, then 101:01 to 101:11, followed by 102:01 to 102:08)

            string path = Application.StartupPath + string.Format(@"\Quran\{0}\", pathK);
            var c = new List<string>();
            for (int surah = startSurah; surah <= endSurah; surah++)
            {
                int finalAyah = endAyah;

                //BUG caught nov-10-2010: if surah is not startsurah, reset ayah counter back to 0 to add bismillah
                if (surah != startSurah)
                    startAyah = 0;


                //if (surah == endSurah)
                //    finalAyah = endAyah;
                //else 
                if (surah < endSurah) //if this surah is not the last on the page, then all the ayahs will be used up until end of this surah
                    finalAyah = library.QuranMetaData.SurahsContainer._suras[surah - 1].ayas;

                for (int ayah = startAyah; ayah <= finalAyah; ayah++)
                {
                    if (ayah == 0)
                    {
                        c.Add(Path.Combine(path, "001001.mp3")); //Add Bismillah
                    }
                    else
                        c.Add(Path.Combine(path, surah.ToString().PadLeft(3, '0') + ayah.ToString().PadLeft(3, '0') + ".mp3"));
                }
            }
            if (startSurah == 100)
                System.Threading.Thread.Sleep(1);
            return c.ToArray();
        }


        /// <summary>
        /// grab list of start and end ayahs for each surah
        /// </summary>
        /// <param name="startSurah"></param>
        /// <param name="startAyah"></param>
        /// <param name="endSurah"></param>
        /// <param name="endAyah"></param>
        /// <returns></returns>
        private string[] Mp3ListWeb(int startSurah, int startAyah, int endSurah, int endAyah)
        {
            //TEST case
            //Page 600: start surah 100, start ayah 10, end surah 102, end ayah 8 ( 100:10 to 100:11, then 101:01 to 101:11, followed by 102:01 to 102:08)

            string path = "http://everyayah.com/data/"+$"{pathK}/";
            var c = new List<string>();
            for (int surah = startSurah; surah <= endSurah; surah++)
            {
                int finalAyah = endAyah;

                //BUG caught nov-10-2010: if surah is not startsurah, reset ayah counter back to 0 to add bismillah
                if (surah != startSurah)
                    startAyah = 0;


                //if (surah == endSurah)
                //    finalAyah = endAyah;
                //else 
                if (surah < endSurah) //if this surah is not the last on the page, then all the ayahs will be used up until end of this surah
                    finalAyah = library.QuranMetaData.SurahsContainer._suras[surah - 1].ayas;

                for (int ayah = startAyah; ayah <= finalAyah; ayah++)
                {
                    if (ayah == 0)
                    {
                        c.Add(Path.Combine(path, "001001.mp3")); //Add Bismillah
                    }
                    else
                        c.Add(Path.Combine(path, surah.ToString().PadLeft(3, '0') + ayah.ToString().PadLeft(3, '0') + ".mp3"));
                }
            }
            if (startSurah == 100)
                System.Threading.Thread.Sleep(1);
            return c.ToArray();
        }
        private void Frm_Seva_Load(object sender, EventArgs e)
        {
            try
            {
                com_c1.Items.AddRange(c1);
                com_c2.Items.AddRange(c2);
                //for (int i = 0; i < library.QuranMetaData.SurahsContainer._suras.Length; i++)
                //{
                //    com_c2.Properties.Items.Add(library.QuranMetaData.SurahsContainer._suras[i].name);
                //}
                com_c1.SelectedIndex = 0;
                com_c2.SelectedIndex = 0;

                UpdateMuted();
                string ConString3 = "Data Source =" + Application.StartupPath + string.Format("\\DatabaseUser\\{0}", "DatabaseUser.db3");
                SQLiteConnection conn3 = new SQLiteConnection(ConString3);
                if (conn3.State == System.Data.ConnectionState.Open)
                    conn3.Close();
                string SQL3str = "SELECT * FROM de";

                using (SQLiteCommand cmd = new SQLiteCommand(conn3))
                {
                    conn3.Open();
                    cmd.CommandText = SQL3str;
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                string output = reader["mname"].ToString();
                                txt_hapday.Text = reader["hapday"].ToString();
                                ComName.Items.Add(output);
                            }
                        }
                    }
                }




            }
            catch (Exception)
            {

                return;
            }
        }

        public void UpdateMuted()
        {
            bool mute;
            if (!devicePanel)
            {
                mute = session.SimpleAudioVolume.Mute;
                if (device.AudioEndpointVolume.Mute)
                    mute = true;
            }
            else
            {
                mute = device.AudioEndpointVolume.Mute;
                if (MuteChanged != null)
                    MuteChanged(null, new MuteEventArgs(Device.AudioEndpointVolume.Mute));
            }
           btnMuteUnmute.ImageKey = mute ? "Mute.png" : "Unmute.png";
        }
        public void UpdateVolume()
        {
            if (!devicePanel)
            {
                float volume = session.SimpleAudioVolume.Volume;
                tbVolume.Value = (int)(Math.Round(volume * Device.AudioEndpointVolume.MasterVolumeLevelScalar * 100));
            }
            else
            {
                tbVolume.Value = (int)(Math.Round(Device.AudioEndpointVolume.MasterVolumeLevelScalar * 100));
                if (VolumeChanged != null)
                    VolumeChanged(null, new VolumeEventArgs(Device.AudioEndpointVolume.MasterVolumeLevelScalar));
            }
        }

        private void btnMuteUnmute_Click(object sender, EventArgs e)
        {
            bool muted;
            if (!devicePanel)
            {
                muted = !session.SimpleAudioVolume.Mute;
                session.SimpleAudioVolume.Mute = muted;
                if (!muted)
                    Device.AudioEndpointVolume.Mute = false;
            }
            else
            {
                muted = !Device.AudioEndpointVolume.Mute;
                Device.AudioEndpointVolume.Mute = muted;
            }
            UpdateMuted();
            if (MuteChanged != null)
                MuteChanged(sender, new MuteEventArgs(muted));
        }

        private void tbVolume_Scroll(object sender, EventArgs e)
        {
            float volume;
            volume = tbVolume.Value / 100.0f;
            if (!devicePanel)
            {
                var newVolume = volume / Device.AudioEndpointVolume.MasterVolumeLevelScalar;
                if (newVolume <= 1)
                    session.SimpleAudioVolume.Volume = newVolume;
                else
                {
                    Device.AudioEndpointVolume.MasterVolumeLevelScalar = volume;
                    session.SimpleAudioVolume.Volume = 1;
                }
                session.SimpleAudioVolume.Mute = false;
            }
            else
            {
                Device.AudioEndpointVolume.MasterVolumeLevelScalar = volume;
            }
            Device.AudioEndpointVolume.Mute = false;
            if (VolumeChanged != null)
                VolumeChanged(sender, new VolumeEventArgs(volume));
            UpdateMuted();
            if (MuteChanged != null)
                MuteChanged(sender, new MuteEventArgs(false));
        }

        private void com_c1_SelectedIndexChanged(object sender, EventArgs e)
        {
            current = 0;
            currentendAyah = 0;
            mp3sToWrapArray.Clear();
            switch (com_c1.SelectedIndex)
            {
                case 0:
                    pathK = "Minshawy_Murattal_48kbps";
                    break;
                case 1:
                    pathK = "Banna_32kbps";
                    break;
                case 2:
                    pathK = "Muhammad_Ayyoub_32kbps";
                    break;
                case 3:
                    pathK = "Abdul_Basit_Murattal_64kbps";
                    break;

                default:
                    break;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Pause();
                }
            }
        }

        private void trackBarPosition_ValueChanged(object sender, EventArgs e)
        {
            int last;
            last = trackBarPosition.Maximum - 1;
            if (trackBarPosition.Value >= last)
            {
                SetNext();
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            CleanUp();

            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    return;
                }
                else if (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    waveOut.Play();

                    return;
                }
            }
            mp3sToWrapArray.AddRange(Mp3ListWeb(startSurahMP3, startAyahMP3, endSurahMP3, endAyahMP3));
            try
            {
                if (current > endAyahMP3 - 1) current = 0;
                if (currentendAyah > endAyahMP3) currentendAyah = 0;
                BeginPlayback(mp3sToWrapArray[current]);

                Rich_teb_1.Text = library.q.surahs[startSurah].ayat[current].text;

            }
            catch (Exception createException)
            {
                MessageBox.Show(String.Format("{0}", createException.Message), "Error Loading File");
                return;
            }
 
            if (RNotNet.Checked)
            {
                labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
             audioFileReader.TotalTime.Seconds);
            }
            else
            {
                labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)mf.TotalTime.TotalMinutes,
           mf.TotalTime.Seconds);
            }
        }

        private void trackBarPosition_Scroll(object sender, EventArgs e)
        {
            if (waveOut != null|| wo != null)
            {
                if (RNotNet.Checked)
                {
                    audioFileReader.CurrentTime = TimeSpan.FromSeconds(audioFileReader.TotalTime.TotalSeconds * trackBarPosition.Value / 100.0);
                    audioFileReader.Position = trackBarPosition.Value;
                }
                else
                {
                    mf.CurrentTime = TimeSpan.FromSeconds(mf.TotalTime.TotalSeconds * trackBarPosition.Value / 100.0);
                    mf.Position = trackBarPosition.Value;
                }
           }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (waveOut != null || audioFileReader  != null || mf != null || wo != null)
            {

                if (RNotNet.Checked)
                {

                    TimeSpan currentTime = (waveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioFileReader.CurrentTime;
                    trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / audioFileReader.TotalTime.TotalSeconds));
                    labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes,
                        currentTime.Seconds);
                }
                else
                {
                    TimeSpan currentTime = (wo.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : mf.CurrentTime;
                    trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / mf.TotalTime.TotalSeconds));
                    labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes,
                        currentTime.Seconds);
                }
            }
            else
            {
                trackBarPosition.Value = 0;
            }
        }
        public DataTable ds2 = new DataTable();
        private void btnEnter_Click(object sender, EventArgs e)
        {
            string ConString3 = "Data Source =" + Application.StartupPath + string.Format("\\DatabaseUser\\{0}", "DatabaseUser.db3");
            SQLiteConnection conn3 = new SQLiteConnection(ConString3);
            if (conn3.State == System.Data.ConnectionState.Open)
                conn3.Close();
            string SQL3str = "SELECT * FROM de WHERE mname=@mname and pass=@pass";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(SQL3str, conn3);
            adp.SelectCommand.Parameters.AddWithValue("@mname", ComName.Text);
            adp.SelectCommand.Parameters.AddWithValue("@pass", txtPas.Text);
            adp.Fill(ds2);
            if (ds2.Rows.Count > 0)
            {
                G_LOGIN.Visible = false;
                Program.SalesMan = ds2.Rows[0]["mname"].ToString();
                txtSalesMan.Text = ds2.Rows[0]["mname"].ToString();
                txt_timerec.Text = ds2.Rows[0]["hkeep"].ToString();
                txt_dayrec.Text = ds2.Rows[0]["dayrec"].ToString();
                txt_morec.Text = ds2.Rows[0]["morec"].ToString();
                txt_yearrec.Text = ds2.Rows[0]["yearrec"].ToString();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txtTimeHI.Text = DateTime.Now.ToShortTimeString();
        }

        private void com_c2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                current = 0;
                currentendAyah = 0;
                mp3sToWrapArray.Clear();

                endAyahMP3 = library.QuranMetaData.SurahsContainer._suras[com_c2.SelectedIndex].ayas;
                startSurahMP3 = com_c2.SelectedIndex + 1;
                endSurahMP3 = com_c2.SelectedIndex + 1;
                startSurah = com_c2.SelectedIndex;

                SetDoc();


                if (devicePanel)
                {

                    var deviceEnumerator = new MMDeviceEnumerator();
                    foreach (var d in deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                    {


                    }
                }

                UpdateVolume();
                switch (com_c2.SelectedIndex)
                {
                    case 0:
                        ImageNum1 = 4;

                        CountStartAyahPage = 7;
                        break;
                    case 1:
                        ImageNum1 = 5;

                        CountStartAyahPage = 5;

                        break;
                    case 2:
                        ImageNum1 = 50;

                        CountStartAyahPage = 9;

                        break;
                    case 3:
                        ImageNum1 = 77;

                        CountStartAyahPage = 6;

                        break;
                    default:
                        break;
                }



            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            FrmMain form = Application.OpenForms["FrmMain"] as FrmMain;
            FrmCreateDatabase frm = new FrmCreateDatabase();
            frm.MdiParent = form;
            frm.Show();
        }

        private void btn_Sevaing_Click(object sender, EventArgs e)
        {
            FrmMain form = Application.OpenForms["FrmMain"] as FrmMain;
            Frm_db_User frm = new Frm_db_User();
            frm.MdiParent = form;
            frm.Show();
        }
        public void SetDoc()
        {

            string text = this.com_c2.Text;
            if (Operators.CompareString(text, c2[0], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\1.rtf");
            else if (Operators.CompareString(text, c2[1], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\2.rtf");
            else if (Operators.CompareString(text, c2[2], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\3.rtf");
            else if (Operators.CompareString(text, c2[3], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\4.rtf");
            else if (Operators.CompareString(text, c2[4], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\5.rtf");
            else if (Operators.CompareString(text, c2[5], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\6.rtf");
            else if (Operators.CompareString(text, c2[6], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\7.rtf");
            else if (Operators.CompareString(text, c2[7], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\8.rtf");
            else if (Operators.CompareString(text, c2[8], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\9.rtf");
            else if (Operators.CompareString(text, c2[9], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\10.rtf");
            else if (Operators.CompareString(text, c2[10], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\11.rtf");
            else if (Operators.CompareString(text, c2[11], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\12.rtf");
            else if (Operators.CompareString(text, c2[12], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\13.rtf");
            else if (Operators.CompareString(text, c2[13], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\14.rtf");
            else if (Operators.CompareString(text, c2[14], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\15.rtf");
            else if (Operators.CompareString(text, c2[15], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\16.rtf");
            else if (Operators.CompareString(text, c2[16], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\17.rtf");
            else if (Operators.CompareString(text, c2[17], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\18.rtf");
            else if (Operators.CompareString(text, c2[18], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\19.rtf");
            else if (Operators.CompareString(text, c2[19], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\20.rtf");
            else if (Operators.CompareString(text, c2[20], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\21.rtf");
            else if (Operators.CompareString(text, c2[21], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\22.rtf");
            else if (Operators.CompareString(text, c2[22], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\23.rtf");
            else if (Operators.CompareString(text, c2[23], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\24.rtf");
            else if (Operators.CompareString(text, c2[24], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\25.rtf");
            else if (Operators.CompareString(text, c2[25], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\26.rtf");
            else if (Operators.CompareString(text, c2[26], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\27.rtf");
            else if (Operators.CompareString(text, c2[27], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\28.rtf");
            else if (Operators.CompareString(text, c2[28], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\29.rtf");
            else if (Operators.CompareString(text, c2[29], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\30.rtf");
            else if (Operators.CompareString(text, c2[30], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\31.rtf");
            else if (Operators.CompareString(text, c2[31], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\32.rtf");
            else if (Operators.CompareString(text, c2[32], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\33.rtf");
            else if (Operators.CompareString(text, c2[33], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\34.rtf");
            else if (Operators.CompareString(text, c2[34], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\35.rtf");
            else if (Operators.CompareString(text, c2[35], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\36.rtf");
            else if (Operators.CompareString(text, c2[36], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\37.rtf");
            else if (Operators.CompareString(text, c2[37], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\38.rtf");
            else if (Operators.CompareString(text, c2[38], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\39.rtf");
            else if (Operators.CompareString(text, c2[39], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\40.rtf");
            else if (Operators.CompareString(text, c2[40], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\41.rtf");
            else if (Operators.CompareString(text, c2[41], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\42.rtf");
            else if (Operators.CompareString(text, c2[42], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\43.rtf");
            else if (Operators.CompareString(text, c2[43], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\44.rtf");
            else if (Operators.CompareString(text, c2[44], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\45.rtf");
            else if (Operators.CompareString(text, c2[45], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\46.rtf");
            else if (Operators.CompareString(text, c2[46], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\47.rtf");
            else if (Operators.CompareString(text, c2[47], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\48.rtf");
            else if (Operators.CompareString(text, c2[48], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\49.rtf");
            else if (Operators.CompareString(text, c2[49], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\50.rtf");
            else if (Operators.CompareString(text, c2[50], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\51.rtf");
            else if (Operators.CompareString(text, c2[51], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\52.rtf");
            else if (Operators.CompareString(text, c2[52], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\53.rtf");
            else if (Operators.CompareString(text, c2[53], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\54.rtf");
            else if (Operators.CompareString(text, c2[54], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\55.rtf");
            else if (Operators.CompareString(text, c2[55], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\56.rtf");
            else if (Operators.CompareString(text, c2[56], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\57.rtf");
            else if (Operators.CompareString(text, c2[57], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\58.rtf");
            else if (Operators.CompareString(text, c2[58], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\59.rtf");
            else if (Operators.CompareString(text, c2[59], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\60.rtf");
            else if (Operators.CompareString(text, c2[60], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\61.rtf");
            else if (Operators.CompareString(text, c2[61], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\62.rtf");
            else if (Operators.CompareString(text, c2[62], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\63.rtf");
            else if (Operators.CompareString(text, c2[63], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\64.rtf");
            else if (Operators.CompareString(text, c2[64], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\65.rtf");
            else if (Operators.CompareString(text, c2[65], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\66.rtf");
            else if (Operators.CompareString(text, c2[66], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\67.rtf");
            else if (Operators.CompareString(text, c2[67], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\68.rtf");
            else if (Operators.CompareString(text, c2[68], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\69.rtf");
            else if (Operators.CompareString(text, c2[69], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\70.rtf");
            else if (Operators.CompareString(text, c2[70], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\71.rtf");
            else if (Operators.CompareString(text, c2[71], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\72.rtf");
            else if (Operators.CompareString(text, c2[72], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\73.rtf");
            else if (Operators.CompareString(text, c2[73], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\74.rtf");
            else if (Operators.CompareString(text, c2[74], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\75.rtf");
            else if (Operators.CompareString(text, c2[75], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\76.rtf");
            else if (Operators.CompareString(text, c2[76], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\77.rtf");
            else if (Operators.CompareString(text, c2[77], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\78.rtf");
            else if (Operators.CompareString(text, c2[78], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\79.rtf");
            else if (Operators.CompareString(text, c2[79], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\80.rtf");
            else if (Operators.CompareString(text, c2[80], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\81.rtf");
            else if (Operators.CompareString(text, c2[81], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\82.rtf");
            else if (Operators.CompareString(text, c2[82], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\83.rtf");
            else if (Operators.CompareString(text, c2[83], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\84.rtf");
            else if (Operators.CompareString(text, c2[84], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\85.rtf");
            else if (Operators.CompareString(text, c2[85], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\86.rtf");
            else if (Operators.CompareString(text, c2[86], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\87.rtf");
            else if (Operators.CompareString(text, c2[87], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\88.rtf");
            else if (Operators.CompareString(text, c2[88], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\89.rtf");
            else if (Operators.CompareString(text, c2[89], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\90.rtf");
            else if (Operators.CompareString(text, c2[90], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\91.rtf");
            else if (Operators.CompareString(text, c2[91], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\92.rtf");
            else if (Operators.CompareString(text, c2[92], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\93.rtf");
            else if (Operators.CompareString(text, c2[93], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\94.rtf");
            else if (Operators.CompareString(text, c2[94], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\95.rtf");
            else if (Operators.CompareString(text, c2[95], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\96.rtf");
            else if (Operators.CompareString(text, c2[96], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\97.rtf");
            else if (Operators.CompareString(text, c2[97], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\98.rtf");
            else if (Operators.CompareString(text, c2[98], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\99.rtf");
            else if (Operators.CompareString(text, c2[99], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\100.rtf");
            else if (Operators.CompareString(text, c2[100], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\101.rtf");
            else if (Operators.CompareString(text, c2[101], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\102.rtf");
            else if (Operators.CompareString(text, c2[102], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\103.rtf");
            else if (Operators.CompareString(text, c2[103], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\104.rtf");
            else if (Operators.CompareString(text, c2[104], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\105.rtf");
            else if (Operators.CompareString(text, c2[105], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\106.rtf");
            else if (Operators.CompareString(text, c2[106], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\107.rtf");
            else if (Operators.CompareString(text, c2[107], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\108.rtf");
            else if (Operators.CompareString(text, c2[108], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\109.rtf");
            else if (Operators.CompareString(text, c2[109], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\110.rtf");
            else if (Operators.CompareString(text, c2[110], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\111.rtf");
            else if (Operators.CompareString(text, c2[111], false) == 0)
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\112.rtf");
            else if (Operators.CompareString(text, c2[112], false) == 0)
            {
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\113.rtf");
            }
            else
            {
                if (Operators.CompareString(text, c2[113], false) != 0)
                    return;
                this.Rich_teb_1.LoadFile(Application.StartupPath + "\\Word\\Qrena\\114.rtf");
            }
        }

        private void Frm_Seva_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanUp();
        }

        private void btn_Frm_Mushaf_Click(object sender, EventArgs e)
        {
            Frm_Mushaf frm = new Frm_Mushaf(pathK, ImageNum1, ImageNum2, startSurah, CountStartAyahPage);
            frm.Show();
        }
       
      
        private VolumeWaveProvider16 volumeProvider;
        
       
     
    }
}
