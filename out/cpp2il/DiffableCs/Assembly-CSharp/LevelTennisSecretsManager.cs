//Type is in global namespace

public class LevelTennisSecretsManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass8_0
	{
		public PDPrefab prefabReference; //Field offset: 0x10

		public <>c__DisplayClass8_0() { }

		internal bool <OnServe>b__0(PDprefabEventEntry x) { }

	}

	[SerializeField]
	private List<PDprefabEventEntry> _uniqueBallEvents; //Field offset: 0x20
	[SerializeField]
	private string _catFullAnimationName; //Field offset: 0x28
	[SerializeField]
	private PDPrefabReference _catPrefabReference; //Field offset: 0x30
	[SerializeField]
	private UnityEvent _catSecretEvent; //Field offset: 0x38
	[SerializeField]
	private PDPrefabReference _dogPrefabReference; //Field offset: 0x40
	[SerializeField]
	private UnityEvent _dogSecretEvent; //Field offset: 0x48

	public LevelTennisSecretsManager() { }

	[CompilerGenerated]
	private bool <OnAnimationBegin>b__9_0(PDPrefab x) { }

	[CompilerGenerated]
	private bool <OnCatch>b__10_0(PDPrefab x) { }

	private void Awake() { }

	private void OnAnimationBegin(ICATarget target, LevelCAConfig config, string fullAnimationName) { }

	private void OnCatch(LevelDog levelDog, LevelItem levelItem) { }

	private void OnDestroy() { }

	private void OnServe(LevelCATennisballItemHandler itemHandler) { }

}

