using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class Gestionar_ventas : Form
    {

        private static Gestionar_ventas instancia;

        public static Gestionar_ventas Obtener_instancia()
        {
            if (instancia == null)
            {
                instancia = new Gestionar_ventas();
            }

            return instancia;
        }

        public Gestionar_ventas()
        {
            InitializeComponent();
            System.Collections.IList list = Controladora.Venta.Obtener_instancia().ListarVentasCC();
            dataModelcc.DataSource = list;
        }

        private void crear_vta_Click(object sender, EventArgs e)
        {
            Form vt = Ventas.Obtener_instancia();
            vt.Show();
        }
    }
}
