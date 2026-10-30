namespace Game.Level;

public class LevelProcessorDropAreaHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass16_0
	{
		public ICATarget caTarget; //Field offset: 0x10

		public <>c__DisplayClass16_0() { }

		internal void <PlayAnimationAndReturnToIdle>b__0(TrackEntry x) { }

	}

	[SerializeField]
	private LevelConsumerAreaBase _dropArea; //Field offset: 0x20
	[SerializeField]
	private bool _lookForItemsInHierarchy; //Field offset: 0x28

	public LevelProcessorDropAreaHandler() { }

	public void DestroyItems() { }

	public void DestroyItemsForEver() { }

	private void DestroyItemsInternal(bool isPoof, bool destroyForEver = false) { }

	public void DestroyItemsWithPoof() { }

	public void DetachItems() { }

	public void DropItems() { }

	public void EatAnimalFood() { }

	public void EatAvatarFood() { }

	private void EatFood(EaterType eaterType) { }

	public void LockAllChildren() { }

	private void PlayAnimationAndReturnToIdle(ICATarget caTarget, string fullPathOfAnimation, bool isLoop) { }

	private void PlayAnimationOnAllChildren(string FullPathOfAnimation, bool isloop) { }

	public void PlayAnimationOnAllChildren(string FullPathOfAnimation) { }

	public void PlayLoopAnimationOnAllChildren(string FullPathOfAnimation) { }

	public void ToggleCShapes(bool state) { }

	public void ToggleItemsToSpecificIndex(int index) { }

	public void ToggleLevelItems(bool state) { }

	public void TransformItems() { }

	public void UnlockAndReleaseAllChildren() { }

}

