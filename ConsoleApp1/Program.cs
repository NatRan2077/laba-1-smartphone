using System;
using System.Reflection.Metadata.Ecma335;

namespace laba1
{
    class App
    {
        string _name = "Name";
        double _memory2 = 0;
        public string name
        {
            get => _name;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Введите корректное имя приложения");
                }
                else
                {
                    _name = value;
                }
            }
        }
        public double memory2
        {
            get => _memory2;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Введите корректное значение занимаемой памяти");
                }
                else
                {
                    _memory2 = value;
                }
            }
        }
        public App(string name1, double memory1)
        {
            name = name1;
            memory2 = memory1;
        }
    }

    class Smartphone
    {
        string manufacturer12 = "Name";
        string _model = "Name";
        public string manufacturer
        {
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Введите корректное название производителя");
                }
                else
                {
                    manufacturer12 = value;
                }
            }
            get => manufacturer12;
        }
        public string model
        {
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Введите корректное название модели");
                }
                else
                {
                    _model = value;
                }
            }
            get => _model;

        }
        double cpuf = 0;
        int cpuc = 0;
        public double CPUfreq
        {
            set
            {
                if (value > 4000 || value < 0)
                {
                    throw new ArgumentException("Введите корректное значение частоты процессора");
                }
                else
                {
                    cpuf = value;
                }
            }
            get => cpuf;
        }
        public int CPUcore
        {
            set
            {
                if (value > 12 || value < 1)
                {
                    throw new ArgumentException("Введите корректное значение ядра процессора");
                }
                else
                {
                    cpuc = value;
                }
            }
            get => cpuc;
        }
        int ram = 0;
        public int RAM
        {
            set
            {
                if (value > 16 || value < 1)
                {
                    throw new ArgumentException("Введите корректное значение RAM");
                }
                else
                {
                    ram = value;
                }
            }
            get => ram;
        }
        string tRam = "Name";
        int mem = 0;
        public string typeOfRAM
        {
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Введите корректное значение");
                }
                else
                {
                    tRam = value;
                }
            }
            get => tRam;
        }
        public int memory
        {
            set
            {
                if (value > 1024 || value < 8)
                {
                    throw new ArgumentException("Введите корректное значение памяти телефона");
                }
                else
                {
                    mem = value;
                }
            }
            get => mem;
        }
        string os = "Name";
        string im = "Name";
        public string OS
        {
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Введите корректное значение операционной системы");
                }
                else
                {
                    os = value;
                }
            }
            get => os;
        }
        public string IMEI
        {
            set
            {
                if (value.Length != 16 && value.Length != 15)
                {
                    throw new ArgumentException("Введите корректное значение IMEI");
                }
                else
                {
                    im = value;
                }
            }
            get => im;
        }

        static double memory_used = 0;
        List<App> apps = new List<App>();
        public Smartphone(string manafacturer1, string model1, int cpufreq, int cpucore, int ram, string typeofram, int memory1, string os1, string imei1)
        {
            manufacturer = manafacturer1;
            model = model1;
            CPUfreq = cpufreq;
            CPUcore = cpucore;
            RAM = ram;
            typeOfRAM = typeofram;
            memory = memory1;
            OS = os1;
            IMEI = imei1;
        }

        public void HardReset()
        {
            apps.Clear();
        }
        public double averageApp()
        {
            double k = memory;
            foreach (var app in apps)
            {
                k -= app.memory2;
            }
            return k * 2;
        }
        public void print()
        {
            int i = 1;
            Console.WriteLine("Ваш смартфон: {0} {1}", manufacturer, model);
            Console.WriteLine("Операционная система: {0}", OS);
            Console.WriteLine("IMEI: {0}", IMEI, model);
            Console.WriteLine("Процессор. Частота: {0} МГц. Количество ядер: {1}", CPUfreq, CPUcore);
            Console.WriteLine("Оперативная память. Объем: {0} Гб. ТИп: {1}", RAM, typeOfRAM);
            if (apps.Count == 0)
            {
                Console.WriteLine("На устройстве не найдены установленные приложения.");
            }
            else
            {
                Console.WriteLine("Список установленных приложений: ");
                foreach (var app in apps)
                {
                    Console.Write($"{i}. ");
                    Console.WriteLine($"Название: {0}, занимаемая память: {1} Гб", app.name, app.memory2);
                    i++;
                }

            }
        }
        public void InstallApp(string name, double memory2)
        {
            /*foreach (App app in apps)
            {
                App.Print();
            }*/
            foreach (App app in apps)
            {

                memory_used += app.memory2;

                if (app.name == name)
                {
                    Console.WriteLine("Приложение с таким названием уже существует. Установка отменена.");
                    return;
                }
                //Console.WriteLine(memory_used);
                Console.WriteLine(memory2);
            }

            if (memory_used + memory2 > memory) // есть подозрения в этой фун
            {
                Console.WriteLine("На устройстве недостаточно места. Установка отменена.");
                /*double checkaddition = 0;
                checkaddition = memory_used + memory2;
                Console.WriteLine("CHECKADDITION {0}", checkaddition);*/
                //Console.WriteLine(memory2);
                return;
            }

            try
            {
                App app = new App(name, memory2);
                apps.Add(app);
            }
            catch (Exception)
            {
                throw (new Exception("Установка отменена."));
            }
            
        }
        public void DeleteApp(string name)
        {
            int i = 1;
            foreach (App app in apps)
            {
                if (app.name == name)
                {
                    apps.RemoveAt(i);
                    i++;
                }
                else { i++; }
            }
            Console.WriteLine("Приложение с таким названием не существует. Удаление не произошло.");
        }

    }
    class Functions
    {

    }
    class Program
    {

        static void Main()
        {

            Smartphone s1 = new Smartphone("Apple", "SE", 2000, 8, 6, "LPDDR3", 256, "IOS", "346741084731834");
            s1.print();
            s1.InstallApp("VK", 2);
            //s1.InstallApp("VK", 15);
            //s1.InstallApp("", 15);
            //s1.InstallApp("Game", -10);
            s1.InstallApp("YouTube", 8);
            s1.InstallApp("YourNETI", 10);
            s1.InstallApp("Word", 99);
            s1.DeleteApp("Word");
           // Console.WriteLine(s1.averageApp());
           // s1.HardReset();
            s1.print();
            
        }
    }
}