namespace AvatarWorld.Core.Literacy
{
    public sealed class AnswerResult
    {
        public bool Correct;
        /// <summary>Falso numa resposta certa repetida (a moeda so e paga na primeira vez).</summary>
        public bool CoinsAwarded;
        public int CoinsEarned;
        public int PazuCurrencyBalance;
    }
}
