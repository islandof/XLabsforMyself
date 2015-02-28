//#if !__IOS__
using System;
using System.Collections.Generic;
using System.Text;

#if WINDOWS_PHONE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using TestFixture = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestClassAttribute;
using Test = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.TestMethodAttribute;
#else
using NUnit.Framework;
#endif

namespace IocTests
{
    using Xamarin.Forms.Labs.Services;
    using Xamarin.Forms.Labs.Services.Unity;

    [TestFixture()]
    public class UnityResolverTests : ResolveTests
    {

        protected override Xamarin.Forms.Labs.Services.IResolver GetEmptyResolver()
        {
            return GetEmptyContainer().GetResolver();
            //return new UnityResolver(new Microsoft.Practices.Unity.UnityContainer());
        }

        protected override Xamarin.Forms.Labs.Services.IDependencyContainer GetEmptyContainer()
        {
            return new UnityDependencyContainer();
        }
    }
}
//#endif
