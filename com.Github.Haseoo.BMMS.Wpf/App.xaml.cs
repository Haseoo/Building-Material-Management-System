﻿using AutoMapper;
using com.Github.Haseoo.BMMS.Business.DTOs;
using com.Github.Haseoo.BMMS.Business.Services;
using com.Github.Haseoo.BMMS.Business.Validators;
using com.Github.Haseoo.BMMS.Data;
using com.Github.Haseoo.BMMS.Data.Entities;
using FluentNHibernate.Cfg;
using System;
using System.Windows;

namespace com.Github.Haseoo.BMMS.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            ServiceContext serviceContext;
            var connectingWindow = new ConnectingToDatabaseWindow();
            try
            {
                connectingWindow.Show();
                serviceContext = new ServiceContext(GetMapper());
                SessionManager.Instance.AcquireNewSession();
            }
            catch (FluentConfigurationException e)
            {
                MessageBox.Show(e.GetBaseException().Message, "Database connection error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
            finally
            {
                connectingWindow.Close();
            }
            var validatorContext = new ValidatorContext();
            var application = new App();
            application.InitializeComponent();
            application.Run(new MainWindow(serviceContext, validatorContext));
        }

        private static IMapper GetMapper()
        {
            return new MapperConfiguration(c =>
            {
                c.CreateMap<Material, MaterialDto>().ConstructUsing(s => MaterialDto.From(s));
                c.CreateMap<Company, CompanyDto>().ConvertUsing(s => CompanyDto.From(s));
                c.CreateMap<CompanyContactData, CompanyContactDataDto>()
                    .ConvertUsing(s => CompanyContactDataDto.From(s));
                c.CreateMap<Offer, OfferDto>().ConvertUsing(s => OfferDto.From(s));
                c.CreateMap<OrderList, OrderListFullDto>()
                    .ConvertUsing(s => OrderListFullDto.From(s));
                c.CreateMap<OrderList, OrderListShortDto>()
                    .ConvertUsing(s => OrderListShortDto.From(s));
                c.CreateMap<OrderPosition, OrderPositionDto>()
                    .ConvertUsing(s => OrderPositionDto.From(s));
            }).CreateMapper();
        }
    }
}