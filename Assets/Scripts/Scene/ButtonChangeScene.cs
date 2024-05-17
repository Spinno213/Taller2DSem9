using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
