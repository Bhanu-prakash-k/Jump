using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    public GameObject boxOneInstruction;
    public GameObject boxTwoInstruction;

    // Start is called before the first frame update
    void Start()
    {
        boxOneInstruction.SetActive(true);
        boxTwoInstruction.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
		if (BoxOneCollision.instance.instructionCanvas)
		{
            boxOneInstruction.SetActive(false);
            boxTwoInstruction.SetActive(true);
            Invoke("BoxTwoInstruction", 3f);
		}
    }
    public void BoxTwoInstruction()
	{
        BoxOneCollision.instance.instructionCanvas = false;
        boxTwoInstruction.SetActive(false);
	}
}
