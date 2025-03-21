using UnityEngine;
using TMPro;

public class Paper : MonoBehaviour
{
    [Header("Paper Data")]
    public int grade;

    [Header("UI")]
    public TextMeshProUGUI gradeText;

    void Start()
    {
        UpdateGradeVisual();
    }


    public void UpdateGradeVisual()
    {
        if (gradeText != null)
        {
            gradeText.text = grade.ToString();
        }
    }
}
