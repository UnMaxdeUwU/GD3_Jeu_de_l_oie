using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private int min = 1;
    [SerializeField] private int max = 6;
    private int diceValue;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    

    // Update is called once per frame
    void Update()
    {

    }

    public void throwDice()
    {
        diceValue = Random.Range(min, max);
    }


    public int GetDiceValue() => diceValue;
}
