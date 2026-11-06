using System;

namespace AvatarWorld.Core.World
{
    /// <summary>
    /// Movimento das animacoes do mapa (WorldCloudsSpawner / WorldTrain do original). Os PONTOS e TEMPOS vem dos dados
    /// exportados da cena; velocidade das nuvens e pausas do trem NAO estao serializados (sao constantes do codigo
    /// original nao recuperadas) e aqui sao aproximacoes declaradas.
    /// </summary>
    public static class WorldAnimation
    {
        /// <summary>Faixa de velocidade das nuvens, em unidades de mundo por segundo (aproximacao).</summary>
        public const float CloudMinSpeed = 0.25f, CloudMaxSpeed = 0.55f;

        /// <summary>Velocidade estavel por nuvem (mesmo id = mesma velocidade em toda sessao).</summary>
        public static float CloudSpeed(int cloudId)
        {
            uint h = (uint)cloudId * 2654435761u; // hash multiplicativo de Knuth
            float t = (h >> 8 & 0xFFFF) / 65535f;
            return CloudMinSpeed + (CloudMaxSpeed - CloudMinSpeed) * t;
        }

        /// <summary>
        /// Desloca uma nuvem por dt. Ao passar do ponto final volta ao inicial (o original destroi a nuvem e o spawner
        /// cria outra la): devolve o novo x e quanto o grupo inteiro foi deslocado (para mover os sprites juntos).
        /// </summary>
        public static float AdvanceCloud(float x, float dt, float speed, float startX, float endX)
        {
            float dir = endX >= startX ? 1f : -1f;
            float next = x + dir * speed * dt;
            bool past = dir > 0 ? next > endX : next < endX;
            return past ? startX + (next - endX) : next;
        }

        /// <summary>Segundos que o trem fica parado na estacao e fora de cena entre passagens (aproximacao).</summary>
        public const float TrainDwellSeconds = 6f, TrainAwaySeconds = 8f;

        public static float TrainPeriod(float toStartSeconds, float toGoSeconds) =>
            toStartSeconds + TrainDwellSeconds + toGoSeconds + TrainAwaySeconds;

        /// <summary>
        /// Posicao x do trem em t segundos: chega do ponto inicial a estacao (toStartSeconds), para, sai para o ponto
        /// final (toGoSeconds), fica fora de cena e recomeca. A estacao e a posicao do trem na cena exportada.
        /// </summary>
        public static float TrainX(float t, float startX, float stationX, float goX, float toStartSeconds, float toGoSeconds)
        {
            float period = TrainPeriod(toStartSeconds, toGoSeconds);
            if (period <= 0f) return stationX;
            t = ((t % period) + period) % period;
            if (t < toStartSeconds) return Lerp(startX, stationX, EaseOut(t / Math.Max(toStartSeconds, 0.0001f)));
            t -= toStartSeconds;
            if (t < TrainDwellSeconds) return stationX;
            t -= TrainDwellSeconds;
            if (t < toGoSeconds) return Lerp(stationX, goX, EaseIn(t / Math.Max(toGoSeconds, 0.0001f)));
            return goX; // fora de cena ate o proximo ciclo (o runtime esconde/teleporta pelo limite da camera)
        }

        static float Lerp(float a, float b, float t) => a + (b - a) * t;
        static float EaseOut(float t) => 1f - (1f - t) * (1f - t);
        static float EaseIn(float t) => t * t;
    }
}
