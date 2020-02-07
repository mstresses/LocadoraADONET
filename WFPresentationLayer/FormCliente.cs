using BLL;
using BusinessLogicalLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentationLayer
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            //dataGridView1.DataSource = 
        }
        int idClienteASerAtualizadoExcluido = 0;

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            new ClienteService().Insert(cliente);
            MessageBox.Show("Cliente cadastrado com sucesso!");
            //dataGridView1.DataSource = .GetData().Data;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ID = idClienteASerAtualizadoExcluido;
            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.CPF = txtCPF.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            new ClienteService().Update(cliente);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            new ClienteService().Delete(cliente);
        }
    }
}