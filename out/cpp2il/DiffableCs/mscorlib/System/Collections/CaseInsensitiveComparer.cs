namespace System.Collections;

public class CaseInsensitiveComparer : IComparer
{
	private CompareInfo _compareInfo; //Field offset: 0x10

	public CaseInsensitiveComparer() { }

	public CaseInsensitiveComparer(CultureInfo culture) { }

	public override int Compare(object a, object b) { }

}

