using UnityEngine;


public class EventTest : MonoBehaviour
{
    public delegate void OnClicked();
    public event OnClicked onLeftClicked;
    public event OnClicked onRightClicked;

    private void Start()
    {
        onLeftClicked += PrintLeft;
        onRightClicked += PrintRight;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onLeftClicked();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            onRightClicked();
        }
    }
    public void PrintRight()
    {
        Debug.Log("Right");
    }
    public void PrintLeft()
    {
        Debug.Log("Left");
    }
}
