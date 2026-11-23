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
            ["reset.done"] = new[] { "Progresso reiniciado.", "Progress reset.", "Progreso reiniciado.", "Kemajuan diatur ulang." },
        };

        public static string Get(string key) => Get(key, Current);

        public static string Get(string key, Language language)
        {
            if (!Table.TryGetValue(key, out var row)) return key;
            var text = row[(int)language];
            return string.IsNullOrEmpty(text) ? row[(int)Language.Pt] : text;
        }

        public static string Format(string key, params object[] args) => string.Format(Get(key), args);

        /// <summary>Todas as chaves conhecidas (usado pelo teste que garante as 4 traducoes preenchidas).</summary>
        public static IEnumerable<string> Keys => Table.Keys;
    }
}
