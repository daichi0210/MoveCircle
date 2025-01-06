namespace MoveCircle
{
    public partial class FormBallGame : Form
    {
        public FormBallGame()
        {
            InitializeComponent();
        }

        private void DrawCircleSelectPictureBox()
        {
            var height = selectPictureBox.Height;
            var width = selectPictureBox.Width;
            var selectCanvas = new Bitmap(width, height);
            using var g = Graphics.FromImage(selectCanvas);
            g.FillEllipse(Brushes.LightBlue, 0, 0, height, height);
            selectPictureBox.Image = selectCanvas;
        }


        private void FormBallGame_Load(object sender, EventArgs e)
        {
            DrawCircleSelectPictureBox();
        }

        private void selectPictureBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void restartButton_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
