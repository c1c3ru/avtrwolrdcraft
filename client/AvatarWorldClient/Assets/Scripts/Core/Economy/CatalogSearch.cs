using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvatarWorld.Core.Economy
{
    /// <summary>
    /// Busca nos catalogos (itens da loja e pecas do avatar): minusculas, sem acento e com "_" tratado como espaco,
    /// por termos em qualquer ordem ("camisa 869" acha "Shirt_Special_869_Color" se a categoria/titulo tiver os termos).
    /// Sem dependencia da engine nem de string.Normalize (nao confiavel em todos os alvos IL2CPP): mapa manual de acentos latinos.
    /// </summary>
    public static class CatalogSearch
    {
        const string Accented = "áàâãäåéèêëíìîïóòôõöúùûüçñÿ";
        const string Plain = "aaaaaaeeeeiiiiooooouuuucny";

        public static string Normalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";
            var sb = new StringBuilder(text.Length);
            foreach (char raw in text.Trim().ToLowerInvariant())
            {
                int i = Accented.IndexOf(raw);
                char c = i >= 0 ? Plain[i] : raw;
                sb.Append(c == '_' || c == '-' ? ' ' : c);
            }
            return sb.ToString();
        }

        public static string[] Tokens(string query) =>
            Normalize(query).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        /// <summary>True se todos os termos da consulta aparecem em algum lugar do texto (ja normalizado).</summary>
        public static bool MatchesNormalized(string normalizedText, string[] tokens)
        {
            foreach (var token in tokens)
                if (normalizedText.IndexOf(token, StringComparison.Ordinal) < 0) return false;
            return true;
        }

        public static bool Matches(string text, string query) => MatchesNormalized(Normalize(text), Tokens(query));

        public static int PageCount(int total, int pageSize) => Math.Max(1, (Math.Max(0, total) + pageSize - 1) / pageSize);
    }

    /// <summary>Uma linha de catalogo (item da loja ou peca de avatar), com texto de busca pre-normalizado.</summary>
    public sealed class CatalogEntry
    {
        public readonly string Id, Title, Category, Search;

        public CatalogEntry(string id, string title, string category)
        {
            Id = id ?? ""; Title = title ?? ""; Category = category ?? "";
            Search = CatalogSearch.Normalize(Title + " " + Category + " " + Id);
        }
    }

    /// <summary>
    /// Visao paginada de um catalogo: consulta de texto + categoria + pagina. Logica pura para a tela de catalogos
    /// (<c>StudioCatalogScreen</c>) e para os testes. Mudar consulta ou categoria volta para a pagina 0.
    /// </summary>
    public sealed class CatalogView
    {
        readonly IReadOnlyList<CatalogEntry> _all;
        List<CatalogEntry> _filtered;
        string[] _tokens = new string[0];

        public CatalogView(IEnumerable<CatalogEntry> entries, int pageSize)
        {
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize));
            _all = (entries ?? throw new ArgumentNullException(nameof(entries))).ToList();
            PageSize = pageSize;
            Query = ""; Category = "";
            Refilter();
        }

        public int PageSize { get; }
        public string Query { get; private set; }
        /// <summary>Vazio = todas as categorias.</summary>
        public string Category { get; private set; }
        public int Page { get; private set; }
        public int Total => _all.Count;
        public int Count => _filtered.Count;
        public int PageCount => CatalogSearch.PageCount(_filtered.Count, PageSize);

        public IReadOnlyList<CatalogEntry> CurrentPage =>
            _filtered.Skip(Page * PageSize).Take(PageSize).ToList();

        /// <summary>Categorias mais frequentes (maior contagem primeiro; empate por nome), ate <paramref name="max"/>.</summary>
        public IReadOnlyList<string> TopCategories(int max) => _all
            .GroupBy(e => e.Category).Where(g => g.Key.Length > 0)
            .OrderByDescending(g => g.Count()).ThenBy(g => g.Key, StringComparer.Ordinal)
            .Take(max).Select(g => g.Key).ToList();

        public void SetQuery(string query)
        {
            Query = query ?? "";
            _tokens = CatalogSearch.Tokens(Query);
            Page = 0;
            Refilter();
        }

        public void SetCategory(string category)
        {
            Category = category ?? "";
            Page = 0;
            Refilter();
        }

        public void SetPage(int page) => Page = Math.Max(0, Math.Min(page, PageCount - 1));

        /// <summary>Anda de pagina em volta (a ultima volta para a primeira).</summary>
        public void Move(int delta)
        {
            int pages = PageCount;
            Page = ((Page + delta) % pages + pages) % pages;
        }

        void Refilter()
        {
            _filtered = _all.Where(e => (Category.Length == 0 || e.Category == Category) &&
                                        CatalogSearch.MatchesNormalized(e.Search, _tokens)).ToList();
            Page = Math.Min(Page, PageCount - 1);
        }
    }
}
