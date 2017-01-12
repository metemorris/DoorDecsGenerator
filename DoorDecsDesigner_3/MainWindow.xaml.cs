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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;

namespace DoorDecsCreator_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string ImageLocation = "";
        string SaveLocation = "";
        string ResidentList = "";
        int noOfImages;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void ResidentList_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            //Set filter for file extension and default file extension 
            dlg.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ResidentList = filename;
            }
        }


        private void ImageLocation_Click(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(fbd.SelectedPath);
                noOfImages = dir.GetFiles().Length;
                ImageLocation = fbd.SelectedPath;
            }
        }



        private void SaveLocation_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveLocation = fbd.SelectedPath;
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

            //save the names into the name array 
            string[] names = File.ReadAllLines(ResidentList);
            Font drawFont = new Font("Georgia", 70);

            string writeLoc;
            string readLoc;




            if (noOfImages == 1 && noOfImages > 0)
            {
                /*//if there is only 1 image just use the name 
                //folder to add different names https://www.google.com.cy/imgres?imgurl=https%3A%2F%2Fs-media-cache-ak0.pinimg.com%2F736x%2Fc8%2Fc3%2Ffd%2Fc8c3fde8be53dad0a4afddb90b8f413a.jpg&imgrefurl=https%3A%2F%2Fwww.pinterest.com%2Fpin%2F485122191081481030%2F&docid=6LJTRfyyou3kqM&tbnid=QLKUI5dW7Byu2M%3A&w=736&h=736&itg=1&bih=991&biw=942&ved=0ahUKEwiF0djohorNAhWGPBQKHYbvATEQMwg-KBowGg&iact=mrc&uact=8to save images
                //and save it in a location
                FileStream fs = new FileStream(ImageLocation, FileMode.Open, FileAccess.Read);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                fs.Close();



                for (int i = 0; i < names.Length; i++)
                {

                    writeLoc = SaveLocation + i.ToString();
                    //                Console.WriteLine(writeLoc);

                    Bitmap b = new Bitmap(image);
                    Graphics graphics = Graphics.FromImage(b);
                    graphics.DrawString(names[i], drawFont, System.Drawing.Brushes.White, 70, 300);

                    b.Save(writeLoc, image.RawFormat);

                    b.Dispose();
                    writeLoc = SaveLocation;
                }
                image.Dispose();*/
                //less images than residents repeat the images 
                //int modNumber = noOfImages;
                int nextImage = 1;
                int xCoordinate;
                int DefaultX;
                for (int i = 0; i < names.Length; i++)
                {
                    //nextImage = i % modNumber + 1;
                    readLoc = ImageLocation + "\\" + nextImage.ToString() + ".png";
                    writeLoc = SaveLocation + "\\" + i.ToString() + ".png";
                    FileStream fs = new FileStream(readLoc, FileMode.Open, FileAccess.Read);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                    fs.Close();
                    DefaultX = image.Width / 2 - 60;
                    Bitmap b = new Bitmap(image);
                    Graphics graphics = Graphics.FromImage(b);
                    if (names[i].Length < 5)
                    {
                        xCoordinate = DefaultX - ((names[i].Length) * 60);
                    }
                    else if (names[i].Length > 5)
                    {
                        drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 12)));
                        if (names[i].Length == 6)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 8)));
                            xCoordinate = DefaultX - ((names[i].Length) * 50);
                        }

                        else if (names[i].Length == 7)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 10)));
                            xCoordinate = DefaultX - ((names[i].Length) * 40);
                        }
                        else if (names[i].Length == 8)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 8)));
                            xCoordinate = DefaultX - ((names[i].Length) * 38);
                        }
                        else if (names[i].Length == 9)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 8)));
                            xCoordinate = DefaultX - ((names[i].Length) * (48 - names[i].Length));
                        }
                        else if (names[i].Length == 10 || names[i].Length == 11)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 7)));
                            xCoordinate = DefaultX - ((names[i].Length) * (30));
                        }
                        else
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 10)));
                            xCoordinate = DefaultX - ((names[i].Length) * (46 - names[i].Length));
                        }


                    }
                    else
                    {
                        drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 23)));
                        xCoordinate = DefaultX - ((names[i].Length) * 50);
                    }

                    graphics.DrawString(names[i], drawFont, System.Drawing.Brushes.Black, xCoordinate, 670);
                    b.Save(writeLoc, image.RawFormat);

                    b.Dispose();
                    writeLoc = SaveLocation;
                    readLoc = ImageLocation;
                    drawFont = new Font("Georgia", 70);
                }




            }



          //  else(noOfImages < names.Length && noOfImages > 0)
          else
            {
                //less images than residents repeat the images 
                int modNumber = noOfImages;
                int nextImage = 0;
                int xCoordinate;
                int DefaultX;
                for (int i = 0; i < names.Length; i++)
                {
                    nextImage = i % modNumber + 1;
                    readLoc = ImageLocation + "\\" + nextImage.ToString() + ".jpg";
                    writeLoc = SaveLocation + "\\" + i.ToString() + ".jpg";
                    FileStream fs = new FileStream( readLoc, FileMode.Open, FileAccess.Read );
                    System.Drawing.Image image = System.Drawing.Image.FromStream( fs );
                    fs.Close();
                    DefaultX = (image.Width / 2) +80;
                    Bitmap b = new Bitmap( image );
                    Graphics graphics = Graphics.FromImage( b );
                    if ( names[i].Length < 5 )
                    {
                        xCoordinate = DefaultX - ( (names[i].Length) * 60 );
                    }
                    else if ( names[i].Length > 5 )
                    {
                        drawFont = new Font( "Georgia", (150 - ((names[i].Length - 5)*13) )  );
                        if (names[i].Length == 6)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 10)));
                            xCoordinate = DefaultX - ((names[i].Length) * 45);
                        }

                        else if ( names[i].Length == 7)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 10)));
                            xCoordinate = DefaultX - ( (names[i].Length) * 35 );
                        }
                        else if (names[i].Length == 8)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 8)));
                            xCoordinate = DefaultX - ((names[i].Length) * 30);
                        }
                        else if (names[i].Length==9)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 8)));
                            xCoordinate = DefaultX - ((names[i].Length) * (48 - names[i].Length));
                        }
                        else if (names[i].Length == 10)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 6)));
                            xCoordinate = DefaultX - ((names[i].Length) * (25));
                        }
                        else if (names[i].Length == 11)
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 6)));
                            xCoordinate = DefaultX - ((names[i].Length) * (22));
                        }
                        else
                        {
                            drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 14)));
                            xCoordinate = DefaultX - ( (names[i].Length) * (46 - names[i].Length) );
                        }
                    }
                    else
                    {
                        drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) *8)));
                        xCoordinate = DefaultX - ( (names[i].Length) * 50 );
                    }
                    if (names[i].Equals("Simon"))
                    {
                        drawFont = new Font("Georgia", (65 - ((names[i].Length - 5) * 17)));
                    }
                    if (names[i].Equals("Jithin")|| names[i].Equals("Daniel")|| names[i].Equals("Philip"))
                    {
                        drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 10)));
                        xCoordinate = DefaultX - ((names[i].Length) * 40);
                    }
                    if (names[i].Equals("Thomas"))
                    {
                        drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 14)));
                        xCoordinate = DefaultX - ((names[i].Length) * 45);
                    }
                    if (names[i].Equals("Jonathon"))
                    {
                        drawFont = new Font("Georgia", (70 - ((names[i].Length - 5) * 8)));
                        xCoordinate = DefaultX - ((names[i].Length) * 32);
                    }

                    graphics.DrawString(names[i], drawFont, System.Drawing.Brushes.Black, xCoordinate, 300);
                    b.Save(writeLoc, image.RawFormat);

                    b.Dispose();
                    writeLoc = SaveLocation;
                    readLoc = ImageLocation;
                    drawFont = new Font("Georgia", 70);
                }
            }

/*

            else if (noOfImages >= names.Length && noOfImages > 0)
            {
                //if more or equal images just go thourgh them 
                //one by one and assign names 
                Console.WriteLine("3rd loop");
                while (true) ;
            }


            else
            {
                Console.WriteLine("No Image");
                while (true) ;
            }*/
            System.Windows.MessageBox.Show("Images Have Been Created in " + SaveLocation);
        }




    }
}
