using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool PermissaoLogin { get; set; }
    }
}
