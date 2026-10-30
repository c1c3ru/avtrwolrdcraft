namespace BWYW;

public class DailyTasksData : ScriptableObject
{
	[SerializeField]
	[TasksList(typeof(DailyTaskBase))]
	private DailyTaskContainer _tasksList; //Field offset: 0x18

	public int numOfTasks
	{
		 get { } //Length: 80
	}

	public List<DailyTaskBase> tasksList
	{
		 get { } //Length: 28
	}

	public DailyTasksData() { }

	public int get_numOfTasks() { }

	public List<DailyTaskBase> get_tasksList() { }

}

