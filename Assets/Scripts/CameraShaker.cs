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
    private void Awake()
    {
        Instance = this;
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
}
