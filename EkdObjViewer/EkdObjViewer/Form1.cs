using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EkdObjViewer.Resources;
using EkdObjViewer.Utils;
using System.Drawing.Imaging;

using System.IO;

namespace EkdObjViewer
{
    public partial class Form1 : Form
    {
        private Config _config;

        private BgLoader _bgLoader;

        private FaceLoader _faceLoader;
        private FaceLargeLoader _faceLargeLoader;

        private PmapobjLoader _frontLoader;
        private PmapobjLoader _backLoader;

        private AtkLoader _atkLoader;
        private MovLoader _movLoader;
        private SpcLoader _spcLoader;

        private int[] AtkIndexes_Down = { 0, 1, 2, 3 };
        private int[] AtkIndexes_Up = { 4, 5, 6, 7 };
        private int[] AtkIndexes_Left = { 8, 9, 10, 11 };

        private int[] MovIndexes_Down = { 100, 100, 101, 101 };
        private int[] MovIndexes_Up = { 102, 102, 103, 103 };
        private int[] MovIndexes_Left = { 104, 104, 105, 105 };

        private int[] DefIndexes_Down = { 106, 106, 200, 200 };
        private int[] DefIndexes_Up = { 107, 107, 201, 201 };
        private int[] DefIndexes_Left = { 108, 108, 202, 202 };

        private int[] PinchIndexes = { 109, 109, 110, 110 };
        private int[] DamageIndexes = { 106, 106, 203, 203 };
        private int[] PoseIndexes = { 106, 108, 107, 400, 106, 204, 204, 204  };

        private int[] PmapMoveIndexes = { 1, 1, 2, 2 };

        private int _currentFrame;

