using OrderManagement.BusinessContracts;
using OrderManagement.Constants;
using OrderManagement.Models;
using OrderManagement.Models.Result;
using OrderManagement.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Validations
{
    public class OrderServiceValidator
    {
        private readonly IOrderUnitOfWork _orderUnitOfWork;
        public OrderServiceValidator(IOrderUnitOfWork orderUnitOfWork)
        {
            _orderUnitOfWork = orderUnitOfWork;
        }        
        public Result ValidateCreate(OrderDTO orderDTO)
        {
            var result = new Result
            {
                IsSuccess = true
            };
            var errors = new List<string>();
            try
            {
                if (orderDTO.OrderDetail == null || orderDTO.OrderDetail.Count == 0)
                {
                    errors.Add(AppConstants.ORDER_ORDERDETAILS_REQUIRED);
                }
                else
                {
                    foreach (var orderDetail in orderDTO.OrderDetail)
                    {
                        var product = _orderUnitOfWork.ProductRepository.Get(orderDetail.ProductId);
                        if (product == null)
                        {
                            errors.Add(string.Format(AppConstants.ORDER_PRODUCT_NOT_FOUND, orderDetail.ProductId));
                            continue;
                        }

                        if (product.AvailableQuantity < orderDetail.Quantity)
                        {
                            errors.Add(string.Format(AppConstants.ORDER_PRODUCT_QUANTITY_NOT_AVAILABLE, product.ProductName, orderDetail.Quantity, product.AvailableQuantity));
                        }
                    }
                }

                if (errors.Count > 0)
                {
                    result.IsSuccess = false;
                    result.Message = AppConstants.VALIDATION_FAILED_MESSAGE;
                    result.ErrorNo = (int)ApplicationErrorTypes.ValidationError;
                    result.Data = errors;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result ValidateUpdate()
        {
            //todo: code here
            return new Result { IsSuccess = true };
        }
        public Result ValidateDelete()
        {
            //todo: code here
            return new Result { IsSuccess = true };
        }
        public Result ValidateCommon()
        {
            //todo: code here, can have any common validations for all actions...
            return new Result { IsSuccess = true };
        }
    }
}
