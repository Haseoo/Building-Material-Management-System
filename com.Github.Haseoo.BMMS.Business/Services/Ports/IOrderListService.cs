using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using System;
using System.Collections.Generic;
using System.IO;

namespace com.Github.Haseoo.BMMS.Business.Services.Ports
{
    public interface IOrderListService : ITransactionalService<string, OrderListFullDto>
    {
        IList<OrderListShortDto> GetList();

        IList<OrderListShortDto> SearchByName(string partialName);

        OrderListFullDto GetById(Guid id);

        OrderListFullDto Update(Guid id, OrderListUpdateDto operation);

        void AddPositionToList(OrderListPositionOperationDto operation);

        void SaveToPdf(Guid listId, string file);
    }
}