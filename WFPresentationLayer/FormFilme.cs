using BusinessLogicalLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities.Enums;
using Entities;
using BLL;
using DAO;

namespace WFPresentationLayer
{
    public partial class FormFilme : Form
    {
        public FormFilme()
        {
            InitializeComponent();
        }

        private void FormFilme_Load(object sender, EventArgs e)
        {
            LocadoraDbContext db = new LocadoraDbContext();
            List<Genero> generos = db.Generos.Where(genero => genero.Nome != null).ToList();
            cmbGeneros.DataSource = db.Generos.Where GetData().Data;//<- Este .Data retorna uma List<Genero>
            cmbGeneros.DisplayMember = "Nome";
            cmbGeneros.ValueMember = "ID";
            cmbClassificacao.DataSource = Enum.GetValues(typeof(Classificacao));
            //dataGridView1.DataSource = .GetFilmes().Data;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            filme.Duracao = Convert.ToInt32(txtDuracao.Text);
            filme.Classificacao = (Classificacao)cmbClassificacao.SelectedItem;
            filme.Nome = txtNome.Text;
            filme.DataLancamento = dtpLancamento.Value;
            filme.GeneroID = (int)cmbGeneros.SelectedValue;
            new FilmeService().Insert(filme);
        }

        private void cmbFIltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //FilmeResultSet result = (FilmeResultSet)dataGridView1.SelectedRows[0].DataBoundItem;
            //DataResponse<Filme> response = filmeBLL.GetByID(result.ID);
            //if (response.Sucesso)
            //{
            //    Filme filme = response.Data[0];
            //    idFilmeASerAtualizadoExcluido = filme.ID;
            //    txtDuracao.Text = filme.Duracao.ToString();
            //    txtNome.Text = filme.Nome;
            //    dtpLancamento.Value = filme.DataLancamento;

            //    cmbClassificacao.SelectedItem = filme.Classificacao;
            //    cmbGeneros.SelectedValue = filme.GeneroID;
            //}
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            filme.Duracao = Convert.ToInt32(txtDuracao.Text);
            filme.Classificacao = (Classificacao)cmbClassificacao.SelectedItem;
            filme.Nome = txtNome.Text;
            filme.DataLancamento = dtpLancamento.Value;
            filme.GeneroID = (int)cmbGeneros.SelectedValue;
            new FilmeService().Update(filme);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            new FilmeService().Delete(filme);
        }
    }
}