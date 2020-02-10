﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGeneroService
    {
        Response Insert(Genero genero);
        Response Update(Genero genero);
        Response Delete(Genero genero);
        Response Validate(Genero genero);
        //DataResponse<Genero> GetData();
    }
}