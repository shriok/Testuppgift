using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Models
{
    public class ModelService
    {
        protected bool ValidateCompany(Company companyToValidate)
        {
            if (companyToValidate.Name.Trim().Length == 0)
                _validatonDictionary.AddError("Name", "Name is required.");
            if (companyToValidate.Description.Trim().Length == 0)
                _validatonDictionary.AddError("Description", "Description is required.");
            if (companyToValidate.UnitsInStock < 0)
                _validatonDictionary.AddError("UnitsInStock", "Units in stock cannot be less than zero.");
            return _validatonDictionary.IsValid;
        }
    }
}
