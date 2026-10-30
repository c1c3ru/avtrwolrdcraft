namespace System.Xml.Schema;

internal class Datatype_positiveInteger : Datatype_nonNegativeInteger
{
	private static readonly FacetsChecker numeric10FacetsChecker; //Field offset: 0x0

	internal virtual FacetsChecker FacetsChecker
	{
		internal get { } //Length: 88
	}

	public virtual XmlTypeCode TypeCode
	{
		 get { } //Length: 8
	}

	private static Datatype_positiveInteger() { }

	public Datatype_positiveInteger() { }

	internal virtual FacetsChecker get_FacetsChecker() { }

	public virtual XmlTypeCode get_TypeCode() { }

}

