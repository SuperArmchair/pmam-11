using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace BookstoreApp
{
    public partial class Form1 : Form
    {
        // Створюємо об’єкт логіки — сюди винесено всі розрахунки та аналітику
        private BookstoreLogic bookstore = new BookstoreLogic();

        public Form1()
        {
            InitializeComponent();
            InitializeColoredPromotionText(); // Після побудови форми — генеруємо кольоровий текст акції
        }

        private void InitializeColoredPromotionText()
        {
            // Метод формує красивий кольоровий текст у textBox1 (RichTextBox)
            // Використовуємо AppendColoredText для різних кольорів і шрифтів

            AppendColoredText(textBox1, "                     Увага! Акція!", Color.Red, true);
            AppendColoredText(textBox1, "", Color.Black);

            AppendColoredText(textBox1, "Одна книга коштує 8.00 ₴", Color.FromArgb(128, 0, 0), true);
            AppendColoredText(textBox1, "", Color.Black);

            AppendColoredText(textBox1, "Знижки при купівлі кількох різних книг серії з 5 книг:", Color.FromArgb(128, 0, 0), true);

            // Детальний список знижок
            AppendColoredText(textBox1, " - 2 різні книги: 5% знижка", Color.FromArgb(119, 153, 119), true);
            AppendColoredText(textBox1, " - 3 різні книги: 10% знижка", Color.Orange, true);
            AppendColoredText(textBox1, " - 4 різні книги: 20% знижка", Color.FromArgb(238, 119, 68), true);
            AppendColoredText(textBox1, " - 5 різних книг: 25% знижка", Color.Red, true);

            AppendColoredText(textBox1, "", Color.Black);
            AppendColoredText(textBox1, "Групи формуються так, щоб максимізувати знижку.", Color.FromArgb(128, 0, 0));
            AppendColoredText(textBox1, "Ця інформація допомагає планувати покупку та економити.", Color.FromArgb(128, 0, 0));
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Зчитуємо кількість книг з NumericUpDown елементів
            int[] basket = new int[5]
            {
                (int)nudBook1.Value,
                (int)nudBook2.Value,
                (int)nudBook3.Value,
                (int)nudBook4.Value,
                (int)nudBook5.Value
            };

            // Отримуємо оптимальну ціну та групи з BookstoreLogic
            var result = bookstore.CalculateBestPriceWithGroups(basket);

            // Ціна без знижок (8 грн * кількість книг)
            decimal noDiscountPrice = basket.Sum() * bookstore.BookPrice;

            // Очищаємо поле перед новим розрахунком
            txtOutput.Clear();

            // Виводимо загальні дані кольоровим текстом
            AppendColoredText(txtOutput, "                             Ваше замовлення:", Color.FromArgb(62, 43, 38));
            AppendColoredText(txtOutput, $"Мінімальна ціна кошика зі знижками: {result.price:C}", Color.FromArgb(128, 0, 0));
            AppendColoredText(txtOutput, $"Загальна кількість книг: {basket.Sum()}", Color.FromArgb(128, 0, 0));
            AppendColoredText(txtOutput, $"Середня ціна за книгу: {(basket.Sum() > 0 ? result.price / basket.Sum() : 0m):C}", Color.FromArgb(128, 0, 0));
            AppendColoredText(txtOutput, "", Color.Black);

            // Виводимо сформовані групи для знижок
            AppendColoredText(txtOutput, "Групи книг для максимальної знижки:", Color.FromArgb(62, 43, 38));
            foreach (var group in result.groups)
            {
                string groupText =
                    $" - Група (з {group.Count} книг) зі знижкою {bookstore.Discounts[group.Count] * 100}%: [{string.Join(", ", group.Select(i => i + 1))}]";

                AppendColoredText(txtOutput, groupText, Color.FromArgb(136, 17, 68));
            }

            AppendColoredText(txtOutput, "", Color.Black);

            // Порівняння з ціною без акції
            AppendColoredText(txtOutput, $"Ціна без застосування будь-яких знижок: {noDiscountPrice:C}", Color.FromArgb(128, 0, 0));
            AppendColoredText(txtOutput, $"Ціна при купівлі кожної книги окремо: {noDiscountPrice:C}", Color.FromArgb(128, 0, 0));
            AppendColoredText(txtOutput, $"Економія завдяки акції: {noDiscountPrice - result.price:C}", Color.FromArgb(204, 0, 0));
            AppendColoredText(txtOutput, "", Color.Black);

            // Отримуємо розширений аналіз у реальних сценаріях
            AppendColoredText(txtOutput, "                             Рекомендації:", Color.FromArgb(62, 43, 38));
            var realWhatIf = bookstore.RealWhatIfAnalysis(basket);

            if (realWhatIf.Any())
            {
                // Виводимо кожну рекомендацію стилізовано
                foreach (var suggestion in realWhatIf)
                {
                    Color suggestionColor = GetSuggestionTitleColor(suggestion);
                    AppendColoredText(txtOutput, suggestion, suggestionColor);
                }
            }
            else
            {
                // Якщо група ідеальна
                AppendColoredText(txtOutput, "Вітаємо! Ваш вибір вже оптимальний для ваших потреб!", Color.Green);
            }
        }

        private Color GetSuggestionTitleColor(string suggestion)
        {
            // Метод визначає, які заголовки рекомендацій фарбувати індивідуальними кольорами

            if (suggestion.StartsWith("Повна колекція:"))
                return Color.Purple;

            if (suggestion.StartsWith("Для бібліотеки:"))
                return Color.DarkCyan;

            if (suggestion.StartsWith("Для читання з друзями:"))
                return Color.DarkOrange;

            if (suggestion.StartsWith("Вигідна заміна:"))
                return Color.Blue;

            if (suggestion.StartsWith("Бюджет"))
                return Color.Orange;

            if (suggestion.StartsWith("Ваш бюджет"))
                return Color.Orange;

            // Інші рядки робимо стандартним бордовим
            return Color.FromArgb(128, 0, 0);
        }

        private void AppendColoredText(RichTextBox rtb, string text, Color color, bool addNewLine = true)
        {
            // Метод додає текст у RichTextBox і змінює колір саме для даного фрагмента

            if (string.IsNullOrEmpty(text) && addNewLine)
            {
                rtb.AppendText("\n"); // Просто новий рядок
                return;
            }

            rtb.SelectionStart = rtb.TextLength; // Переходимо в кінець тексту
            rtb.SelectionLength = 0;
            rtb.SelectionColor = color;         // Встановлюємо потрібний колір
            rtb.AppendText(text + (addNewLine ? "\n" : ""));

            rtb.SelectionColor = rtb.ForeColor; // Повертаємо стандартний колір
        }
    }
}
