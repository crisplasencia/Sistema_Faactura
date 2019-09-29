using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Facturacion1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            TicketVenta ticket = new TicketVenta();

            ticket.CentrarTexto("SISTEMA ACADEMICO");
            ticket.Textoizquierda("LA PARA DE LAS UNIS ");
            ticket.Textoizquierda("EN EL FIN DEL MUNDO ");
            ticket.Textoizquierda("809 887 9762");
            ticket.Textoizquierda("ASOC");
            ticket.Textoizquierda("cristianjoseplasencia@gmail.com");
            ticket.Textoizquierda("");
            ticket.TextosExtremos("Caja # 1", "Ticket # ");
            ticket.LineasAsteriscos();

            ticket.Textoizquierda("");
            ticket.Textoizquierda("Atendio: Cristian jose Plasencia Santana");
            ticket.Textoizquierda("Cliente: Sin nombre");
            ticket.TextosExtremos("Fecha" + DateTime.Now.ToShortDateString(), "Hora" + DateTime.Now.ToShortTimeString());
            ticket.LineasAsteriscos();

            ticket.TituloDelTicket();
            ticket.Lineasguion();
            //Para añadir nombres, cantidades, precios
            foreach (DataGridViewRow fila in dataLista.Rows)
            {
                ticket.AgregarArticulos(fila.Cells[1].Value.ToString(), int.Parse(fila.Cells[3].Value.ToString()), int.Parse(fila.Cells[2].Value.ToString()), int.Parse(fila.Cells[4].Value.ToString()));
            }
           
            ticket.LineasIgual();

            ticket.Lineasguion();
            ticket.VentaTotal("SUBTOTAL. . . . . . .$", int.Parse(CostoPagar.Text));
            ticket.VentaTotal("IVA . . . . . . . . .$", int.Parse("0"));
            ticket.VentaTotal("TOTAL . . . . . . . .$", int.Parse(CostoPagar.Text));
            ticket.Textoizquierda("");
            ticket.VentaTotal("EFECTIVO . . . . . . $", int.Parse(txtEfectivo.Text));
            ticket.VentaTotal("CAMBIO . . . . . . . $", int.Parse(Devolucion.Text));

            ticket.Textoizquierda(" ");
            ticket.CentrarTexto("********************************");
            ticket.CentrarTexto("");
            ticket.CentrarTexto("   GRACIAS POR SU COMPRA!!!!    ");

            ticket.CentrarTexto("*********************************");
            ticket.Cortaticket();
            //Aqui va el nombre de la impresora 
            ticket.Imprimirticket("Microsoft XPS Document Writer");

            Fila = 0;
            while (dataLista.RowCount > 0)
            {
                dataLista.Rows.Remove(dataLista.CurrentRow);
            }
            txtIdArticulo.Text = txtNombre.Text = txtPrecio.Text = txtCodigo.Text = "";
            CostoPagar.Text = Devolucion.Text = "0.00";
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DateTime.Now.ToShortDateString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        string[,] listaVenta = new string[200, 6];
        int Fila = 0;

        private void BtCargarlista_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdArticulo.Text != ""&& txtNombre.Text != "" && txtPrecio.Text != "" && txtCodigo.Text != "." )
                {
                    listaVenta[Fila, 0] = txtIdArticulo.Text;
                    listaVenta[Fila, 1] = txtNombre.Text;
                    listaVenta[Fila, 2] = txtPrecio.Text;
                    listaVenta[Fila, 3] = txtCodigo.Text;
                    listaVenta[Fila, 4] = (float.Parse(txtPrecio.Text) * float.Parse(txtCodigo.Text)).ToString();

                    dataLista.Rows.Add(listaVenta[Fila, 0], listaVenta[Fila, 1], listaVenta[Fila, 2], listaVenta[Fila, 3], listaVenta[Fila, 4]);

                    Fila++;
                    txtIdArticulo.Text = txtNombre.Text = txtPrecio.Text = txtCodigo.Text = "";

                    txtIdArticulo.Focus();
                }

            }
            catch 
            {
                
                
            }
            CostosPagar();
        }
        public void CostosPagar()
        {
            //Aqui se saca el costo Total de las asignaturas
            float CostoTotal = 0;
            int conteo = 0;

            conteo = dataLista.RowCount;

            for (int i = 0; i < conteo; i++)
            {
                CostoTotal += float.Parse(dataLista.Rows[i].Cells[4].Value.ToString());
            }
            CostoPagar.Text = CostoTotal.ToString();    
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Devolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(CostoPagar.Text)).ToString();
            }
            catch
            {
                Devolucion.Text = "0.00";

            }
        }    
        

        private void CostoPagar_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
