namespace System.Xml.Schema;

internal class Datatype_decimal : Datatype_anySimpleType
{
	private static readonly Type atomicValueType; //Field offset: 0x0
	private static readonly Type listValueType; //Field offset: 0x8
	private static readonly FacetsChecker numeric10FacetsChecker; //Field offset: 0x10

	internal virtual XmlSchemaWhiteSpace BuiltInWhitespaceFacet
	{
		internal get { } //Length: 8
	}

	internal virtual FacetsChecker FacetsChecker
	{
		internal get { } //Length: 88
	}

	internal virtual Type ListValueType
	{
		internal get { } //Length: 88
	}

	public virtual XmlTypeCode TypeCode
	{
		 get { } //Length: 8
	}

	internal virtual RestrictionFlags ValidRestrictionFlags
	{
		internal get { } //Length: 8
	}

	public virtual Type ValueType
	{
		 get { } //Length: 88
	}

	private static Datatype_decimal() { }

	public Datatype_decimal() { }

	internal virtual int Compare(object value1, object value2) { }

	internal virtual XmlValueConverter CreateValueConverter(XmlSchemaType schemaType) { }

	internal virtual XmlSchemaWhiteSpace get_BuiltInWhitespaceFacet() { }

	internal virtual FacetsChecker get_FacetsChecker() { }

	internal virtual Type get_ListValueType() { }

	public virtual XmlTypeCode get_TypeCode() { }

	internal virtual RestrictionFlags get_ValidRestrictionFlags() { }

	public virtual Type get_ValueType() { }

	internal virtual Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue) { }

}

