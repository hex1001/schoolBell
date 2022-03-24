using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
namespace SchoolBell
{
    public partial class MainForm : Form
    {
        #region Vaiables
       
        private static SerialPort _serialPort;
        private String _port;// = "COM1";
        private static bool _isDown;
        private static bool _isRun;
        private DateTime _dt;
        private volatile int _hourBegin11;
        private volatile int _hourBegin12;
        private volatile int _hourBegin13;
        private volatile int _hourBegin14;
        private volatile int _hourBegin15;
        private volatile int _hourBegin16;
        private volatile int _hourBegin17;
        private volatile int _hourBegin21;
        private volatile int _hourBegin22;
        private volatile int _hourBegin23;
        private volatile int _hourBegin24;
        private volatile int _hourBegin25;
        private volatile int _hourBegin26;
        private volatile int _minutBegin11;
        private volatile int _minutBegin12;
        private volatile int _minutBegin13;
        private volatile int _minutBegin14;
        private volatile int _minutBegin15;
        private volatile int _minutBegin16;
        private volatile int _minutBegin17;
        private volatile int _minutBegin21;
        private volatile int _minutBegin22;
        private volatile int _minutBegin23;
        private volatile int _minutBegin24;
        private volatile int _minutBegin25;
        private volatile int _minutBegin26;
        private volatile int _hourFinish11;
        private volatile int _hourFinish12;
        private volatile int _hourFinish13;
        private volatile int _hourFinish14;
        private volatile int _hourFinish15;
        private volatile int _hourFinish16;
        private volatile int _hourFinish17;
        private volatile int _hourFinish21;
        private volatile int _hourFinish22;
        private volatile int _hourFinish23;
        private volatile int _hourFinish24;
        private volatile int _hourFinish25;
        private volatile int _hourFinish26;
        private volatile int _minutFinish11;
        private volatile int _minutFinish12;
        private volatile int _minutFinish13;
        private volatile int _minutFinish14;
        private volatile int _minutFinish15;
        private volatile int _minutFinish16;
        private volatile int _minutFinish17;
        private volatile int _minutFinish21;
        private volatile int _minutFinish22;
        private volatile int _minutFinish23;
        private volatile int _minutFinish24;
        private volatile int _minutFinish25;
        private volatile int _minutFinish26;
        private volatile int _sekundInterval;
        private Thread _thread;
        private Thread _threadTime;

