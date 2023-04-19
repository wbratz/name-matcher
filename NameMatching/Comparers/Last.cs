﻿namespace NameMatching.Comparers;

public sealed class Last : ComparerBase
{
	public override bool Equals(Name x, Name y)
		=> CompareRequiredNamePart(x.LastName, y.LastName);

	public override bool Contains(Name x, string y)
		=> y.Contains(string.Join(" ", x.LastName));

	public override int GetHashCode(Name obj)
		=> obj switch
		{
			null => 0,
			_ => obj.LastName.Aggregate(0, (hash, lastName) => hash ^ StringComparer.OrdinalIgnoreCase.GetHashCode(lastName.ToLowerInvariant()))
		};
}
