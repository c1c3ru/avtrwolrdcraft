import copy, json, sys, unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).parent))
import recon_contract as rc

SEED = Path(__file__).parent.parent / "contracts" / "store-claim.contract.json"


def seed():
    return json.loads(SEED.read_text(encoding="utf-8"))


class ParseSource(unittest.TestCase):
    def test_formats(self):
        self.assertEqual(rc.parse_source("a/b.cs:12-30"), ("lines", "a/b.cs", 12, 30))
        self.assertEqual(rc.parse_source("a/b.cs:7"), ("lines", "a/b.cs", 7, 7))
        self.assertEqual(rc.parse_source("libil2cpp.so@0x401000"), ("addr", "libil2cpp.so", 0x401000))
        self.assertEqual(rc.parse_source("ev_" + "a" * 64)[0], "ev")
        self.assertIsNone(rc.parse_source("vi no código"))


class Validate(unittest.TestCase):
    def test_seed_is_valid_and_sources_resolve(self):
        c = seed()
        self.assertEqual(rc.validate(c), [])
        self.assertEqual(rc.check_sources(c), [])

    def test_sourced_constant_needs_source(self):
        c = seed()
        del c["constants"][0]["source"]
        self.assertTrue(any("source" in x for x in rc.validate(c)))

    def test_invented_needs_basis_and_reimplementation(self):
        c = seed()
        del c["constants"][2]["reimplementation"]
        self.assertTrue(any("reimplementation" in x for x in rc.validate(c)))

    def test_unknown_key_rejected(self):
        c = seed()
        c["extra"] = 1
        self.assertTrue(any("extra" in x for x in rc.validate(c)))

    def test_line_range_out_of_file(self):
        c = seed()
        c["constants"][0]["source"] = c["constants"][0]["source"].split(":")[0] + ":9000"
        self.assertTrue(any("fora de" in x for x in rc.check_sources(c)))

    def test_missing_file(self):
        c = seed()
        c["constants"][0]["source"] = "nao/existe.cs:1"
        self.assertTrue(any("inexistente" in x for x in rc.check_sources(c)))


class Replay(unittest.TestCase):
    def vec(self, **kw):
        c = seed()
        c["vectors"] = [dict({"name": "v", "provenance": "static-derived", "args": [], "stdin": "ab", "stdout": "ab", "exitCode": 0,
                              "source": c["functions"][0]["source"]}, **kw)]
        return c

    def test_identical_passes(self):
        self.assertEqual(rc.validate(self.vec()), [])
        self.assertEqual(rc.replay(self.vec(), ["cat"]), [])

    def test_byte_difference_fails(self):
        self.assertTrue(rc.replay(self.vec(stdout="ab\n"), ["cat"]))

    def test_exit_code_fails(self):
        self.assertTrue(rc.replay(self.vec(exitCode=3), ["cat"]))

    def test_missing_binary_reported(self):
        self.assertTrue(rc.replay(self.vec(), ["/nao/existe"]))

    def test_runtime_observed_source_is_free_text(self):
        c = self.vec(provenance="runtime-observed", source="adb shell run-as ... > save.json")
        self.assertEqual(rc.validate(c), [])

    def test_static_derived_needs_parseable_source(self):
        c = self.vec(source="derivei de cabeça")
        self.assertTrue(rc.validate(c))


if __name__ == "__main__":
    unittest.main()
