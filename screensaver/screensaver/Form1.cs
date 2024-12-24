using System.Drawing.Text;
using Timer = System.Windows.Forms.Timer;

namespace screensaver
{
    public partial class Form1 : Form
    {
        public List<snowflake> snowflakes;
        public Timer timer;
        public Image snowflakeImage;
        public Image backgroundImage;

        public Bitmap bitmap;
        public Graphics image;


        public Form1()
        {
            InitializeComponent();
            snowflakes = new List<snowflake>();
            Load += Form1_Load;
            Paint += Form_Paint;
            timer = new Timer();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            image = Graphics.FromImage(bitmap);
        }

        private void Form_Paint(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("деревня.jpg");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            snowflakeImage = Image.FromFile("снежинка.png");
            WindowState = FormWindowState.Maximized;
            pictureBox1.Size = Size;
            //pictureBox1.Size = ClientSize;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //FormBorderStyle = FormBorderStyle.None;
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                int x = random.Next(ClientSize.Width);
                int y = random.Next(-ClientSize.Height / 4, ClientSize.Height);
                int size = random.Next(50, 75);
                int speedX = random.Next(1, 8);
                int speedY = random.Next(1, 8);
                snowflakes.Add(new snowflake(x, y, size, speedX, speedY));
            }
            KeyPreview = true;
            KeyDown += OnKeyDown;

            timer.Interval = 100;
            timer.Tick += MoveSnowFlakes;
            timer.Start();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using Graphics g = pictureBox1.CreateGraphics();

            foreach (var snowflake in snowflakes)
            {
                g.DrawImage(snowflakeImage, snowflake.X, snowflake.Y, snowflake.Size, snowflake.Size);
            }
        }

        private void MoveSnowFlakes(object sender, EventArgs e)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Y += snowflake.SpeedY;
                snowflake.X += snowflake.SpeedX;

                if (snowflake.X > Width)
                    snowflake.X -= Width;
                if (snowflake.Y > Height)
                    snowflake.Y -= Height;
            }
            Invalidate();
        }
    }
}
