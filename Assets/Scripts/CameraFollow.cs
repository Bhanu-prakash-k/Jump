using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Transform boxOne;
    public Transform boxTwo;
    public bool isPlayerDead = false;
    public float smoothSpeed = 0.125f;
    private Vector3 boxOneOffset;
    private Vector3 boxTwoOffset;

	private void Awake()
	{
        if (instance == null)
            instance = this;
	}
	// Start is called before the first frame update
	void Start()
    {
        boxOneOffset = transform.position - boxOne.position;
        boxTwoOffset = transform.position - boxTwo.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isPlayerDead)
        {
            if (BoxOneCollision.instance.cameraFollow)
            {
                Vector3 desiredPosition = boxOne.position + boxOneOffset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }
            else
            {
                Vector3 desiredPosition = boxTwo.position + boxTwoOffset;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }
        }
    }
}
