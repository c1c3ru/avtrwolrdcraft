using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Animacao de moeda ganha: nasce no ponto de origem, "pula" (pop de escala) e voa ate o
    /// contador de moedas, sumindo no fim. Usa o icone de moeda do proprio jogo
    /// (Resources/Icons/coin.png, extraido de Currency_Coin), nao um efeito novo inventado.
    /// </summary>
    public static class CoinFx
    {
        const string IconPath = "Icons/coin";

        public static void Play(Transform parent, Vector3 fromWorldPos, Vector3 toWorldPos)
        {
            var sprite = Resources.Load<Sprite>(IconPath);
            if (sprite == null) { Debug.LogWarning("CoinFx: " + IconPath + " nao encontrado"); return; }

            var go = new GameObject("CoinFx", typeof(RectTransform));
            go.transform.SetParent(parent, false);
            var rt = (RectTransform)go.transform;
            rt.sizeDelta = new Vector2(70, 70);
            rt.position = fromWorldPos;

            var img = go.AddComponent<Image>();
            img.sprite = sprite;
            img.preserveAspect = true;
            img.raycastTarget = false;

            var runner = go.AddComponent<CoinFxRunner>();
            runner.Run(rt, img, fromWorldPos, toWorldPos);
        }

        sealed class CoinFxRunner : MonoBehaviour
        {
            public void Run(RectTransform rt, Image img, Vector3 from, Vector3 to) => StartCoroutine(Animate(rt, img, from, to));

            IEnumerator Animate(RectTransform rt, Image img, Vector3 from, Vector3 to)
            {
                const float popDuration = 0.25f;
                const float flyDuration = 0.55f;

                float t = 0f;
                while (t < popDuration)
                {
                    t += Time.deltaTime;
                    rt.localScale = Vector3.one * Mathf.Lerp(0.2f, 1.3f, t / popDuration);
                    yield return null;
                }

                t = 0f;
                while (t < flyDuration)
                {
                    t += Time.deltaTime;
                    float p = t / flyDuration;
                    float eased = 1f - (1f - p) * (1f - p);
                    rt.position = Vector3.Lerp(from, to, eased);
                    rt.localScale = Vector3.one * Mathf.Lerp(1.3f, 0.4f, p);
                    var c = img.color;
                    c.a = p < 0.6f ? 1f : Mathf.Lerp(1f, 0f, (p - 0.6f) / 0.4f);
                    img.color = c;
                    yield return null;
                }

                Destroy(gameObject);
            }
        }
    }
}
