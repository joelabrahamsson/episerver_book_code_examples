using EPiServer.Framework.Localization;
using EPiServer.Validation;
using FruitCorp.Web.Models.Pages;
using System.Collections.Generic;

namespace FruitCorp.Web.Business
{
  public class MetaDescriptionValidator : IValidate<StandardPage>
  {
    public IEnumerable<ValidationError> Validate(StandardPage page)
    {
      if (string.IsNullOrWhiteSpace(page.MetaDescription))
      {
        yield return new ValidationError()
          {
            ErrorMessage = LocalizationService.Current.GetString("/validation/metadescription")
          };
      }
    }
  }
}