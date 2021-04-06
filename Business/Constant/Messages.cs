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
        public static string IsForRent = "This car can be rented";
        public static string IsForRentInvalid = "This car can not be rented";
        #endregion
        #region BrandReg
        public static string BrandAdded = "Brand added";
        public static string BrandDeleted = "Brand deleted";
        public static string BrandUpdated = "Brand updated";
        #endregion
        #region ColorReg
        public static string ColorAdded = "Color added";
        public static string ColorDeleted = "Color deleted";
        public static string ColorUpdated = "Color updated";
        #endregion
        #region CarImage
        public static string CarImageAdded = "CarImage added";
        public static string CarImageDeleted = "CarImage deleted";
        public static string CarImageUpdated = "CarImage updated";
        public static string CarImageLimitExceded = "5 ten fazla araba resminiz olamaz";
        public static string CarImageDateExceded = "Zamanlar eşleşmiyor.";
        public static string CarImagesDeleteExceded = "Resminiz silinmedi";
        public static string CarImagesUpdateExceded = "Resminiz güncellenemedi";
        #endregion
        #region AuthReg
        public static string AuthorizationDenied = "You have no authorization";
        public static string UserRegistered = "Registration Successful";
        public static string UserNotFound = "No user";
        public static string PasswordError = "Password is incorrect";
        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "User registered";
        public static string AccessTokenCreated = "Accestoken oluşturuldu";
        #endregion
        #region CustomerReg
        public static string CustomerAdded = "Customer Added";
        public static string CustomerDeleted = "Customer Deleted";
        public static string CustomerUpdated = "Customer Updated";
        #endregion
        #region CreditCardReg
        public static string CreditCardAdded="Credit Card Added";
        public static string CreditCardDelete= "Credit Card Deleted";
        public static string CreditCardUpdated= "Credit Card Updated";
        #endregion
    }
}