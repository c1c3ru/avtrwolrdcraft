namespace PWC.World.Buildings;

public class WorldBuildingResetButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	private IWorldResettable _worldBuilding; //Field offset: 0x20
	private bool _didReset; //Field offset: 0x28

	public WorldBuildingResetButton() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__3_0() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__3_1() { }

	[CompilerGenerated]
	private void <OnPointerClick>b__3_2() { }

	public void Init(IWorldResettable worldBuilding) { }

	public override void OnPointerClick(PointerEventData eventData) { }

}

