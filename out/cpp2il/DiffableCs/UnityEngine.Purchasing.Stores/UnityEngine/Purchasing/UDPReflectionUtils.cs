namespace UnityEngine.Purchasing;

internal class UDPReflectionUtils
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass6_0
	{
		public Assembly assembly; //Field offset: 0x10

		public <>c__DisplayClass6_0() { }

		internal bool <GetTypeByName>b__0(string x) { }

	}

	internal const BindingFlags k_InstanceBindingFlags = 20; //Field offset: 0x0
	internal const BindingFlags k_StaticBindingFlags = 24; //Field offset: 0x0
	internal const BindingFlags k_PrivateStaticBindingFlags = 40; //Field offset: 0x0
	private static readonly Dictionary<Assembly, Type[]> s_assemblyTypeCache; //Field offset: 0x0
	private static readonly Dictionary<String, Type> s_typeCache; //Field offset: 0x8
	private static readonly String[] k_whiteListedAssemblies; //Field offset: 0x10

	private static UDPReflectionUtils() { }

	public UDPReflectionUtils() { }

	private static IEnumerable<Assembly> GetAllAssemblies() { }

	internal static Type GetTypeByName(string typeName) { }

	private static IEnumerable<Type> GetTypes(Assembly assembly) { }

}

