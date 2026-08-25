using UnityEngine;
using TMPro;
using System.Diagnostics.Contracts;
using System;
public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] private GameObject NotePanel;
    [SerializeField] private TextMeshProUGUI noteTitle;
    [SerializeField] private TextMeshProUGUI noteDescription;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenNote(ItemSO item)
    {
        if(item == null)
        {
            return;
        }
        if(item.itemType == ItemType.Note)
        {
            GameManager.Instance.SetState(GameState.ReadingNotes);
            NotePanel.SetActive(true);
            noteTitle.text = item.noteTitle;
            noteDescription.text = item.noteContent;


        }
    }
    public void CloseNote()
    {
        GameManager.Instance.SetState(GameState.Playing);
        NotePanel.SetActive(false);
        noteTitle.text = "";
        noteDescription.text = "";

    }

    
}
