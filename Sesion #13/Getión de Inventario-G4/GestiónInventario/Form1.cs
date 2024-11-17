using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestiónInventario
{
  public partial class Form1 : Form
  {
   //Declaración de la clase
   public class Producto
   {
     public int Codigo {get; set;}
     public string Nombre { get; set; }
     public string Categoria {get; set;}
     public decimal Precio {get; set;}
     public int Stock {get; set;}
    
     //Llamado al constructor de la clase para inicializar los campos
     public Producto(string nombre, int codigo, string categoria, decimal precio, int stock)
     {
       Codigo = codigo;
       Nombre = nombre;
       Categoria = categoria;
       Precio = precio;
       Stock = stock;
     }
   }

   //Creación de la lista de objetos
   List<Producto> productos = new List<Producto>() { };
   
   //Inicializar todos los controles del formulario
   public Form1()
   { 
     InitializeComponent();
     CargarDatosEnGrafico();
     ActualizarMensajeEstado();
   }
   private void MainForm_Load(object sender, EventArgs e)
   {
      ActualizarMensajeEstado();
      CuentaProductosCategoria();
   }
  private void Form1_Load(object sender, EventArgs e) { }
  
  //Agregar datos con botón
  private void btnAgregar_Click(object sender, EventArgs e)
  {
     AgregarProducto();
     ActualizarMensajeEstado();
     CuentaProductosCategoria();
  }
   private void AgregarProducto()
   {
      string nuevoNombre = txtNombre.Text;
      int nuevoCódigo = int.Parse(txtCodigo.Text);
      string nuevaCategoria = cmbCategoría.SelectedItem.ToString();
      decimal nuevoPrecio = decimal.Parse(txtPrecio.Text);
      int nuevoStock = int.Parse(txtStock.Text);

      productos.Add(new Producto(nuevoNombre, nuevoCódigo, nuevaCategoria, nuevoPrecio, nuevoStock));
      ActualizarDataGridView();
      LimpiarCampos();
      CuentaProductosCategoria();
      CargarDatosEnGrafico();
   }
   
   //Actualizar datos del DataGridView   
   private void ActualizarDataGridView()
   {
      dgvProductos.DataSource = null;
      dgvProductos.DataSource = productos;
   }

   //Eliminar datos con botón
   private void btnEliminar_Click(object sender, EventArgs e)
   {
      int i = dgvProductos.CurrentCell.RowIndex;
      productos.RemoveAt(i);
      ActualizarDataGridView();
      ActualizarMensajeEstado();
      CuentaProductosCategoria();
      CargarDatosEnGrafico();
   }

   //Agregar datos con menú
   private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
   {
      AgregarProducto();
   }
   private void salirToolStripMenuItem_Click(object sender, EventArgs e)
   {
      this.Close();
   }

   //Eliminar datos con menú
   private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
   {
      int i = dgvProductos.CurrentCell.RowIndex;
      productos.RemoveAt(i);
      ActualizarDataGridView();
      CuentaProductosCategoria();
   }
   
    //Limpiar contenido de los controles
    private void LimpiarCampos()
    { 
       txtCodigo.Clear();
       txtNombre.Clear();
       cmbCategoría.SelectedIndex = -1;
       txtPrecio.Clear();
       txtStock.Clear();
    }

   //Imprimir datos en la pestaña 1/caja de texto
   private void CuentaProductosCategoria()
   {
      var productosPorCategoria = productos
            .GroupBy(p => p.Categoria)
            .Select(g => new { Categoria = g.Key, Cantidad = g.Count() })
            .ToList();

      string mensaje = "";
      foreach (var categoria in productosPorCategoria)
      {
         mensaje += $"{categoria.Categoria}: {categoria.Cantidad}" + Environment.NewLine;
      }

      txtProductosPorCategoria.Text = mensaje;
   }

   //Crear gráfico en la pestaña 2
   private void chart1_Click(object sender, EventArgs e) {}
   private void CargarDatosEnGrafico()
   {
      chart1.Series.Clear();
      chart1.Titles.Clear();
      chart1.Titles.Add("Cantidad de Productos por Categoría");
      chart1.ChartAreas[0].AxisX.Title = "Categorías";
      chart1.ChartAreas[0].AxisX.Interval = 1;
      chart1.ChartAreas[0].AxisY.Title = "Cantidad";
      chart1.ChartAreas[0].AxisY.Maximum = 5;
      chart1.ChartAreas[0].AxisY.Interval = 1;

      Series serie = new Series("Productos")
      {
         ChartType = SeriesChartType.Column,
         IsValueShownAsLabel = true
      };

      var productosPorCategoria = productos
         .GroupBy(p => p.Categoria)
         .Select(g => new { Categoria = g.Key, Cantidad = g.Count() })
         .ToList();

      foreach (var categoria in productosPorCategoria)
      {
         serie.Points.AddXY(categoria.Categoria, categoria.Cantidad);
      }

      chart1.Series.Add(serie);
      chart1.Invalidate();
   }

   //Imprimir mensaje en la barra de estado
   private void ActualizarMensajeEstado()
   {
      int totalStock = 0;
      foreach (var producto in productos)
      {
         totalStock += producto.Stock;
      }

      toolStripStatusLabel.Text = $"Número de productos en inventario: {totalStock}";
   }
   private void groupBox1_Enter(object sender, EventArgs e) { }
   private void tabPage2_Click(object sender, EventArgs e) { }
   private void toolStripButton2_Click(object sender, EventArgs e) { }
   private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
   private void tstAgregar_Click(object sender, EventArgs e)
   { AgregarProducto(); }
   private void tstActualizar_Click(object sender, EventArgs e)
   { ActualizarDataGridView(); }

 }//Fin de la clase/formulario
}//Fin del espacio de dominio