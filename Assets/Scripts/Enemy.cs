using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Animator _animator;

    NavMeshAgent _navMeshAgent;
    private Target[] _Targets;
    private Target _target;
    [SerializeField]
    GameObject _player;
    [SerializeField]
    private GameObject _bulletHole;
    [SerializeField]
    private GameObject _muzzleFlash;
    private float NextState;
    private float lookRadius = 10f;
    private Vector3 _ppos;
    public bool isShooting = false;
    AudioSource _aS;

    private void Start()
    {
        _aS = GetComponent<AudioSource>();
        _muzzleFlash.SetActive(false);
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.LogError("Navmash null" + gameObject.name);
        }
        _animator = GetComponent<Animator>();
        _Targets = FindObjectsOfType<Target>();
        _target = _Targets[Random.Range(0, _Targets.Length - 1)];
        _animator.SetBool("Run", true);
        _navMeshAgent.SetDestination(_target.transform.position);

    }

    private void Update()
    {
        _ppos = _player.transform.position;
        if (!_navMeshAgent.hasPath)
        {
            _animator.SetBool("Run", false);
            NextState -= Time.deltaTime;
            if (NextState <= 0)
            {

                _animator.SetBool("Run", true);
                _target = _Targets[Random.Range(0, _Targets.Length - 1)];
                _navMeshAgent.SetDestination(_target.transform.position);
                NextState = Random.Range(7f, 15f);
            }
        }


        float distance = Vector3.Distance(_ppos, transform.position);
        if (distance <= lookRadius)
        {
            ShootPlayer();
            FacePlayer();
        }
        else
        {
            // faceDirection();
            _muzzleFlash.SetActive(false);
            isShooting = false;
        }
    }

    private void FacePlayer()
    {
        Vector3 direction = (_ppos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // transform.rotation = lookRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private void faceDirection()
    {
        Vector3 direction = (_navMeshAgent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // transform.rotation = lookRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    private void ShootPlayer()
    {
        isShooting = true;
        _aS.Play();
        _muzzleFlash.SetActive(true);
        //position ray casted from 
        Ray rayOrigin = new Ray(transform.position + Vector3.up * 1.5f, transform.forward + new Vector3(0.2f, 0.2f, 0.2f));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            GameObject hitMarker = Instantiate(_bulletHole, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)) as GameObject;
            Destroy(hitMarker, 1f);
        }
        if (hitInfo.collider.gameObject.tag == "Player")
        {

        }
    }


    //private Vector3 GetRandomDir()
    //{
    //    float x = UnityEngine.Random.Range(-1f, 1f);
    //    float z = UnityEngine.Random.Range(-1f, 1f);
    //    Vector3 dir=new Vector3(x,0,z).normalized;

    //    return startinPosition + dir * Random.Range(10f, 70f);
    //}
}
