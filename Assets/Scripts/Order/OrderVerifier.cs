using UnityEngine;

public class OrderVerifier : MonoBehaviour
{
    public static OrderVerifier Instance { get; private set; }
    [SerializeField] private int missingIngredientPenalty;
    [SerializeField] private int wrongToppingPenalty;
    [SerializeField] private int wrongSaucePenalty;

    private void Awake()
    {
        Instance = this;
    }

    public int Verify(PizzaOrder preparedOrder, PizzaOrder customerOrder)
    {
        int score = 100;
        
        if (preparedOrder.Sauce != customerOrder.Sauce) score -= wrongSaucePenalty;

        foreach (string requestedTopping in customerOrder.Ingredients)
        {
            if (!preparedOrder.Ingredients.Contains(requestedTopping)) score -= missingIngredientPenalty;
        }

        foreach (string addedTopping in preparedOrder.Ingredients)
        {
            if (!customerOrder.Ingredients.Contains(addedTopping)) score -= wrongToppingPenalty;
        }

        return score;
    }
}
