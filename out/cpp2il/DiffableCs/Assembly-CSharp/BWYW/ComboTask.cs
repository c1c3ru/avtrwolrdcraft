namespace BWYW;

public class ComboTask : DailyTaskBase
{
	[SerializeField]
	private List<ComboTasksData> _tasksLists; //Field offset: 0x40
	[SerializeField]
	private List<ComboTasksData> _requiredStateTasksLists; //Field offset: 0x48

	public ComboTask() { }

	public List<DailyTaskBase> GetAllStateSubTasks() { }

	public DailyTaskBase GetProgressableSubTaskOfType(TaskType type) { }

}

