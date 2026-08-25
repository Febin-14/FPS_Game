using UnityEngine;

public class TestButton : MonoBehaviour
{
    public void Onclick()
    {
        NoteManager.Instance.CloseNote();
    }
}
