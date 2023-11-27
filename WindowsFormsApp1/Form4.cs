using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public static string ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=БД Допинг.mdb";
        private OleDbConnection myConnection;
        public Form4()
        {
            // Установить свойство ControlBox в false
            this.ControlBox = false;
            InitializeComponent();
            myConnection = new OleDbConnection(ConnectString);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "бД_ДопингDataSet.Запись_к_врачу". При необходимости она может быть перемещена или удалена.
            this.запись_к_врачуTableAdapter.Fill(this.бД_ДопингDataSet.Запись_к_врачу);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Закрыть текущее приложение
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

            // Закрываем текущую форму 
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedSport = comboBox1.Text; // Получаем выбранный вид спорта из comboBox1

                myConnection.Open();

                // Создаем запрос на выборку данных с сортировкой по виду спорта
                string query = "SELECT [ID запись], [ФИО], [Номер телефона], [Дата приёма], [Дата сдачи анализов], [Вид спорта] " +
                               "FROM [Запись к врачу] " +
                               "WHERE [Вид спорта] = @SelectedSport " +
                               "ORDER BY [Вид спорта]";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.AddWithValue("@SelectedSport", selectedSport);

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Здесь вы можете использовать dataTable для отображения данных, например, в DataGridView
                dataGridView1.DataSource = dataTable;

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 Form5 = new Form5();
            Form5.Show();

            // Закрываем текущую форму 
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedId = Convert.ToInt32(comboBox2.SelectedValue); // Получаем выбранный ID из comboBox2

                myConnection.Open();

                // Создаем запрос на удаление данных по выбранному ID
                string query = "DELETE FROM [Запись к врачу] WHERE [ID запись] = @SelectedId";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.AddWithValue("@SelectedId", selectedId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Данные успешно удалены!");
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении данных.");
                }

                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении данных: " + ex.Message);
            }
        }

    }
}
