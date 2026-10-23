using System.Collections;
using Sciript;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Dice _dice;

    private int _tuilePos;
    private int actuel_pos;
    private Vector3 _playerPos;
    [SerializeField] private GameObject[] tuile;
    [SerializeField] private int _playerID;
    private int reapeat_tuile;
    [SerializeField] private Board board;
    private bool isMoving; 

    private int move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dice.GetComponent<Dice>();
        _tuilePos = 0;
        if (board == null)
        {
            board = GameObject.Find("Board").GetComponent<Board>();
        }
        
    }

    private void OnEnable()
    {
        //Tuile.effectplayer += MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayDice();
        }
    }

    private void PlayDice()
    {
        if (isMoving) return;
        _dice.throwDice();
        move = _dice.GetDiceValue();
        MovePlayer(move);
    }


    public void MovePlayer(int movement)
    {
        _tuilePos = Mathf.Clamp(_tuilePos + movement, 0, board.boards.Length - 1);
        if (_tuilePos == actuel_pos) return; 
        StartCoroutine(MovePlayer(1f));
    }
    
    
    private IEnumerator MovePlayer(float t)
    {
        isMoving = true;
        int dir = (int)Mathf.Sign(_tuilePos - actuel_pos); // Renvoie la valeur -1 si f est négatif, ou la valeur 1 si f est supérieur ou égal à 0. Cela diffère des implémentations classiques de la fonction « Sign », qui renvoient 0 lorsque f est égal à 0.

        while (actuel_pos != _tuilePos)
        {
            actuel_pos += dir;
            Vector3 start = transform.position;
            Vector3 end = board.boards[actuel_pos].transform.position;
            float time = 0;

            while (time < t)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(start, end, time / t);
                yield return null;
            }
        }

        isMoving = false; // avant l'effet, pour que celui-ci puisse relancer un déplacement

        TuileEffect effect = board.boards[actuel_pos].GetComponent<TuileEffect>();
        if (effect != null) effect.ApplyEffect();
    }

    
    
}
