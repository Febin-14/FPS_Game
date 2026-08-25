using UnityEngine;

public class TestNoteScript : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSO TestNote;
    [SerializeField] private string interactionPrompt;

    

    public string GetInteractionPrompt()
    {
        return interactionPrompt;
    }

    public void Interact()
    {
        NoteManager.Instance.OpenNote(TestNote);
    }
}
