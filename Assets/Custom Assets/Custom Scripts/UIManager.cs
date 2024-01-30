using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button axisYButton;
    public Button axisXButton;

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
                Object.DontDestroyOnLoad(container);
            }
        }
        return UIManager.instance;
    }

    private void Awake ()
    {
        CameraManager.GetInstance().OnRotationStatusChanged += UpdateButtonStates;
    }

    private void OnDestroy ()
    {
        if (CameraManager.GetInstance() != null)
        {
            CameraManager.GetInstance().OnRotationStatusChanged -= UpdateButtonStates;
        }
    }

    private void UpdateButtonStates ()
    {
        bool isRotating = CameraManager.GetInstance().IsRotating;
        axisYButton.enabled = !isRotating;
        axisXButton.enabled = !isRotating;
    }
}
