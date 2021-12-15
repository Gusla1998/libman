using System;
using System.Collections.Generic;
using System.Xml;

namespace libman
{
    /// <summary>
    /// Вывод данных о библиотеке в формате XML.
    /// </summary>
    public class DataWriter: IDisposable
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public DataWriter()
        {
            output = null;
        }

        /// <summary>
        /// Создаёт поток записи в файл с указанным именем.
        /// </summary>
        /// <param name="filename">Имя файла для записи.</param>
        public DataWriter(string filename)
        {
            output = XmlWriter.Create(filename);
            output.WriteStartDocument(true);
        }

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Открывает запись данных.
        /// </summary>
        /// <returns>Этот объект.</returns>
        public DataWriter Start()
        {
            output.WriteStartElement("library");
            return this;
        }

        /// <summary>
        /// Завершает запись данных.
        /// </summary>
        /// <returns>Этот объект.</returns>
        public DataWriter Finish()
        {
            output.WriteEndElement();
            return this;
        }

        /// <summary>
        /// Записывает набор пар (имя, значение).<br />
        /// </summary>
        /// <param name="name">Имя набора значений.</param>
        /// <param name="values">Записываемый набор значений.</param>
        /// <returns>Этот объект.</returns>
        public DataWriter Write(string name, ValueSet values)
        {
            output.WriteStartElement(name);
            foreach (var pair in values)
            {
                output.WriteStartElement(pair.Key);
                output.WriteString(pair.Value);
                output.WriteEndElement();
            }
            output.WriteEndElement();
            return this;
        }

        /// <summary>
        /// Записывает представление коллекции объектов библиотеки.
        /// </summary>
        /// <param name="collection">Выводимая коллекция объектов</param>
        /// <returns>Этот объект.</returns>
        public DataWriter Write<TData, TKey>(ILibDataCollection<TData, TKey> collection)
            where TData: ILibDataObject<TKey>
            where TKey: IComparable<TKey>
        {
            foreach (TData item in collection)
                Write(item.GetType().Name, item.AsValues);
            return this;
        }

        /// <summary>
        /// Закрывает запись.
        /// </summary>
        public void Close()
        {
            output.WriteEndDocument();
            output.Close();
        }

        #region Реализация IDisposable

        public void Dispose()
        {
            ((IDisposable)output).Dispose();
        }

        #endregion

        #endregion

        #region Поля

        XmlWriter output;

        #endregion

    }
}
