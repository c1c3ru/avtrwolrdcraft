using System.Collections;
using System.Collections.Generic;
using AvatarWorld.Core.Literacy;
using TMPro;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Tela de desafios de alfabetizacao: mostra um LiteracyChallenge por vez, acerto paga moeda
    /// via LiteracyChallengeService e avanca para o proximo (fila circular, pratica sem limite).
    /// Cores e tamanhos de fonte seguem o padrao ja usado na Home (texto branco/cinza-roxo
    /// de legenda, extraidos de level3.json), nao uma paleta nova.
    /// </summary>
    public sealed class LiteracyChallengeScreen : MonoBehaviour
    {
        // Mesmo cinza-roxo de "LAST SAVED" / "SAVE YOUR CURRENT WORLD" na Home original.
        static readonly Color CaptionColor = new Color(0.4941f, 0.4392f, 0.5686f, 1f);
        // Fundo roxo escuro e rosa de botao: amostrados dos proprios sprites extraidos da Home
        // (sharedassets3.assets_76 / sharedassets3.assets_85), nao inventados.
        static readonly Color PanelColor = new Color(0.145f, 0.094f, 0.286f, 0.94f);
        static readonly Color ButtonColor = new Color(0.988f, 0.329f, 0.612f, 1f);
        static readonly Color CorrectColor = new Color(0.30f, 0.80f, 0.40f, 1f);
        static readonly Color WrongColor = new Color(0.90f, 0.35f, 0.30f, 1f);

        LiteracyChallengeService _service;
        List<LiteracyChallenge> _queue;
        int _queueIndex;
        System.Action _onProgress;

        GameObject _root;
        TextMeshProUGUI _prompt;
        TextMeshProUGUI _feedback;
        TextMeshProUGUI _coins;
        readonly List<GameObject> _optionButtons = new List<GameObject>();
        readonly List<TextMeshProUGUI> _optionLabels = new List<TextMeshProUGUI>();

        public void Begin(LiteracyChallengeService service, List<LiteracyChallenge> queue, System.Action onProgress = null)
        {
            _service = service;
            _queue = queue;
            _queueIndex = 0;
            _onProgress = onProgress;
            UiSceneBuilder.EnsureEventSystem();
            ShowCurrent();
        }

        void ShowCurrent()
        {
            if (_root != null) Destroy(_root);
            _optionButtons.Clear();
            _optionLabels.Clear();

            var challenge = _queue[_queueIndex];
            var desc = BuildDescription(challenge, out int promptIdx, out int feedbackIdx, out int coinsIdx, out List<int> optionIdx, out List<int> optionLabelIdx);

            var actions = new System.Collections.Generic.Dictionary<string, System.Action>();
            for (int i = 0; i < optionIdx.Count; i++)
            {
                int captured = i;
                actions["Option" + i] = () => OnOptionClicked(captured);
            }

            var objs = UiSceneBuilder.Build(desc, _ => null, actions, transform);
            _root = objs[0];
            _prompt = objs[promptIdx].GetComponent<TextMeshProUGUI>();
            _feedback = objs[feedbackIdx].GetComponent<TextMeshProUGUI>();
            _coins = objs[coinsIdx].GetComponent<TextMeshProUGUI>();
            _feedback.gameObject.SetActive(false);

            foreach (var idx in optionIdx) _optionButtons.Add(objs[idx]);
            foreach (var idx in optionLabelIdx) _optionLabels.Add(objs[idx].GetComponent<TextMeshProUGUI>());

            RefreshCoinsLabel();
        }

        void OnOptionClicked(int optionIndex)
        {
            var challenge = _queue[_queueIndex];
            var result = _service.Answer(challenge, optionIndex);

            _feedback.gameObject.SetActive(true);
            if (result.Correct)
            {
                _feedback.text = result.CoinsAwarded ? ("Certo! +" + result.CoinsEarned + " moedas") : "Certo!";
                _feedback.color = CorrectColor;
                UiSound.PlayCorrect();
                if (result.CoinsAwarded) UiSound.PlayCoin();
                foreach (var b in _optionButtons) b.GetComponent<UnityEngine.UI.Button>().interactable = false;
                RefreshCoinsLabel();
                _onProgress?.Invoke();
                StartCoroutine(AdvanceAfterDelay());
            }
            else
            {
                _feedback.text = "Tente de novo!";
                _feedback.color = WrongColor;
                UiSound.PlayWrong();
            }
        }

        IEnumerator AdvanceAfterDelay()
        {
            yield return new WaitForSeconds(1.2f);
            _queueIndex = (_queueIndex + 1) % _queue.Count;
            ShowCurrent();
        }

        void RefreshCoinsLabel() => _coins.text = "Moedas: " + _service.PazuCurrencyBalance;

        static SceneDescription BuildDescription(LiteracyChallenge challenge, out int promptIdx, out int feedbackIdx,
            out int coinsIdx, out List<int> optionIdx, out List<int> optionLabelIdx)
        {
            var desc = new SceneDescription { name = "LiteracyChallenge" };
            var nodes = desc.nodes;

            nodes.Add(new NodeDescription { name = "Canvas", isCanvas = true, hasRect = true, parent = -1 });

            nodes.Add(new NodeDescription
            {
                name = "Panel", parent = 0, hasRect = true,
                anchorMin = Vector2.zero, anchorMax = Vector2.one, pivot = new Vector2(0.5f, 0.5f),
                hasImage = true, image = new ImageDescription { color = PanelColor },
            });
            const int panel = 1;

            nodes.Add(new NodeDescription
            {
                name = "Prompt", parent = panel, hasRect = true,
                anchorMin = new Vector2(0.5f, 0.5f), anchorMax = new Vector2(0.5f, 0.5f), pivot = new Vector2(0.5f, 0.5f),
                anchoredPosition = new Vector2(0, 380), sizeDelta = new Vector2(1500, 180),
                hasText = true, text = new TextDescription { text = challenge.Prompt, fontSize = 44, color = Color.white, hAlign = 2, vAlign = 512 },
            });
            promptIdx = nodes.Count - 1;

            optionIdx = new List<int>();
            optionLabelIdx = new List<int>();
            float[] ys = { 150f, 10f, -130f, -270f };
            for (int i = 0; i < challenge.Options.Count && i < ys.Length; i++)
            {
                nodes.Add(new NodeDescription
                {
                    name = "Option" + i, parent = panel, hasRect = true,
                    anchorMin = new Vector2(0.5f, 0.5f), anchorMax = new Vector2(0.5f, 0.5f), pivot = new Vector2(0.5f, 0.5f),
                    anchoredPosition = new Vector2(0, ys[i]), sizeDelta = new Vector2(900, 110),
                    hasImage = true, image = new ImageDescription { color = ButtonColor },
                    hasButton = true, button = new ButtonDescription(),
                });
                int buttonNode = nodes.Count - 1;
                optionIdx.Add(buttonNode);

                nodes.Add(new NodeDescription
                {
                    name = "Option" + i + "Label", parent = buttonNode, hasRect = true,
                    anchorMin = Vector2.zero, anchorMax = Vector2.one, pivot = new Vector2(0.5f, 0.5f),
                    hasText = true, text = new TextDescription { text = challenge.Options[i], fontSize = 36, color = Color.white, hAlign = 2, vAlign = 512 },
                });
                optionLabelIdx.Add(nodes.Count - 1);
            }

            nodes.Add(new NodeDescription
            {
                name = "Feedback", parent = panel, hasRect = true,
                anchorMin = new Vector2(0.5f, 0.5f), anchorMax = new Vector2(0.5f, 0.5f), pivot = new Vector2(0.5f, 0.5f),
                anchoredPosition = new Vector2(0, -430), sizeDelta = new Vector2(1500, 100),
                hasText = true, text = new TextDescription { text = "", fontSize = 38, color = Color.white, hAlign = 2, vAlign = 512 },
            });
            feedbackIdx = nodes.Count - 1;

            nodes.Add(new NodeDescription
            {
                name = "Coins", parent = panel, hasRect = true,
                anchorMin = new Vector2(1, 1), anchorMax = new Vector2(1, 1), pivot = new Vector2(1, 1),
                anchoredPosition = new Vector2(-40, -40), sizeDelta = new Vector2(400, 80),
                hasText = true, text = new TextDescription { text = "", fontSize = 30, color = CaptionColor, hAlign = 4, vAlign = 256 },
            });
            coinsIdx = nodes.Count - 1;

            return desc;
        }
    }
}
