using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.ETracker.Domain.Validators
{
    public class CsvFileValidator : AbstractValidator<IFormFile>, ICsvFileValidator
    {
		private IReadOnlyCollection<string> AllowedMimeTypes => new List<string>
	{
		"text/csv",
		"text/plain",
		"application/vnd.ms-excel"
	};

		private IReadOnlyCollection<string> AllowedExtensions => new List<string>
	{
		".CSV",
		".TXT"
	};


		public CsvFileValidator()
		{
			RuleFor(f => f.FileName)
				.Must(fn => ValidateAllowedExtensions(fn))
				.WithMessage($"The uploaded file extension is not allowed. File should be {string.Join(", ", AllowedExtensions)}");


			RuleFor(f => f.ContentType)
				.Must(ct => ValidateAllowedMimeType(ct))
				.WithMessage($"The uploaded file type is not allowed. File should be {string.Join(", ", AllowedExtensions)}");
		}

		private bool ValidateAllowedExtensions(string fileName)
        {
			var extension = Path.GetExtension(fileName);
			return AllowedExtensions.Contains(extension.ToUpperInvariant());
		}

		private bool ValidateAllowedMimeType(string mimeType)
        {
			return AllowedMimeTypes.Contains(mimeType);
		}
	}

    
}
