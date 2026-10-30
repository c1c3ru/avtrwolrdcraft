namespace UnityEngine;

[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemModulesScriptBindings.h")]
[NativeHeader("Modules/ParticleSystem/ParticleSystem.h")]
[NativeHeader("Modules/ParticleSystem/ParticleSystemGeometryJob.h")]
[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemScriptBindings.h")]
[NativeHeader("Modules/ParticleSystem/ScriptBindings/ParticleSystemScriptBindings.h")]
[NativeHeader("ParticleSystemScriptingClasses.h")]
[NativeHeader("ParticleSystemScriptingClasses.h")]
[NativeHeader("Modules/ParticleSystem/ParticleSystem.h")]
[RequireComponent(typeof(Transform))]
[UsedByNativeCode]
public sealed class ParticleSystem : Component
{
	[NativeType(CodegenOptions::Custom (1), "MonoBurst", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
	internal struct Burst
	{
		private float m_Time; //Field offset: 0x0
		private MinMaxCurve m_Count; //Field offset: 0x8
		private int m_RepeatCount; //Field offset: 0x28
		private float m_RepeatInterval; //Field offset: 0x2C
		private float m_InvProbability; //Field offset: 0x30

		public MinMaxCurve count
		{
			 set { } //Length: 28
		}

		public int cycleCount
		{
			 set { } //Length: 156
		}

		public short maxCount
		{
			 get { } //Length: 28
		}

		public short get_maxCount() { }

		public void set_count(MinMaxCurve value) { }

		public void set_cycleCount(int value) { }

	}

	internal struct EmissionModule
	{
		internal ParticleSystem m_ParticleSystem; //Field offset: 0x0

		public bool enabled
		{
			 get { } //Length: 60
			[NativeThrows]
			 set { } //Length: 68
		}

		public MinMaxCurve rateOverTime
		{
			 get { } //Length: 96
			[NativeThrows]
			 set { } //Length: 68
		}

		internal EmissionModule(ParticleSystem particleSystem) { }

		public bool get_enabled() { }

		private static bool get_enabled_Injected(ref EmissionModule _unity_self) { }

		public MinMaxCurve get_rateOverTime() { }

		private static void get_rateOverTime_Injected(ref EmissionModule _unity_self, out MinMaxCurve ret) { }

		[NativeThrows]
		public Burst GetBurst(int index) { }

		private static void GetBurst_Injected(ref EmissionModule _unity_self, int index, out Burst ret) { }

		[NativeThrows]
		public void set_enabled(bool value) { }

		private static void set_enabled_Injected(ref EmissionModule _unity_self, bool value) { }

		[NativeThrows]
		public void set_rateOverTime(MinMaxCurve value) { }

		private static void set_rateOverTime_Injected(ref EmissionModule _unity_self, ref MinMaxCurve value) { }

		[NativeThrows]
		public void SetBurst(int index, Burst burst) { }

		private static void SetBurst_Injected(ref EmissionModule _unity_self, int index, ref Burst burst) { }

	}

	internal struct EmitParams
	{
		[NativeName("particle")]
		private Particle m_Particle; //Field offset: 0x0
		[NativeName("positionSet")]
		private bool m_PositionSet; //Field offset: 0x84
		[NativeName("velocitySet")]
		private bool m_VelocitySet; //Field offset: 0x85
		[NativeName("axisOfRotationSet")]
		private bool m_AxisOfRotationSet; //Field offset: 0x86
		[NativeName("rotationSet")]
		private bool m_RotationSet; //Field offset: 0x87
		[NativeName("rotationalSpeedSet")]
		private bool m_AngularVelocitySet; //Field offset: 0x88
		[NativeName("startSizeSet")]
		private bool m_StartSizeSet; //Field offset: 0x89
		[NativeName("startColorSet")]
		private bool m_StartColorSet; //Field offset: 0x8A
		[NativeName("randomSeedSet")]
		private bool m_RandomSeedSet; //Field offset: 0x8B
		[NativeName("startLifetimeSet")]
		private bool m_StartLifetimeSet; //Field offset: 0x8C
		[NativeName("meshIndexSet")]
		private bool m_MeshIndexSet; //Field offset: 0x8D
		[NativeName("applyShapeToPosition")]
		private bool m_ApplyShapeToPosition; //Field offset: 0x8E

	}

	internal struct MainModule
	{
		internal ParticleSystem m_ParticleSystem; //Field offset: 0x0

		public float duration
		{
			 get { } //Length: 60
		}

		public float gravityModifierMultiplier
		{
			 get { } //Length: 60
			[NativeThrows]
			 set { } //Length: 76
		}

		public int maxParticles
		{
			 get { } //Length: 60
		}

		public ParticleSystemScalingMode scalingMode
		{
			 get { } //Length: 60
			[NativeThrows]
			 set { } //Length: 68
		}

		public ParticleSystemSimulationSpace simulationSpace
		{
			 get { } //Length: 60
		}

		public MinMaxGradient startColor
		{
			 get { } //Length: 120
			[NativeThrows]
			 set { } //Length: 68
		}

		public MinMaxCurve startLifetime
		{
			 get { } //Length: 96
			[NativeThrows]
			 set { } //Length: 68
		}

		[NativeName("StartRotationZ")]
		public MinMaxCurve startRotation
		{
			[NativeThrows]
			 set { } //Length: 68
		}

		[NativeName("StartSizeX")]
		public MinMaxCurve startSize
		{
			[NativeThrows]
			 set { } //Length: 68
		}

		public MinMaxCurve startSpeed
		{
			[NativeThrows]
			 set { } //Length: 68
		}

		internal MainModule(ParticleSystem particleSystem) { }

		public float get_duration() { }

		private static float get_duration_Injected(ref MainModule _unity_self) { }

		public float get_gravityModifierMultiplier() { }

		private static float get_gravityModifierMultiplier_Injected(ref MainModule _unity_self) { }

		public int get_maxParticles() { }

		private static int get_maxParticles_Injected(ref MainModule _unity_self) { }

		public ParticleSystemScalingMode get_scalingMode() { }

		private static ParticleSystemScalingMode get_scalingMode_Injected(ref MainModule _unity_self) { }

		public ParticleSystemSimulationSpace get_simulationSpace() { }

		private static ParticleSystemSimulationSpace get_simulationSpace_Injected(ref MainModule _unity_self) { }

		public MinMaxGradient get_startColor() { }

		private static void get_startColor_Injected(ref MainModule _unity_self, out MinMaxGradient ret) { }

		public MinMaxCurve get_startLifetime() { }

		private static void get_startLifetime_Injected(ref MainModule _unity_self, out MinMaxCurve ret) { }

		[NativeThrows]
		public void set_gravityModifierMultiplier(float value) { }

		private static void set_gravityModifierMultiplier_Injected(ref MainModule _unity_self, float value) { }

		[NativeThrows]
		public void set_scalingMode(ParticleSystemScalingMode value) { }

		private static void set_scalingMode_Injected(ref MainModule _unity_self, ParticleSystemScalingMode value) { }

		[NativeThrows]
		public void set_startColor(MinMaxGradient value) { }

		private static void set_startColor_Injected(ref MainModule _unity_self, ref MinMaxGradient value) { }

		[NativeThrows]
		public void set_startLifetime(MinMaxCurve value) { }

		private static void set_startLifetime_Injected(ref MainModule _unity_self, ref MinMaxCurve value) { }

		[NativeThrows]
		public void set_startRotation(MinMaxCurve value) { }

		private static void set_startRotation_Injected(ref MainModule _unity_self, ref MinMaxCurve value) { }

		[NativeThrows]
		public void set_startSize(MinMaxCurve value) { }

		private static void set_startSize_Injected(ref MainModule _unity_self, ref MinMaxCurve value) { }

		[NativeThrows]
		public void set_startSpeed(MinMaxCurve value) { }

		private static void set_startSpeed_Injected(ref MainModule _unity_self, ref MinMaxCurve value) { }

	}

	[NativeType(CodegenOptions::Custom (1), "MonoMinMaxCurve", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
	internal struct MinMaxCurve
	{
		[SerializeField]
		private ParticleSystemCurveMode m_Mode; //Field offset: 0x0
		[SerializeField]
		private float m_CurveMultiplier; //Field offset: 0x4
		[SerializeField]
		private AnimationCurve m_CurveMin; //Field offset: 0x8
		[SerializeField]
		private AnimationCurve m_CurveMax; //Field offset: 0x10
		[SerializeField]
		private float m_ConstantMin; //Field offset: 0x18
		[SerializeField]
		private float m_ConstantMax; //Field offset: 0x1C

		public float constant
		{
			 get { } //Length: 8
		}

		public float constantMax
		{
			 get { } //Length: 8
		}

		public float constantMin
		{
			 get { } //Length: 8
		}

		public AnimationCurve curve
		{
			 get { } //Length: 8
		}

		public AnimationCurve curveMin
		{
			 get { } //Length: 8
		}

		public ParticleSystemCurveMode mode
		{
			 get { } //Length: 8
		}

		public MinMaxCurve(float constant) { }

		public MinMaxCurve(float min, float max) { }

		public float get_constant() { }

		public float get_constantMax() { }

		public float get_constantMin() { }

		public AnimationCurve get_curve() { }

		public AnimationCurve get_curveMin() { }

		public ParticleSystemCurveMode get_mode() { }

		public static MinMaxCurve op_Implicit(float constant) { }

	}

	[NativeType(CodegenOptions::Custom (1), "MonoMinMaxGradient", Header = "Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
	internal struct MinMaxGradient
	{
		[SerializeField]
		private ParticleSystemGradientMode m_Mode; //Field offset: 0x0
		[SerializeField]
		private Gradient m_GradientMin; //Field offset: 0x8
		[SerializeField]
		private Gradient m_GradientMax; //Field offset: 0x10
		[SerializeField]
		private Color m_ColorMin; //Field offset: 0x18
		[SerializeField]
		private Color m_ColorMax; //Field offset: 0x28

		public Gradient gradient
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public ParticleSystemGradientMode mode
		{
			 set { } //Length: 8
		}

		public MinMaxGradient(Color color) { }

		public MinMaxGradient(Gradient gradient) { }

		public MinMaxGradient(Color min, Color max) { }

		public Gradient get_gradient() { }

		public static MinMaxGradient op_Implicit(Color color) { }

		public void set_gradient(Gradient value) { }

		public void set_mode(ParticleSystemGradientMode value) { }

	}

	[RequiredByNativeCode("particleSystemParticle", Optional = True)]
	internal struct Particle
	{
		private Vector3 m_Position; //Field offset: 0x0
		private Vector3 m_Velocity; //Field offset: 0xC
		private Vector3 m_AnimatedVelocity; //Field offset: 0x18
		private Vector3 m_InitialVelocity; //Field offset: 0x24
		private Vector3 m_AxisOfRotation; //Field offset: 0x30
		private Vector3 m_Rotation; //Field offset: 0x3C
		private Vector3 m_AngularVelocity; //Field offset: 0x48
		private Vector3 m_StartSize; //Field offset: 0x54
		private Color32 m_StartColor; //Field offset: 0x60
		private uint m_RandomSeed; //Field offset: 0x64
		private uint m_ParentRandomSeed; //Field offset: 0x68
		private float m_Lifetime; //Field offset: 0x6C
		private float m_StartLifetime; //Field offset: 0x70
		private int m_MeshIndex; //Field offset: 0x74
		private float m_EmitAccumulator0; //Field offset: 0x78
		private float m_EmitAccumulator1; //Field offset: 0x7C
		private uint m_Flags; //Field offset: 0x80

		public Vector3 angularVelocity3D
		{
			 set { } //Length: 44
		}

		[Obsolete("Please use Particle.remainingLifetime instead. (UnityUpgradable) -> UnityEngine.ParticleSystem/Particle.remainingLifetime", False)]
		public float lifetime
		{
			 set { } //Length: 8
		}

		public Vector3 position
		{
			 get { } //Length: 12
			 set { } //Length: 12
		}

		public uint randomSeed
		{
			 set { } //Length: 8
		}

		public float remainingLifetime
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public float rotation
		{
			 get { } //Length: 20
		}

		public Vector3 rotation3D
		{
			 set { } //Length: 44
		}

		public Color32 startColor
		{
			 set { } //Length: 8
		}

		public float startLifetime
		{
			 get { } //Length: 8
			 set { } //Length: 8
		}

		public float startSize
		{
			 set { } //Length: 12
		}

		public Vector3 velocity
		{
			 set { } //Length: 12
		}

		public Vector3 get_position() { }

		public float get_remainingLifetime() { }

		public float get_rotation() { }

		public float get_startLifetime() { }

		public Color32 GetCurrentColor(ParticleSystem system) { }

		public float GetCurrentSize(ParticleSystem system) { }

		public void set_angularVelocity3D(Vector3 value) { }

		public void set_lifetime(float value) { }

		public void set_position(Vector3 value) { }

		public void set_randomSeed(uint value) { }

		public void set_remainingLifetime(float value) { }

		public void set_rotation3D(Vector3 value) { }

		public void set_startColor(Color32 value) { }

		public void set_startLifetime(float value) { }

		public void set_startSize(float value) { }

		public void set_velocity(Vector3 value) { }

	}

	internal struct ShapeModule
	{
		internal ParticleSystem m_ParticleSystem; //Field offset: 0x0

		public Mesh mesh
		{
			[NativeThrows]
			 set { } //Length: 68
		}

		public MeshRenderer meshRenderer
		{
			[NativeThrows]
			 set { } //Length: 68
		}

		public ParticleSystemMeshShapeType meshShapeType
		{
			[NativeThrows]
			 set { } //Length: 68
		}

		public float radius
		{
			[NativeThrows]
			 set { } //Length: 76
		}

		public Vector3 scale
		{
			[NativeThrows]
			 set { } //Length: 84
		}

		public ParticleSystemShapeType shapeType
		{
			[NativeThrows]
			 set { } //Length: 68
		}

		public SpriteRenderer spriteRenderer
		{
			[NativeThrows]
			 set { } //Length: 68
		}

		internal ShapeModule(ParticleSystem particleSystem) { }

		[NativeThrows]
		public void set_mesh(Mesh value) { }

		private static void set_mesh_Injected(ref ShapeModule _unity_self, Mesh value) { }

		[NativeThrows]
		public void set_meshRenderer(MeshRenderer value) { }

		private static void set_meshRenderer_Injected(ref ShapeModule _unity_self, MeshRenderer value) { }

		[NativeThrows]
		public void set_meshShapeType(ParticleSystemMeshShapeType value) { }

		private static void set_meshShapeType_Injected(ref ShapeModule _unity_self, ParticleSystemMeshShapeType value) { }

		[NativeThrows]
		public void set_radius(float value) { }

		private static void set_radius_Injected(ref ShapeModule _unity_self, float value) { }

		[NativeThrows]
		public void set_scale(Vector3 value) { }

		private static void set_scale_Injected(ref ShapeModule _unity_self, ref Vector3 value) { }

		[NativeThrows]
		public void set_shapeType(ParticleSystemShapeType value) { }

		private static void set_shapeType_Injected(ref ShapeModule _unity_self, ParticleSystemShapeType value) { }

		[NativeThrows]
		public void set_spriteRenderer(SpriteRenderer value) { }

		private static void set_spriteRenderer_Injected(ref ShapeModule _unity_self, SpriteRenderer value) { }

	}

	internal struct TextureSheetAnimationModule
	{
		internal ParticleSystem m_ParticleSystem; //Field offset: 0x0

		public ParticleSystemAnimationType animation
		{
			 get { } //Length: 60
		}

		public int cycleCount
		{
			 get { } //Length: 60
		}

		public bool enabled
		{
			 get { } //Length: 60
		}

		public MinMaxCurve frameOverTime
		{
			 get { } //Length: 96
		}

		public int numTilesX
		{
			 get { } //Length: 60
		}

		public int numTilesY
		{
			 get { } //Length: 60
		}

		public int rowIndex
		{
			 get { } //Length: 60
		}

		public MinMaxCurve startFrame
		{
			 get { } //Length: 96
		}

		internal TextureSheetAnimationModule(ParticleSystem particleSystem) { }

		public ParticleSystemAnimationType get_animation() { }

		private static ParticleSystemAnimationType get_animation_Injected(ref TextureSheetAnimationModule _unity_self) { }

		public int get_cycleCount() { }

		private static int get_cycleCount_Injected(ref TextureSheetAnimationModule _unity_self) { }

		public bool get_enabled() { }

		private static bool get_enabled_Injected(ref TextureSheetAnimationModule _unity_self) { }

		public MinMaxCurve get_frameOverTime() { }

		private static void get_frameOverTime_Injected(ref TextureSheetAnimationModule _unity_self, out MinMaxCurve ret) { }

		public int get_numTilesX() { }

		private static int get_numTilesX_Injected(ref TextureSheetAnimationModule _unity_self) { }

		public int get_numTilesY() { }

		private static int get_numTilesY_Injected(ref TextureSheetAnimationModule _unity_self) { }

		public int get_rowIndex() { }

		private static int get_rowIndex_Injected(ref TextureSheetAnimationModule _unity_self) { }

		public MinMaxCurve get_startFrame() { }

		private static void get_startFrame_Injected(ref TextureSheetAnimationModule _unity_self, out MinMaxCurve ret) { }

	}

	internal struct VelocityOverLifetimeModule
	{
		internal ParticleSystem m_ParticleSystem; //Field offset: 0x0

		public bool enabled
		{
			 get { } //Length: 60
		}

		public MinMaxCurve x
		{
			 get { } //Length: 96
			[NativeThrows]
			 set { } //Length: 68
		}

		internal VelocityOverLifetimeModule(ParticleSystem particleSystem) { }

		public bool get_enabled() { }

		private static bool get_enabled_Injected(ref VelocityOverLifetimeModule _unity_self) { }

		public MinMaxCurve get_x() { }

		private static void get_x_Injected(ref VelocityOverLifetimeModule _unity_self, out MinMaxCurve ret) { }

		[NativeThrows]
		public void set_x(MinMaxCurve value) { }

		private static void set_x_Injected(ref VelocityOverLifetimeModule _unity_self, ref MinMaxCurve value) { }

	}


	public EmissionModule emission
	{
		 get { } //Length: 32
	}

	public bool isPlaying
	{
		[NativeName("SyncJobs(false)->IsPlaying")]
		 get { } //Length: 60
	}

	public MainModule main
	{
		 get { } //Length: 32
	}

	public ShapeModule shape
	{
		 get { } //Length: 32
	}

	public TextureSheetAnimationModule textureSheetAnimation
	{
		 get { } //Length: 32
	}

	public VelocityOverLifetimeModule velocityOverLifetime
	{
		 get { } //Length: 32
	}

	public ParticleSystem() { }

	public void Clear() { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::Clear", HasExplicitThis = True)]
	public void Clear(bool withChildren) { }

	[Obsolete("Emit with specific parameters is deprecated. Pass a ParticleSystem.EmitParams parameter instead, which allows you to override some/all of the emission properties", False)]
	public void Emit(Vector3 position, Vector3 velocity, float size, float lifetime, Color32 color) { }

	[Obsolete("Emit with a single particle structure is deprecated. Pass a ParticleSystem.EmitParams parameter instead, which allows you to override some/all of the emission properties", False)]
	public void Emit(Particle particle) { }

	[NativeName("SyncJobs()->EmitParticlesExternal")]
	public void Emit(EmitParams emitParams, int count) { }

	[RequiredByNativeCode]
	public void Emit(int count) { }

	private void Emit_Injected(ref EmitParams emitParams, int count) { }

	[NativeName("SyncJobs()->Emit")]
	private void Emit_Internal(int count) { }

	[NativeName("SyncJobs()->EmitParticleExternal")]
	private void EmitOld_Internal(ref Particle particle) { }

	public EmissionModule get_emission() { }

	[NativeName("SyncJobs(false)->IsPlaying")]
	public bool get_isPlaying() { }

	public MainModule get_main() { }

	public ShapeModule get_shape() { }

	public TextureSheetAnimationModule get_textureSheetAnimation() { }

	public VelocityOverLifetimeModule get_velocityOverLifetime() { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::GetCustomParticleData", HasExplicitThis = True, ThrowsException = True)]
	public int GetCustomParticleData(List<Vector4> customData, ParticleSystemCustomData streamIndex) { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::GetParticleCurrentColor", HasExplicitThis = True)]
	internal Color32 GetParticleCurrentColor(ref Particle particle) { }

	private void GetParticleCurrentColor_Injected(ref Particle particle, out Color32 ret) { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::GetParticleCurrentSize", HasExplicitThis = True)]
	internal float GetParticleCurrentSize(ref Particle particle) { }

	public int GetParticles(out Particle[] particles, int size) { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::GetParticles", HasExplicitThis = True, ThrowsException = True)]
	public int GetParticles(out Particle[] particles, int size, int offset) { }

	public int GetParticles(out Particle[] particles) { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::Play", HasExplicitThis = True)]
	public void Play(bool withChildren) { }

	public void Play() { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::SetCustomParticleData", HasExplicitThis = True, ThrowsException = True)]
	public void SetCustomParticleData(List<Vector4> customData, ParticleSystemCustomData streamIndex) { }

	public void Simulate(float t, bool withChildren, bool restart) { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::Simulate", HasExplicitThis = True)]
	public void Simulate(float t, bool withChildren, bool restart, bool fixedTimeStep) { }

	[FreeFunction(Name = "ParticleSystemScriptBindings::Stop", HasExplicitThis = True)]
	public void Stop(bool withChildren, ParticleSystemStopBehavior stopBehavior) { }

	public void Stop() { }

	public void Stop(bool withChildren) { }

}

