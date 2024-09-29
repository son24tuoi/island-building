using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Construction
{
    public class BrickMovement : MonoBehaviour
    {
        [SerializeField] private BrickTrajectory brickTrajectory;
        [SerializeField][Range(0f, 1f)] private float timeStep;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (brickTrajectory == null)
                return;

            transform.position = brickTrajectory.GetPos(Mathf.Lerp(0f, brickTrajectory.TotalTime, timeStep));
        }
#endif
    }
}
