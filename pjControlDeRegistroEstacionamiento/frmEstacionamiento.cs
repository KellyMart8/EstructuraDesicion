namespace pjControlDeRegistroEstacionamiento
{
    public partial class frmEstacionamiento : Form
    {
        String dia;
        public frmEstacionamiento()
        {
            InitializeComponent();
        }

        private void frmEstacionamiento_Load(object sender, EventArgs e)
        {
            //Mostrando la fecha actual
            lblFecha.Text = DateTime.Now.ToShortDateString();

            //Determinar el dia

            DateTime fecha = DateTime.Parse(lblFecha.Text);
            dia = fecha.ToString("dddd");

            double costo = 0;
            switch (dia)
            {
                case "domingo": costo = 2; break;
                case "lunes":
                case "martes":
                case "miercoles":
                case "jueves":
                    costo = 4; break;
                case "viernes":
                case "sabado":
                    costo = 7; break;
            }
            lblCosto.Text = costo.ToString("0.00");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos del formulario
            String placa = txtPlaca.Text;
            double costo = double.Parse(lblCosto.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime horainicio = DateTime.Parse(txtHi.Text);
            DateTime horafin = DateTime.Parse(txtHF.Text);

            //Calcular Hora

            TimeSpan hora = horafin - horainicio;

            //Calcular elimporte
            double importe = costo * (hora.TotalHours);

            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(horainicio.ToString("t"));
            fila.SubItems.Add(horafin.ToString("t"));
            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("C"));
            fila.SubItems.Add(importe.ToString("C"));
            lvRegistro.Items.Add(fila);                //aca se agraga la info
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtHi.Clear();
            txtHF.Clear();  
            txtPlaca.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea salir?",
                                               "Estacionamiento",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Exclamation) ;

            if (r == DialogResult.Yes)
                this.Close();
        }
    }
}