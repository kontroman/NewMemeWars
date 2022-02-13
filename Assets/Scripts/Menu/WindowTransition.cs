using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(Button))]
public class WindowTransition : MonoBehaviour 
{
    [SerializeField]
    protected GameObject current;
    public GameObject Current { get { return current; } }

    [SerializeField]
    protected GameObject target;
    public GameObject Target { get { return target; } }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (current != null)
            current.SetActive(false);

        if (target != null)
            target.SetActive(true);
    }
}
