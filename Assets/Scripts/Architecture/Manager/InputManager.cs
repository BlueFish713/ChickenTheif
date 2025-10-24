using System;
using UnityEngine;

[Singleton]
public class InputManager : MonoBehaviour
{
    [SerializeField] int _horizontal = 0;
    [SerializeField] int _latestHorizontal = 0;

    public bool ignoreHorizontalInput = false;
    
    public int Horizontal { get => _horizontal; private set => _horizontal = value; }
    public int LatestHorizontal { get => _latestHorizontal; set
    {
            if (value != 0)
            {
                _latestHorizontal = value;
                EventManager.Publish(EventName.ChangeLatestHorizontal);
            }
    } }

    int _vertical = 0;
    public int Vertical { get => _vertical; private set => _vertical = value; }

    bool _jump;
    public bool Jump { get => _jump; private set => _jump = value; }

    bool _dash;
    public bool Dash { get => _dash; private set => _dash = value; }

    [SerializeField] bool _F;
    public bool F { get => _F; private set => _F = value; }

    [SerializeField] bool _ESC;
    public bool ESC { get => _ESC; private set => _ESC = value; }

    void Update()
    {
        Horizontal = (int)Input.GetAxisRaw("Horizontal");
        if (ignoreHorizontalInput) Horizontal = 0;
        Vertical = (int)Input.GetAxisRaw("Vertical");
        Jump = (int)Input.GetAxisRaw("Jump") != 0 ? true : false;
        Dash = (int)Input.GetAxisRaw("Dash") != 0 ? true : false;
        F = Input.GetKey(KeyCode.F);
        ESC = Input.GetKey(KeyCode.Escape);
    }
}