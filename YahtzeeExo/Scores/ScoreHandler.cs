namespace TestProjectYahtzee;

public class ScoreHandler
{

    public Dictionary<Scores, int> HandleDicesForScore(List<Dice> dices)
    {
        Dictionary<Scores, int> dataScore = new Dictionary<Scores, int>();

        var data1 = Handler1(dices);

        foreach (var keyValuePair in data1)
        {
            dataScore.Add(keyValuePair.Key,keyValuePair.Value);
        }

        var data2 = Handler2(dices);

        foreach (var keyValuePair in data2)
        {
            dataScore.Add(keyValuePair.Key, keyValuePair.Value);
        }

        return dataScore;
    }

    private Dictionary<Scores, int> Handler1(List<Dice> dices)
    {
        Dictionary<Scores,int> dataScore = new Dictionary<Scores,int>();

        var data = dices.GroupBy(x => x.DiceValue).ToList();
        foreach (var diceData in data)
        {
            var scoreName = GetScoresBase(diceData.Key);
            if (scoreName != null)
            {
               var name = (Scores)scoreName;
               dataScore.Add(name, diceData.Sum(x => x.DiceValue));
            }
            
        }
        return dataScore;
    }

    private Dictionary<Scores, int> Handler2(List<Dice> dices)
    {
        Dictionary<Scores, int> dataScore = new Dictionary<Scores, int>();

        var data = dices.GroupBy(x => x.DiceValue).ToList();

        if(data.Any(x=>x.Count()==3))
        {
            dataScore.Add(Scores.ThreeOfAKind,dices.Sum(x=>x.DiceValue));
        }
        if (data.Any(x => x.Count() == 4))
        {
            dataScore.Add(Scores.FourOfAKind, dices.Sum(x => x.DiceValue));
        }
        if (data.Count==2 && data.All(x=>x.Count()>1))
        {
            dataScore.Add(Scores.FullHouse, 25);
        }

        var orderedData = dices.OrderBy(x => x.DiceValue).ToList();

        var sequentialTest = orderedData.TakeWhile((x, i) =>
        {
            if (i == 0)
            {
                return true;
            }
            else
            {
                if (x.DiceValue != (orderedData[i - 1].DiceValue+1))
                {
                    return false;
                }

                return true;
            }
        }).ToList();

        if (sequentialTest.Count == 4)
        {
            dataScore.Add(Scores.SmallStraight,30);
        }

        if (sequentialTest.Count == 5)
        {
            dataScore.Add(Scores.LargeStraight,40);
        }

        if (dices.Select(x=>x.DiceValue).Distinct().Count() == 1)
        {
            dataScore.Add(Scores.Yathzee,50);
        }


        

        return dataScore;
    }


    private Scores? GetScoresBase(int i)
    {
        switch (i)
        {
            case 1:
                return Scores.Ones;
            case 2:
                return Scores.Twos;
            case 3:
                return Scores.Threes;
            case 4:
                return Scores.Fours;
            case 5:
                return Scores.Fives;
            case 6:
                return Scores.Sixes;
            default:
                return null;
        }

       
    }
}