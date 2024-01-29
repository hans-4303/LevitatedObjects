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

    public Camera currentCamera;

    private bool isAxisYRotate = false;

    public bool IsAxisYRotate
    {
        get { return isAxisYRotate; }
        private set { isAxisYRotate = value; }
    }

    public void HandleAxisYButtonClick()
    {
        if(IsAxisYRotate == false)
        {
            Quaternion newRotation = currentCamera.transform.rotation * Quaternion.Euler(0, 180, 0);
            currentCamera.transform.rotation = newRotation;
            IsAxisYRotate = true;
        }
        else
        {
            Quaternion newRotation = currentCamera.transform.rotation * Quaternion.Euler(0, -180, 0);
            currentCamera.transform.rotation = newRotation;
            IsAxisYRotate = false;
        }
    }

    private bool isAxisXRotate = false;

    public bool IsAxisXRotate
    {
        get { return isAxisXRotate; }
        private set { isAxisXRotate = value; }
    }

    public void HandleAxisXButtonClick()
    {
        if(IsAxisXRotate == false)
        {
            Quaternion newRotation = currentCamera.transform.rotation * Quaternion.Euler(90, 0, 0);
            currentCamera.transform.rotation = newRotation;
            IsAxisXRotate = true;
        }
        else
        {
            Quaternion newRotation = currentCamera.transform.rotation * Quaternion.Euler(-90, 0, 0);
            currentCamera.transform.rotation = newRotation;
            IsAxisXRotate = false;
        }
    }
}
