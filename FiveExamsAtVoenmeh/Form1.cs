namespace FiveExamsAtVoenmeh
{
    using System.Runtime.InteropServices;
    using System.Diagnostics; 

    public partial class Form1 : Form
    {
// работа с длл
        public const string HID_wapi_DLL = @"..\..\..\..\x64\Debug\HID_wapi.dll";

        [DllImport(HID_wapi_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern bool OpenHID();

        [DllImport(HID_wapi_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int LED_ON();

        [DllImport(HID_wapi_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern byte Read(ref PinSlider left, ref PinSlider right);

        [DllImport(HID_wapi_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int Send(IntPtr data);

        [DllImport(HID_wapi_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int LED_OFF();

        [DllImport(HID_wapi_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern int LightPixel(byte x, byte y, byte color);

        [DllImport(HID_wapi_DLL, CallingConvention = CallingConvention.Cdecl)]
        private static extern void ClearScreen();

        [StructLayout(LayoutKind.Sequential)]
        public struct PinSlider
        {
            [MarshalAs(UnmanagedType.U1)] public bool button1;
            [MarshalAs(UnmanagedType.U1)] public bool button2;
            [MarshalAs(UnmanagedType.U1)] public bool button3;
            [MarshalAs(UnmanagedType.U1)] public bool button4;
            [MarshalAs(UnmanagedType.U4)] public uint slider;
        }

        PinSlider pinSliderLeft = new();
        PinSlider pinSliderRight = new();
        
// работа с длл
// битмапы
        private const string leftUpPath = @"..\..\..\images\leftUp.png";
        private const string leftDownPath = @"..\..\..\images\leftDown.png";
        private const string rightUpPath = @"..\..\..\images\rightUp.png";
        private const string rightDownPath = @"..\..\..\images\rightDown.png";

        Bitmap leftUpMap = new(leftUpPath);
        Bitmap leftDownMap = new(leftDownPath);
        Bitmap rightUpMap = new(rightUpPath);
        Bitmap rightdownMap = new(rightDownPath);

        // 64 / 8 = 8 байт
        byte[] leftUp = new byte[128 * 8];
        byte[] leftDown = new byte[128 * 8];
        byte[] rightUp = new byte[128 * 8];
        byte[] rightdown = new byte[128 * 8];

        private void BitmapToBuffer()
        {
            // leftUp
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 128; x++)
                    for (int i = 0; i < 8; i++)
                    {
                        if (leftUpMap.GetPixel(x, y * 8 + i) == Color.FromArgb(255, 0, 0, 0))
                            leftUp[(y * 128) + x] |= (byte)(1 << i);
                    }
            // leftDown
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 128; x++)
                    for (int i = 0; i < 8; i++)
                    {
                        if (leftDownMap.GetPixel(x, y * 8 + i) == Color.FromArgb(255, 0, 0, 0))
                            leftDown[(y * 128) + x] |= (byte)(1 << i);
                    }
            // rightUp
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 128; x++)
                    for (int i = 0; i < 8; i++)
                    {
                        if (rightUpMap.GetPixel(x, y * 8 + i) == Color.FromArgb(255, 0, 0, 0))
                            rightUp[(y * 128) + x] |= (byte)(1 << i);
                    }
            // rightdown
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 128; x++)
                    for (int i = 0; i < 8; i++)
                    {
                        if (rightdownMap.GetPixel(x, y * 8 + i) == Color.FromArgb(255, 0, 0, 0))
                            rightdown[(y * 128) + x] |= (byte)(1 << i);
                    }
        }

        private void BufferToFile()
        {
            /* StreamWriter file = new("ex.txt");
             for (int i = 0; i < bitmap.Height; i++)
             {
                 for (int j = 0; j < 16; j++)
                 {
                     string result = Convert.ToString(buf[16 * i + j], 2);
                     if (result.Length < 8)
                     {
                         string str = "";
                         for (int g = result.Length; g < 8; g++)
                         {
                             str += "0";
                         }
                         result = str + result;
                     }
                     file.Write(result);
                     file.Write(" ");
                 }
                 file.Write("\n");
             }
             file.Close();*/
        }
// битмапы
// учитель
        Random random = new Random();

        int currentX = 1, currentY = 0;
        int maxX = 3, maxY = 5;
        int teacherStartWidth = 60, teacherStartHeight = 100;
        int teacherWIdthDelta = 15, teacherHIdthDelta = 25;
        Point teacherStartPosition = new(372, 22);

        Point[,] teacherPositions =
        {
            {new Point(145,33), new Point(321,33), new Point(446,33), new Point(605,33)},
            {new Point(151,39), new Point(297,40), new Point(445,40), new Point(588,37)},
            {new Point(92,30), new Point(258,29), new Point(446,31), new Point(628,26)},
            {new Point(12,37), new Point(215,38), new Point(487,38), new Point(683,33)},
            {new Point(0,0), new Point(165,98), new Point(524,101), new Point(1,0)},
            {new Point(0,1), new Point(), new Point(), new Point(1,1)}
        };

        private void teacherTimer_Tick(object sender, EventArgs e)
        {
            // дивгаемся по иксу
            if (random.Next(100) < 50)
            {
                // вправо
                if (random.Next(100) < 50 && currentX < maxX)
                    currentX++;
                // влево
                else if (currentX > 0)
                    currentX--;
            }
            // двигаемся по игреку
            else
            {
                // вниз
                if (random.Next(100) < 50 && currentY < maxY)
                    currentY++;
                // вверх
                else if (currentY > 0)
                    currentY--;
            }

            // если в слепой зоне
            byte[] pictureToPlata = null;
            bool outOfScreen = false;
            // лево верх 
            if (currentX == 0 && currentY == maxY - 1)
            {
                pictureToPlata = leftUp;
                outOfScreen = true;
            }
            // лево низ
            else if (currentX == 0 && currentY == maxY)
            {
                pictureToPlata = leftDown;
                outOfScreen = true;
            }
            // право верх
            else if (currentX == maxX && currentY == maxY - 1)
            {
                pictureToPlata = rightUp;
                outOfScreen = true;
            }
            // право низ
            else if (currentX == maxX && currentY == maxY)
            {
                pictureToPlata = rightdown;
                outOfScreen = true;
            }
            else
                outOfScreen = false;

            if (outOfScreen)
            {
                teacher.Visible = false;
                unsafe
                {
                    int size = Marshal.SizeOf(pictureToPlata[0]) * pictureToPlata.Length;
                    IntPtr ptr = Marshal.AllocHGlobal(size);
                    Marshal.Copy(pictureToPlata, 0, ptr, pictureToPlata.Length);
                    Send(ptr);
                    Marshal.FreeHGlobal(ptr);
                }
            }
            else
            {
                //ClearScreen();
                teacher.Visible = true;
                teacher.Location = teacherPositions[currentY, currentX];
                teacher.Size = new Size(teacherStartWidth + teacherWIdthDelta * currentY,
                                        teacherStartHeight + teacherHIdthDelta * currentY);
            }

            teacher.Update();
        }
// учитель
// игрок
        Stopwatch sw = new();

        PictureBox[] papers = new PictureBox[3];

        private void button1_Click(object sender, EventArgs e)
        {
            unsafe
            {
                int size = Marshal.SizeOf(leftUp[0]) * leftUp.Length;

                IntPtr pnt = Marshal.AllocHGlobal(size);

                Marshal.Copy(leftUp, 0, pnt, leftUp.Length);

                Send(pnt);

                Marshal.FreeHGlobal(pnt);
            }
            
        }

        private const string exemTime = "До окончания экзамена осталось: ";
        int minuteUntilEnd = 4;

        private void examTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = exemTime + minuteUntilEnd + " минут";
            minuteUntilEnd--;
            // если время вышло, игрок проиграл
            if (minuteUntilEnd == -1)
                this.Close();
        }

        int currentPaper = 0;
        long n = 1;

        private void playerTimer_Tick(object sender, EventArgs e)
        {
            byte result = Read(ref pinSliderLeft, ref pinSliderRight);
            if (result == 1)
                throw new Exception("cant get from 1 palta");
            if (result == 2)
                throw new Exception("cant get from 2 plata");

            // бросок бумажки влево
            if (pinSliderLeft.button1)
            {
                // если бумажки еще есть на столе
                if (currentPaper < papers.Length)
                {
                    papers[currentPaper].Visible = false;
                    currentPaper++;
                    // учитель реагирует на бросок бумажки
                }
            }

            // бросок бумажки вправо
            if (pinSliderRight.button1)
            {
                // если бумажки еще есть на столе
                if (currentPaper < papers.Length)
                {
                    papers[currentPaper].Visible = false;
                    currentPaper++;
                    // учитель реагирует на бросок бумажки
                }
            }

            // поднять \ опустить руку слева
            if (pinSliderLeft.slider < 2000)
            {
                leftHandBox.Visible = false;
            }
            else
            {
                leftHandBox.Visible = true;
            }

            // поднять \ опустить руку справа
            if (pinSliderRight.slider < 2000)
            {
                rightHandBox.Visible = false;
            }
            else
            {
                rightHandBox.Visible = true;
            }

            // если одна рука на парте, а вторая под ней, то спысываем
            if (pinSliderLeft.slider < 2000 && pinSliderRight.slider > 2000 ||
                pinSliderLeft.slider > 2000 && pinSliderRight.slider < 2000)

                sw.Start();
            else
                sw.Stop();

            if (sw.IsRunning)
                if (sw.ElapsedMilliseconds / 10000 == n) 
                {
                    n++;
                    progressBar1.PerformStep();
                }
        }
// игрок


        public Form1()
        {
            InitializeComponent();

            teacher.Location = teacherStartPosition;
            teacher.Update();

            // отправляем лейбл и прогресбар на задний фон
            label1.SendToBack();
            progressBar1.SendToBack();

            // инициализируем массив бумажек
            papers[0] = paper1;
            papers[1] = paper2;
            papers[2] = paper3;

            // загружаем битмапы для плат в буферы
            BitmapToBuffer();

            // выходим на связь с платами
            if (!OpenHID())
                throw new Exception("can't open HID device");

            playerTimer.Enabled = true;
            teacherTimer.Enabled = true;
            pinSliderRight.slider = 4000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}