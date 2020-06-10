using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    AudioSource _audioS;
    [SerializeField]
    Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy.isShooting)
        {
            _audioS.Play();
        }
    }
}
