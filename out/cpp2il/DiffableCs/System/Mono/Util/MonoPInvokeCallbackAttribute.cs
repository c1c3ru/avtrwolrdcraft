namespace Mono.Util;

[AttributeUsage(AttributeTargets::Method (64))]
[Conditional("MONOTOUCH")]
[Conditional("UNITY")]
[Conditional("FULL_AOT_RUNTIME")]
internal sealed class MonoPInvokeCallbackAttribute : Attribute
{

	public MonoPInvokeCallbackAttribute(Type t) { }

}

