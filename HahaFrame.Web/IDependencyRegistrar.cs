using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace HahaFrame.Web
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);

        int Order { get; }
    }
}