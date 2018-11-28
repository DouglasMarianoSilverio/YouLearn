using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api.Controllers.Base
{
    public class ControllerBase : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private IServiceBase _serviceBase;
    }
}
