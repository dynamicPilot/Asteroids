using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LaserRecoveryUI : MonoBehaviour
{
    [SerializeField] private Text bar;

    private string barFull = "| - - - |";
    private string[] progressIndexes= new string[3] { "|       |", "| -     |", "| - -   |" };

    private bool isBusy = false;
    private bool isFull = true;
    public bool IsFull { get => isFull; }

    private WaitForSeconds timer;
    public void SetBar()
    {
        bar.text = barFull;
        isBusy = false;
        timer = new WaitForSeconds(0.5f);
    }

    public void UpdateBar(float progress)
    {
        if (isBusy) return;

        int index = (Mathf.FloorToInt(progress * 100f) / 10) / 3;

        if (index < progressIndexes.Length)
        {
            bar.text = progressIndexes[index];
            isFull = false;
        }
        else
        {
            isFull = true;
            StartCoroutine(BarIsFull());
        }
    }

    IEnumerator BarIsFull()
    {
        isBusy = true;
        bar.text = barFull;
        yield return timer;
        bar.text = barFull.Substring(0, barFull.Length - 2) + " ";
        yield return timer;
        bar.text = barFull;        
        isBusy = false;
    }
}
