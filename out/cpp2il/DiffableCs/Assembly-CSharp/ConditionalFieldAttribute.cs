//Type is in global namespace

[AttributeUsage(AttributeTargets::Field (256))]
public class ConditionalFieldAttribute : PropertyAttribute
{
	public string PropertyToCheck; //Field offset: 0x10
	public Object[] CompareValues; //Field offset: 0x18
	public bool OrCodition; //Field offset: 0x20

	public ConditionalFieldAttribute(string propertyToCheck, object compareValue = null, bool orCodition = true, Object[] compareValues = null) { }

}

