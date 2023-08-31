using ConsoleAppCSharp.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

        //struct Person
        //{
        //    public int Id;
        //    public string Name;

        //    public Person(int id, string name)
        //    {
        //        this.Id = id;
        //        this.Name = name;
        //    }

        //    public string Speak(string language)
        //    {
        //        return this.Name + " Nói ngôn ngữ :" + language;
        //    }

        //}



        //public struct Product
        //{
        //    public int _number { get; set; }
        //    public int _price { get; set; }
        //    public string _typename { get; set; }

        //    public Product(int number, int price, string typename)
        //    {
        //        this._number = number;
        //        this._price = price;
        //        this._typename = typename;
        //    }

        //    public string Run(int number, string type)
        //    {
        //        if (number == 0 && type != "RON95")
        //        {
        //            return "Stop";
        //        }
        //        _typename = type;

        //        return "Running with :" + _typename;
        //    }
        //}


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
            HeSo1 = 2,
            Heso2 = 3,
            Heso3 = 4,
        }

        struct NGAYTHANG
        {
            public int ngay { get; set; }
            public int thang { get; set; }
            public int nam { get; set; }
        };
        struct SV
        {
            public char masv { get; set; }
            public char hodem { get; set; }
            public char ten { get; set; }
            public NGAYTHANG ngsinh { get; set; }
            public char gioitinh { get; set; }
            public char hokhau { get; set; }
            public float diem { get; set; }
        };


        //struct Product
        //{
        //    public string ProductName { get; set; }
        //    public int ProductPrice { get; set; }
        //    public DateTime ExpiredDate { get; set; }
        //    // Ngày phải không được trống
        //    // phải lớn hơn ngày hiện tại
        //    // Không quá 6 tháng (180 ngày ) so với ngày hiện tại

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expiredDate">truyền vào ngày hết hạn</param>
        /// <returns></returns>
        public static bool CheckValidExpiredDate(DateTime expiredDate)
        {
            // Ngày phải không được trống
            // phải lớn hơn ngày hiện tại
            // Không quá 6 tháng (180 ngày ) so với ngày hiện tại
            if (expiredDate == null)
            {
                return false;
            }

            if (expiredDate < DateTime.Now)
            {
                return false;
            }

            var days = (expiredDate - DateTime.Now).TotalDays;
            if (days > 180)
            {
                return false;
            }

            return true;
        }
        
        public int ProductInsert(string name, int gia, string image, int kichthuoc, int soluong)
        {
            return 1;
        }

        public int Product_Insert(Product product)
        {
            return 1;
        }

        /// <summary>
        /// Hàm này để tính ngày hết hạn
        /// </summary>
        /// <param name="expiredDate">Ngày hết hạn</param>
        /// <param name="a">tham số gì đó chưa biết</param>
        /// <returns></returns>
        public static bool ExpiredDate30Day(DateTime expiredDate, string a)
        {
            if (expiredDate == null)
            {
                return false;
            }

            var days = (expiredDate - DateTime.Now).TotalDays;
            if (days <= 30)
            {
                return true;
            }

            return false;
        }


        static void HoanVi<T>(T a, T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }


        //static T CongHaiSo<T>(T a, T b)
        //{
        //    return a + b
        //}


        static void Main(string[] args)
        {
            
            var listProduct = DbHelper.Product_GetList();

            if(listProduct!=null && listProduct.Count > 0)
            {
                foreach (var item in listProduct)
                {
                    Console.WriteLine(" item id: {0}", item.ProductID);
                    Console.WriteLine(" item ProductName: {0}", item.ProductName);
                    Console.WriteLine(" item Price: {0}", item.Price);
                }
            }

            //var person = new Person();

            //var person1 = (Candidate)person;
            //var person2 = (CandidateJob)person;

            //var candidate = new Candidate();

            // var appexport = new ApplicationExport();
            // appexport.Export();
            // Console.WriteLine(" appexport.Export(): {0}", appexport.Export());


            //var lstBill = new List<BillInfor>();// hóa đơn đơn
            // lstBill.Add(new BillInfor { Price = 1});


            //var listProduct = new List<Product>();

            //listProduct.Add(new Product
            //{
            //    Description = "a",
            //    Name = ""
            //});


            //int a = 10;
            //string noti = string.Empty;
            //var noti1 = "";
            //if (a > 5)
            //{
            //    noti = "ok";
            //}
            //else
            //{
            //    noti = "not ok";
            //}

            //noti = a > 5 ? "ok" : "not ok";

            //var p = new Product();
            //p.Name = "SẢN PHẨM 1";




            //foreach (var item in listProduct)
            //{
            //    Console.WriteLine("productName {0}", item.Name);
            //}

            //var bill = new BillInfor();
            //bill.ProductCode = "IPHONE-X";
            //bill.Quantity = 3;
            //bill.Price = 100000;
            //bill.ProductName = "apple iphone X";
            //bill.TotalAmount = bill.Quantity * bill.Price;

            //lstBill.Add(bill);


            //var bill2 = new BillInfor();
            //bill2.ProductCode = "IPHONE-15";
            //bill2.Quantity = 1;
            //bill2.Price = 300000;
            //bill2.ProductName = "apple iphone 15";
            //bill2.TotalAmount = bill2.Quantity * bill2.Price;

            //lstBill.Add(bill2);


            //double totalPayment = 0;

            //foreach (var item in lstBill)
            //{
            //    totalPayment += item.TotalAmount;
            //}

            //Console.WriteLine("totalPayment: {0}", totalPayment);

            //if (totalPayment >= 500 && totalPayment < 1000000)
            //{
            //    totalPayment = totalPayment - (totalPayment * 0.1);

            //    Console.WriteLine("totalPayment Sale 10% : {0}", totalPayment);
            //}
            //else
            //{

            //    if (totalPayment >= 1000000)
            //    {
            //        totalPayment = totalPayment - (totalPayment * 0.3);
            //    }
            //}

            //Console.WriteLine("totalPayment Sale 30% : {0}", totalPayment);


            //var quanlyNhanVien = new QuanlyNhanVien();

            //var nhanvien = new NhanVien();
            //nhanvien.ID = 1;
            //nhanvien.Name = "MrQuan";

            //quanlyNhanVien.Them(nhanvien);
            //quanlyNhanVien.HienThi();

            //string a = "a";
            //int a1 = 10;

            //var generic = new DemoGeneric<double>(10);
            //generic.genericProperty = 100;

            //generic.genericMethod(10);



            //var generic_str = new DemoGeneric<string>("ABC");

            //generic_str.genericProperty = "Generic";
            //generic_str.genericMethod("demo 123");



            //HoanVi<int>(10, 12);


            //HoanVi<long>(10, 12);

            //HoanVi<float>(10.5f, 12.5f);

            //ArrayList arrList = new ArrayList() { 1, "5", 2.5, true };

            //arrList.Add("bac");

            //foreach (var item in arrList)
            //{
            //    Console.WriteLine("item {0}", item);
            //}


            //var lsst = new List<int>();
            //lsst.Add(1);

            //var lsstObject = new List<Class1>();
            //lsstObject.Add(new Class1 { ID = 1 });

            //string str = "abcdaefd";

            //Product product = new Product();
            //Console.WriteLine("Mời nhập tên sản phẩm");

            //product.ProductName = Console.ReadLine();

            //Console.WriteLine("Mời nhập giá sản phẩm");

            //product.ProductPrice = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Mời nhập ngày hết hạn (dd/mm/yyyy)");

            //var datetime_text = Console.ReadLine();

            //// kiểm tra xem người dùng có nhập đúng định dạng không ?
            //DateTime dateValue;
            //if (!DateTime.TryParseExact(datetime_text, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
            //{
            //    Console.WriteLine("Ngày hết hạn {0}: không phải định dạng ngày tháng", datetime_text);
            //    return;
            //}

            //// kiểm tra xem ngày hết hạn có hợp lệ không
            //var checkValid = CheckValidExpiredDate(dateValue);
            ////if (!checkValid)
            ////    if (checkValid)


            //if (checkValid == false)
            //{
            //    Console.WriteLine("Ngày hết hạn {0}: không phải định dạng ngày tháng", datetime_text);
            //    return;
            //}

            //product.ExpiredDate = dateValue;

            //// kIỂM TRA XEM NGÀY HẾT HẠN ĐÚNG VỚI ĐỀ BÀI KHÔNG
            //var check30days = ExpiredDate30Day(product.ExpiredDate);

            //if (check30days == true)
            //{
            //    Console.WriteLine("Tên sản phẩm {0}", product.ProductName);
            //    Console.WriteLine("giá sản phẩm {0}", product.ProductPrice);
            //    Console.WriteLine("ngày hết hạn sản phẩm {0}", product.ExpiredDate.ToString("dd/MM/yyyy"));
            //}
            //else
            //{
            //    Console.WriteLine("Sản phẩm không hợp lệ với đề bài");
            //}

            //var sinhvien = new SV();
            //var ngaythang = new NGAYTHANG();

            //ngaythang.ngay = 10;
            //ngaythang.nam = 2023;
            //ngaythang.thang = 8;

            //sinhvien.ngsinh = ngaythang;


            //var person = new Person();

            //person.Id = 1;
            //person.Name = "Mr Quân";
            //person.Speak("VietNamese");

            //Console.WriteLine(" personSpeak {0}", person.Speak("VietNamese"));

            //var status = 1;
            //var statusName = "";
            //if (status == 1)
            //{
            //    ///
            //    ///

            //}

            //if (status == (int)HeSoLuong.HeSo1)
            //{
            //    ///
            //    ///

            //}

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

            var dateNow = DateTime.Now;
            var dateNowUTC = DateTime.UtcNow;

            //Console.WriteLine("dateNow: {0}", dateNow.ToString("dd/MM/yyyy HH:mm:ss"));

            //Console.WriteLine("dateNowUTC: {0}", dateNowUTC.ToString("dd/MM/yyyy HH:mm:ss"));

            //var newDate = dateNow.AddDays(-1).ToString("dd/MM/yyyy HH:mm:ss");
            //Console.WriteLine("newDate: {0}", newDate);

            var timeSpan = new TimeSpan(-2, 0, 0);

            var newDatetimeSpan = DateTime.Now.Add(timeSpan);

            //Console.WriteLine("newDatetimeSpan: {0}", newDatetimeSpan);

            //var firstDate = new DateTime(dateNow.Year, dateNow.Month, 1);
            //Console.WriteLine("firstDate: {0}", firstDate);

            //var lastDayOfMonth = DateTime.DaysInMonth(dateNow.Year, 2);
            //Console.WriteLine("lastDayOfMonth: {0}", lastDayOfMonth);

            //// Thời điểm hiện tại.
            //DateTime aDateTime = DateTime.Now;

            //// Thời điểm năm 2000
            //DateTime y2K = new DateTime(2000, 1, 1);

            //// Khoảng thời gian từ năm 2000 tới nay.
            //TimeSpan interval = aDateTime.Subtract(y2K);

            //Console.WriteLine("Interval from Y2K to Now: " + interval);

            //Console.WriteLine("Days: " + interval.Days);
            //Console.WriteLine("Hours: " + interval.Hours);
            //Console.WriteLine("Minutes: " + interval.Minutes);
            //Console.WriteLine("Seconds: " + interval.Seconds);

            //var compare = DateTime.Compare(new DateTime(2023, 08, 15), new DateTime(2023, 8, 14));
            //Console.WriteLine("compare {0}: " + compare);


            //DateTime aDateTime1 = new DateTime(2022, 8, 22, 19, 30, 00);
            //// Các định dạng date-time được hỗ trợ.
            //string[] formattedStrings = aDateTime1.GetDateTimeFormats();

            //foreach (string format in formattedStrings)
            //{
            //    Console.WriteLine(format);
            //}

            /// var datetime_text = "15/05/2023";

            //DateTime dateValue;
            //if (!DateTime.TryParseExact(datetime_text, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))
            //{
            //    Console.WriteLine("datetime_text {0}: không phải định dạng ngày tháng", datetime_text);
            //}
            //else
            //{
            //    Console.WriteLine("datetime_text {0}: là định dạng ngày tháng", datetime_text);
            //}

            //var date = Convert.ToDateTime(datetime_text);
            //Console.WriteLine("date {0}: " + date.ToString("dd/MM/yyyy HH:mm:ss"));

            //var dateNew = DateTime.ParseExact(datetime_text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //Console.WriteLine("dateNew {0}: " + dateNew.ToString("dd/MM/yyyy HH:mm:ss"));



            //Console.WriteLine("chuoi {0}: " + chuoi.Length);
            //var chuoi2 = chuoi.Concat("Thay Quan").ToString();

            //var chuoiReplace = chuoi.Replace("aspnet", "aspnet fullstack");
            //Console.WriteLine("chuoi chuoi {0}: " + chuoi);
            //Console.WriteLine("chuoi chuoiReplace {0}: " + chuoiReplace);

            var chuoi = "day la khoa hoc aspnet net core";
            Console.WriteLine("chuoi {0}: " + chuoi);
            var lstStr = chuoi.Split(' ');

            Console.WriteLine("{0}: ", lstStr);
            foreach (var item in lstStr)
            {
                Console.WriteLine(char.ToUpper(item[0]) + item.Substring(1, item.Length - 1));
            }



            //var subStr = chuoi.Substring(0, chuoi.Length - 1);
            //Console.WriteLine("{0}: ", subStr);


            //var strUpper = chuoi.ToUpper();
            //Console.WriteLine("{0}: ", strUpper);


            //string Value = "MyName";
            //Value = Value + "Is Quan";

            //Console.WriteLine("Value: {0}", Value);

            //StringBuilder MutableValue = new StringBuilder("MyName");
            //MutableValue.Append("Is Quan");

            //Console.WriteLine("MutableValue : {0}", MutableValue);

            //MutableValue.Insert(0, "ASPNET123_");
            //Console.WriteLine("MutableValue Insert: {0}", MutableValue);

            Console.ReadLine();
        }


    }
}
