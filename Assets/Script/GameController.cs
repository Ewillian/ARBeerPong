using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private const string BLUE_WINS_TEXT = "Blue wins!";
    private const string RED_WINS_TEXT = "Red wins!";
    private const string EQUALITY_TEXT = "Equality.";

    /// <summary>
    /// Defines the player red score
    /// </summary>
    private int playerRedScore;

    /// <summary>
    /// Defines the player blue score
    /// </summary>
    private int playerBlueScore;

    /// <summary>
    /// Defines the player blue score
    /// </summary>
    private int MaxScore;

    /// <summary>
    /// Defines the player's turn
    /// </summary>
    private bool turn;

    /// <summary>
    /// Defines number turn
    /// </summary>
    private int nbTurn;

    /// <summary>
    /// Defines the player's turn
    /// </summary>
    public GameObject pingPongBall;

    /// <summary>
    /// Defines the player blue Text Mesh
    /// </summary>
    public Text TBlueScore;

    /// <summary>
    /// Defines the player red Text Mesh
    /// </summary>
    public Text TRedScore;

    /// <summary>
    /// Defines the turn text tesh
    /// </summary>
    public Text TTurn;

    /// <summary>
    /// Keeps in memory each player progression
    /// </summary>
    public GameObject[] cups;
    private bool[] cupsPlayerRed;
    private bool[] cupsPlayerBlue;

    /// <summary>
    /// The red image background
    /// </summary>
    Image redImageBackground;

    /// <summary>
    /// The blue image background
    /// </summary>
    Image blueImageBackground;

    [SerializeField]
    Material materialBlue;

    [SerializeField]
    Material materialRed;

    public GameObject winPanel;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        playerRedScore = 0;
        playerBlueScore = 0;
        MaxScore = 6;

        cupsPlayerRed = new bool[cups.Length];
        cupsPlayerBlue = new bool[cups.Length];
        for (int i = 0; i < cups.Length; i++)
        {
            cupsPlayerRed[i] = true;
            cupsPlayerBlue[i] = true;
        }

        nbTurn = 0;

        turn = (Random.Range(1, 10) % 2 == 1 ? true : false);

        SetActualTurnText();

        redImageBackground = GameObject.FindGameObjectWithTag("RedBackground").GetComponent<Image>();
        blueImageBackground = GameObject.FindGameObjectWithTag("BlueBackground").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SwitchPlayerTurnColor()
    {
        if (turn == true)
        {
            redImageBackground.enabled = true;
            blueImageBackground.enabled = false;
        }
        else if (turn == false)
        {
            redImageBackground.enabled = false;
            blueImageBackground.enabled = true;
        }
    }

    public void AddPoint()
    {
        if (turn == true)
        {
            playerRedScore++;
            print("Red" + playerRedScore);
            TRedScore.text = playerRedScore.ToString();
        }
        else if (turn == false)
        {
            playerBlueScore++;
            print("Blue" + playerBlueScore);
            TBlueScore.text = playerBlueScore.ToString();
        }

        nbTurn++;
        CheckWin();
    }

    public void NextTurn()
    {
        if(playerRedScore <= MaxScore && playerBlueScore <= MaxScore)
        {
            turn = !turn;
            SwitchPlayerTurnColor();
            SetActualTurnText();
        }
    }

    public void CheckWin()
    {
        // Check if player have play same number of turn
        if(nbTurn % 2 == 0)
        {
            if(playerBlueScore == MaxScore && playerRedScore == MaxScore)
            {
                print("Equality !");
                Win(EQUALITY_TEXT);
            }
            else if (playerBlueScore == MaxScore)
            {
                print("Blue Win !");
                Win(BLUE_WINS_TEXT);
            }
            else if (playerRedScore == MaxScore)
            {
                print("Red Win !");
                Win(RED_WINS_TEXT);
            }
        }
    }

    public void Win(string winString)
    {
        winPanel.SetActive(true);
        Text winText = winTextObject.GetComponent(typeof(Text)) as Text;
        winText.text = winString;
    }

    public void SetActualTurnText()
    {
        TTurn.text = (turn ? "Red" : "Blue");
    }

    public void RemoveCup(string collider)
    {
        if (turn)
        {
            for (int i = 0; i < cups.Length; i++)
            {
                if (cups[i].name == collider)
                {
                    cupsPlayerRed[i] = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < cups.Length; i++)
            {
                if (cups[i].name == collider)
                {
                    cupsPlayerBlue[i] = false;
                }
            }
        }
    }

    public void LoadCups()
    {
        if (turn)
        {
            for (int i = 0; i < cups.Length; i++)
            {
                cups[i].SetActive(cupsPlayerRed[i]);
                if(cupsPlayerRed[i]) cups[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = materialRed;
            }
        }
        else
        {
            for (int i = 0; i < cups.Length; i++)
            {
                cups[i].SetActive(cupsPlayerBlue[i]);
                if (cupsPlayerBlue[i]) cups[i].transform.GetChild(0).GetComponent<MeshRenderer>().material = materialBlue;
            }
        }
    }
}
