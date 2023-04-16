using System.Collections.Generic;
using UnityEngine;

public class EnvLighting : MonoBehaviour
{
    [SerializeField]
    List<Light> lights;

    public void SetLight(bool isEnabled)
    {
        lights.ForEach(light => light.enabled = isEnabled);
    }
}
