using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Attendance_Check_System.formImp
{
    public class controlImp
    {
        private static controlImp control = new controlImp();
        public static controlImp getControlImp()
        {
            return control;
        }

        public void showDialog(Form form,string msg)
        {
            form.BeginInvoke((EventHandler)delegate 
            {
                MessageBox.Show(msg);
            });
        }

        public void setBtnEnabled(Form form, Button button, bool type)
        {
            form.BeginInvoke((EventHandler)delegate
            {
                button.Enabled = type;
            });
        }

        public void setBtnVisible(Form form, Button button, bool type)
        {
            form.BeginInvoke((EventHandler)delegate
            {
                button.Visible = type;
            });
        }

        public void setBtnText(Form form, Button button, string text)
        {
            form.BeginInvoke((EventHandler)delegate
            {
                button.Text = text;
            });
        }

        public void setLabelText(Form form, Label label, string value)
        {
            form.BeginInvoke((EventHandler)delegate 
            {
                label.Text = value;
            });
        }

        public void exchangePage(Form form, Form aimForm)
        {
            form.BeginInvoke((EventHandler)delegate
            {
                form.Visible = false;
                aimForm.Visible = true;
            });
        }

        public void appendTextBox(Form form, TextBox textBox, string value)
        {
            form.BeginInvoke((EventHandler)delegate
            {
                textBox.AppendText(value + "\r\n");
            });
        }

        public void setTextBoxText(Form form,TextBox textBox,string value)
        {
            form.BeginInvoke((EventHandler)delegate 
            {
                textBox.Text = value;
            });
        }

        public void setDataGridViewSource(Form form, DataGridView dgv, DataTable table)
        {
            form.BeginInvoke((EventHandler)delegate
            {
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.AllowUserToAddRows = false;
                dgv.RowHeadersVisible = false;
                dgv.AllowUserToResizeColumns = false;
                dgv.AllowUserToResizeRows = false;
                dgv.DataSource = table;
            });
        }

        public void setProgress(Form form, ProgressBar progressBar, int value, int max, string msg)
        {
            form.BeginInvoke((EventHandler)delegate
            {
                form.Text = msg;
                progressBar.Value = value - 10;
                progressBar.Maximum = max;
                for (int i = value - 10; i < value; i++)
                {
                    Thread.Sleep(12);
                    progressBar.Value++;
                }
            });
        }
    }
}
