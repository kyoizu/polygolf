using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject scoreBoard;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Goal");
        scoreBoard.SetActive(true);
    }
}
