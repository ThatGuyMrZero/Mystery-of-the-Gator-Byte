using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class OrderGenerator : MonoBehaviour
{


    public TextMeshProUGUI orderText;
    //public GameObject orderCard;
    //public Transform orderQueueParent;
    public int maxOrders = 10;
    public int orderCount = 0;
    public int completedOrders = 0;
    public float orderDuration = 7f;

    private List<string> menuItems = new List<string> { "Pizza", "Burger", "Dessert"};
    private List<string> pizzaToppings = new List<string> { "Pepperoni", "Mushroom", "Pineapple" };
    private List<string> burgerToppings = new List<string> { "Cheese", "Ketchup", "Mustard", "Lettuce", "Tomato", "Onion" };

    private Queue<List<string>> orderQueue = new Queue<List<string>>();


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
        if (orderCount >= maxOrders)
        {
            return;
        }

        //int orderType = Random.Range(0, 3);
        //string orderType = menuItems[Random.Range(0, menuItems.Count)];
        string orderType = "Pizza";
        int dessertOrdered = Random.Range(0,2); // 0 is no, 1 is yes 

        List<string> orderItems = new List<string>();

        if(orderType == "Pizza")
        {
            orderItems.Add("Dough");
            orderItems.Add("Sauce");
            orderItems.Add("Cheese");

            int numToppings = Random.Range(0, 3);
            for (int i = 0; i < numToppings; i++)
            {
                string topping = pizzaToppings[Random.Range(0, pizzaToppings.Count)];
                if(!orderItems.Contains(topping))
                {
                    orderItems.Add(topping);
                }
            }

        }
        // burger logic here

        Debug.Log(string.Join(", ", orderItems));

        orderQueue.Enqueue(orderItems);
        orderCount++;
        UpdateOrderUI();

        //string currentOrder = "Order number " + (orderCount+1) + ": " + menuItems[orderType];
        //string currentOrder = "Order number " + (orderCount+1) + ": " + menuItems[0]; // this line for rn while i have pizza hard coded, otherwise switch to line above
        //orderText.text = currentOrder;
    }

    IEnumerator OrderTimer()
    {
        //int orderCount = 0;

        while(orderCount < maxOrders)
        {
            GenerateOrder();
            //orderCount++;
            yield return new WaitForSeconds(orderDuration);

        }
        EndGame();
    }

    void UpdateOrderUI()
    {
        string ordersDisplay = "";
        int orderNumber = 1;

        foreach (var order in orderQueue)
        {
            ordersDisplay += $"Order {orderNumber}: {string.Join(", ", order)}\n\n";
            orderNumber++;
        }

        orderText.text = ordersDisplay;
    }

    public List<string> GetActiveOrder()
    {
        return orderQueue.Count > 0 ? orderQueue.Peek() : null;
    }

    public void CompleteOrder()
    {
        if (orderQueue.Count > 0)
        {
            orderQueue.Dequeue();
            completedOrders++;

            if (completedOrders >= maxOrders)
            {
                EndGame();
            }
            else
            {
                UpdateOrderUI();
            }
        }

    }

    void EndGame()
    {
        orderText.text = "Game Over!";
        Debug.Log("Game over");
        Time.timeScale = 0;
    }
}
