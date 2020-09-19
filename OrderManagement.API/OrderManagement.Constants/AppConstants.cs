using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Constants
{
    public class AppConstants
    {
        #region Business Rules
        public const string VALIDATION_FAILED_MESSAGE = "Validation falid, see the validation errors.";
        public const string ORDER_ORDERDETAILS_REQUIRED = "Order should contain atleast one product";
        public const string ORDER_PRODUCT_NOT_FOUND = "Order has invalid product, product id is {0}";
        public const string ORDER_PRODUCT_QUANTITY_NOT_AVAILABLE = "Requested quantity is not available for the Product {0}, Requested quantity: {2} and Available quantity: {2}";
        #endregion
    }
}
