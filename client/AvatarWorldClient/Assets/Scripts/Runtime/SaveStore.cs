using System;
using System.IO;
using AvatarWorld.Core.Economy;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Salva e carrega o PlayerState em JSON. Escrita atomica (arquivo temporario + troca) para que uma queda
    /// no meio do save nao corrompa o anterior. Save ilegivel e preservado como .corrupt, nunca apagado.
    /// </summary>
    public sealed class SaveStore
    {
        readonly string _path;

        public SaveStore(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("caminho vazio", nameof(path));
            _path = path;
        }

        public static string DefaultPath => Path.Combine(Application.persistentDataPath, "player_state.json");

        public bool Exists => File.Exists(_path);

        public PlayerState LoadOrCreate(int startingPazuCurrency)
        {
            if (!File.Exists(_path)) return PlayerState.CreateNew(startingPazuCurrency);
            try
            {
                var state = JsonUtility.FromJson<PlayerState>(File.ReadAllText(_path));
                if (state == null || state.PazuCurrency < 0 || state.LoyaltyPoints < 0) throw new InvalidDataException("estado invalido");
                return state;
            }
            catch (Exception e) when (e is ArgumentException || e is InvalidDataException || e is IOException)
            {
                string backup = _path + ".corrupt";
                try { File.Copy(_path, backup, true); } catch (IOException) { /* melhor esforco */ }
                Debug.LogWarning("Save ilegivel (" + e.GetType().Name + "); copia em " + backup + ". Iniciando estado novo.");
                return PlayerState.CreateNew(startingPazuCurrency);
            }
        }

        public void Save(PlayerState state)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));
            string dir = Path.GetDirectoryName(_path);
            if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);

            string tmp = _path + ".tmp";
            File.WriteAllText(tmp, JsonUtility.ToJson(state, true));
            if (File.Exists(_path)) File.Replace(tmp, _path, null);
            else File.Move(tmp, _path);
        }
    }
}
