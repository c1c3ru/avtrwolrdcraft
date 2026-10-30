namespace Game.Level;

[DisallowMultipleComponent]
[RequireComponent(typeof(LevelItem))]
[RequireComponent(typeof(PDPrefab))]
public class LevelRecipeRevertItemHandler : MonoBehaviour
{
	[CompilerGenerated]
	private static Action<LevelItem, LevelItem> OnRevertRecipeAction; //Field offset: 0x0
	[SerializeField]
	private bool _useEffectColorHandler; //Field offset: 0x20
	[ConditionalField("_useEffectColorHandler", False, True, (array) null)]
	[SerializeField]
	private Color _particleSystemColor; //Field offset: 0x24
	[SerializeField]
	private ParticleSystem _overrideEffectPrefab; //Field offset: 0x38
	[SerializeField]
	private string _revertSound; //Field offset: 0x40
	[SerializeField]
	private bool _shouldTryAndRevertIngredients; //Field offset: 0x48
	private LevelItem _levelItem; //Field offset: 0x50
	private PDPrefab _myPDPrefab; //Field offset: 0x58

	public static event Action<LevelItem, LevelItem> OnRevertRecipeAction
	{
		[CompilerGenerated]
		 add { } //Length: 204
		[CompilerGenerated]
		 remove { } //Length: 204
	}

	public LevelRecipeRevertItemHandler() { }

	[CompilerGenerated]
	public static void add_OnRevertRecipeAction(Action<LevelItem, LevelItem> value) { }

	private void Awake() { }

	[CompilerGenerated]
	public static void remove_OnRevertRecipeAction(Action<LevelItem, LevelItem> value) { }

	public void RevertToIngredientsFromInspector() { }

	private static void TryRevertRecursively(LevelItem item) { }

}

