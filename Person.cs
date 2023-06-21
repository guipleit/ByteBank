using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class Client
    {
        public Client(string name, string cpf, string job)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.Job = job;
        }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Job { get; set; }
    }
}
