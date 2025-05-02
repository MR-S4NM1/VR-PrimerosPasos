using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Pine"))
        {
            BowlingManager.instance.ResetAllBowlingObjPositions();
        }
    }
}
