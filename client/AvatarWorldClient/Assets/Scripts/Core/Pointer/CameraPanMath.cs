namespace AvatarWorld.Core.Pointer
{
    /// <summary>Resultado de um passo de pan da camera do mundo.</summary>
    public struct CameraPanStep
    {
        public float X, Y;
        /// <summary>O original so dispara OnBeginDrag (e desliga o CShapeRaycaster) quando isto vira verdadeiro.</summary>
        public bool BeginDrag;
    }

    /// <summary>
    /// Matematica do pan da camera, como PWC.GameCameraBase (docs/loops/results/L02.md; tools/recon_camera_drag.py).
    /// - Awake (0x206dca0): fator = 10.24 / Screen.height (unidades de mundo por pixel; 10.24 = HEIGHT = 2 * 5.12).
    /// - OnDrag (0x206e9e0): x = clamp(camX - (mouse.x - last.x) * fator, xMin, xMax); y = camY - (mouse.y - last.y) * fator.
    ///   OnBeginDrag so dispara quando |x - camX| > 0.01 (unidades de mundo) e ainda nao esta arrastando; o eixo y e aplicado
    ///   em todo quadro, mesmo antes de IsDragging.
    /// - Update (0x206e7ec): so ha pan com ponteiro primario (GetMouseButton(0)); nao ha pinca nem scroll no gameplay.
    ///   Nao provado: o clamp vertical (feito em CameraMovementClampper.SetPosition, nao aberto).
    /// </summary>
    public static class CameraPanMath
    {
        public const float Height = 10.24f;
        public const float BeginDragThreshold = 0.01f;

        public static float DragFactor(float screenHeightPixels)
        {
            return Height / screenHeightPixels;
        }

        /// <summary>Gate do Update: isDraggable e (movimento permitido com zoom ou zoom no padrao).</summary>
        public static bool MovementAllowed(bool isDraggable, bool allowMovementWhenZoomNotDefault, bool isZoomNotDefault)
        {
            return isDraggable && (allowMovementWhenZoomNotDefault || !isZoomNotDefault);
        }

        /// <summary>Com ShouldConsiderCShapes ligado, um CShape sob o ponteiro (LastResultCount >= 1) impede o pan.</summary>
        public static bool PanBlockedByShape(bool shouldConsiderShapes, int shapeHitCount)
        {
            return shouldConsiderShapes && shapeHitCount >= 1;
        }

        public static CameraPanStep Step(float camX, float camY, float lastMouseX, float lastMouseY,
                                         float mouseX, float mouseY, float factor,
                                         float xMin, float xMax, bool isDragging)
        {
            float x = camX - (mouseX - lastMouseX) * factor;
            float upperClamped = x > xMax ? xMax : x;               // fcsel s1,s1,s13,gt
            x = x >= xMin ? upperClamped : xMin;                    // fcsel s13,s1,s0,pl (compara o x original)
            float y = camY - (mouseY - lastMouseY) * factor;
            bool begin = !isDragging && System.Math.Abs(x - camX) > BeginDragThreshold;
            return new CameraPanStep { X = x, Y = y, BeginDrag = begin };
        }
    }
}
