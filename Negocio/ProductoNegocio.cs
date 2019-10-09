﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            Producto aux;

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select P.Titulo,P.Descripcion,P.URLImagen from Productos AS P");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Producto();
                    aux.nombre = datos.lector.GetString(0);
                    aux.descripcion = datos.lector.GetString(1);
                    aux.urlImagen = datos.lector.GetString(2);
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

        public List<Producto> buscarProducto(string ID)
        {
            List<Producto> lista = new List<Producto>();
            Producto aux;

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select Id, Titulo, Descripcion, URLImagen from Productos where Id = '" + ID + "'");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    aux = new Producto();
                    aux.id = datos.lector.GetInt64(0);
                    aux.nombre = datos.lector.GetString(1);
                    aux.descripcion = datos.lector.GetString(2);
                    aux.urlImagen = datos.lector.GetString(3);
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


    }
}