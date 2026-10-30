namespace Unity.Burst;

public static class BurstCompiler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Attribute, Boolean> <>9__22_0; //Field offset: 0x8
		public static Func<Attribute, Boolean> <>9__29_0; //Field offset: 0x10

		private static <>c() { }

		public <>c() { }

		internal bool <Compile>b__22_0(Attribute s) { }

		internal bool <TriggerUnsafeStaticMethodRecompilation>b__29_0(Attribute x) { }

	}

	[CompilerGenerated]
	private struct <>c__DisplayClass17_0
	{
		public RuntimeMethodHandle managedMethodHandle; //Field offset: 0x0
		public RuntimeTypeHandle delegateTypeHandle; //Field offset: 0x8

	}

	[BurstCompile]
	public static class BurstCompilerHelper
	{
		public static class IsBurstEnabled_00000145$BurstDirectCall
		{
			private static IntPtr Pointer; //Field offset: 0x0
			private static IntPtr DeferredCompilation; //Field offset: 0x8

			private static IsBurstEnabled_00000145$BurstDirectCall() { }

			public static void Constructor() { }

			private static IntPtr GetFunctionPointer() { }

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

			public static void Initialize() { }

			public static bool Invoke() { }

		}

		public sealed class IsBurstEnabled_00000145$PostfixBurstDelegate : MulticastDelegate
		{

			public IsBurstEnabled_00000145$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

			public override IAsyncResult BeginInvoke(AsyncCallback unnamed_param_0, object unnamed_param_1) { }

			public override bool EndInvoke(IAsyncResult unnamed_param_0) { }

			public override bool Invoke() { }

		}

		[UnmanagedFunctionPointer(CallingConvention::Cdecl (2))]
		private sealed class IsBurstEnabledDelegate : MulticastDelegate
		{

			public IsBurstEnabledDelegate(object object, IntPtr method) { }

			public override IAsyncResult BeginInvoke(AsyncCallback callback, object object) { }

			public override bool EndInvoke(IAsyncResult result) { }

			public override bool Invoke() { }

		}

		private static readonly IsBurstEnabledDelegate IsBurstEnabledImpl; //Field offset: 0x0
		public static readonly bool IsBurstGenerated; //Field offset: 0x8

		private static BurstCompilerHelper() { }

		[BurstDiscard]
		private static void DiscardedMethod(ref bool value) { }

		[BurstCompile]
		[MonoPInvokeCallback(typeof(IsBurstEnabledDelegate))]
		private static bool IsBurstEnabled() { }

		[BurstCompile]
		[MonoPInvokeCallback(typeof(IsBurstEnabledDelegate))]
		internal static bool IsBurstEnabled$BurstManaged() { }

		private static bool IsCompiledByBurst(Delegate del) { }

	}

	private class CommandBuilder
	{
		private StringBuilder _builder; //Field offset: 0x10
		private bool _hasArgs; //Field offset: 0x18

		public CommandBuilder() { }

		public CommandBuilder And(char sep = |) { }

		public CommandBuilder Begin(string cmd) { }

		public string SendToCompiler() { }

		public CommandBuilder With(string arg) { }

		public CommandBuilder With(IntPtr arg) { }

	}

	private class FakeDelegate
	{
		[CompilerGenerated]
		private readonly MethodInfo <Method>k__BackingField; //Field offset: 0x10

		[Preserve]
		public MethodInfo Method
		{
			[CompilerGenerated]
			 get { } //Length: 8
		}

		public FakeDelegate(MethodInfo method) { }

		[CompilerGenerated]
		public MethodInfo get_Method() { }

	}

	[AttributeUsage(AttributeTargets::Assembly (1), AllowMultiple = True)]
	public class StaticTypeReinitAttribute : Attribute
	{
		public readonly Type reinitType; //Field offset: 0x10

		public StaticTypeReinitAttribute(Type toReinit) { }

	}

	[ThreadStatic]
	private static CommandBuilder _cmdBuilder; //Field offset: 0x80000000
	internal static bool _IsEnabled; //Field offset: 0x0
	public static readonly BurstCompilerOptions Options; //Field offset: 0x8
	internal static Action OnCompileILPPMethod2; //Field offset: 0x10
	private static readonly MethodInfo DummyMethodInfo; //Field offset: 0x18

	public static bool IsEnabled
	{
		 get { } //Length: 156
	}

	private static BurstCompiler() { }

	[CompilerGenerated]
	internal static void <GetILPPMethodFunctionPointer2>g__GetManagedFallbackDelegate|17_0(out Delegate managedFallbackDelegate, out GCHandle gcHandle, ref <>c__DisplayClass17_0 unnamed_param_2) { }

	internal static string AotCompilation(String[] assemblyFolders, String[] assemblyRoots, string options) { }

	private static CommandBuilder BeginCompilerCommand(string cmd) { }

	internal static void Cancel() { }

	private static Void* Compile(object delegateObj, MethodInfo methodInfo, bool isFunctionPointer, bool isILPostProcessing, bool deterministicCompilation = false) { }

	private static Void* Compile(object delegateObj, bool isFunctionPointer, bool deterministicCompilation = false) { }

	internal static T CompileDelegate(T delegateMethod, bool deterministicCompilation = false) { }

	public static FunctionPointer<T> CompileFunctionPointer(T delegateMethod) { }

	[Obsolete("This method will be removed in a future version of Burst")]
	public static IntPtr CompileILPPMethod(RuntimeMethodHandle burstMethodHandle, RuntimeMethodHandle managedMethodHandle, RuntimeTypeHandle delegateTypeHandle) { }

	public static IntPtr CompileILPPMethod2(RuntimeMethodHandle burstMethodHandle) { }

	[Obsolete("This method will be removed in a future version of Burst")]
	public static Void* CompileUnsafeStaticMethod(RuntimeMethodHandle handle) { }

	internal static void Disable() { }

	private static void DummyMethod() { }

	internal static void Enable() { }

	public static bool get_IsEnabled() { }

	public static BurstExecutionEnvironment GetExecutionMode() { }

	[Obsolete("This method will be removed in a future version of Burst")]
	public static Void* GetILPPMethodFunctionPointer(IntPtr ilppMethod) { }

	public static Void* GetILPPMethodFunctionPointer2(IntPtr ilppMethod, RuntimeMethodHandle managedMethodHandle, RuntimeTypeHandle delegateTypeHandle) { }

	internal static void Initialize(String[] assemblyFolders, String[] ignoreAssemblies) { }

	public static void Initialize$BurstCompilerHelper_IsBurstEnabled_00000145$BurstDirectCall() { }

	internal static bool IsApiAvailable(string apiName) { }

	internal static bool IsCurrentCompilationDone() { }

	internal static bool IsHostEditorArm() { }

	public static bool IsLoadAdditionalLibrarySupported() { }

	internal static void NotifyAssemblyCompilationFinished(string assemblyName, String[] defines) { }

	internal static void NotifyAssemblyCompilationNotRequired(string assemblyName) { }

	internal static void NotifyCompilationFinished() { }

	internal static void NotifyCompilationStarted(String[] assemblyFolders, String[] ignoreAssemblies) { }

	internal static int RequestSetProtocolVersion(int version) { }

	private static string SendCommandToCompiler(string commandName, string commandArgs = null) { }

	private static string SendRawCommandToCompiler(string command) { }

	public static void SetExecutionMode(BurstExecutionEnvironment mode) { }

	internal static void SetProfilerCallbacks() { }

	internal static void Shutdown() { }

	internal static void TriggerRecompilation() { }

	internal static void TriggerUnsafeStaticMethodRecompilation() { }

	internal static void UnloadAdditionalLibraries() { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void VerifyDelegateHasCorrectUnmanagedFunctionPointerAttribute(T delegateMethod) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void VerifyDelegateIsNotMulticast(T delegateMethod) { }

}

