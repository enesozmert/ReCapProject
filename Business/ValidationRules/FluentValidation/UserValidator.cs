using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(t => t.FirstName).NotNull().WithMessage("boş olmamalı => FirstName");
            RuleFor(t => t.FirstName).Must(FirstNameLengthWithTwo).WithMessage("İlk adın 2 karakterden büyük olmalıdır.=>FirstName");
            RuleFor(t => t.LastName).Must(LastNameLengthWithTwo).WithMessage("İlk adın 2 karakterden büyük olmalıdır.=>LastName");
            RuleFor(t => t.NickName).Must(NickNameLengthWithTwo).WithMessage("İlk adın 2 karakterden büyük olmalıdır.=>NickName");
            RuleFor(t => t.Email).Must(IsEmail).WithMessage("Geçersiz =>Email");
        }

        private bool IsEmail(string arg)
        {
            bool key=false;
            if (arg.IndexOf("@") > -1)
            {
                key= true;
            }
            else if (arg.IndexOf("@") <= -1)
            {
                key= false;
            }
            return key;
        }

        private bool NickNameLengthWithTwo(string arg)
        {
            return arg.Length > 2;
        }

        private bool LastNameLengthWithTwo(string arg)
        {
            return arg.Length > 2;
        }

        private bool FirstNameLengthWithTwo(string arg)
        {
            return arg.Length > 2;
        }
    }
}
