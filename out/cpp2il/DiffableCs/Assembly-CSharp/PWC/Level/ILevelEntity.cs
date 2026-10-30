namespace PWC.Level;

public interface ILevelEntity
{

	public List<LevelAreaBase> MyAreas
	{
		 get { } //Length: 0
	}

	public List<LevelAreaBase> get_MyAreas() { }

	public SortingElement GetSortingElement() { }

	public int GetSortingOrder() { }

	public Transform GetTransform() { }

}

