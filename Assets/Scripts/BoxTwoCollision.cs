using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxTwoCollision : MonoBehaviour
{
	//public GameObject outerBox;
	// Start is called before the first frame update
    void Start()
    {
		//PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	//private void OnCollisionEnter(Collision other)
	//{
	//	if (other.gameObject.CompareTag("LastBox"))
	//	{
	//		Debug.Log("GameOver");
	//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	//	}
	//	if (other.gameObject.CompareTag("Water"))
	//	{
	//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	//	}
	//}
	//private void OnCollisionExit(Collision other)
	//{
	//	if (other.gameObject.CompareTag("FirstBox"))
	//	{
	//		other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
	//		Destroy(other.gameObject, 1f);
	//	}
	//	if (other.gameObject.CompareTag("NormalBox"))
	//	{
	//		other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
	//		Destroy(other.gameObject, 1f);
	//	}
	//	if (other.gameObject.CompareTag("GreenBox"))
	//	{
	//		other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
	//		Destroy(other.gameObject, 1f);
	//	}
	//}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("LastBox"))
		{
			Debug.Log("GameOver");
			PlayerPrefs.SetInt("LevelLoad", PlayerPrefs.GetInt("LevelLoad", 1) + 1);
			SceneManager.LoadScene(PlayerPrefs.GetInt("LevelLoad", 1));
			//Debug.Log(PlayerPrefs.GetInt("LevelLoad", 0)+1);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
		if (other.gameObject.CompareTag("OneHeightBox"))
		{
			gameObject.GetComponent<PlayerMovement>().distance = 1f;
			gameObject.GetComponent<PlayerMovement>().jumpHeight = 1f;
		}
		if (other.gameObject.CompareTag("TwoHeightBox"))
		{
			gameObject.GetComponent<PlayerMovement>().distance = 2f;
			gameObject.GetComponent<PlayerMovement>().jumpHeight = 1.5f;
	    }
		if (other.gameObject.CompareTag("BlackBox"))
		{
			//Debug.Log("Falling");
			StartCoroutine(BlackBoxFalling());
			IEnumerator BlackBoxFalling()
			{
				yield return new WaitForSeconds(1f);
				other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
				yield return new WaitForSeconds(0.25f);
				other.gameObject.GetComponent<BoxCollider>().enabled = false;
				//gameObject.GetComponent<PlayerMovement>().canMove = false;
				Destroy(other.gameObject, 1f);
			}
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("FirstBox"))
		{
			other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			gameObject.GetComponent<PlayerMovement>().firstBox = false;
			//GameObject box = Instantiate(outerBox, other.transform.position, other.transform.rotation);
			//box.SetActive(true);
			Destroy(other.gameObject, 1f);
		}
		if (other.gameObject.CompareTag("NormalBox"))
		{
			other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			//GameObject box = Instantiate(outerBox, other.transform.position, other.transform.rotation);
			//box.SetActive(true);
			Destroy(other.gameObject, 1f);
		}
		if (other.gameObject.CompareTag("GreenBox"))
		{
			other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			gameObject.GetComponent<PlayerMovement>().firstBox = false;
			//GameObject box = Instantiate(outerBox, other.transform.position, other.transform.rotation);
			//box.SetActive(true);
			Destroy(other.gameObject, 1f);
		}
		if (other.gameObject.CompareTag("OneHeightBox"))
		{
			other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			//GameObject box = Instantiate(outerBox, other.transform.position, other.transform.rotation);
			//box.SetActive(true);
			Destroy(other.gameObject, 1f);
		}
	}
	//IEnumerator BlackBoxFalling()
	//{
	//	yield return new WaitForSeconds(1.5f);
	//}
}
