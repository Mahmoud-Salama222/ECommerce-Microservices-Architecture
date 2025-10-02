using Catalog.Application.Response;
using Catalog.Core.Paganation;
using Catalog.Core.Spec;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetAllProudctQueryWithSpecParams : IRequest<Paganation<ProudctResponseDto>>
    {
        public CatalogSpecParams catalogSpecParams { get; set; }

        public GetAllProudctQueryWithSpecParams(CatalogSpecParams CatalogSpecParams)
        {
            catalogSpecParams = CatalogSpecParams;
        }

    }
}
