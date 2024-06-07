using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class cuenta_corriente : Form
    {
        int id_usuario;
        int id_cc;
        public cuenta_corriente(int account)
        {
            InitializeComponent();
            numberVta.Text = "";
            id_usuario = account;
            //Muestro los datos de la cuenta 
            var datos = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia().GetCuentaCorriente(account);             
            inputDNI.Text = Convert.ToString(account);
            inputName.Text = Convert.ToString(datos[0].GetType().GetProperty("Name").GetValue(datos[0], null));
            inputEmail.Text = Convert.ToString(datos[0].GetType().GetProperty("Email").GetValue(datos[0], null));
            id_cc = Convert.ToInt32(datos[0].GetType().GetProperty("Id_cc").GetValue(datos[0], null));
            lblSaldo.Text = Convert.ToString(datos[0].GetType().GetProperty("Saldo").GetValue(datos[0], null));
            dataMove.DataSource = Controladora.Venta.Obtener_instancia().ListarVentas(1,id_usuario);

            //Preparo el combo box para que haga las diferentes querys
            comboSelect.Text= "Ventas-retirar";
            comboSelect.Items.Add("Ventas-retirar");
            comboSelect.Items.Add("Ventas-Cuenta Corriente");
            comboSelect.Items.Add("Movimientos");
            comboSelect.Items.Add("Pagos");
        }

        private void bunifuGroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(numberVta.Text != "")
            {
                //Controladora.Venta.Obtener_instancia().pagar(Convert.ToInt32(numberVta.Text));
                MessageBox.Show("Pago efectuado con exito");
                dataMove.DataSource = Controladora.Venta.Obtener_instancia().ListarVentas(comboSelect.SelectedIndex + 1, id_usuario);
            }
        }

        private void dataMove_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            string idVta = (dataMove.Rows[index].Cells[0].Value).ToString();
            numberVta.Text = idVta;
        }

        private void VentaCC_Click(object sender, EventArgs e)
        {
            if (numberVta.Text != "")
            {
                Controladora.Venta.Obtener_instancia().ventaCC(Convert.ToInt32(numberVta.Text),id_usuario);
                MessageBox.Show("Venta en cuenta corriente");
                var datos = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia().GetCuentaCorriente(id_usuario);
                lblSaldo.Text = Convert.ToString(datos[0].GetType().GetProperty("Saldo").GetValue(datos[0], null));
                dataMove.DataSource = Controladora.Venta.Obtener_instancia().ListarVentas(1, id_usuario);
            }
        }

        private void comboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboSelect.SelectedIndex == 2)
            {
                dataMove.DataSource = Controladora.Cuenta_Corriente_Cliente.Obtener_instancia().listarMovimientos(id_cc);
                btnPay.Enabled = false;
                VentaCC.Enabled = false;
            }
            if(comboSelect.SelectedIndex == 1)
            {
                dataMove.DataSource = Controladora.Venta.Obtener_instancia().ListarVentas(comboSelect.SelectedIndex+1, id_usuario);
                btnPay.Enabled = false;
                VentaCC.Enabled = false;
            }
            if (comboSelect.SelectedIndex == 0)
            {
                dataMove.DataSource = Controladora.Venta.Obtener_instancia().ListarVentas(comboSelect.SelectedIndex + 1, id_usuario);
                btnPay.Enabled = true;
                VentaCC.Enabled = true;
            }
            if (comboSelect.SelectedIndex == 3)
            {
                dataMove.DataSource = Controladora.Venta.Obtener_instancia().ListarPagos(id_usuario);
                btnPay.Enabled = false;
                VentaCC.Enabled = false;
            }
        }
    }
}