        #endregion
        private void Mythread()
        {
            while (true)
            {
                if (_isDown)
                {
                    try
                    {
                        if (!_serialPort.IsOpen)
                            _serialPort.Open();
                        _serialPort.WriteLine("1");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (!_isDown)
                {
                    try
                    {
                        if (!_serialPort.IsOpen)
                            _serialPort.Open();
                        _serialPort.WriteLine("0");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }

                
            }
            
// ReSharper disable FunctionNeverReturns
        }
// ReSharper restore FunctionNeverReturns
        public MainForm()
        {
            InitializeComponent();
           
            ReadConfig();
            _serialPort = new SerialPort(_port, 9600, Parity.None, 8, StopBits.One);
        }
        private void ReadConfig()
        {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\config.ini");
            string [] line;
            //list = new List<string>();
            try
            {
                #region
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _port = line[1];
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin11 = Int32.Parse(line[1]);
                numBeginH1.Value = _hourBegin11;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin12 = Int32.Parse(line[1]);
                numBeginH2.Value = _hourBegin12;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin13 = Int32.Parse(line[1]);
                numBeginH3.Value = _hourBegin13;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin14 = Int32.Parse(line[1]);
                numBeginH4.Value = _hourBegin14;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin15 = Int32.Parse(line[1]);
                numBeginM5.Value = _hourBegin15;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin16 = Int32.Parse(line[1]);
                numBeginH6.Value = _hourBegin16;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin17 = Int32.Parse(line[1]);
                numBeginH7.Value = _hourBegin17;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin21 = Int32.Parse(line[1]);
                numBeginH2_1.Value = _hourBegin21;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin22 = Int32.Parse(line[1]);
                numBeginH2_2.Value = _hourBegin22;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin23 = Int32.Parse(line[1]);
                numBeginH2_3.Value = _hourBegin23;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin24 = Int32.Parse(line[1]);
                numBeginH2_4.Value = _hourBegin24;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin25 = Int32.Parse(line[1]);
                numBeginH2_5.Value = _hourBegin25;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourBegin26 = Int32.Parse(line[1]);
                numBeginH2_6.Value = _hourBegin26;
                /////////////////////////////////////
                
                
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin11 = Int32.Parse(line[1]);
                numBeginM1.Value = _minutBegin11;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin12 = Int32.Parse(line[1]);
                numBeginM2.Value = _minutBegin12;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin13 = Int32.Parse(line[1]);
                numBeginM3.Value = _minutBegin13;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin14 = Int32.Parse(line[1]);
                numBeginM4.Value = _minutBegin14;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin15 = Int32.Parse(line[1]);
                numBeginM5.Value = _minutBegin15;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin16 = Int32.Parse(line[1]);
                numBeginM6.Value = _minutBegin16;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin17 = Int32.Parse(line[1]);
                numBeginM7.Value = _minutBegin17;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin21 = Int32.Parse(line[1]);
                numBeginM2_1.Value = _minutBegin21;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin22 = Int32.Parse(line[1]);
                numBeginM2_2.Value = _minutBegin22;
                ///////////////////////////////////// 
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin23 = Int32.Parse(line[1]);
                numBeginM2_3.Value = _minutBegin23;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin24 = Int32.Parse(line[1]);
                numBeginM2_4.Value = _minutBegin24;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin25 = Int32.Parse(line[1]);
                numBeginM2_5.Value = _minutBegin25;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutBegin26 = Int32.Parse(line[1]);
                numBeginM2_6.Value = _minutBegin26;
                /////////////////////////////////////
                
                
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish11 = Int32.Parse(line[1]);
                numFinishH1_1.Value = _hourFinish11;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish12 = Int32.Parse(line[1]);
                numFinishH1_2.Value = _hourFinish12;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish13 = Int32.Parse(line[1]);
                numFinishH1_3.Value = _hourFinish13;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish14 = Int32.Parse(line[1]);
                numFinishH1_4.Value = _hourFinish14;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish15 = Int32.Parse(line[1]);
                numFinishH1_5.Value = _hourFinish15;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish16 = Int32.Parse(line[1]);
                numFinishH1_6.Value = _hourFinish16;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish17 = Int32.Parse(line[1]);
                numFinishH1_7.Value = _hourFinish17;
                /////////////////////////////////////
                

                line = sr.ReadLine().Trim().Split('=');
                _hourFinish21 = Int32.Parse(line[1]);
                numFinishH2_1.Value = _hourFinish21;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish22 = Int32.Parse(line[1]);
                numFinishH2_2.Value = _hourFinish22;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish23 = Int32.Parse(line[1]);
                numFinishH2_3.Value = _hourFinish23;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish24 = Int32.Parse(line[1]);
                numFinishH2_4.Value = _hourFinish24;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish25 = Int32.Parse(line[1]);
                numFinishH2_5.Value = _hourFinish25;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _hourFinish26 = Int32.Parse(line[1]);
                numFinishH2_6.Value = _hourFinish26;
                /////////////////////////////////////


                line = sr.ReadLine().Trim().Split('=');
                _minutFinish11 = Int32.Parse(line[1]);
                numFinishM1_1.Value = _minutFinish11;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish12 = Int32.Parse(line[1]);
                numFinishM1_2.Value = _minutFinish12;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish13 = Int32.Parse(line[1]);
                numFinishM1_3.Value = _minutFinish13;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish14 = Int32.Parse(line[1]);
                numFinishM1_4.Value = _minutFinish14;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish15 = Int32.Parse(line[1]);
                numFinishM1_5.Value = _minutFinish15;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish16 = Int32.Parse(line[1]);
                numFinishM1_6.Value = _minutFinish16;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish17 = Int32.Parse(line[1]);
                numFinishM1_7.Value = _minutFinish17;
                /////////////////////////////////////

                
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish21 = Int32.Parse(line[1]);
                numFinishM2_1.Value = _minutFinish21;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish22 = Int32.Parse(line[1]);
                numFinishM2_2.Value = _minutFinish22;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish23 = Int32.Parse(line[1]);
                numFinishM2_3.Value = _minutFinish23;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish24 = Int32.Parse(line[1]);
                numFinishM2_4.Value = _minutFinish24;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish25 = Int32.Parse(line[1]);
                numFinishM2_5.Value = _minutFinish25;
                /////////////////////////////////////
                line = sr.ReadLine().Trim().Split('=');
                _minutFinish26 = Int32.Parse(line[1]);
                numFinishM2_6.Value = _minutFinish26;
                /////////////////////////////////////

                line = sr.ReadLine().Trim().Split('=');
                _sekundInterval = Int32.Parse(line[1]);
                numericInterval.Value = _sekundInterval;
                /////////////////////////////////////
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sr.Close();
            }
            sr.Close();
        }
        private void WriteConfig()
        {
            #region
            using (StreamWriter w = new StreamWriter(Directory.GetCurrentDirectory() + @"\config.ini"))
            {
                
                w.WriteLine(String.Format("COMPORT={0}", _port));
                w.WriteLine(String.Format("_hourBegin11={0}", _hourBegin11));
                w.WriteLine(String.Format("_hourBegin12={0}", _hourBegin12));
                w.WriteLine(String.Format("_hourBegin13={0}", _hourBegin13));
                w.WriteLine(String.Format("_hourBegin14={0}", _hourBegin14));
                w.WriteLine(String.Format("_hourBegin15={0}", _hourBegin15));
                w.WriteLine(String.Format("_hourBegin16={0}", _hourBegin16));
                w.WriteLine(String.Format("_hourBegin17={0}", _hourBegin17));
                w.WriteLine(String.Format("_hourBegin21={0}", _hourBegin21));
                w.WriteLine(String.Format("_hourBegin22={0}", _hourBegin22));
                w.WriteLine(String.Format("_hourBegin23={0}", _hourBegin23));
                w.WriteLine(String.Format("_hourBegin24={0}", _hourBegin24));
                w.WriteLine(String.Format("_hourBegin25={0}", _hourBegin25));
                w.WriteLine(String.Format("_hourBegin26={0}", _hourBegin26));
                w.WriteLine(String.Format("_minutBegin11={0}", _minutBegin11));
                w.WriteLine(String.Format("_minutBegin12={0}", _minutBegin12));
                w.WriteLine(String.Format("_minutBegin13={0}", _minutBegin13));
                w.WriteLine(String.Format("_minutBegin14={0}", _minutBegin14));
                w.WriteLine(String.Format("_minutBegin15={0}", _minutBegin15));
                w.WriteLine(String.Format("_minutBegin16={0}", _minutBegin16));
                w.WriteLine(String.Format("_minutBegin17={0}", _minutBegin17));
                w.WriteLine(String.Format("_minutBegin21={0}", _minutBegin21));
                w.WriteLine(String.Format("_minutBegin22={0}", _minutBegin22));
                w.WriteLine(String.Format("_minutBegin23={0}", _minutBegin23));
                w.WriteLine(String.Format("_minutBegin24={0}", _minutBegin24));
                w.WriteLine(String.Format("_minutBegin25={0}", _minutBegin25));
                w.WriteLine(String.Format("_minutBegin26={0}", _minutBegin26));
                w.WriteLine(String.Format("_hourFinish11={0}", _hourFinish11));
                w.WriteLine(String.Format("_hourFinish12={0}", _hourFinish12));
                w.WriteLine(String.Format("_hourFinish13={0}", _hourFinish13));
                w.WriteLine(String.Format("_hourFinish14={0}", _hourFinish14));
                w.WriteLine(String.Format("_hourFinish15={0}", _hourFinish15));
                w.WriteLine(String.Format("_hourFinish16={0}", _hourFinish16));
                w.WriteLine(String.Format("_hourFinish17={0}", _hourFinish17));
                w.WriteLine(String.Format("_hourFinish21={0}", _hourFinish21));
                w.WriteLine(String.Format("_hourFinish22={0}", _hourFinish22));
                w.WriteLine(String.Format("_hourFinish23={0}", _hourFinish23));
                w.WriteLine(String.Format("_hourFinish24={0}", _hourFinish24));
                w.WriteLine(String.Format("_hourFinish25={0}", _hourFinish25));
                w.WriteLine(String.Format("_hourFinish26={0}", _hourFinish26));
                w.WriteLine(String.Format("_minutFinish11={0}", _minutFinish11));
                w.WriteLine(String.Format("_minutFinish12={0}", _minutFinish12));
                w.WriteLine(String.Format("_minutFinish13={0}", _minutFinish13));
                w.WriteLine(String.Format("_minutFinish14={0}", _minutFinish14));
                w.WriteLine(String.Format("_minutFinish15={0}", _minutFinish15));
                w.WriteLine(String.Format("_minutFinish16={0}", _minutFinish16));
                w.WriteLine(String.Format("_minutFinish17={0}", _minutFinish17));
                w.WriteLine(String.Format("_minutFinish21={0}", _minutFinish21));
                w.WriteLine(String.Format("_minutFinish22={0}", _minutFinish22));
                w.WriteLine(String.Format("_minutFinish23={0}", _minutFinish23));
                w.WriteLine(String.Format("_minutFinish24={0}", _minutFinish24));
                w.WriteLine(String.Format("_minutFinish25={0}", _minutFinish25));
                w.WriteLine(String.Format("_minutFinish26={0}", _minutFinish26));
                w.WriteLine(String.Format("_sekundInterval={0}", _sekundInterval));

            }
            #endregion
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _thread = new Thread(Mythread);
            _thread.Start();
            _thread.IsBackground = true;
            _threadTime = new Thread(CheckTime);
            _threadTime.Start();
            _threadTime.IsBackground = true;
        }

        private void btnBell_MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
        }
        private void btnBell_MouseUp(object sender, MouseEventArgs e)
        {
            _isDown = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_serialPort.IsOpen)
                _serialPort.Close();
            WriteConfig();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();

        }

        private void CheckTime()
        {
            #region

            while (true)
            {


                int h = DateTime.Now.Hour;
                int m = DateTime.Now.Minute;
                int s = DateTime.Now.Second;

                if (!_isRun &&
                    ((h == _hourBegin11 && m == _minutBegin11 && s >= 0 && s < 2 && checkBoxRun1_1.Checked) ||
                     (h == _hourBegin12 && m == _minutBegin12 && s >= 0 && s < 2 && checkBoxRun1_2.Checked) ||
                     (h == _hourBegin13 && m == _minutBegin13 && s >= 0 && s < 2 && checkBoxRun1_3.Checked) ||
                     (h == _hourBegin14 && m == _minutBegin14 && s >= 0 && s < 2 && checkBoxRun1_4.Checked) ||
                     (h == _hourBegin15 && m == _minutBegin15 && s >= 0 && s < 2 && checkBoxRun1_5.Checked) ||
                     (h == _hourBegin16 && m == _minutBegin16 && s >= 0 && s < 2 && checkBoxRun1_6.Checked) ||
                     (h == _hourBegin17 && m == _minutBegin17 && s >= 0 && s < 2 && checkBoxRun1_7.Checked) ||

                     (h == _hourBegin21 && m == _minutBegin21 && s >= 0 && s < 2 && checkBoxRun2_1.Checked) ||
                     (h == _hourBegin22 && m == _minutBegin22 && s >= 0 && s < 2 && checkBoxRun2_2.Checked) ||
                     (h == _hourBegin23 && m == _minutBegin23 && s >= 0 && s < 2 && checkBoxRun2_3.Checked) ||
                     (h == _hourBegin24 && m == _minutBegin24 && s >= 0 && s < 2 && checkBoxRun2_4.Checked) ||
                     (h == _hourBegin25 && m == _minutBegin25 && s >= 0 && s < 2 && checkBoxRun2_5.Checked) ||
                     (h == _hourBegin26 && m == _minutBegin26 && s >= 0 && s < 2 && checkBoxRun2_6.Checked) ||

                     (h == _hourFinish11 && m == _minutFinish11 && s >= 0 && s < 2 && checkBoxRun1_1.Checked) ||
                     (h == _hourFinish12 && m == _minutFinish12 && s >= 0 && s < 2 && checkBoxRun1_2.Checked) ||
                     (h == _hourFinish13 && m == _minutFinish13 && s >= 0 && s < 2 && checkBoxRun1_3.Checked) ||
                     (h == _hourFinish14 && m == _minutFinish14 && s >= 0 && s < 2 && checkBoxRun1_4.Checked) ||
                     (h == _hourFinish15 && m == _minutFinish15 && s >= 0 && s < 2 && checkBoxRun1_5.Checked) ||
                     (h == _hourFinish16 && m == _minutFinish16 && s >= 0 && s < 2 && checkBoxRun1_6.Checked) ||
                     (h == _hourFinish17 && m == _minutFinish17 && s >= 0 && s < 2 && checkBoxRun1_7.Checked) ||

                     (h == _hourFinish21 && m == _minutFinish21 && s >= 0 && s < 2 && checkBoxRun2_1.Checked) ||
                     (h == _hourFinish22 && m == _minutFinish22 && s >= 0 && s < 2 && checkBoxRun2_2.Checked) ||
                     (h == _hourFinish23 && m == _minutFinish23 && s >= 0 && s < 2 && checkBoxRun2_3.Checked) ||
                     (h == _hourFinish24 && m == _minutFinish24 && s >= 0 && s < 2 && checkBoxRun2_4.Checked) ||
                     (h == _hourFinish25 && m == _minutFinish25 && s >= 0 && s < 2 && checkBoxRun2_5.Checked) ||
                     (h == _hourFinish26 && m == _minutFinish26 && s >= 0 && s < 2 && checkBoxRun2_6.Checked)))
                {
                    _isDown = true;
                    _dt = DateTime.Now.AddSeconds(_sekundInterval);
                    _isRun = true;

                }
                if (h == _dt.Hour && m == _dt.Minute && s >= _dt.Second && _isRun)
                {
                    _isRun = false;
                    _isDown = false;
                }
                Thread.Sleep(10);
            }
            #endregion
        }

        #region
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel1_1.Enabled = !checkBox1_1.Checked;
        }

