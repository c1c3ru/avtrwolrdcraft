using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarWorld.Runtime
{
    // Formato gerado por tools/export_level.py. Os nomes dos campos devem bater com o JSON (JsonUtility).

    [Serializable]
    public sealed class SceneDescription
    {
        public string name;
        public List<NodeDescription> nodes = new List<NodeDescription>();
    }

    [Serializable]
    public sealed class NodeDescription
    {
        public int id;
        /// <summary>Indice do pai em SceneDescription.nodes; -1 = raiz.</summary>
        public int parent = -1;
        public string name;
        public bool active = true;
        public bool hasRect;
        public bool isCanvas;
        public Vector3 localScale = Vector3.one;
        public Quaternion localRotation = Quaternion.identity;
        public Vector3 localPosition;

        public Vector2 anchorMin;
        public Vector2 anchorMax;
        public Vector2 pivot = new Vector2(0.5f, 0.5f);
        public Vector2 anchoredPosition;
        public Vector2 sizeDelta;

        public bool hasImage;
        public ImageDescription image;
        public bool hasText;
        public TextDescription text;
        public bool hasButton;
        public ButtonDescription button;

        /// <summary>Componentes do original que o construtor ainda nao reproduz (visibilidade, nao erro).</summary>
        public List<string> ignoredComponents = new List<string>();
    }

    [Serializable]
    public sealed class ImageDescription
    {
        public string sprite;
        public Color color = Color.white;
        public int imageType;
        public bool raycastTarget = true;
        public bool preserveAspect;
        public bool enabled = true;
    }

    [Serializable]
    public sealed class TextDescription
    {
        public string text;
        public float fontSize = 36f;
        public Color color = Color.white;
        /// <summary>TMPro.HorizontalAlignmentOptions (flags: Left=1, Center=2, Right=4...).</summary>
        public int hAlign = 2;
        /// <summary>TMPro.VerticalAlignmentOptions (Top=256, Middle=512, Bottom=1024...).</summary>
        public int vAlign = 512;
        public bool autoSize;
        public float minSize = 18f;
        public float maxSize = 72f;
        public bool enabled = true;
    }

    [Serializable]
    public sealed class ClickCall
    {
        public string method;
        public string type;
    }

    [Serializable]
    public sealed class ButtonDescription
    {
        public bool interactable = true;
        public List<ClickCall> onClick = new List<ClickCall>();
    }
}
