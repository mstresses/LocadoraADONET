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
            Response response = new ClienteService().Insert(cliente);
            if (response.Sucesso)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                //dataGridView1.DataSource = bll.GetData().Data;
            }
            else
            {
                MessageBox.Show("Problema no banco de dados, contate o administrador");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ID = idClienteASerAtualizadoExcluido;
            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.CPF = txtCPF.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            Response response = new ClienteService().Update(cliente);
            if (response.Sucesso)
            {
                MessageBox.Show("Atualizado com sucesso.");
            }
            else
            {
                MessageBox.Show("Problema no banco de dados, contate o administrador");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            Response response = new ClienteService().Delete(cliente);
            if (response.Sucesso)
            {
                MessageBox.Show("Excluído com sucesso.");
            }
            else
            {
                MessageBox.Show("Problema com o banco de dados, contate o administrador.");
            }
        }
    }
}