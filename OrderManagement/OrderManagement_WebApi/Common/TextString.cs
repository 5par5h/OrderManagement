using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement_WebApi.Common
{
    public class TextString
    {
        public const string TextOkay = "okay";
        public const string TextFail = "fail";
        public const string UserAdded = "User added successfully";
        public const string UserDeleted = "User deleted successfully";
        public const string FailedToDeleteUser = "There is some problem in deleting user, please try again";
        public const string FailedToAddUser = "There is some prblem in adding new user, please try again";
        public const string UserUpdated = "User updated successfully";
        public const string FailedToUpdateUser = "There is some prblem in updating user, please try again";
    }

    public static class ErrorString
    {
        public const string IncompleteUserDetails = "Please provide all the user information";
        public const string APIError = "Error while executing, please try again";
        public const string FailedToGetProductList = "Failed To Get Proucts";
        public const string FailedToPlaceOrder = "Failed to Placed Order";
    }
}