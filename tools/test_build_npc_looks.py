import sys
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parent))
from build_npc_looks import FIELDS, extra_for, item_for, nearest  # noqa: E402


class ItemForTests(unittest.TestCase):
    def test_skin_names_map_to_look_fields_and_ids(self):
        cases = {
            'Shirt_Special/243': ('Shirt', 'shirt_special_243'),
            'OnePiece_Dress/5': ('Shirt', 'onepiece_dress_5'),
            'Bottom_Special/77': ('Bottom', 'bottom_special_77'),
            'Legs_Shoes/76': ('Shoes', 'legs_shoes_76'),
            'Hair_Back/12_Color': ('HairBack', 'hair_back_12_color'),
            'Mouth/58': ('Mouth', 'mouth_58'),
            'Eyebrows/15_Color': ('Eyebrows', 'eyebrows_15_color'),
            'Hat_Winter/3': ('Hat', 'hat_winter_3'),
            'Jacket_Casual/9': ('Jacket', 'jacket_casual_9'),
            'Accessories_Face_Glasses/2': ('Accessory', 'accessories_face_glasses_2'),
        }
        for name, expected in cases.items():
            self.assertEqual(item_for(name), expected, name)

    def test_front_hair_keeps_the_original_skin_name(self):
        self.assertEqual(item_for('Hair_Front/99_Color'), ('Hair', 'Hair_Front/99_Color'))

    def test_unsupported_categories_return_none(self):
        for name in ('Back_A/1', 'Nails/4', 'Hair_Facial/2_Color', 'Face_Cheeks/3'):
            self.assertIsNone(item_for(name), name)

    def test_every_mapped_field_is_a_known_look_field(self):
        for name in ('Shirt_X/1', 'Bottom_X/1', 'Legs_Shoes/1', 'Hair_Back/1', 'Hair_Front/1_Color', 'Mouth/1', 'Eyebrows/1', 'Hat_X/1', 'Jacket_X/1'):
            self.assertIn(item_for(name)[0], FIELDS, name)


class ExtraForTests(unittest.TestCase):
    def test_extras_become_manifest_ids(self):
        self.assertEqual(extra_for('Face_Complexion/23'), 'face_complexion_23')
        self.assertEqual(extra_for('Legs_Socks/16'), 'legs_socks_16')
        self.assertEqual(extra_for('Accessories_Body_Bags/4'), 'accessories_body_bags_4')

    def test_non_extras_return_none(self):
        for name in ('Shirt_Special/243', 'Mouth/58', 'Back_A/1', 'Nails/4', 'Body_Whites/1'):
            self.assertIsNone(extra_for(name), name)

    def test_extras_and_editor_items_do_not_overlap(self):
        # main() testa extra_for primeiro; item_for nao pode reconhecer o mesmo SkinName.
        for name in ('Face_Cheeks/1', 'Legs_Socks/1', 'Accessories_Face_Piercing/1', 'Accessories_Body_Rings/1', 'Accessories_Face_Mask/1'):
            self.assertIsNotNone(extra_for(name), name)
            self.assertIsNone(item_for(name), name)


class NearestTests(unittest.TestCase):
    def test_exact_color_returns_its_index(self):
        pal = [[0, 0, 0], [1, 0, 0], [0, 1, 0]]
        self.assertEqual(nearest([0, 1, 0], pal), 2)

    def test_picks_closest_by_squared_distance(self):
        pal = [[0.0, 0.0, 0.0], [1.0, 1.0, 1.0]]
        self.assertEqual(nearest([0.4, 0.4, 0.4], pal), 0)
        self.assertEqual(nearest([0.6, 0.6, 0.6], pal), 1)

    def test_tie_goes_to_first(self):
        self.assertEqual(nearest([0.5], [[0.0], [1.0]]), 0)


if __name__ == '__main__':
    unittest.main()
