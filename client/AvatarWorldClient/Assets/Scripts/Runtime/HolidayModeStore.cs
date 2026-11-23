using System;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>Liga/desliga o modo feriado (preferencia local; ver Core.World.HolidayMode para as regras).</summary>
    public static class HolidayModeStore
    {
        public const string PrefsKey = "home.holiday";

        public static bool IsOn
        {
            get { try { return PlayerPrefs.GetInt(PrefsKey, 0) != 0; } catch (Exception) { return false; } }
            set { try { PlayerPrefs.SetInt(PrefsKey, value ? 1 : 0); PlayerPrefs.Save(); } catch (Exception) { /* sem preferencia: segue desligado */ } }
        }
    }
}
