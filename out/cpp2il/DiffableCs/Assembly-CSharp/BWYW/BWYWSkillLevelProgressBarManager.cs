namespace BWYW;

public class BWYWSkillLevelProgressBarManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass32_0
	{
		public BWYWSkillLevelProgressBarManager <>4__this; //Field offset: 0x10
		public int endXp; //Field offset: 0x18

		public <>c__DisplayClass32_0() { }

		internal void <AnimateProgress>b__0(float t) { }

		internal void <AnimateProgress>b__1() { }

	}

	[CompilerGenerated]
	private sealed class <LevelUpCoroutine>d__31 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public BWYWSkillLevelProgressBarManager <>4__this; //Field offset: 0x20
		public Action OnComplete; //Field offset: 0x28
		private Vector2 <position>5__2; //Field offset: 0x30

		private override object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		private override object System.Collections.IEnumerator.Current
		{
			[DebuggerHidden]
			private get { } //Length: 8
		}

		[DebuggerHidden]
		public <LevelUpCoroutine>d__31(int <>1__state) { }

		private override bool MoveNext() { }

		[DebuggerHidden]
		private override object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[DebuggerHidden]
		private override object System.Collections.IEnumerator.get_Current() { }

		[DebuggerHidden]
		private override void System.Collections.IEnumerator.Reset() { }

		[DebuggerHidden]
		private override void System.IDisposable.Dispose() { }

	}

	[SerializeField]
	private DeliveryProgressBar _progressBar; //Field offset: 0x20
	[SerializeField]
	private DeliveryProgressBar _nextLevelProgressBar; //Field offset: 0x28
	[SerializeField]
	private TMP_Text _currentXpText; //Field offset: 0x30
	[SerializeField]
	private TMP_Text _targetXpText; //Field offset: 0x38
	[SerializeField]
	private GameObject _currentLevelGameObject; //Field offset: 0x40
	[SerializeField]
	private GameObject _nextLevelTextParentGameObject; //Field offset: 0x48
	[SerializeField]
	private TMP_Text _currentLevelText; //Field offset: 0x50
	[SerializeField]
	private TMP_Text _nextLevelText; //Field offset: 0x58
	[SerializeField]
	private BWYWSkillLevel _nextLevelGameObject; //Field offset: 0x60
	[SerializeField]
	private GameObject _xpTextParent; //Field offset: 0x68
	[SerializeField]
	private GameObject _lastDayIcon; //Field offset: 0x70
	[SerializeField]
	private GameObject _rightFinalIcon; //Field offset: 0x78
	[SerializeField]
	private GameObject _leftFinalIcon; //Field offset: 0x80
	[SerializeField]
	private GameObject _particalSystem; //Field offset: 0x88
	[SerializeField]
	private GameObject _finalTextParent; //Field offset: 0x90
	[SerializeField]
	private TMP_Text _title; //Field offset: 0x98
	private float _lastXPRatio; //Field offset: 0xA0
	private int _currentXp; //Field offset: 0xA4
	private int _currentLevel; //Field offset: 0xA8
	private int _targetXp; //Field offset: 0xAC
	private SkillType _currentSkillType; //Field offset: 0xB0
	private float _levelUpAnimationDurationPart1; //Field offset: 0xB4
	private float _levelUpAnimationDurationPart2; //Field offset: 0xB8
	private float _levelUpAnimationDurationPart3; //Field offset: 0xBC
	private float _levelUpAnimationDurationPart4; //Field offset: 0xC0
	private float _levelUpAnimationDurationPart5; //Field offset: 0xC4
	private float _levelUpAnimationDurationPart6; //Field offset: 0xC8

	public BWYWSkillLevelProgressBarManager() { }

	private void AnimateProgress(float startXp, int endXp, float time) { }

	public void LevelUp(Action OnComplete) { }

	[IteratorStateMachine(typeof(<LevelUpCoroutine>d__31))]
	public IEnumerator LevelUpCoroutine(Action OnComplete) { }

	public void Refresh(SkillType skillType) { }

	public void SetEmpty() { }

	public void SetFinishedState() { }

	public void SetLastDayState() { }

}

