using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove;
	public bool raycastOn;
	public bool firstBox;
    private Vector3 currentPosition;
    private Quaternion currentRotation;

    public float distance;
    public float jumpHeight;
    public float duration;

	private Vector3 fp;   
	private Vector3 lp;   
	private float dragDistanceHeight;  
	private float dragDistanceWidth;

	public Transform[] blocksTransform;
	private void Awake()
	{
		
		//PlayerPrefs.GetInt("LevelLoad", 0);
		//SceneManager.LoadScene(PlayerPrefs.GetInt("LevelLoad",0));
	}
	private void Start()
	{
		dragDistanceHeight = Screen.height * 10 / 100;
		dragDistanceWidth = Screen.width * 10 / 100;
		canMove = true;
		firstBox = true;
        currentPosition = transform.position;
        currentRotation = transform.rotation;
	}
	private void Update()
	{
		if (canMove)
		{
			
			//Keyboard Movement
			if (Input.GetKeyDown(KeyCode.W))
			{
				StartCoroutine(Movement(MoveDirection.UP, duration));
			}
			else if (Input.GetKeyDown(KeyCode.D))
			{
				StartCoroutine(Movement(MoveDirection.RIGHT, duration));
			}
			else if (Input.GetKeyDown(KeyCode.A))
			{
				StartCoroutine(Movement(MoveDirection.LEFT, duration));
			}
			else if (Input.GetKeyDown(KeyCode.S))
			{
				StartCoroutine(Movement(MoveDirection.DOWN, duration));
			}
			
		//	//mouse movement
		//	if (Input.GetMouseButtonDown(0)) 
		//	{
		//		fp = Input.mousePosition;
		//		lp = Input.mousePosition;
		//	}
		//	else if (Input.GetMouseButton(0)) 
		//	{
		//		lp = Input.mousePosition;
		//	}
		//	else if (Input.GetMouseButtonUp(0)) 
		//	{
		//		lp = Input.mousePosition;  

				
		//		if (Mathf.Abs(lp.x - fp.x) > dragDistanceWidth || Mathf.Abs(lp.y - fp.y) > dragDistanceHeight)
		//		{
				 
		//			if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
		//			{   
		//				if ((lp.x > fp.x))  
		//				{   
		//					Debug.Log("Right Swipe");
		//					StartCoroutine(Movement(MoveDirection.RIGHT, duration));
		//				}
		//				else
		//				{   
		//					Debug.Log("Left Swipe");
		//					StartCoroutine(Movement(MoveDirection.LEFT, duration));
		//				}
		//			}
		//			else
		//			{   
		//				if (lp.y > fp.y)  
		//				{   
		//					Debug.Log("Up Swipe");
		//					StartCoroutine(Movement(MoveDirection.UP, duration));
		//				}
		//				else
		//				{  
		//					Debug.Log("Down Swipe");
		//					StartCoroutine(Movement(MoveDirection.DOWN, duration));
		//				}
		//			}
		//		}
		//		else
		//		{  
		//			Debug.Log("Tap");
		//		}
		//	}
		}
		if (raycastOn)
		{
			Vector3 origin = transform.position;
			Vector3 direction;

			//Debug.DrawRay(origin, newDirection * 10f, Color.red);

			if (firstBox)
			{
				direction = -transform.up;
			}
			else
			{
				direction = transform.up;
			}
			Debug.DrawRay(origin, direction * 10f, Color.red);
			Ray ray = new Ray(origin, direction);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit, 10f))
			{
				if (raycastHit.collider.isTrigger)
				{
					Debug.Log("Good");
				}
				else
				{
					canMove = false;
					CameraFollow.instance.isPlayerDead = true;
					gameObject.GetComponent<Rigidbody>().useGravity = true;
					StartCoroutine(LoadScene());
				}
			}
			else
			{
				Debug.Log("None");
				canMove = false;
				CameraFollow.instance.isPlayerDead = true;
				gameObject.GetComponent<Rigidbody>().useGravity = true;
				StartCoroutine(LoadScene());
			}
		}
	}
	IEnumerator Movement(MoveDirection moveDirection, float duration)
	{
		canMove = false;
		raycastOn = false;
		float progress = 0;

		var endRotation = Quaternion.Euler(0, 0, 0);
		var targetPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z);

		if(moveDirection == MoveDirection.LEFT)
		{
			endRotation = Quaternion.Euler(0, 0, -180);
			targetPosition = new Vector3(currentPosition.x - distance, currentPosition.y, currentPosition.z);
		}
		else if (moveDirection == MoveDirection.RIGHT)
		{
			endRotation = Quaternion.Euler(0, 0, 180);
			targetPosition = new Vector3(currentPosition.x + distance, currentPosition.y, currentPosition.z);
		}
		else if (moveDirection == MoveDirection.UP)
		{
			endRotation = Quaternion.Euler(-180, 0, 0);
			targetPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + distance);
		}
		else if (moveDirection == MoveDirection.DOWN)
		{
			endRotation = Quaternion.Euler(180, 0, 0);
			targetPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - distance);
		}
		var endPosition = new Vector3(targetPosition.x, currentPosition.y, targetPosition.z);

		while (progress < duration)
		{
			progress += Time.deltaTime;
			var percent = Mathf.Clamp01(progress / duration);
			float height = jumpHeight * Mathf.Sin(Mathf.PI * percent);

			transform.position = Vector3.Lerp(currentPosition, endPosition, percent) + new Vector3(0, height, 0);
			transform.rotation = Quaternion.Lerp(currentRotation, endRotation, percent);
			yield return null;
		}
		currentPosition = new Vector3(transform.position.x, 0.0f, transform.position.z);
		canMove = true;
		raycastOn = true;
	}
	public enum MoveDirection
	{
		RIGHT,
		LEFT,
		UP,
		DOWN
	}
	public void MoveUpperRight()
	{
		if (canMove)
		{
			StartCoroutine(Movement(MoveDirection.UP, duration));
		}
	}
	public void MoveUpperLeft()
	{
		if (canMove)
		{
			StartCoroutine(Movement(MoveDirection.LEFT, duration));
		}
	}
	public void MoveDownLeft()
	{
		if (canMove)
		{
			StartCoroutine(Movement(MoveDirection.DOWN, duration));
		}
	}
	public void MoveDownRight()
	{
		if (canMove)
		{
			StartCoroutine(Movement(MoveDirection.RIGHT, duration));
		}
	}
	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
