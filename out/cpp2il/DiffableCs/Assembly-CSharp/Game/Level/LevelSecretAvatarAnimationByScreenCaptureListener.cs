namespace Game.Level;

public class LevelSecretAvatarAnimationByScreenCaptureListener : MonoBehaviour
{
	[CompilerGenerated]
	private struct <>c__DisplayClass10_0
	{
		public LevelSecretAvatarAnimationByScreenCaptureListener <>4__this; //Field offset: 0x0
		public int currentValidAvatars; //Field offset: 0x8
		public int targetCounter; //Field offset: 0xC

	}

	[SerializeField]
	private List<String> _animationNames; //Field offset: 0x20
	[SerializeField]
	private List<String> _avatarIDs; //Field offset: 0x28
	[SerializeField]
	private bool _acceptOnlyPlayerCreatedAvatars; //Field offset: 0x30
	[SerializeField]
	private int _overrideTargetCount; //Field offset: 0x34
	[SerializeField]
	private string _dropAreaLabel; //Field offset: 0x38
	[SerializeField]
	private string _heldItemLabel; //Field offset: 0x40
	[SerializeField]
	private List<String> _requiredSkins; //Field offset: 0x48
	[SerializeField]
	private UnityEvent _onCaptureEvent; //Field offset: 0x50

	public LevelSecretAvatarAnimationByScreenCaptureListener() { }

	[CompilerGenerated]
	private bool <OnScreenCapture>g__AreRequiredSkinsInCapture|10_2(List<ILevelAvatar> avatars, ref <>c__DisplayClass10_0 unnamed_param_1) { }

	[CompilerGenerated]
	private bool <OnScreenCapture>g__CheckItemInCharacterHand|10_1(LevelCharacter character, AvatarHandType handType, ref <>c__DisplayClass10_0 unnamed_param_2) { }

	[CompilerGenerated]
	private void <OnScreenCapture>g__CheckSingleLevelAvatar|10_0(ILevelAvatar levelAvatar, ref <>c__DisplayClass10_0 unnamed_param_1) { }

	private void Awake() { }

	private void OnDestroy() { }

	private void OnScreenCapture(LevelScreenCaptureCameraItemHandler levelScreenCaptureCameraItemHandler) { }

}

