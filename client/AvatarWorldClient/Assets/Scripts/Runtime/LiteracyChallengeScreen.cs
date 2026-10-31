using System.Collections;
using System.Collections.Generic;
using AvatarWorld.Core.Literacy;
using TMPro;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    /// <summary>
    /// Tela de desafios de alfabetizacao: mostra um LiteracyChallenge por vez, acerto paga moeda via
    /// LiteracyChallengeService e avanca para o proximo. A ordem e embaralhada a cada volta na fila
    /// (nao sequencial), e uma volta completa mostra uma tela de conclusao em vez de reiniciar direto.
    /// O painel reaproveita um fundo de popup real do jogo (Resources/Icons/quiz_panel, extraido de
    /// UI_PopUpBG_Pink), nao uma cor solida inventada.
    /// </summary>
    public sealed class LiteracyChallengeScreen : MonoBehaviour
    {
        // Mesmo cinza-roxo de "LAST SAVED" / "SAVE YOUR CURRENT WORLD" na Home original.
        static readonly Color CaptionColor = new Color(0.4941f, 0.4392f, 0.5686f, 1f);
        // Texto escuro pra ler bem sobre o painel rosa claro (quiz_panel), nao branco como antes
        // (o painel era roxo escuro; agora e um sprite claro do proprio jogo).
        static readonly Color DarkTextColor = new Color(0.25f, 0.14f, 0.32f, 1f);
        static readonly Color BackdropColor = new Color(0.09f, 0.06f, 0.16f, 0.72f);
        static readonly Color ButtonColor = new Color(0.988f, 0.329f, 0.612f, 1f);
        static readonly Color CorrectColor = new Color(0.12f, 0.55f, 0.28f, 1f);
        static readonly Color WrongColor = new Color(0.75f, 0.2f, 0.18f, 1f);

        static readonly string[] EncouragementMessages =
        {
            "Quase la! Tenta de novo!",
            "Voce consegue! Vamos tentar outra vez!",
            "Essa nao foi, mas voce ja quase acertou!",
            "Continue tentando, voce esta indo bem!",
            "Nao foi dessa vez, mas nao desiste!",
        };

        LiteracyChallengeService _service;
        List<LiteracyChallenge> _queue;
        int _queueIndex;
        int _sessionCoinsEarned;
        System.Action _onProgress;
        System.Random _rng = new System.Random();

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
            Shuffle(_queue);
            _queueIndex = 0;
            _onProgress = onProgress;
            UiSceneBuilder.EnsureEventSystem();
            ShowCurrent();
        }

        void Shuffle(List<LiteracyChallenge> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = _rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

        static Sprite LoadIcon(string key) => Resources.Load<Sprite>("Icons/" + key);

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

            actions["CloseButton"] = Close;
            var objs = UiSceneBuilder.Build(desc, LoadIcon, actions, transform);
            _root = objs[0];
            // Canvas raiz separado do da Home: sem sortingOrder explicito, a ordem entre dois Canvas
            // ScreenSpaceOverlay no mesmo order(0) nao e garantida - podia renderizar atras da Home
            // (clique funcionava, tela so nao aparecia por cima).
            _root.GetComponent<Canvas>().sortingOrder = 10;
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
                if (result.CoinsAwarded)
                {
                    UiSound.PlayCoin();
                    _sessionCoinsEarned += result.CoinsEarned;
                    CoinFx.Play(_root.transform, _feedback.transform.position, _coins.transform.position);
                }
                foreach (var b in _optionButtons) b.GetComponent<UnityEngine.UI.Button>().interactable = false;
                RefreshCoinsLabel();
                _onProgress?.Invoke();
                StartCoroutine(AdvanceAfterDelay());
            }
            else
            {
                _feedback.text = EncouragementMessages[_rng.Next(EncouragementMessages.Length)];
                _feedback.color = WrongColor;
                UiSound.PlayWrong();
            }
        }

        IEnumerator AdvanceAfterDelay()
        {
            yield return new WaitForSeconds(1.2f);
            _queueIndex++;
            if (_queueIndex >= _queue.Count) ShowCompletion();
            else ShowCurrent();
        }

        /// <summary>Fim de uma volta completa na fila (ja embaralhada): para e avisa em vez de
        /// reiniciar sem dizer nada (o loop "sem fim e silencioso" reportado pelo usuario).</summary>
        void ShowCompletion()
        {
            if (_root != null) Destroy(_root);
            _optionButtons.Clear();
            _optionLabels.Clear();

            var desc = BuildCompletionDescription(_sessionCoinsEarned);
            var actions = new System.Collections.Generic.Dictionary<string, System.Action>
            {
                { "PlayAgainButton", () => { Shuffle(_queue); _queueIndex = 0; _sessionCoinsEarned = 0; ShowCurrent(); } },
                { "CloseButton", Close },
            };
            var objs = UiSceneBuilder.Build(desc, LoadIcon, actions, transform);
            _root = objs[0];
            _root.GetComponent<Canvas>().sortingOrder = 10;
        }

        void Close() => Destroy(gameObject);

        void RefreshCoinsLabel() => _coins.text = "Moedas: " + _service.PazuCurrencyBalance;

        /// <summary>Fundo escuro de tela cheia (escurece a Home atras) + cartao com o sprite real de
        /// popup do jogo (quiz_panel, 9-slice). Retorna o indice do cartao, onde os filhos entram.</summary>
        static int AddBackdropAndCard(List<NodeDescription> nodes)
        {
            nodes.Add(new NodeDescription
            {
                name = "Backdrop", parent = 0, hasRect = true,
                anchorMin = Vector2.zero, anchorMax = Vector2.one, pivot = new Vector2(0.5f, 0.5f),
                hasImage = true, image = new ImageDescription { color = BackdropColor },
            });

            nodes.Add(new NodeDescription
            {
                name = "Card", parent = 0, hasRect = true,
                anchorMin = new Vector2(0.5f, 0.5f), anchorMax = new Vector2(0.5f, 0.5f), pivot = new Vector2(0.5f, 0.5f),
                sizeDelta = new Vector2(1750, 1000),
                hasImage = true, image = new ImageDescription { sprite = "quiz_panel", imageType = 1, color = Color.white },
            });
            return nodes.Count - 1;
        }

        static SceneDescription BuildDescription(LiteracyChallenge challenge, out int promptIdx, out int feedbackIdx,
            out int coinsIdx, out List<int> optionIdx, out List<int> optionLabelIdx)
        {
            var desc = new SceneDescription { name = "LiteracyChallenge" };
            var nodes = desc.nodes;

            nodes.Add(new NodeDescription { name = "Canvas", isCanvas = true, hasRect = true, parent = -1 });
            int panel = AddBackdropAndCard(nodes);

            nodes.Add(new NodeDescription
            {
                name = "Prompt", parent = panel, hasRect = true,
                anchorMin = new Vector2(0.5f, 0.5f), anchorMax = new Vector2(0.5f, 0.5f), pivot = new Vector2(0.5f, 0.5f),
                anchoredPosition = new Vector2(0, 380), sizeDelta = new Vector2(1500, 180),
                hasText = true, text = new TextDescription { text = challenge.Prompt, fontSize = 44, color = DarkTextColor, hAlign = 2, vAlign = 512 },
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
                anchoredPosition = new Vector2(0, -400), sizeDelta = new Vector2(1600, 100),
                hasText = true, text = new TextDescription { text = "", fontSize = 36, color = Color.white, hAlign = 2, vAlign = 512 },
            });
            feedbackIdx = nodes.Count - 1;

            nodes.Add(new NodeDescription
            {
                name = "Coins", parent = panel, hasRect = true,
                anchorMin = new Vector2(1, 1), anchorMax = new Vector2(1, 1), pivot = new Vector2(1, 1),
                anchoredPosition = new Vector2(-60, -50), sizeDelta = new Vector2(400, 80),
                hasText = true, text = new TextDescription { text = "", fontSize = 30, color = CaptionColor, hAlign = 4, vAlign = 256 },
            });
            coinsIdx = nodes.Count - 1;

            AddCloseButton(nodes, panel);

            return desc;
        }

        /// <summary>X no canto, sempre presente: sem isso a crianca ficava presa na tela de desafios
        /// ate zerar a fila inteira (o "loop sem fim" reportado pelo usuario).</summary>
        static void AddCloseButton(List<NodeDescription> nodes, int panel)
        {
            nodes.Add(new NodeDescription
            {
                name = "CloseButton", parent = panel, hasRect = true,
                anchorMin = new Vector2(0, 1), anchorMax = new Vector2(0, 1), pivot = new Vector2(0, 1),
                anchoredPosition = new Vector2(60, -50), sizeDelta = new Vector2(80, 80),
                hasImage = true, image = new ImageDescription { color = ButtonColor },
                hasButton = true, button = new ButtonDescription(),
            });
            int closeNode = nodes.Count - 1;
            nodes.Add(new NodeDescription
            {
                name = "CloseButtonLabel", parent = closeNode, hasRect = true,
                anchorMin = Vector2.zero, anchorMax = Vector2.one, pivot = new Vector2(0.5f, 0.5f),
                hasText = true, text = new TextDescription { text = "X", fontSize = 36, color = Color.white, hAlign = 2, vAlign = 512 },
            });
        }

        static SceneDescription BuildCompletionDescription(int coinsEarned)
        {
            var desc = new SceneDescription { name = "LiteracyCompletion" };
            var nodes = desc.nodes;

            nodes.Add(new NodeDescription { name = "Canvas", isCanvas = true, hasRect = true, parent = -1 });
            int panel = AddBackdropAndCard(nodes);

            nodes.Add(new NodeDescription
            {
                name = "Title", parent = panel, hasRect = true,
                anchorMin = new Vector2(0.5f, 0.5f), anchorMax = new Vector2(0.5f, 0.5f), pivot = new Vector2(0.5f, 0.5f),
                anchoredPosition = new Vector2(0, 200), sizeDelta = new Vector2(1500, 160),
                hasText = true, text = new TextDescription { text = "Parabens! Voce respondeu tudo!", fontSize = 48, color = CorrectColor, hAlign = 2, vAlign = 512 },
            });

            nodes.Add(new NodeDescription
            {
                name = "Summary", parent = panel, hasRect = true,
                anchorMin = new Vector2(0.5f, 0.5f), anchorMax = new Vector2(0.5f, 0.5f), pivot = new Vector2(0.5f, 0.5f),
                anchoredPosition = new Vector2(0, 60), sizeDelta = new Vector2(1500, 100),
                hasText = true, text = new TextDescription { text = "Moedas ganhas agora: " + coinsEarned, fontSize = 38, color = DarkTextColor, hAlign = 2, vAlign = 512 },
            });

            nodes.Add(new NodeDescription
            {
                name = "PlayAgainButton", parent = panel, hasRect = true,
                anchorMin = new Vector2(0.5f, 0.5f), anchorMax = new Vector2(0.5f, 0.5f), pivot = new Vector2(0.5f, 0.5f),
                anchoredPosition = new Vector2(0, -80), sizeDelta = new Vector2(900, 110),
                hasImage = true, image = new ImageDescription { color = ButtonColor },
                hasButton = true, button = new ButtonDescription(),
            });
            nodes.Add(new NodeDescription
            {
                name = "PlayAgainLabel", parent = nodes.Count - 1, hasRect = true,
                anchorMin = Vector2.zero, anchorMax = Vector2.one, pivot = new Vector2(0.5f, 0.5f),
                hasText = true, text = new TextDescription { text = "Jogar de novo", fontSize = 36, color = Color.white, hAlign = 2, vAlign = 512 },
            });

            AddCloseButton(nodes, panel);

            return desc;
        }
    }
}
