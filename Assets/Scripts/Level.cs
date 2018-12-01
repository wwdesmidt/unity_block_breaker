using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    private void Update()
    {
        if(breakableBlocks==0)
        {
            FindObjectOfType<SceneLoader>().loadNextScene();
        }
    }

    public void addBreakableBlock()
    {
        breakableBlocks++;
    }

    public void removeBreakableBlock()
    {
        breakableBlocks--;
    }
}
