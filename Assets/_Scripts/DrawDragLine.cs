using UnityEngine;
 
public class DrawDragLine : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _LineRenderer;
    private bool RenderLine = false;

    private void Awake()
    {
        if (_LineRenderer == null) _LineRenderer = GetComponent<LineRenderer>();
        _LineRenderer.enabled = false;
    }
 
    void Update()
    {
        if (!RenderLine) return;
        
        _LineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.localPosition);
    }

    public void StartLineDraw() 
    {
        RenderLine = true;
        _LineRenderer.enabled = true;
        _LineRenderer.positionCount = 2;
        _LineRenderer.SetPosition(0, Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.localPosition);
        _LineRenderer.useWorldSpace = true;
    }

    public void EndLineDraw() {
        RenderLine = false;
        _LineRenderer.enabled = false;
    }
}