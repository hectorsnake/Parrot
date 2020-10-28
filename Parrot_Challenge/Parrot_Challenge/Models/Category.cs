using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot_Challenge.Models
{
	public class Category : BaseObject
	{
		public int SortPosition { get; set;}
	}

    public class ComparerCategory : IEqualityComparer<Category>
    {
        public bool Equals(Category x, Category y)
        {
            return x.Uuid == y.Uuid;
        }

        public int GetHashCode(Category obj)
        {
            return obj.Uuid.GetHashCode();
        }
    }
}
