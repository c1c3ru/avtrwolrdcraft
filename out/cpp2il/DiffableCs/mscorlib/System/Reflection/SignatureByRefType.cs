namespace System.Reflection;

internal sealed class SignatureByRefType : SignatureHasElementType
{

	public virtual bool IsSZArray
	{
		 get { } //Length: 8
	}

	public virtual bool IsVariableBoundArray
	{
		 get { } //Length: 8
	}

	protected virtual string Suffix
	{
		 get { } //Length: 64
	}

	internal SignatureByRefType(SignatureType elementType) { }

	public virtual bool get_IsSZArray() { }

	public virtual bool get_IsVariableBoundArray() { }

	protected virtual string get_Suffix() { }

	public virtual int GetArrayRank() { }

	protected virtual bool IsArrayImpl() { }

	protected virtual bool IsByRefImpl() { }

	protected virtual bool IsPointerImpl() { }

}

