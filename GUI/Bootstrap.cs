using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Data;
using Repository;
using Repository.Interfaces;
using Service;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component = Castle.MicroKernel.Registration.Component;

namespace GUI
{
    public class Bootstrap
    {/// <summary>
    /// Контейнер для работы с конструкторами, чтобы облегчить 
    /// и не реализовывать всё вручную(все наши интерфейсы)
    /// </summary>
    /// <returns></returns>
        public static WindsorContainer BuildContainer()
        {
            WindsorContainer container = new WindsorContainer();
           // Регистрируем БД: Какой объект будет реализован
            container.Register(Component.For<DbContext>().ImplementedBy<QbContext>());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>());

            // Объявление всех "репозиторией" и "сервисов" для работы с ними
            container.Register(Classes.FromAssemblyNamed("Repository").BasedOn(typeof(IRepository<>))
                .WithServiceBase().WithServiceDefaultInterfaces());

            container.Register(Classes.FromAssemblyNamed("Service").BasedOn(typeof(IService))
                .WithServiceBase().WithServiceDefaultInterfaces());
            return container;
        }
    }
}

