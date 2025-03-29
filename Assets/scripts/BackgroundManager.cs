using UnityEngine;
public class BackgroundManager : MonoBehaviour
{
    public GameObject dormroom1;
    public GameObject plain_bg;
    public GameObject PC_2;
    public GameObject pc_wallpaper;

    void Start()
    {
        // Example of setting the initial background for the first level
        SetBackground("Level1");
    }

    void SetBackground(string level)
    {
        // Hide all backgrounds
        dormroom1.SetActive(false);
        plain_bg.SetActive(false);
        pc_wallpaper.SetActive(false);

        // Show the background for the current level
        if (level == "Level1")
        {
            dormroom1.SetActive(true);
        }
        else if (level == "Level2")
        {
            plain_bg.SetActive(true);
        }
        else if (level == "Level3")
        {
            plain_bg.SetActive(true);
            PC_2.SetActive(true);
            pc_wallpaper.SetActive(true);
        }
    }
}
