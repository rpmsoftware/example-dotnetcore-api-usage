using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2Rpm.Models
{
	public class RpmProcess
	{
		public int ProcessID;
		public RpmForm Form = new RpmForm();
	}
	public class RpmField
	{
		public string Field { get; set; }
		public string Value { get; set; }
	}
	public class RpmForm
	{
		public List<RpmField> Fields = new List<RpmField>();
	}
}
