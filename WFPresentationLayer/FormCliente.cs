using BLL;
using BLL.Interfaces;
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
            DataResponse<Cliente> response = svc.GetData();
            if (response.Sucesso)
            {
                dataGridView1.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }
        int idClienteASerAtualizadoExcluido = 0;
        ClienteService svc = new ClienteService()

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente result = (Cliente)dataGridView1.SelectedRows[0].DataBoundItem;
            DataResponse<Cliente> response = svc.GetByID(result.ID);
            if (response.Sucesso)
            {
                Cliente cliente = response.Data[0];
                idClienteASerAtualizadoExcluido = cliente.ID;
                txtNome.Text = cliente.Nome;
                txtCPF.Text = cliente.CPF;
                txtEmail.Text = cliente.Email;
                dtpDataNascimento.Value = cliente.DataNascimento;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = txtNome.Text;
            cliente.CPF = txtCPF.Text;
            cliente.Email = txtEmail.Text;
            cliente.DataNascimento = dtpDataNascimento.Value;
            svc.Insert(cliente);
            Response response = new ClienteService().Insert(cliente);
            if (response.Sucesso)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                dataGridView1.DataSource = bll.GetData().Data;
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
            Response response = svc.Update(cliente);
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
            Response response = svc.Delete(cliente);
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