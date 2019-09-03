using UnityEngine;

public class Line : MonoBehaviour
{
    public float lineWidth = 0.2f;
    public string sortingLayer;

    public drawCircle circle;
    public Transform leftCog;
    public Transform rightCog;

    private LineRenderer lineRenderer;

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        leftCog.position = new Vector3(-circle.radius, 0f, 0f);
        rightCog.position = new Vector3(circle.radius, 0f, 0f);

        lineRenderer.SetPosition(0, leftCog.position);
        lineRenderer.SetPosition(1, rightCog.position);
        lineRenderer.enabled = false;
    }

    private void SetupBeam(Vector3 position, bool isLeft)
    {
        lineRenderer.enabled = true;

        if (isLeft)
        {
            Vector3 leftPos = PlaceOnCircle(position);
            leftCog.position = leftPos;
            lineRenderer.SetPosition(0, leftPos);
        }
        else
        {
            Vector3 rightPos = PlaceOnCircle(position);
            rightCog.position = rightPos;
            lineRenderer.SetPosition(1, rightPos);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetupBeam(Input.mousePosition, true);
        }

        if (Input.GetMouseButton(1))
        {
            SetupBeam(Input.mousePosition, false);
        }

    }


    private Vector3 PlaceOnCircle(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        Vector3 pos = ray.GetPoint(0f);

        pos = transform.InverseTransformPoint(pos);
        float angle = Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
        pos.x = circle.radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = circle.radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        pos.z = 0f;

        return pos;
    }

}
