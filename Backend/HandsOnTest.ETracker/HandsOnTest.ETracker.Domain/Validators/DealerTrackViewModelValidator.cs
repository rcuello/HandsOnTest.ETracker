using FluentValidation;
using HandsOnTest.ETracker.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.Domain.Validators
{
    public class DealerTrackViewModelValidator : AbstractValidator<DealerTrackViewModel>
    {
        public DealerTrackViewModelValidator()
        {
            RuleFor(f => f.File).SetValidator(new CsvFileValidator());

        }
    }
}
