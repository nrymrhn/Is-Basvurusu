using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iş_başvurusu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] diller = { "ingilizce", "almanca", "fransızça", "korece", "kürtçe", "çince", "italyanca" };
            yabancıdiller.Items.AddRange(diller); //addrange dizi eklemedir dizi değilse adddir
            yabancıdiller.MultiColumn = true; //içindeki dilleri yan yana gelmesini sağlıyor true olursa
            yabancıdiller.CheckOnClick = true; //dilleri tek işaretlemede seçiyor
            button3.Enabled = false; //enable özelliği buttonun tıklanıp tıklanmadığını gösterir.

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                button3.Enabled = false;
            else
                button3.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (yabancıdiller.Items.Contains(textBox2.Text) == false) //bu kod yabancı dillerin içinde ekleyeceğimiz dil yoksa ekle anlamına gelmektedir.
                    yabancıdiller.Items.Add(textBox2.Text);
                else
                    MessageBox.Show("eklediğiniz dil zaten vardır!");
                textBox2.Text = ""; //bu kodu yazmamızın sebebi yazdığımız dili silmek yazmasakta olur ama.
            }
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            yabancıdiller.Items.Remove(yabancıdiller.SelectedItem); //bu kodla seçili olan dili siliyoruz

        }

        private void button4_Click(object sender, EventArgs e)
        {
            while (yabancıdiller.CheckedIndices.Count > 0)
                yabancıdiller.SetItemChecked(yabancıdiller.CheckedIndices[0], false); //bu kodla seçili dillerinin işaretlerini kaldırıyoruz.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = textBox1.Text;
            string diller = "", mezuniyet = ""; //diller ve meuzniyet değişkenleri tanımlandı burda.
            for (int i = 0; i < yabancıdiller.CheckedItems.Count; i++)
            {
                diller += ", " + yabancıdiller.CheckedItems[i];
            }
            diller = diller.Substring(2); //bu kodla virgülin 2 dilden sonra araya katmasını sağöladık yani tek dil seçtiğimizde gelemeyecek
            label7.Text = diller;
            if (radioButton1.Checked)
                mezuniyet = radioButton1.Text;
            else if (radioButton2.Checked)
                mezuniyet = radioButton2.Text;
            else if (radioButton3.Checked)
                mezuniyet = radioButton3.Text;
            else if (radioButton4.Checked)
                mezuniyet = radioButton4.Text;
            label8.Text = mezuniyet;


        }
    }
}
