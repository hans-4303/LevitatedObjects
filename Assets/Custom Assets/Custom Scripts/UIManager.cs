using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager GetInstance()
    {
        if (UIManager.instance == null)
        {
            UIManager.instance = FindObjectOfType<UIManager>();

            if (UIManager.instance == null)
            {
                GameObject container = new("UIManager");
                UIManager.instance = container.AddComponent<UIManager>();
            }
        }
        return UIManager.instance;
    }

    public Camera currentCamara;

    private bool isAxisYRotate = false;

    public bool IsAxisYRotate
    {
        get { return isAxisYRotate; }
        set { isAxisYRotate = value; }
    }

    public void OnAxisYButtonClick()
    {
        if(IsAxisYRotate == false)
        {
            currentCamara.transform.Rotate(0, 180, 0);
            IsAxisYRotate = true;
        }
        else
        {
            currentCamara.transform.Rotate(0, -180, 0);
            IsAxisYRotate = false;
        }
    }

    private bool isAxisXRotate = false;

    public bool IsAxisXRotate
    {
        get { return isAxisXRotate; }
        set { isAxisXRotate = value; }
    }

    public void OnAxisXButtonClick()
    {
        if(IsAxisXRotate == false)
        {
            currentCamara.transform.Rotate(90, 0, 0);
            IsAxisXRotate = true;
            Debug.Log("false 쪽 작동");
        }
        else
        {
            currentCamara.transform.Rotate(-90, 0, 0);
            IsAxisXRotate = false;
            Debug.Log("true 쪽 작동");
        }
    }
}
