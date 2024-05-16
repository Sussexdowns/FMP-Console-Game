using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TMP_InputFieldHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI displayText;  // Optional: If you want to display the input value somewhere
    public Button submitButton;


    void Start()
    {
        // Ensure the input field and button are not null
        if (inputField != null && submitButton != null)
        {
            // Add a listener to handle the button click
            submitButton.onClick.AddListener(OnSubmitButtonClicked);
        }
    }

    public void OnSubmitButtonClicked()
    {
        // Get the input from the input field
        string userInput = inputField.text;

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
        RaceClass,
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
