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

    private LineRenderer lineRenderer;

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.widthMultiplier = lineWidth;

        centerCog.position = new Vector3(0f, 0f, 0f);
        sliderCog.position = new Vector3(0f, 0f, 0f);

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

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
           
            if (touch.position.x < 1750) //limit the touch sense
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log(touch.position);
                    SetupBeam(touch.position, true);
                    Globals.GlobalVar.newRadiusInformed = true;
                }
            } else
            {
                if (touch.phase == TouchPhase.Ended && Globals.GlobalVar.newRadiusInformed == true)
                {
                    if (Globals.GlobalVar.OscReportButtonValue == 2)
                    {
                        Globals.GlobalVar.OscSendEndTrialValue = true;
                        Globals.GlobalVar.OscSendEndTrialEvent = true;
                        Globals.GlobalVar.newRadiusInformed = false;
                    } else { Globals.GlobalVar.newRadiusInformed = false;}

                }

            }

        }

        if (Globals.GlobalVar.ResetRadiusEvent)
        {
            if (Globals.GlobalVar.ResetRadius% 2 == 0) //is even trial
            {
                Vector3 reset_pos = new Vector3(0f,680f,0f);
                SetupBeam(reset_pos, true);

            } else // is odd trial
            {
                Vector3 reset_pos = new Vector3(0f, 150f, 0f);
                SetupBeam(reset_pos, true);
            }
            Globals.GlobalVar.ResetRadiusEvent = false;
        }

        

    }


    private Vector3 PlaceOnRefLine(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        Vector3 pos = ray.GetPoint(0f);

        pos = transform.InverseTransformPoint(pos);
        pos.x = 0f;
        pos.z = 0f;


        return pos;
    }


}
