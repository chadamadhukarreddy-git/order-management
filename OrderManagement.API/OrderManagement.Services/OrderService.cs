using AutoMapper;
using OrderManagement.BusinessContracts;
using OrderManagement.DBEntities.Models;
using OrderManagement.Models;
using OrderManagement.Models.Common;
using OrderManagement.Models.Result;
using OrderManagement.Repositories.Contracts;
using OrderManagement.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement.Services
{
    public class OrderService : IOrderService
    {
        #region Global Declarations
        private readonly IOrderUnitOfWork _orderUnitOfWork;
        private readonly IAppCacheService _appCacheService;
        private readonly IMapper _mapper;
        private readonly OrderServiceValidator _orderValidator;
        #endregion

        #region Constructor Logic
        public OrderService(IMapper mapper, IOrderUnitOfWork orderUnitOfWork, IAppCacheService appCacheService)
        {
            _orderUnitOfWork = orderUnitOfWork;
            _mapper = mapper;
            _orderValidator = new OrderServiceValidator(_orderUnitOfWork);
            _appCacheService = appCacheService;
        }
        #endregion

        #region Public Methods
        public IEnumerable<Order> GetAll()
        {
            return _orderUnitOfWork.OrderRepository.GetAll();
        }
        public Order Get(long id)
        {
            return _orderUnitOfWork.OrderRepository.Get(id);
        }

        public IEnumerable<OrderDetail> GetDetails(long orderId)
        {
            return _orderUnitOfWork.OrderDetailRepository.GetOrderDetails(orderId);
        }
        public WriteResult Create(OrderDTO orderDTO)
        {
            var result = new WriteResult
            {
                IsSuccess = true
            };
            try
            {
                #region Validation
                var validationResult = _orderValidator.ValidateCreate(orderDTO);
                if (!validationResult.IsSuccess) return _mapper.Map<WriteResult>(validationResult);
                #endregion

                #region Create Order
                var order = _mapper.Map<Order>(orderDTO);                
                var resultOrder = _orderUnitOfWork.OrderRepository.Create(order);

                #region Reduce Quntity
                orderDTO.OrderDetail.ForEach(a =>
                {
                    if (a.ProductId.HasValue)
                    {
                        _orderUnitOfWork.ProductRepository.ReduceQuntity(a.ProductId.Value, a.Quantity.GetValueOrDefault());
                    }
                });
                #endregion

                #endregion

                #region Save Changes
                _orderUnitOfWork.Save();
                #endregion

                #region Send Alert
                var account = _orderUnitOfWork.AccountRepository.Get(order.AccountId);
                var alertDTO = new OrderComfirmationAlertDTO
                {
                      Email = account.Email
                    , OrderNumber = order.OrderNumber
                    , OrderProducts = _mapper.Map<List<OrderDetailDTO>>(order.OrderDetail.ToList())

                };
                _appCacheService.MailService.SendOrderConfirmation(alertDTO);
                #endregion
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public WriteResult Update(OrderDTO orderDTO)
        {
            var result = new WriteResult
            {
                IsSuccess = true
            };
            try
            {
                var order = _mapper.Map<Order>(orderDTO);
                _orderUnitOfWork.OrderRepository.Update(order);
                _orderUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public WriteResult Delete(long id)
        {
            var result = new WriteResult
            {
                IsSuccess = true
            };
            try
            {
                var order = _orderUnitOfWork.OrderRepository.Get(id);
                if (order.OrderDetail.Any())
                {
                    foreach(var orderProduct in order.OrderDetail)
                    {
                        _orderUnitOfWork.OrderDetailRepository.Delete(orderProduct);
                    }
                }
                _orderUnitOfWork.OrderRepository.Delete(order);
                _orderUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public WriteResult UpdateOrderStatus(OrderDTO orderDTO)
        {
            var result = new WriteResult
            {
                IsSuccess = true
            };
            try
            {
                var order = _mapper.Map<Order>(orderDTO);
                _orderUnitOfWork.OrderRepository.UpdateOrderStatus(order);
                _orderUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
        #endregion
    }
}
