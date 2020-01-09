using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest.Models
{
	[ProtoContract]
	class AddressBook
    {
		[ProtoMember(1)]
		public List<Contact> contact { get; set; }
	}

	[ProtoContract]
	class Contact
	{
		[ProtoMember(1)]
		public int id { get; set; }
		[ProtoMember(2)]
		public string name { get; set; }
	}
}
