using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogConversationManager : MonoBehaviour
{
    public GameObject dog;
    public Sprite dog_0;
    public Sprite dog_1;
    public Sprite dog_2;
    public Sprite dog_3;
    public Sprite dog_4;
    public Sprite dog_5;
    public Sprite dog_6;
    public Sprite dog_7;
    public Sprite dog_8;

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
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_1;
            GoodAnswers++;
        }

        if (index == 2)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_5;
            GoodAnswers++;
        }

        if (index == 3)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_2;
            BadAnswers++;
        }

        if (index == 4)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_6;
            BadAnswers++;
        }

        if (index == 5)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_8;
            GoodAnswers++;
        }

        if (index == 6)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_0;
            BadAnswers++;
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
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_0;
            BadAnswers++;
        }

        if (index == 2)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_5;
            BadAnswers++;
        }

        if (index == 3)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_4;
            GoodAnswers++;
        }

        if (index == 4)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_6;
            GoodAnswers++;
        }

        if (index == 5)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_7;
            BadAnswers++;
        }

        if (index == 6)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_3;
            GoodAnswers++;
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
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_3;
            ques.text = "Let's be roommates!! We should celebrate with some delicious home-made buffalo chicken!";
            Destroy(LeftButton.gameObject);
            Destroy(RightButton.gameObject);
        }

        if (BadAnswers >= GoodAnswers)
        {
            dog.gameObject.GetComponent<SpriteRenderer>().sprite = dog_1;
            ques.text = "I'm so sorry, I can't live with you...but I like you! So let's be friends!";
            Destroy(LeftButton.gameObject);
            Destroy(RightButton.gameObject);
        }
    }
}
