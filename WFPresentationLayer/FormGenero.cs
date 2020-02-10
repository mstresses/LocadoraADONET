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
            dataGridView1.DataSource = bll.GetData().Data;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        int idGeneroASerAtualizadoExcluido = 0;
        GeneroService bll = new GeneroService();
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Genero genero = new Genero();
            genero.Nome = txtGenero.Text;
            new GeneroService().Insert(genero);

            Response response = new GeneroService().Insert(genero);
            if (response.Sucesso)
            {
                MessageBox.Show("Cadastrado com sucesso!");
                //dataGridView1.DataSource = bll.GetData().Data;
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Genero genero = new Genero();
            genero.Nome = txtGenero.Text;
            new GeneroService().Update(genero);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Genero genero = new Genero();
            new GeneroService().Delete(genero);
        }
    }
}