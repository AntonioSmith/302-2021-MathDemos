using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer))]
public class GenerateRingPath : MonoBehaviour
{
    [Range(10, 60)] public int num = 10;
    [Range(3, 20)] public float radius = 5;
    LineRenderer line;

    EventSystem events;

    void Start()
    {
        GeneratePath();
    }

    private void OnValidate() // can edit in inspector and see results without running game
    {
        GeneratePath();
    }

    private void GeneratePath()
    {
        line = GetComponent<LineRenderer>();

        // generate points
        float rad = 0;

        Vector3[] pts = new Vector3[num];

        for (int i = 0; i < num; i++)
        {
            pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;
            rad += Mathf.PI * 2 / num; // increases angle
        }
        line.positionCount = num;
        line.SetPositions(pts);
    }
}
