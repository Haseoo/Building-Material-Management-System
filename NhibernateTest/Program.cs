using System;
using System.Collections.Generic;
using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.Data.Entities;
using com.Github.Haseoo.BMMS.Data.Repositories;
using NHibernate;

namespace NhibernateTest
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var sessionFactory =
                SessionFactoryBuilder.BuildSessionFactory(true, true);
            var mapper = new MapperConfiguration(c =>
            {
                c.CreateMap<Material, MaterialDto>().ConstructUsing(s => MaterialDto.From(s));
            }).CreateMapper();
            var repositories = new RepositoryContext(new SessionWrapper(null));

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
                ContactData = new List<CompanyContactData> {cd, cd2},
                Voivodeship = "xd",
                City = "xP"
            };
            using (var session = sessionFactory.OpenSession())
            {
                session.FlushMode = FlushMode.Always;
                repositories.SetSession(session);
                using (var transaction = session.BeginTransaction())
                {
                    repositories.CompanyRepository.Add(comp);
                    transaction.Commit();
                }

                using (var transaction = session.BeginTransaction())
                {
                    comp = repositories.CompanyRepository.GetById(comp.Id);
                    comp.ContactData[0].EmailAddress = "owo@ou.pl";
                    repositories.CompanyRepository.Add(comp);
                    repositories.MaterialRepository.Add(mat);
                    transaction.Commit();
                }

                Console.WriteLine("XD");

                /*Console.WriteLine(repositories
                    .MaterialRepository
                    .GetById(Guid.Parse("fa57670f-27c6-41ca-8e37-a8f82a65e470")));*/
            }


            using (var session = sessionFactory.OpenSession())
            {
                session.FlushMode = FlushMode.Commit;
                repositories.SetSession(session);
                var off = new Offer
                {
                    Comments = "xD",
                    Company = repositories.CompanyRepository.GetById(comp.Id),
                    LastModification = DateTime.Now,
                    Material = repositories.MaterialRepository.GetById(mat.Id),
                    Unit = "ovo",
                    UnitPrice = 12M
                };
                using (var transaction = session.BeginTransaction())
                {
                    repositories.OfferRepository.Add(off);
                    transaction.Commit();
                }
            }

            using (var session = sessionFactory.OpenSession())
            {
                repositories.SetSession(session);
                foreach (var material in repositories.MaterialRepository.GetAll())
                    Console.WriteLine(material);
            }

            Console.ReadKey();
        }
    }
}