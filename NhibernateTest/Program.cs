using System;
using System.Collections.Generic;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories;
using NHibernate;

namespace NhibernateTest
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var sessionFactory =
                SessionFactoryBuilder.BuildSessionFactory(true, true);

            var mat = new Material
            {
                Name = "xDDDD",
                Specification = "Spec"
            };

            var cd = new CompanyContactData
            {
                Description = "desc",
                RepresentativeNameAndSurname = "Anna Kopytko",
                EmailAddress = "uhu@o2.pl",
                PhoneNumber = "1234676"
            };

            var cd2 = new CompanyContactData
            {
                Description = "desic",
                RepresentativeNameAndSurname = "Maciej Kopytko",
                EmailAddress = "uheu@wp.pl",
                PhoneNumber = "123467623"
            };

            var comp = new Company
            {
                Address = "adr",
                Name = "xd",
                ContactData = new List<CompanyContactData> { cd, cd2 },
                Voivodeship = "xd",
                City = "xP"
            };
            using (var repositories = new RepositoryContext(sessionFactory))
            {
                using (var transaction = repositories.BeginTransaction())
                {
                    repositories.CompanyRepository.Add(comp);
                    transaction.Commit();
                }

                using (var transaction = repositories.BeginTransaction())
                {
                    comp = repositories.CompanyRepository.GetById(comp.Id);
                    comp.ContactData[0].EmailAddress = "owo@ou.pl";
                    repositories.CompanyRepository.Add(comp);
                    repositories.MaterialRepository.Add(mat);
                    transaction.Commit();
                }

                Console.WriteLine("XD");
            }


            using (var repositories = new RepositoryContext(sessionFactory))
            {
                var off = new Offer
                {
                    Comments = "xD",
                    Company = repositories.CompanyRepository.GetById(comp.Id),
                    LastModification = DateTime.Now,
                    Material = repositories.MaterialRepository.GetById(mat.Id),
                    Unit = "ovo",
                    UnitPrice = 12M
                };
                using (var transaction = repositories.BeginTransaction())
                {
                    repositories.OfferRepository.Add(off);
                    transaction.Commit();
                }
            }

            using (var repositories = new RepositoryContext(sessionFactory))
            {
                foreach (var material in repositories.MaterialRepository.GetAll())
                    Console.WriteLine(material);
            }

            Console.ReadKey();
        }
    }
}