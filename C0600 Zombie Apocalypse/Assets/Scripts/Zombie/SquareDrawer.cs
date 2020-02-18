using UnityEngine;
using System.Collections;

public class SquareDrawer : MonoBehaviour
{

    public Vector3 center;
    public Vector3 size;
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}