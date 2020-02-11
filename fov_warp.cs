using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fov_warp : MonoBehaviour
{
    public bool disableScript = false;
    public bool randomFov = false;
    [Range(0f, 179.0f)]
    public float minRandomFov = 80f;
    [Range(0.1f, 180.0f)]
    public float maxRandomFov = 90f;

    private float fovar;
    private bool fovSwitch;
    void Start()
    {
        fovSwitch = true;
        fovar = 90f;
    }
    void Update()
    {
        if (!disableScript)
        {
            if (!randomFov)
            {
                StartCoroutine("AnimateFov");
                Camera.main.fieldOfView = fovar;
            }
            else if (randomFov)
            {
                Camera.main.fieldOfView = Random.Range(minRandomFov, maxRandomFov);
            }
        }
    }

    IEnumerator AnimateFov()
    {
        if (fovar >= 175 || fovar <= 10)
            fovSwitch = !fovSwitch;
        if (fovSwitch)
            fovar++;
        else
            fovar--;
        yield return null;
    }
}
