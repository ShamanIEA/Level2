using System;
using System.Drawing;
using System.Windows.Forms;
namespace SpaceForms
{
    internal static class BackGround
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static Timer Timer;
        
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        //Объявляем массив косических объектов
        public static SpaceObjects[] SpaceObj;
        
        /// <summary>
        /// Создаём массив звёзд и заполняем его координатами
        /// </summary>
        private static void Load()
        {
            var random = new Random();

            SpaceObj = new SpaceObjects[random.Next(50,60)];
            for (var i = 0; i < SpaceObj.Length; i++)
            {
                var sizeRandom = random.Next(5, 20);
                SpaceObj[i] = new SpaceObjects(new Point(random.Next(10, 750), random.Next(10, 550)),
                    new Point(20, 20), new Size(sizeRandom, sizeRandom));
            }

            // Создаём счётчик и привязываемся к событию по счётчику
            Timer = new Timer {Interval = 100};
            Timer.Start();
            Timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Инициализируем поле для вывода графики
        /// Создаём звёзды
        /// </summary>
        /// <param name="form"></param>
        public static void InitBackground(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics graphics;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height - 42;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(graphics, new Rectangle(0, 40, Width, Height));
            Load();
        }

        /// <summary>
        //// Рисуем на форме при на старте программы
        /// </summary>
        public static void DrawBackground()
        {
            // Заполняем всё чёрным
            Buffer.Graphics.Clear(Color.Black);

            //Рисуем звёзды
            foreach (SpaceObjects obj in SpaceObj)
                obj.Draw();

            Buffer.Render();
        }

        /// <summary>
        /// обновляем данные по координатам
        /// вызываея виртуальный метод из SpaceObjects
        /// </summary>
        public static void Update()
        {
            foreach (SpaceObjects obj in SpaceObj)
                obj.Update();
        }

        /// <summary>
        /// Событие по счётчику времени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            DrawBackground();
            Update();
        }
    }
}