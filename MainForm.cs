/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14.03.2017
 * Time: 13:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ScreenSaver
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private Point mouseLocation;
		private Random rand = new Random();
		int i = 0;
		string[] files = Directory.GetFiles("C:\\Users\\User\\Downloads\\minimalism");
		public MainForm(Rectangle Bounds)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			Cursor.Hide();
			TopMost = true;
			
			moveTimer.Interval = 5000;
			moveTimer.Tick += new EventHandler(MoveTimerTick);
			moveTimer.Start();
		}
		void MainFormMouseMove(object sender, MouseEventArgs e)
		{
			if (!mouseLocation.IsEmpty) {
				// Terminate if mouse is moved a significant distance
				if (Math.Abs(mouseLocation.X - e.X) > 10 ||
				    Math.Abs(mouseLocation.Y - e.Y) > 10)
					Application.Exit();
			}
 
			// Update current mouse location
			mouseLocation = e.Location;

		}
		void MainFormMouseClick(object sender, MouseEventArgs e)
		{
			Application.Exit();
		}
		void MainFormKeyPress(object sender, KeyPressEventArgs e)
		{
			Application.Exit();
		}
		void MoveTimerTick(object sender, EventArgs e)
		{
			i++;
			MainForm.ActiveForm.BackgroundImage = Image.FromFile(files[i]);
			//label1.Left = rand.Next(Math.Max(1, Bounds.Width - label1.Width));
			//label1.Top = rand.Next(Math.Max(1, Bounds.Height - label1.Height));  
		}
		
		private void animateImageOpacity(PictureBox control)
    {
        for(float i = 0F; i< 1F; i+=.10F)
        {
            control.Image = ChangeOpacity(itemIcon[selected], i);
            Thread.Sleep(40);
        }
    }

    public static Bitmap ChangeOpacity(Image img, float opacityvalue)
    {
        Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
        Graphics graphics = Graphics.FromImage(bmp);
        ColorMatrix colormatrix = new ColorMatrix {Matrix33 = opacityvalue};
        ImageAttributes imgAttribute = new ImageAttributes();
        imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
        graphics.Dispose();   // Releasing all resource used by graphics 
        return bmp;
    }
	}
}
