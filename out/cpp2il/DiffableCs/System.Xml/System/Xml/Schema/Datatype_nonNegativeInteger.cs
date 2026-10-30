namespace System.Xml.Schema;

internal class Datatype_nonNegativeInteger : Datatype_integer
{
	private static readonly FacetsChecker numeric10FacetsChecker; //Field offset: 0x0

	internal virtual FacetsChecker FacetsChecker
	{
		internal get { } //Length: 88
	}

	internal virtual bool HasValueFacets
	{
		internal get { } //Length: 8
	}

	public virtual XmlTypeCode TypeCode
	{
		 get { } //Length: 8
	}

	private static Datatype_nonNegativeInteger() { }

	public Datatype_nonNegativeInteger() { }

	internal virtual FacetsChecker get_FacetsChecker() { }

	internal virtual bool get_HasValueFacets() { }

	public virtual XmlTypeCode get_TypeCode() { }

}

