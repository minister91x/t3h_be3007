using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    public class QuanlyNhanVien
    {
        public ArrayList arrayListempl = new System.Collections.ArrayList();
        public void Them(NhanVien nhanVien)
        {
            arrayListempl.Add(nhanVien);
        }

        public void Them(int Id, string name, int Age, int saraly)
        {
            var nhanvien = new NhanVien();
            nhanvien.ID = Id;
            nhanvien.Name = name;
            nhanvien.Age = Age;
            nhanvien.Saraly = saraly;

            arrayListempl.Add(nhanvien);
        }

        public int Sua(NhanVien nhanVienMuonSua)
        {
            var checkExist = 0;
            foreach (var item in arrayListempl)
            {
                var empl = (NhanVien)item;
                if (empl.ID == nhanVienMuonSua.ID)
                {
                    checkExist = 1;
                    empl.Name = nhanVienMuonSua.Name;
                    empl.Age = nhanVienMuonSua.Age;
                }
            }

            // return checkExist > 0 ? 1 : 0;

            if (checkExist > 0)
            {
                return 1;
            }
            return 0;
        }


        public void Xoa(NhanVien nhanVien)
        {
            arrayListempl.Remove(nhanVien);
        }

        public void HienThi()
        {
            if (arrayListempl != null && arrayListempl.Count > 0)
            {
                foreach (var item in arrayListempl)
                {
                    var empl = (NhanVien)item;
                    Console.WriteLine("Name ={0}", empl.Name);
                    Console.WriteLine("Salary ={0}", empl.Saraly);
                }
            }
        }

    }
}
