namespace MoveCircle
{
    public partial class FormBallGame : Form
    {
        // �N���X���ʂ̕ϐ�
        private Bitmap? canvas;             // ��ʉ��̕`��̈�
        private string correctText = "��";   // �����̕����F1����
        private string mistakeText = "��";   // �ԈႢ�̕����F�{�[���̌�������
        //private Ball balls;                 // �{�[�����Ǘ�
        private Ball[] balls;               // �z��Ƃ��ĕ����̃{�[�����Ǘ�
        private string[] kanjis;            // �{�[���ɕ`�������̔z��
        private Brush[] ballColor = new[]
        {
            Brushes.LightPink,  // �����s���N
            Brushes.LightBlue,  // ������
            Brushes.LightGray,  // �����D�F
            Brushes.LightCoral, // �����T���S�F
            Brushes.LightGreen  // ������
        };
        private string fontName;            // �\�����銿���̃t�H���g��
        private double nowTime = 0.0;       // �o�ߎ���
        private int ballCount = 5;      // �{�[���̐�
        private int randomResult = 0;   // �����̔ԍ��F0�`�{�[���̐��̂����ꂩ

        public FormBallGame()
        {
            InitializeComponent();
        }

        private void FormBallGame_Load(object sender, EventArgs e)
        {
            DrawCircleSelectPictureBox();   // ���PictureBox�ɉ~��`��
            DrawMainPictureBox(Brushes.Gray, correctText);  // ����PictureBox�ɉ~��`��
            textHunt.Text = correctText;    // �����̕�����ݒ�
            fontName = textHunt.Font.Name;  // textHunt�ɐݒ肵���t�H���g�Ɠ����t�H���g�ɂ���

            // �{�[���N���X�̃C���X�^���X�쐬
            //balls = new Ball(mainPictureBox, canvas, Brushes.LightBlue, correctText, fontName);
            balls = new Ball[ballCount];

            // �����̐ݒ�
            kanjis = new string[ballCount];
            for (int i = 0; i < ballCount; i++)
            {
                kanjis[i] = mistakeText;    // �ԈႢ�̕������Z�b�g
            }
            randomResult = new Random().Next(ballCount);    // �{�[���̐����̗������擾
            kanjis[randomResult] = correctText;             // �����_���Ȉʒu�ɐ����̕������Z�b�g
            
            // ballCount��Ball�C���X�^���X�𐶐��A�w�i�F��ballColor, �\�����銿����kanjis�ɗp��
            for (int i = 0; i < ballCount; i++ )
            {
                balls[i] = new Ball(mainPictureBox, canvas, ballColor[i], kanjis[i], fontName);
            }

            // �ʒu 100, 100 �Ƀ{�[����u��
            //balls.PutCircle(100, 100);

            // �����_���Ȉʒu��ballCount�̃{�[����u��
            for (int i = 0;i < ballCount; i++ )
            {
                balls[i].PutCircle(new Random().Next(mainPictureBox.Width),
                    new Random().Next(mainPictureBox.Height));
            }

            // �^�C�}�[���X�^�[�g������
            nowTime = 0.0;
            timer1.Start();
        }

        // �ăX�^�[�g�{�^���������ꂽ�Ƃ��A�Ă΂��C�x���g�n���h���[
        private void restartButton_Click(object sender, EventArgs e)
        {
            // �������e��FormBallGame_Load�Ɠ����ł��邽�߂��̂܂܌Ă�
            canvas = null;  // ��ʉ��̕`��̈��������
            FormBallGame_Load(sender, e);
        }

        // ��̃s�N�`���[�{�b�N�X�������ꂽ�Ƃ��A�Ă΂��C�x���g�n���h���[
        private void selectPictureBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        // ���̃s�N�`���[�{�b�N�X�������ꂽ�Ƃ��A�Ă΂��C�x���g�n���h���[


        // �^�C�}�[�������Ă���Ƃ��A�Ă΂��C�x���g�n���h���[
        private void timer1_Tick(object sender, EventArgs e)
        {
            //balls.Move();
            // ballCount�����[�v����Move()�����s
            for (int i = 0; i < ballCount; i++)
            {
                balls[i].Move();
            }
            
            nowTime += 0.02;
            textTimer.Text = nowTime.ToString("0.00");
        }

        // ���PictureBox�R���g���[���ɉ~��`��
        private void DrawCircleSelectPictureBox()
        {
            var height = selectPictureBox.Height;   // ������selectPictureBoxc����擾
            var width = selectPictureBox.Width;     // ����selectPictureBox����擾
            var selectCanvas = new Bitmap(width, height);   // ���~�����ŃL�����o�X�쐬
            using var g = Graphics.FromImage(selectCanvas); // �L�����o�X�ɊG��`������
            //g.FillEllipse(Brushes.LightBlue, 0, 0, height, height); // �����F�ŉ~��`��
            for (int i = 0; i < ballCount; i++)
            {
                g.FillEllipse(ballColor[i], i * height, 0, height, height);
            }
            
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
