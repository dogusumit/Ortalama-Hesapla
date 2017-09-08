/*
 * Created by SharpDevelop.
 * User: User
 * Date: 20.04.2013
 * Time: 12:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _25Subat13
{
	/// <summary>
	/// Description of Form2.
	/// </summary>
	public partial class Form2 : Form
	{
		public Form2()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		void Form2Load(object sender, EventArgs e)
		{
			textBox1.Text=MainForm.not[0].ToString();
			textBox2.Text=MainForm.not[1].ToString();
			textBox3.Text=MainForm.not[2].ToString();
			textBox4.Text=MainForm.not[3].ToString();
			textBox5.Text=MainForm.not[4].ToString();
			textBox6.Text=MainForm.not[5].ToString();
			textBox7.Text=MainForm.not[6].ToString();
			textBox8.Text=MainForm.not[7].ToString();
		}
		
		void TextBox1Leave(object sender, EventArgs e)
		{
			TextBox a=(TextBox)sender;
			try{
			int b=	Convert.ToInt32(a.Text);
			if(b>=0&&b<=100)
			{}
			else{
				MessageBox.Show("Yanlis Giriş Yaptınız!");
				a.Focus();}
			}
			catch{MessageBox.Show("Lütfen Sayı Giriniz!");
				a.Focus();}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			MainForm.not[0]=Convert.ToInt32(textBox1.Text);
			MainForm.not[1]=Convert.ToInt32(textBox2.Text);
			MainForm.not[2]=Convert.ToInt32(textBox3.Text);
			MainForm.not[3]=Convert.ToInt32(textBox4.Text);
			MainForm.not[4]=Convert.ToInt32(textBox5.Text);
			MainForm.not[5]=Convert.ToInt32(textBox6.Text);
			MainForm.not[6]=Convert.ToInt32(textBox7.Text);
			MainForm.not[7]=Convert.ToInt32(textBox8.Text);
			this.Close();
			
		}
	}
}
