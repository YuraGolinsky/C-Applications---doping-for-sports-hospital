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
    public partial class Form2 : Form
    {
        public static string ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=БД Допинг.mdb";
        private OleDbConnection myConnection;
        public Form2()
        {
            // Установить свойство ControlBox в false
            this.ControlBox = false;
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;

                myConnection.Open();

                // Создаем запрос на добавление нового пользователя
                string query = "INSERT INTO Пользователи ([Логин], [Пароль]) VALUES (@Username, @Password)";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Пользователь успешно добавлен!");
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении пользователя.");
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении пользователя: " + ex.Message);
            }
        }

    }
}
