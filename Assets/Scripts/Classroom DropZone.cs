using UnityEngine;

public class ClassroomDropZone : MonoBehaviour
{

    private int paperCount = 0;


    [SerializeField] private float zOffsetPerPaper = .1f;


    public void PlacePaperOnTop(GameObject paper)
    {
        paperCount++;


        Vector3 pos = paper.transform.position;

        paper.transform.position = new Vector3(pos.x, pos.y, pos.z - zOffsetPerPaper * paperCount);


    }
}
