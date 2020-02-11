using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrain_gen : MonoBehaviour
{
    public bool resetTerrain = true;

    private bool initRun = true;
    private int counter = 0;
    private float alphaRandom;
    private float finalOut;
    private float baseLine = 0;
    
    void Start()
    {
        GenTerrain();
        
    }
    void Update()
    {
        if(!resetTerrain)
            GenTerrain();
    }

    private void GenTerrain()
    {
        Terrain terrObj = Terrain.activeTerrain;
        TerrainData terrObjData = terrObj.terrainData;
        int terrW = terrObjData.heightmapWidth;
        int terrH = terrObjData.heightmapHeight;
        int terrColorW = terrObjData.alphamapHeight;
        int terrColorH = terrObjData.alphamapWidth;
        float[,] heights = terrObjData.GetHeights(0, 0, terrW, terrH);
        float[,] newHeights = heights;
        float[,,] ColorMap = new float[terrColorW, terrColorH, terrObjData.alphamapLayers];
        /*
        for (int y = 0; y < terrColorH; ++y)
        {
            for (int x = 0; x < terrColorW; ++x)
            {
                ColorMap[x, y, (int)Random.Range(0,terrObjData.alphamapLayers)] = (float)Random.Range(0, 5);
            }
        }
        terrObjData.SetAlphamaps(0, 0, ColorMap);
        */
        for (int outr = 0; outr != terrW; ++outr)
        {
            for (int inr = 0; inr != terrW; ++inr)
            {
                try
                {
                    if (resetTerrain)
                        newHeights[inr, outr] = 0;
                    else
                        newHeights[inr, outr] = InternalMapGen();
                }
                catch (System.Exception ex)
                {
                    Debug.Log("Uh oh \ninr:" + inr + " outr: " + outr + " exception: " + ex);
                    goto breakout;
                }
            }
        }
        breakout:
        //Sets heights to new generation
        terrObjData.SetHeights(0, 0, newHeights);
    }

    private float InternalMapGen()
    {
        if (initRun)
        {
            Debug.Log("Init run!");
            alphaRandom = Random.Range(baseLine, 0.5f);
            initRun = !initRun;
        }
        else
        {
            counter += 1;
            finalOut = Random.Range(baseLine, 0.01f);
            return finalOut;
        }
        return 0f;
    }
}
