namespace UnityEngine;

[NativeHeader("Runtime/Transform/Transform.h")]
[NativeHeader("Configuration/UnityConfigure.h")]
[NativeHeader("Runtime/Transform/ScriptBindings/TransformScriptBindings.h")]
[RequiredByNativeCode]
public class Transform : Component, IEnumerable
{
	private class Enumerator : IEnumerator
	{
		private Transform outer; //Field offset: 0x10
		private int currentIndex; //Field offset: 0x18

		public override object Current
		{
			 get { } //Length: 76
		}

		internal Enumerator(Transform outer) { }

		public override object get_Current() { }

		public override bool MoveNext() { }

		public override void Reset() { }

	}


	public int childCount
	{
		[NativeMethod("GetChildrenCount")]
		 get { } //Length: 60
	}

	public Vector3 eulerAngles
	{
		 get { } //Length: 48
		 set { } //Length: 48
	}

	public Vector3 forward
	{
		 get { } //Length: 124
	}

	[NativeProperty("HasChangedDeprecated")]
	public bool hasChanged
	{
		 get { } //Length: 60
		 set { } //Length: 68
	}

	public Vector3 localEulerAngles
	{
		 get { } //Length: 48
		 set { } //Length: 48
	}

	public Vector3 localPosition
	{
		 get { } //Length: 92
		 set { } //Length: 84
	}

	public Quaternion localRotation
	{
		 get { } //Length: 88
		 set { } //Length: 84
	}

	public Vector3 localScale
	{
		 get { } //Length: 92
		 set { } //Length: 84
	}

	public Matrix4x4 localToWorldMatrix
	{
		 get { } //Length: 108
	}

	public Vector3 lossyScale
	{
		[NativeMethod("GetWorldScaleLossy")]
		 get { } //Length: 92
	}

	public Transform parent
	{
		 get { } //Length: 60
		 set { } //Length: 204
	}

	internal Transform parentInternal
	{
		internal get { } //Length: 60
		internal set { } //Length: 72
	}

	public Vector3 position
	{
		 get { } //Length: 92
		 set { } //Length: 84
	}

	public Vector3 right
	{
		 get { } //Length: 124
		 set { } //Length: 132
	}

	public Transform root
	{
		 get { } //Length: 60
	}

	public Quaternion rotation
	{
		 get { } //Length: 88
		 set { } //Length: 84
	}

	public Vector3 up
	{
		 get { } //Length: 124
		 set { } //Length: 132
	}

	public Matrix4x4 worldToLocalMatrix
	{
		 get { } //Length: 108
	}

	protected Transform() { }

	[FreeFunction("DetachChildren", HasExplicitThis = True)]
	public void DetachChildren() { }

	public Transform Find(string n) { }

	[FreeFunction]
	private static Transform FindRelativeTransformWithPath(Transform transform, string path, bool isActiveOnly) { }

	[NativeMethod("GetChildrenCount")]
	public int get_childCount() { }

	public Vector3 get_eulerAngles() { }

	public Vector3 get_forward() { }

	public bool get_hasChanged() { }

	public Vector3 get_localEulerAngles() { }

	public Vector3 get_localPosition() { }

	private void get_localPosition_Injected(out Vector3 ret) { }

	public Quaternion get_localRotation() { }

	private void get_localRotation_Injected(out Quaternion ret) { }

	public Vector3 get_localScale() { }

	private void get_localScale_Injected(out Vector3 ret) { }

	public Matrix4x4 get_localToWorldMatrix() { }

	private void get_localToWorldMatrix_Injected(out Matrix4x4 ret) { }

	[NativeMethod("GetWorldScaleLossy")]
	public Vector3 get_lossyScale() { }

	private void get_lossyScale_Injected(out Vector3 ret) { }

	public Transform get_parent() { }

	internal Transform get_parentInternal() { }

	public Vector3 get_position() { }

	private void get_position_Injected(out Vector3 ret) { }

	public Vector3 get_right() { }

	public Transform get_root() { }

	public Quaternion get_rotation() { }

	private void get_rotation_Injected(out Quaternion ret) { }

	public Vector3 get_up() { }

