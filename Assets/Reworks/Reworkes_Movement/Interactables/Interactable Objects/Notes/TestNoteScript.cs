using UnityEngine;

public class TestNoteScript : MonoBehaviour, IInteractable
{
    public string GetInteractionPrompt()
    {
        return "Press E to read the note.";
    }

    public void Interact()
    {
       
    }
}
