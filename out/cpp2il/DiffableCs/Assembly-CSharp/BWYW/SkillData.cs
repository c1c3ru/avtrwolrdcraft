namespace BWYW;

public class SkillData
{
	private class Date
	{
		public int seconds; //Field offset: 0x10
		public int minutes; //Field offset: 0x14
		public int hour; //Field offset: 0x18
		public int day; //Field offset: 0x1C
		public int month; //Field offset: 0x20
		public int year; //Field offset: 0x24

		public Date() { }

	}

	internal class DayData
	{
		public List<TaskData> tasksDatasList; //Field offset: 0x10
		public List<Int32> doneTasksToday; //Field offset: 0x18
		public List<Int32> claimedTasksToday; //Field offset: 0x20

		public List<Int32> DoneTasksToday
		{
			 get { } //Length: 8
		}

		public DayData(int numOfTasks) { }

		public List<Int32> get_DoneTasksToday() { }

		public List<String> GetDoneSubtasksList(int taskId) { }

	}

	internal enum SkillType
	{
		None = 0,
		HipHop = 1,
		HipHop_SE1_C2 = 2,
		MovieStar_SE2_C1 = 3,
		ComingSoon_SE3_C1 = 4,
	}

	internal class TaskData
	{
		public List<String> doneSubTasksList; //Field offset: 0x10
		public bool isXPClaimed; //Field offset: 0x18

		public TaskData() { }

	}

	public List<DayData> daysDataList; //Field offset: 0x10
	public List<Int32> giftsClaimed; //Field offset: 0x18
	public List<Int32> tasksRevealed; //Field offset: 0x20
	[SerializeField]
	private int _currentXP; //Field offset: 0x28
	[SerializeField]
	private Date _dayDoneDate; //Field offset: 0x30
	[SerializeField]
	private bool _isStarterKitGiven; //Field offset: 0x38
	[SerializeField]
	private bool _isNeedSearchLastGift; //Field offset: 0x39
	[SerializeField]
	private bool _isNew; //Field offset: 0x3A

	public int CurrentXP
	{
		 get { } //Length: 8
	}

	public Nullable<DateTime> DayDoneDate
	{
		 get { } //Length: 152
	}

	public bool IsNeedSearchLastGift
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public SkillData() { }

	public void AddNewDay(int numOfTasks) { }

	public int get_CurrentXP() { }

	public Nullable<DateTime> get_DayDoneDate() { }

	public bool get_IsNeedSearchLastGift() { }

	public int GetCurrentDay() { }

	public DayData GetDayData(int day) { }

	public bool GetIsNew() { }

	public int GetProgressInTask(int day, int taskId) { }

	public TaskData GetTaskData(int day, int taskId) { }

	public int GetTotalXP() { }

	public bool IsSkillFinished() { }

	public bool IsStarterKitGiven() { }

	public bool IsTaskClaimed(int day, int taskId) { }

	public bool IsTaskClaimed(int taskId) { }

	public bool IsTaskDone(int taskId) { }

	public bool IsTaskDone(int day, int taskId) { }

	internal bool IsTaskRevealed(int day, int taskId) { }

	public void RemoveDays(int numOfDaysToRemove) { }

	public void ResetClaimedGifts() { }

	public void ResetDay() { }

	public void set_IsNeedSearchLastGift(bool value) { }

	public void SetDayDoneDate(Nullable<DateTime> dayDoneDate) { }

	public void SetGiftClaimed(int day) { }

	public void SetNotNew() { }

	public void SetStarterKitGiven() { }

	public void SetTaskDone(int taskId) { }

	public void SetTaskRevealed(int taskId) { }

	public bool TrySetTaskClaimed(int taskId, int xpGained) { }

	public void UnclaimGift(int giftId) { }

}