        private void checkBox1_2_CheckedChanged(object sender, EventArgs e)
        {
            panel1_2.Enabled = !checkBox1_2.Checked;
        }

        private void checkBox1_3_CheckedChanged(object sender, EventArgs e)
        {
            panel1_3.Enabled = !checkBox1_3.Checked;
        }

        private void checkBox1_4_CheckedChanged(object sender, EventArgs e)
        {
            panel1_4.Enabled = !checkBox1_4.Checked;
        }

        private void checkBox1_5_CheckedChanged(object sender, EventArgs e)
        {
            panel1_5.Enabled = !checkBox1_5.Checked;
        }

        private void checkBox1_6_CheckedChanged(object sender, EventArgs e)
        {
            panel1_6.Enabled = !checkBox1_6.Checked;
        }

        private void checkBox2_1_CheckedChanged(object sender, EventArgs e)
        {
            panel2_1.Enabled = !checkBox2_1.Checked;
        }

        private void checkBox2_2_CheckedChanged(object sender, EventArgs e)
        {
            panel2_2.Enabled = !checkBox2_2.Checked;
        }

        private void checkBox2_3_CheckedChanged(object sender, EventArgs e)
        {
            panel2_3.Enabled = !checkBox2_3.Checked;
        }

        private void checkBox2_4_CheckedChanged(object sender, EventArgs e)
        {
            panel2_4.Enabled = !checkBox2_4.Checked;
        }

