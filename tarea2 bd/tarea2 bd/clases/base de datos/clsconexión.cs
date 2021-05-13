﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace tarea2_bd.clases.base_de_datos
{
    public class clsconexión
    {
        public SqlConnection conexion;

        private String _conexion { get; }



        public clsconexión()

        {



            _conexion = "Data Source=UMG-VM\\SQLEXPRESS;Initial Catalog=DBProgra1 A;Integrated Security=True";



        }


        /// <summary>

        /// Cierra la conexion.

        /// </summary>

        public void cerrarConexionBD()

        {

            conexion.Close();

        }

        /// <summary>

        /// abre la conexion

        /// </summary>

        public void abrirConexion()

        {

            conexion = new SqlConnection(_conexion);

            conexion.Open();

        }


        /// <summary>

        /// metodo que ejecuta una consulta, esta clase maneja la apertura y clausura a la base de datos

        /// </summary>

        /// <param name="sqll"></param>

        /// <returns></returns>

        public DataTable consultaTablaDirecta(String sqll)

        {

            abrirConexion();

            SqlDataReader dr;

            SqlCommand comm = new SqlCommand(sqll, conexion);

            dr = comm.ExecuteReader();



            var dataTable = new DataTable();

            dataTable.Load(dr);

            cerrarConexionBD();

            return dataTable;

        }







        /// <summary>

        /// ejecuta una instrucción de insersion, eliminación y actualización,

        /// esta clase se encarga de manejar las aperturas y clausuras de la conexion.

        /// </summary>

        /// <param name="sqll"></param>

        public void EjecutaSQLDirecto(String sqll)

        {

            abrirConexion();

            try

            {



                SqlCommand comm = new SqlCommand(sqll, conexion);

                comm.ExecuteReader();

            }

            catch (Exception e)

            {

                Console.Write(e.Message);

            }

            finally

            {

                cerrarConexionBD();

            }

        }

        /// <summary>

        /// ejecuta instrucciones SQL, pero el progromador debe manejar la apertura y clausura

        /// de las conexiones.

        /// </summary>

        /// <param name="sqll"></param>

        public void EjecutaSQLManual(String sqll)

        {

            // se abre y cierra la conexino manualmente

            SqlCommand comm = new SqlCommand(sqll, conexion);

            comm.ExecuteReader();

        }
    }//end clase
}