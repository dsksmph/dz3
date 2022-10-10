using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(MeshRenderer))]
    public class Player : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material powerUpMaterial;

    [SerializeField] private float powerUpDuration;
    private MeshRenderer _renderer;

    public bool IsAlive { get; private set; } = true;
    public bool HasKey { get; private set; } = false;
    public bool HasPowerUp { get; private set; } = false;
    
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Enable();
    }

    public void Enable()
    {
        _movement.enabled = true;
    }

    public void Disable()
    {
        _movement.enabled = false;
    }

    public void Kill()
    {
        IsAlive = false;
    }

    public void PickUpKey()
    {
        HasKey = true;
    }

    public void ActivatePowerUp()
        {
            HasPowerUp = true;
            _renderer.sharedMaterial = powerUpMaterial;
            StartCoroutine(PowerUpCountDown(powerUpDuration));
        }

    private IEnumerator PowerUpCountDown(float duration)
        {
            yield return new WaitForSeconds(duration);
            HasPowerUp = false;
            _renderer.sharedMaterial = defaultMaterial;
        }
}
}