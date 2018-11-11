using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceForms
{
    public class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static Timer Timer;

        private static short _count; // счётчик циклов
        public static int Speed; // скорость игры
        private static Random _randm;

        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        //Объявляем массив косических объектов
        public static StarsObjects[] SmallStars;
        public static StarsObjects[] Stars;
        public static Meteors[] Meteorits;
        public static SpaceShip Ship;
        public static Bullets BulletsShort;
 
        /// <summary>
        /// Инициируем поле для рисования
        /// </summary>
        /// <param name="form">Форма, на которой быдет выводится изображение</param>
        public static void InitGame(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics graphics;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height - 40;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(graphics, new Rectangle(0, 40, Width, Height));
            Load();
        }

        /// <summary>
        /// Создаём массив звёзд и заполняем его координатами
        /// Объявляем корабль
        /// </summary>
        public static void Load() // Можно ли данный метод засунуть в SpaceObjects, а здесь только переопределить размеры и количество?
        {
            _randm = new Random();
            Stars = new StarsObjects[_randm.Next(35, 45)];
            SmallStars = new StarsObjects[_randm.Next(210,300)];
            
            Speed = 20;
            //CreatSpaceObjects(Stars);

            for (var i = 0; i < SmallStars.Length; i++)
            {
                //var dirRandom = Randm.Next(10, 15);
                SmallStars[i] = new StarsObjects(new Point(_randm.Next(0, 800), _randm.Next(30, 600)),
                    new Point(Speed/8, 0), new Size(1, 1));
            }

            for (var i = 0; i < Stars.Length; i++)
            {
                var sizeRandom = _randm.Next(5, 20);
                Stars[i] = new StarsObjects(new Point(_randm.Next(0, 780), _randm.Next(30, 580)),
                    new Point(Speed, 20), new Size(sizeRandom, sizeRandom));
            }

            Meteorits = new Meteors[_randm.Next(20,30)];
            //CreatSpaceObjects(Meteors);
            for (var i = 0; i < Meteorits.Length; i++)
            {
                Meteorits[i] = new Meteors(new Point(_randm.Next(10, 750), _randm.Next(10, 550)),
                    new Point(Speed/4, 20), new Size(1, 1));
            }

            Ship = new SpaceShip (new Point(80, 200), new Point(Speed,20), new Size(20, 20), Speed/20);
            _count = 0;// объявляем счётчик скорости

            Bullets.Bullet = false;

            // Создаём счётчик и привязываемся к событию по счётчику
            Timer = new Timer { Interval = 100 };
            Timer.Start();
            Timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Событие по счётчику времени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            DrawGame();
            Update();
        }

        //эта фигня не заработала
        /// <summary>
        /// Передаём массив объектов
        /// Заполняем массив новыми объектами с новыми координатами
        /// </summary>
        /// <param name="objct">массив объектов</param>
        //private static void CreatSpaceObjects(Object[] objct)
        //{
        //    for (var i = 0; i < objct.Length; i++)
        //    {
        //        var type = typeof(objct[i].GetType());
        //        var sizeRandom = Randm.Next(10, 15);
        //        // как реализовать задумку?
        //        //objct[i] = new  (new Point(Randm.Next(10, 750), Randm.Next(10, 550)),
        //        //    new Point(20, 20), new Size(sizeRandom, sizeRandom));
        //    }
        //}

        /// <summary>
        /// обновляем данные по координатам
        /// вызываея виртуальные методы Всех объектов
        /// </summary>
        public static void Update()
        {
            foreach (var smallStar in SmallStars)
                smallStar.Update();

            foreach (var meteor in Meteorits)
                meteor.Update();

            foreach (var star in Stars)
                star.Update();


            Ship.Update();

            if (Bullets.Bullet)
            {
                BulletsShort.Update();
            }


            _count++; // считаем количество циклов
            if (_count % 700 != 0) return;
            Speed += 5; //увеличиваем скорость по времени
            _count = 0;
        }

        /// <summary>
        /// Рисуем объекты
        /// </summary>
        public static void DrawGame()
        {
            // Закрышиваем всё поле чёрный
            Buffer.Graphics.Clear(Color.Black);

            foreach (var smallStar in SmallStars)
                smallStar.DrawSmallStars();

            foreach (var stars in Stars)
                stars.Draw();

            foreach (var meteor in Meteorits)
                meteor.Draw();

            // выводим корабль
             Ship.Draw();

            if (Bullets.Bullet) BulletsShort.Draw();

            Buffer.Render();
        }
    }
}