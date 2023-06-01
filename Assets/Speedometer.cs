using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    private GameObject Needle;
    private Transform needleTransform;
    private const float MAX_SPEED_ANGLE = -110;
    private const float ZERO_SPEED_ANGLE = 110;
    private float speed;
    private float speedMax;

    void Awake() 
    {
        needleTransform = transform.Find("Needle");
        speed = 0f;
        speedMax = GameObject.Find("Prometheus").GetComponent<PrometeoCarController>().maxSpeed;
        // Debug.Log(speed.ToString());
        // Debug.Log(speedMax.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Abs(GameObject.Find("Prometheus").GetComponent<PrometeoCarController>().carSpeed);
        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }
    private float GetSpeedRotation()
    {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;
        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
