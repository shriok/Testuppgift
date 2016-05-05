﻿using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CompanyServices
    {
        public static List<Company> List()
        {
            List<Company> LComp = new List<Company>();
            LComp.AddRange(CustomMapper.MapTo.Companies(Repository.Repositories.CompanyRepository.List()));
            return LComp;
        }

        public static void Delete(string companyId)
        {
            try
            {
                Repository.Repositories.CompanyRepository.Delete(new Guid(companyId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void Add(Company company)
        {
            Repository.Repositories.CompanyRepository.Add(CustomMapper.MapTo.Company(company));
        }

        public static void Update() { }
    }
}
