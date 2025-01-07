namespace MoveCircle
{
    public partial class FormBallGame : Form
    {
        // クラス共通の変数
        private Bitmap? canvas;             // 画面下の描画領域
        private string correctText = "萩";   // 正解の文字：1つだけ
        
        public FormBallGame()
        {
            InitializeComponent();
        }

        private void FormBallGame_Load(object sender, EventArgs e)
        {
            DrawCircleSelectPictureBox();
            DrawMainPictureBox(Brushes.Gray, correctText);  // 下のPictureBoxに描画する
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
            var height = selectPictureBox.Height;   // 高さをselectPictureBoxcから取得
            var width = selectPictureBox.Width;     // 幅をselectPictureBoxから取得
            var selectCanvas = new Bitmap(width, height);   // 幅×高さでキャンバス作成
            using var g = Graphics.FromImage(selectCanvas); // キャンバスに絵を描く準備
            g.FillEllipse(Brushes.LightBlue, 0, 0, height, height); // 薄い青色で円を描く
            selectPictureBox.Image = selectCanvas;  // キャンバスに描いた絵をImageに設定
        }   // using指定がされた変数gはこの時点で破棄する処理が内部的に呼ばれる

        private void DrawMainPictureBox(Brush color, string text)
        {
            // 描画先とするImageオブジェクトをmainPictureBoxの幅×高さの大きさで作成
            canvas ??= new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            using var g = Graphics.FromImage(canvas);   // キャンバスに絵を描く準備
            // 背景に引数で指定した文字列を描画
            g.DrawString(text,                      // 描画する文字列
                new Font(textHunt.Font.FontFamily,  // フォント名（textHuntと同じ）
                    mainPictureBox.Height / 2),     // フォントサイズ（高さの半分）
                color,                              // 描画する色
                mainPictureBox.Width / 8,           // x座標（横位置）（0～横幅の1/8で調整）
                -mainPictureBox.Height / 8          // y座標（縦位置）（0～縦幅の1/8で調整）
                );
            mainPictureBox.Image = canvas;          // キャンバスに描いた絵をImageに設定
        }   // using指定がされた変数gはこの時点で破棄する処理が内部的に呼ばれる
    }
}
