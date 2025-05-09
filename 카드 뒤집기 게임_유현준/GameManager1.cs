using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager lnstance;
    
    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;

    public int cardCount = 0;
    float time = 0.0f;


    private void Awake()
    {
        if (lnstance == null)
        {
            lnstance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale= 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if (time > 30.0f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            //ÆÄ±«
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true); 
            }
        }
        else 
        { 
            //´Ý±â
            firstCard.CloseCaard();
            secondCard.CloseCaard();

        }
        firstCard = null;
        secondCard = null;





    }


}
