namespace MicroMultiBusiness.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public int Id { get; set; }

        public GetOrderDetailByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
