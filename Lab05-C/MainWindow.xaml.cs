using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab05_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAB1504-14\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=userTecsup;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("InsertarProductos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", int.Parse(txtIdProducto.Text)); // Agregar el parámetro idproducto
                    cmd.Parameters.AddWithValue("@nombreproducto", txtNombreProducto.Text);
                    cmd.Parameters.AddWithValue("@idproveedor", int.Parse(txtIdProveedor.Text));
                    cmd.Parameters.AddWithValue("@idcategoria", int.Parse(txtIdCategoria.Text));
                    cmd.Parameters.AddWithValue("@cantidadporunidad", txtCantidadPorUnidad.Text);
                    cmd.Parameters.AddWithValue("@preciounidad", txtPrecioUnidad.Text);
                    cmd.Parameters.AddWithValue("@unidadesenexistencia", txtUnidadesEnExistencia.Text);
                    cmd.Parameters.AddWithValue("@unidadesenpedido", txtUnidadesEnPedido.Text);
                    cmd.Parameters.AddWithValue("@nivelnuevopedido", txtNivelNuevoPedido.Text);
                    cmd.Parameters.AddWithValue("@suspendido", txtSuspendido.Text);
                    cmd.Parameters.AddWithValue("@categoriaproducto", txtCategoriaProducto.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto ingresado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el Producto: " + ex.Message);
            }
        }
    }
}
