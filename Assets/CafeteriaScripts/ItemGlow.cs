using UnityEngine;

public class ItemGlow : MonoBehaviour
{

    public Color glowColor = Color.white;
    public float baseEmission = 0.0f;
    public float hoverEmission = 3.0f;

    private Material materialInstance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        materialInstance = GetComponent < SpriteRenderer >().material;
        materialInstance.EnableKeyword("_EMISSION");
        materialInstance.SetColor("_EmissionColor", glowColor * baseEmission);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        materialInstance.SetColor("_EmissionColor", glowColor * hoverEmission);
    }

    void OnMouseExit()
    {
        materialInstance.SetColor("_EmissionColor", glowColor * baseEmission);
    }
}
