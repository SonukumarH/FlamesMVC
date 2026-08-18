
namespace FlamesMvc.Services;

public class FlamesService
{
    public string Calculate(string yourName, string partnerName)
    {
        int number = FlamesNumber(yourName, partnerName);

        number %= 6;

        if (number == 0)
        {
            number = 6;
        }

        char letter = "FLAMES"[number - 1];

        return FlamesResult(letter);
    }

    private int FlamesNumber(string yourName, string partnerName)
    {
        string yourNameWithOutSpace =
            yourName.Replace(" ", string.Empty);

        string partnerNameWithOutSpace =
            partnerName.Replace(" ", string.Empty);

        List<char> yourNameList =
            yourNameWithOutSpace.ToList();

        List<char> partnerNameList =
            partnerNameWithOutSpace.ToList();

        for (int i = 0; i < yourNameList.Count; i++)
        {
            for (int j = 0; j < partnerNameList.Count; j++)
            {
                if (yourNameList[i] == partnerNameList[j])
                {
                    yourNameList.RemoveAt(i);
                    partnerNameList.RemoveAt(j);

                    i--;

                    break;
                }
            }
        }

        return yourNameList.Count + partnerNameList.Count;
    }

    private string FlamesResult(char letter)
    {
        return letter switch
        {
            'F' => "Friends",
            'L' => "Love",
            'A' => "Affection",
            'M' => "Marriage",
            'E' => "Enemy",
            'S' => "Sister",
            _ => "No answer"
        };
    }
}
