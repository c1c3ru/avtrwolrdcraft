namespace System.Reflection;

public abstract class TypeInfo : Type, IReflectableType
{
	private const BindingFlags DeclaredOnlyLookup = 62; //Field offset: 0x0

	public override IEnumerable<Type> ImplementedInterfaces
	{
		 get { } //Length: 16
	}

	protected TypeInfo() { }

	public override IEnumerable<Type> get_ImplementedInterfaces() { }

	private override TypeInfo System.Reflection.IReflectableType.GetTypeInfo() { }

}

