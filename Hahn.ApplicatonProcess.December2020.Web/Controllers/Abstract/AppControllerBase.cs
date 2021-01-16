
using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Abstract
{
    public class AppControllerBase<T> : ControllerBase where T : AppControllerBase<T>
    {
        private ApplicationContext _DbContext;

        public ApplicationContext DbContext => _DbContext ?? (_DbContext = (ApplicationContext)HttpContext?.RequestServices.GetService(typeof(ApplicationContext)));

        // TODO: Need to get current logged in admin user id
        public int AdminUserID => 1;

    }
}
