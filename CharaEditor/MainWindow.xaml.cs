using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharaEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateSaveBitmap(Canvas canvas, string src)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int) canvas.Width, (int) canvas.Height, 96d, 96d,
                PixelFormats.Pbgra32);
            canvas.Measure(new Size((int)canvas.Width, (int)canvas.Height));
            canvas.Arrange(new Rect(new Size((int)canvas.Width, (int)canvas.Height)));
            
            bmp.Render(canvas);

            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));

            using (FileStream file = File.Create(src))
            {
                encoder.Save(file);
            }
        }
        
        private void SaveUnifiedImage(object sender, RoutedEventArgs e)
        {
            // throw new System.NotImplementedException();
            CreateSaveBitmap(canvas1, @"C:\Users\Enin\OneDrive\test\out.png");
            // string output = @"C:\Users\Enin\OneDrive\test\out.png";
            // if (File.Exists(output))
            // {
            //     output = @"C:\Users\Enin\OneDrive\test\out2.png";
            // }
            // CreateSaveBitmap(canvas1, output);
        }
    }
}