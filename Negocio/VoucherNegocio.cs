using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class VoucherNegocio
    {
       
        public List<Voucher> buscarVoucher(string voucher)
        {
            List<Voucher> lista = new List<Voucher>();
            Voucher aux;

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select Id, CodigoVoucher, Estado, IdCliente, IdProducto  from Vouchers where Estado = 0 and CodigoVoucher = '" + voucher + "'");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Voucher();
                    aux.id = datos.lector.GetInt64(0);
                    aux.codigoVoucher = datos.lector.GetString(1);
                    aux.estado = datos.lector.GetBoolean(2);
                    if (!Convert.IsDBNull(datos.lector["IdCliente"]))
                    {
                        aux.idCliente = datos.lector.GetInt32(3);
                    }

                    if (!Convert.IsDBNull(datos.lector["IdProducto"]))
                    {
                        aux.idProducto = datos.lector.GetInt32(4);
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datos = null;
            }

        }

        public Voucher validarVoucher(string codigoVoucher)
        {
            Voucher aux = null;
            AccesoDatos datos;
            datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select v.Id,v.CodigoVoucher,v.Estado from Vouchers as v where v.CodigoVoucher = @CodigoVoucher");
                datos.agregarParametro("@CodigoVoucher", codigoVoucher);
                datos.ejecutarLector();
                while (datos.lector.Read())
                {

                    aux = new Voucher();
                    aux.id = datos.lector.GetInt64(0);
                    aux.codigoVoucher = datos.lector.GetString(1);
                    aux.estado = datos.lector.GetBoolean(2);
                }
                return aux;

            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }

        }

        public void cambiarEstadoVoucher(Voucher aux)
        {

            AccesoDatos datos;
            datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update Vouchers set IdProducto = '" + aux.idProducto + "', Vouchers.Estado=1 where Vouchers.Id = '" + aux.id + "'");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

