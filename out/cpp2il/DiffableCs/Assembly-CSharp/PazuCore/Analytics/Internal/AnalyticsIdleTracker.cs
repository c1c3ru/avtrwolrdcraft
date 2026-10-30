namespace PazuCore.Analytics.Internal;

public class AnalyticsIdleTracker : MonoBehaviour
{
	private const float IDLE_TIME = 60; //Field offset: 0x0
	private float _lastInputTime; //Field offset: 0x20
	private bool _isIdle; //Field offset: 0x24
	private double _activeTime; //Field offset: 0x28

	public double ActiveTime
	{
		 get { } //Length: 8
	}

	public AnalyticsIdleTracker() { }

	public double get_ActiveTime() { }

	private float GetTimeNow() { }

	public void ResetTimer() { }

	private void Update() { }

}

