namespace BWYW;

public class ComboTasksData : ScriptableObject
{
	[SerializeField]
	[TasksList(typeof(DailyTaskBase))]
	private DailyTaskContainer _subTasksList; //Field offset: 0x18

	public int numOfTasks
	{
		 get { } //Length: 80
	}

	public List<DailyTaskBase> subTasksList
	{
		 get { } //Length: 28
	}

	public ComboTasksData() { }

	public int get_numOfTasks() { }

	public List<DailyTaskBase> get_subTasksList() { }

}

