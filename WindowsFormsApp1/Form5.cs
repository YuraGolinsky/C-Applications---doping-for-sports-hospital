using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public static string ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=БД Допинг.mdb";
        private OleDbConnection myConnection;
        public Form5()
        {
            // Установить свойство ControlBox в false
            this.ControlBox = false;
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.Show();

            // Закрываем текущую форму (Form1)
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string fio = textBox1.Text; // ФИО
                string phoneNumber = textBox2.Text; // Номер телефона
                DateTime dateOfAppointment = dateTimePicker1.Value; // Дата приёма
                DateTime dateOfTests = dateTimePicker2.Value; // Дата сдачи анализов
                string sportType = comboBox1.Text; // Вид спорта

                myConnection.Open();

                // Создаем запрос на добавление новых данных
                string query = "INSERT INTO [Запись к врачу] ([ФИО], [Номер телефона], [Дата приёма], [Дата сдачи анализов], [Вид спорта]) " +
                               "VALUES (@FIO, @PhoneNumber, @DateOfAppointment, @DateOfTests, @SportType)";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.AddWithValue("@FIO", fio);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@DateOfAppointment", dateOfAppointment);
                command.Parameters.AddWithValue("@DateOfTests", dateOfTests);
                command.Parameters.AddWithValue("@SportType", sportType);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Новые данные успешно добавлены!");
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении новых данных.");
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении новых данных: " + ex.Message);
            }
        }

    }
}
