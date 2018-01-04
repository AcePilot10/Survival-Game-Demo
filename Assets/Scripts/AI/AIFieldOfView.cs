using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFieldOfView : MonoBehaviour {

    public float maxAngle;

    public bool IsInRange(GameObject target)
    {
        return Vector3.Angle(target.transform.position, transform.position) <= maxAngle;
    }
}
