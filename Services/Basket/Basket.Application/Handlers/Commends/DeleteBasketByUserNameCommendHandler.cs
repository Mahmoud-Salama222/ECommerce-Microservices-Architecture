using AutoMapper;
using Basket.Application.Commends;
using Basket.Core.Repositries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Handlers.Commends
{
    public class DeleteBasketByUserNameCommendHandler : IRequestHandler<DeleteBasketByUserNameCommend, Unit>
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public DeleteBasketByUserNameCommendHandler(IBasketRepository basketRepository, IMapper _mapper)
        {
            this.basketRepository = basketRepository;
            mapper = _mapper;
        }

        public async Task<Unit> Handle(DeleteBasketByUserNameCommend request, CancellationToken cancellationToken)
        {
            await basketRepository.DeleteBasket(request.UserName);
            return Unit.Value; //indicate that i will reurn any thing
        }
    }
}
