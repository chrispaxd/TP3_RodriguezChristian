using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Text.RegularExpressions;

namespace Negocio
{
    public class ClienteNegocio
    {
      
        public void agregarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearQuery("insert into Clientes (DNI,Nombre,Apellido,Email,Direccion,Ciudad,CodigoPostal)values(@DNI,@Nombre,@Apellido,@Email,@Direccion,@Ciudad,@CodigoPostal)");
                datos.agregarParametro("@DNI", cliente.dni);
                datos.agregarParametro("@Nombre", cliente.nombre);
                datos.agregarParametro("@Apellido", cliente.apellido);
                datos.agregarParametro("@Email", cliente.email);
                datos.agregarParametro("@Direccion", cliente.direccion);
                datos.agregarParametro("@CodigoPostal", cliente.codigoPostal);
                datos.agregarParametro("@Ciudad", cliente.ciudad);
                datos.ejecutarAccion();
            }



            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificarCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update Clientes set Nombre = @Nombre where DNI = @DNI;update Clientes set Apellido = @Apellido where DNI = @DNI;update Clientes set Email = @Email where DNI = @DNI;update Clientes set Direccion = @Direccion where DNI = @DNI;update Clientes set Ciudad = @Ciudad where DNI = @DNI;update Clientes set CodigoPostal = @CodigoPostal where DNI = @DNI;");

                datos.agregarParametro("@DNI", cliente.dni);
                datos.agregarParametro("@Nombre", cliente.nombre);
                datos.agregarParametro("@Apellido", cliente.apellido);
                datos.agregarParametro("@Email", cliente.email);
                datos.agregarParametro("@Direccion", cliente.direccion);
                datos.agregarParametro("@CodigoPostal", cliente.codigoPostal);
                datos.agregarParametro("@Ciudad", cliente.ciudad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Cliente buscarCliente(int dni)
        {
            Cliente cliente;

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select c.dni, c.Nombre, c.Apellido, c.Email, c.Direccion, c.Ciudad, c.CodigoPostal from Clientes as c where c.DNI = " + dni);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    cliente = new Cliente();
                    cliente.dni = datos.lector.GetInt32(0);
                    cliente.nombre = datos.lector.GetString(1);
                    cliente.apellido = datos.lector.GetString(2);
                    cliente.email = datos.lector.GetString(3);
                    cliente.direccion = datos.lector.GetString(4);
                    cliente.ciudad = datos.lector.GetString(5);
                    cliente.codigoPostal = datos.lector.GetString(6);
                    return cliente;
                }
            }
            catch (Exception)
            {


            }
            finally
            {
                datos.cerrarConexion();
            }
            return null;


        }

        public Boolean validarEmail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
