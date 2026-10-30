namespace Unity.Burst.CompilerServices;

[AttributeUsage(AttributeTargets::Method (64), AllowMultiple = True)]
public class IgnoreWarningAttribute : Attribute
{

	public IgnoreWarningAttribute(int warning) { }

}

