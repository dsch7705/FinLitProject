using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MundyDialogue : MonoBehaviour
{
    public Text mundyText;

    public InputField answer;
    public Text answerPlaceholder;
    public Text answerText;

    public GameObject brackets;

    public int currentDialogue = 0;

    public int moneyStated;
    public int bracketStated;

    public GameObject endScreenBad;

    public Dictionary<int, string> dialogue = new Dictionary<int, string>()
    {
        { 0, "Hello, I'm Tax Man Mundy. I was looking over your 1040, and some of your math doesn't add up. Can you tell me, what was your gross income during the last year?" },
        { 1, "Thanks. Now, what tax bracket were you in according to this chart?" },
        { 2, "According to the information you provided me with, you made ${0} this year. At this amount, you should have been paying {1}% in taxes, or a total of ${2}, of which you have only paid ${3}. Unfortunately, I must report you to the IRS." }
    };

    public Dictionary<int, string> inputPlaceholders = new Dictionary<int, string>()
    {
        { 0, "Input your gross income." },
        { 1, "Input your tax bracket." },
        { 2, "Okay." }
    };

    public Dictionary<int, float> taxBrackets = new Dictionary<int, float>()
    {
        { 1, 0.10f },
        { 2, 0.12f },
        { 3, 0.22f },
        { 4, 0.24f },
        { 5, 0.32f },
        { 6, 0.35f },
        { 7, 0.37f }
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProgressDialogue()
    {
        if (currentDialogue < dialogue.Count)
        {
            currentDialogue++;
            mundyText.text = dialogue[currentDialogue];
        }

        switch (currentDialogue)
        {
            case 1:
                brackets.SetActive(true);
                moneyStated = Int32.Parse(answer.text);
                answer.text = "";
                answerPlaceholder.text = inputPlaceholders[currentDialogue];
                break;
            case 2:
                int bracket = Int32.Parse(answer.text);
                brackets.SetActive(false);
                if (bracket > 0 && bracket <= 7)
                {
                    bracketStated = bracket;
                    Debug.Log("Bracket Set");
                }
                answer.text = "";
                break;
            default:
                brackets.SetActive(false);
                break;
        }

        if (currentDialogue == 2)
        {
            mundyText.text = string.Format(dialogue[currentDialogue], moneyStated.ToString("n0"), taxBrackets[bracketStated] * 100, (moneyStated * taxBrackets[bracketStated]).ToString("n0"), W2Handler.instance.fedTax.text);
            StartCoroutine("StartEndScreen");
        }
    }

    IEnumerator StartEndScreen()
    {
        yield return new WaitForSeconds(4.0f);
        endScreenBad.SetActive(true);
        gameObject.SetActive(false);
    }
}
