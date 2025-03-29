using UnityEngine;

public class TextBoxManager : MonoBehaviour
{
    public GameObject booleanTextBox;
    public GameObject charTextBox;
    public GameObject arrayTextBox;
    public GameObject classTextBox;
    public GameObject conditionalStatementTextBox;
    public GameObject doubleTextBox;
    public GameObject elseStatementTextBox;
    public GameObject forLoopsTextBox;
    public GameObject ifStatementTextBox;
    public GameObject integerTextBox;
    public GameObject iterationTextBox;
    public GameObject loopTextBox;
    public GameObject nestedTextBox;
    public GameObject operatorTextBox;
    public GameObject stringTextBox;
    public GameObject syntaxTextBox;
    public GameObject variableTextBox;
    public GameObject whileLoopTextBox;

    void Start()
    {
        // Hide all text boxes at start
        booleanTextBox.SetActive(false);
        charTextBox.SetActive(false);
        arrayTextBox.SetActive(false);
        classTextBox.SetActive(false);
        conditionalStatementTextBox.SetActive(false);
        doubleTextBox.SetActive(false);
        elseStatementTextBox.SetActive(false);
        forLoopsTextBox.SetActive(false);
        ifStatementTextBox.SetActive(false);
        integerTextBox.SetActive(false);
        iterationTextBox.SetActive(false);
        loopTextBox.SetActive(false);
        nestedTextBox.SetActive(false);
        operatorTextBox.SetActive(false);
        stringTextBox.SetActive(false);
        syntaxTextBox.SetActive(false);
        variableTextBox.SetActive(false);
        whileLoopTextBox.SetActive(false);
    }

    public void ShowTextBox(string type)
    {
        // Hide all text boxes before showing the right one
        booleanTextBox.SetActive(false);
        charTextBox.SetActive(false);
        arrayTextBox.SetActive(false);
        classTextBox.SetActive(false);
        conditionalStatementTextBox.SetActive(false);
        doubleTextBox.SetActive(false);
        elseStatementTextBox.SetActive(false);
        forLoopsTextBox.SetActive(false);
        ifStatementTextBox.SetActive(false);
        integerTextBox.SetActive(false);
        iterationTextBox.SetActive(false);
        loopTextBox.SetActive(false);
        nestedTextBox.SetActive(false);
        operatorTextBox.SetActive(false);
        stringTextBox.SetActive(false);
        syntaxTextBox.SetActive(false);
        variableTextBox.SetActive(false);
        whileLoopTextBox.SetActive(false);

        // Show the correct text box
        if (type == "Boolean")
            booleanTextBox.SetActive(true);
        else if (type == "Char")
            charTextBox.SetActive(true);
        else if (type == "Array")
            arrayTextBox.SetActive(true);
        else if (type == "Class")
            classTextBox.SetActive(true);
        else if (type == "ConditionalStatement")
            conditionalStatementTextBox.SetActive(true);
        else if (type == "Double")
            doubleTextBox.SetActive(true);
        else if (type == "ElseStatement")
            elseStatementTextBox.SetActive(true);
        else if (type == "ForLoop")
            forLoopsTextBox.SetActive(true);
        else if (type == "IfStatement")
            ifStatementTextBox.SetActive(true);
        else if (type == "Integer")
            integerTextBox.SetActive(true);
        else if (type == "Iteration")
            iterationTextBox.SetActive(true);
        else if (type == "Loop")
            loopTextBox.SetActive(true);
        else if (type == "Nested")
            nestedTextBox.SetActive(true);
        else if (type == "Operator")
            operatorTextBox.SetActive(true);
        else if (type == "String")
            stringTextBox.SetActive(true);
        else if (type == "Syntax")
            syntaxTextBox.SetActive(true);
        else if (type == "Variable")
            variableTextBox.SetActive(true);
        else if (type == "WhileLoop")
            whileLoopTextBox.SetActive(true);
    }

    public void HideAllTextBoxes()
    {
        // Hide all text boxes when close is clicked
        booleanTextBox.SetActive(false);
        charTextBox.SetActive(false);
        arrayTextBox.SetActive(false);
        classTextBox.SetActive(false);
        conditionalStatementTextBox.SetActive(false);
        doubleTextBox.SetActive(false);
        elseStatementTextBox.SetActive(false);
        forLoopsTextBox.SetActive(false);
        ifStatementTextBox.SetActive(false);
        integerTextBox.SetActive(false);
        iterationTextBox.SetActive(false);
        loopTextBox.SetActive(false);
        nestedTextBox.SetActive(false);
        operatorTextBox.SetActive(false);
        stringTextBox.SetActive(false);
        syntaxTextBox.SetActive(false);
        variableTextBox.SetActive(false);
        whileLoopTextBox.SetActive(false);
    }
}