	public Matrix4x4 get_worldToLocalMatrix() { }

	private void get_worldToLocalMatrix_Injected(out Matrix4x4 ret) { }

	[FreeFunction("GetChild", HasExplicitThis = True)]
	[NativeThrows]
	public Transform GetChild(int index) { }

	public override IEnumerator GetEnumerator() { }

	private Transform GetParent() { }

	private Transform GetRoot() { }

	public int GetSiblingIndex() { }

	[FreeFunction("Internal_LookAt", HasExplicitThis = True)]
	private void Internal_LookAt(Vector3 worldPosition, Vector3 worldUp) { }

	private void Internal_LookAt_Injected(ref Vector3 worldPosition, ref Vector3 worldUp) { }

	public Vector3 InverseTransformDirection(Vector3 direction) { }

	private void InverseTransformDirection_Injected(ref Vector3 direction, out Vector3 ret) { }

	public Vector3 InverseTransformPoint(Vector3 position) { }

	private void InverseTransformPoint_Injected(ref Vector3 position, out Vector3 ret) { }

	public Vector3 InverseTransformVector(Vector3 vector) { }

	private void InverseTransformVector_Injected(ref Vector3 vector, out Vector3 ret) { }

	[FreeFunction("Internal_IsChildOrSameTransform", HasExplicitThis = True)]
	public bool IsChildOf(Transform parent) { }

	public void LookAt(Vector3 worldPosition, Vector3 worldUp) { }

	public void LookAt(Transform target, Vector3 worldUp) { }

	public void Rotate(float xAngle, float yAngle, float zAngle) { }

	public void Rotate(Vector3 eulers) { }

	public void Rotate(Vector3 eulers, Space relativeTo) { }

	public void RotateAround(Vector3 point, Vector3 axis, float angle) { }

	[NativeMethod("RotateAround")]
	internal void RotateAroundInternal(Vector3 axis, float angle) { }

	private void RotateAroundInternal_Injected(ref Vector3 axis, float angle) { }

	public void set_eulerAngles(Vector3 value) { }

	public void set_hasChanged(bool value) { }

	public void set_localEulerAngles(Vector3 value) { }

	public void set_localPosition(Vector3 value) { }

	private void set_localPosition_Injected(ref Vector3 value) { }

	public void set_localRotation(Quaternion value) { }

	private void set_localRotation_Injected(ref Quaternion value) { }

	public void set_localScale(Vector3 value) { }

	private void set_localScale_Injected(ref Vector3 value) { }

	public void set_parent(Transform value) { }

	internal void set_parentInternal(Transform value) { }

	public void set_position(Vector3 value) { }

	private void set_position_Injected(ref Vector3 value) { }

	public void set_right(Vector3 value) { }

	public void set_rotation(Quaternion value) { }

	private void set_rotation_Injected(ref Quaternion value) { }

	public void set_up(Vector3 value) { }

	public void SetAsFirstSibling() { }

	public void SetAsLastSibling() { }

	public void SetLocalPositionAndRotation(Vector3 localPosition, Quaternion localRotation) { }

	private void SetLocalPositionAndRotation_Injected(ref Vector3 localPosition, ref Quaternion localRotation) { }

	[FreeFunction("SetParent", HasExplicitThis = True)]
	public void SetParent(Transform parent, bool worldPositionStays) { }

	public void SetParent(Transform p) { }

	public void SetPositionAndRotation(Vector3 position, Quaternion rotation) { }

	private void SetPositionAndRotation_Injected(ref Vector3 position, ref Quaternion rotation) { }

	public void SetSiblingIndex(int index) { }

	public Vector3 TransformDirection(Vector3 direction) { }

	private void TransformDirection_Injected(ref Vector3 direction, out Vector3 ret) { }

	public Vector3 TransformPoint(Vector3 position) { }

	private void TransformPoint_Injected(ref Vector3 position, out Vector3 ret) { }

	public Vector3 TransformVector(Vector3 vector) { }

	private void TransformVector_Injected(ref Vector3 vector, out Vector3 ret) { }

	public void Translate(Vector3 translation, Space relativeTo) { }

}

