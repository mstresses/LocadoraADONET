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
using Entities.ResultSets;

namespace WFPresentationLayer
{
    public partial class FormFilme : Form
    {
        public FormFilme()
        {
            InitializeComponent();
        }

        FilmeService svcF = new FilmeService();
        GeneroService svc = new GeneroService();
        private int idFilmeASerAtualizadoExcluido = 0;
        private void FormFilme_Load(object sender, EventArgs e)
        {
            LocadoraDbContext db = new LocadoraDbContext();
            List<Genero> generos = db.Generos.Where(genero => genero.Nome != null).ToList();
            cmbGeneros.DataSource = db.Generos;
            cmbGeneros.DisplayMember = "Nome";
            cmbGeneros.ValueMember = "ID";
            cmbClassificacao.DataSource = Enum.GetValues(typeof(Classificacao));
            dataGridView1.DataSource = db.Filmes;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            LocadoraDbContext db = new LocadoraDbContext();
            Filme filme = new Filme();
            filme.Duracao = Convert.ToInt32(txtDuracao.Text);
            filme.Classificacao = (Classificacao)cmbClassificacao.SelectedItem;
            filme.Nome = txtNome.Text;
            filme.DataLancamento = dtpLancamento.Value;
            filme.GeneroID = (int)cmbGeneros.SelectedValue;
            Response response = new FilmeService().Insert(filme);
            if (response.Sucesso)
            {
                MessageBox.Show("Filme cadastrado com sucesso.");
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void cmbFIltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFIltro.Text == "Nome")
            {
                cmbPesquisa.Visible = false;
                txtPesquisa.Visible = true;
            }
            else
            {
                if (cmbFIltro.Text == "Gênero")
                {
                    cmbPesquisa.DataSource = null;
                    cmbPesquisa.DataSource = svcF.GetData().Data;//<- Este .Data retorna uma List<Genero>
                    cmbPesquisa.DisplayMember = "Nome";
                    cmbPesquisa.ValueMember = "ID";
                }
                else
                {
                    cmbPesquisa.DataSource = null;
                    cmbPesquisa.DataSource = Enum.GetValues(typeof(Classificacao));
                }
                cmbPesquisa.Visible = true;
                txtPesquisa.Visible = false;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            DataResponse<FilmeResultSet> response = null;

            if (cmbFIltro.Text == "Nome")
            {
                response = svcF.GetFilmesByName(txtPesquisa.Text);
            }
            else if (cmbFIltro.Text == "Gênero")
            {
                response = svcF.GetFilmesByGenero(((Genero)cmbPesquisa.SelectedItem).ID);
            }
            else
            {
                response = svcF.GetFilmesByClassificacao(((Classificacao)cmbPesquisa.SelectedItem));
            }
            if (response.Sucesso)
            {
                if (response.Data.Count == 0)
                {
                    MessageBox.Show("Não foram encontrados dados!");
                }
                else
                {
                    dataGridView1.DataSource = response.Data;
                }
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FilmeResultSet result = (FilmeResultSet)dataGridView1.SelectedRows[0].DataBoundItem;
            DataResponse<Filme> response = svcF.GetByID(result.ID);
            if (response.Sucesso)
            {
                Filme filme = response.Data[0];
                idFilmeASerAtualizadoExcluido = filme.ID;
                txtDuracao.Text = filme.Duracao.ToString();
                txtNome.Text = filme.Nome;
                dtpLancamento.Value = filme.DataLancamento;

                cmbClassificacao.SelectedItem = filme.Classificacao;
                cmbGeneros.SelectedValue = filme.GeneroID;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            filme.Duracao = Convert.ToInt32(txtDuracao.Text);
            filme.Classificacao = (Classificacao)cmbClassificacao.SelectedItem;
            filme.Nome = txtNome.Text;
            filme.DataLancamento = dtpLancamento.Value;
            filme.GeneroID = (int)cmbGeneros.SelectedValue;
            Response response = new FilmeService().Update(filme);
            if (response.Sucesso)
            {
                MessageBox.Show("Filme cadastrado com sucesso.");
            }
            else
            {
                MessageBox.Show(response.GetErrorMessage());
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            Response response = new FilmeService().Delete(filme);
            if (response.Sucesso)
            {
                MessageBox.Show("Excluído com sucesso.");
            }
        }
    }
}