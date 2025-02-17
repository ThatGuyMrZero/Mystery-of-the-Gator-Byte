using UnityEngine;
using TMPro;
using System.Collections;

public class OrderGenerator : MonoBehaviour
{

    public TextMeshProUGUI orderText;
    public int maxOrders = 10;
    public int orderCount =0;
    public float orderDuration = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(OrderTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateOrder()
    {
        string currentOrder = "Order number" + (orderCount) + ": Pizza";
        orderText.text = currentOrder;
    }

    IEnumerator OrderTimer()
    {
        //int orderCount = 0;

        while(orderCount < maxOrders)
        {
            GenerateOrder();
            orderCount++;
            yield return new WaitForSeconds(orderDuration);

        }
        EndGame();
    }

    void EndGame()
    {
        orderText.text = "Game Over!";
    }
}
