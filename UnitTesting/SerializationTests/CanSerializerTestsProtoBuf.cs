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

using Xamarin.Forms.Labs.Services.Serialization.ProtoBuf;

namespace SerializationTests
{
    [TestFixture()]
    public class CanSerializerTestsProtoBuf : CanSerializerTests
    {
        protected override Xamarin.Forms.Labs.Services.Serialization.ISerializer Serializer
        {
            get { return new ProtoBufSerializer(); }
        }
    }
}
