using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class TuileEffect : MonoBehaviour
{
    public static Action<int> effectplayer;
    
    [SerializeField] private int AdvencedPlayer;
    [SerializeField] private int BackPlayer;
    [SerializeField] private int TeleportCase;

    [SerializeField] private Player _player;
    private MeshRenderer meshRenderer;

    private Color Advance_color = Color.green;
    private Color Back_color = Color.red;
    private Color Teleport_color = Color.yellow;
    
    //[SerializeField] public GameObject[] tuile;
    
    private enum Effect
    {
        Advanced,
        Back,
        Teleport,
        
    }
    [SerializeField] Effect effects;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        
        if (Effect.Advanced == effects)
        {
            meshRenderer.material.color = Advance_color;
            
        }
        else if (Effect.Back == effects)
        {
            meshRenderer.material.color = Back_color;
        }
        else if (Effect.Teleport == effects)
        {
            meshRenderer.material.color = Teleport_color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyEffect()
    {
        if (Effect.Advanced == effects)
        {
            _player.MovePlayer(AdvencedPlayer);
            effectplayer?.Invoke(AdvencedPlayer);
        }
        else if (Effect.Back == effects)
        {
            _player.MovePlayer(BackPlayer);
            effectplayer?.Invoke(BackPlayer);
        }
        else if (Effect.Teleport == effects)
        {
            _player.MovePlayer(TeleportCase);
            effectplayer?.Invoke(TeleportCase);
        }
    }
}
