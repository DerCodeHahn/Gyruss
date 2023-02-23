using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShaker : MonoBehaviour
{
    public enum ShakeIntensity
    {
        Light,
        Medium,
        Intense
    }
    
    public static CameraShaker Instance;
    Camera camera;
    float defaultFov;
    [SerializeField] float duration = 1;
    [SerializeField] AnimationCurve fieldOfViewChange;

    private void Awake()
    {
        Instance = this;
        camera = GetComponent<Camera>();
        defaultFov = camera.fieldOfView;
    }

    public void Shake(ShakeIntensity shakeIntensity)
    {
        switch (shakeIntensity)
        {
            case ShakeIntensity.Light:
                transform.DOShakePosition(1, 0.1f);
                break;
            case ShakeIntensity.Medium:
                transform.DOShakePosition(1, 0.2f);
                break;
            case ShakeIntensity.Intense:
                transform.DOShakePosition(1, 1);
                break;
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        // Dont generate errors when changing scenes
        transform.DOKill();
    }

    public void ChangeLevel()
    {
        DOVirtual.Float(0, 1, duration, (x) =>
        {
            camera.fieldOfView = fieldOfViewChange.Evaluate(x);
        });

    }
}
