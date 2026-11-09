"""Mutation guards against invented scene-event signup edges; requires cached pair."""
import copy
import json
from pathlib import Path
import struct
import tempfile
import unittest

import recon_scene_subscribers as subscribers


class SceneSubscribersTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.source = subscribers.nav.ROOT / "out/recon/il2cpp"
        cls.binary = (cls.source / "libil2cpp.so").read_bytes()
        cls.metadata = (cls.source / "global-metadata.dat").read_bytes()
        subscribers.nav.verify_pair(cls.binary, cls.metadata)
        cls.elf = subscribers.nav.Elf(cls.binary)
        cls.meta = subscribers.nav.Metadata(cls.metadata)
        cls.index = cls.source / "metadata_methods.jsonl"
        cls.edges, _, _, _ = subscribers.verify_edges(cls.elf, cls.meta, cls.index)

    def changed_word(self, address, value):
        result = copy.copy(self.elf)
        result.data = bytearray(self.binary)
        struct.pack_into("<I", result.data, self.elf.offset(address, 4), value)
        return result

    def test_original_five_edges_have_exact_handlers_and_no_runtime_claim(self):
        self.assertEqual(len(self.edges), 5)
        self.assertEqual([e["handler"]["token"] for e in self.edges],
                         ["0x06005601", "0x06006e44", "0x0600849c", "0x0600849d", "0x060056fc"])
        self.assertEqual(self.edges[-1]["event_add_method"]["name"], "add_activeSceneChanged")
        self.assertTrue(all(e["classification"] == "DERIVED_static_registration_edge_not_runtime_observed" for e in self.edges))

    def test_mutated_stage_registration_BL_target_rejected_without_outer_hash_gate(self):
        address = 0x2310d64
        elf = self.changed_word(address, subscribers.nav.word(self.elf, address) + 1)
        with self.assertRaisesRegex(ValueError, "registration branch target/kind"):
            subscribers.verify_edges(elf, self.meta, self.index)

    def test_mutated_active_scene_changed_tail_target_rejected(self):
        address = 0x2072568
        elf = self.changed_word(address, subscribers.nav.word(self.elf, address) + 1)
        with self.assertRaisesRegex(ValueError, "registration branch target/kind"):
            subscribers.verify_edges(elf, self.meta, self.index)

    def test_mutated_constructor_target_rejected(self):
        address = 0x2072540
        elf = self.changed_word(address, subscribers.nav.word(self.elf, address) + 1)
        with self.assertRaisesRegex(ValueError, "constructor call target"):
            subscribers.verify_edges(elf, self.meta, self.index)

    def test_wrong_handler_method_usage_rejected(self):
        usage = int(self.edges[0]["handler_metadata_usage"]["usage_vaddr"], 16)
        encoded = int(self.edges[0]["handler_metadata_usage"]["encoded"], 16)
        elf = self.changed_word(usage, encoded ^ 2)
        with self.assertRaisesRegex(ValueError, "handler MethodDef usage"):
            subscribers.verify_edges(elf, self.meta, self.index)

    def test_changed_handler_metadata_token_rejected(self):
        meta = copy.copy(self.meta)
        meta.data = bytearray(self.metadata)
        index = self.edges[0]["handler"]["method_definition_index"]
        token_at = meta.tables["methods"]["offset"] + index * 36 + 24
        struct.pack_into("<I", meta.data, token_at, 0x06000001)
        with self.assertRaisesRegex(ValueError, "declaring type/token inconsistent with v31 layout"):
            subscribers.verify_edges(self.elf, meta, self.index)

    def test_changed_handler_argument_register_rejected(self):
        address = 0x206926c  # LDR x2,[x20] -> LDR x3,[x20]
        elf = self.changed_word(address, subscribers.nav.word(self.elf, address) ^ 1)
        with self.assertRaisesRegex(ValueError, "opcode mismatch"):
            subscribers.verify_edges(elf, self.meta, self.index)

    def test_fabricated_matching_cached_names_are_not_trusted(self):
        with tempfile.TemporaryDirectory(prefix="scene-subscribers-index-") as temporary:
            target = Path(temporary) / "metadata_methods.jsonl"
            modified = 0
            with self.index.open() as source, target.open("w") as out:
                for line in source:
                    row = json.loads(line)
                    if row["image"] == "Assembly-CSharp.dll" and row["token"] == "0x06005601":
                        # Keep fake matching name/token/address, but point to a
                        # different raw method definition. Metadata must win.
                        row["method_definition_index"] += 1
                        modified += 1
                    out.write(json.dumps(row) + "\n")
            self.assertEqual(modified, 1)
            with self.assertRaisesRegex(ValueError, "cached symbol metadata mismatch"):
                subscribers.verify_edges(self.elf, self.meta, target)

    def test_changed_pair_hash_rejected(self):
        changed = bytearray(self.binary)
        changed[-1] ^= 1
        with self.assertRaisesRegex(ValueError, "native identity mismatch"):
            subscribers.nav.verify_pair(changed, self.metadata)


if __name__ == "__main__":
    unittest.main()
