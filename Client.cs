using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class Client
    {
        public Client(string name, string surname, string cpf, string job)
        {
            this.Name = name;
            this.Surname = surname;
            this.Cpf = cpf;
            this.Job = job;
            this.FullName = $"{this.Name} {this.Surname}";
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public string Job { get; set; }
    }
}
