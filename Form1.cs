namespace SimplePaint
{

    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Printing;
    using System.Windows.Forms;


    public partial class Form1 : Form
    {

        enum ToolType{ Line, Rectangle, Circle }  // 사용할 도형타입
        private Bitmap canvasBitmap;          // 실제 그림이 저장되는 비트맵
        private Graphics canvasGraphics;      // 비트맵 위에 그리기 위한 객체
        private bool isDrawing = false;       // 현재 드래그 중인지 여부
        private Point startPoint;             // 드래그 시작점
        private Point endPoint;               // 드래그 끝점
        private ToolType currentTool= ToolType.Line;  // 현재 선택된 도형
        private Color currentColor = Color.Black;      // 현재 색상
        private int currentLineWidth = 2;              // 현재 선두께
        
        public Form1()
        {
            InitializeComponent();
            // 캔버스초기화
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            canvasGraphics = Graphics.FromImage(canvasBitmap);
            canvasGraphics.Clear(Color.White);   // 캔버스를 흰색으로 초기화

            // PictureBox는 커스텀 Paint에서 이미지를 그린다.
            picCanvas.Image = null;

            // 초기 줌값을 트랙바 값에 맞춘다
            zoomFactor = trbZoom != null ? trbZoom.Value / 100f : 1.0f;
            picCanvas.Size = new Size((int)(canvasBitmap.Width * zoomFactor), (int)(canvasBitmap.Height * zoomFactor));

            // 마우스이벤트연결
            picCanvas.MouseDown += PicCanvas_MouseDown;
            picCanvas.MouseMove += PicCanvas_MouseMove;
            picCanvas.MouseUp += PicCanvas_MouseUp;

            // picCanvas가 다시 그려질 때 PicCanvas_Paint 함수를 실행하도록 연결
            picCanvas.Paint += PicCanvas_Paint;

            // 도형선택 버튼 이벤트 연결
            btnLine.Click += btnLine_Click;
            btnRectangle.Click += btnRectangle_Click;
            btnCircle.Click += btnCircle_Click;

            // 색상 콤보박스 이벤트 연결
            cmbColor.SelectedIndexChanged += cmbColor_SelectedIndexChanged;
            cmbColor.SelectedIndex = 0;  // 기본값: Black
            
            // 선두께 트랙바 이벤트 연결
            trbLineWidth.Minimum = 1;    // 최소값
            trbLineWidth.Maximum = 10;   // 최대값
            trbLineWidth.Value = 5;
            trbLineWidth.ValueChanged += trbLineWidth_ValueChanged;
            btnSaveFile.Click += btnSaveFile_Click;
            btnOpenFile.Click += btnOpenFile_Click;

            // 줌 컨트롤 이벤트
            if (trbZoom != null)
            {
                trbZoom.ValueChanged += trbZoom_ValueChanged;
            }

        }

        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;             // 드래그 시작
            // 화면 좌표 -> 이미지 좌표로 변환
            startPoint = AdjustPoint(e.Location);      // 시작점 저장
        }

        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;       // 그림 그리기와 상관없는 마우스 움직임은 무시
            endPoint = AdjustPoint(e.Location);        // 현재 위치 갱신 (이미지 좌표)
                                          // picCanvas를 다시 그려라(Paint 이벤트를 발생시킨다)
            picCanvas.Invalidate();       // 화면 다시 그리기(미리보기)        
        }

        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;     // 그림 그리기와 상관없는 마우스 움직임은 무시
            
            isDrawing = false;          // 드래그 종료
            endPoint = AdjustPoint(e.Location);
            // 실제비트맵에도형그리기(확정)
            using (Pen pen = new Pen(currentColor, currentLineWidth))
            {
                DrawShape(canvasGraphics, pen, startPoint, endPoint);
            }
            picCanvas.Invalidate();     // 다시 그려서 결과 반영, Paint 이벤트 발생
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            // 이미지 전체를 현재 컨트롤 크기에 맞춰서 그린다 (줌 적용)
            if (canvasBitmap != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(canvasBitmap, 0, 0, picCanvas.Width, picCanvas.Height);
            }

            if (!isDrawing) return;

            // 미리보기 그리기: 이미지 좌표를 화면(컨트롤) 좌표로 변환
            Point sp = new Point((int)(startPoint.X * zoomFactor), (int)(startPoint.Y * zoomFactor));
            Point ep = new Point((int)(endPoint.X * zoomFactor), (int)(endPoint.Y * zoomFactor));

            using (Pen previewPen = new Pen(currentColor, Math.Max(1f, currentLineWidth * zoomFactor)))
            {
                previewPen.DashStyle = DashStyle.Dash;
                DrawShape(e.Graphics, previewPen, sp, ep);
            }
        }

        private void DrawShape(Graphics g, Pen pen, Point p1, Point p2)
        {
            Rectangle rect = GetRectangle(p1, p2);
            switch (currentTool)
            {
                case ToolType.Line:
                    g.DrawLine(pen, p1, p2);
                    break;
                case ToolType.Rectangle:
                    g.DrawRectangle(pen, rect);
                    break;
                case ToolType.Circle:
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
            Math.Min(p1.X, p2.X),
            Math.Min(p1.Y, p2.Y),
            Math.Abs(p1.X - p2.X),  
            Math.Abs(p1.Y - p2.Y)
            );
        }

        private void btnLine_Click(object sender, EventArgs e)
        { 
            currentTool = ToolType.Line;
        }
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Rectangle;
        }
        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = ToolType.Circle;
        }

        private void cmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbColor.SelectedIndex)
            {
                case 0: // Black 검정
                    currentColor = Color.Black;
                    break;
                case 1: // Red 빨강
                    currentColor = Color.Red;
                    break;
                case 2: // Blue 파랑
                    currentColor = Color.Blue;
                    break;
                case 3: // Green 녹색
                    currentColor = Color.Green;
                    break;
                default:
                    currentColor = Color.Black;
                    break;
            }
        }

        private void trbLineWidth_ValueChanged(object sender, EventArgs e)
        {
            currentLineWidth = trbLineWidth.Value;
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                sfd.Title = "이미지 저장";
                sfd.FileName = "drawing";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Png;

                    switch (sfd.FilterIndex)
                    {
                        case 1:
                            format = ImageFormat.Png;
                            break;
                        case 2:
                            format = ImageFormat.Jpeg;
                            break;
                        case 3:
                            format = ImageFormat.Bmp;
                            break;
                    }

                    canvasBitmap.Save(sfd.FileName, format);
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.png;*.jpg;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap loadedImage = new Bitmap(ofd.FileName);

                    // 기존 비트맵 정리
                    canvasGraphics.Dispose();
                    canvasBitmap.Dispose();

                    canvasBitmap = new Bitmap(loadedImage);
                    canvasGraphics = Graphics.FromImage(canvasBitmap);

                    // PictureBox의 이미지는 Paint에서 직접 그리므로 null로 둔다
                    picCanvas.Image = null;

                    // 캔버스 크기를 이미지 크기와 현재 줌에 맞춘다
                    ResizeCanvasToImage();
                }
            }
        }

        private void ResizeCanvasToImage()
        {
            if (canvasBitmap == null) return;
            picCanvas.Size = new Size((int)(canvasBitmap.Width * zoomFactor), (int)(canvasBitmap.Height * zoomFactor));
        }

        private float zoomFactor = 1.0f;

        private Point AdjustPoint(Point p)
        {
            return new Point(
                (int)(p.X / zoomFactor),
                (int)(p.Y / zoomFactor)
            );
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            zoomFactor *= 1.2f;
            if (canvasBitmap != null)
                picCanvas.Size = new Size((int)(canvasBitmap.Width * zoomFactor), (int)(canvasBitmap.Height * zoomFactor));
            picCanvas.Invalidate();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            zoomFactor /= 1.2f;
            if (canvasBitmap != null)
                picCanvas.Size = new Size((int)(canvasBitmap.Width * zoomFactor), (int)(canvasBitmap.Height * zoomFactor));
            picCanvas.Invalidate();
        }

        private void trbZoom_ValueChanged(object? sender, EventArgs e)
        {
            if (trbZoom == null) return;
            zoomFactor = trbZoom.Value / 100f;
            if (canvasBitmap != null)
                picCanvas.Size = new Size((int)(canvasBitmap.Width * zoomFactor), (int)(canvasBitmap.Height * zoomFactor));
            picCanvas.Invalidate();
        }
    }
}
