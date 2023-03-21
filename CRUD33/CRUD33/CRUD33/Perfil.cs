using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD33
{
    public partial class Perfil : Form
    {
       int cedula;
       Conexion acesso = new Conexion();

        public Perfil()
        {
            InitializeComponent();
            txtCedula.Focus();
        }
        private void GridDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cedula = Convert.ToInt32(gridDatos.Rows[e.RowIndex].Cells[0].Value);
            txtNombre.Text = Convert.ToString(gridDatos.Rows[e.RowIndex].Cells[1].Value);
            txtEmail.Text = Convert.ToString(gridDatos.Rows[e.RowIndex].Cells[2].Value);
            txtEdad.Text = Convert.ToString(gridDatos.Rows[e.RowIndex].Cells[3].Value);
        }
        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarMostrar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, no se puede mostrar : " + ex.Message);
            }
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == string.Empty || txtNombre.Text == string.Empty || txtEmail.Text == string.Empty || txtEdad.Text == string.Empty)
            {
                txtCedula.Focus();
                return;
            }
            try
            {
                acesso.InsertarRegistros(Convert.ToInt32(txtCedula.Text), txtNombre.Text, txtEmail.Text, Convert.ToInt32(txtEdad.Text));
                ActualizarMostrar();
                LimpiarTextBox(this);
                Mensage();
                txtCedula.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == string.Empty || txtNombre.Text == string.Empty || txtEmail.Text == string.Empty || txtEdad.Text == string.Empty)
            {
                txtCedula.Focus();
                return;
            }

            try
            {
                acesso.AtualizarRegistro(Convert.ToInt32(txtCedula.Text), txtNombre.Text, txtEmail.Text, Convert.ToInt32(txtEdad.Text));
                ActualizarMostrar();
                LimpiarTextBox(this);
                Mensage();
                txtCedula.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCedula.Text == string.Empty)
            {
                txtCedula.Focus();
                return;
            }

            try
            {
                acesso.BorrarRegistro(int.Parse(txtCedula.Text));
                ActualizarMostrar();
                LimpiarTextBox(this);
                Mensage();
                txtCedula.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no se pudo el registro... : " + ex.Message);
            }
        }
        public void LimpiarTextBox(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.HasChildren)
                {
                    LimpiarTextBox(c);
                }

            }
        }
        private void Mensage()
        {
            MessageBox.Show("Operación realizada exitosamente!!!!!!");
        }

        private void ActualizarMostrar()
        {
            gridDatos.DataSource = acesso.GetRegistros();
        }

        private void GridDatos_MouseClick(object sender, MouseEventArgs e)
        {
            txtCedula.Text = gridDatos.SelectedRows[0].Cells[0].Value.ToString();
            txtNombre.Text = gridDatos.SelectedRows[0].Cells[1].Value.ToString();
            txtEmail.Text = gridDatos.SelectedRows[0].Cells[2].Value.ToString();
            txtEdad.Text = gridDatos.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
