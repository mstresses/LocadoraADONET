using BLL.Interfaces;
using BusinessLogicalLayer.Security;
using DAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class FuncionarioService : IFuncionarioService
    {
        public Response Insert(Funcionario funcionario)
        {
            Response response = Validate(funcionario);
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Funcionarios.Add(funcionario);
                db.SaveChanges();
            }
            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Update(Funcionario funcionario)
        {
            Response response = Validate(funcionario);
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Funcionario funcASerAtualizado = new Funcionario();
                db.Entry<Funcionario>(funcASerAtualizado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Delete(Funcionario funcionario)
        {
            Response response = new Response();
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Funcionario funcASerExcluido = new Funcionario();
                db.Entry<Funcionario>(funcASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            if (funcionario.ID <= 0)
            {
                response.Erros.Add("ID do cliente não foi informado.");
            }
            if (response.Erros.Count != 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Validate(Funcionario funcionario)
        {
            Response response = new Response();
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                if (string.IsNullOrWhiteSpace(funcionario.Nome))
                {
                    response.Erros.Add("O nome deve ser informado");
                }
                else
                {
                    funcionario.Nome = funcionario.Nome.Trim();
                    funcionario.Nome = Regex.Replace(funcionario.Nome, @"\s+", " ");
                    if (funcionario.Nome.Length < 2 || funcionario.Nome.Length > 50)
                    {
                        response.Erros.Add("O nome deve conter entre 2 e 50 caracteres");
                    }
                }
                if (string.IsNullOrWhiteSpace(funcionario.CPF))
                {
                    response.Erros.Add("O cpf deve ser informado");
                }
                string validacaoSenha = SenhaValidator.ValidateSenha(funcionario.Senha, funcionario.DataNascimento);
                if (validacaoSenha != "")
                {
                    response.Erros.Add(validacaoSenha);
                }
                db.SaveChanges();
                return response;
            }
        }
    }
}