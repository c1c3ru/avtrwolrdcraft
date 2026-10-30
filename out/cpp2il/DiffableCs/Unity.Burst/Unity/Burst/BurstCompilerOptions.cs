namespace Unity.Burst;

public sealed class BurstCompilerOptions
{
	private const string DisableCompilationArg = "--burst-disable-compilation"; //Field offset: 0x0
	internal const string OptionSaveExtraContext = "save-extra-context"; //Field offset: 0x0
	internal const string OptionDiscardAssemblies = "discard-assemblies="; //Field offset: 0x0
	internal const string OptionTargetFramework = "target-framework="; //Field offset: 0x0
	internal const string OptionCompilationId = "compilation-id="; //Field offset: 0x0
	internal const string OptionLibraryOutputMode = "library-output-mode="; //Field offset: 0x0
	internal const string OptionSafetyChecks = "safety-checks"; //Field offset: 0x0
	internal const string OptionAotPdbSearchPaths = "pdb-search-paths="; //Field offset: 0x0
	internal const string OptionAlwaysCreateOutput = "always-create-output="; //Field offset: 0x0
	internal const string OptionOutputMode = "output-mode="; //Field offset: 0x0
	internal const string OptionPrintLogOnMissingPInvokeCallbackAttribute = "print-monopinvokecallbackmissing-message"; //Field offset: 0x0
	internal const string OptionChunkSize = "chunk-size="; //Field offset: 0x0
	internal const string CompilerCommandShutdown = "$shutdown"; //Field offset: 0x0
	internal const string OptionCompilerThreads = "threads="; //Field offset: 0x0
	internal const string OptionVerbose = "verbose"; //Field offset: 0x0
	internal const string OptionAotDecodeFolder = "decode-folder="; //Field offset: 0x0
	internal const string OptionAotKeyFolder = "key-folder="; //Field offset: 0x0
	internal const string OptionAotEmitLlvmObjects = "emit-llvm-objects"; //Field offset: 0x0
	internal const string OptionAotNoNativeToolchain = "no-native-toolchain"; //Field offset: 0x0
	internal const string OptionMethodPrefix = "method-prefix="; //Field offset: 0x0
	internal const string OptionAotOnlyStaticMethods = "only-static-methods"; //Field offset: 0x0
	internal const string OptionAotNoLink = "nolink"; //Field offset: 0x0
	internal const string OptionAotKeepIntermediateFiles = "keep-intermediate-files"; //Field offset: 0x0
	internal const string OptionAotAssembly = "assembly="; //Field offset: 0x0
	internal const string OptionAotType = "type="; //Field offset: 0x0
	internal const string OptionValidateExternalToolChain = "validate-external-tool-chain"; //Field offset: 0x0
	internal const string OptionAotMethod = "method="; //Field offset: 0x0
	internal const string CompilerCommandCancel = "$cancel"; //Field offset: 0x0
	internal const string CompilerCommandDisableCompiler = "$disable_compiler"; //Field offset: 0x0
	internal static readonly bool ForceDisableBurstCompilation; //Field offset: 0x0
	internal const string CompilerCommandSetProtocolVersionBurst = "$set_protocol_version_burst"; //Field offset: 0x0
	internal const string CompilerCommandRequestSetProtocolVersionEditor = "$request_set_protocol_version_editor"; //Field offset: 0x0
	internal const string CompilerCommandInitialiseDebuggerCommmand = "$load_debugger_interface"; //Field offset: 0x0
	internal const string CompilerCommandRequestInitialiseDebuggerCommmand = "$request_debug_command"; //Field offset: 0x0
	internal const string CompilerCommandAotCompilation = "$aot_compilation"; //Field offset: 0x0
	internal const string CompilerCommandDirtyAllAssemblies = "$dirty_all_assemblies"; //Field offset: 0x0
	internal const string CompilerCommandNotifyCompilationFinished = "$notify_compilation_finished"; //Field offset: 0x0
	internal const string CompilerCommandNotifyCompilationStarted = "$notify_compilation_started"; //Field offset: 0x0
	internal const string CompilerCommandNotifyAssemblyCompilationFinished = "$notify_assembly_compilation_finished"; //Field offset: 0x0
	internal const string CompilerCommandNotifyAssemblyCompilationNotRequired = "$notify_assembly_compilation_not_required"; //Field offset: 0x0
	internal const string CompilerCommandEnableCompiler = "$enable_compiler"; //Field offset: 0x0
	internal const string CompilerCommandIsArmTestEnv = "$is_arm_test_env"; //Field offset: 0x0
	internal const string CompilerCommandIsNativeApiAvailable = "$is_native_api_available"; //Field offset: 0x0
	internal const string CompilerCommandUnloadBurstNatives = "$unload_burst_natives"; //Field offset: 0x0
	internal const string CompilerCommandSetProfileCallbacks = "$set_profile_callbacks"; //Field offset: 0x0
	internal const string CompilerCommandGetTargetCpuFromHost = "$get_target_cpu_from_host"; //Field offset: 0x0
	internal const string CompilerCommandVersionNotification = "$version"; //Field offset: 0x0
	internal const string CompilerCommandDomainReload = "$domain_reload"; //Field offset: 0x0
	internal const string CompilerCommandInitialize = "$initialize"; //Field offset: 0x0
	internal const string CompilerCommandTriggerRecompilation = "$trigger_recompilation"; //Field offset: 0x0
	internal const string CompilerCommandIsCurrentCompilationDone = "$is_current_compilation_done"; //Field offset: 0x0
	internal const string CompilerCommandTriggerSetupRecompilation = "$trigger_setup_recompilation"; //Field offset: 0x0
	internal const string CompilerCommandSetDefaultOptions = "$set_default_options"; //Field offset: 0x0
	internal const string CompilerCommandILPPCompilation = "$ilpp_compilation"; //Field offset: 0x0
	internal const string OptionIncludeRootAssemblyReferences = "include-root-assembly-references="; //Field offset: 0x0
	internal const string OptionAotOutputPath = "output="; //Field offset: 0x0
	internal const string OptionAotAssemblyFolder = "assembly-folder="; //Field offset: 0x0
	internal const string OptionFormat = "format="; //Field offset: 0x0
	internal const string OptionDump = "dump="; //Field offset: 0x0
	internal const string OptionRootAssembly = "root-assembly="; //Field offset: 0x0
	internal const string OptionDisableWarnings = "disable-warnings="; //Field offset: 0x0
	internal const string OptionBranchProtection = "branch-protection="; //Field offset: 0x0
	internal const string OptionFloatMode = "float-mode="; //Field offset: 0x0
	internal const string OptionFloatPrecision = "float-precision="; //Field offset: 0x0
	internal const string OptionOptForSize = "opt-for-size"; //Field offset: 0x0
	internal const string OptionLogTimings = "log-timings"; //Field offset: 0x0
	internal const string OptionOptLevel = "opt-level="; //Field offset: 0x0
	internal const string OptionTarget = "target="; //Field offset: 0x0
	internal const string OptionFastMath = "fastmath"; //Field offset: 0x0
	internal const string OptionDisableOpt = "disable-opt"; //Field offset: 0x0
	internal const string OptionDisableSafetyChecks = "disable-safety-checks"; //Field offset: 0x0
	internal const string OptionGlobalSafetyChecksSetting = "global-safety-checks-setting="; //Field offset: 0x0
	internal const string OptionBackend = "backend="; //Field offset: 0x0
	internal const string OptionMinimumOSVersion = "minimum-os-version="; //Field offset: 0x0
	internal const string OptionPlatform = "platform="; //Field offset: 0x0
	internal const string OptionGroup = "group"; //Field offset: 0x0
	internal const string OptionBurstcSwitch = "+burstc"; //Field offset: 0x0
	internal const string BurstInitializeStaticsName = "burst.initialize.statics"; //Field offset: 0x0
	internal const string BurstInitializeExternalsName = "burst.initialize.externals"; //Field offset: 0x0
	internal const string BurstInitializeName = "burst.initialize"; //Field offset: 0x0
	internal const string DefaultLibraryName = "lib_burst_generated"; //Field offset: 0x0
	private const string ForceSynchronousCompilationArg = "--burst-force-sync-compilation"; //Field offset: 0x0
	internal const string OptionDebugTrap = "debugtrap"; //Field offset: 0x0
	internal const string OptionDisableVectors = "disable-vectors"; //Field offset: 0x0
	internal const string OptionAssemblyDefines = "assembly-defines="; //Field offset: 0x0
	internal const string OptionDebugMode = "debugMode"; //Field offset: 0x0
	internal const string OptionEnableInterpreter = "enable-interpreter"; //Field offset: 0x0
	internal const string OptionJitManagedDelegateHandle = "managed-delegate-handle="; //Field offset: 0x0
	internal const string OptionJitManagedFunctionPointer = "managed-function-pointer="; //Field offset: 0x0
	internal const string OptionJitIsForFunctionPointer = "is-for-function-pointer"; //Field offset: 0x0
	internal const string OptionJitCompilationPriority = "compilation-priority="; //Field offset: 0x0
	internal const string OptionJitEnableSynchronousCompilation = "enable-synchronous-compilation"; //Field offset: 0x0
	internal const string OptionJitEnableAssemblyCachingLogs = "enable-assembly-caching-logs"; //Field offset: 0x0
	internal const string OptionDebug = "debug="; //Field offset: 0x0
	internal const string OptionJitDisableFunctionCaching = "disable-function-caching"; //Field offset: 0x0
	internal const string OptionCacheDirectory = "cache-directory="; //Field offset: 0x0
	internal const string OptionForceDisableFrameInfoRegistration = "force-disable-frame-info-registration"; //Field offset: 0x0
	internal const string OptionStackProtectorBufferSize = "stack-protector-buffer-size="; //Field offset: 0x0
	internal const string OptionJitDisableAssemblyCaching = "disable-assembly-caching"; //Field offset: 0x0
	internal const string OptionPlatformConfiguration = "platform-configuration="; //Field offset: 0x0
	internal const string OptionStaticLinkage = "generate-static-linkage-methods"; //Field offset: 0x0
	internal const string OptionStackProtector = "stack-protector="; //Field offset: 0x0
	internal const string OptionTempDirectory = "temp-folder="; //Field offset: 0x0
	internal const string OptionEnableDirectExternalLinking = "enable-direct-external-linking"; //Field offset: 0x0
	internal const string OptionLinkerOptions = "linker-options="; //Field offset: 0x0
	internal const string OptionJobMarshalling = "generate-job-marshalling-methods"; //Field offset: 0x0
	internal const string OptionEnableFrameInfoRegistration = "enable-frame-info-registration"; //Field offset: 0x0
	internal const string OptionGenerateLinkXml = "generate-link-xml="; //Field offset: 0x0
	internal const string OptionMetaDataGeneration = "meta-data-generation="; //Field offset: 0x0
	internal const string OptionDisableStringInterpolationInExceptionMessages = "disable-string-interpolation-in-exception-messages"; //Field offset: 0x0
	internal const string OptionEnableAutoLayoutFallbackCheck = "enable-autolayout-fallback-check"; //Field offset: 0x0
	private static readonly bool ForceBurstCompilationSynchronously; //Field offset: 0x1
	internal static readonly bool IsSecondaryUnityProcess; //Field offset: 0x2
	private bool _enableBurstCompilation; //Field offset: 0x10
	private bool _enableBurstCompileSynchronously; //Field offset: 0x11
	private bool _enableBurstSafetyChecks; //Field offset: 0x12
	private bool _enableBurstTimings; //Field offset: 0x13
	private bool _enableBurstDebug; //Field offset: 0x14
	private bool _forceEnableBurstSafetyChecks; //Field offset: 0x15
	[CompilerGenerated]
	private readonly bool <IsGlobal>k__BackingField; //Field offset: 0x16
	[CompilerGenerated]
	private Action <OptionsChanged>k__BackingField; //Field offset: 0x18

