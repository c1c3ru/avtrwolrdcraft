namespace PWC.Level;

public class LevelCharacterCaller : MonoBehaviour
{
	[SerializeField]
	private LevelCharacterCallerConfig _config; //Field offset: 0x20
	[SerializeField]
	private Transform _callPoint; //Field offset: 0x28
	[SerializeField]
	private bool _isBasicDrop; //Field offset: 0x30

	public LevelCharacterCaller() { }

	[CompilerGenerated]
	private bool <CallCharacter>b__3_0(LevelCharacter x) { }

	public void CallCharacter() { }

	private void PutInHand(LevelCharacter character, PDPrefab instance, AvatarHandType preferredHandType) { }

}

