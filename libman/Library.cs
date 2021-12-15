using System.Xml;

namespace libman
{
    public class Library
    {
        #region Типы

        public class FileNameEventArgs
        {
            public FileNameEventArgs(string filename)
            {
                FileName = filename;
            }

            public string FileName { get; private set; }
        }

        public delegate void FileNameChangedEventHandler(object sender, FileNameEventArgs args);

        #endregion

        #region Конструкторы (закрытые)

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Library()
        {
            FileName = "";
            Customers = new Customers();
            Books = new Books();
            DeliveredBooks = new DeliveredBooks();
        }

        #endregion

        #region Cвойства (общедоступные)

        /// <summary>
        /// Имя файла библиотеки.
        /// </summary>
        public string FileName
        {
            get => filename;
            private set
            {
                filename = value;
                FileNameChanged?.Invoke(this, new FileNameEventArgs(filename));
            }
        }

        /// <summary>
        /// Признак модифицированности данных библиотеки.
        /// </summary>
        public bool Modified
        {
            get => Customers.Modified || Books.Modified || DeliveredBooks.Modified;
            set
            {
                Customers.Modified = value;
                Books.Modified = value;
                DeliveredBooks.Modified = value;
            }
        }

        /// <summary>
        /// Данные о читателях.
        /// </summary>
        public Customers Customers { get; set; }

        /// <summary>
        /// Данные о книгах.
        /// </summary>
        public Books Books { get; set; }

        /// <summary>
        /// Данные о выданных книгах.
        /// </summary>
        public DeliveredBooks DeliveredBooks { get; set; }

        #endregion

        #region Методы (общедоступные)

        /// <summary>
        /// Сохраняет данные библиотеки в файл.
        /// </summary>
        /// <param name="filename">Имя файла для выгрузки.</param>
        public void Save(string filename)
        {
            using (DataWriter output = new DataWriter(filename))
            {
                output.Start();
                output.Write(Customers);
                output.Write(Books);
                output.Write(DeliveredBooks);
                output.Finish();
                output.Close();
                Modified = false;
                FileName = filename;
            }
        }

        /// <summary>
        /// Загружает данные библиотеки из файла.
        /// </summary>
        /// <param name="filename">Имя файла для загрузки.</param>
        public void Load(string filename)
        {
            DataReader input = new DataReader(filename);
            input.Start();
            input.ReadObjects();
            input.Close();
            Customers.RestoreNumeration();
            Books.RestoreNumeration();
            Modified = false;
            FileName = filename;
        }

        /// <summary>
        /// Полностью очищает все данные.
        /// </summary>
        public void Clear()
        {
            FileName = "";
            Customers.Clear();
            Books.Clear();
            DeliveredBooks.Clear();
        }

        #endregion

        #region События (общедоступные)

        public event FileNameChangedEventHandler FileNameChanged;

        #endregion

        #region Поля

        string filename;

        #endregion

        #region Статические поля (общедоступные)

        public static Library Data = new Library();

        #endregion

        #region Статические методы

        bool IsAllowedTypeName(string typename)
        {
            return
                typename == typeof(Customer).Name ? true :
                typename == typeof(Book).Name ? true :
                typename == typeof(DeliveredBook).Name ? true :
                false;
        }

        #endregion
    }
}
