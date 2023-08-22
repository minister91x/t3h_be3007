using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp
{
    public class EmployeerManager
    {
        public List<Employeer> employeers { get; set; }
        public ArrayList arrayListempl = new System.Collections.ArrayList();

        public EmployeerManager()
        {
            employeers = new List<Employeer>();
        }

        public int Employeer_Add(Employeer employeer)
        {
            // code here
            employeers.Add(employeer);
            arrayListempl.Add(employeer);
            return 0;
        }

        public int Employeer_Update(Employeer employeerUpdate)
        {
            // code here
            var empl = employeers.FindAll(s => s.Name == employeerUpdate.Name).FirstOrDefault();
            if (empl == null) { return 0; }

            empl.Name = employeerUpdate.Name;

            return 0;
        }
        public int Employeer_Remove(Employeer employeerRemove)
        {
            // code here
            employeers.Remove(employeerRemove);
            return 0;
        }

        public void Employeer_Show()
        {
            Console.WriteLine("--USING ARRAY LIST----");

            if (arrayListempl != null && arrayListempl.Count > 0)
            {
                foreach (var item in arrayListempl)
                {
                    var empl = (Employeer)item;
                    Console.WriteLine("Name ={0}", empl.Name);
                    Console.WriteLine("Salary ={0}", empl.Salary);
                }
            }

            Console.WriteLine("--USING LIST----");
            
            foreach (var item in employeers)
            {
                Console.WriteLine("Name ={0}", item.Name);
                Console.WriteLine("Salary ={0}", item.Salary);
            }

        }

        public List<Employeer> Employeers(string name)
        {
            if(employeers!=null && employeers.Count > 0)
            {
                return employeers.FindAll(s=>s.Name== name);
            }
            return new List<Employeer>();
        }
    }
}
