using EmpleadosApp.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmpleadosApp.Data
{
    public class PuestoDAOImpl : CRUD<Puesto>
    {

        private readonly MySqlConnection conn = Connection.Instance;
        private static readonly PuestoDAOImpl _instance = new();

        private PuestoDAOImpl() { }

        public static PuestoDAOImpl Instance
        {
            get {
                return _instance;
            }
        }

        public void Create(Puesto obj)
        {
            string sql = "INSERT INTO PUESTO(nombre, descripcion) VALUES(@nombre, @descripcion)";

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);

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

        public void Delete(Puesto obj)
        {
            throw new NotImplementedException();
        }

        public Puesto Read(Puesto obj)
        {
            MySqlDataReader reader;
            string sql = "SELECT * FROM PUESTO WHERE id_puesto=" + obj.Id + "";
            Puesto puesto = null;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand comando = new MySqlCommand(sql, conn);
                reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    puesto = new()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                    };
                }
                reader.Close();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return puesto;
        }

        public List<Puesto> ReadAll()
        {
            MySqlDataReader reader;
            List<Puesto> puestos = new();
            string sql = "SELECT * FROM PUESTO";


            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand comando = new(sql, conn);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Puesto puesto = new()
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2)
                    };
                    puestos.Add(puesto);
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return puestos;
        }

        public void Update(Puesto obj)
        {
            string sql = "UPDATE PUESTO SET nombre=@nombre, descripcion=@descripcion WHERE id_puesto=@id";

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                MySqlCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@id", obj.Id);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);

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
