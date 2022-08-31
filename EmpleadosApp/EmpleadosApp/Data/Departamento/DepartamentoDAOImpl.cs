using EmpleadosApp.Model;
using MySql.Data.MySqlClient;

namespace EmpleadosApp.Data
{
    public class DepartamentoDAOImpl : CRUD<Departamento>
    {
        private readonly MySqlConnection conn = Connection.Instance;
        private static readonly DepartamentoDAOImpl _instance = new();

        private DepartamentoDAOImpl()
        {
        }

        public static DepartamentoDAOImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Create(Departamento obj)
        {
            string sql = "INSERT INTO DEPARTAMENTO(nombre, presupuesto, descripcion) VALUES(@nombre, @presupuesto, @descripcion)";
            try
            {
                conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@presupuesto", obj.Presupuesto);
                cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void Delete(Departamento obj)
        {
            throw new NotImplementedException();
        }

        public Departamento Read(Departamento obj)
        {
            MySqlDataReader reader;
            string sql = "SELECT * FROM DEPARTAMENTO WHERE id_departamento=" + obj.Id + "";
            Departamento departamento = null;
            try
            {
                conn.Open();
                MySqlCommand comando = new(sql, conn);
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    departamento = new()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Presupuesto = reader.GetDouble(2),
                        Descripcion = reader.GetString(3)
                    };
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return departamento;
        }

        public List<Departamento> ReadAll()
        {
            MySqlDataReader reader;
            List<Departamento> departamentos = new();
            string sql = "SELECT * FROM DEPARTAMENTO";
            try
            {
                conn.Open();
                MySqlCommand comando = new(sql, conn);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Departamento departamento = new()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Presupuesto = reader.GetDouble(2),
                        Descripcion = reader.GetString(3)
                    };
                    departamentos.Add(departamento);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return departamentos;
        }

        public void Update(Departamento obj)
        {
            string sql = "UPDATE DEPARTAMENTO SET nombre=@nombre, presupuesto=@presupuesto, descripcion=@descripcion WHERE id_departamento=@id_departamento";
            try
            {
                conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@presupuesto", obj.Presupuesto);
                cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@id_departamento", obj.Id);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
