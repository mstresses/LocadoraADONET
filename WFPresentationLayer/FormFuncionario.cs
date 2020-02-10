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
    public partial class FormFuncionario : Form
    {
        public FormFuncionario()
        {
            InitializeComponent();
            //dataGridView1.DataSource = bll.GetData().Data;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }
        int idFuncionarioASerAtualizadoExcluido = 0;
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Funcionario result = (Funcionario)dataGridView1.SelectedRows[0].DataBoundItem;
            ////DataResponse<Funcionario> response = bll.GetByID(result.ID);
            //if (response.Sucesso)
            //{
            //    Funcionario funcionario = response.Data[0];
            //    idFuncionarioASerAtualizadoExcluido = funcionario.ID;
            //    txtNome.Text = funcionario.Nome;
            //    txtEmail.Text = funcionario.Email;
            //    txtCpf.Text = funcionario.CPF;
            //    txtTelefone.Text = funcionario.Telefone;
            //    dtpDataNascimento.Value = funcionario.DataNascimento;
            //}
        }
    }
}