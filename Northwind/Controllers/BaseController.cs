using AutoMapper;
using Northwind.DataLayer;
using Northwind.Models;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    //not instantiated
    public abstract class BaseController : Controller
    {
        //will execute ahead of controllers
        IMapper Mapper;

        protected BaseController()
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<Customer, CustomerEdit>();
            });
            Mapper = config.CreateMapper();


        }
    }
}