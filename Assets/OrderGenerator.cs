using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class OrderGenerator : MonoBehaviour
{


    public TextMeshProUGUI orderText;
    public int maxOrders = 10;
    public int orderCount =0;
    public float orderDuration = 7f;

    private List<string> menuItems = new List<string> { "Pizza", "Burger", "Dessert"};
    private List<string> pizzaToppings = new List<string> { "Extra Cheese", "Pepperoni", "Mushroom", "Pineapple" };
    private List<string> burgerToppings = new List<string> { "Cheese", "Ketchup", "Mustard", "Lettuce", "Tomato", "Onion" };


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

        int orderType = Random.Range(0, 3);
        int dessertOrdered = Random.Range(0,2); // 0 is no, 1 is yes 


        string currentOrder = "Order number " + (orderCount+1) + ": " + menuItems[orderType];
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
