"""Pins the named handler-slot lifecycle of contextual animations and checks that the receiver test is not vacuous."""
import unittest

import recon_ca_lifecycle as ca


class CaLifecycleTests(unittest.TestCase):
    source = ca.nav.ROOT / 'out/recon/il2cpp'

    @classmethod
    def setUpClass(cls):
        cls.report = ca.probe(cls.source)

    def test_add_order_is_validity_lock_added_relevance_silence(self):
        self.assertEqual(self.report['add']['handler_virtual_calls_in_order'], [
            'IsValidForTarget', 'IsLockedToTarget', 'GetLockedAnimationName', 'OnAddedToTarget',
            'IsRelevantForTarget', 'IsSilent'])
        self.assertEqual(self.report['add']['direct_calls_in_order'][1], 'CATargetExtensionMethods.AddCAHandler')

    def test_remove_calls_on_removed_hook_then_idle_policy(self):
        self.assertEqual(self.report['remove']['handler_virtual_calls_in_order'], [
            'OnRemovedFromTarget', 'AllowReturnToIdleAnimationWhenRemovedFromTarget', 'IsSilent'])

    def test_previous_doc_inferences_were_confirmed_and_two_corrected(self):
        add = self.report['add']['handler_virtual_calls_in_order']
        self.assertIn('OnAddedToTarget', add)       # was inferred
        self.assertIn('IsLockedToTarget', add)      # was "second bool, unidentified"
        self.assertIn('IsRelevantForTarget', add)   # was "TryForceToSit-like"

    def test_animation_name_rule(self):
        rule = self.report['animation_name']
        self.assertIn('isNameFullAnimationName ? config.name', rule['rule'])
        self.assertEqual(rule['literals'], {'prefix': 'CA/', 'empty': '', 'separator': '/'})
        self.assertIn('1 (Character), 2 (Baby), 13 (Toddler)', rule['prefix'])

    def test_triggers_cover_menu_weather_clothing_gear_and_multiplayer(self):
        triggers = self.report['triggers']
        self.assertIn('PWC.LevelContextualAnimation.LevelContextualAnimationMenu.OnAnimationItemClick',
                      triggers['PlayContextualAnimation']['user menu'])
        self.assertIn('Game.Level.LevelAddCAOnAllCharactersHandlerByWeather.AddCaScriptToAvatar',
                      triggers['AddCAHandlerAndUpdateGame']['weather'])
        self.assertIn('PWC.Level.LevelClothingUtils.TryAddCAHandlerFromSkinName', triggers['AddCAHandlerAndUpdateGame']['clothing'])
        self.assertIn('PWC.Multiplayer.MPDataHelper_CA.HandleData', triggers['PlayContextualAnimation']['multiplayer replay'])

    def test_list_update_event_is_gated_on_add_but_not_on_remove(self):
        event = self.report['list_updated_event']
        self.assertIn('IsRelevantForTarget', event['add'])
        self.assertIn('true, handler.IsSilent()', event['add'])
        self.assertIn('false, handler.IsSilent()', event['remove'])
        self.assertIn('no relevance gate', event['remove'])

    def test_menu_speech_and_cellphone_subscribe_to_the_events(self):
        users = self.report['event_users']
        self.assertIn('PWC.LevelContextualAnimation.LevelContextualAnimationMenu', users['subscribers_awake_ondestroy'])
        self.assertIn('PWC.AvatarSpeech.AvatarSpeechUIMenu', users['subscribers_awake_ondestroy'])
        self.assertIn('PWC.Level.LevelToddler.OnPointerClickInternal', users['publishers'])

    def test_missing_subscriber_is_rejected(self):
        original = set(ca.EVENT_SUBSCRIBERS)
        ca.EVENT_SUBSCRIBERS.add('PWC.Level.LevelManager')
        try:
            with self.assertRaisesRegex(ValueError, 'does not touch CATargetEvents'):
                ca.probe(self.source)
        finally:
            ca.EVENT_SUBSCRIBERS.clear()
            ca.EVENT_SUBSCRIBERS.update(original)

    def test_missing_trigger_is_rejected(self):
        original = ca.TRIGGERS['PlayContextualAnimation']['user menu']
        ca.TRIGGERS['PlayContextualAnimation']['user menu'] = original | {'PWC.Level.LevelManager.Init'}
        try:
            with self.assertRaisesRegex(ValueError, 'PlayContextualAnimation user menu: missing'):
                ca.probe(self.source)
        finally:
            ca.TRIGGERS['PlayContextualAnimation']['user menu'] = original

    def test_changed_prefix_logic_is_rejected(self):
        original = list(ca.CA_PREFIX_WORDS)
        ca.CA_PREFIX_WORDS[3] = 0x7100381f  # cmp w0,#14 instead of #13 (Horse instead of Toddler)
        try:
            with self.assertRaisesRegex(ValueError, 'HasCAPrefixForCAAnimations logic changed'):
                ca.probe(self.source)
        finally:
            ca.CA_PREFIX_WORDS[:] = original

    def test_wrong_slot_name_is_rejected(self):
        original = list(ca.ADD_SLOTS)
        ca.ADD_SLOTS[3] = (0x23ac9c4, 12, 'OnRemovedFromTarget')
        try:
            with self.assertRaisesRegex(ValueError, 'slot 12 is not OnRemovedFromTarget'):
                ca.probe(self.source)
        finally:
            ca.ADD_SLOTS[:] = original

    def test_receiver_check_rejects_a_slot_not_called_on_the_handler(self):
        original = set(ca.INFERRED_RECEIVER)
        ca.INFERRED_RECEIVER.clear()
        try:
            with self.assertRaisesRegex(ValueError, 'receiver of GetLockedAnimationName'):
                ca.probe(self.source)
        finally:
            ca.INFERRED_RECEIVER.update(original)


if __name__ == '__main__':
    unittest.main()
