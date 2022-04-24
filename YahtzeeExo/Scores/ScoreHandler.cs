namespace TestProjectYahtzee;

public class ScoreHandler
{

    public Dictionary<ScoresEnum, int> HandleDicesForScore(List<Dice> dices)
    {
        Dictionary<ScoresEnum, int> dataScore = new Dictionary<ScoresEnum, int>();

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

    private Dictionary<ScoresEnum, int> Handler1(List<Dice> dices)
    {
        Dictionary<ScoresEnum,int> dataScore = new Dictionary<ScoresEnum,int>();

        var data = dices.GroupBy(x => x.DiceValue).ToList();
        foreach (var diceData in data)
        {
            var scoreName = GetScoresBase(diceData.Key);
            if (scoreName != null)
            {
               var name = (ScoresEnum)scoreName;
               dataScore.Add(name, diceData.Sum(x => x.DiceValue));
            }
            
        }
        return dataScore;
    }

    private Dictionary<ScoresEnum, int> Handler2(List<Dice> dices)
    {
        Dictionary<ScoresEnum, int> dataScore = new Dictionary<ScoresEnum, int>();

        var data = dices.GroupBy(x => x.DiceValue).ToList();

        if(data.Any(x=>x.Count()==3))
        {
            dataScore.Add(ScoresEnum.ThreeOfAKind,dices.Sum(x=>x.DiceValue));
        }
        if (data.Any(x => x.Count() == 4))
        {
            dataScore.Add(ScoresEnum.FourOfAKind, dices.Sum(x => x.DiceValue));
        }
        if (data.Count==2 && data.All(x=>x.Count()>1))
        {
            dataScore.Add(ScoresEnum.FullHouse, 25);
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
            dataScore.Add(ScoresEnum.SmallStraight,30);
        }

        if (sequentialTest.Count == 5)
        {
            dataScore.Add(ScoresEnum.LargeStraight,40);
        }

        if (dices.Select(x=>x.DiceValue).Distinct().Count() == 1)
        {
            dataScore.Add(ScoresEnum.Yathzee,50);
        }

        dataScore.Add(ScoresEnum.Chance,dices.Sum(x=>x.DiceValue));
        

        return dataScore;
    }


    private ScoresEnum? GetScoresBase(int i)
    {
        switch (i)
        {
            case 1:
                return ScoresEnum.Ones;
            case 2:
                return ScoresEnum.Twos;
            case 3:
                return ScoresEnum.Threes;
            case 4:
                return ScoresEnum.Fours;
            case 5:
                return ScoresEnum.Fives;
            case 6:
                return ScoresEnum.Sixes;
            default:
                return null;
        }

       
    }
}