namespace Unity.Burst.CompilerServices;

[AttributeUsage(AttributeTargets::Method (64))]
public class SkipLocalsInitAttribute : Attribute
{

	public SkipLocalsInitAttribute() { }

}

