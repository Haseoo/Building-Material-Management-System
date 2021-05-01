using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.Github.Haseoo.BMMS.Business.Services.Adapters
{
    public class OrderListService : IOrderListService
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly IOrderListRepository _orderListRepository;

        public OrderListService(IMapper mapper,
                                IOfferRepository offerRepository,
                                IOrderListRepository orderListRepository)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _orderListRepository = orderListRepository;
        }

        public OrderListFullDto Add(string operation)
        {
            var orderList = new OrderList()
            {
                Name = operation,
                LastModification = DateTime.Now,
                OrderPositions = new List<OrderPosition>()
            };
            return _mapper.Map<OrderList, OrderListFullDto>(_orderListRepository.Add(orderList));
        }

        public void AddPositionToList(OrderListPositionOperationDto operation)
        {
            var orderList = GetOrderList(operation.OrderListId);
            var offer = GetOffer(operation.OfferId);
            var orderPosition = orderList.OrderPositions
                .FirstOrDefault(position => position.Offer.Id == offer.Id);
            if (orderPosition != null)
            {
                orderPosition.Quantity += operation.Quantity;
            }
            else
            {
                orderPosition = new OrderPosition()
                {
                    Offer = offer,
                    Quantity = operation.Quantity
                };
                orderList.OrderPositions.Add(orderPosition);
            }

            _orderListRepository.Update(orderList);
        }

        public void Delete(Guid id)
        {
            _offerRepository.Remove(GetOrderList(id));
        }

        public OrderListFullDto GetById(Guid id)
        {
            return _mapper.Map<OrderList, OrderListFullDto>(GetOrderList(id));
        }

        public IList<OrderListShortDto> GetList()
        {
            return _mapper.Map<IList<OrderList>, IList<OrderListShortDto>>(_orderListRepository.GetAll().ToList());
        }

        public IList<OrderListShortDto> SearchByName(string partialName)
        {
            return _mapper.Map<IList<OrderList>, IList<OrderListShortDto>>(_orderListRepository.GetAll()
                .Where(list => list.Name.Contains(partialName))
                .ToList());
        }

        public OrderListFullDto Update(Guid id, OrderListUpdateDto operation)
        {
            var list = GetOrderList(id);
            list.Name = operation.Name;
            list.LastModification = DateTime.Now;
            list.OrderPositions.Clear();
            GetOrderPositions(operation.OrderPositions).ForEach(list.OrderPositions.Add);
            return _mapper.Map<OrderList, OrderListFullDto>(_orderListRepository.Update(list));
        }

        private Offer GetOffer(Guid id)
        {
            return _offerRepository.GetById(id) ?? throw new NotFoundException("offer");
        }

        private OrderList GetOrderList(Guid id)
        {
            return _orderListRepository.GetById(id) ?? throw new NotFoundException("order list");
        }

        private List<OrderPosition> GetOrderPositions(IEnumerable<OrderListPositionOperationDto> operations)
        {
            return operations.Select(e => new OrderPosition()
            {
                Offer = GetOffer(e.OfferId),
                Quantity = e.Quantity
            }).ToList();
        }
    }
}