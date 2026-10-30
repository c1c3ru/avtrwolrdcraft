namespace Game.Level;

public class LevelSliderTableContainerArea : LevelContainerArea
{
	[SerializeField]
	private LevelSlider _leftSlider; //Field offset: 0xD8
	[SerializeField]
	private LevelSlider _rightSlider; //Field offset: 0xE0
	private bool _isLeftOpen; //Field offset: 0xE8
	private bool _isRightOpen; //Field offset: 0xE9

	public LevelSliderTableContainerArea() { }

	private void AnimateChildrenItems(bool value, bool isSnap = false) { }

	protected virtual void Awake() { }

	protected virtual void OnDestroy() { }

	private void OnLeftSliderBeginAnimation(SliderDestinationType destinationType) { }

	protected virtual void OnLevelPostInit() { }

	private void OnRightSliderBeginAnimation(SliderDestinationType destinationType) { }

}

