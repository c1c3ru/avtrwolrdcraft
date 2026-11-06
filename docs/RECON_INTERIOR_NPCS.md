# NPCs dos interiores (recon estático)

Gerado por `tools/recon_interior_npcs.py`. **Avatares**: lista `LevelSceneAvatarMap` da cena (id + posição, mesmo sistema de coordenadas dos sprites exportados). **Script**: `LevelAvatarOneTimeSpawner`. **Pets**: `LevelAnimalIDHandler`. **Fundo**: `BackgroundCharacterSpineManager`. A **aparência** de cada id não está nos dados locais (provavelmente vem do servidor/prefab), então hoje só dá para posicionar um personagem genérico em cada ponto.

Total: **389** avatares em 52 de 57 interiores.

| Interior | LevelType | Avatares | isOnPhone | Script | Pets | Fundo |
|---|---|---:|---:|---:|---:|---:|
| airport_street_t1z4 | AirportStreet_L66 | 8 | 8 | 1 | 0 | 0 |
| airport_t1s6 | Airport_F1_L35 | 12 | 12 | 0 | 0 | 0 |
| airportmetro_t1s6 | AirportMetroStation_L64 | 9 | 9 | 1 | 0 | 0 |
| bakery_build_t1s3 | Bakery_L20 | 8 | 8 | 0 | 0 | 0 |
| ballet | BalletStudio_L19 | 5 | 5 | 0 | 0 | 0 |
| bank_t1s4 | Bank_L148 | 8 | 8 | 0 | 0 | 0 |
| barbershop_t1s2 | MiniBarbershop_Z1B5L1 | 7 | 7 | 0 | 0 | 0 |
| basketball_t1s2 | MiniBasketball_L1 | 5 | 5 | 0 | 0 | 0 |
| branding_kawaii_build_t1s3 | KawaiiShopBrand_L27 | 8 | 8 | 0 | 2 | 0 |
| branding_skater_t1s3 | SkaterShopBrand_L28 | 6 | 6 | 0 | 0 | 0 |
| cabin | Cabin_Z2B5L1 | 2 | 2 | 0 | 0 | 0 |
| campsite_z2b1 | Campsite_Z2B1L1 | 5 | 5 | 0 | 0 | 0 |
| countryclubstreet_l187 | CountryClubStreet_L187 | 9 | 9 | 0 | 0 | 0 |
| courthouse_t1s4 | CourtHouse_L147 | 12 | 12 | 0 | 0 | 5 |
| daycare_t1z2 | DaycareEntrance_L23 | 6 | 6 | 0 | 0 | 0 |
| dentist | DentistOffice_L208 | 8 | 8 | 0 | 0 | 0 |
| family_house_t1s1 | GirlsLivingRoom_Z1B1L1 | 3 | 3 | 0 | 2 | 0 |
| fancyrestaurant_t1z3 | ItalianRestaurant_L98 | 10 | 10 | 0 | 0 | 0 |
| fashion_shop_t1s4 | Fashionshop_L2 | 4 | 4 | 0 | 0 | 0 |
| fire_station_t1s4 | FireStation_F0_L154 | 6 | 6 | 0 | 0 | 0 |
| furniture_store_build_t1s5 | FurnitureStoreShowRoom_F1_L46 | 7 | 7 | 0 | 0 | 0 |
| garage | Garage_L232 | 8 | 8 | 0 | 0 | 0 |
| hats_shop_t1s4 | Hatshop_L7 | 2 | 2 | 0 | 0 | 0 |
| hiphop_build_t1s3 | HipHopStudio_L18 | 5 | 5 | 0 | 0 | 0 |
| hospital_t1s4 | Hospital_F1_L157 | 8 | 8 | 1 | 0 | 0 |
| hotdog_shop_t1s4 | Hotdog_L4 | 7 | 7 | 1 | 0 | 0 |
| ice_cream_t1s4 | Icecreamshop_L16 | 7 | 7 | 0 | 0 | 0 |
| jellybean_street | JellyBeanAvenue_L210 | 11 | 11 | 0 | 0 | 0 |
| kawaii_shop_t1s4 | Kawaiishop_L5 | 5 | 5 | 0 | 0 | 0 |
| lake_z2b2 | Lake_Z2B2L1 | 2 | 2 | 0 | 0 | 0 |
| luxury_build_t1s1 | LuxuryHouse_F1_L43 | 0 | 0 | 0 | 0 | 0 |
| mall_t1s4 | Mall_F1_L8 | 9 | 9 | 0 | 0 | 0 |
| metro_build_t1z3 | MetroStation_L58 | 12 | 12 | 0 | 0 | 0 |
| mkr_kawaii_house_t1s1 | KawaiiHouse_F1_L32 | 0 | 0 | 0 | 0 | 0 |
| mkr_modern_t1s1 | ModernHouse_F1_L30 | 0 | 0 | 0 | 0 | 0 |
| municipalstreet_t1s4 | MunicipalStreet_L141 | 14 | 14 | 2 | 0 | 0 |
| natural_chich_t1s1 | NaturalChicHM_F1_L99 | 0 | 0 | 0 | 0 | 0 |
| office_build_t1s3 | StorageUnit_L125 | 0 | 0 | 0 | 0 | 0 |
| pet_store_t1s3 | PetShop_L21 | 7 | 7 | 0 | 0 | 0 |
| pharmacy_t1s2 | DoctorOffice_L17 | 8 | 8 | 0 | 0 | 0 |
| pizza_shop_t1s4 | Pizza_L3 | 12 | 12 | 0 | 0 | 0 |
| police_station_t1s4 | PoliceStation_L145 | 6 | 6 | 0 | 0 | 0 |
| post_office_t1s4 | PostOffice_L146 | 9 | 9 | 0 | 0 | 0 |
| res_street_t1s1 | Street_Main_L41 | 14 | 14 | 7 | 0 | 0 |
| school_street_t1s2 | SchoolStreet_L39 | 12 | 12 | 4 | 0 | 0 |
| school_t1s2 | SchoolHallway_L12 | 10 | 10 | 1 | 0 | 0 |
| shoes_shop_t1s4 | Shoeshop_L6 | 5 | 5 | 1 | 0 | 0 |
| shopboulevard_l59 | ShopBoulevard_L59 | 7 | 7 | 1 | 0 | 0 |
| sports_clothes_t1s2 | ShoeShopBrand_L26 | 7 | 7 | 0 | 0 | 0 |
| supermarket_z1b4 | Supermarket_Z1B4L1 | 7 | 7 | 0 | 0 | 0 |
| talentshow_z2b4 | TalentShow_Z2B4L1 | 7 | 7 | 0 | 0 | 0 |
| toddler_baby_skater_t1z3 | SkaterToddlerAndBabyShop_L49 | 10 | 10 | 1 | 0 | 0 |
| toddlerbaby_t1s3 | ToddlerBabyShop_L45 | 9 | 9 | 0 | 0 | 0 |
| toystore | ToyStore_L209 | 9 | 9 | 0 | 0 | 0 |
| trainstation | TrainStation_Z1B2 | 6 | 6 | 0 | 0 | 0 |
| treetop_z2b3 | Treetop_Z2B3L1 | 1 | 1 | 0 | 0 | 0 |
| yoga_build_t1s3 | MiniYogaStudio_Z1B2L1 | 5 | 5 | 0 | 0 | 0 |
