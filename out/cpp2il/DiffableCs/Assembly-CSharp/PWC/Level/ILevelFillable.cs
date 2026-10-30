namespace PWC.Level;

public interface ILevelFillable
{

	public event Action<Color> OnColorLiquidAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<ILevelFillable> OnEmptyingTweenCompleteAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<ILevelFillable> OnEmptyingTweenStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<ILevelFillable> OnFillingTweenCompleteAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<ILevelFillable> OnFillingTweenStartAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	[CompilerGenerated]
	public void add_OnColorLiquidAction(Action<Color> value) { }

	[CompilerGenerated]
	public void add_OnEmptyingTweenCompleteAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public void add_OnEmptyingTweenStartAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public void add_OnFillingTweenCompleteAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public void add_OnFillingTweenStartAction(Action<ILevelFillable> value) { }

	public Color GetLiquidColor() { }

	public bool IsFull() { }

	public void PlayEmptyingTween(float duration) { }

	public void PlayFillingTween(float duration, Color color, Action onFinish = null) { }

	[CompilerGenerated]
	public void remove_OnColorLiquidAction(Action<Color> value) { }

	[CompilerGenerated]
	public void remove_OnEmptyingTweenCompleteAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public void remove_OnEmptyingTweenStartAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public void remove_OnFillingTweenCompleteAction(Action<ILevelFillable> value) { }

	[CompilerGenerated]
	public void remove_OnFillingTweenStartAction(Action<ILevelFillable> value) { }

	public void SetLiquidColor(Color color) { }

	public void SnapToState(bool isFull) { }

}

