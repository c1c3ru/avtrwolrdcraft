namespace UnityEngine;

[NativeHeader("Modules/Animation/AnimatorInfo.h")]
[RequiredByNativeCode]
public struct AnimatorStateInfo
{
	private int m_Name; //Field offset: 0x0
	private int m_Path; //Field offset: 0x4
	private int m_FullPath; //Field offset: 0x8
	private float m_NormalizedTime; //Field offset: 0xC
	private float m_Length; //Field offset: 0x10
	private float m_Speed; //Field offset: 0x14
	private float m_SpeedMultiplier; //Field offset: 0x18
	private int m_Tag; //Field offset: 0x1C
	private int m_Loop; //Field offset: 0x20

	public int fullPathHash
	{
		 get { } //Length: 8
	}

	public float normalizedTime
	{
		 get { } //Length: 8
	}

	public float speed
	{
		 get { } //Length: 8
	}

	public float speedMultiplier
	{
		 get { } //Length: 8
	}

	public int get_fullPathHash() { }

	public float get_normalizedTime() { }

	public float get_speed() { }

	public float get_speedMultiplier() { }

}

