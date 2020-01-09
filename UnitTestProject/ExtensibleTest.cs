using System.IO;
using Google.Protobuf.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtoBuf;

namespace UnitTestProject
{
    [TestClass]
    public class ExtensibleTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileDescriptorSet descriptor;
            using (var descriptorStream = File.OpenRead("protos/AddressBook.pb"))
            {
                descriptor = Serializer.Deserialize<FileDescriptorSet>(descriptorStream);
            }

            using (var messageStream = File.OpenRead("protos/AddressBook.bin"))
            {
//                Assert.Equal("Luke Skywalker", output.Name);
            }
        }
    }
}
