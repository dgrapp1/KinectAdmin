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
using System.Windows.Forms;
using System.Collections.ObjectModel;


namespace Kinect_PT_Administrator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<int> list5 = new ObservableCollection<int>();
        
        
        //brushes
        private readonly Brush pointBrush = Brushes.Orange;
        private readonly Brush lineBrush = Brushes.White;



        public ObservableCollection<string> list = new ObservableCollection<string>();


        public class BubbleSize
        {
            public int BubbleRadius { get; set; }
            public int BubbleID { get; set; }
        }

        public class JointBrushes
        {
            // create brushes for each joint
            
        }

        public MainWindow()
        {
            InitializeComponent();

            LoadComboBoxes();

            DoInitialization();

            LoadDefaultDirectory();

        }

        private void DoInitialization()
        {
            BubbleCount = 0;
            SetComboBoxes();
            SetTextBoxes();

        }

        private void SetComboBoxes()
        {
            cboSize.SelectedIndex = 3;
            cboJoint.SelectedIndex = 0;
        }

        private void SetTextBoxes()
        {
            // hard coding this for now , need to make this read off a file in the application directory 
            // so that the app can load up with a default path

            


        }

        private void LoadComboBoxes()
        {
            // bubble size
            list5.Add(15);
            list5.Add(20);
            list5.Add(25);
            list5.Add(30);
            list5.Add(35);
            list5.Add(40);
            cboSize.ItemsSource = list5;


            // joints
            list.Add("Left Hand");
            list.Add("Right Hand");
            list.Add("Left Foot");
            list.Add("Right Foot");
            list.Add("Left Ankle");
            list.Add("Right Ankle");
            list.Add("Left Elbow");
            list.Add("Right Elbow");
            list.Add("Head");
            list.Add("Left Hip");
            list.Add("Center Hip");
            list.Add("Right Hip");
            list.Add("Left Knee");
            list.Add("Right Knee");
            list.Add("Left Shoulder");
            list.Add("Center Shoulder");
            list.Add("Right Shoulder");
            list.Add("Spine");
            list.Add("Wrist Left");
            list.Add("Wrist Right");
            cboJoint.ItemsSource = list;
        }


        private Shape MakeSimpleShape(double size, Point center, Brush brush, Brush brushStroke, double strokeThickness)
        {
           // int BubbleThickness = 15;
            TextBlock tb = new TextBlock();
            tb.Text = BubbleCount.ToString();
            tb.Foreground = Brushes.White;
            tb.FontSize = 20;
            if (BubbleCount < 10)
            {
                tb.SetValue(Canvas.LeftProperty, center.X - 5);
                tb.SetValue(Canvas.TopProperty, center.Y - 15);
            }
            else
            {
                tb.SetValue(Canvas.LeftProperty, center.X - 11);
                tb.SetValue(Canvas.TopProperty, center.Y - 15);
            }

            var circle = new Ellipse { Width = size * 2, Height = size * 2, Stroke = brushStroke };

            circle.StrokeThickness = size * 2;
            circle.Fill = brush;
            circle.SetValue(Canvas.LeftProperty, center.X - size);
            circle.SetValue(Canvas.TopProperty, center.Y - size);



            Canvas.Children.Add(circle);
            Canvas.Children.Add(tb);

            return circle;
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = new Point();
            p = e.GetPosition(Canvas);
            BubbleCount = BubbleCount + 1;
            MakeSimpleShape(list5[cboSize.SelectedIndex],p , GetSelectedBrush(), GetSelectedBrush(), 20);
           
            PopulateCoordinates(p);
        }

        private Brush GetSelectedBrush()
        {
            Brush _selectedBrush;





           
            //public Brush LightBlueBrush = Brushes.LightBlue;
            //public Brush RedBrush = Brushes.Red;
            //public readonly Brush OrangeBrush = Brushes.Orange;
            //public readonly Brush BlueBrush = Brushes.Green;
            //public readonly Brush BlueBrush = Brushes.LightGreen;
            //public readonly Brush PurpleBrush = Brushes.Purple;
            //public readonly Brush BrownBrush = Brushes.Brown;
            //public readonly Brush YellowBrush = Brushes.LightGoldenrodYellow;
            //public readonly Brush TanBrush = Brushes.Tan;
            //public readonly Brush GrayBrush = Brushes.DarkGray;
            //public readonly Brush LightGrayBrush = Brushes.LightGray;
            //public readonly Brush PinkBrush = Brushes.Pink;
            //public readonly Brush LightYellow = Brushes.LightYellow;


            if (cboJoint.SelectedIndex == 0)
            {
                _selectedBrush = Brushes.Blue;
                return _selectedBrush;
            }
            if (cboJoint.SelectedIndex == 1)
            {
                _selectedBrush = Brushes.Red;
                return _selectedBrush;
            }
            if (cboJoint.SelectedIndex == 2)
            {
                _selectedBrush = Brushes.Orange;
                return _selectedBrush;
            }
            if (cboJoint.SelectedIndex == 3)
            {
                _selectedBrush = Brushes.Purple;
                return _selectedBrush;
            }
            if (cboJoint.SelectedIndex == 4)
            {
                _selectedBrush = Brushes.Green;
                return _selectedBrush;
            }
            if (cboJoint.SelectedIndex == 5)
            {
                _selectedBrush = Brushes.Yellow;
                return _selectedBrush;
            }
            //if (cboJoint.SelectedIndex == 0)
            //{
            //    _selectedBrush = Brushes.Blue;
            //}       
            //if (cboJoint.SelectedIndex == 0)
            //{
            //    _selectedBrush = Brushes.Blue;
            //}
            //if (cboJoint.SelectedIndex == 0)
            //{
            //    _selectedBrush = Brushes.Blue;
            //}
            //if (cboJoint.SelectedIndex == 0)
            //{
            //    _selectedBrush = Brushes.Blue;
            //}   
            //if (cboJoint.SelectedIndex == 0)
            //{
            //    _selectedBrush = Brushes.Blue;
            //}        




            return null;

        }

        private void PopulateCoordinates(Point p)
        {
            double x = p.X;
            double y = p.Y;

            string _point = "(" + x + " , " + y + ")";
            

            BubbleItem item = new BubbleItem
            {
                ID = BubbleCount.ToString(),
                Size = cboSize.SelectedValue.ToString(),
                Joint = cboJoint.SelectedValue.ToString(),
                Coordinates = _point
            };
            lvwCoords.Items.Add(item);


            
            
            
        



            //lvwCoords.Vie


            
            //if (BubbleCount == 1)
            //{
            //    Coord1.Visibility = Visibility.Visible;
            //    Joint1.Visibility = Visibility.Visible;

            //    Joint1.Text = cboJoint.Text;
            //    Coord1.Text = x + " , " + y;
            //}
            //if (BubbleCount == 2)
            //{
            //    Coord2.Visibility = Visibility.Visible;
            //    Joint2.Visibility = Visibility.Visible;

            //    Joint2.Text = cboJoint.Text;
            //    Coord2.Text = x + " , " + y;
            //}
            //if (BubbleCount == 3)
            //{
            //    Coord3.Visibility = Visibility.Visible;
            //    Joint3.Visibility = Visibility.Visible;

            //    Joint3.Text = cboJoint.Text;
            //    Coord3.Text = x + " , " + y;
            //}
            //if (BubbleCount == 4)
            //{
            //    Coord4.Visibility = Visibility.Visible;
            //    Joint4.Visibility = Visibility.Visible;

            //    Joint4.Text = cboJoint.Text;
            //    Coord4.Text = x + " , " + y;
            //}
            //if (BubbleCount == 5)
            //{
            //    Coord5.Visibility = Visibility.Visible;
            //    Joint5.Visibility = Visibility.Visible;

            //    Joint5.Text = cboJoint.Text;
            //    Coord5.Text = x + " , " + y;
            //}

        }

        private void Canvas_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DrawCanvasGraph();
            
            


        }

        private void DrawCanvasGraph()
        {


            Canvas.Background = System.Windows.Media.Brushes.Black;

            //start drawing white grid on black background

            //y - axis
            Line GraphY = new Line();

            GraphY.StrokeThickness = 2;

            GraphY.Stroke = lineBrush;

            GraphY.X1 = (Canvas.Width / 2);
            GraphY.X2 = (Canvas.Width / 2);

            GraphY.Y1 = (Canvas.Height);
            GraphY.Y2 = (Canvas.Margin.Bottom);
            GraphY.Visibility = System.Windows.Visibility.Visible;

            Canvas.Children.Add(GraphY);


            //x - axis
            Line GraphX = new Line();

            GraphX.StrokeThickness = 2;

            GraphX.Stroke = lineBrush;

            GraphX.X1 = (Canvas.Width);
            GraphX.X2 = (Canvas.Margin.Right);

            GraphX.Y1 = (Canvas.Height / 2);
            GraphX.Y2 = (Canvas.Height / 2);
            GraphX.Visibility = System.Windows.Visibility.Visible;



            Canvas.Children.Add(GraphX);
        }
        public class BubbleItem
        {
            public string ID { get; set; }
            public string Size { get; set; }
            public string Joint { get; set; }
            public string Coordinates { get; set; }
        }

     

        // public variables
        public int BubbleCount { get; set; }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            // need error handling for required fields 
            if (txtName.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Please enter an exercise name.");
                return;
            }
            
            
            
            List<string> Data = new List<string>();

            Data.Add(txtName.Text.ToString());

            
            foreach (BubbleItem item in lvwCoords.Items)
            { 
               Data.Add(item.ID + " ; " + item.Size + " ; " + item.Joint + " ; " + item.Coordinates);
            }

            string[] lines = Data.ToArray();


            System.IO.File.WriteAllLines(_FolderPath + "\\" + txtName.Text +".txt", lines);


            System.Windows.MessageBox.Show(txtName.Text + " has been saved successfully.", "Exercise saved!");
        }

        private void btnBrowse_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // need to check if folder and file exists here



            System.Windows.Forms.FolderBrowserDialog browse = new System.Windows.Forms.FolderBrowserDialog();
            browse.ShowDialog();
            _FolderPath = browse.SelectedPath;
            txtPath.Text = _FolderPath;

            System.IO.File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "DefaultAdminDirectory.txt", _FolderPath);

        }


        public string _FolderPath { get; set; }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lvwCoords.Items.Clear();
            BubbleCount = 0;
            Canvas.Children.Clear();
            txtName.Clear();
            cboJoint.SelectedIndex = 0;
            cboSize.SelectedIndex = 2;
            DrawCanvasGraph();
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadDefaultDirectory()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "DefaultAdminDirectory.txt";

            if (File.Exists(path))
            {
                string text = System.IO.File.ReadAllText(path);

                if (text != "")
                {
                   // cboExercises.Items.Clear();

                    txtPath.Text = text;
                    _FolderPath = text;

                    //DirectoryInfo dir = new DirectoryInfo(text);
                    //FileInfo[] files = dir.GetFiles("*.txt");
                    //foreach (FileInfo file in files)
                    //{
                    //    cboExercises.Items.Add(file.Name.Replace(".txt", ""));
                    //}
                }
            }

        }

      
    }
}
