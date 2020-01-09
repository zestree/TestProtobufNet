using System;
using System.IO;
using System.Linq;
using Google.Protobuf.Reflection;
using ProtoBuf;
using UnitTest.Models;
using UnitTestProject.Models;
using Xunit;

namespace UnitTestProject
{
    public class ExtensibleTest
    {
        [Fact]
        public void TestMethod1()
        {
            FileDescriptorSet descriptor;
            using (var descriptorStream = File.OpenRead(GetFilePath("AddressBook.pb")))
            {
                descriptor = Serializer.Deserialize<FileDescriptorSet>(descriptorStream);
            }
            var contactType = descriptor.Files[0].MessageTypes[0];
            var addressBookType = descriptor.Files[0].MessageTypes[1];

            using (var messageStream = File.OpenRead(GetFilePath("AddressBook.bin")))
            {
                var model = Serializer.Deserialize<Base>(messageStream);
                var addr = Extensible.GetValue<AddressBook>(model, 1);
//                Assert.Equal("Luke Skywalker", output.Name);
            }
        }

        private static string GetFilePath(string fileName)
        {
            var domainPath = Environment.CurrentDirectory;
            var pathItems = domainPath.Split(Path.DirectorySeparatorChar);
            var path = string.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - 3));

            return Path.Combine(path, $"protos\\{fileName}");
        }
    }
}
