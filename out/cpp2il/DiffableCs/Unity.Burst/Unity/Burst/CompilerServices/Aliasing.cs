namespace Unity.Burst.CompilerServices;

public static class Aliasing
{

	public static void ExpectAliased(Void* a, Void* b) { }

	public static void ExpectAliased(in A a, in B b) { }

	public static void ExpectAliased(Void* a, in B b) { }

	public static void ExpectAliased(in A a, Void* b) { }

	public static void ExpectNotAliased(Void* a, Void* b) { }

	public static void ExpectNotAliased(in A a, in B b) { }

	public static void ExpectNotAliased(Void* a, in B b) { }

	public static void ExpectNotAliased(in A a, Void* b) { }

}

