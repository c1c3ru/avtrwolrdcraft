namespace PWC.Multiplayer;

public class MPDataGenerator
{
	public static string GuidPrefixForThisFrame; //Field offset: 0x0
	[CompilerGenerated]
	private static MPDataGeneratorHandle <OneCallDataGeneratorHandle>k__BackingField; //Field offset: 0x8
	public static bool ShouldClearGuidPrefixAtTheEndOfTheFrame; //Field offset: 0x10
	private static MPPlayerRandom _oneCallRandomGenerator; //Field offset: 0x18
	private static MPPlayerGuid _oneCallGuidGenerator; //Field offset: 0x20
	private static readonly Dictionary<Int32, MPPlayerRandom> _randoms; //Field offset: 0x28
	private static readonly Dictionary<Int32, MPPlayerGuid> _guids; //Field offset: 0x30
	[CompilerGenerated]
	private static Action<Int32, String> OnInitAction; //Field offset: 0x38

	public static event Action<Int32, String> OnInitAction
	{
		[CompilerGenerated]
		 add { } //Length: 244
		[CompilerGenerated]
		 remove { } //Length: 244
	}

	public static MPDataGeneratorHandle OneCallDataGeneratorHandle
	{
		[CompilerGenerated]
		 get { } //Length: 88
		[CompilerGenerated]
		 set { } //Length: 96
	}

	private static MPDataGenerator() { }

	public MPDataGenerator() { }

	[CompilerGenerated]
	public static void add_OnInitAction(Action<Int32, String> value) { }

	public static void ClearOneCallGenerator() { }

	[CompilerGenerated]
	public static MPDataGeneratorHandle get_OneCallDataGeneratorHandle() { }

	public static float GetNextFloat(float minValue, float maxValue, bool useGlobal = false) { }

	public static string GetNextGUID() { }

	public static int GetNextInt(int minValue, int maxValue) { }

	private static MPPlayerGuid GetProperPlayerGuid() { }

	private static MPPlayerRandom GetProperPlayerRandom() { }

	public static Random GetRandom() { }

	public static void Init(ICollection<Int32> uids, int seed, string prefixPrefix) { }

	[CompilerGenerated]
	public static void remove_OnInitAction(Action<Int32, String> value) { }

	[CompilerGenerated]
	public static void set_OneCallDataGeneratorHandle(MPDataGeneratorHandle value) { }

	public static void SetActiveOneCallHandle(MPDataGeneratorHandle dataGeneratorHandle) { }

	public static void SetGuidPrefixAndAppendPlayerUIDForPlayer(int playerUID, string guidPrefix) { }

	public static void SetGuidPrefixForPlayer(int playerUID, string guidPrefix) { }

	public static void SetOneCallGuidGenerator(MPPlayerGuid generator) { }

	public static void SetOneCallGuidGenerator(string guidPrefix) { }

	public static void SetOneCallRandomGenerator(MPPlayerRandom generator) { }

	public static void SetOneCallRandomGenerator(int seed) { }

	public static void SetOneCallValidDataGenerators(MPOneCallGeneratorData data) { }

	public static void SetRandomSeedForPlayer(int playerUID, int seed) { }

}

