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
                Object.DontDestroyOnLoad(container);
            }
        }
        return UIManager.instance;
    }

    public Camera currentCamera;

    private bool isRotating = false;

    public void HandleClickRotate ()
    {
        if (!isRotating)
        {
            this.StartCoroutine(RotateOverTime(180f, 1f));
        }
    }

    private IEnumerator RotateOverTime(float angle, float duration)
    {
        isRotating = true;
        Quaternion startRotation = currentCamera.transform.rotation;
        Quaternion endRotation = currentCamera.transform.rotation * Quaternion.Euler(0, angle, 0);
        float time = 0.0f;

        while (time < duration)
        {
            currentCamera.transform.rotation = Quaternion.Slerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        currentCamera.transform.rotation = endRotation;
        isRotating = false;
    }
}
