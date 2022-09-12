using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAutoHelper;

namespace TaiAnhZaloADB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            FormClosing += Main_FormClosing;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadding(false);
            System.Threading.Thread.Sleep(200);
        }

        Bitmap imgShowMore, imgDownload;
        BackgroundWorker backgroundWorker;
        private void Main_Load(object sender, EventArgs e)
        {
            lblThongBao.Text = "";

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            progressBar.Visible = false;
            progressBar.Step = 1;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;

            tmr.Tick += Tmr_Tick;
            btnTaiAnh.Click += BtnTaiAnh_Click;
            btnDung.Click += BtnDung_Click;

            //tải ảnh
            imgShowMore = (Bitmap)Bitmap.FromFile("showmore.png");
            imgDownload = (Bitmap)Bitmap.FromFile("textdownload.png");
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadding(false);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Kiểm tra xem có thiết bị nào đang kết nối hay không
            var lstDevices = ADBHelper.GetDevices();
            if (lstDevices.Count == 0)
            {
                ShowWaring("Không có thiết bị nào được kết nối");
                return;
            }

            if (lstDevices.Count > 1)
            {
                ShowWaring("Chỉ có thể kết nối 1 thiết bị 1 lúc");
                return;
            }

            string deviceId = lstDevices[0];

            bool next;
            while (!stop)
            {
                try
                {
                    next = false;
                    Point? point = null;
                    //b1: tìm dấu 3 chấm, ko có thì chạm vào màn hình
                    while (!stop && !next)
                    {
                        DatThongBaoThread("Tìm dấu 3 chấm");
                        var screen = ADBHelper.ScreenShoot(deviceId);
                        point = ImageScanOpenCV.FindOutPoint(screen, imgShowMore);
                        if (point != null)
                        {
                            next = true;
                        }
                        else
                        {
                            //nhấn màn 1 cái rồi tìm tiếp
                            System.Threading.Thread.Sleep(2000);
                            ADBHelper.TapByPercent(deviceId, 50, 50);
                        }
                    }
                    //b2: nhấn 3 chấm
                    next = false;
                    while (!stop && !next)
                    {
                        DatThongBaoThread("Nhấn dấu 3 chấm");
                        point = point ?? new Point(0,0);
                        ADBHelper.Tap(deviceId, point.Value.X, point.Value.Y);
                        next = true;
                    }
                    //b3: nhấn tải ảnh
                    next = false;
                    while (!stop && !next)
                    {
                        DatThongBaoThread("Nhấn tải ảnh");
                        var screen = ADBHelper.ScreenShoot(deviceId);
                        point = ImageScanOpenCV.FindOutPoint(screen, imgDownload);
                        if (point != null)
                        {
                            ADBHelper.Tap(deviceId, point.Value.X, point.Value.Y);
                            next = true;
                        }
                    }
                    //b4: lướt sang ảnh khác
                    next = false;
                    while (!stop && !next)
                    {
                        DatThongBaoThread("Lướt cái tiếp theo");
                        ADBHelper.Swipe(deviceId, 200, 300, 10, 300, 100);
                        next = true;
                    }
                }
                catch (Exception ex)
                {
                    DatThongBaoThread("Error: " + ex.Message);
                    stop = true;
                }
            }
        }

        private void DatThongBaoThread(string text)
        {
            Invoke(new MethodInvoker(delegate {
                lblThongBao.Text = text;
            }));
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            tmr.Enabled = false;
            if (progressBar.Value == progressBar.Maximum)
            {
                progressBar.Value = progressBar.Minimum;
            }
            else
            {
                progressBar.PerformStep();
            }
            tmr.Enabled = true;
        }
        private void BtnDung_Click(object sender, EventArgs e)
        {
            loadding(false);
        }
        private void loadding(bool run)
        {
            stop = !run;
            tmr.Enabled = run;
            progressBar.Visible = run;
            if (!run) progressBar.Value = 0;
            btnTaiAnh.Enabled = !run;
            if (!run && !lblThongBao.Text.Contains("Error:")) lblThongBao.Text = "";
        }

        private bool stop = true;
        private void BtnTaiAnh_Click(object sender, EventArgs e)
        {
            loadding(true);
            backgroundWorker.RunWorkerAsync();
        }

        private void ShowWaring(string text)
        {
            MessageBox.Show(text, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
