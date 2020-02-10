using Entities;
using Entities.Enums;
using Entities.ResultSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFilmeService
    {
        Response Insert(Filme filme);
        Response Update(Filme filme);
        Response Delete(Filme filme);
        Response Validate(Filme filme);
        DataResponse<Filme> GetData();
        DataResponse<Filme> GetByID(int id);
        DataResponse<FilmeResultSet> GetFilmes();
        DataResponse<FilmeResultSet> GetFilmesByName(string nome);
        DataResponse<FilmeResultSet> GetFilmesByGenero(int genero);
        DataResponse<FilmeResultSet> GetFilmesByClassificacao(Classificacao classificacao);
    }
}