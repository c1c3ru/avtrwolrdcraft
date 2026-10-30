namespace PWC.Level;

public class LevelScreenCaptureItemHandler : LevelScreenCaptureHandler
{
	protected LevelItem _levelItem; //Field offset: 0x80
	private bool _isOnFlipedCharacter; //Field offset: 0x88

	public LevelScreenCaptureItemHandler() { }

	[CompilerGenerated]
	private void <OnPlacedOnCharacter>b__5_0() { }

	protected virtual void Awake() { }

	protected virtual bool CanCaptureShowItself() { }

	protected virtual bool IsParentFliped() { }

	protected virtual void OnDestroy() { }

	protected override void OnEndDragTweenUpdate(LevelItem item, float value) { }

	protected override void OnParentEndDragTweenUpdate(LevelItem parentLevelItem, float value) { }

	protected override void OnParentEndLand(LevelItem parentLevelItem, LevelDropArea dropArea) { }

	protected override void OnParentSyncPosition(LevelItem parentLevelItem, Vector2 pointerPosition) { }

	private void OnPlacedOnCharacter(ILevelAvatar avatar, ItemOnAvatarType type) { }

	private void OnRemovedFromCharacter(ILevelAvatar avatar) { }

	private void OnSyncCharacterIsFlippedState(LevelItem levelItem, bool isFlipped) { }

	private void OnSyncItemIsFlippedState(LevelItem levelItem, bool isFlipped) { }

}

