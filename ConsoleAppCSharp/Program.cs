using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    internal class Program
    {
        public static int a = 0;

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

        static void Main(string[] args)
        {

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

            var myNumber1 = 0;
            var myNumber2 = 0;
            int sum = 0;
            Console.WriteLine("Nhap số thứ 1 :");
            myNumber1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nhap số thứ 2:");
            myNumber2 = Convert.ToInt32(Console.ReadLine());


            if (myNumber1 <= 0 || myNumber2 <= 0)
            {
                Console.WriteLine("Nhap lại số thứ 1 :");
                myNumber1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Nhap lại số thứ 2:");
                myNumber2 = Convert.ToInt32(Console.ReadLine());

                Swap(myNumber1, myNumber2);

            }
            else
            {
                Swap(myNumber1, myNumber2);

            }

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

            int i, n;
            Console.Write("\n");
            Console.Write("Hien thi va tinh tong n so le trong C#:\n");
            Console.Write("------------------------------------------");
            Console.Write("\n\n");

            Console.Write("Nhap so cac so: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nHien thi cac so le: ");
            for (i = 1; i <= n; i++)
            {
                Console.Write("{0} ", 2 * i - 1);
                sum += 2 * i - 1;
            }
            Console.Write("\nTong {0} so le ban dau la: {1} \n", n, sum);

            Console.ReadKey();

            Console.ReadLine();

            //Console.WriteLine("Number: {0}", myNumber);
        }




    }
}
