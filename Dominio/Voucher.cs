using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Voucher
    {
        public Int64 id { get; set; }
        public string codigoVoucher { get; set; }
        public Boolean estado { get; set; }
        public Int64 idCliente { get; set; }
        public Int64 idProducto { get; set; }
        public DateTime fechaRegistro { get; set; }

    }
}
