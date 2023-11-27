using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=БД Допинг.mdb";
        private OleDbConnection myConnection;

        public Form1()
        {
            // Установить свойство ControlBox в false
            this.ControlBox = false;
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            myConnection.Open();
            string query = "SELECT COUNT(*) FROM Пользователи WHERE [Логин] = @Username AND [Пароль] = @Password";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("Авторизация успешна!");

                // Открываем Form3 при успешной авторизации
                Form3 form3 = new Form3();
                form3.Show();

                // Закрываем текущую форму (Form1)
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }

            myConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

            // Закрываем текущую форму (Form1)
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();

            // Закрываем текущую форму (Form1)
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Закрыть текущее приложение
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = @"D:\Проект приложения Допинг\Инструкция.doc";

                // Проверка наличия файла по указанному пути
                if (System.IO.File.Exists(filePath))
                {
                    Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show("Файл не найден по указанному пути.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии документа: " + ex.Message);
            }
        }
    }
}
