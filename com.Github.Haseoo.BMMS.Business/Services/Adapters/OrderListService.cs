using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.DTOs.OperationDTOs;
using com.Github.Haseoo.BMMS.Business.Exceptions;
using com.Github.Haseoo.BMMS.Business.Services.Ports;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories.Ports;
using iText.Kernel.Font;
using iText.Layout.Element;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Document = iText.Layout.Document;
using PageSize = iText.Kernel.Geom.PageSize;
using Paragraph = iText.Layout.Element.Paragraph;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;

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

        public void SaveToPdf(Guid listId, string file)
        {
            var order = GetOrderList(listId);
            var baseFont = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\Arial.ttf", BaseFont.CP1250);
            using (var pdfDoc = new PdfDocument(new PdfWriter(file)))
            {
                var doc = new Document(pdfDoc, PageSize.A4.Rotate());
                doc.SetFont(baseFont);
                var header = new Text($"Order list: {order.Name}")
                    .SetFontSize(16);
                doc.Add(new Paragraph(header));
                var table = new Table(9)
                    .UseAllAvailableWidth()
                    .AddCell("No.")
                    .AddCell("Material")
                    .AddCell("Material specs")
                    .AddCell("Company")
                    .AddCell("Unit")
                    .AddCell("Price per unit")
                    .AddCell("Offer comments.")
                    .AddCell("Quantity")
                    .AddCell("Price");
                var totalPrice = 0.0M;
                var index = 1;
                foreach (var orderOrderPosition in order.OrderPositions)
                {
                    table.AddCell(index++.ToString())
                        .AddCell(orderOrderPosition.Offer.Material.Name)
                        .AddCell(orderOrderPosition.Offer.Material.Specification)
                        .AddCell(orderOrderPosition.Offer.Company.Name)
                        .AddCell(orderOrderPosition.Offer.Unit)
                        .AddCell(orderOrderPosition.Offer.UnitPrice
                            .ToString(CultureInfo.CurrentCulture) +
                                 NumberFormatInfo.CurrentInfo.CurrencySymbol)
                        .AddCell(orderOrderPosition.Offer.Comments)
                        .AddCell(orderOrderPosition.Quantity.ToString());
                    var subPrice = orderOrderPosition.Quantity * orderOrderPosition.Offer.UnitPrice;
                    totalPrice += subPrice;
                    table.AddCell(subPrice.ToString(CultureInfo.CurrentCulture) +
                                  NumberFormatInfo.CurrentInfo.CurrencySymbol);
                }
                doc.Add(table);
                var totalPriceText = new Text("Total price: " +
                                              totalPrice.ToString(CultureInfo.CurrentCulture) +
                                              NumberFormatInfo.CurrentInfo.CurrencySymbol)
                    .SetFontSize(16);
                doc.Add(new Paragraph(totalPriceText));
            }
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