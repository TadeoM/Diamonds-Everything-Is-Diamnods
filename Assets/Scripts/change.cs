using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change : MonoBehaviour
{
    public void Map1()
    {
        SceneManager.LoadScene("main");
        Data.map = "map01.txt";
    }
    public void Map2()
    {
        SceneManager.LoadScene("main");
        Data.map = "map02.txt";
    }
    public void Map3()
    {
        SceneManager.LoadScene("main");
        Data.map = "map03.txt";
    }
    public void Map4()
    {
        SceneManager.LoadScene("main");
        Data.map = "map04.txt";
    }

}
