using UnityEngine;
using Photon.Pun;

public class PointSystem : MonoBehaviourPunCallbacks
{
    private int currentPoints = 0;
    private int maxPointsPerQuestion = 100;
    private int questionsAnswered = 0;

    // Metode til at h�ndtere, n�r et sp�rgsm�l besvares korrekt
    public void AnswerCorrect()
    {
        if (photonView.IsMine)
        {
            // Tilf�j point for det aktuelle sp�rgsm�l
            int pointsToAdd = Random.Range(1, maxPointsPerQuestion + 1);
            currentPoints += pointsToAdd;

            Debug.Log("Correct! +" + pointsToAdd + " points. Total points: " + currentPoints);

            // �g antallet af besvarede sp�rgsm�l
            questionsAnswered++;

            // H�ndter noget, n�r to sp�rgsm�l er besvaret (kan tilpasses)
            if (questionsAnswered == 2)
            {
                Debug.Log("Two questions answered! Do something...");

                // Nulstil t�lleren for besvarede sp�rgsm�l
                questionsAnswered = 0;
            }
        }
    }

    // Metode til at nulstille point
    public void ResetPoints()
    {
        if (photonView.IsMine)
        {
            currentPoints = 0;
            questionsAnswered = 0;
            Debug.Log("Points reset to 0.");
        }
    }
}

