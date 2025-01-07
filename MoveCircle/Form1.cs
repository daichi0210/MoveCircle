namespace MoveCircle
{
    public partial class FormBallGame : Form
    {
        // �N���X���ʂ̕ϐ�
        private Bitmap? canvas;             // ��ʉ��̕`��̈�
        private string correctText = "��";   // �����̕����F1����
        
        public FormBallGame()
        {
            InitializeComponent();
        }

        private void FormBallGame_Load(object sender, EventArgs e)
        {
            DrawCircleSelectPictureBox();
            DrawMainPictureBox(Brushes.Gray, correctText);  // ����PictureBox�ɕ`�悷��
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

        private void DrawCircleSelectPictureBox()
        {
            var height = selectPictureBox.Height;   // ������selectPictureBoxc����擾
            var width = selectPictureBox.Width;     // ����selectPictureBox����擾
            var selectCanvas = new Bitmap(width, height);   // ���~�����ŃL�����o�X�쐬
            using var g = Graphics.FromImage(selectCanvas); // �L�����o�X�ɊG��`������
            g.FillEllipse(Brushes.LightBlue, 0, 0, height, height); // �����F�ŉ~��`��
            selectPictureBox.Image = selectCanvas;  // �L�����o�X�ɕ`�����G��Image�ɐݒ�
        }   // using�w�肪���ꂽ�ϐ�g�͂��̎��_�Ŕj�����鏈���������I�ɌĂ΂��

        private void DrawMainPictureBox(Brush color, string text)
        {
            // �`���Ƃ���Image�I�u�W�F�N�g��mainPictureBox�̕��~�����̑傫���ō쐬
            canvas ??= new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            using var g = Graphics.FromImage(canvas);   // �L�����o�X�ɊG��`������
            // �w�i�Ɉ����Ŏw�肵���������`��
            g.DrawString(text,                      // �`�悷�镶����
                new Font(textHunt.Font.FontFamily,  // �t�H���g���itextHunt�Ɠ����j
                    mainPictureBox.Height / 2),     // �t�H���g�T�C�Y�i�����̔����j
                color,                              // �`�悷��F
                mainPictureBox.Width / 8,           // x���W�i���ʒu�j�i0�`������1/8�Œ����j
                -mainPictureBox.Height / 8          // y���W�i�c�ʒu�j�i0�`�c����1/8�Œ����j
                );
            mainPictureBox.Image = canvas;          // �L�����o�X�ɕ`�����G��Image�ɐݒ�
        }   // using�w�肪���ꂽ�ϐ�g�͂��̎��_�Ŕj�����鏈���������I�ɌĂ΂��
    }
}
