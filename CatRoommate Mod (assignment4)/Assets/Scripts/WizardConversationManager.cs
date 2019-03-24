using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardConversationManager : MonoBehaviour
{
    public GameObject wizard;
    public Sprite wizard_0;
    public Sprite wizard_1;
    public Sprite wizard_2;
    public Sprite wizard_3;
    public Sprite wizard_4;
    public Sprite wizard_5;

    public Text ques;
    public string[] questions;
    public int index;

    public Button LeftButton;
    public string[] LAnswers;
    public Button RightButton;
    public string[] RAnswers;

    public int count1 = 0;
    public int count2 = 0;
    public Text buttonLeft;
    public Text buttonRight;

    public float typingSpeed;

    public int GoodAnswers;
    public int BadAnswers;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type1());
        StartCoroutine(Type2());
        StartCoroutine(Type3());
    }

    // Update is called once per frame
    IEnumerator Type1()
    {
        foreach (char letter in questions[index].ToCharArray())
        {
            ques.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator Type2()
    {
        foreach (char letter in LAnswers[count1].ToCharArray())
        {
            buttonLeft.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator Type3()
    {
        foreach (char letter in RAnswers[count2].ToCharArray())
        {
            buttonRight.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void GetQuestion()
    {
        if (index < questions.Length - 1)
        {
            index++;
            ques.text = "";
            StartCoroutine(Type1());
        }
    }

    public void GetLeftAnswers()
    {
        if (count1 < LAnswers.Length - 1)
        {
            count1++;
            buttonLeft.text = "";
            StartCoroutine(Type2());
        }
    }
    public void GetRightAnswers()
    {
        if (count2 < RAnswers.Length - 1)
        {
            count2++;
            buttonRight.text = "";
            StartCoroutine(Type3());
        }
    }

    public void ClickLeft()
    {
        GetQuestion();
        GetLeftAnswers();
        GetRightAnswers();

        if (index == 1)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_0;
            GoodAnswers++;
        }

        if (index == 2)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_0;
            GoodAnswers++;
        }

        if (index == 3)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_1;
            GoodAnswers++;
        }

        if (index == 4)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_5;
            GoodAnswers++;
        }

        if (index == 5)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_3;
            GoodAnswers++;
        }

        if (index == 6)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_5;
            GoodAnswers++;
        }

        if (index == 7)
        {
            ShowResult();
        }
    }

    public void ClickRight()
    {
        GetQuestion();
        GetLeftAnswers();
        GetRightAnswers();

        if (index == 1)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_0;
            BadAnswers++;
        }

        if (index == 2)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_1;
            BadAnswers++;
        }

        if (index == 3)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_2;
            BadAnswers++;
        }

        if (index == 4)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_2;
            BadAnswers++;
        }

        if (index == 5)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_3;
            BadAnswers++;
        }

        if (index == 6)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_5;
            BadAnswers++;
        }

        if (index == 7)
        {
            ShowResult();
        }
    }

    public void ShowResult()
    {
        if (GoodAnswers >= BadAnswers)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_5;
            ques.text = "You're a polite kid. I'll be your roommate if you can't find other roommate.";
            Destroy(LeftButton.gameObject);
            Destroy(RightButton.gameObject);
        }

        if (BadAnswers >= GoodAnswers)
        {
            wizard.gameObject.GetComponent<SpriteRenderer>().sprite = wizard_4;
            ques.text = "I don't want to be your roommate. Now I'll clean up your memory about this conversation, so I can hide my existence.";
            Destroy(LeftButton.gameObject);
            Destroy(RightButton.gameObject);
        }
    }
}
