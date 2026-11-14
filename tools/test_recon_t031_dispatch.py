"""Mutation guards for the T031 indirect-dispatch resolution."""
import copy
import struct
import unittest

import recon_t031_dispatch as probe


class DispatchResolutionTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.elf, cls.meta = probe.load()
        cls.result = probe.verify(cls.elf, cls.meta)

    def mutate(self, site, word):
        elf = copy.copy(self.elf)
        elf.data = bytearray(self.elf.data)
        struct.pack_into("<I", elf.data, elf.offset(site, 4), word)
        return elf

    def rejected(self, site, word):
        with self.assertRaises(ValueError):
            probe.verify(self.mutate(site, word), self.meta)

    def test_dispatch_counts(self):
        self.assertEqual(len(self.result["on_begin_drag"]["dispatches"]), 5)
        self.assertEqual(len(self.result["on_end_drag"]["dispatches"]), 5)
        self.assertEqual(len(self.result["level_item_on_begin_drag_internal"]["dispatches"]), 4)
        self.assertEqual(len(self.result["level_item_on_end_drag_internal"]["dispatches"]), 2)
        self.assertEqual(len(self.result["level_item_on_begin_drag_internal"]["unresolved"]), 1)
        self.assertEqual(len(self.result["level_item_on_end_drag_internal"]["unresolved"]), 1)

    def test_is_dragging_field_identity(self):
        self.assertEqual(self.result["on_begin_drag"]["resolved_unknown"]["name"],
                          "<IsDragging>k__BackingField")

    # Changing the vtable-slot immediate on the StopSyncPosition load must be caught.
    def test_changed_stop_sync_position_slot_rejected(self):
        self.rejected(0x206ba34, probe.nav.word(self.elf, 0x206ba34) ^ (1 << 10))

    # Changing the field-offset immediate on the override-hook load must be caught.
    def test_changed_try_override_pre_begin_drag_offset_rejected(self):
        self.rejected(0x206b9e0, probe.nav.word(self.elf, 0x206b9e0) ^ (1 << 10))

    # A blr turned into something else at a proven dispatch site must be caught.
    def test_changed_on_begin_drag_internal_blr_rejected(self):
        self.rejected(0x206ba54, 0xd65f03c0)  # swapped for RET

    def test_changed_override_on_drop_behavior_field_offset_rejected(self):
        self.rejected(0x22f69ac, probe.nav.word(self.elf, 0x22f69ac) ^ (1 << 10))

    def test_changed_hitbox_window_introducing_blr_rejected(self):
        self.rejected(0x227f5f8, 0xd63f0120)  # bl -> blr inside the "no blr" window


if __name__ == "__main__":
    unittest.main()
