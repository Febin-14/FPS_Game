using UnityEngine;

public class TestCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with the cube!");
    }
    public string GetInteractionPrompt()
    {
        return "Press E to interact with the cube.";
    }
}
