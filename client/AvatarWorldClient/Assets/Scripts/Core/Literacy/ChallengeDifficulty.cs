namespace AvatarWorld.Core.Literacy
{
    /// <summary>
    /// Liga o valor (preco em moedas) de um item ao nivel de dificuldade dos desafios que o
    /// jogador responde para ganhar moedas: item barato -> desafio facil, item caro -> dificil.
    /// Precos observados na loja original: 300 a 1400 moedas.
    /// </summary>
    public static class ChallengeDifficulty
    {
        public const int Easy = 1;
        public const int Medium = 2;
        public const int Hard = 3;

        /// <summary>Valor do "Pacote Inicial" na Home (nao tem preco no original: era compra com dinheiro real).</summary>
        public const int StarterPackValue = 700;

        public const int EasyMaxPrice = 500;
        public const int MediumMaxPrice = 899;

        public static int ForPrice(int price)
        {
            if (price <= EasyMaxPrice) return Easy;
            if (price <= MediumMaxPrice) return Medium;
            return Hard;
        }

        public static int RewardFor(int difficulty)
        {
            switch (difficulty)
            {
                case Easy: return 10;
                case Medium: return 15;
                default: return 20;
            }
        }

        public static string LabelFor(int difficulty)
        {
            switch (difficulty)
            {
                case Easy: return "Fácil";
                case Medium: return "Médio";
                default: return "Difícil";
            }
        }
    }
}
