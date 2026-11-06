using System.Collections.Generic;

namespace AvatarWorld.Core.World
{
    /// <summary>
    /// Quais predios do mapa tem interior exportado (Resources/Interiors/&lt;chave&gt;). A chave de entrada e o
    /// PWC.Game.LevelType padrao do predio (world.json, defaultLevel); a cadeia ate a cena do original esta em
    /// docs/PRD_WORLD_INTERIORS_2026-11-05.md (tools/recon_building_scenes.py). Gerado a partir de
    /// tools/export_all_interiors.py (out/recon/interiors_export.json); 6 predios em obras (defaultLevel 0) nao tem cena.
    /// </summary>
    public static class InteriorCatalog
    {
        static readonly Dictionary<int, string> Keys = new Dictionary<int, string>
        {
            { 1, "family_house_t1s1" }, // Family_House_T1S1 -> level5
            { 7, "cabin" }, // Cabin_Z2B5 -> level15
            { 8, "campsite_z2b1" }, // Campsite_Z2B1 -> level11
            { 9, "lake_z2b2" }, // Lake_Z2B2 -> level12
            { 10, "talentshow_z2b4" }, // TalentShow_Z2B4 -> level14
            { 11, "treetop_z2b3" }, // Treetop_Z2B3 -> level13
            { 12, "yoga_build_t1s3" }, // Yoga_Build_T1S3 -> level7
            { 13, "basketball_t1s2" }, // Basketball_T1S2 -> level8
            { 14, "barbershop_t1s2" }, // Barbershop_T1S2 -> level10
            { 15, "supermarket_z1b4" }, // Supermarket_Z1B4 -> level9
            { 18, "hotdog_shop_t1s4" }, // Hotdog_Shop_T1S4 -> level16
            { 19, "pizza_shop_t1s4" }, // Pizza_Shop_T1S4 -> level17
            { 20, "fashion_shop_t1s4" }, // Fashion_Shop_T1S4 -> level18
            { 21, "kawaii_shop_t1s4" }, // Kawaii_Shop_T1S4 -> level19
            { 22, "shoes_shop_t1s4" }, // Shoes_Shop_T1S4 -> level20
            { 23, "trainstation" }, // TrainStation -> level21
            { 24, "hats_shop_t1s4" }, // Hats_Shop_T1S4 -> level22
            { 26, "mall_t1s4" }, // Mall_T1S4 -> level23
            { 27, "ice_cream_t1s4" }, // Ice_Cream_T1S4 -> level25
            { 28, "pharmacy_t1s2" }, // Pharmacy_T1S2 -> level26
            { 30, "school_t1s2" }, // School_T1S2 -> level28
            { 32, "ballet" }, // Ballet_T1S3 -> level30
            { 33, "hiphop_build_t1s3" }, // HipHop_Build_T1S3 -> level31
            { 35, "bakery_build_t1s3" }, // Bakery_Build_T1S3 -> level33
            { 36, "pet_store_t1s3" }, // Pet_Store_T1S3 -> level34
            { 39, "sports_clothes_t1s2" }, // Sports_Clothes_T1S2 -> level37
            { 40, "daycare_t1z2" }, // Daycare_T1Z2 -> level38
            { 42, "branding_kawaii_build_t1s3" }, // Branding_Kawaii_Build_T1S3 -> level40
            { 43, "mkr_modern_t1s1" }, // MKR_Modern_T1S1 -> level41
            { 45, "branding_skater_t1s3" }, // Branding_Skater_T1S3 -> level43
            { 46, "toddlerbaby_t1s3" }, // ToddlerBaby_T1S3 -> level44
            { 47, "luxury_build_t1s1" }, // Luxury_Build_T1S1 -> level45
            { 50, "toddler_baby_skater_t1z3" }, // Toddler_Baby_Skater_T1Z3 -> level48
            { 51, "res_street_t1s1" }, // Res_Street_T1S1 -> level49
            { 52, "furniture_store_build_t1s5" }, // Furniture_Store_Build_T1S5 -> level50
            { 60, "school_street_t1s2" }, // School_Street_T1S2 -> level57
            { 61, "office_build_t1s3_1" }, // Office_Build_T1S3 (1) -> level59
            { 62, "shopboulevard_l59" }, // ShopBoulevard_L59 -> level60
            { 63, "airport_t1s6" }, // Airport_T1S6 -> level64
            { 69, "mkr_kawaii_house_t1s1" }, // MKR_Kawaii_House_T1S1 -> level76
            { 73, "metro_build_t1z3" }, // Metro_Build_T1Z3 -> level61
            { 85, "airport_street_t1z4" }, // Airport_Street_T1Z4 -> level80
            { 90, "airportmetro_t1s6" }, // AirportMetro_T1S6 -> level84
            { 94, "natural_chich_t1s1" }, // Natural_Chich_T1S1 -> level88
            { 106, "fancyrestaurant_t1z3" }, // FancyRestaurant_T1Z3 -> level101
            { 107, "office_build_t1s3" }, // Office_Build_T1S3 -> level102
            { 139, "police_station_t1s4" }, // Police_Station_T1S4 -> level132
            { 140, "post_office_t1s4" }, // Post_Office_T1S4 -> level133
            { 142, "bank_t1s4" }, // Bank_T1S4 -> level134
            { 143, "courthouse_t1s4" }, // CourtHouse_T1S4 -> level135
            { 144, "municipalstreet_t1s4" }, // MunicipalStreet_T1S4 -> level137
            { 145, "fire_station_t1s4" }, // Fire_Station_T1S4 -> level138
            { 147, "hospital_t1s4" }, // Hospital_T1S4 -> level139
            { 178, "countryclubstreet_l187" }, // CountryClubStreet_L187 -> level165
            { 216, "jellybean_street" }, // JellyBean_Street -> level204
            { 217, "toystore" }, // Toystore -> level205
            { 218, "dentist" }, // ZV_Dentist_T1 -> level206
            { 239, "garage" }, // Garage -> level227
        };

        public static bool TryGetKey(int defaultLevel, out string key) => Keys.TryGetValue(defaultLevel, out key);

        public static IReadOnlyCollection<string> AllKeys => Keys.Values;
    }
}
