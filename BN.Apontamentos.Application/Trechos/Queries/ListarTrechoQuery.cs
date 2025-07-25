﻿using BN.Apontamentos.Application.Common.Queries;
using BN.Apontamentos.Application.Trechos.Data;

namespace BN.Apontamentos.Application.Trechos.Queries
{
    public class ListarTrechoQuery
        : IQueryRequest<IEnumerable<ListarTrechoResponse>>
    {
        public IEnumerable<int> IdPlanoDeCorte { get; set; }
    }
}
