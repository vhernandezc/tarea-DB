using System;
using System.Data;
using tarea2_bd.clases.archivos;
using tarea2_bd.clases.base_de_datos;

namespace tarea2_bd
{
    public partial class frminicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargarArvhivoExterno()
        {
            string fuente = @"C:\Users\alumno\Desktop\tarea 2\tarea2 bd\tarea2 bd\crudDB.csv";
            clsArchivos ar = new clsArchivos();
            clsconexión cn = new clsconexión();

            //obtener todo el archivo en un arreglo
            string[] arreglonotas = ar.LeerArchivo(fuente);
            string sentencia_sql = "";
            int numero_linea = 0;

            //iteramos sobre el arreglo linea por linea prar luego convertirlo en datos individuales
            foreach (string linea in arreglonotas)
            {
                string[] datos = linea.Split(';');
                if (numero_linea > 0)
                {
                    sentencia_sql = $"insert into Tb_alumnos values({datos[0]},'{datos[1]}',{datos[2]},{datos[3]},{datos[4]},{datos[5]},'{datos[6]}');\n";
                }
                numero_linea++;
            }// end foreach

            numero_linea = 0;
            cn.EjecutaSQLDirecto(sentencia_sql);
        }
        protected void cargadatos_Click(object sender, EventArgs e)

        {
            cargarArvhivoExterno();
        }

        protected void BuscarIDE_Click(object sender, EventArgs e)
        {
            string id = TextBoxIDE.Text.Trim();
            clsconexión cn = new clsconexión();
            DataTable dt = new DataTable();
            string sentencia = $"select *from Tb_alumnos where correlativo={id}";
            dt = cn.consultaTablaDirecta(sentencia);
            if (dt.Rows.Count > 0)
            {
                string nombre = dt.Rows[0].Field<string>("nombre");
                TextBoxNOMBRE.Text = nombre;
            }
            else
            {
                TextBoxNOMBRE.Text = "no hay datos";
            }
        }

        protected void Buttonnombre_Click(object sender, EventArgs e)
        {
            string nombre = TextBoxNOMBRE.Text.Trim();
            clsconexión cn = new clsconexión();
            DataTable dt = new DataTable();
            string sentencia = $"select *from Tb_alumnos where nombre like('%{nombre}%')";
            dt = cn.consultaTablaDirecta(sentencia);
            if (dt.Rows.Count > 0)
            {
                int id= dt.Rows[0].Field<Int32>("correlativo");
                TextBoxIDE.Text = id+"";
            }
            else 
            {
                TextBoxNOMBRE.Text = "no hay datos";
            }

        }
    } }

  