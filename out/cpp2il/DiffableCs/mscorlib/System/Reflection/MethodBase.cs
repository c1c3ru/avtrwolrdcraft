namespace System.Reflection;

public abstract class MethodBase : MemberInfo
{

	public abstract MethodAttributes Attributes
	{
		 get { } //Length: 0
	}

	public override CallingConventions CallingConvention
	{
		 get { } //Length: 8
	}

	public override bool ContainsGenericParameters
	{
		 get { } //Length: 8
	}

	public override bool IsAbstract
	{
		 get { } //Length: 32
	}

	public override bool IsConstructor
	{
		 get { } //Length: 164
	}

	public override bool IsGenericMethod
	{
		 get { } //Length: 8
	}

	public override bool IsGenericMethodDefinition
	{
		 get { } //Length: 8
	}

	public override bool IsPublic
	{
		 get { } //Length: 40
	}

	public override bool IsSecurityCritical
	{
		 get { } //Length: 40
	}

	public override bool IsSpecialName
	{
		 get { } //Length: 32
	}

	public override bool IsStatic
	{
		 get { } //Length: 32
	}

	public override bool IsVirtual
	{
		 get { } //Length: 32
	}

	public abstract RuntimeMethodHandle MethodHandle
	{
		 get { } //Length: 0
	}

	protected MethodBase() { }

	internal static string ConstructParameters(Type[] parameterTypes, CallingConventions callingConvention, bool serialization) { }

	public virtual bool Equals(object obj) { }

	internal override string FormatNameAndSig(bool serialization) { }

	public abstract MethodAttributes get_Attributes() { }

	public override CallingConventions get_CallingConvention() { }

	public override bool get_ContainsGenericParameters() { }

	public override bool get_IsAbstract() { }

	public override bool get_IsConstructor() { }

	public override bool get_IsGenericMethod() { }

	public override bool get_IsGenericMethodDefinition() { }

	public override bool get_IsPublic() { }

	public override bool get_IsSecurityCritical() { }

	public override bool get_IsSpecialName() { }

	public override bool get_IsStatic() { }

	public override bool get_IsVirtual() { }

	public abstract RuntimeMethodHandle get_MethodHandle() { }

	public override Type[] GetGenericArguments() { }

	public virtual int GetHashCode() { }

	public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle) { }

	public abstract MethodImplAttributes GetMethodImplementationFlags() { }

	public abstract ParameterInfo[] GetParameters() { }

	internal override int GetParametersCount() { }

	internal override ParameterInfo[] GetParametersInternal() { }

	internal override ParameterInfo[] GetParametersNoCopy() { }

	internal override Type[] GetParameterTypes() { }

	public abstract object Invoke(object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture) { }

	[DebuggerHidden]
	[DebuggerStepThrough]
	public override object Invoke(object obj, Object[] parameters) { }

	public static bool op_Equality(MethodBase left, MethodBase right) { }

	public static bool op_Inequality(MethodBase left, MethodBase right) { }

}

