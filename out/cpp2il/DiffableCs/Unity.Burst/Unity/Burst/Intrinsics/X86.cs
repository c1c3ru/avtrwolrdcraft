namespace Unity.Burst.Intrinsics;

[BurstCompile]
public static class X86
{
	internal static class Avx
	{
		internal enum CMP
		{
			EQ_OQ = 0,
			LT_OS = 1,
			LE_OS = 2,
			UNORD_Q = 3,
			NEQ_UQ = 4,
			NLT_US = 5,
			NLE_US = 6,
			ORD_Q = 7,
			EQ_UQ = 8,
			NGE_US = 9,
			NGT_US = 10,
			FALSE_OQ = 11,
			NEQ_OQ = 12,
			GE_OS = 13,
			GT_OS = 14,
			TRUE_UQ = 15,
			EQ_OS = 16,
			LT_OQ = 17,
			LE_OQ = 18,
			UNORD_S = 19,
			NEQ_US = 20,
			NLT_UQ = 21,
			NLE_UQ = 22,
			ORD_S = 23,
			EQ_US = 24,
			NGE_UQ = 25,
			NGT_UQ = 26,
			FALSE_OS = 27,
			NEQ_OS = 28,
			GE_OQ = 29,
			GT_OQ = 30,
			TRUE_US = 31,
		}


		public static bool IsAvxSupported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static v128 broadcast_ss(Void* ptr) { }

