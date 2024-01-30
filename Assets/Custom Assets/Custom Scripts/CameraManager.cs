using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

public class CameraManager : MonoBehaviour
{
    private static bool isDestroyed = false;
    public static bool IsDestroyed
    {
        get { return isDestroyed; }
        set { isDestroyed = value; }
    }
    private void OnDestroy ()
    {
        IsDestroyed = true;
    }

    private static CameraManager instance;
    public static CameraManager GetInstance()
    {
        if(CameraManager.instance == null && IsDestroyed != true)
        {
            CameraManager.instance = FindObjectOfType<CameraManager>(); ;
            if(CameraManager.instance == null)
            {
                GameObject container = new("Main Camera");
                CameraManager.instance = container.AddComponent<CameraManager>();
                Object.DontDestroyOnLoad(container);
            }
        }
        return CameraManager.instance;
    }

    public Action OnRotationStatusChanged;
    private bool isRotating = false;
    public bool IsRotating
    {
        get { return isRotating; }
        private set { isRotating = value; }
    }
    private void UpdateRotationStatus(bool isRotating)
    {
        this.IsRotating = isRotating;
        OnRotationStatusChanged?.Invoke();
    }

    private bool isAlreadyYRotated = false;
    public void HandleClickAxisYRotate ()
    {
        if (!IsRotating)
        {
            Vector3 rotationAxis = Vector3.up;
            float angle = isAlreadyYRotated ? -180f : 180f;
            StartCoroutine(RotateOverTime(rotationAxis, angle, 1f));
            isAlreadyYRotated = !isAlreadyYRotated;
        }
    }

    private bool isAlreadyXRotated = false;
    public void HandleClickAxisXRotate ()
    {
        if (!IsRotating)
        {
            Vector3 rotationAxis = Vector3.right;
            float angle = isAlreadyXRotated ? -90f : 90f;
            StartCoroutine(RotateOverTime(rotationAxis, angle, 1f));
            isAlreadyXRotated = !isAlreadyXRotated;
        }
    }

    private IEnumerator RotateOverTime (Vector3 rotationAxis, float angle, float duration)
    {
        UpdateRotationStatus(true);

        Quaternion startRotation = this.transform.rotation;
        Quaternion endRotation = this.transform.rotation * Quaternion.Euler(rotationAxis * angle);
        float time = 0.0f;

        while (time < duration)
        {
            this.transform.rotation = Quaternion.Slerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        this.transform.rotation = endRotation;
        UpdateRotationStatus(false);
    }
}