	[Obsolete("This property is no longer used and will be removed in a future major release")]
	public bool DisableOptimizations
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public bool EnableBurstCompilation
	{
		 get { } //Length: 8
		 set { } //Length: 296
	}

	public bool EnableBurstCompileSynchronously
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public bool EnableBurstDebug
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public bool EnableBurstSafetyChecks
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	internal bool EnableBurstTimings
	{
		internal get { } //Length: 8
		internal set { } //Length: 48
	}

	[Obsolete("This property is no longer used and will be removed in a future major release. Use the [BurstCompile(FloatMode = FloatMode.Fast)] on the method directly to enable this feature")]
	public bool EnableFastMath
	{
		 get { } //Length: 8
		 set { } //Length: 4
	}

	public bool ForceEnableBurstSafetyChecks
	{
		 get { } //Length: 8
		 set { } //Length: 48
	}

	public bool IsEnabled
	{
		 get { } //Length: 116
	}

	private bool IsGlobal
	{
		[CompilerGenerated]
		private get { } //Length: 8
	}

	internal Action OptionsChanged
	{
		[CompilerGenerated]
		internal get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal bool RequiresSynchronousCompilation
	{
		internal get { } //Length: 116
	}

	private static BurstCompilerOptions() { }

	private BurstCompilerOptions() { }

	internal BurstCompilerOptions(bool isGlobal) { }

	private static void AddOption(StringBuilder builder, string option) { }

	private static bool CheckIsSecondaryUnityProcess() { }

	internal BurstCompilerOptions Clone() { }

	internal static ValueTuple<String[], String[], String> DeserialiseCompilationOptionsSafe(string from) { }

	public bool get_DisableOptimizations() { }

	public bool get_EnableBurstCompilation() { }

	public bool get_EnableBurstCompileSynchronously() { }

	public bool get_EnableBurstDebug() { }

	public bool get_EnableBurstSafetyChecks() { }

	internal bool get_EnableBurstTimings() { }

	public bool get_EnableFastMath() { }

	public bool get_ForceEnableBurstSafetyChecks() { }

	public bool get_IsEnabled() { }

	[CompilerGenerated]
	private bool get_IsGlobal() { }

	[CompilerGenerated]
	internal Action get_OptionsChanged() { }

	internal bool get_RequiresSynchronousCompilation() { }

	private static BurstCompileAttribute GetBurstCompileAttribute(MemberInfo memberInfo) { }

	internal static string GetOption(string optionName, object value = null) { }

	internal string GetOptions(BurstCompileAttribute attr = null, bool isForILPostProcessing = false, bool isForCompilerClient = false, bool deterministicCompilation = false) { }

	internal static bool HasBurstCompileAttribute(MemberInfo member) { }

	private void MaybeTriggerRecompilation() { }

	internal static void MergeAttributes(ref BurstCompileAttribute memberAttribute, in BurstCompileAttribute assemblyAttribute) { }

	private void OnOptionsChanged() { }

	internal static string SerialiseCompilationOptionsSafe(String[] roots, String[] folders, string options) { }

	public void set_DisableOptimizations(bool value) { }

	public void set_EnableBurstCompilation(bool value) { }

	public void set_EnableBurstCompileSynchronously(bool value) { }

	public void set_EnableBurstDebug(bool value) { }

	public void set_EnableBurstSafetyChecks(bool value) { }

	internal void set_EnableBurstTimings(bool value) { }

	public void set_EnableFastMath(bool value) { }

	public void set_ForceEnableBurstSafetyChecks(bool value) { }

	[CompilerGenerated]
	internal void set_OptionsChanged(Action value) { }

	private static bool TryGetAttribute(Assembly assembly, out BurstCompileAttribute attribute) { }

	private static bool TryGetAttribute(MemberInfo member, out BurstCompileAttribute attribute) { }

	internal bool TryGetOptions(MemberInfo member, out string flagsOut, bool isForILPostProcessing = false, bool isForCompilerClient = false, bool deterministicCompilation = false) { }

}

