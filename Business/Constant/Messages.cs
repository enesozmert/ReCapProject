using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
    public static class Messages
    {
        #region CarReg
        /**Car Alanı**/
        public static string CarAdded = "Car added";
        public static string CarAddedInvalid = "Car added invalided";
        public static string CarDeleted = "Car deleted";
        //public static string CarDeletedInvalid = "Car deleted invalided";
        public static string CarUpdated = "Car updated";
        //public static string CarUpdatedInvalid = "Car updated invalided";
        #endregion
        #region UserReg
        /**User Alanı**/
        public static string UserAdded = "User added";
        //public static string UserAddedInvalid = "User added invalided";
        public static string UserDeleted = "User deleted";
        //public static string UserDeletedInvalid = "User deleted invalided";
        public static string UserUpdate = "User updated";
        //public static string UserDeletedInvalid = "User updated invalided";
        #endregion
        #region RentalReg
        /**Rental Alanı**/
        public static string RentalAdd = "Rental added";
        public static string RentalAddInvalid = "Rental added invalided";
        public static string RentalDeletedInvalid = "Rental added invalided";
        public static string RentalDelete = "Rental deleted";
        //public static string RentalDeletedInvalid = "Rental deleted invalided";
        public static string RentalUpdate = "Rental updated";
        public static string RentalUpdatedInvalid = "Rental updated invalided";
        public static string IsForRent = "Rental is it for rent//araba teslim edildi";
        public static string IsForRentInvalid = "Rental is it for rent invalied//araba teslim edilmedi";
        #endregion
        #region BrandReg
        public static string BrandAdded="Brand added";
        public static string BrandDeleted="Brand deleted";
        public static string BrandUpdated="Brand updated";
        #endregion
        #region ColorReg
        public static string ColorAdded = "Color added";
        public static string ColorDeleted = "Color deleted";
        public static string ColorUpdated = "Color updated";
        #endregion
    }
}