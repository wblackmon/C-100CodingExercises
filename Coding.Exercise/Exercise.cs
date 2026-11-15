using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Coding.Exercises;

public class Exercise
{
    public static List<string> GetQualifiedPlayers(
        Dictionary<string, int> playerScores)
    {
        //your code goes here
        List<string> qualifiedPlayers = new List<string>();
        foreach (var item in playerScores)
        {
            if (item.Value >= 100)
            {
                break;
            }

            if (item.Value >= 50)
            {
                qualifiedPlayers.Add(item.Key);
            }

        }
        return qualifiedPlayers;
    }

    public static List<string> GetQualifiedPlayersLinq(
    Dictionary<string, int> playerScores)
    {
        //your code goes here
        List<string> qualifiedPlayers = new List<string>();

        qualifiedPlayers = playerScores.TakeWhile(s => s.Value < 100)
            .Where(s => s.Value >= 50)
            .Select(s => s.Key).ToList();

        return qualifiedPlayers;
    }

    public static TimeSpan CalculateTotalBreakTime(
        List<(DateTime Start, DateTime End)> breaks)
    {
        //your code goes here
        TimeSpan breakTime = TimeSpan.Zero;

        foreach (var item in breaks)
        {
            var itemTime = item.End - item.Start;
            breakTime += itemTime;
        }
        return breakTime;
    }

    public static TimeSpan CalculateTotalBreakTimeLINQ(
            List<(DateTime Start, DateTime End)> breaks)
    {
        //your code goes here
        TimeSpan breakTime = TimeSpan.Zero;

        breakTime = TimeSpan.FromTicks(breaks.Sum(t => (t.End - t.Start).Ticks));
        return breakTime;
    }

    public static void UpdateHighestScore(
        Player? player, int newScore)
    {
        if (player is null || player.Statistics is null)
        {
            return;
        }

        if (player.Statistics.HighestScore is null)
        {
            player.Statistics ??= new Statistics();
            player.Statistics.HighestScore = newScore;
            return;
        }
        //your code goes here
        if (player.Statistics.HighestScore < newScore)
        {
            player.Statistics.HighestScore = newScore;
            return;
        }
    }

    public static decimal CalculateShippingCost(
        decimal orderTotal,
        bool isPremiumCustomer)
    {
        //your code goes here
        return orderTotal switch
        {
            < 50 when !isPremiumCustomer => 10,
            < 50 when isPremiumCustomer => 5,
            >= 50 when !isPremiumCustomer => 5,
            >= 50 when isPremiumCustomer => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(orderTotal))
        };
    }

    public static bool TryExtractDateComponents(
    string dateInput,
    out int year,
    out int month,
    out int day)
    {
        //your code goes here
        DateTime date;
        bool isParsed = DateTime.TryParse(dateInput, CultureInfo.InvariantCulture, out date);

        year = date.Year;
        month = date.Month;
        day = date.Day;

        if (!isParsed)
        {
            year = 0;
            month = 0;
            day = 0;
            return false;
        }

        return isParsed;
    }

    public static bool IsPalindrome(string input)
    {
        //your code goes here
        int left = 0;
        int right = input.Length - 1;

        while (left < right)
        {
            if (input[left] != input[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

}

public class Player
{
    public Statistics? Statistics { get; set; }
}

public class Statistics
{
    public int? HighestScore { get; set; }
}
