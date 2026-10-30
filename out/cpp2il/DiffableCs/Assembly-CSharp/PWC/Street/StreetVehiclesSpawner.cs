namespace PWC.Street;

public class StreetVehiclesSpawner : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class <SpawnVehicles>d__8 : IEnumerator<Object>, IEnumerator, IDisposable
	{
		private int <>1__state; //Field offset: 0x10
		private object <>2__current; //Field offset: 0x18
		public StreetVehiclesSpawner <>4__this; //Field offset: 0x20

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
		public <SpawnVehicles>d__8(int <>1__state) { }

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

	private enum VehicleType
	{
		Bus = 0,
		Car = 1,
		Truck = 2,
	}

	[SerializeField]
	private Transform _endPoint; //Field offset: 0x20
	[SerializeField]
	private bool _isFacingRight; //Field offset: 0x28
	private GameObject _vehiclePrefab; //Field offset: 0x30
	private VehicleType[] _vehicleTypes; //Field offset: 0x38
	private Dictionary<VehicleType, Sprite> _vehicleSprites; //Field offset: 0x40
	private Dictionary<VehicleType, Sprite> _vehicleLightsSprites; //Field offset: 0x48

	public StreetVehiclesSpawner() { }

	public void Init(float xPosition) { }

	private void SpawnVehicle() { }

	[IteratorStateMachine(typeof(<SpawnVehicles>d__8))]
	private IEnumerator SpawnVehicles() { }

}

