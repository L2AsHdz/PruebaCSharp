using EmpleadosApp.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmpleadosApp.Data
{
    public class EmpleadoDAOImpl : CRUD<Empleado>
    {
        private readonly MySqlConnection conn = Connection.Instance;
        private static readonly EmpleadoDAOImpl _instance = new();

        private EmpleadoDAOImpl()
        {
        }

        public static EmpleadoDAOImpl Instance
        {
            get
            {
                return _instance;
            }
        }
        public void Create(Empleado obj)
        {
            string sql = "INSERT INTO EMPLEADO(cui, nombre, apellidos, sueldo, fecha_ingreso, id_puesto, id_departamento) " +
                "VALUES(@cui, @nombre, @apellido, @sueldo, @fecha, @id_puesto, @id_departamento)";
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@cui", obj.CUI);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@sueldo", obj.Sueldo);
                cmd.Parameters.AddWithValue("@fecha", obj.FechaIngreso);
                cmd.Parameters.AddWithValue("@id_puesto", obj.Puesto.Id);
                cmd.Parameters.AddWithValue("@id_departamento", obj.Departamento.Id);
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

        public void Delete(Empleado obj)
        {
            throw new NotImplementedException();
        }

        public Empleado Read(Empleado obj)
        {
            MySqlDataReader reader;
            string sql = "SELECT e.*, p.nombre pnombre, d.nombre dnombre FROM EMPLEADO e INNER JOIN PUESTO p ON e.id_puesto = p.id_puesto " +
                "INNER JOIN DEPARTAMENTO d ON e.id_departamento = d.id_departamento WHERE e.cui = " + obj.CUI + "";
            Empleado empleado = null;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand comando = new(sql, conn);
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    empleado = new()
                    {
                        CUI = reader.GetString("cui"),
                        Nombre = reader.GetString("nombre"),
                        Apellido = reader.GetString("apellidos"),
                        Sueldo = reader.GetDouble("sueldo"),
                        FechaIngreso = reader.GetString("fecha_ingreso"),
                        Puesto = new()
                        {
                            Id = reader.GetInt32("id_puesto"),
                            Nombre = reader.GetString("pnombre")
                        },
                        Departamento = new()
                        {
                            Id = reader.GetInt32("id_departamento"),
                            Nombre = reader.GetString("dnombre")
                        }
                    };
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
            return empleado;
        }

        public List<Empleado> ReadAll()
        {
            MySqlDataReader reader;
            string sql = "SELECT e.*, p.nombre pnombre, d.nombre dnombre FROM EMPLEADO e INNER JOIN PUESTO p ON e.id_puesto = p.id_puesto" +
                " INNER JOIN DEPARTAMENTO d ON e.id_departamento = d.id_departamento WHERE fecha_baja IS NULL";
            List<Empleado> empleados = new();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand comando = new(sql, conn);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    empleados.Add(new()
                    {
                        CUI = reader.GetString("cui"),
                        Nombre = reader.GetString("nombre"),
                        Apellido = reader.GetString("apellidos"),
                        Sueldo = reader.GetDouble("sueldo"),
                        FechaIngreso = reader.GetString("fecha_ingreso"),
                        Puesto = new()
                        {
                            Id = reader.GetInt32("id_puesto"),
                            Nombre = reader.GetString("pnombre")
                        },
                        Departamento = new()
                        {
                            Id = reader.GetInt32("id_departamento"),
                            Nombre = reader.GetString("dnombre")
                        }
                    });
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
            return empleados;
        }

        public List<Empleado> ReadAllBajas()
        {
            MySqlDataReader reader;
            string sql = "SELECT e.*, p.nombre pnombre, d.nombre dnombre FROM EMPLEADO e INNER JOIN PUESTO p ON e.id_puesto = p.id_puesto" +
                " INNER JOIN DEPARTAMENTO d ON e.id_departamento = d.id_departamento WHERE fecha_baja IS NOT NULL";
            List<Empleado> empleados = new();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand comando = new(sql, conn);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    empleados.Add(new()
                    {
                        CUI = reader.GetString("cui"),
                        Nombre = reader.GetString("nombre"),
                        Apellido = reader.GetString("apellidos"),
                        Sueldo = reader.GetDouble("sueldo"),
                        FechaIngreso = reader.GetString("fecha_ingreso"),
                        FechaBaja = reader.GetString("fecha_baja"),
                        Puesto = new()
                        {
                            Id = reader.GetInt32("id_puesto"),
                            Nombre = reader.GetString("pnombre")
                        },
                        Departamento = new()
                        {
                            Id = reader.GetInt32("id_departamento"),
                            Nombre = reader.GetString("dnombre")
                        }
                    });
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
            return empleados;
        }

        public void Update(Empleado obj)
        {
            string sql = "UPDATE EMPLEADO SET nombre=@nombre, apellidos=@apellido, sueldo=@sueldo, fecha_ingreso=@fecha, " +
                "id_puesto=@id_puesto, id_departamento=@id_departamento WHERE cui=@cui";
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@cui", obj.CUI);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@sueldo", obj.Sueldo);
                cmd.Parameters.AddWithValue("@fecha", obj.FechaIngreso);
                cmd.Parameters.AddWithValue("@id_puesto", obj.Puesto.Id);
                cmd.Parameters.AddWithValue("@id_departamento", obj.Departamento.Id);
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

        public void UpdateBaja(Empleado obj)
        {
            string sql = "UPDATE EMPLEADO SET fecha_baja=@fecha WHERE cui=@cui";
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@cui", obj.CUI);
                cmd.Parameters.AddWithValue("@fecha", obj.FechaBaja);
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

        public void UpdateSueldo(Empleado obj)
        {
            string sql = "UPDATE EMPLEADO SET sueldo=@sueldo WHERE cui=@cui";
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@cui", obj.CUI);
                cmd.Parameters.AddWithValue("@sueldo", obj.Sueldo);
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
    }
}