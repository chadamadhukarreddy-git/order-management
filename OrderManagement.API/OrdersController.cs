using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.BusinessContracts;
using OrderManagement.DBEntities.Models;
using OrderManagement.Models;
using OrderManagement.Models.Result;
using OrderManagement.Repositories.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.API
{
    [Route("api/orders")]
    public class OrdersController : Controller
    {
        #region Global Declarations
        private readonly IOrderService _orderService;
        private readonly Result _result;
        #endregion
        public OrdersController(IOrderService orderUnitOfWork)
        {
            _orderService = orderUnitOfWork;
            _result = new Result();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _result.Data = _orderService.GetAll();
                _result.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _result.Message = ex.Message;
                return StatusCode(500, _result);
            }
            return Ok(_result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _result.Data = _orderService.Get(id);
                _result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _result.Message = ex.Message;
                return StatusCode(500, _result);
            }
            return Ok(_result);
        }

        [HttpGet("{id}/products")]
        public IActionResult GetProducts(int id)
        {
            try
            {
                _result.Data = _orderService.GetDetails(id);
                _result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _result.Message = ex.Message;
                return StatusCode(500, _result);
            }
            return Ok(_result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderDTO order)
        {
            try
            {
               var saveResult = _orderService.Create(order);
               return Ok(saveResult);
            }
            catch (Exception ex)
            {
                _result.Message = ex.Message;
                return StatusCode(500, _result);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]OrderDTO order)
        {
            try
            {
                var updateResult = _orderService.Update(order);
                return Ok(updateResult);
            }
            catch (Exception ex)
            {
                _result.Message = ex.Message;
                return StatusCode(500, _result);
            }
        }

        [HttpPut("{id}/order-status")]
        public IActionResult UpdateOrderStatus([FromBody]OrderDTO order)
        {
            try
            {
                var updateResult =  _orderService.UpdateOrderStatus(order);
                Ok(updateResult);
            }
            catch (Exception ex)
            {
                _result.Message = ex.Message;
                return StatusCode(500, _result);
            }
            return Ok(_result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleteResult = _orderService.Delete(id);
                return Ok(deleteResult);
            }
            catch (Exception ex)
            {
                _result.Message = ex.Message;
                return StatusCode(500, _result);
            }
        }
    }
}