        private Timer _animPlayTimer;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void MainForm1_Load(object sender, EventArgs e)
        {
            this.Text = Program.GetTitle();
            _config = ConfigLoader.Load();
            
            if(!string.IsNullOrEmpty(_config.DirectoryPath))
            {
                panel1.Visible = true;
                LoadDatas();
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void LoadDatas()
        {
            if (_config.BgFileNames.Length <= _config.DefaultBgIndex)
                _config.DefaultBgIndex = 0;

            BgSelector.Items.Clear();
            foreach(var name in _config.BgFileNames)
                BgSelector.Items.Add(name);

            BgSelector.SelectedIndex = _config.DefaultBgIndex;

            _bgLoader = new BgLoader(_config.BgFileNames[BgSelector.SelectedIndex]);

            _faceLoader = new FaceLoader(Path.Combine(_config.DirectoryPath, _config.FaceFileName));
            _faceLargeLoader = new FaceLargeLoader(Path.Combine(_config.DirectoryPath, _config.FaceLargeFileName));

            _frontLoader = new PmapobjLoader(Path.Combine(_config.DirectoryPath, _config.PmapFrontFileName));
            _backLoader = new PmapobjLoader(Path.Combine(_config.DirectoryPath, _config.PmapBackFileName));

            _atkLoader = new AtkLoader(Path.Combine(_config.DirectoryPath, _config.AtkFileName));
            _movLoader = new MovLoader(Path.Combine(_config.DirectoryPath, _config.MovFileName));
            _spcLoader = new SpcLoader(Path.Combine(_config.DirectoryPath, _config.SpcFileName));

            _animPlayTimer = new Timer();
            _animPlayTimer.Tick += new EventHandler(Tick);


            _bgLoader.Load();

            _faceLoader.Load();
            _faceLargeLoader.Load();

            _frontLoader.Load();
            _backLoader.Load();

            _atkLoader.Load();
            _movLoader.Load();
            _spcLoader.Load();

            Face.Image = _faceLoader.GetImage();
            FaceLarge.Image = _faceLargeLoader.GetImage();

            SpeedSelectBox.SelectedIndex = _config.DefaultSpeedIndex;
        }
        
        private void Tick(object sender, EventArgs e)
        {
            int frame = _currentFrame;
            
            background.Image = GetBattleObjFrame(frame);
            PmapObj.Image = GetPmapObjFrame(frame, BackColor);

            _currentFrame++;

            if (_currentFrame >= Int32.MaxValue) _currentFrame = 0;
        }
        

        private Bitmap GetBattleObjImage(int index)
        {
            if (index == 400)
            {
                var image = _movLoader.GetFrameImage(8);
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                return image;
            }
            if (index < 100) return _atkLoader.GetFrameImage(index);
            else if (index >= 100 && index < 200) return _movLoader.GetFrameImage(index - 100);
            else return _spcLoader.GetFrameImage(index - 200);
        }

        private void SpeedSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.DefaultSpeedIndex = SpeedSelectBox.SelectedIndex;
            ConfigLoader.Save(_config);

            _animPlayTimer.Stop();
            
            switch(SpeedSelectBox.SelectedIndex)
            {
                case 0:
                    _animPlayTimer.Interval = 400;
                    break;
                case 1:
                    _animPlayTimer.Interval = 200;
                    break;
                case 2:
                    _animPlayTimer.Interval = 100;
                    break;
                case 3:
                    _animPlayTimer.Interval = 50;
                    break;
            }
            _animPlayTimer.Start();
        }

        private Bitmap GetBattleObjFrame(int frame)
        {
            try
            {
                var bg = _bgLoader.GetImage();
                background.Image = bg;
                var source = background.Image as Bitmap;

                int initX = 3;
                int initY = 3;
                int deltaX = 70;
                int deltaY = 70;
                using (var g = Graphics.FromImage(source))
                {
                    int x = initX;
                    int y = initY;
                    g.DrawImage(GetBattleObjImage(AtkIndexes_Down[frame % AtkIndexes_Down.Length]), new Rectangle(x, y, 64, 64));
                    x += deltaX;
                    g.DrawImage(GetBattleObjImage(AtkIndexes_Up[frame % AtkIndexes_Up.Length]), new Rectangle(x, y, 64, 64));
                    x += deltaX;
                    g.DrawImage(GetBattleObjImage(AtkIndexes_Left[frame % AtkIndexes_Left.Length]), new Rectangle(x, y, 64, 64));

                    y += deltaY;
                    x = initX;
                    x += 8;
                    y += 8;
                    g.DrawImage(GetBattleObjImage(MovIndexes_Down[frame % MovIndexes_Down.Length]), new Rectangle(x, y, 48, 48));
                    x += deltaX;
                    g.DrawImage(GetBattleObjImage(MovIndexes_Up[frame % MovIndexes_Up.Length]), new Rectangle(x, y, 48, 48));
                    x += deltaX;
                    g.DrawImage(GetBattleObjImage(MovIndexes_Left[frame % MovIndexes_Left.Length]), new Rectangle(x, y, 48, 48));

                    y += deltaY;
                    x = initX;
                    x += 8;
                    g.DrawImage(GetBattleObjImage(DefIndexes_Down[frame % DefIndexes_Down.Length]), new Rectangle(x, y, 48, 48));
                    x += deltaX;
                    g.DrawImage(GetBattleObjImage(DefIndexes_Up[frame % DefIndexes_Up.Length]), new Rectangle(x, y, 48, 48));
                    x += deltaX;
                    g.DrawImage(GetBattleObjImage(DefIndexes_Left[frame % DefIndexes_Left.Length]), new Rectangle(x, y, 48, 48));

                    y += deltaY;
                    x = initX;
                    x += 8;
                    g.DrawImage(GetBattleObjImage(PinchIndexes[frame % PinchIndexes.Length]), new Rectangle(x, y, 48, 48));
                    x += deltaX;
                    g.DrawImage(GetBattleObjImage(DamageIndexes[frame % DamageIndexes.Length]), new Rectangle(x, y, 48, 48));
                    x += deltaX;
                    g.DrawImage(GetBattleObjImage(PoseIndexes[frame % PoseIndexes.Length]), new Rectangle(x, y, 48, 48));
                }
                return source;
            }
            catch
            {
                return null;
            }
        }

        private void SaveGIFButton_Click(object sender, EventArgs e)
        {
            try
            {
                var imageArray = new Image[] {
                GetBattleObjFrame(0),
                GetBattleObjFrame(1),
                GetBattleObjFrame(2),
                GetBattleObjFrame(3),
                GetBattleObjFrame(4),
                GetBattleObjFrame(5),
                GetBattleObjFrame(6),
                GetBattleObjFrame(7),
            };

                double delay = 0;

                switch (SpeedSelectBox.SelectedIndex)
                {
                    case 0:
                        delay = 0.4;
                        break;
                    case 1:
                        delay = 0.2;
                        break;
                    case 2:
                        delay = 0.1;
                        break;
                    case 3:
                        delay = 0.05;
                        break;
                }

                using (var stream = new MemoryStream())
                {
                    using (var encoder = new BumpKit.GifEncoder(stream))
                    {
                        for (int i = 0; i < imageArray.Length; i++)
                        {
                            var image = (imageArray[i] as Bitmap);
                            encoder.AddFrame(image, 0, 0, TimeSpan.FromSeconds(delay));
                        }

                        stream.Position = 0;
                        string targetPath = Path.Combine(_config.DirectoryPath, "전투조형.gif");
                        using (var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            stream.WriteTo(fileStream);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("오류 발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private Bitmap GetPmapObjFrame(int frame, Color color)
        {
            try
            {
                var bg = new Bitmap(PmapObj.Size.Width, PmapObj.Size.Height);

                int deltaX = 50;
                int deltaX2 = 10;
                int deltaY = 120;

                using (var g = Graphics.FromImage(bg))
                {
                    g.FillRectangle(new SolidBrush(color), new RectangleF(0, 0, PmapObj.Size.Width, PmapObj.Size.Height));

                    int x = 0;
                    int y = 20;

                    //
                    g.DrawString("보통", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(0), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(0), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("걷기", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(PmapMoveIndexes[frame % PmapMoveIndexes.Length]), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(PmapMoveIndexes[frame % PmapMoveIndexes.Length]), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("앉기", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(3), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(3), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("검홍", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(4), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(4), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("거수", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(5), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(5), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("곡", Font, Brushes.Black, x + 50, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(6), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(6), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;


                    //
                    x = 0;
                    y += deltaY;
                    g.DrawString("신수", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(7), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(7), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("작읍", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(8), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(8), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("반좌검홍", Font, Brushes.Black, x + 20, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(9), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(9), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("반좌거수", Font, Brushes.Black, x + 20, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(10), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(10), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("반좌곡", Font, Brushes.Black, x + 30, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(11), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(11), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("도하", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(12), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(12), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;


                    //
                    x = 0;
                    y += deltaY;
                    g.DrawString("단슬궤지", Font, Brushes.Black, x + 20, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(13), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(13), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("포박", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(14), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(14), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("휘검양기", Font, Brushes.Black, x + 20, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(15), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(15), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("칼부림침", Font, Brushes.Black, x + 20, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(16), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(16), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("함정", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(17), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(17), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                    g.DrawString("기신", Font, Brushes.Black, x + 40, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(18), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(18), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;


                    //
                    x = 0;
                    y += deltaY;
                    g.DrawString("단수거기", Font, Brushes.Black, x + 20, y - 20);
                    g.DrawImage(_frontLoader.GetFrameImage(19), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    g.DrawImage(_backLoader.GetFrameImage(19), new Rectangle(x, y, 48, 64));
                    x += deltaX;
                    x += deltaX2;

                }
                return bg;
            }
            catch
            {
                return null;
            }
        }

        private void SavePmapButton_Click(object sender, EventArgs e)
        {
            try
            {
                var imageArray = new Image[] {
                GetPmapObjFrame(0, Color.White),
                GetPmapObjFrame(1, Color.White),
                GetPmapObjFrame(2, Color.White),
                GetPmapObjFrame(3, Color.White),
            };

                double delay = 0;

                switch (SpeedSelectBox.SelectedIndex)
                {
                    case 0:
                        delay = 0.4;
                        break;
                    case 1:
                        delay = 0.2;
                        break;
                    case 2:
                        delay = 0.1;
                        break;
                    case 3:
                        delay = 0.05;
                        break;
                }

                using (var stream = new MemoryStream())
                {
                    using (var encoder = new BumpKit.GifEncoder(stream))
                    {
                        for (int i = 0; i < imageArray.Length; i++)
                        {
                            var image = (imageArray[i] as Bitmap);
                            encoder.AddFrame(image, 0, 0, TimeSpan.FromSeconds(delay));
                        }

                        stream.Position = 0;
                        string targetPath = Path.Combine(_config.DirectoryPath, "평상조형.gif");
                        using (var fileStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            stream.WriteTo(fileStream);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("오류 발생", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Info infoPopup = new Info();
            infoPopup.ShowDialog();
        }

        private void BgSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.DefaultBgIndex = BgSelector.SelectedIndex;
            ConfigLoader.Save(_config);

            _bgLoader = new BgLoader(_config.BgFileNames[BgSelector.SelectedIndex]);
            _bgLoader.Load();
        }

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog
            {
                SelectedPath = _config.DirectoryPath,
                Description = "경로를 설정해주세요!"
            };
            if (DialogResult.OK != fbd.ShowDialog() || string.IsNullOrEmpty(fbd.SelectedPath) || !Directory.Exists(fbd.SelectedPath))
            {
                return;
            }

            _config.DirectoryPath = fbd.SelectedPath;
            panel1.Visible = true;
            ConfigLoader.Save(_config);
            LoadDatas();
        }
    }
}
