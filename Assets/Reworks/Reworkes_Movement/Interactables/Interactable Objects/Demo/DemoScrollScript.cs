using UnityEngine;

public class DemoScrollScript : MonoBehaviour, IInteractable
{
    [SerializeField] private string demoScrollInteractiionPrompt;
    [SerializeField] private ItemSO demoScrollItemData;
    public string GetInteractionPrompt()
    {
        return demoScrollInteractiionPrompt;
    }

    public void Interact()
    {
        NoteManager.Instance.OpenNote(demoScrollItemData);
    }
}
