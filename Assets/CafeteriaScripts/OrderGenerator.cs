using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class OrderGenerator : MonoBehaviour
{
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public TextMeshProUGUI orderText;
    //public GameObject orderCard;
    //public Transform orderQueueParent;
    public int maxOrders = 10;
    public int orderCount = 0;
    public int completedOrders = 0;
    //public float orderDuration = 7f;

    private List<string> menuItems = new List<string> { "Pizza", "Burger" };
    private List<string> pizzaToppings = new List<string> { "Pepperoni", "Mushroom", "Pineapple" };
    private List<string> burgerToppings = new List<string> { "Cheese", "Ketchup", "Mustard", "Lettuce", "Tomato", "Onion" };

    private Queue<List<string>> orderQueue = new Queue<List<string>>();

    //public GameManager gamemanager;

    public float gameDuration = 90f;

    public Difficulty gameDifficulty = Difficulty.Normal;

    public TextMeshProUGUI difficultyText;
    public TextMeshProUGUI gameTimer;

    public float gameStartTime;

    public float easyMinDelay = 6f;
    public float easyMaxDelay = 10f;
    public float normalMinDelay = 5f;
    public float normalMaxDelay = 8f;
    public float hardMinDelay = 3f;
    public float hardMaxDelay = 7f;

    public EndgameManager endgamemanager;


    void OnEnable()
    {
        GameManager.OnGameStart += StartGame;
    }

    void OnDisable()
    {
        GameManager.OnGameStart -= StartGame;
    }


    public void StartGame()
    {
        gameStartTime = Time.time;

        difficultyText.text = "Difficulty: " + gameDifficulty.ToString();
        StartCoroutine(UpdateGameTimer());
        StartCoroutine(OrderTimer());
    }


    void GenerateOrder()
    {
        //if (orderCount >= maxOrders)
        //{
        //    return;
        //}

        //int orderType = Random.Range(0, 3);
        //string orderType = menuItems[Random.Range(0, menuItems.Count)];
        string orderType = "";
        int randomOrder = Random.Range(0,2); // 0 is no, 1 is yes 

        if(randomOrder == 0)
        {
            orderType = "Pizza";
        }
        else
        {
            orderType = "Burger";
        }    

        List<string> orderItems = new List<string>();

        if(orderType == "Pizza")
        {
            orderItems.Add("Dough");
            orderItems.Add("Sauce");
            orderItems.Add("Cheese");

            int numToppings = 0;

            switch(gameDifficulty)
            {
                case Difficulty.Easy:
                    numToppings = Random.Range(0, 2);
                    break;
                case Difficulty.Normal:
                    numToppings = Random.Range(0, 3);
                    break;
                case Difficulty.Hard:
                    numToppings = Random.Range(0, pizzaToppings.Count + 1);
                    break;
            }

            //int numToppings = Random.Range(0, 3);
            for (int i = 0; i < numToppings; i++)
            {
                string topping = pizzaToppings[Random.Range(0, pizzaToppings.Count)];
                if(!orderItems.Contains(topping))
                {
                    orderItems.Add(topping);
                }
            }

        }
        else if(orderType == "Burger")
        {
            // burger logic here
            orderItems.Add("Bun");
            orderItems.Add("Patty");

            int numToppings = 0;
            switch(gameDifficulty)
            {
                case Difficulty.Easy:
                    numToppings = Random.Range(0, 2);
                    break;
                case Difficulty.Normal:
                    numToppings = Random.Range(0, 3);
                    break;
                case Difficulty.Hard:
                    numToppings = Random.Range(0, burgerToppings.Count + 1);
                    break;
            }

            //int numToppings = Random.Range(0, 3);
            for (int i = 0; i < numToppings; i++)
            {
                string topping = burgerToppings[Random.Range(0, burgerToppings.Count)];
                if(!orderItems.Contains(topping))
                {
                    orderItems.Add(topping);
                }
            }

            orderItems.Add("Bun");
        }


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
        float startTime = Time.time;


        while(Time.time - startTime < gameDuration)
        {
            GenerateOrder();
            float orderDuration = 0f;

            switch(gameDifficulty)
            {
                case Difficulty.Easy:
                    orderDuration = Random.Range(easyMinDelay, easyMaxDelay);
                    break;
                case Difficulty.Normal:
                    orderDuration = Random.Range(normalMinDelay, normalMaxDelay);
                    break;
                case Difficulty.Hard:
                    orderDuration = Random.Range(hardMinDelay, hardMaxDelay);
                    break;
            }

            yield return new WaitForSeconds(orderDuration);

        }
        EndGame();
    }

    void UpdateOrderUI()
    {
        string ordersDisplay = "";
        int orderNumber = 1;

        ordersDisplay += $"Orders in queue: {orderQueue.Count}\n\n";

        foreach (var order in orderQueue)
        {
            if (orderNumber < 5) 
            {
                ordersDisplay += $"Order {orderNumber}: {string.Join(", ", order)}\n\n";
            }
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

            //if (completedOrders >= maxOrders)
            //{
            //    EndGame();
            //}
            //else
            //{
            //    UpdateOrderUI();
            //}
            UpdateOrderUI();
        }

    }

    void EndGame()
    {
        orderText.text = "Game Over!";
        Debug.Log("Game over");
        Time.timeScale = 0;
        endgamemanager.EndGame();
    }

    IEnumerator UpdateGameTimer()
    {
        while (Time.time - gameStartTime < gameDuration)
        {
            float remainingTime = gameDuration - (Time.time - gameStartTime);
            gameTimer.text = "Time Left: " + Mathf.Ceil(remainingTime).ToString();
            yield return null;
        }
        gameTimer.text = "Time Left: 0";
    }
}
