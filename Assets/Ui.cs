using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
        Player.GetInstance().OnScoreChanged += OnPlayerScoreChanged;
	}

    private void OnPlayerScoreChanged(int score)
    {
        scoreText.text = "SCORE : " + score.ToString(CultureInfo.InvariantCulture);
    }

    public void OnRetry()
    {
        StartCoroutine(Retry());
    }

    public IEnumerator Retry()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        yield return SceneManager.LoadSceneAsync("main", LoadSceneMode.Single);
        yield return SceneManager.LoadSceneAsync("ui", LoadSceneMode.Additive);
        Destroy(transform.parent.gameObject);
    }

    public void OnMenu()
    {
        StartCoroutine(Menu());
    }

    private IEnumerator Menu()
    {
        yield return SceneManager.LoadSceneAsync("menu", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
