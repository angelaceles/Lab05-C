using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab05_C
{
    /// <summary>
    /// Lógica de interacción para Listar.xaml
    /// </summary>
    public partial class Listar : Window
    {
        public Listar()
        {
            InitializeComponent();
        }
        public static string connectionString = "Data Source=LAB1504-14\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=userTecsup;Password=123456";
        private static List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Consulta SQL para seleccionar datos
                string query = "SELECT idproducto, nombreProducto, idProveedor, idCategoria, " +
                                      "cantidadPorUnidad, precioUnidad, unidadesEnExistencia, " +
                                      "unidadesEnPedido, nivelNuevoPedido, suspendido, " +
                                      "categoriaProducto FROM Productos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila

                                productos.Add(new Producto
                                {
                                    IdProducto = (int)reader["idproducto"],
                                    NombreProducto = reader["nombreProducto"].ToString(),
                                    IdProveedor = (int)reader["idProveedor"],
                                    IdCategoria = (int)reader["idCategoria"],
                                    CantidadPorUnidad = reader["cantidadPorUnidad"].ToString(),
                                    PrecioUnidad = reader["precioUnidad"].ToString(),
                                    UnidadesEnExistencia = reader["unidadesEnExistencia"].ToString(),
                                    UnidadesEnPedido = reader["unidadesEnPedido"].ToString(),
                                    NivelNuevoPedido = reader["nivelNuevoPedido"].ToString(),
                                    Suspendido = reader["suspendido"].ToString(),
                                    CategoriaProducto = reader["categoriaProducto"].ToString(),
                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();


            }
            return productos;

        }

        private void McDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
