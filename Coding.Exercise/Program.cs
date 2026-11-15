using Coding.Exercises;
using EnumerablePrinter.Extensions;

Console.WriteLine("Hello, CSharp Coders!");

var players = new Dictionary<string, int>
{
    { "Anna", 45 },
    { "Ben", 80 },
    { "Uki", 70 },
    { "Cara", 100 }, //cheating score - we should stop right there
    { "Derek", 90 },
    { "Ella", 70 }
};

var qualifiedPlayers = Exercise.GetQualifiedPlayers(players);
qualifiedPlayers.Print();

var qulifiedPlayersLinq = Exercise.GetQualifiedPlayersLinq(players);
qulifiedPlayersLinq.Print();

// Benchmark
MethodBenchmark.Run(
    "foreach",
    () => Exercise.GetQualifiedPlayers(players));

MethodBenchmark.Run(
    "LINQ",
    () => Exercise.GetQualifiedPlayersLinq(players));

var breaks = new List<(DateTime, DateTime)>
{
    (new DateTime(2023, 4, 1, 9, 0, 0), new DateTime(2023, 4, 1, 9, 15, 0)),
    (new DateTime(2023, 4, 1, 12, 30, 0), new DateTime(2023, 4, 1, 13, 0, 0)),
    (new DateTime(2023, 4, 1, 15, 45, 0), new DateTime(2023, 4, 1, 16, 0, 0))
};

var breakTime = Exercise.CalculateTotalBreakTime(breaks);
breakTime.Print();

var breakTimeLINQ = Exercise.CalculateTotalBreakTimeLINQ(breaks);
breakTimeLINQ.Print();

// Benchmark
MethodBenchmark.Run(
    "foreach",
    () => Exercise.CalculateTotalBreakTime(breaks));

MethodBenchmark.Run(
    "LINQ",
    () => Exercise.CalculateTotalBreakTimeLINQ(breaks));

var player = new Player
{
    Statistics = new Statistics { HighestScore = null }
};

Exercise.UpdateHighestScore(player, 100);
// player.Statistics.HighestScore is now 100

Exercise.UpdateHighestScore(player, 90);
// score is lower than current — no change

Exercise.UpdateHighestScore(player, 150);
// score is higher — should update
// player.Statistics.HighestScore is now 150

var result = Exercise.CalculateShippingCost(30, false); // => 10
result.Print();

result = Exercise.CalculateShippingCost(30, true);  // => 5
result.Print();

result = Exercise.CalculateShippingCost(60, false); // => 5
result.Print();

result = Exercise.CalculateShippingCost(60, true);  // => 0
result.Print();

bool boolResult = Exercise.TryExtractDateComponents(
    dateInput: "2024-12-15",
    year: out var y,
    month: out var m,
    day: out var d
);
y.Print();
m.Print();
d.Print();
// result == true, y == 2024, m == 12, d == 15

boolResult = Exercise.TryExtractDateComponents(
    dateInput: "not-a-date",
    year: out y,
    month: out m,
    day: out d
);
y.Print();
m.Print();
d.Print();
// result == false, y/m/d == 0

string[] inputs = { "radar", "hello", "racecar", "madam" };

foreach (string input in inputs)
{
    bool isPalindrome = Exercise.IsPalindrome(input);
    string printPalindrome = PalindromeResult(isPalindrome, input);
    printPalindrome.Print();
}
// => false (space)

string PalindromeResult(bool isPalindrome, string input)
{
    return $"{input}: {isPalindrome}\n";
}

