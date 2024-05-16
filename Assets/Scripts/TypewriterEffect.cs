using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI displayText;  // TextMeshPro Text component

    public TMP_InputField inputField;


    public float typingSpeed = 0.05f;  // Speed of typing effect
    public Color defaultColor = Color.white;  // Default text color
    public bool linetype = true;


    void Start()
    {
        // Example usage: call the DisplayText method with the desired message

        ClearText();
        StartCoroutine(DisplayTextSequence());
    }

    private IEnumerator DisplayTextSequence()
    {
        yield return StartCoroutine(StartTypewriterEffect("Welcome to the Fantasy RPG!", Color.blue, true));
        yield return StartCoroutine(StartTypewriterEffect("\nWelcome to the Fantasy RPG!", Color.red, true));
        yield return StartCoroutine(StartTypewriterEffect("\nWelcome to the Fantasy RPG!", Color.blue, true));

        yield return StartCoroutine(StartTypewriterEffect("\nWhat is your name?!", Color.white, true));
    }


    public void DisplayTextInput()
    {
        string userInput = inputField.text;
        StartCoroutine(StartTypewriterEffect("\n" + userInput, Color.green, true));
    }
    

    private IEnumerator StartTypewriterEffect(string message, Color textColor, bool append)
    {
        if (!append)
        {
            displayText.text = ""; // Clear the text field initially
        }

        string colorPrefix = $"<color=#{ColorUtility.ToHtmlStringRGB(textColor)}>";
        string colorSuffix = "</color>";

        foreach (char letter in message)
        {
            displayText.text += colorPrefix + letter + colorSuffix;
            yield return WaitForSecondsRealtime(typingSpeed); // Wait for the specified time
        }
    }

    private IEnumerator WaitForSecondsRealtime(float seconds)
    {
        float startTime = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < startTime + seconds)
        {
            yield return null; // Wait until the time has passed
        }
    }

    public IEnumerator ConsoleWriteLine(string message)
    {
        yield return StartCoroutine(StartTypewriterEffect(message, defaultColor, linetype));
    }

    public IEnumerator ConsoleWriteLine(string message, Color textColor, bool linetype)
    {
        yield return StartCoroutine(StartTypewriterEffect(message, textColor, linetype));
    }


    /*
    public void StartTypewriterEffect(string message, Color textColor, bool linetype)
    {
        
        SetTextColor(textColor);

        string prefix, suffix;
        string color = PerformActionBasedOnColor(textColor);

        switch (color)
        {
            case "red":
                prefix = "<color=\"red\">";
                suffix = "</color>";
                break;
            case "green":
                prefix = "<color=\"green\">";
                suffix = "</color>";
                break;
            case "blue":
                prefix = "<color=\"blue\">";
                suffix = "</color>";
                break;
            default:
                prefix = "<color=\"white\">";
                suffix = "</color>";
                break;
        }

        //message =  prefix + message + suffix;


        linetype = true;  // Set linetype
        StartCoroutine(TypeText(message, linetype, prefix, suffix));
    }

    */


    public string PerformActionBasedOnColor(Color color)
    {
        string colorString = ColorUtility.ToHtmlStringRGB(color);
        string result;

        switch (colorString)
        {
            case "FF0000": // Red
                Debug.Log("The color is red.");
                result = "red";
                break;
            case "00FF00": // Green
                Debug.Log("The color is green.");
                result = "green";
                break;
            case "0000FF": // Blue
                Debug.Log("The color is blue.");
                result = "blue";
                break;
            default:
                Debug.Log("The color is something else.");
                result = "white";
                break;
        }
        return result;
    }

    private IEnumerator TypeText(string message, bool linetype, string prefix, string suffix)
    {

        if (linetype == true) {
            ClearText();  // Clear any existing text
        }
        displayText.text = prefix;

        foreach (char letter in message.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        displayText.text +=prefix;

    }

    public void ClearText()
    {
        displayText.text = "";
    }


    public void SetTextColor(Color color)
    {
        if (displayText != null)
        {
            displayText.color = color;  // Set the text color
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component is not assigned.");
        }
    }
}
