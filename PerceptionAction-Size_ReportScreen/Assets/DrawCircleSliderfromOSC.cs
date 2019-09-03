using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawCircleSliderfromOSC : MonoBehaviour
{
    //source www.youtube.com/watch?v=BoDwchoM9Ic

    public vLine line;
    public int vertexCount = 40;
    public float lineWidth = 0.2f;
    public float radius;
    public bool circleFillScreen = false;
    public bool circleSliderControl = true;
    public GameObject positionRef;

    private LineRenderer lineRenderer;
    private float adj_zpos;

    // Start is called before the first frame update
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupCircle();
    }

    private void Update()
    {
        
        if (circleSliderControl)
        {
            radius = line.slPos.y;
            adj_zpos = positionRef.transform.position.z - 0.3f;

            if (Globals.GlobalVar.prev_radius != radius)
            {
                
                //Debug.Log("radius: " + radius);
                radius = radius - 2f;
                Globals.GlobalVar.prev_radius = radius;
                float deltaTheta = (2f * Mathf.PI) / vertexCount;
                float theta = 0f;

                lineRenderer.positionCount = vertexCount;

                for (int i = 0; i < lineRenderer.positionCount; i++)
                {
                    Vector3 pos = new Vector3(radius * Mathf.Cos(theta), (radius * Mathf.Sin(theta))+2f, adj_zpos);
                    lineRenderer.SetPosition(i, pos);
                    theta += deltaTheta;
                }
            }
        }
    }

    private void SetupCircle()
    {
        lineRenderer.widthMultiplier = lineWidth;

        if (circleFillScreen)
        {
            radius = Vector3.Distance(Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMax, adj_zpos)),
                Camera.main.ScreenToWorldPoint(new Vector3(0f, Camera.main.pixelRect.yMin, adj_zpos))) * 0.5f - lineWidth;

            float deltaTheta = (2f * Mathf.PI) / vertexCount;
            float theta = 0f;

            lineRenderer.positionCount = vertexCount;

            for (int i = 0; i < lineRenderer.positionCount; i++)
            {
                Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
                lineRenderer.SetPosition(i, pos);
                theta += deltaTheta;
            }
        }

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (circleFillScreen)
        {
            float deltaTheta = (2f * Mathf.PI) / vertexCount;
            float theta = 0f;

            Vector3 oldPos = Vector3.zero;
            for (int i = 0; i < vertexCount + 1; i++)
            {
                Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), adj_zpos);
                Gizmos.DrawLine(oldPos, transform.position + pos);
                oldPos = transform.position + pos;

                theta += deltaTheta;
            }
        }
    }
#endif
}
