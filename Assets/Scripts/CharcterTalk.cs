using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterTalk : MonoBehaviour
{

    [SerializeField]
    AudioSource _audioS;
    private float lookRadius = 2f;
    [SerializeField] GameObject _player;
    private Vector3 _ppos;
    // Start is called before the first frame update
    void Start()
    {
        _audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _ppos = _player.transform.position;
        float distance = Vector3.Distance(_ppos, transform.position);
        if (distance <= lookRadius && Input.GetKeyDown(KeyCode.E))
        {
            _audioS.Play();
        }
    }
}
