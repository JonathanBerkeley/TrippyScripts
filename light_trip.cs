using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_trip : MonoBehaviour
{
    [Range(0.5f, 35.0f)]
    public float lightIntensity = 10f;
    [Range(0.5f, 500.0f)]
    public float lightRange = 10f;
    public bool randomRange = false; //Enabling this disables lightRange
    public bool randomMode = true; //Enabling this disables linearIncrease
    [Range(0.0001f, 0.5f)]
    public float linearIncrease = 0.3f;

    private Light lightObj;
    private float incX;
    private float incY;
    private float incZ;
    private int randomPath;
    private void Start()
    {
        incX = Random.Range(0f, 1f);
        incY = Random.Range(0f, 1f);
        incZ = Random.Range(0f, 1f);
    }

    void Update()
    {
        //Inherits the editors light object
        lightObj = GetComponent<Light>();
        if (randomMode)
        {
            Color rColor = new Vector4(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 0.4f));
            lightObj.color = rColor;
        }
        else
        {
            //todo: make this increase linearly
            lightObj.color = new Vector4(incX, incY, incZ);
            randomPath = Random.Range(0, 3);
            if (randomPath == 0)
            {
                if (incX <= 8f)
                    incX += linearIncrease;
                else
                    incX = 0f;
            }

            else if (randomPath == 1)
            {
                if (incY <= 8f)
                    incY += linearIncrease;
                else
                    incY = 0f;
            }

            else if (randomPath == 2)
            {
                if (incZ <= 8f)
                    incZ += linearIncrease;
                else
                    incZ = 0f;
            }
        }
        lightObj.intensity = lightIntensity;
        if (!randomRange)
            lightObj.range = lightRange;
        else
            lightObj.range = Random.Range(0f,200f);
    }

}
