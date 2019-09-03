using UnityEngine;

public class vLine : MonoBehaviour
{
    public float lineWidth = 0.1f;
    public string sortingLayer;

    //public vLine line;
    public Transform centerCog;
    public Transform sliderCog;
    public Vector3 slPos;
    public Vector3 cnPos;
    public GameObject positionRef;

    private LineRenderer lineRenderer;
    private float adj_zpos;


    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.widthMultiplier = lineWidth;

        centerCog.position = new Vector3(0f, 2f, 2.8f);
        sliderCog.position = new Vector3(0f, 2f, 3f);

        lineRenderer.SetPosition(0, centerCog.position);
        lineRenderer.SetPosition(1, sliderCog.position);
        lineRenderer.enabled = false;
    }

    private void SetupBeam(Vector3 position, bool isLeft)
    {
        lineRenderer.enabled = true;

        if (isLeft)
        {
            Vector3 sliderPos = PlaceOnRefLine(position);
            sliderCog.position = sliderPos;
            lineRenderer.SetPosition(0, sliderPos);
            slPos = sliderPos;

        }
        //else
        //{
        //    Vector3 centerPos = PlaceOnRefLine(position);
        //    centerCog.position = centerPos;
        //    lineRenderer.SetPosition(1, centerPos);
        //    cnPos = centerPos;
        //}
    }

    private void SetupBeamOSC(float radius)
    {
        lineRenderer.enabled = true;

        Vector3 sliderPos = PlaceOnRefLineOSC(radius);
        sliderCog.position = sliderPos;
        lineRenderer.SetPosition(0, sliderPos);
        slPos = sliderPos;
    }

    private void Update()
    {
        adj_zpos = positionRef.transform.position.z-3.2f;
        if (Globals.GlobalVar.OscSendRadiusSyncEvent == true)
        {
            
            Globals.GlobalVar.OscSendRadiusSyncEvent = false;
            SetupBeamOSC(Globals.GlobalVar.radiusSyncValue);
            Debug.Log("vLine::received radiusSyncValue: " + Globals.GlobalVar.radiusSyncValue);
        }
            
         

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                SetupBeam(touch.position, true);
            }
        }

        if (Input.GetMouseButton(0))
        {
            SetupBeam(Input.mousePosition, true);
        }

        if (Input.GetMouseButton(1))
        {
            SetupBeam(Input.mousePosition, false);
        }

    }


    private Vector3 PlaceOnRefLine(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        Vector3 pos = ray.GetPoint(0f);

        pos = transform.InverseTransformPoint(pos);
        pos.x = 0f;
        pos.y = pos.y + 1f;
        pos.z = adj_zpos+3f;


        return pos;
    }

    private Vector3 PlaceOnRefLineOSC(float radius)
    {
        Vector3 pos;

        pos.x = 0f;
        pos.y = radius + 2f;
        pos.z = adj_zpos+3f;

        return pos;
    }

}
