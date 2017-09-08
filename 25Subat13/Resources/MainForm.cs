
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _25Subat13
{
	/// <summary>
	/// Description of MainForm.
	/// 
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public static int[] not={90,80,70,65,60,55,50,40};
		
		void Button1Click(object sender, EventArgs e)
		{double a=new double();
			try{
				a=Convert.ToDouble(textBox1.Text);
							if(a<101&&a>=0){
				a=(a*0.4);
				AA.Text=Math.Ceiling((not[0]-a)/0.6).ToString();
				BA.Text=Math.Ceiling((not[1]-a)/0.6).ToString();
				BB.Text=Math.Ceiling((not[2]-a)/0.6).ToString();
				CB.Text=Math.Ceiling((not[3]-a)/0.6).ToString();
				CC.Text=Math.Ceiling((not[4]-a)/0.6).ToString();
				DC.Text=Math.Ceiling((not[5]-a)/0.6).ToString();
				DD.Text=Math.Ceiling((not[6]-a)/0.6).ToString();
				FD.Text=Math.Ceiling((not[7]-a)/0.6).ToString();
			}
			else{MessageBox.Show("Yanlış Giriş Yaptınız!");
			}
			}
			catch{
				MessageBox.Show("Lütfen Sayı Giriniz!");
				
			}

			
		}
		

		
		void Button2Click(object sender, EventArgs e)
		{
			Form2 a=new Form2();
			this.Visible=false;
			a.ShowDialog();
			this.Visible=true;
			
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
	}
}
