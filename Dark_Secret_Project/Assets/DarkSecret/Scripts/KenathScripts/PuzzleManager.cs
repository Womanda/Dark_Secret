using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    //Amount of tasks required for the user to complete the puzzle.

    [SerializeField] private int numberOfTasksToComplete;
    private int CurrentlyCompletedTasks = 0;

    [Header("Completion Events")]
    public UnityEvent onPuzzleCompletion;
}
