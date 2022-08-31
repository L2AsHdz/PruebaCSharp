using EmpleadosApp.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmpleadosApp.Data
{
    public class HistAumentoDAOImpl : CRUD<HistAumento>
    {
        private readonly MySqlConnection conn = Connection.Instance;
        private static readonly HistAumentoDAOImpl _instance = new();

        private HistAumentoDAOImpl()
        {
        }

        public static HistAumentoDAOImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Create(HistAumento obj)
        {
            string sql = "INSERT INTO HIST_AUMENTO_EMPLEADO(salario_anterior, nuevo_salario, fecha_aumento, cui_empleado) " +
                "VALUES(@salario_anterior, @salario_nuevo, @fecha, @id_empleado)";
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@salario_anterior", obj.SalarioAnterior);
                cmd.Parameters.AddWithValue("@salario_nuevo", obj.SalarioNuevo);
                cmd.Parameters.AddWithValue("@fecha", obj.Fecha);
                cmd.Parameters.AddWithValue("@id_empleado", obj.Empleado.CUI);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public void Delete(HistAumento obj)
        {
            throw new NotImplementedException();
        }

        public HistAumento Read(HistAumento obj)
        {
            throw new NotImplementedException();
        }

        public List<HistAumento> ReadAll()
        {
            throw new NotImplementedException();
        }
        
        public List<HistAumento> ReadAllByCUI(string CUI)
        {
            MySqlDataReader reader;
            string sql = "SELECT h.*, e.cui, e.nombre FROM HIST_AUMENTO_EMPLEADO h INNER JOIN empleado e ON h.cui_empleado = e.cui WHERE h.cui_empleado = " + CUI + "";
            List<HistAumento> lista = new();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new(sql, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HistAumento h = new()
                    {
                        Id = reader.GetInt32(0),
                        SalarioAnterior = reader.GetDouble("salario_anterior"),
                        SalarioNuevo = reader.GetDouble("nuevo_salario"),
                        Fecha = reader.GetString("fecha_aumento"),
                        Empleado = new()
                        {
                            CUI = reader.GetString("cui"),
                            Nombre = reader.GetString("nombre")
                        }
                    };
                    lista.Add(h);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return lista;
        }

        public void Update(HistAumento obj)
        {
            throw new NotImplementedException();
        }
    }
}
