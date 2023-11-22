using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kategorier : MonoBehaviour
{
    static void Main()
    {
        // Opret en liste i en liste
        List<List<string>> listOfLists = new List<List<string>>();

        // Tilføj kategorierne med tal fra 1 til 15 til hver
        listOfLists.Add(GenerateList("Nævn øer i Danmark"));
        listOfLists.Add(GenerateList("Hajarter"));
        listOfLists.Add(GenerateList("Kortspil"));
        listOfLists.Add(GenerateList("Nobelfredspris vindere"));
        listOfLists.Add(GenerateList("Wimbledon vindere"));
        listOfLists.Add(GenerateList("VM i fodbold vindere"));
        listOfLists.Add(GenerateList("Lande i kontinentet Asien"));
        listOfLists.Add(GenerateList("Karakterer i Harry Potter"));
        listOfLists.Add(GenerateList("Superhelte fra Marvel"));
        listOfLists.Add(GenerateList("Sportsgrene der indgår boldspil"));
        listOfLists.Add(GenerateList("Kræfttyper"));
        listOfLists.Add(GenerateList("Haribo slikvarianter"));
        listOfLists.Add(GenerateList("Mandlige oscarvindere"));
        listOfLists.Add(GenerateList("Superhelte fra DC"));
        listOfLists.Add(GenerateList("Karakterer fra Batman universet"));
        listOfLists.Add(GenerateList("Frugter / bær med ordet bær i"));
        listOfLists.Add(GenerateList("Danske landsholdspillere i fodbold de sidste 5 år"));
        listOfLists.Add(GenerateList("Rasmus Seebach sange"));
        listOfLists.Add(GenerateList("Officielle sprog i Europa"));
        listOfLists.Add(GenerateList("Danske kommuner der begynder med R"));


        // Udskriv indholdet af listen i en liste
        PrintListOfLists(listOfLists);
    }

    static List<string> GenerateList(string category)
    {
        List<string> subList = new List<string>();
        for (int i = 1; i <= 15; i++)
        {
            subList.Add($"{category}: {i}");
        }
        return subList;
    }

    static void PrintListOfLists(List<List<string>> listOfLists)
    {
        foreach (var innerList in listOfLists)
        {
            foreach (var item in innerList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}