        private void checkBox2_5_CheckedChanged(object sender, EventArgs e)
        {
            panel2_5.Enabled = !checkBox2_5.Checked;
        }

        private void checkBox2_6_CheckedChanged(object sender, EventArgs e)
        {
            panel2_6.Enabled = !checkBox2_6.Checked;
        }

        private void numBeginH1_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin11 = (int) numBeginH1.Value;
        }

        private void numBeginH2_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin12 = (int) numBeginH2.Value;
        }

        private void numBeginM1_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin11 = (int) numBeginM1.Value;
        }

       

        private void numericInterval_ValueChanged(object sender, EventArgs e)
        {
            _sekundInterval = (int) numericInterval.Value;
        }


        private void numBeginM2_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin12 = (int) numBeginM2.Value;
        }

        private void numBeginM3_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin13 = (int)numBeginM3.Value;
        }

        private void numBeginM4_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin14 = (int)numBeginM4.Value;
        }

        private void numBeginM5_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin15 = (int)numBeginM5.Value;
        }

        private void numBeginM6_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin16 = (int)numBeginM6.Value;
        }

        private void numBeginM7_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin17 = (int)numBeginM7.Value;
        }

        private void numFinishM1_1_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish11 = (int) numFinishM1_1.Value;
        }

        private void numFinishM1_2_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish12 = (int)numFinishM1_2.Value;
        }

        private void numFinishM1_3_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish13 = (int)numFinishM1_3.Value;
        }

        private void numFinishM1_4_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish14 = (int)numFinishM1_4.Value;
        }

        private void numFinishM1_5_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish15 = (int)numFinishM1_5.Value;
        }

        private void numFinishM1_6_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish16 = (int)numFinishM1_6.Value;
        }

        private void numFinishM1_7_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish17 = (int)numFinishM1_7.Value;
        }

        private void numFinishH1_1_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish11 = (int) numFinishH1_1.Value;
        }

        private void numFinishH1_2_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish12 = (int)numFinishH1_2.Value;
        }

        private void numFinishH1_3_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish13 = (int)numFinishH1_3.Value;
        }

        private void numFinishH1_4_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish14 = (int)numFinishH1_4.Value;
        }

        private void numFinishH1_5_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish15 = (int)numFinishH1_5.Value;
        }

        private void numFinishH1_6_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish16 = (int)numFinishH1_6.Value;
        }

        private void numFinishH1_7_ValueChanged_1(object sender, EventArgs e)
        {
            _hourFinish17 = (int)numFinishH1_7.Value;
        }

        private void numBeginH2_1_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin21 = (int)numBeginH2_1.Value;
        }

        private void numBeginH2_2_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin22 = (int)numBeginH2_2.Value;
        }

        private void numBeginH2_3_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin23 = (int)numBeginH2_3.Value;
        }

        private void numBeginH2_4_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin24 = (int)numBeginH2_4.Value;
        }

        private void numBeginH2_5_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin25 = (int)numBeginH2_5.Value;
        }

        private void numBeginH2_6_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin26 = (int)numBeginH2_6.Value;
        }

        private void numFinishH2_1_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish21 = (int) numFinishH2_1.Value;
        }

        private void numFinishH2_2_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish22 = (int)numFinishH2_2.Value;
        }

        private void numFinishH2_3_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish23 = (int)numFinishH2_3.Value;
        }

        private void numFinishH2_4_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish24 = (int)numFinishH2_4.Value;
        }

        private void numFinishH2_5_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish25 = (int)numFinishH2_5.Value;
        }

        private void numFinishH2_6_ValueChanged(object sender, EventArgs e)
        {
            _hourFinish26 = (int)numFinishH2_6.Value;
        }

        

        private void numFinishM2_1_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish21 = (int) numFinishM2_1.Value;
        }

        private void numFinishM2_2_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish22 = (int)numFinishM2_2.Value;
        }

        private void numFinishM2_3_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish23 = (int)numFinishM2_3.Value;
        }

        private void numFinishM2_4_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish24 = (int)numFinishM2_4.Value;
        }

        private void numFinishM2_5_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish25 = (int)numFinishM2_5.Value;
        }

        private void numFinishM2_6_ValueChanged(object sender, EventArgs e)
        {
            _minutFinish26 = (int)numFinishM2_6.Value;
        }

        private void numBeginH3_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin13 = (int)numBeginH3.Value;
        }

        private void numBeginH4_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin14 = (int)numBeginH4.Value;
        }

        private void numBeginH5_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin15 = (int)numBeginH5.Value;
        }

        private void numBeginH6_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin16 = (int)numBeginH6.Value;
        }

        private void numBeginH7_ValueChanged(object sender, EventArgs e)
        {
            _hourBegin17 = (int)numBeginH7.Value;
        }

        private void numBeginM2_2_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin22 = (int) numBeginM2_2.Value;
        }

        private void numBeginM2_1_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin21 = (int)numBeginM2_1.Value;
        }

        private void numBeginM2_3_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin23 = (int)numBeginM2_3.Value;
        }

        private void numBeginM2_4_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin24 = (int)numBeginM2_4.Value;
        }

        private void numBeginM2_5_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin25 = (int)numBeginM2_5.Value;
        }

        private void numBeginM2_6_ValueChanged(object sender, EventArgs e)
        {
            _minutBegin26 = (int)numBeginM2_6.Value;
        }
        #endregion

        private void checkBox1_7_CheckedChanged(object sender, EventArgs e)
        {
            panel1_7.Enabled = !checkBox1_7.Checked;
        }

    }
}
