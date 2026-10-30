namespace Game.Level.ContextualAnimation;

public class LevelCARestaurantMenuOrderFoodItemHandler : LevelCAItemHandlerBase
{
	private enum FoodType
	{
		Main = 0,
		Fancy = 1,
		Beverage = 2,
		Dessert = 3,
		HotelLobby = 4,
		HotelRoofTop = 5,
	}

	private class FoodWithPlate
	{
		[SerializeField]
		private PDPrefabReference _food; //Field offset: 0x10
		[SerializeField]
		private bool _havePlate; //Field offset: 0x18

		public PDPrefabReference Food
		{
			 get { } //Length: 8
		}

		public bool HavePlate
		{
			 get { } //Length: 8
		}

		public FoodWithPlate() { }

		public PDPrefabReference get_Food() { }

		public bool get_HavePlate() { }

	}

	[SerializeField]
	private PDPrefabReference _plate; //Field offset: 0x88
	[SerializeField]
	private FoodWithPlate[] _food; //Field offset: 0x90
	[SerializeField]
	private LevelSpawner _spawner; //Field offset: 0x98
	[SerializeField]
	private FoodType _foodType; //Field offset: 0xA0
	private readonly List<LevelCAConfig> _mainConfigs; //Field offset: 0xA8
	private readonly List<LevelCAConfig> _fancyConfigs; //Field offset: 0xB0
	private readonly List<LevelCAConfig> _beverageConfigs; //Field offset: 0xB8
	private readonly List<LevelCAConfig> _dessertConfigs; //Field offset: 0xC0
	private readonly List<LevelCAConfig> _hotelLobbyConfigs; //Field offset: 0xC8
	private readonly List<LevelCAConfig> _hotelRoofTopConfigs; //Field offset: 0xD0
	private int _index; //Field offset: 0xD8

	public LevelCARestaurantMenuOrderFoodItemHandler() { }

	public virtual bool AllowReturnToIdleAnimationWhenRemovedFromTarget() { }

	public virtual List<LevelCAConfig> GetAnimations() { }

	public virtual string GetFolderName() { }

	private LevelSpawn GetPrefabToSpawn(PDPrefabReference _reference) { }

	public virtual SpineType GetSpineType() { }

	public virtual void OnAddedToTarget(ICATarget target) { }

	public virtual void OnAnimationBegin(ICATarget target, LevelCAConfig config) { }

	public virtual void OnAnimationEnd(ICATarget target, LevelCAConfig config) { }

	public virtual bool TryOverrideMainThumb(out Sprite sprite) { }

}

