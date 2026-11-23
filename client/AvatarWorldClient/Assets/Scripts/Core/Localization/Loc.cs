using System;
using System.Collections.Generic;

namespace AvatarWorld.Core.Localization
{
    /// <summary>Idiomas da interface. Os codigos (en/id/es/pt) sao os dos botoes do ChatLanguagesPanel do original.</summary>
    public enum Language { Pt, En, Es, Id }

    /// <summary>
    /// Textos da interface por idioma. Funcionalidade propria do cliente offline: o original so tem seletor de idioma de CHAT
    /// (ChatLanguageButton), nao de interface. Chave ausente cai para o portugues e, se nem la existir, devolve a propria chave,
    /// de modo que um texto ainda nao traduzido nunca fica em branco.
    /// </summary>
    public static class Loc
    {
        public static Language Current { get; set; } = Language.Pt;

        public static string Code(Language l)
        {
            switch (l)
            {
                case Language.En: return "en";
                case Language.Es: return "es";
                case Language.Id: return "id";
                default: return "pt";
            }
        }

        /// <summary>Converte "pt"/"en"/"es"/"id" (qualquer caixa). Valor desconhecido ou vazio devolve false.</summary>
        public static bool TryParse(string code, out Language language)
        {
            language = Language.Pt;
            if (string.IsNullOrEmpty(code)) return false;
            foreach (Language l in Enum.GetValues(typeof(Language)))
                if (string.Equals(Code(l), code.Trim(), StringComparison.OrdinalIgnoreCase)) { language = l; return true; }
            return false;
        }

