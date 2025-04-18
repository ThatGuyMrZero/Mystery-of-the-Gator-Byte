using UnityEngine;
using UnityEngine.Rendering.UI;

public class DialogueScript : MonoBehaviour
{
    private Transform[] textSprites;
    private int currentIndex = 0;
    public GameController gameController;
    private bool dialogueComplete = false;
    public string itemNameToAdd; // << NEW FIELD


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textSprites = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            textSprites[i] = transform.GetChild(i);
            textSprites[i].gameObject.SetActive(false);
        }

        // Make first text box active from the start
        textSprites[0].gameObject.SetActive(true);
        // Make text box border always active
        textSprites[textSprites.Length - 1].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !dialogueComplete)
        {
            Debug.Log("Mouse button pressed!");
            CycleText();
        }
    }

    void CycleText()
    {
        if (currentIndex >= 0 && gameObject.activeSelf)
            textSprites[currentIndex].gameObject.SetActive(false);

        currentIndex++;

        if (currentIndex < textSprites.Length - 1)  // Ignore text box border
        {
            textSprites[currentIndex].gameObject.SetActive(true);
        }
        else
        {
            currentIndex = -1;
            textSprites[textSprites.Length - 1].gameObject.SetActive(false); // Hide the text box border
            dialogueComplete = true;

            // ✅ NOW add the inventory item once dialogue is finished
            if (InventoryManager.Instance != null && !string.IsNullOrEmpty(itemNameToAdd))
            {
                InventoryManager.Instance.AddItem(itemNameToAdd);
                Debug.Log("✅ Added item to inventory: " + itemNameToAdd);
            }
        }
    }

}
