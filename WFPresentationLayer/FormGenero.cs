using BLL;
using BusinessLogicalLayer;
using DAO;
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
    public partial class FormGenero : Form
    {
        public FormGenero()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            DataResponse<Genero> response = svc.GetData();
            if (response.Sucesso)
            {
                dataGridView1.DataSource = response.Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        int idGeneroASerAtualizadoExcluido = 0;
        GeneroService svc = new GeneroService();
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Genero genero = new Genero();
            genero.Nome = txtGenero.Text;
            Response response = new GeneroService().Insert(genero);
            if (response.Sucesso)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                dataGridView1.DataSource = svc.GetData().Data;
            }
            else
            {
                MessageBox.Show("Problema no banco de dados, contate o administrador");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Genero genero = new Genero();
            genero.Nome = txtGenero.Text;
            Response response = new GeneroService().Update(genero);
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
            Genero genero = new Genero();
            Response response = new GeneroService().Delete(genero);
            if (response.Sucesso)
            {
                MessageBox.Show("Excluído com sucesso.");
            }
            else
            {
                MessageBox.Show("Problema no banco de dados, contate o administrador");
            }
        }
    }
}