        // Ordem em cada linha: pt, en, es, id.
        static readonly Dictionary<string, string[]> Table = new Dictionary<string, string[]>
        {
            ["back"] = new[] { "Voltar", "Back", "Volver", "Kembali" },
            ["settings"] = new[] { "Configurações", "Settings", "Configuración", "Pengaturan" },
            ["profile.title"] = new[] { "Perfil local", "Local profile", "Perfil local", "Profil lokal" },
            ["profile.saved"] = new[] { "Progresso salvo neste aparelho.", "Progress saved on this device.", "Progreso guardado en este dispositivo.", "Kemajuan disimpan di perangkat ini." },
            ["profile.body"] = new[] { "Progresso salvo neste aparelho.\nMoedas: {0}\nPontos: {1}", "Progress saved on this device.\nCoins: {0}\nPoints: {1}", "Progreso guardado en este dispositivo.\nMonedas: {0}\nPuntos: {1}", "Kemajuan disimpan di perangkat ini.\nKoin: {0}\nPoin: {1}" },
            ["profile.save"] = new[] { "Salvar progresso", "Save progress", "Guardar progreso", "Simpan kemajuan" },
            ["progress.title"] = new[] { "Progresso", "Progress", "Progreso", "Kemajuan" },
            ["progress.body"] = new[] { "Desafios concluídos: {0}\nMoedas: {1}\nPontos: {2}", "Completed challenges: {0}\nCoins: {1}\nPoints: {2}", "Desafíos completados: {0}\nMonedas: {1}\nPuntos: {2}", "Tantangan selesai: {0}\nKoin: {1}\nPoin: {2}" },
            ["storage.title"] = new[] { "Armazenamento", "Storage", "Almacenamiento", "Penyimpanan" },
            ["storage.error"] = new[] { "Não foi possível acessar o salvamento. Confira o espaço livre e tente novamente.", "Could not access the save file. Check the free space and try again.", "No se pudo acceder al guardado. Revisa el espacio libre e inténtalo de nuevo.", "Tidak dapat mengakses data simpanan. Periksa ruang kosong lalu coba lagi." },
            ["reset.title"] = new[] { "Reiniciar progresso", "Reset progress", "Reiniciar progreso", "Atur ulang kemajuan" },
            ["reset.warn"] = new[] { "Isto apaga as moedas, os avatares, as compras e os desafios deste aparelho e volta ao começo do jogo.", "This erases the coins, avatars, purchases and challenges on this device and returns the game to the start.", "Esto borra las monedas, los avatares, las compras y los desafíos de este dispositivo y vuelve al inicio del juego.", "Ini menghapus koin, avatar, pembelian, dan tantangan di perangkat ini lalu mengembalikan permainan ke awal." },
            ["reset.continue"] = new[] { "Continuar", "Continue", "Continuar", "Lanjutkan" },
            ["reset.confirm.title"] = new[] { "Tem certeza?", "Are you sure?", "¿Seguro?", "Yakin?" },
            ["reset.confirm.body"] = new[] { "Não dá para desfazer pelo jogo. Uma cópia do save fica guardada no aparelho.", "This cannot be undone from the game. A copy of the save is kept on the device.", "No se puede deshacer desde el juego. Se guarda una copia del guardado en el dispositivo.", "Tidak dapat dibatalkan dari dalam permainan. Salinan data simpanan disimpan di perangkat." },
            ["reset.confirm.do"] = new[] { "Apagar tudo e recomeçar", "Erase everything and restart", "Borrar todo y empezar de nuevo", "Hapus semua dan mulai ulang" },
            // ---- Loja ----
            ["store.items"] = new[] { "Itens", "Items", "Artículos", "Item" },
            ["store.all"] = new[] { "Todos", "All", "Todos", "Semua" },
            ["store.soon"] = new[] { "Em breve", "Coming soon", "Próximamente", "Segera hadir" },
            ["store.owned"] = new[] { "Adquirido", "Owned", "Adquirido", "Dimiliki" },
            ["store.buy"] = new[] { "Comprar", "Buy", "Comprar", "Beli" },
            ["store.earn"] = new[] { "Ganhar moedas", "Earn coins", "Ganar monedas", "Dapatkan koin" },
            ["store.cancel"] = new[] { "Cancelar", "Cancel", "Cancelar", "Batal" },
            ["store.challenge.body"] = new[] { "Desafios de português e matemática para ganhar moedas", "Portuguese and math challenges to earn coins", "Desafíos de portugués y matemáticas para ganar monedas", "Tantangan bahasa Portugis dan matematika untuk mendapatkan koin" },
            ["store.challenge.reward"] = new[] { "+{0} moedas por acerto", "+{0} coins per correct answer", "+{0} monedas por acierto", "+{0} koin untuk setiap jawaban benar" },
            ["store.have"] = new[] { "Você já tem este combo.", "You already have this bundle.", "Ya tienes este paquete.", "Kamu sudah memiliki paket ini." },
            ["store.confirm"] = new[] { "Comprar \"{0}\" por {1} moedas?", "Buy \"{0}\" for {1} coins?", "¿Comprar \"{0}\" por {1} monedas?", "Beli \"{0}\" seharga {1} koin?" },
            ["store.missing"] = new[] { "Faltam {0} moedas para \"{1}\".", "You need {0} more coins for \"{1}\".", "Te faltan {0} monedas para \"{1}\".", "Kurang {0} koin untuk \"{1}\"." },
            ["store.insufficient"] = new[] { "Moedas insuficientes.", "Not enough coins.", "Monedas insuficientes.", "Koin tidak cukup." },
            ["store.fail"] = new[] { "Não foi possível comprar agora.", "Could not buy right now.", "No se pudo comprar ahora.", "Tidak dapat membeli sekarang." },
            ["store.savefail"] = new[] { "Não foi possível salvar. A compra foi desfeita.", "Could not save. The purchase was undone.", "No se pudo guardar. Se deshizo la compra.", "Tidak dapat menyimpan. Pembelian dibatalkan." },
            ["store.bought"] = new[] { "Combo adquirido!", "Bundle acquired!", "¡Paquete adquirido!", "Paket didapatkan!" },
            // categorias (o identificador continua sendo o nome em portugues; isto e so o texto exibido)
            ["cat.Moedas AW"] = new[] { "Moedas AW", "AW Coins", "Monedas AW", "Koin AW" },
            ["cat.Destaque"] = new[] { "Destaque", "Featured", "Destacados", "Unggulan" },
            ["cat.Veículos"] = new[] { "Veículos", "Vehicles", "Vehículos", "Kendaraan" },
            ["cat.Casas"] = new[] { "Casas", "Houses", "Casas", "Rumah" },
            ["cat.Narrativa"] = new[] { "Narrativa", "Story", "Historia", "Cerita" },
            ["cat.Criador de Avatar"] = new[] { "Criador de Avatar", "Avatar Maker", "Creador de Avatar", "Pembuat Avatar" },
            ["cat.Combos"] = new[] { "Combos", "Bundles", "Paquetes", "Paket" },
            ["cat.Moda"] = new[] { "Moda", "Fashion", "Moda", "Fesyen" },
            ["cat.Casas de Férias"] = new[] { "Casas de Férias", "Vacation Homes", "Casas de Vacaciones", "Rumah Liburan" },
            ["cat.Pets"] = new[] { "Pets", "Pets", "Mascotas", "Hewan Peliharaan" },
            ["cat.Celebrações"] = new[] { "Celebrações", "Celebrations", "Celebraciones", "Perayaan" },
            ["cat.Profissões"] = new[] { "Profissões", "Careers", "Profesiones", "Profesi" },
            ["cat.Esportes"] = new[] { "Esportes", "Sports", "Deportes", "Olahraga" },
            // subgrupos
            ["sub.Mansões"] = new[] { "Mansões", "Mansions", "Mansiones", "Rumah Mewah" },
            ["sub.Natural Chic"] = new[] { "Natural Chic", "Natural Chic", "Natural Chic", "Natural Chic" },
            ["sub.Infantis"] = new[] { "Infantis", "Kids", "Infantiles", "Anak-anak" },
            ["sub.Palco"] = new[] { "Palco", "Stage", "Escenario", "Panggung" },
            ["sub.Variados"] = new[] { "Variados", "Assorted", "Variados", "Beragam" },
            ["sub.Modernas"] = new[] { "Modernas", "Modern", "Modernas", "Modern" },
            ["sub.Família"] = new[] { "Família", "Family", "Familia", "Keluarga" },
            ["sub.Praia"] = new[] { "Praia", "Beach", "Playa", "Pantai" },
            ["sub.Cavalos"] = new[] { "Cavalos", "Horses", "Caballos", "Kuda" },
            ["sub.Luxo"] = new[] { "Luxo", "Luxury", "Lujo", "Mewah" },
            ["sub.Cães"] = new[] { "Cães", "Dogs", "Perros", "Anjing" },
            ["sub.Infantil"] = new[] { "Infantil", "Kids", "Infantil", "Anak" },
            ["sub.Estilista"] = new[] { "Estilista", "Stylist", "Estilista", "Penata Gaya" },
            ["sub.Escola"] = new[] { "Escola", "School", "Escuela", "Sekolah" },
            ["sub.Drip"] = new[] { "Drip", "Drip", "Drip", "Drip" },
            ["sub.Gatos"] = new[] { "Gatos", "Cats", "Gatos", "Kucing" },
            ["sub.Daisy"] = new[] { "Daisy", "Daisy", "Daisy", "Daisy" },
            ["sub.Férias"] = new[] { "Férias", "Vacation", "Vacaciones", "Liburan" },
            ["sub.Festas"] = new[] { "Festas", "Parties", "Fiestas", "Pesta" },
            ["sub.Carro"] = new[] { "Carro", "Car", "Coche", "Mobil" },
            ["sub.Van"] = new[] { "Van", "Van", "Furgoneta", "Van" },
            ["sub.VIP"] = new[] { "VIP", "VIP", "VIP", "VIP" },
            // ofertas (titulos)
            ["offer.bundle-PB22"] = new[] { "Galxe Mansion", "Galxe Mansion", "Galxe Mansion", "Galxe Mansion" },
            ["offer.bundle-PB7"] = new[] { "Natural Chic", "Natural Chic", "Natural Chic", "Natural Chic" },
            ["offer.bundle-PB26"] = new[] { "Casinha de brincar", "Playhouse", "Casita de juegos", "Rumah mainan" },
            ["offer.bundle-PB23"] = new[] { "Show ao vivo", "Live Show", "Show en vivo", "Pertunjukan Langsung" },
            ["offer.bundle-PB25"] = new[] { "Amiguinhos", "Little Friends", "Amiguitos", "Teman Kecil" },
            ["offer.bundle-PB2"] = new[] { "Mansão", "Mansion", "Mansión", "Rumah Mewah" },
            ["offer.bundle-PB8"] = new[] { "Bubble Glam", "Bubble Glam", "Bubble Glam", "Bubble Glam" },
            ["offer.bundle-PB9"] = new[] { "Casa Moderna", "Modern House", "Casa Moderna", "Rumah Modern" },
            ["offer.bundle-PB10"] = new[] { "Casa Kawaii", "Kawaii House", "Casa Kawaii", "Rumah Kawaii" },
            ["offer.bundle-PB11"] = new[] { "Casa de Praia", "Beach House", "Casa de Playa", "Rumah Pantai" },
            ["offer.bundle-PB12"] = new[] { "Cavalos", "Horses", "Caballos", "Kuda" },
            ["offer.bundle-PB13"] = new[] { "Ricos e Famosos", "Rich and Famous", "Ricos y Famosos", "Kaya dan Terkenal" },
            ["offer.bundle-PB14"] = new[] { "Vida em Família", "Family Life", "Vida en Familia", "Kehidupan Keluarga" },
            ["offer.bundle-PB15"] = new[] { "Cachorrinho", "Puppy", "Cachorrito", "Anak Anjing" },
            ["offer.bundle-PB16"] = new[] { "Crescendo", "Growing Up", "Creciendo", "Tumbuh Besar" },
            ["offer.bundle-PB17"] = new[] { "Estilista de Celebridades", "Celebrity Stylist", "Estilista de Celebridades", "Penata Gaya Selebriti" },
            ["offer.bundle-PB3"] = new[] { "Volta às Aulas", "Back to School", "Vuelta al Cole", "Kembali ke Sekolah" },
            ["offer.bundle-PB18"] = new[] { "Moda Drip", "Drip Fashion", "Moda Drip", "Fesyen Drip" },
            ["offer.bundle-PB19"] = new[] { "Gatinhos", "Kittens", "Gatitos", "Anak Kucing" },
            ["offer.bundle-PB20"] = new[] { "Pop Star", "Pop Star", "Estrella del Pop", "Bintang Pop" },
            ["offer.bundle-PB21"] = new[] { "Moda Daisy", "Daisy Fashion", "Moda Daisy", "Fesyen Daisy" },
            ["offer.bundle-PB24"] = new[] { "Férias de Primavera", "Spring Break", "Vacaciones de Primavera", "Liburan Musim Semi" },
            ["offer.bundle-PB27"] = new[] { "Festa à Fantasia", "Costume Party", "Fiesta de Disfraces", "Pesta Kostum" },
            ["offer.bundle-jeep-aventura"] = new[] { "Carro de Aventura", "Adventure Car", "Coche de Aventura", "Mobil Petualangan" },
            ["offer.bundle-carro-familia"] = new[] { "Carro da Família", "Family Car", "Coche Familiar", "Mobil Keluarga" },
            ["offer.bundle-viagem-inverno"] = new[] { "Viagem de Inverno em Família", "Family Winter Trip", "Viaje de Invierno en Familia", "Perjalanan Musim Dingin Keluarga" },
            ["offer.bundle-pe-na-estrada"] = new[] { "Pé na Estrada", "Hit the Road", "A la Carretera", "Ayo Berkendara" },
            ["offer.bundle-motorhome"] = new[] { "Motorhome", "Motorhome", "Autocaravana", "Motorhome" },
            ["offer.bundle-trator-agricola"] = new[] { "Trator Agrícola", "Farm Tractor", "Tractor Agrícola", "Traktor Pertanian" },
            ["offer.bundle-helicoptero-vip"] = new[] { "Helicóptero VIP", "VIP Helicopter", "Helicóptero VIP", "Helikopter VIP" },
            ["offer.bundle-limo-luxo"] = new[] { "Limusine de Luxo", "Luxury Limousine", "Limusina de Lujo", "Limusin Mewah" },
            ["offer.bundle-limo-panda"] = new[] { "Limusine Panda", "Panda Limousine", "Limusina Panda", "Limusin Panda" },
            ["offer.vehicle-slot-standard"] = new[] { "Vaga de Veículo", "Vehicle Slot", "Plaza de Vehículo", "Slot Kendaraan" },
            ["offer.vehicle-slot-premium"] = new[] { "Vaga de Veículo Premium", "Premium Vehicle Slot", "Plaza de Vehículo Premium", "Slot Kendaraan Premium" },
            // ---- Vaga de veiculo ----
            ["vehicle.title"] = new[] { "Vaga de Veículo", "Vehicle Slot", "Plaza de Vehículo", "Slot Kendaraan" },
            ["vehicle.subtitle"] = new[] { "Desbloqueie uma vaga extra para o seu carro", "Unlock an extra slot for your car", "Desbloquea una plaza extra para tu coche", "Buka slot tambahan untuk mobilmu" },
            ["vehicle.owned.premium"] = new[] { "Vaga premium já desbloqueada!", "Premium slot already unlocked!", "¡Plaza premium ya desbloqueada!", "Slot premium sudah terbuka!" },
            ["vehicle.owned"] = new[] { "Vaga de veículo já desbloqueada!", "Vehicle slot already unlocked!", "¡Plaza de vehículo ya desbloqueada!", "Slot kendaraan sudah terbuka!" },
            ["vehicle.best"] = new[] { "★ Melhor oferta ★", "★ Best deal ★", "★ Mejor oferta ★", "★ Penawaran terbaik ★" },
            ["vehicle.bonus"] = new[] { "+{0} moedas de bônus", "+{0} bonus coins", "+{0} monedas de bonificación", "+{0} koin bonus" },
            ["vehicle.missing"] = new[] { "Faltam {0} moedas.", "You need {0} more coins.", "Te faltan {0} monedas.", "Kurang {0} koin." },
            ["vehicle.already"] = new[] { "Você já tem uma vaga de veículo.", "You already have a vehicle slot.", "Ya tienes una plaza de vehículo.", "Kamu sudah memiliki slot kendaraan." },
            ["vehicle.unlocked.premium"] = new[] { "Vaga premium desbloqueada! +{0} moedas de bônus.", "Premium slot unlocked! +{0} bonus coins.", "¡Plaza premium desbloqueada! +{0} monedas de bonificación.", "Slot premium terbuka! +{0} koin bonus." },
            ["vehicle.unlocked"] = new[] { "Vaga de veículo desbloqueada!", "Vehicle slot unlocked!", "¡Plaza de vehículo desbloqueada!", "Slot kendaraan terbuka!" },
            // ---- Slots de avatar ----
            ["slots.novehicles"] = new[] { "Veículos ainda não estão disponíveis.", "Vehicles are not available yet.", "Los vehículos aún no están disponibles.", "Kendaraan belum tersedia." },
            ["slots.reserved.toast"] = new[] { "Vaga reservada. Veículos ainda não estão disponíveis.", "Slot reserved. Vehicles are not available yet.", "Plaza reservada. Los vehículos aún no están disponibles.", "Slot dipesan. Kendaraan belum tersedia." },
            ["slots.reserved.premium"] = new[] { "Vaga premium reservada", "Premium slot reserved", "Plaza premium reservada", "Slot premium dipesan" },
            ["slots.reserved"] = new[] { "Vaga reservada", "Slot reserved", "Plaza reservada", "Slot dipesan" },
            ["slots.unlock"] = new[] { "Toque para desbloquear", "Tap to unlock", "Toca para desbloquear", "Ketuk untuk membuka" },
            ["slots.pickkind"] = new[] { "Escolha o tipo de avatar", "Choose the avatar type", "Elige el tipo de avatar", "Pilih jenis avatar" },
            ["slots.nothing"] = new[] { "Não há nada para remover.", "There is nothing to remove.", "No hay nada que eliminar.", "Tidak ada yang bisa dihapus." },
            ["slots.atleastone"] = new[] { "Você precisa ter ao menos um avatar.", "You need at least one avatar.", "Necesitas al menos un avatar.", "Kamu harus punya setidaknya satu avatar." },
            ["slots.active"] = new[] { " (ativo)", " (active)", " (activo)", " (aktif)" },
            ["slots.pickremove.avatar"] = new[] { "Escolha o avatar para remover", "Choose the avatar to remove", "Elige el avatar que quieres eliminar", "Pilih avatar yang akan dihapus" },
            ["slots.avatarremoved"] = new[] { "Avatar removido.", "Avatar removed.", "Avatar eliminado.", "Avatar dihapus." },
            ["slots.pickremove.pet"] = new[] { "Escolha o pet para remover", "Choose the pet to remove", "Elige la mascota que quieres eliminar", "Pilih hewan peliharaan yang akan dihapus" },
            ["slots.petremoved"] = new[] { "Pet removido.", "Pet removed.", "Mascota eliminada.", "Hewan peliharaan dihapus." },
            ["slots.remove"] = new[] { "Remover", "Remove", "Eliminar", "Hapus" },
            // tipos de avatar e especies de pet
            ["kind.Adult"] = new[] { "Adulto", "Adult", "Adulto", "Dewasa" },
            ["kind.Toddler"] = new[] { "Criança", "Child", "Niño", "Anak" },
            ["kind.Baby"] = new[] { "Bebê", "Baby", "Bebé", "Bayi" },
            ["pet.Dog"] = new[] { "Cão", "Dog", "Perro", "Anjing" },
            ["pet.Cat"] = new[] { "Gato", "Cat", "Gato", "Kucing" },
            ["pet.Horse"] = new[] { "Cavalo", "Horse", "Caballo", "Kuda" },
            ["pet.Cow"] = new[] { "Vaca", "Cow", "Vaca", "Sapi" },
            ["pet.Rabbit"] = new[] { "Coelho", "Rabbit", "Conejo", "Kelinci" },
            ["pet.Hamster"] = new[] { "Hamster", "Hamster", "Hámster", "Hamster" },
            ["pet.Bird"] = new[] { "Pássaro", "Bird", "Pájaro", "Burung" },
            ["pet.Chicken"] = new[] { "Galinha", "Chicken", "Gallina", "Ayam" },
            ["pet.Turtle"] = new[] { "Tartaruga", "Turtle", "Tortuga", "Kura-kura" },
            ["pet.Lizard"] = new[] { "Lagarto", "Lizard", "Lagarto", "Kadal" },
            ["pet.Snake"] = new[] { "Cobra", "Snake", "Serpiente", "Ular" },
            ["pet.Fish"] = new[] { "Peixe", "Fish", "Pez", "Ikan" },
            ["reset.done"] = new[] { "Progresso reiniciado.", "Progress reset.", "Progreso reiniciado.", "Kemajuan diatur ulang." },
        };

        public static bool Has(string key) => Table.ContainsKey(key);

        public static string Get(string key) => Get(key, Current);

        public static string Get(string key, Language language)
        {
            if (!Table.TryGetValue(key, out var row)) return key;
            var text = row[(int)language];
            return string.IsNullOrEmpty(text) ? row[(int)Language.Pt] : text;
        }

        /// <summary>
        /// Texto exibido de um identificador que continua em portugues na logica (categoria, subgrupo, titulo de oferta...).
        /// Sem traducao cadastrada devolve o proprio valor, entao um item novo nunca aparece vazio.
        /// </summary>
        public static string Name(string prefix, string id, string fallback = null)
        {
            var key = prefix + id;
            return Table.ContainsKey(key) ? Get(key) : (fallback ?? id);
        }

        public static string Format(string key, params object[] args) => string.Format(Get(key), args);

        /// <summary>Todas as chaves conhecidas (usado pelo teste que garante as 4 traducoes preenchidas).</summary>
        public static IEnumerable<string> Keys => Table.Keys;
    }
}
