using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine.UI;
using UnityEngine;

[AddComponentMenu("UI/UIEffects/UIOutline")]
public sealed class UIOutline : Shadow
{
    private const int CAPACITY_MULTIPLIER = 5;
    private const int ALPHA_DIVIDER = 255;

    private const float DEGREES_AROUND = 360f;

    [Space]
    [Tooltip("Number of vertex displacement directions")]
    [SerializeField][Range(4, 24)] private int _smoothness;

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive())
        {
            return;
        }

        var vertices = ListPool<UIVertex>.Get();

        vh.GetUIVertexStream(vertices);

        int neededCapacity = vertices.Count * CAPACITY_MULTIPLIER;

        if (vertices.Capacity < neededCapacity)
        {
            vertices.Capacity = neededCapacity;
        }

        ApplyOutline(vertices);

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertices);

        ListPool<UIVertex>.Release(vertices);
    }

    private void ApplyOutline(List<UIVertex> vertices)
    {
        int start = 0;
        int end = vertices.Count;
        float angleStep = DEGREES_AROUND / _smoothness;

        for (int i = 0; i < _smoothness; ++i)
        {
            float radians = angleStep * i * Mathf.Deg2Rad;
            var direction = new Vector2
            (
                Mathf.Cos(radians) * effectDistance.x,
                Mathf.Sin(radians) * effectDistance.y
            );

            ApplyShadowZeroAlloc(vertices, effectColor, start, end, direction.x, direction.y);

            start = end;
            end = vertices.Count;
        }
    }

    private new void ApplyShadowZeroAlloc(List<UIVertex> vertices, Color32 color, int start, int end, float x, float y)
    {
        var neededCapacity = vertices.Count + end - start;

        if (vertices.Capacity < neededCapacity)
        {
            vertices.Capacity = neededCapacity;
        }

        for (int i = start; i < end; ++i)
        {
            var vertex = vertices[i];

            vertices.Add(vertex);

            vertex.position.x += x;
            vertex.position.y += y;

            if (useGraphicAlpha)
            {
                color.a = (byte)(color.a * vertices[i].color.a / ALPHA_DIVIDER);
            }

            vertex.color = color;
            vertices[i] = vertex;
        }
    }
}
