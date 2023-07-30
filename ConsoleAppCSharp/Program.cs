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
        static void Main(string[] args)
        {

            string myName = Convert.ToString(10);
            string myName1 = "10";
            string myName12 = 10 + "";


            int myNumber = 100000;
            var variableName = 10;

            if (myNumber == variableName)
            {
                Console.WriteLine("myNumber bang variableName");
            }
            else
            {
                Console.WriteLine("myNumber Khong bang variableName");
            }


            var variableName_2 = 10f;

            var variableName_3 = "day la so 10";

            Console.WriteLine("Name: {0}-{1}", myName, variableName_3);
            Console.WriteLine("Number: {0}", myNumber);

            Console.WriteLine("variableName_2: {0}", variableName_2);

            const int myNum = 15;
            //myNum = 16;

            //Console.WriteLine("Nhap ngay thang nam sinh cua bạn:");
            //Console.WriteLine("nhap nam:");

            // CTRL+K+ C comment code 
            // CTRL+ K+ U : uncomment code 

            // CTRL+ K+ D : fomat code 

            //Nhập vào bàn phím năm sinh và tính ra số tuổi hiện tại 

            // bước 1: nhập vào bàn phím số năm sinh 

            Console.WriteLine("Nhap diem toan:");
            var mathPoint = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap diem ly:");
            var phyPoint = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap diem toan:");
            var Point = Convert.ToDouble(Console.ReadLine());
            var totalPoint = mathPoint + phyPoint + Point;
            if (mathPoint >= 6.5 && phyPoint > 5.5 && Point > 5.0 && totalPoint > 18)
            {
                Console.WriteLine("CHUC MUNG BAN DAU:");
            }
            else
            {
                Console.WriteLine("CHIA BUON BẠN DA ROT:");
            }



            Console.ReadLine();

            Console.WriteLine("Number: {0}", myNumber);
        }


    }
}
