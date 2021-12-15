using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libman
{
    /// <summary>
    /// Дополнительные методы для работы с формами.
    /// </summary>
    public static class FormExtensions
    {
        /// <summary>
        /// Выдаёт пользователю сообщение об ошибке.
        /// </summary>
        /// <param name="form">Форма, выдающая сообщение.</param>
        /// <param name="message">Текст сообщения.</param>
        public static void ErrorMessage(this Form form, string message)
        {
            MessageBox.Show(message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Получает ответ от пользователя на заданный вопрос.
        /// </summary>
        /// <param name="form">Форма, задающая вопрос.</param>
        /// <param name="question">Текст вопроса.</param>
        /// <param name="defaultanswer">Ожидаемый по умолчанию ответ.</param>
        /// <returns>Ответ пользователя (true - "да", false - "нет").</returns>
        public static bool Question(this Form form, string question, bool defaultanswer = true)
        {
            DialogResult answer =
                MessageBox.Show(
                    question,
                    form.Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    defaultanswer ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2
                    );
            return  answer == DialogResult.Yes;
        }

        /// <summary>
        /// Выдаёт пользователю информационное сообщение.
        /// </summary>
        /// <param name="form">Форма, выдающая сообщение.</param>
        /// <param name="message">Текст сообщения.</param>
        public static void InfoMessage(this Form form, string message)
        {
            MessageBox.Show(message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Выдаёт пользователю запрещающее сообщение.
        /// </summary>
        /// <param name="form">Форма, выдающая сообщение.</param>
        /// <param name="message">Текст сообщения.</param>
        public static void ProhibitionMessage(this Form form, string message)
        {
            MessageBox.Show(message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Выдаёт пользователю информационное сообщение.
        /// </summary>
        /// <param name="form">Форма, выдающая сообщение.</param>
        /// <param name="message">Текст сообщения.</param>
        public static void ImportantMessage(this Form form, string message)
        {
            MessageBox.Show(message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Выдаёт пользователю предупреждение.
        /// </summary>
        /// <param name="form">Форма, выдающая сообщение.</param>
        /// <param name="message">Текст сообщения.</param>
        public static void Warning(this Form form, string message)
        {
            MessageBox.Show(message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
