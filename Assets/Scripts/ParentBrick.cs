using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentBrick : MonoBehaviour
{

    public void CheckForDestroy()
    {
        if(transform.childCount == 0)
        {
            Brick.breakableCount--;
            Brick.bricksDestroyed++;
            if (Brick.breakableCount <= 0)
            {
                GameObject UIController = FindObjectOfType<BlockBreakerUIController>().gameObject;
                UIController.GetComponent<BlockBreakerUIController>().GameComplete(Brick.bricksDestroyed);
            }
        }

    }
}
