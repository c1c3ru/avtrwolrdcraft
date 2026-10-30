namespace PWC.AvatarSpeech;

public class AvatarSpeechAvatarHandler : MonoBehaviour, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass7_0
	{
		public LevelCharacter <character>5__2; //Field offset: 0x10

		public <>c__DisplayClass7_0() { }

		internal void <DoSpeech>b__0() { }

	}

	internal class Multiplayer_MessageData
	{
		public string key; //Field offset: 0x10
		public string itemId; //Field offset: 0x18

		public Multiplayer_MessageData() { }

	}

	private AvatarSpeechUITextBubble _textBubble; //Field offset: 0x20
	private int _tweenId; //Field offset: 0x28
	[CompilerGenerated]
	private int <Multiplayer_ComponentIndex>k__BackingField; //Field offset: 0x2C

	public override int Multiplayer_ComponentIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public AvatarSpeechAvatarHandler() { }

	private void Awake() { }

	public void DoSpeech(Item config, bool multiplayer_allowEvent) { }

	[CompilerGenerated]
	public override int get_Multiplayer_ComponentIndex() { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	[CompilerGenerated]
	public override void set_Multiplayer_ComponentIndex(int value) { }

}

