namespace Unity.Mathematics;

[Il2CppEagerStaticClassConstruction]
public static class noise
{

	public static float2 cellular(float2 P) { }

	public static float2 cellular(float3 P) { }

	public static float2 cellular2x2(float2 P) { }

	public static float2 cellular2x2x2(float3 P) { }

	public static float cnoise(float3 P) { }

	public static float cnoise(float4 P) { }

	public static float cnoise(float2 P) { }

	private static float4 fade(float4 t) { }

	private static float3 fade(float3 t) { }

	private static float2 fade(float2 t) { }

	private static float4 grad4(float j, float4 ip) { }

	private static float mod289(float x) { }

	private static float2 mod289(float2 x) { }

	private static float3 mod289(float3 x) { }

	private static float4 mod289(float4 x) { }

	private static float4 mod7(float4 x) { }

	private static float3 mod7(float3 x) { }

	private static float4 permute(float4 x) { }

	private static float permute(float x) { }

	private static float3 permute(float3 x) { }

	public static float pnoise(float4 P, float4 rep) { }

	public static float pnoise(float3 P, float3 rep) { }

	public static float pnoise(float2 P, float2 rep) { }

	public static float3 psrdnoise(float2 pos, float2 per, float rot) { }

	public static float3 psrdnoise(float2 pos, float2 per) { }

	public static float psrnoise(float2 pos, float2 per, float rot) { }

	public static float psrnoise(float2 pos, float2 per) { }

	private static float2 rgrad2(float2 p, float rot) { }

	public static float snoise(float3 v) { }

	public static float snoise(float2 v) { }

	public static float snoise(float3 v, out float3 gradient) { }

	public static float snoise(float4 v) { }

	public static float3 srdnoise(float2 pos) { }

	public static float3 srdnoise(float2 pos, float rot) { }

	public static float srnoise(float2 pos, float rot) { }

	public static float srnoise(float2 pos) { }

	private static float4 taylorInvSqrt(float4 r) { }

	private static float taylorInvSqrt(float r) { }

}

