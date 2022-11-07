using System.Globalization;

var clock = new AnalogueClock();

// Execution Flow
clock.AskUserForInput();
var result = clock.CalculateLesserAngle();
AnalogueClock.PrintResult(result);
clock.Repeat();

public class AnalogueClock
{
    // Anti-Magic Number Pattern;
    private const int ClockDegrees = 360;

    private const float HourDegrees = 30; // -> 360(ClockDegrees) / 12(TotalHours)
    private const float MinuteDegrees = 6; // -> 360(ClockDegrees) / 60(MinutesInHour) 
    private const double HourHandMovementByMinute = 0.5; // -> 30(HourDegrees) / 60(MinutesInHour)

    private float ClientHour { get; set; }
    private float ClientMinute { get; set; }

    private void AssignValues(float hour, float minute)
    {
        ClientHour = hour;
        ClientMinute = minute;
    }

    public void AskUserForInput()
    {
        var userHour = HandleUserInput("Enter the desired hour: ", ValidateHourInput);
        var userMinute = HandleUserInput("Enter the desired minute: ", ValidateMinuteInput);

        AssignValues(userHour,userMinute);
    }

    private static float HandleUserInput(string message, Func<float, bool> func)
    {
        bool inputIsValid = false;
        float input = 0;

        while (inputIsValid is false)
        {
            Console.Write("{0}", message);
            bool inputIsNumerical = float.TryParse(Console.ReadLine(), out input);

            switch (inputIsNumerical)
            {
                case false:
                    Console.WriteLine("Only numerical values are allowed.");
                    break;
                case true:
                {
                    bool validateNumber = func.Invoke(input);

                    if (validateNumber)
                    {
                        inputIsValid = true;
                    }

                    break;
                }
            }
        }
        return input;
    }

    private static bool ValidateHourInput(float number)
    {
        if (number is < 0 or > 12)
        {
            Console.WriteLine("The hour number must be between 0 and 12.");
            return false;
        }

        return true;
    }

    private static bool ValidateMinuteInput(float number)
    {
        if (number is < 0 or > 60)
        {
            Console.WriteLine("The minute number must be between 0 and 60.");
            return false;
        }

        return true;
    }

    public double CalculateLesserAngle()
    {
        // FORMULA -> 30° x number of hours + 0.5° x number of minutes;
        var hourAngle = HourDegrees * ClientHour + HourHandMovementByMinute * ClientMinute;

        // FORMULA -> 6° x number of minutes;
        var minuteAngle = MinuteDegrees * ClientMinute;

        var angle = Math.Abs(hourAngle - minuteAngle);

        // Get the lesser angle
        if (angle > 180)
        {
            angle = ClockDegrees - angle;
        }

        return angle;
    }

    public void Repeat()
    {
        Console.WriteLine("Do you want to try another values? Type in \"Y\" to calculate different values or \"N\" to stop.");
        var answer = Console.ReadLine();
        
        if (answer?.ToLower() == "y")
        {
            AskUserForInput();
            PrintResult(CalculateLesserAngle());
            Repeat();
        }
    }

    public static void PrintResult(double result)
    {
        Console.WriteLine("The lesser angle between two hands is {0} degrees", result.ToString(CultureInfo.InvariantCulture));
        Console.WriteLine();
    }
}
