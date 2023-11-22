using UnityEngine;
using Photon.Pun;

public class PointSystem : MonoBehaviourPunCallbacks
{
    private int currentPoints = 0;
    private int maxPointsPerQuestion = 100;
    private int questionsAnswered = 0;

    // Metode til at håndtere, når et spørgsmål besvares korrekt
    public void AnswerCorrect()
    {
        if (photonView.IsMine)
        {
            // Tilføj point for det aktuelle spørgsmål
            int pointsToAdd = Random.Range(1, maxPointsPerQuestion + 1);
            currentPoints += pointsToAdd;

            Debug.Log("Correct! +" + pointsToAdd + " points. Total points: " + currentPoints);

            // Øg antallet af besvarede spørgsmål
            questionsAnswered++;

            // Håndter noget, når to spørgsmål er besvaret (kan tilpasses)
            if (questionsAnswered == 2)
            {
                Debug.Log("Two questions answered! Do something...");

                // Nulstil tælleren for besvarede spørgsmål
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

