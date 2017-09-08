using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;


namespace _25Subat13
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        public string Pcommand;

        public Form1()
        {
            InitializeComponent();
        }

        public static double[] not = { 4.00, 3.50, 3.00, 2.50, 2.25, 1.75, 1.25, 0.75, 0 };//diğer formlardan ulaşabilmek için static olarak not sınırlarını saklayan int dizisi oluştur
        public double topnot = new double();
        public int topkredi = new int();
        bool klik = false;
        string yol;


        private void eklebtn_Click(object sender, EventArgs e)
        { 
            if (comboBox1.Text.Length > 0 && textders.Text.Length > 0 && textkredi.Text.Length > 0)//textboxların boş durumu kontrolü
            {
                try
                {
                    if (Convert.ToInt32(textkredi.Text) >= 0 && Convert.ToInt32(textkredi.Text) <= 50)//textbox a 0-100 aralığı dışında giriş kontrolü
                    {


                        int a = Convert.ToInt32(textkredi.Text);
                        int b = Convert.ToInt32(comboBox1.SelectedIndex.ToString());
                        topkredi += a;
                        topnot += (a * not[b]);
                        double sayi = (topnot / topkredi);
                        sayi = Math.Round(sayi, 2, MidpointRounding.AwayFromZero);
                        dataGridView1.Rows.Add(textders.Text, textkredi.Text, comboBox1.Text, not[b]);
                        label9.Text = sayi.ToString();
                    }
                    else
                        MessageBox.Show("Yanlış Giriş Yaptınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Yanlış Giriş Yaptınız!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Gerekli Alanları Doldur!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void yukle(string xml_yol)
        {
            try
            {
                dataGridView1.Rows.Clear();
                topkredi = 0;
                topnot = 0;
                DataSet dt = new DataSet();
                dt.ReadXml(xml_yol);
                for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                {

                    dataGridView1.Rows.Add(dt.Tables[0].Rows[i].ItemArray[0], dt.Tables[0].Rows[i].ItemArray[1],
                        dt.Tables[0].Rows[i].ItemArray[2], dt.Tables[0].Rows[i].ItemArray[3]);


                    int a = Convert.ToInt32(dt.Tables[0].Rows[i].ItemArray[1]);
                    double b = Convert.ToDouble(dt.Tables[0].Rows[i].ItemArray[3]);
                    topkredi += a;
                    topnot += (a * b);

                }
                dt.Dispose();
                double sayi = (topnot / topkredi);
                sayi = Math.Round(sayi, 2, MidpointRounding.AwayFromZero);
                label9.Text = sayi.ToString();
            }
            catch(Exception Ex){
                MessageBox.Show(Ex.ToString(), "Hata!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;

                int a = Convert.ToInt32(dataGridView1.Rows[index].Cells[1].Value.ToString());
                double b = Convert.ToDouble(dataGridView1.Rows[index].Cells[3].Value.ToString());
                topkredi -= a;
                topnot -= (a * b);
                double sayi = (topnot / topkredi);
                sayi = Math.Round(sayi, 2, MidpointRounding.AwayFromZero);
                label9.Text = sayi.ToString();
                dataGridView1.Rows.Remove(dataGridView1.Rows[index]);
            }
            catch
            {
                MessageBox.Show("Hata!!!", "Hata!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true; 
            file.Filter = "XML Dosyası|*.xml";
            file.Title = "Kayıt Dizini Seçin...";
            if (file.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    string DosyaYolu = file.FileName;
                    DataTable dt = new DataTable();
                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        DataColumn column = new DataColumn(dataGridView1.Columns[i - 1].HeaderText);

                        dt.Columns.Add(column);
                    }
                    int ColumnCount = dataGridView1.Columns.Count;
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        DataRow a;
                        a = dt.NewRow();
                        a[0] = dr.Cells[0].Value.ToString();
                        a[1] = dr.Cells[1].Value.ToString();
                        a[2] = dr.Cells[2].Value.ToString();
                        a[3] = dr.Cells[3].Value.ToString();
                        dt.Rows.Add(a);

                    }

                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    XmlTextWriter newXml = new XmlTextWriter(DosyaYolu, Encoding.UTF8);
                    ds.WriteXml(newXml);
                    MessageBox.Show(DosyaYolu + " Konumuna Kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.None);
                    newXml.Close();
                    ds.Dispose();
                    file.Dispose();
                }
                catch { MessageBox.Show("Kaydedilemedi!!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.InitialDirectory = Application.StartupPath;
                file.RestoreDirectory = true;
                file.Filter = "XML Dosyası|*.xml";
                file.Title = "Tablo Dizinini Açın..";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    string DosyaYolu = file.FileName;
                    yukle(DosyaYolu);
                    file.Dispose();
                }
                
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm a = new MainForm();
            a.Show();

        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            yol = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\dittiri.mp3";
            FileStream fs = new FileStream(yol, FileMode.Create);
            fs.Write(Properties.Resources.dittiri, 0, Properties.Resources.dittiri.Length);
            fs.Close();
            Pcommand = "open \"" + yol + "\" type mpegvideo alias MediaFile";
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (klik)
            {
                Pcommand = "stop MediaFile";
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
                klik = false;
                pictureBox1.Image = Properties.Resources.play1;
            }
            else
            {
                Pcommand = "play MediaFile REPEAT";
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
                klik = true;
                pictureBox1.Image = Properties.Resources.pause;
            }
        }

    }
}
