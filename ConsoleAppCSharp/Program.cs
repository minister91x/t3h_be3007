using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    internal class Program
    {
        public int a = 0;

        public static int CongHaiSo(int a, int b)
        {
            return a + b;
        }
        public static int CongBaSo(int a, int b, int c)
        {
            return a + b + c;
        }

        public static void ThamTri(int x)
        {
            x = x * x;
            Console.WriteLine(x);
        }
        public static void ThamChieu(ref int x)
        {
            x = x * x;
            Console.WriteLine(x);
        }
        public static void OutExample(out int x)
        {
            x = 100;
        }


        public static void AddItem()
        {
            var a = Console.ReadLine();
        }

        public static void ShowItem()
        {

        }
        //public static int ChiaHaiSo(int a, int b)
        //{
        //    try
        //    {
        //        throw new MyException("day là myexception"); 
        //       // return a / b;
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        Console.WriteLine("Lỗi chia cho không");
        //        Console.WriteLine("DivideByZeroException {0}:", ex.Message);
        //    }
        //    catch (MyCustomException ex)
        //    {
        //        Console.WriteLine("Lỗi chia cho không");
        //        Console.WriteLine("OutOfMemoryException {0}:", ex.StackTrace);
        //    }
        //    catch (MyException ex)
        //    {
        //        Console.WriteLine("Message: {0}:", ex.Message);
        //        Console.WriteLine("StackTrace: {0}", ex.StackTrace);
        //        Console.WriteLine("Source: {0}", ex.Source);
        //    }
        //    finally
        //    {
        //        Console.WriteLine("finally");
        //    }

        //    return 0;

        //}

        public static int Sum(int a)
        {
            var sum = 0;
            //sum = + 1 + 2 + ..+10;
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Các số {0},", i);
                sum += i;
            }

            return sum;
        }

        public static void Swap(int a, int b)
        {
            Console.WriteLine("Trước khi Swap a={0} ,b={1}:", a, b);
            int temp = 0;
            temp = a;
            a = b;
            b = temp;

            Console.WriteLine("Trước khi Swap a={0} ,b={1}:", a, b);
        }

        struct Person
        {
            public int Id;
            public string Name;

            public Person(int id, string name)
            {
                this.Id = id;
                this.Name = name;
            }

            public string Speak(string language)
            {
                return this.Name + " Nói ngôn ngữ :" + language;
            }

        }



        public struct Product
        {
            public int _number { get; set; }
            public int _price { get; set; }
            public string _typename { get; set; }

            public Product(int number, int price, string typename)
            {
                this._number = number;
                this._price = price;
                this._typename = typename;
            }

            public string Run(int number, string type)
            {
                if (number == 0 && type != "RON95")
                {
                    return "Stop";
                }
                _typename = type;

                return "Running with :" + _typename;
            }
        }


        enum Hocluc
        {
            GIOI = 1,
            KHA = 2,
            TRUNGBINH = 3,
            KEM = 4
        };

        enum TrangThai
        {
            DA_DAT_HANG = 1,
            DA_THANH_TOAN = 2,
            DANG_VAN_CHUYEN = 3,
            DA_GIAO = 4
        };

        enum HeSoLuong
        {
            HeSo1= 2,
            Heso2= 3,
            Heso3 = 4,
        }
        static void Main(string[] args)
        {

            var person = new Person();

            person.Id = 1;
            person.Name = "Mr Quân";
            person.Speak("VietNamese");

            Console.WriteLine(" personSpeak {0}", person.Speak("VietNamese"));

            var status = 1;
            var statusName = "";
            if (status == 1)
            {
                ///
                ///

            }

            if (status == (int)HeSoLuong.HeSo1)
            {
                ///
                ///

            }

            //string[] cars = { "Honda", "BMW", "Ford", "Mazda" };
            //int[] numbers = { 1, 7, 3, 9, 6, 8 };

            //cars[3] = "Mercedes G63";

            ////  Console.WriteLine("cars1 {0}", cars1[0]);

            //for (int i = 0; i < cars.Length; i++)
            //{
            //    Console.WriteLine("cars name index {0} = {1}", i, cars[i]);
            //}

            //Array.Sort(numbers);

            //foreach (var item in numbers)
            //{
            //    Console.WriteLine("numbers {0}", item);
            //}

            //var structProd = new Product();
            //var structProd_ = new Product(10, 1500, "RON95");

            //structProd._number = 1000;
            //structProd._price = 1500;
            //structProd._typename = "RON95";

            //var run = structProd.Run(structProd_._number, structProd_._typename);

            //Console.WriteLine("Product _number {0}", structProd._number);
            //Console.WriteLine("Product _price {0}", structProd._price);
            //Console.WriteLine("ProductRun {0}", run);

            //var isCancel = true;
            //var choose = Convert.ToInt32( .ReadLine());
            //while (!isCancel)
            //{
            //    switch (choose)
            //    {
            //        case 1: AddItem(); break;
            //        case 2: ShowItem(); break;
            //        case 4: isCancel = false; break;
            //    }
            //}
            //int a = 10;
            //ThamTri(a);
            //Console.WriteLine("ThamTri của a {0}", a);

            //ThamChieu(ref a);
            //Console.WriteLine("ThamChieu của a {0}", a);

            //int a_out;
            //OutExample(out a_out);
            //Console.WriteLine("OutExample của a {0}", a_out);

            /// ChiaHaiSo(10, 0);

            Console.ReadKey();

            //string myName = Convert.ToString(10);
            //string myName1 = "10";
            //string myName12 = 10 + "";


            //int myNumber = 100000;
            //var variableName = 10;

            //if (myNumber == variableName)
            //{
            //    Console.WriteLine("myNumber bang variableName");
            //}
            //else
            //{
            //    Console.WriteLine("myNumber Khong bang variableName");
            //}

            //var variableName_2 = 10f;

            //var variableName_3 = "day la so 10";

            //Console.WriteLine("Name: {0}-{1}", myName, variableName_3);
            //Console.WriteLine("Number: {0}", myNumber);

            //Console.WriteLine("variableName_2: {0}", variableName_2);

            int myNum = 15;
            myNum = 16;

            //Console.WriteLine("Nhap ngay thang nam sinh cua bạn:");
            //Console.WriteLine("nhap nam:");

            // CTRL+K+ C comment code 
            // CTRL+ K+ U : uncomment code 

            // CTRL+ K+ D : fomat code 

            //Nhập vào bàn phím năm sinh và tính ra số tuổi hiện tại 

            // bước 1: nhập vào bàn phím số năm sinh 

            //Console.WriteLine("Nhap diem toan:");
            //var mathPoint = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Nhap diem ly:");
            //var phyPoint = Convert.ToDouble(Console.ReadLine());
            //Console.WriteLine("Nhap diem toan:");
            //var Point = Convert.ToDouble(Console.ReadLine());
            //var totalPoint = mathPoint + phyPoint + Point;
            //if (mathPoint >= 6.5 && phyPoint > 5.5 && Point > 5.0 && totalPoint > 18)
            //{
            //    Console.WriteLine("CHUC MUNG BAN DAU:");
            //}
            //else
            //{
            //    Console.WriteLine("CHIA BUON BẠN DA ROT:");
            //}

            //var myNumber1 = 0;
            //var myNumber2 = 0;
            //int sum = 0;
            //Console.WriteLine("Nhap số thứ 1 :");
            //myNumber1 = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Nhap số thứ 2:");
            //myNumber2 = Convert.ToInt32(Console.ReadLine());


            //if (myNumber1 <= 0 || myNumber2 <= 0)
            //{
            //    Console.WriteLine("Nhap lại số thứ 1 :");
            //    myNumber1 = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine("Nhap lại số thứ 2:");
            //    myNumber2 = Convert.ToInt32(Console.ReadLine());

            //    Swap(myNumber1, myNumber2);

            //}
            //else
            //{
            //    Swap(myNumber1, myNumber2);

            //}

            //switch (myNumber1)
            //{
            //    case 0:
            //        Console.WriteLine("case 0:");
            //        switch (myNumber2)
            //        {
            //            case 1: break;
            //        }
            //        break;
            //    case 1: Console.WriteLine("case 1:"); break;
            //    case 2: Console.WriteLine("case 2:"); break;
            //    case 3: Console.WriteLine("case 3:"); break;
            //    default: Console.WriteLine("case default:"); break;
            //}

            //int i, n;
            //Console.Write("\n");
            //Console.Write("Hien thi va tinh tong n so le trong C#:\n");
            //Console.Write("------------------------------------------");
            //Console.Write("\n\n");

            //Console.Write("Nhap so cac so: ");
            //n = Convert.ToInt32(Console.ReadLine());
            //Console.Write("\nHien thi cac so le: ");
            //for (i = 1; i <= n; i++)
            //{
            //    Console.Write("{0} ", 2 * i - 1);
            //    sum += 2 * i - 1;
            //}
            //Console.Write("\nTong {0} so le ban dau la: {1} \n", n, sum);

            //Console.ReadKey();

            Console.ReadLine();

            //Console.WriteLine("Number: {0}", myNumber);
        }


    }
}
