namespace Game.Level;

public class LevelMakeupBrushItemHandler : LevelMakeupDragItemHandler, IHasPersistentData, IRequirePDSceneObject, IMultiplayer_Messageable, IMultiplayer_NetworkIdentityBase
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public LevelMakeupBrushItemHandler <>4__this; //Field offset: 0x10
		public LevelMakeupDataItemHandler makeupDataItemHandler; //Field offset: 0x18

		public <>c__DisplayClass9_0() { }

		internal void <OnTargetEnterOtherItem>b__0() { }

	}

	[SerializeField]
	private SpriteRenderer _powder; //Field offset: 0xE8
	[SerializeField]
	private ParticleSystem _particleSystem; //Field offset: 0xF0
	[SerializeField]
	private GameSoundPlayer _soundPlayer; //Field offset: 0xF8
	private LevelCharacterMakeupData _characterMakeupData; //Field offset: 0x100
	private int _charactersCount; //Field offset: 0x108
	private int _timerTween; //Field offset: 0x10C
	private LevelItem _currentItem; //Field offset: 0x110
	[SerializeField]
	private UnityEvent OnPowderSet; //Field offset: 0x118

	public LevelMakeupBrushItemHandler() { }

	public override Dictionary<String, Object> GetPersistentData() { }

	private bool HasData() { }

	protected virtual bool IsValidTarget(ILevelConsumer target) { }

	protected virtual bool Multiplayer_ShouldSendEnterAndExitEvents() { }

	protected virtual void OnEndDrag(DragDropItemBase item, PointerEventData eventData) { }

	protected virtual void OnTargetEnterCharacterHead(LevelCharacter character, bool shouldPlaySound = true) { }

	private void OnTargetEnterCharacterHead_Internal(LevelCharacter character) { }

	protected virtual void OnTargetEnterOtherItem(ILevelConsumer target) { }

	private void OnTargetEnterOtherItem_Internal(LevelMakeupDataItemHandler makeupDataItemHandler) { }

	protected virtual void OnTargetExitCharacterHead(LevelCharacter character) { }

	protected virtual void OnTargetExitOtherItem(ILevelConsumer target) { }

	private void ParticleSystemSetActive(bool value) { }

	private override void PWC.Multiplayer.IMultiplayer_Messageable.Multiplayer_ReceiveMessage(MPEventIdentifierData idData, object objectData) { }

	protected virtual void SetData(LevelCharacterMakeupData characterMakeupData) { }

	public override void SetPersistentData(Dictionary<String, Object> allData, Dictionary<String, PDSceneObject> sceneObjects) { }

	private void SetPowderActiveAndColor() { }

	private void SoundLoopSetActive(bool value) { }

	public void StopAnimationEffects() { }

}

