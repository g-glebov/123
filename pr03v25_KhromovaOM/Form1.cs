using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr03v25_KhromovaOM
{
    public partial class Form1 : Form
    {
        SalesInformation sales = new SalesInformation();

        public Form1()
        {
            InitializeComponent();
        }

        private void InsertTheNumber(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string fabricname;
            if (tbFabric.Text == "")
                fabricname = "Без названия ";
            else fabricname = tbFabric.Text;


            string factory = tbFactory.Text;
            if (tbFactory.Text == "")
                factory = "Неизвстно ";
            else factory = tbFactory.Text;

            try
            {
                Fabric typeoffabric = (Fabric)Enum.Parse(typeof(Fabric), cbFabric.Text, true);

                Colors color = (Colors)Enum.Parse(typeof(Colors), cbColor.Text, true);

                int pricepermeter = Convert.ToInt32(tbPricePerMeter.Text);

                double meters = Convert.ToDouble(tbNumberOfMeters.Text);

                Payment typeofpayment;
                if (rbCash.Checked)
                {
                    typeofpayment = (Payment)Enum.Parse(typeof(Payment), "Наличный", true);
                }
                else typeofpayment = (Payment)Enum.Parse(typeof(Payment), "Безналичный", true);

                sales.AddPurchase(fabricname, factory, typeoffabric, color, pricepermeter, meters, typeofpayment);
                tbInform.Text = sales.ToString();
            }
            catch (Exception ex) { MessageBox.Show("Убедитесь, что все поля запонены!"); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Удалить все данные?", "Предупреждение", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        sales.DeleteAll();
                        tbInform.Text = sales.ToString();
                        MessageBox.Show("Все данные успешно удалены.");
                        break;
                    }
                case DialogResult.No:
                    {
                        MessageBox.Show("Отмена удаления данных.");
                        break;
                    }
            }
        }

        private void btnDeleteID_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(nudID.Value);
            DialogResult result = MessageBox.Show("Удалить данные по товару №" + index + "?", "Предупреждение", MessageBoxButtons.YesNo);
            switch(result)
            {
                case DialogResult.Yes:
                    {
                        if(!sales.DeletePurchase(index))
                        {
                             string error = String.Format("Товара с номером {0} не существует!", Convert.ToInt32(index));
                             MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            tbInform.Text = sales.ToString();
                            MessageBox.Show("Товар с номером " + index + " успешно удален.");
                        }
                        
                        break;
                    }
                case DialogResult.No:
                    {
                        MessageBox.Show("Отмена удаления данных.");
                        break;
                    }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string filename;

            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                filename = openFileDialog1.FileName;

                StreamReader str;
                str = new StreamReader(openFileDialog1.FileName, System.Text.Encoding.GetEncoding("windows-1252"));
                tbInform.Text = str.ReadToEnd();
                str.Close();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter str =
                    new StreamWriter(saveFileDialog1.FileName, false, System.Text.Encoding.GetEncoding("utf-8"));
                str.Write(tbInform.Text);
                str.Close();
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            tbInform.Text += sales.Total();
        }

        private void удалитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sales.DeleteAll();
            tbInform.Text = sales.ToString();
        }
        
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbInform_TextChanged(object sender, EventArgs e)
        {
            tbInform.AppendText(tbInform.SelectedText);
        }

        private void cbFabric_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFabric.SelectedIndex = 1;
        }

        private void tbPricePerMeter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) return;
            else
            {
                MessageBox.Show("В это поле нужно ввести число!");
                e.Handled = true;
            };

        }

        private void tbNumberOfMeters_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',')
            {

                if (e.KeyChar == '.') e.KeyChar = ',';
                

                if (e.KeyChar == ',')
                {
                    if ((sender as TextBox).Text.IndexOf(',') != -1)
                        e.Handled = true;
                    return;
                }

                if (Char.IsNumber(e.KeyChar)
                   || (!string.IsNullOrEmpty((sender as TextBox).Text))
                   && e.KeyChar == ','
                   && Char.IsControl(e.KeyChar))
                {
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("В это поле нужно ввести число!");
                e.Handled = true;
            }
            if (e.KeyChar != (char)8) e.Handled = true;

        }
    }
}
