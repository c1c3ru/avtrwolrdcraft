using System;
using System.Linq;
using System.Reflection;

namespace NUnit.Framework
{
    [AttributeUsage(AttributeTargets.Method)] public sealed class TestAttribute : Attribute { }

    public sealed class AssertionException : Exception { public AssertionException(string m) : base(m) { } }

    /// <summary>Only the Assert overloads the client tests use. Unknown ones fail to compile on purpose.</summary>
    public static class Assert
    {
        static void Fail(string message) { throw new AssertionException(message); }
        public static void IsTrue(bool condition) { if (!condition) Fail("expected true"); }
        public static void IsFalse(bool condition) { if (condition) Fail("expected false"); }
        public static void AreEqual(float expected, float actual) { if (expected != actual) Fail($"expected {expected} but was {actual}"); }
        public static void AreEqual(float expected, float actual, float delta)
        { if (Math.Abs(expected - actual) > delta) Fail($"expected {expected} +/- {delta} but was {actual}"); }
        public static void AreEqual(int expected, int actual) { if (expected != actual) Fail($"expected {expected} but was {actual}"); }
        public static void AreEqual(object expected, object actual) { if (!Equals(expected, actual)) Fail($"expected {expected} but was {actual}"); }
        public static void Less(int arg1, int arg2) { if (!(arg1 < arg2)) Fail($"expected {arg1} < {arg2}"); }
        public static void Greater(int arg1, int arg2) { if (!(arg1 > arg2)) Fail($"expected {arg1} > {arg2}"); }
    }
}

namespace Harness
{
    public static class Runner
    {
        public static int Main()
        {
            int passed = 0, failed = 0;
            var fixtures = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && t.GetMethods().Any(m => m.GetCustomAttribute<NUnit.Framework.TestAttribute>() != null))
                .OrderBy(t => t.FullName);
            foreach (var type in fixtures)
            {
                foreach (var method in type.GetMethods().Where(m => m.GetCustomAttribute<NUnit.Framework.TestAttribute>() != null)
                             .OrderBy(m => m.Name))
                {
                    try { method.Invoke(Activator.CreateInstance(type), null); passed++; }
                    catch (TargetInvocationException e)
                    {
                        failed++;
                        Console.WriteLine($"FAIL {type.Name}.{method.Name}: {e.InnerException?.Message}");
                    }
                }
            }
            Console.WriteLine($"{passed} passed, {failed} failed");
            return failed == 0 ? 0 : 1;
        }
    }
}
