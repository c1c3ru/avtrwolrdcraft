namespace System.Xml.Schema;

internal class Datatype_List : Datatype_anySimpleType
{
	private DatatypeImplementation itemType; //Field offset: 0x38
	private int minListSize; //Field offset: 0x40

	internal virtual FacetsChecker FacetsChecker
	{
		internal get { } //Length: 88
	}

	internal virtual Type ListValueType
	{
		internal get { } //Length: 36
	}

	public virtual XmlTokenizedType TokenizedType
	{
		 get { } //Length: 32
	}

	public virtual XmlTypeCode TypeCode
	{
		 get { } //Length: 32
	}

	internal virtual RestrictionFlags ValidRestrictionFlags
	{
		internal get { } //Length: 8
	}

	public virtual Type ValueType
	{
		 get { } //Length: 16
	}

	internal Datatype_List(DatatypeImplementation type, int minListSize) { }

	internal virtual int Compare(object value1, object value2) { }

	internal virtual XmlValueConverter CreateValueConverter(XmlSchemaType schemaType) { }

	internal virtual FacetsChecker get_FacetsChecker() { }

	internal virtual Type get_ListValueType() { }

	public virtual XmlTokenizedType get_TokenizedType() { }

	public virtual XmlTypeCode get_TypeCode() { }

	internal virtual RestrictionFlags get_ValidRestrictionFlags() { }

	public virtual Type get_ValueType() { }

	internal virtual Exception TryParseValue(object value, XmlNameTable nameTable, IXmlNamespaceResolver namespaceResolver, out object typedValue) { }

	internal virtual Exception TryParseValue(string s, XmlNameTable nameTable, IXmlNamespaceResolver nsmgr, out object typedValue) { }

}

