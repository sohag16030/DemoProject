using FaceBookApplication.IRepository;
using FaceBookApplication.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaceBookApplication
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IEndUser, EndUser>();
            services.AddTransient<IPost, Post>();
            services.AddTransient<IRegisterLogin, RegisterLogin>();

        }
    }
}