		[DebuggerStepThrough]
		public static v128 cmp_pd(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 cmp_ps(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 cmp_sd(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 cmp_ss(v128 a, v128 b, int imm8) { }

		public static bool get_IsAvxSupported() { }

		[DebuggerStepThrough]
		public static v128 maskload_pd(Void* mem_addr, v128 mask) { }

		[DebuggerStepThrough]
		public static v128 maskload_ps(Void* mem_addr, v128 mask) { }

		[DebuggerStepThrough]
		public static void maskstore_pd(Void* mem_addr, v128 mask, v128 a) { }

		[DebuggerStepThrough]
		public static void maskstore_ps(Void* mem_addr, v128 mask, v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_add_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_add_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_addsub_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_addsub_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_and_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_and_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_andnot_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_andnot_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_blend_pd(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_blend_ps(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_blendv_pd(v256 a, v256 b, v256 mask) { }

		[DebuggerStepThrough]
		public static v256 mm256_blendv_ps(v256 a, v256 b, v256 mask) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcast_pd(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcast_ps(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcast_sd(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcast_ss(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_castpd_ps(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_castpd_si256(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_castpd128_pd256(v128 a) { }

		[DebuggerStepThrough]
		public static v128 mm256_castpd256_pd128(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_castps_pd(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_castps_si256(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_castps128_ps256(v128 a) { }

		[DebuggerStepThrough]
		public static v128 mm256_castps256_ps128(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_castsi128_si256(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_castsi256_pd(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_castsi256_ps(v256 a) { }

		[DebuggerStepThrough]
		public static v128 mm256_castsi256_si128(v256 a) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_ceil_pd(v256 val) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_ceil_ps(v256 val) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmp_pd(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmp_ps(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepi32_pd(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepi32_ps(v256 a) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v128 mm256_cvtpd_epi32(v256 a) { }

		[DebuggerStepThrough]
		public static v128 mm256_cvtpd_ps(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtps_epi32(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtps_pd(v128 a) { }

		[DebuggerStepThrough]
		public static float mm256_cvtss_f32(v256 a) { }

		[DebuggerStepThrough]
		public static v128 mm256_cvttpd_epi32(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvttps_epi32(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_div_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_div_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_dp_ps(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static int mm256_extract_epi32(v256 a, int index) { }

		[DebuggerStepThrough]
		public static long mm256_extract_epi64(v256 a, int index) { }

		[DebuggerStepThrough]
		public static v128 mm256_extractf128_pd(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 mm256_extractf128_ps(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 mm256_extractf128_si256(v256 a, int imm8) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_floor_pd(v256 val) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_floor_ps(v256 val) { }

		[DebuggerStepThrough]
		public static v256 mm256_hadd_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_hadd_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_hsub_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_hsub_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_insert_epi16(v256 a, int i, int index) { }

		[DebuggerStepThrough]
		public static v256 mm256_insert_epi32(v256 a, int i, int index) { }

		[DebuggerStepThrough]
		public static v256 mm256_insert_epi64(v256 a, long i, int index) { }

		[DebuggerStepThrough]
		public static v256 mm256_insert_epi8(v256 a, int i, int index) { }

		[DebuggerStepThrough]
		public static v256 mm256_insertf128_pd(v256 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_insertf128_ps(v256 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_insertf128_si256(v256 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_lddqu_si256(Void* mem_addr) { }

		[DebuggerStepThrough]
		public static v256 mm256_load_pd(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_load_ps(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_load_si256(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_loadu_pd(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_loadu_ps(Void* ptr) { }

		[DebuggerStepThrough]
		public static v256 mm256_loadu_si256(Void* ptr) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_loadu2_m128(Void* hiaddr, Void* loaddr) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_loadu2_m128d(Void* hiaddr, Void* loaddr) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_loadu2_m128i(Void* hiaddr, Void* loaddr) { }

		[DebuggerStepThrough]
		public static v256 mm256_maskload_pd(Void* mem_addr, v256 mask) { }

		[DebuggerStepThrough]
		public static v256 mm256_maskload_ps(Void* mem_addr, v256 mask) { }

		[DebuggerStepThrough]
		public static void mm256_maskstore_pd(Void* mem_addr, v256 mask, v256 a) { }

		[DebuggerStepThrough]
		public static void mm256_maskstore_ps(Void* mem_addr, v256 mask, v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_max_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_max_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_min_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_min_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_movedup_pd(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_movehdup_ps(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_moveldup_ps(v256 a) { }

		[DebuggerStepThrough]
		public static int mm256_movemask_pd(v256 a) { }

		[DebuggerStepThrough]
		public static int mm256_movemask_ps(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_mul_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_mul_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_or_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_or_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_permute_pd(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_permute_ps(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_permute2f128_pd(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_permute2f128_ps(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_permute2f128_si256(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_permutevar_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_permutevar_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_rcp_ps(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_round_pd(v256 a, int rounding) { }

		[DebuggerStepThrough]
		public static v256 mm256_round_ps(v256 a, int rounding) { }

		[DebuggerStepThrough]
		public static v256 mm256_rsqrt_ps(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_epi16(short e15_, short e14_, short e13_, short e12_, short e11_, short e10_, short e9_, short e8_, short e7_, short e6_, short e5_, short e4_, short e3_, short e2_, short e1_, short e0_) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_epi32(int e7, int e6, int e5, int e4, int e3, int e2, int e1, int e0) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_epi64x(long e3, long e2, long e1, long e0) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_epi8(byte e31_, byte e30_, byte e29_, byte e28_, byte e27_, byte e26_, byte e25_, byte e24_, byte e23_, byte e22_, byte e21_, byte e20_, byte e19_, byte e18_, byte e17_, byte e16_, byte e15_, byte e14_, byte e13_, byte e12_, byte e11_, byte e10_, byte e9_, byte e8_, byte e7_, byte e6_, byte e5_, byte e4_, byte e3_, byte e2_, byte e1_, byte e0_) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_m128(v128 hi, v128 lo) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_m128d(v128 hi, v128 lo) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_m128i(v128 hi, v128 lo) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_pd(double d, double c, double b, double a) { }

		[DebuggerStepThrough]
		public static v256 mm256_set_ps(float e7, float e6, float e5, float e4, float e3, float e2, float e1, float e0) { }

		[DebuggerStepThrough]
		public static v256 mm256_set1_epi16(short a) { }

		[DebuggerStepThrough]
		public static v256 mm256_set1_epi32(int a) { }

		[DebuggerStepThrough]
		public static v256 mm256_set1_epi64x(long a) { }

		[DebuggerStepThrough]
		public static v256 mm256_set1_epi8(byte a) { }

		[DebuggerStepThrough]
		public static v256 mm256_set1_pd(double a) { }

		[DebuggerStepThrough]
		public static v256 mm256_set1_ps(float a) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_epi16(short e15_, short e14_, short e13_, short e12_, short e11_, short e10_, short e9_, short e8_, short e7_, short e6_, short e5_, short e4_, short e3_, short e2_, short e1_, short e0_) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_epi32(int e7, int e6, int e5, int e4, int e3, int e2, int e1, int e0) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_epi64x(long e3, long e2, long e1, long e0) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_epi8(byte e31_, byte e30_, byte e29_, byte e28_, byte e27_, byte e26_, byte e25_, byte e24_, byte e23_, byte e22_, byte e21_, byte e20_, byte e19_, byte e18_, byte e17_, byte e16_, byte e15_, byte e14_, byte e13_, byte e12_, byte e11_, byte e10_, byte e9_, byte e8_, byte e7_, byte e6_, byte e5_, byte e4_, byte e3_, byte e2_, byte e1_, byte e0_) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_m128(v128 hi, v128 lo) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_m128d(v128 hi, v128 lo) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_m128i(v128 hi, v128 lo) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_pd(double d, double c, double b, double a) { }

		[DebuggerStepThrough]
		public static v256 mm256_setr_ps(float e7, float e6, float e5, float e4, float e3, float e2, float e1, float e0) { }

		[DebuggerStepThrough]
		public static v256 mm256_setzero_pd() { }

		[DebuggerStepThrough]
		public static v256 mm256_setzero_ps() { }

		[DebuggerStepThrough]
		public static v256 mm256_setzero_si256() { }

		[DebuggerStepThrough]
		public static v256 mm256_shuffle_pd(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_shuffle_ps(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_sqrt_pd(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_sqrt_ps(v256 a) { }

		[DebuggerStepThrough]
		public static void mm256_store_pd(Void* ptr, v256 a) { }

		[DebuggerStepThrough]
		public static void mm256_store_ps(Void* ptr, v256 val) { }

		[DebuggerStepThrough]
		public static void mm256_store_si256(Void* ptr, v256 v) { }

		[DebuggerStepThrough]
		public static void mm256_storeu_pd(Void* ptr, v256 a) { }

		[DebuggerStepThrough]
		public static void mm256_storeu_ps(Void* ptr, v256 a) { }

		[DebuggerStepThrough]
		public static void mm256_storeu_si256(Void* ptr, v256 v) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static void mm256_storeu2_m128(Void* hiaddr, Void* loaddr, v256 val) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static void mm256_storeu2_m128d(Void* hiaddr, Void* loaddr, v256 val) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static void mm256_storeu2_m128i(Void* hiaddr, Void* loaddr, v256 val) { }

		[DebuggerStepThrough]
		public static void mm256_stream_pd(Void* mem_addr, v256 a) { }

		[DebuggerStepThrough]
		public static void mm256_stream_ps(Void* mem_addr, v256 a) { }

		[DebuggerStepThrough]
		public static void mm256_stream_si256(Void* mem_addr, v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_sub_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_sub_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testc_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testc_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testc_si256(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testnzc_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testnzc_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testnzc_si256(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testz_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testz_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_testz_si256(v256 a, v256 b) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_undefined_pd() { }

		[DebuggerStepThrough]
		public static v256 mm256_undefined_ps() { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_undefined_si256() { }

		[DebuggerStepThrough]
		public static v256 mm256_unpackhi_pd(v256 a, v256 b) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_unpackhi_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpacklo_pd(v256 a, v256 b) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_unpacklo_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_xor_pd(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_xor_ps(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static void mm256_zeroall() { }

		[DebuggerStepThrough]
		public static void mm256_zeroupper() { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_zextpd128_pd256(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_zextps128_ps256(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v256 mm256_zextsi128_si256(v128 a) { }

		[DebuggerStepThrough]
		public static v128 permute_pd(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 permute_ps(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 permutevar_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 permutevar_ps(v128 a, v128 b) { }

		private static v128 Select4(v256 src1, v256 src2, int control) { }

		[DebuggerStepThrough]
		public static int testc_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int testc_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int testnzc_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int testnzc_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int testz_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int testz_ps(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v128 undefined_pd() { }

		[DebuggerStepThrough]
		public static v128 undefined_ps() { }

		[BurstTargetCpu(BurstTargetCpu::AVX (5))]
		[DebuggerStepThrough]
		public static v128 undefined_si128() { }

	}

	internal static class Avx2
	{

		public static bool IsAvx2Supported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static v128 blend_epi32(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 broadcastb_epi8(v128 a) { }

		[DebuggerStepThrough]
		public static v128 broadcastd_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 broadcastq_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 broadcastsd_pd(v128 a) { }

		[DebuggerStepThrough]
		public static v128 broadcastss_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 broadcastw_epi16(v128 a) { }

		private static void EmulatedGather(T* dptr, Void* base_addr, Int64* indexPtr, int scale, int n, U* mask) { }

		private static void EmulatedGather(T* dptr, Void* base_addr, Int32* indexPtr, int scale, int n, U* mask) { }

		public static bool get_IsAvx2Supported() { }

		[DebuggerStepThrough]
		public static v128 i32gather_epi32(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 i32gather_epi64(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 i32gather_pd(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 i32gather_ps(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 i64gather_epi32(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 i64gather_epi64(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 i64gather_pd(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 i64gather_ps(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 mask_i32gather_epi32(v128 src, Void* base_addr, v128 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mask_i32gather_epi64(v128 src, Void* base_addr, v128 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mask_i32gather_pd(v128 src, Void* base_addr, v128 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mask_i32gather_ps(v128 src, Void* base_addr, v128 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mask_i64gather_epi32(v128 src, Void* base_addr, v128 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mask_i64gather_epi64(v128 src, Void* base_addr, v128 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mask_i64gather_pd(v128 src, Void* base_addr, v128 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mask_i64gather_ps(v128 src, Void* base_addr, v128 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 maskload_epi32(Void* mem_addr, v128 mask) { }

		[DebuggerStepThrough]
		public static v128 maskload_epi64(Void* mem_addr, v128 mask) { }

		[DebuggerStepThrough]
		public static void maskstore_epi32(Void* mem_addr, v128 mask, v128 a) { }

		[DebuggerStepThrough]
		public static void maskstore_epi64(Void* mem_addr, v128 mask, v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_abs_epi16(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_abs_epi32(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_abs_epi8(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_add_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_add_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_add_epi64(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_add_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_adds_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_adds_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_adds_epu16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_adds_epu8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_alignr_epi8(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_and_si256(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_andnot_si256(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_avg_epu16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_avg_epu8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_blend_epi16(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_blend_epi32(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_blendv_epi8(v256 a, v256 b, v256 mask) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcastb_epi8(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcastd_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcastq_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcastsd_pd(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcastsi128_si256(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcastss_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_broadcastw_epi16(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_bslli_epi128(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_bsrli_epi128(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmpeq_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmpeq_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmpeq_epi64(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmpeq_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmpgt_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmpgt_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmpgt_epi64(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_cmpgt_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepi16_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepi16_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepi32_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepi8_epi16(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepi8_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepi8_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepu16_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepu16_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepu32_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepu8_epi16(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepu8_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtepu8_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static double mm256_cvtsd_f64(v256 a) { }

		[DebuggerStepThrough]
		public static int mm256_cvtsi256_si32(v256 a) { }

		[DebuggerStepThrough]
		public static long mm256_cvtsi256_si64(v256 a) { }

		[DebuggerStepThrough]
		public static int mm256_extract_epi16(v256 a, int index) { }

		[DebuggerStepThrough]
		public static int mm256_extract_epi8(v256 a, int index) { }

		[DebuggerStepThrough]
		public static v128 mm256_extracti128_si256(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_hadd_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_hadd_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_hadds_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_hsub_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_hsub_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_hsubs_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_i32gather_epi32(Void* base_addr, v256 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_i32gather_epi64(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_i32gather_pd(Void* base_addr, v128 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_i32gather_ps(Void* base_addr, v256 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 mm256_i64gather_epi32(Void* base_addr, v256 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_i64gather_epi64(Void* base_addr, v256 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_i64gather_pd(Void* base_addr, v256 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v128 mm256_i64gather_ps(Void* base_addr, v256 vindex, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_inserti128_si256(v256 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_madd_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_maddubs_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_mask_i32gather_epi32(v256 src, Void* base_addr, v256 vindex, v256 mask, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_mask_i32gather_epi64(v256 src, Void* base_addr, v128 vindex, v256 mask, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_mask_i32gather_pd(v256 src, Void* base_addr, v128 vindex, v256 mask, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_mask_i32gather_ps(v256 src, Void* base_addr, v256 vindex, v256 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mm256_mask_i64gather_epi32(v128 src, Void* base_addr, v256 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_mask_i64gather_epi64(v256 src, Void* base_addr, v256 vindex, v256 mask, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_mask_i64gather_pd(v256 src, Void* base_addr, v256 vindex, v256 mask, int scale) { }

		[DebuggerStepThrough]
		public static v128 mm256_mask_i64gather_ps(v128 src, Void* base_addr, v256 vindex, v128 mask, int scale) { }

		[DebuggerStepThrough]
		public static v256 mm256_maskload_epi32(Void* mem_addr, v256 mask) { }

		[DebuggerStepThrough]
		public static v256 mm256_maskload_epi64(Void* mem_addr, v256 mask) { }

		[DebuggerStepThrough]
		public static void mm256_maskstore_epi32(Void* mem_addr, v256 mask, v256 a) { }

		[DebuggerStepThrough]
		public static void mm256_maskstore_epi64(Void* mem_addr, v256 mask, v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_max_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_max_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_max_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_max_epu16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_max_epu32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_max_epu8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_min_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_min_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_min_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_min_epu16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_min_epu32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_min_epu8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static int mm256_movemask_epi8(v256 a) { }

		[DebuggerStepThrough]
		public static v256 mm256_mpsadbw_epu8(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_mul_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_mul_epu32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_mulhi_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_mulhi_epu16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_mulhrs_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_mullo_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_mullo_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_or_si256(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_packs_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_packs_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_packus_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_packus_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_permute2x128_si256(v256 a, v256 b, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_permute4x64_epi64(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_permute4x64_pd(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_permutevar8x32_epi32(v256 a, v256 idx) { }

		[DebuggerStepThrough]
		public static v256 mm256_permutevar8x32_ps(v256 a, v256 idx) { }

		[DebuggerStepThrough]
		public static v256 mm256_sad_epu8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_shuffle_epi32(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_shuffle_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_shufflehi_epi16(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_shufflelo_epi16(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_sign_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_sign_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_sign_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_sll_epi16(v256 a, v128 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_sll_epi32(v256 a, v128 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_sll_epi64(v256 a, v128 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_slli_epi16(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_slli_epi32(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_slli_epi64(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_slli_si256(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_sllv_epi32(v256 a, v256 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_sllv_epi64(v256 a, v256 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_sra_epi16(v256 a, v128 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_sra_epi32(v256 a, v128 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_srai_epi16(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_srai_epi32(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_srav_epi32(v256 a, v256 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_srl_epi16(v256 a, v128 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_srl_epi32(v256 a, v128 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_srl_epi64(v256 a, v128 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_srli_epi16(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_srli_epi32(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_srli_epi64(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_srli_si256(v256 a, int imm8) { }

		[DebuggerStepThrough]
		public static v256 mm256_srlv_epi32(v256 a, v256 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_srlv_epi64(v256 a, v256 count) { }

		[DebuggerStepThrough]
		public static v256 mm256_stream_load_si256(Void* mem_addr) { }

		[DebuggerStepThrough]
		public static v256 mm256_sub_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_sub_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_sub_epi64(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_sub_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_subs_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_subs_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_subs_epu16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_subs_epu8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpackhi_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpackhi_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpackhi_epi64(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpackhi_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpacklo_epi16(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpacklo_epi32(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpacklo_epi64(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_unpacklo_epi8(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v256 mm256_xor_si256(v256 a, v256 b) { }

		[DebuggerStepThrough]
		public static v128 sllv_epi32(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 sllv_epi64(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 srav_epi32(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 srlv_epi32(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 srlv_epi64(v128 a, v128 count) { }

	}

	internal static class Bmi1
	{

		public static bool IsBmi1Supported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static uint andn_u32(uint a, uint b) { }

		[DebuggerStepThrough]
		public static ulong andn_u64(ulong a, ulong b) { }

		[DebuggerStepThrough]
		public static uint bextr_u32(uint a, uint start, uint len) { }

		[DebuggerStepThrough]
		public static ulong bextr_u64(ulong a, uint start, uint len) { }

		[DebuggerStepThrough]
		public static uint bextr2_u32(uint a, uint control) { }

		[DebuggerStepThrough]
		public static ulong bextr2_u64(ulong a, ulong control) { }

		[DebuggerStepThrough]
		public static uint blsi_u32(uint a) { }

		[DebuggerStepThrough]
		public static ulong blsi_u64(ulong a) { }

		[DebuggerStepThrough]
		public static uint blsmsk_u32(uint a) { }

		[DebuggerStepThrough]
		public static ulong blsmsk_u64(ulong a) { }

		[DebuggerStepThrough]
		public static uint blsr_u32(uint a) { }

		[DebuggerStepThrough]
		public static ulong blsr_u64(ulong a) { }

		public static bool get_IsBmi1Supported() { }

		[DebuggerStepThrough]
		public static uint tzcnt_u32(uint a) { }

		[DebuggerStepThrough]
		public static ulong tzcnt_u64(ulong a) { }

	}

	internal static class Bmi2
	{

		public static bool IsBmi2Supported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static uint bzhi_u32(uint a, uint index) { }

		[DebuggerStepThrough]
		public static ulong bzhi_u64(ulong a, ulong index) { }

		public static bool get_IsBmi2Supported() { }

		[DebuggerStepThrough]
		public static uint mulx_u32(uint a, uint b, out uint hi) { }

		[DebuggerStepThrough]
		public static ulong mulx_u64(ulong a, ulong b, out ulong hi) { }

		[DebuggerStepThrough]
		public static uint pdep_u32(uint a, uint mask) { }

		[DebuggerStepThrough]
		public static ulong pdep_u64(ulong a, ulong mask) { }

		[DebuggerStepThrough]
		public static uint pext_u32(uint a, uint mask) { }

		[DebuggerStepThrough]
		public static ulong pext_u64(ulong a, ulong mask) { }

	}

	public static class DoGetCSRTrampoline_0000012A$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0
		private static IntPtr DeferredCompilation; //Field offset: 0x8

		private static DoGetCSRTrampoline_0000012A$BurstDirectCall() { }

		public static void Constructor() { }

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static void Initialize() { }

		public static int Invoke() { }

	}

	public sealed class DoGetCSRTrampoline_0000012A$PostfixBurstDelegate : MulticastDelegate
	{

		public DoGetCSRTrampoline_0000012A$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(AsyncCallback unnamed_param_0, object unnamed_param_1) { }

		public override int EndInvoke(IAsyncResult unnamed_param_0) { }

		public override int Invoke() { }

	}

	public static class DoSetCSRTrampoline_00000129$BurstDirectCall
	{
		private static IntPtr Pointer; //Field offset: 0x0
		private static IntPtr DeferredCompilation; //Field offset: 0x8

		private static DoSetCSRTrampoline_00000129$BurstDirectCall() { }

		public static void Constructor() { }

		private static IntPtr GetFunctionPointer() { }

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr unnamed_param_0) { }

		public static void Initialize() { }

		public static void Invoke(int bits) { }

	}

	public sealed class DoSetCSRTrampoline_00000129$PostfixBurstDelegate : MulticastDelegate
	{

		public DoSetCSRTrampoline_00000129$PostfixBurstDelegate(object unnamed_param_0, IntPtr unnamed_param_1) { }

		public override IAsyncResult BeginInvoke(int bits, AsyncCallback unnamed_param_1, object unnamed_param_2) { }

		public override void EndInvoke(IAsyncResult unnamed_param_0) { }

		public override void Invoke(int bits) { }

	}

	internal static class F16C
	{
		private static readonly UInt16[] BaseTable; //Field offset: 0x0
		private static readonly SByte[] ShiftTable; //Field offset: 0x8

		public static bool IsF16CSupported
		{
			 get { } //Length: 8
		}

		private static F16C() { }

		[DebuggerStepThrough]
		public static v128 cvtph_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtps_ph(v128 a, int rounding) { }

		[DebuggerStepThrough]
		private static ushort FloatToHalf(uint f, int rounding) { }

		public static bool get_IsF16CSupported() { }

		[DebuggerStepThrough]
		private static uint HalfToFloat(ushort h) { }

		[DebuggerStepThrough]
		public static v256 mm256_cvtph_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 mm256_cvtps_ph(v256 a, int rounding) { }

	}

	internal static class Fma
	{
		private struct Union
		{
			public float f; //Field offset: 0x0
			public uint u; //Field offset: 0x0

		}


		public static bool IsFmaSupported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static v128 fmadd_pd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmadd_ps(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmadd_sd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmadd_ss(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmaddsub_pd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmaddsub_ps(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		private static float FmaHelper(float a, float b, float c) { }

		[DebuggerStepThrough]
		public static v128 fmsub_pd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmsub_ps(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmsub_sd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmsub_ss(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmsubadd_pd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fmsubadd_ps(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fnmadd_pd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fnmadd_ps(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fnmadd_sd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fnmadd_ss(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		private static float FnmaHelper(float a, float b, float c) { }

		[DebuggerStepThrough]
		public static v128 fnmsub_pd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fnmsub_ps(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fnmsub_sd(v128 a, v128 b, v128 c) { }

		[DebuggerStepThrough]
		public static v128 fnmsub_ss(v128 a, v128 b, v128 c) { }

		public static bool get_IsFmaSupported() { }

		[DebuggerStepThrough]
		public static v256 mm256_fmadd_pd(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fmadd_ps(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fmaddsub_pd(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fmaddsub_ps(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fmsub_pd(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fmsub_ps(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fmsubadd_pd(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fmsubadd_ps(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fnmadd_pd(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fnmadd_ps(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fnmsub_pd(v256 a, v256 b, v256 c) { }

		[DebuggerStepThrough]
		public static v256 mm256_fnmsub_ps(v256 a, v256 b, v256 c) { }

	}

	[Flags]
	internal enum MXCSRBits
	{
		FlushToZero = 32768,
		RoundingControlMask = 24576,
		RoundToNearest = 0,
		RoundDown = 8192,
		RoundUp = 16384,
		RoundTowardZero = 24576,
		PrecisionMask = 4096,
		UnderflowMask = 2048,
		OverflowMask = 1024,
		DivideByZeroMask = 512,
		DenormalOperationMask = 256,
		InvalidOperationMask = 128,
		ExceptionMask = 8064,
		DenormalsAreZeroes = 64,
		PrecisionFlag = 32,
		UnderflowFlag = 16,
		OverflowFlag = 8,
		DivideByZeroFlag = 4,
		DenormalFlag = 2,
		InvalidOperationFlag = 1,
		FlagMask = 63,
	}

	internal static class Popcnt
	{

		public static bool IsPopcntSupported
		{
			 get { } //Length: 80
		}

		public static bool get_IsPopcntSupported() { }

		[DebuggerStepThrough]
		public static int popcnt_u32(uint v) { }

		[DebuggerStepThrough]
		public static int popcnt_u64(ulong v) { }

	}

	[Flags]
	internal enum RoundingMode
	{
		FROUND_TO_NEAREST_INT = 0,
		FROUND_TO_NEG_INF = 1,
		FROUND_TO_POS_INF = 2,
		FROUND_TO_ZERO = 3,
		FROUND_CUR_DIRECTION = 4,
		FROUND_RAISE_EXC = 0,
		FROUND_NO_EXC = 8,
		FROUND_NINT = 0,
		FROUND_FLOOR = 1,
		FROUND_CEIL = 2,
		FROUND_TRUNC = 3,
		FROUND_RINT = 4,
		FROUND_NEARBYINT = 12,
		FROUND_NINT_NOEXC = 8,
		FROUND_FLOOR_NOEXC = 9,
		FROUND_CEIL_NOEXC = 10,
		FROUND_TRUNC_NOEXC = 11,
		FROUND_RINT_NOEXC = 12,
	}

	public struct RoundingScope : IDisposable
	{
		private MXCSRBits OldBits; //Field offset: 0x0

		public RoundingScope(MXCSRBits roundingMode) { }

		public override void Dispose() { }

	}

	internal static class Sse
	{

		public static bool IsSseSupported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static v128 add_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 add_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 and_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 andnot_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpeq_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpeq_ss(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpge_ps(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpge_ss(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpgt_ps(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpgt_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmple_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmple_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmplt_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmplt_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpneq_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpneq_ss(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpnge_ps(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpnge_ss(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpngt_ps(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpngt_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnle_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnle_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnlt_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnlt_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpord_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpord_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpunord_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpunord_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comieq_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comige_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comigt_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comile_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comilt_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comineq_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int cvt_ss2si(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtsi32_ss(v128 a, int b) { }

		[DebuggerStepThrough]
		public static v128 cvtsi64_ss(v128 a, long b) { }

		[DebuggerStepThrough]
		public static float cvtss_f32(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static int cvtss_si32(v128 a) { }

		[DebuggerStepThrough]
		public static long cvtss_si64(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static int cvtt_ss2si(v128 a) { }

		[DebuggerStepThrough]
		public static int cvttss_si32(v128 a) { }

		[DebuggerStepThrough]
		public static long cvttss_si64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 div_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 div_ss(v128 a, v128 b) { }

		public static bool get_IsSseSupported() { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 load_ps(Void* ptr) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 loadu_ps(Void* ptr) { }

		[DebuggerStepThrough]
		public static v128 loadu_si16(Void* mem_addr) { }

		[DebuggerStepThrough]
		public static v128 loadu_si64(Void* mem_addr) { }

		[DebuggerStepThrough]
		public static v128 max_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 max_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 move_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 movehl_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 movelh_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int movemask_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 mul_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 mul_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 or_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 rcp_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 rcp_ss(v128 a) { }

		[DebuggerStepThrough]
		public static v128 rsqrt_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 rsqrt_ss(v128 a) { }

		[DebuggerStepThrough]
		public static v128 set_ps(float e3, float e2, float e1, float e0) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 set_ps1(float a) { }

		[DebuggerStepThrough]
		public static v128 set_ss(float a) { }

		[DebuggerStepThrough]
		public static v128 set1_ps(float a) { }

		[DebuggerStepThrough]
		public static v128 setr_ps(float e3, float e2, float e1, float e0) { }

		[DebuggerStepThrough]
		public static v128 setzero_ps() { }

		public static int SHUFFLE(int d, int c, int b, int a) { }

		[DebuggerStepThrough]
		public static v128 shuffle_ps(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 sqrt_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 sqrt_ss(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static void store_ps(Void* ptr, v128 val) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static void storeu_ps(Void* ptr, v128 val) { }

		public static void storeu_si16(Void* mem_addr, v128 a) { }

		[DebuggerStepThrough]
		public static void storeu_si64(Void* mem_addr, v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static void stream_ps(Void* mem_addr, v128 a) { }

		[DebuggerStepThrough]
		public static v128 sub_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sub_ss(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static void TRANSPOSE4_PS(ref v128 row0, ref v128 row1, ref v128 row2, ref v128 row3) { }

		[DebuggerStepThrough]
		public static int ucomieq_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomige_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomigt_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomile_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomilt_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomineq_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpackhi_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpacklo_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 xor_ps(v128 a, v128 b) { }

	}

	internal static class Sse2
	{

		public static bool IsSse2Supported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static v128 add_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 add_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 add_epi64(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 add_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 add_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 add_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 adds_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 adds_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 adds_epu16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 adds_epu8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 and_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 and_si128(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 andnot_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 andnot_si128(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 avg_epu16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 avg_epu8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 bslli_si128(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 bsrli_si128(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static void clflush(Void* ptr) { }

		[DebuggerStepThrough]
		public static v128 cmpeq_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpeq_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpeq_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpeq_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpeq_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpge_pd(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpge_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpgt_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpgt_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpgt_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpgt_pd(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpgt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmple_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmple_sd(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmplt_epi16(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmplt_epi32(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmplt_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmplt_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmplt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpneq_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpneq_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnge_pd(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpnge_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpngt_pd(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cmpngt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnle_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnle_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnlt_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpnlt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpord_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpord_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpunord_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpunord_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comieq_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comige_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comigt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comile_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comilt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int comineq_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cvtepi32_pd(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepi32_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtpd_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtpd_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtps_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtps_pd(v128 a) { }

		[DebuggerStepThrough]
		public static double cvtsd_f64(v128 a) { }

		[DebuggerStepThrough]
		public static int cvtsd_si32(v128 a) { }

		[DebuggerStepThrough]
		public static long cvtsd_si64(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static long cvtsd_si64x(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtsd_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int cvtsi128_si32(v128 a) { }

		[DebuggerStepThrough]
		public static long cvtsi128_si64(v128 a) { }

		[DebuggerStepThrough]
		public static long cvtsi128_si64x(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtsi32_sd(v128 a, int b) { }

		[DebuggerStepThrough]
		public static v128 cvtsi32_si128(int a) { }

		[DebuggerStepThrough]
		public static v128 cvtsi64_sd(v128 a, long b) { }

		[DebuggerStepThrough]
		public static v128 cvtsi64_si128(long a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 cvtsi64x_sd(v128 a, long b) { }

		[DebuggerStepThrough]
		public static v128 cvtsi64x_si128(long a) { }

		[DebuggerStepThrough]
		public static v128 cvtss_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cvttpd_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvttps_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static int cvttsd_si32(v128 a) { }

		[DebuggerStepThrough]
		public static long cvttsd_si64(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static long cvttsd_si64x(v128 a) { }

		[DebuggerStepThrough]
		public static v128 div_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 div_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static ushort extract_epi16(v128 a, int imm8) { }

		public static bool get_IsSse2Supported() { }

		[DebuggerStepThrough]
		public static v128 insert_epi16(v128 a, int i, int imm8) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 load_si128(Void* ptr) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 loadu_si128(Void* ptr) { }

		public static v128 loadu_si32(Void* mem_addr) { }

		[DebuggerStepThrough]
		public static v128 madd_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 max_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 max_epu8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 max_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 max_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_epu8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 move_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 move_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int movemask_epi8(v128 a) { }

		[DebuggerStepThrough]
		public static int movemask_pd(v128 a) { }

		[DebuggerStepThrough]
		public static v128 mul_epu32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 mul_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 mul_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 mulhi_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 mulhi_epu16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 mullo_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 or_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 or_si128(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 packs_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 packs_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 packus_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sad_epu8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 set_epi16(short e7, short e6, short e5, short e4, short e3, short e2, short e1, short e0) { }

		[DebuggerStepThrough]
		public static v128 set_epi32(int e3, int e2, int e1, int e0) { }

		[DebuggerStepThrough]
		public static v128 set_epi64x(long e1, long e0) { }

		[DebuggerStepThrough]
		public static v128 set_epi8(sbyte e15_, sbyte e14_, sbyte e13_, sbyte e12_, sbyte e11_, sbyte e10_, sbyte e9_, sbyte e8_, sbyte e7_, sbyte e6_, sbyte e5_, sbyte e4_, sbyte e3_, sbyte e2_, sbyte e1_, sbyte e0_) { }

		[DebuggerStepThrough]
		public static v128 set_pd(double e1, double e0) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static v128 set_pd1(double a) { }

		[DebuggerStepThrough]
		public static v128 set_sd(double a) { }

		[DebuggerStepThrough]
		public static v128 set1_epi16(short a) { }

		[DebuggerStepThrough]
		public static v128 set1_epi32(int a) { }

		[DebuggerStepThrough]
		public static v128 set1_epi64x(long a) { }

		[DebuggerStepThrough]
		public static v128 set1_epi8(sbyte a) { }

		[DebuggerStepThrough]
		public static v128 set1_pd(double a) { }

		[DebuggerStepThrough]
		public static v128 setr_epi16(short e7, short e6, short e5, short e4, short e3, short e2, short e1, short e0) { }

		[DebuggerStepThrough]
		public static v128 setr_epi32(int e3, int e2, int e1, int e0) { }

		[DebuggerStepThrough]
		public static v128 setr_epi8(sbyte e15_, sbyte e14_, sbyte e13_, sbyte e12_, sbyte e11_, sbyte e10_, sbyte e9_, sbyte e8_, sbyte e7_, sbyte e6_, sbyte e5_, sbyte e4_, sbyte e3_, sbyte e2_, sbyte e1_, sbyte e0_) { }

		[DebuggerStepThrough]
		public static v128 setr_pd(double e1, double e0) { }

		[DebuggerStepThrough]
		public static v128 setzero_si128() { }

		[DebuggerStepThrough]
		public static v128 shuffle_epi32(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 shuffle_pd(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static int SHUFFLE2(int x, int y) { }

		[DebuggerStepThrough]
		public static v128 shufflehi_epi16(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 shufflelo_epi16(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 sll_epi16(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 sll_epi32(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 sll_epi64(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 slli_epi16(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 slli_epi32(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 slli_epi64(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 slli_si128(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 sqrt_pd(v128 a) { }

		[DebuggerStepThrough]
		public static v128 sqrt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sra_epi16(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 sra_epi32(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 srai_epi16(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 srai_epi32(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 srl_epi16(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 srl_epi32(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 srl_epi64(v128 a, v128 count) { }

		[DebuggerStepThrough]
		public static v128 srli_epi16(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 srli_epi32(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 srli_epi64(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static v128 srli_si128(v128 a, int imm8) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static void store_si128(Void* ptr, v128 val) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		[DebuggerStepThrough]
		public static void storeu_si128(Void* ptr, v128 val) { }

		public static void storeu_si32(Void* mem_addr, v128 a) { }

		[DebuggerStepThrough]
		public static void stream_pd(Void* mem_addr, v128 a) { }

		[DebuggerStepThrough]
		public static void stream_si128(Void* mem_addr, v128 a) { }

		[DebuggerStepThrough]
		public static void stream_si32(Int32* mem_addr, int a) { }

		[DebuggerStepThrough]
		public static void stream_si64(Int64* mem_addr, long a) { }

		[DebuggerStepThrough]
		public static v128 sub_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sub_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sub_epi64(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sub_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sub_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sub_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 subs_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 subs_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 subs_epu16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 subs_epu8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomieq_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomige_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomigt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomile_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomilt_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int ucomineq_sd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpackhi_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpackhi_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpackhi_epi64(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpackhi_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpackhi_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpacklo_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpacklo_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpacklo_epi64(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpacklo_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 unpacklo_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 xor_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 xor_si128(v128 a, v128 b) { }

	}

	internal static class Sse3
	{

		public static bool IsSse3Supported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static v128 addsub_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 addsub_ps(v128 a, v128 b) { }

		public static bool get_IsSse3Supported() { }

		[DebuggerStepThrough]
		public static v128 hadd_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 hadd_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 hsub_pd(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 hsub_ps(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 movedup_pd(v128 a) { }

		[DebuggerStepThrough]
		public static v128 movehdup_ps(v128 a) { }

		[DebuggerStepThrough]
		public static v128 moveldup_ps(v128 a) { }

	}

	internal static class Sse4_1
	{

		public static bool IsSse41Supported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static v128 blend_epi16(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 blend_pd(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 blend_ps(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 blendv_epi8(v128 a, v128 b, v128 mask) { }

		[DebuggerStepThrough]
		public static v128 blendv_pd(v128 a, v128 b, v128 mask) { }

		[DebuggerStepThrough]
		public static v128 blendv_ps(v128 a, v128 b, v128 mask) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static v128 ceil_pd(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static v128 ceil_ps(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static v128 ceil_sd(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static v128 ceil_ss(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cmpeq_epi64(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 cvtepi16_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepi16_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepi32_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepi8_epi16(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepi8_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepi8_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepu16_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepu16_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepu32_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepu8_epi16(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepu8_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 cvtepu8_epi64(v128 a) { }

		[DebuggerStepThrough]
		public static v128 dp_pd(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 dp_ps(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static int extract_epi32(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static long extract_epi64(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static byte extract_epi8(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static int extract_ps(v128 a, int imm8) { }

		[DebuggerStepThrough]
		public static float extractf_ps(v128 a, int imm8) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static v128 floor_pd(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static v128 floor_ps(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static v128 floor_sd(v128 a, v128 b) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static v128 floor_ss(v128 a, v128 b) { }

		public static bool get_IsSse41Supported() { }

		[DebuggerStepThrough]
		public static v128 insert_epi32(v128 a, int i, int imm8) { }

		[DebuggerStepThrough]
		public static v128 insert_epi64(v128 a, long i, int imm8) { }

		[DebuggerStepThrough]
		public static v128 insert_epi8(v128 a, byte i, int imm8) { }

		[DebuggerStepThrough]
		public static v128 insert_ps(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 max_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 max_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 max_epu16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 max_epu32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_epu16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 min_epu32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 minpos_epu16(v128 a) { }

		[DebuggerStepThrough]
		public static int MK_INSERTPS_NDX(int srcField, int dstField, int zeroMask) { }

		[DebuggerStepThrough]
		public static v128 mpsadbw_epu8(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static v128 mul_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 mullo_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 packus_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 round_pd(v128 a, int rounding) { }

		[DebuggerStepThrough]
		public static v128 round_ps(v128 a, int rounding) { }

		[DebuggerStepThrough]
		public static v128 round_sd(v128 a, v128 b, int rounding) { }

		[DebuggerStepThrough]
		public static v128 round_ss(v128 a, v128 b, int rounding) { }

		private static double RoundDImpl(double d, int roundingMode) { }

		[DebuggerStepThrough]
		public static v128 stream_load_si128(Void* mem_addr) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static int test_all_ones(v128 a) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static int test_all_zeros(v128 a, v128 mask) { }

		[BurstTargetCpu(BurstTargetCpu::X64_SSE4 (4))]
		[DebuggerStepThrough]
		public static int test_mix_ones_zeroes(v128 a, v128 mask) { }

		[DebuggerStepThrough]
		public static int testc_si128(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int testnzc_si128(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static int testz_si128(v128 a, v128 b) { }

	}

	internal static class Sse4_2
	{
		[Flags]
		internal enum SIDD
		{
			UBYTE_OPS = 0,
			UWORD_OPS = 1,
			SBYTE_OPS = 2,
			SWORD_OPS = 3,
			CMP_EQUAL_ANY = 0,
			CMP_RANGES = 4,
			CMP_EQUAL_EACH = 8,
			CMP_EQUAL_ORDERED = 12,
			POSITIVE_POLARITY = 0,
			NEGATIVE_POLARITY = 16,
			MASKED_POSITIVE_POLARITY = 32,
			MASKED_NEGATIVE_POLARITY = 48,
			LEAST_SIGNIFICANT = 0,
			MOST_SIGNIFICANT = 64,
			BIT_MASK = 0,
			UNIT_MASK = 64,
		}

		private struct StrBoolArray
		{
			[CompilerGenerated]
			[UnsafeValueType]
			internal struct <Bits>e__FixedBuffer
			{
				public ushort FixedElementField; //Field offset: 0x0

			}

			[FixedBuffer(typeof(ushort), 16)]
			public <Bits>e__FixedBuffer Bits; //Field offset: 0x0

			public bool GetBit(int aindex, int bindex) { }

			public void SetBit(int aindex, int bindex, bool val) { }

		}

		private static readonly UInt32[] crctab; //Field offset: 0x0

		public static bool IsSse42Supported
		{
			 get { } //Length: 8
		}

		private static Sse4_2() { }

		[DebuggerStepThrough]
		public static int cmpestra(v128 a, int la, v128 b, int lb, int imm8) { }

		[DebuggerStepThrough]
		public static int cmpestrc(v128 a, int la, v128 b, int lb, int imm8) { }

		[DebuggerStepThrough]
		public static int cmpestri(v128 a, int la, v128 b, int lb, int imm8) { }

		private static int cmpestri_emulation(T* a, int alen, T* b, int blen, int len, int imm8, int allOnes, T allOnesT) { }

		[DebuggerStepThrough]
		public static v128 cmpestrm(v128 a, int la, v128 b, int lb, int imm8) { }

		private static v128 cmpestrm_emulation(T* a, int alen, T* b, int blen, int len, int imm8, int allOnes, T allOnesT) { }

		[DebuggerStepThrough]
		public static int cmpestro(v128 a, int la, v128 b, int lb, int imm8) { }

		[DebuggerStepThrough]
		public static int cmpestrs(v128 a, int la, v128 b, int lb, int imm8) { }

		[DebuggerStepThrough]
		public static int cmpestrz(v128 a, int la, v128 b, int lb, int imm8) { }

		[DebuggerStepThrough]
		public static v128 cmpgt_epi64(v128 val1, v128 val2) { }

		[DebuggerStepThrough]
		public static int cmpistra(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static int cmpistrc(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static int cmpistri(v128 a, v128 b, int imm8) { }

		private static int cmpistri_emulation(T* a, T* b, int len, int imm8, int allOnes, T allOnesT) { }

		[DebuggerStepThrough]
		public static v128 cmpistrm(v128 a, v128 b, int imm8) { }

		private static v128 cmpistrm_emulation(T* a, T* b, int len, int imm8, int allOnes, T allOnesT) { }

		[DebuggerStepThrough]
		public static int cmpistro(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static int cmpistrs(v128 a, v128 b, int imm8) { }

		[DebuggerStepThrough]
		public static int cmpistrz(v128 a, v128 b, int imm8) { }

		private static int ComputeStrCmpIntRes2(T* a, int alen, T* b, int blen, int len, int imm8, int allOnes) { }

		private static int ComputeStringLength(T* ptr, int max) { }

		private static int ComputeStriOutput(int len, int imm8, int intRes2) { }

		private static v128 ComputeStrmOutput(int len, int imm8, T allOnesT, int intRes2) { }

		[DebuggerStepThrough]
		public static uint crc32_u16(uint crc, ushort v) { }

		[DebuggerStepThrough]
		public static uint crc32_u32(uint crc, uint v) { }

		[DebuggerStepThrough]
		public static ulong crc32_u64(ulong crc_ul, ulong v) { }

		[DebuggerStepThrough]
		[Obsolete("Use the ulong version of this intrinsic instead.")]
		public static ulong crc32_u64(ulong crc_ul, long v) { }

		[DebuggerStepThrough]
		public static uint crc32_u8(uint crc, byte v) { }

		public static bool get_IsSse42Supported() { }

	}

	internal static class Ssse3
	{

		public static bool IsSsse3Supported
		{
			 get { } //Length: 8
		}

		[DebuggerStepThrough]
		public static v128 abs_epi16(v128 a) { }

		[DebuggerStepThrough]
		public static v128 abs_epi32(v128 a) { }

		[DebuggerStepThrough]
		public static v128 abs_epi8(v128 a) { }

		[DebuggerStepThrough]
		public static v128 alignr_epi8(v128 a, v128 b, int count) { }

		public static bool get_IsSsse3Supported() { }

		[DebuggerStepThrough]
		public static v128 hadd_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 hadd_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 hadds_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 hsub_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 hsub_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 hsubs_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 maddubs_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 mulhrs_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 shuffle_epi8(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sign_epi16(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sign_epi32(v128 a, v128 b) { }

		[DebuggerStepThrough]
		public static v128 sign_epi8(v128 a, v128 b) { }

	}


	public static MXCSRBits MXCSR
	{
		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		 get { } //Length: 4
		[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
		 set { } //Length: 4
	}

	private static int BurstIntrinsicGetCSRFromManaged() { }

	private static void BurstIntrinsicSetCSRFromManaged(int _) { }

	[BurstCompile(CompileSynchronously = True)]
	private static int DoGetCSRTrampoline() { }

	[BurstCompile(CompileSynchronously = True)]
	internal static int DoGetCSRTrampoline$BurstManaged() { }

	[BurstCompile(CompileSynchronously = True)]
	private static void DoSetCSRTrampoline(int bits) { }

	[BurstCompile(CompileSynchronously = True)]
	internal static void DoSetCSRTrampoline$BurstManaged(int bits) { }

	private static v128 GenericCSharpLoad(Void* ptr) { }

	private static void GenericCSharpStore(Void* ptr, v128 val) { }

	[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
	public static MXCSRBits get_MXCSR() { }

	internal static int getcsr_raw() { }

	private static bool IsNaN(uint v) { }

	private static bool IsNaN(ulong v) { }

	private static short Saturate_To_Int16(int val) { }

	private static sbyte Saturate_To_Int8(int val) { }

	private static ushort Saturate_To_UnsignedInt16(int val) { }

	private static byte Saturate_To_UnsignedInt8(int val) { }

	[BurstTargetCpu(BurstTargetCpu::X64_SSE2 (3))]
	public static void set_MXCSR(MXCSRBits value) { }

	internal static void setcsr_raw(int bits) { }

}

