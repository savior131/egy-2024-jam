
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

enum Speaker
{
    zahi,saqer, albert, horus
}

[System.Serializable]
struct Character
{
    public string name;
    public Sprite characterImage; 
}

[System.Serializable]
struct dialogueEntery
{
    public string text;
    public Speaker speaker;
}

public class DialogueSystem : MonoBehaviour
{
    [Header("dialogue")]
    [SerializeField] private Character[] characters;
    [SerializeField] private dialogueEntery[] entries;
    [SerializeField] private float timeBetweenCharacters;
    [SerializeField] private float timeBetweenEntries;
    [Header("dialogue canvas")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] Image speakerImage;
    [SerializeField] TextMeshProUGUI speakerName;
    [SerializeField] TextMeshProUGUI dialogueText;
    private void OnEnable()
    {
       showDialogue();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    int index = 0;
    IEnumerator TextDisplay()
    {
       
        dialogueText.text = string.Empty;
        if (index < entries.Length)
        {
            int speakerIndex = (int)entries[index].speaker;
              speakerName.text = characters[speakerIndex].name;
            if (characters[speakerIndex].characterImage != null)
            {
                speakerImage.sprite = characters[speakerIndex].characterImage;
            }
            else
            {
                speakerImage.gameObject.SetActive(false);
            }
            for (int textIDX = 0; textIDX < entries[index].text.Length; textIDX++)
            {
                dialogueText.text += entries[index].text[textIDX];
                yield return new WaitForSeconds(timeBetweenCharacters);
            }

            index++;
            Invoke("showDialogue", timeBetweenEntries);
        }
        else
        {
            StopAllCoroutines();
        }
       
    }

    //public void hideDialogue()
    //{
    //    dialoguePanel.SetActive(false);        
    //}
    public void showDialogue()
    {
       
        dialoguePanel.SetActive(true);
        StartCoroutine(TextDisplay());
        
    }

}
