using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace range_limits_DZ
{
    public partial class listBoxPrimes : Form
    {
        // Конструктор формы - вызывается при создании окна
        public listBoxPrimes()
        {
            // Инициализация всех компонентов формы (кнопок, полей ввода и т.д.)
            InitializeComponent();
            // Устанавливаем заголовок окна
            this.Text = "Поиск простых чисел в диапазоне";

            // Устанавливаем минимальный размер окна
            this.MinimumSize = new Size(400, 300);
        }
        // Обработчик нажатия кнопки "Найти простые числа"
        private void btnFindPrimes_Click(object sender, EventArgs e)
        {
            // Очищаем список перед новым поиском
            listBox1.Items.Clear();

            // Пытаемся преобразовать введенные значения в числа
            if (!int.TryParse(txtFrom.Text, out int from) || !int.TryParse(txtTo.Text, out int to))
            {
                // Если введены не числа, показываем сообщение об ошибке
                MessageBox.Show("Пожалуйста, введите корректные числа!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем, чтобы начало диапазона не было больше конца
            if (from > to)
            {
                MessageBox.Show("Начало диапазона должно быть меньше или равно концу!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Получаем список простых чисел в заданном диапазоне
            List<int> primes = FindPrimesInRange(from, to);

            // Если простых чисел не найдено
            if (primes.Count == 0)
            {
                listBox1.Items.Add("В данном диапазоне простых чисел не найдено");
                return;
            }

            // Добавляем все найденные простые числа в список
            foreach (int prime in primes)
            {
                listBox1.Items.Add(prime);
            }

            // Показываем количество найденных простых чисел
            lblResult.Text = $"Найдено простых чисел: {primes.Count}";
        }

        // Метод для поиска простых чисел в диапазоне
        private List<int> FindPrimesInRange(int from, int to)
        {
            // Создаем список для хранения простых чисел
            List<int> primes = new List<int>();

            // Если начало диапазона меньше 2, начинаем с 2 (первое простое число)
            if (from < 2) from = 2;

            // Перебираем все числа в диапазоне
            for (int number = from; number <= to; number++)
            {
                // Проверяем, является ли число простым
                if (IsPrime(number))
                {
                    // Если простое - добавляем в список
                    primes.Add(number);
                }
            }

            // Возвращаем список найденных простых чисел
            return primes;
        }

        // Метод проверки числа на простоту
        private bool IsPrime(int number)
        {
            // Числа меньше 2 не являются простыми
            if (number < 2) return false;

            // 2 - единственное четное простое число
            if (number == 2) return true;

            // Все остальные четные числа не простые
            if (number % 2 == 0) return false;

            // Проверяем делители до квадратного корня из числа
            int boundary = (int)Math.Sqrt(number);

            // Проверяем только нечетные делители
            for (int i = 3; i <= boundary; i += 2)
            {
                // Если число делится на i без остатка, оно не простое
                if (number % i == 0)
                    return false;
            }

            // Если делителей не найдено - число простое
            return true;
        }

        // Обработчик нажатия кнопки "Очистить"
        private void button2_Click(object sender, EventArgs e)
        {
            // Очищаем все поля формы
            txtFrom.Text = "";
            txtTo.Text = "";
            listBox1.Items.Clear();
            lblResult.Text = "Найдено простых чисел: 0";
        }

        // Эти методы можно оставить пустыми, так как они не используются
        private void label1_Click(object sender, EventArgs e) { }
        private void listBoxPrimes_Load(object sender, EventArgs e) { }
    }
}
