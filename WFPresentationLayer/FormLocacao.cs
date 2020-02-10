﻿using BLL;
using BusinessLogicalLayer;
using BusinessLogicalLayer.Security;
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
    public partial class FormLocacao : Form
    {
        private Cliente cliente;

        public FormLocacao()
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
        ClienteService svc = new ClienteService();
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnPesquisaCLiente_Click(object sender, EventArgs e)
        {
            FormPesquisaCliente frm = new FormPesquisaCliente();
            frm.ShowDialog();
            //Esta linha só será executada quando o formpesquisacliente for fechado! ^^
            if (frm.ClienteSelecionado != null)
            {
                this.cliente = frm.ClienteSelecionado;
                this.txtClienteID.Text = cliente.ID.ToString();
                this.txtClienteNome.Text = cliente.Nome;
                this.txtClienteCPF.Text = cliente.CPF;
            }
            
    }

        private BindingList<Filme> listFilmesSelecionados = new BindingList<Filme>();

        private void btnPesquisaFilme_Click(object sender, EventArgs e)
        {
            FormPesquisaFIlme frm = new FormPesquisaFIlme();
            this.Hide();
            frm.ShowDialog();
            this.Show();

            if (frm.FilmeSelecionado != null)
            {
                foreach (Filme filme in listFilmesSelecionados)
                {
                    if (filme.ID == frm.FilmeSelecionado.ID)
                    {
                        MessageBox.Show("Este filme já foi selecionado.");
                        return;
                    }
                }
                listFilmesSelecionados.Add(frm.FilmeSelecionado);
            }

            this.dataGridView1.DataSource = listFilmesSelecionados;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Locacao locacao = new Locacao();
            locacao.Cliente = this.cliente;
            locacao.Filmes = listFilmesSelecionados.ToList();
            locacao.FoiPago = chkFoiPago.Checked;
            locacao.Funcionario = User.FuncionarioLogado;
            new LocacaoService().Insert(locacao);
            
            MessageBox.Show("Locação efetuada com sucesso!");
        }
    }
}