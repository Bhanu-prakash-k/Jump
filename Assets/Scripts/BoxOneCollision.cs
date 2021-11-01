using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxOneCollision : MonoBehaviour
{
    public static BoxOneCollision instance;
    public GameObject boxTwo;
	//public GameObject boxOneSwipe;
	public bool instructionCanvas = false;

	public bool cameraFollow = true;
	//public GameObject outerBox;
	private void Awake()
	{
		if (instance == null)
			instance = this;
	}
	// Start is called before the first frame update
	void Start()
    {
		cameraFollow = true;
		//boxOneSwipe.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	//private void OnCollisionEnter(Collision other)
	//{
	//	if (other.gameObject.CompareTag("LastBox"))
	//	{
	//		gameObject.SetActive(false);
	//		instructionCanvas = true;
	//		//gameObject.GetComponent<PlayerMovement>().enabled = false;
	//		boxTwo.SetActive(true);
	//		cameraFollow = false;
	//	}
	//	if (other.gameObject.CompareTag("GreenBox"))
	//	{
	//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	//	}
	//	if (other.gameObject.CompareTag("Water"))
	//	{
	//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	//	}
	//}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("LastBox"))
		{
			gameObject.SetActive(false);
			//boxOneSwipe.SetActive(false);
			instructionCanvas = true;
			gameObject.GetComponent<PlayerMovement>().enabled = false;
			boxTwo.SetActive(true);
			cameraFollow = false;
		}
		if (other.gameObject.CompareTag("GreenBox"))
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		if (other.gameObject.CompareTag("Water"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		if (other.gameObject.CompareTag("OuterBox"))
		{
			Debug.Log("Over");
			gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.GetComponent<PlayerMovement>().canMove = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		if (other.gameObject.CompareTag("TwoHeightBox"))
		{
			gameObject.GetComponent<PlayerMovement>().distance = 2f;
			gameObject.GetComponent<PlayerMovement>().jumpHeight = 1.5f;
		}
		if (other.gameObject.CompareTag("OneHeightBox"))
		{
			gameObject.GetComponent<PlayerMovement>().distance = 1f;
			gameObject.GetComponent<PlayerMovement>().jumpHeight = 1f;
		}
		if (other.gameObject.CompareTag("BlackBox"))
		{
			//Debug.Log("Falling");
			StartCoroutine(BlackBoxFalling());
			IEnumerator BlackBoxFalling()
			{
				yield return new WaitForSeconds(1f);
				other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				//gameObject.GetComponent<PlayerMovement>().canMove = false;
				yield return new WaitForSeconds(0.25f);
				other.gameObject.GetComponent<BoxCollider>().enabled = false;
				Destroy(other.gameObject, 1f);
			}
		}
	}
	//private void OnCollisionExit(Collision other)
	//{
	//	if (other.gameObject.CompareTag("NormalBox"))
	//	{
	//		other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
	//		//other.gameObject.SetActive(false);
	//		Destroy(other.gameObject, 1f);
	//	}
	//}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("NormalBox"))
		{
			other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			//other.gameObject.SetActive(false);
			//GameObject box = (GameObject)Instantiate(outerBox, other.transform.position, other.transform.rotation);
			//box.SetActive(true);
			Destroy(other.gameObject, 1f);
		}
		if (other.gameObject.CompareTag("FirstBox"))
		{
			gameObject.GetComponent<PlayerMovement>().firstBox = false;
		}
	}
}
