using BLL.Interfaces;
using BusinessLogicalLayer.Security;
using DAO;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
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

        public Response Delete(int id)
        {
            Response response = new Response();
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Funcionario funcASerExcluido = db.Funcionarios.Find(id);
                db.Entry<Funcionario>(funcASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            if (id <= 0)
            {
                response.Erros.Add("ID do cliente não foi informado.");
            }
            else if  (response.Erros.Count != 0)
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

        public DataResponse<Funcionario> GetData()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                DataResponse<Funcionario
                    > response = new DataResponse<Funcionario>();
                try
                {
                    response.Data = db.Funcionarios.ToList();
                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
                    File.WriteAllText("log.txt", ex.Message);
                    response.Sucesso = false;
                    response.Erros.Add("Erro no banco de dados, contate o adm.");
                    return response;
                }
            }
        }

        public DataResponse<Funcionario> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Response Delete(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public DataResponse<Funcionario> Autenticar(string email, string senha)
        {
            senha = HashUtils.HashPassword(senha);
            DataResponse<Funcionario> response = svcfunc.Autenticar(email, senha); //CORRIGIR AMANHÃ//
            if (response.Sucesso)
            {
                User.FuncionarioLogado = response.Data[0];
            }
            return response;
        }
    }
}