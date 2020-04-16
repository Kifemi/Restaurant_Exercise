using System;
using System.Collections.Generic;
using System.Text;

namespace MenuManagerLibrary.Models
{
    public class Allergen
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public Allergen(string name)
		{
			this.Name = name;
		}

	}
}
