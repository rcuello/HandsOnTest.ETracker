using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.Domain.Validators
{
    public interface ICsvFileValidator : IValidator<IFormFile>
    {
    }
}
