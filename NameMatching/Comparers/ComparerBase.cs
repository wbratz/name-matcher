﻿namespace NameMatching.Comparers;

public abstract class ComparerBase : IEqualityComparer<Name>
{
	protected static bool CompareRequiredString(string x, string y)
		=> string.Equals(x, y, StringComparison.OrdinalIgnoreCase);

	protected static bool CompareRequiredNamePart(IEnumerable<string> x, IEnumerable<string> y)
	{
		if (!x.Any() || !y.Any())
		{
			return false;
		}
		
		var sortedXName = x.OrderBy(name => name).ToList();
		var sortedYName = y.OrderBy(name => name).ToList();
		return sortedXName.SequenceEqual(sortedYName, StringComparer.InvariantCultureIgnoreCase);
	}
	

	protected static bool CompareOptionalString(string x, string y)
		=> ReferenceEquals(x, y)
			|| string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y)
			|| string.Equals(x, y, StringComparison.OrdinalIgnoreCase);

	public abstract bool Equals(Name x, Name y);
	public abstract int GetHashCode(Name obj);
}
