using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    public Text dateText;

    public Dictionary<int, int> date = new Dictionary<int, int>()
    {
        { 1, 31 },
        { 2, 28 },
        { 3, 31 },
        { 4, 30 },
        { 5, 31 },
        { 6, 30 },
        { 7, 31 },
        { 8, 31 },
        { 9, 30 },
        { 10, 31 },
        { 11, 30 },
        { 12, 31 }
    };
    public Dictionary<int, string> months = new Dictionary<int, string>()
    {
        { 1, "January" },
        { 2, "February" },
        { 3, "March" },
        { 4, "April" },
        { 5, "May" },
        { 6, "June" },
        { 7, "July" },
        { 8, "August" },
        { 9, "September" },
        { 10, "October" },
        { 11, "November" },
        { 12, "December" },
    };

    public (int Month, int Day, int Year) currentDate = (4, 16, 2022);
    public (int, int, int) TAX_DAY = (4, 15, 2023);

    // Start is called before the first frame update
    void Start()
    {
        dateText = GetComponent<Text>();

        InvokeRepeating("NextDay", 0.658f, 0.658f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextDay()
    {
        if (currentDate.Day + 1 > date[currentDate.Month])
        {
            if (currentDate.Month + 1 > date.Count)
            {
                currentDate.Month = 1;
                currentDate.Year++;
            }
            else
            { 
                currentDate.Month++;
            }
            currentDate.Day = 1;
        }
        else
        {
            currentDate.Day++;
        }

        if (currentDate == TAX_DAY)
        {
            Debug.Log("Tax Day!");

            GameEvents.instance.TaxDay();
            CancelInvoke();
        }

        dateText.text = string.Format("{0} {1}, {2}", months[currentDate.Month], currentDate.Day, currentDate.Year);
        Debug.Log(currentDate);
    }
}
