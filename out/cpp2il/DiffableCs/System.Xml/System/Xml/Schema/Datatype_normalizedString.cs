namespace System.Xml.Schema;

internal class Datatype_normalizedString : Datatype_string
{

	internal virtual XmlSchemaWhiteSpace BuiltInWhitespaceFacet
	{
		internal get { } //Length: 8
	}

	internal virtual bool HasValueFacets
	{
		internal get { } //Length: 8
	}

	public virtual XmlTypeCode TypeCode
	{
		 get { } //Length: 8
	}

	public Datatype_normalizedString() { }

	internal virtual XmlSchemaWhiteSpace get_BuiltInWhitespaceFacet() { }

	internal virtual bool get_HasValueFacets() { }

	public virtual XmlTypeCode get_TypeCode() { }

}

