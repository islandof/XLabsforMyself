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
    using Xamarin.Forms.Labs.Services.TinyIOC;

    [TestFixture()]
    public class TinyIocResolveTests : ResolveTests
    {
        protected override IResolver GetEmptyResolver()
        {
            return new TinyResolver(new TinyIoC.TinyIoCContainer());
        }

        protected override IDependencyContainer GetEmptyContainer()
        {
            return new TinyContainer(new TinyIoC.TinyIoCContainer());
        }
    }
}
