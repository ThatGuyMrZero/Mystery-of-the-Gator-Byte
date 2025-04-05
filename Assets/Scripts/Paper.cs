using UnityEngine;
using TMPro;

public class Paper : MonoBehaviour
{
    [Header("Paper Data")]
    public int grade;
    public TextMeshPro gradeText;
    //[Header("UI")]
    //public TextMeshProUGUI gradeText;

    void Start()
    {
        UpdateGradeVisual();
    }

    public void UpdateGradeVisual()
    {
        if (gradeText != null)
        {
            gradeText.text = grade.ToString();
            gradeText.ForceMeshUpdate();
            Debug.Log($"{gameObject.name} updated grade text to: {gradeText.text}");
        }
        else
        {
            Debug.LogWarning("gradeText is not assigned in " + gameObject.name);
        }
    }

}
