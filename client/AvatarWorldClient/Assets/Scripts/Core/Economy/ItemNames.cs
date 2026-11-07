using System.Text;
using System.Text.RegularExpressions;

namespace AvatarWorld.Core.Economy
{
    /// <summary>
    /// Nome legivel de um item de cena a partir do nome interno do asset (ex.: "Food_01_ChocoSnackbar_Box_P134"
    /// -> "Food 01 Choco Snackbar Box"). Remove codigos de pacote/cena (P134, L195, Z1B1L1, WS2, T1S4) e separa
    /// palavras coladas em CamelCase. Nao traduz; o nome original continua em CatalogItem.Name.
    /// </summary>
    public static class ItemNames
    {
        static readonly Regex Code = new Regex(@"^(?:[A-Z]{1,2}\d+|(?:[A-Z]{1,2}\d+){2,}|UC|UGC)$", RegexOptions.Compiled);
        static readonly Regex Camel = new Regex(@"(?<=[a-z])(?=[A-Z])", RegexOptions.Compiled);

        public static string Display(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return "";
            var sb = new StringBuilder();
            foreach (var part in raw.Split(new[] { '_', ' ' }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                if (Code.IsMatch(part)) continue;
                if (sb.Length > 0) sb.Append(' ');
                sb.Append(Camel.Replace(part, " "));
            }
            string result = sb.ToString().Trim();
            return result.Length > 0 ? result : raw.Trim();
        }
    }
}
