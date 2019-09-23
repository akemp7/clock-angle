using System;

class Program
{
  static void Main()
  {
    Console.WriteLine("Enter a time (HH:MM)");
    string userTime = Console.ReadLine();
    Time time = new Time();
    int index = userTime.IndexOf(":");
    string hourString = userTime.Substring(0, index);
    string minuteString = userTime.Substring(index + 1);
    try {
        int hour = int.Parse(hourString);
        int minute = int.Parse(minuteString);
        double degree = time.Angle(hour, minute);
        if(degree > 180){
            degree = degree - 180;
        }
        Console.WriteLine("The time angle in degrees is " + degree.ToString());
        Console.WriteLine("The time angle in radians is " + time.Radian(degree).ToString());
    } catch (FormatException){
        Console.WriteLine("Incorrect Formatting. Ending Now.");
    }
  }
}


class Time{

    private double FindDegree(int value, int maxValue){
        return (Convert.ToDouble(value)/Convert.ToDouble(maxValue))*360.0;
    }
    public double Angle(int hour, int minute){
      double hourDegree = this.FindDegree(hour,12);
      double minuteDegree = this.FindDegree(minute,60);
      hourDegree = hourDegree % 360;
      if(hourDegree > minuteDegree){
        return hourDegree - minuteDegree;
      } else {
        return  minuteDegree - hourDegree;
      }
    }
    public double Radian(double degree){
        double radian = degree/180 * Math.PI;
        return radian;
    }
}