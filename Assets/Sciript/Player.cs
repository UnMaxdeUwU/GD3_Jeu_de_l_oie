using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Dice _dice;

    private int _tuilePos;
    private Vector3 _playerPos;
    [SerializeField] private GameObject[] tuile;
    [SerializeField] private int _playerID;
    private int reapeat_tuile;
    

    private int move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _dice.GetComponent<Dice>();
        _tuilePos = 0;
        
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
        _dice.throwDice();
        move = _dice.GetDiceValue();
        MovePlayer(move);
    }

    public void MovePlayer(int movement)
    {
        
        _tuilePos += movement;
        StartCoroutine(MovePlayer(2f, movement));


        //transform.position = tuile[_tuilePos].transform.position;
        
        Debug.Log(_tuilePos);
        if (tuile[_tuilePos].GetComponent<Tuile>() != null)
        {
            tuile[_tuilePos].GetComponent<Tuile>().ApplyEffect();
        }
    }

    private IEnumerator MovePlayer(float t, int mov)
    {
        float time = 0;
        
        for (int i = 0; i < mov; i++)
        {
            while (time < t)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, tuile[_tuilePos].transform.position, time * Time.deltaTime);
            }

            time = 0;
        }

        yield return null;
        
    }

    
    
}
