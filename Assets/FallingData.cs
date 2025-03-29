using UnityEngine;

public class FallingData : MonoBehaviour
{
    public string dataType; // "string", "int", or "bool"
    public float fallSpeed = 2f;

    void Update()
    {
        // Move object downward
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy if it falls off-screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
