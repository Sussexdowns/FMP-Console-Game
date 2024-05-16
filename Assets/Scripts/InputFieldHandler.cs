using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InputFieldHandler : MonoBehaviour
{
    public InputField inputField;
    public Text displayText;  // Optional: If you want to display the input value somewhere

    public TMP_InputField consoleInput; // Reference to the TextMeshPro Input Field
    public TextMeshProUGUI consoleText; // Reference to the TextMeshPro Text for displaying errors


    void Start()
    {
        // Ensure the input field is not null
        if (inputField != null)
        {
            // Add a listener to handle input when the user submits the text
            inputField.onEndEdit.AddListener(OnInputFieldSubmitted);
        }
    }

    void OnInputFieldSubmitted(string userInput)
    {
        // Do something with the input
        Debug.Log("User input: " + userInput);

        // Display the input in the UI Text (optional)
        if (displayText != null)
        {
            displayText.text = "You entered: " + userInput;
        }

        // Process the input as needed
        ProcessInput(userInput);
    }

    void ProcessInput(string input)
    {
        // Your processing logic here
        // For example, you can convert this input to an integer or perform some action
        Debug.Log("Processing input: " + input);
    }

    public enum InputType
    {
        Integer,
        String,
        Race,
        CharacterClass

    }

    public T ConsoleReadLine<T>()
    {
        // Get the input value from the TextMeshPro input field
        string input = inputField.text;

        try
        {
            // Convert the input string to the desired data type
            return (T)System.Convert.ChangeType(input, typeof(T));
        }
        catch (System.Exception)
        {
            // If conversion fails, return default value of the data type
            return default(T);
        }
    }

    

}

