using MediatR;

namespace Catalog.Application.commends
{
    public class DeleteProudctCommend : IRequest<bool>
    {
        public string Id { get; set; }
        public DeleteProudctCommend(string Id) //to force send Id when send commend
        {
            this.Id = Id;
        }
    }
}
