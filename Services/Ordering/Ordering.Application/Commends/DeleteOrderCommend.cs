using MediatR;

namespace Discount.Application.commends
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteOrderCommand(int id) //to force send Id when send commend
        {
            this.Id = id;
        }
    }
}
