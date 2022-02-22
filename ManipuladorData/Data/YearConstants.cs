namespace ManipuladorData.Data;

public static class YearConstants
{
    public static readonly int[] DaysInMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public static bool IsLeapYear(int year) =>  year % 400 == 0 || year % 100 != 0 && year % 4 == 0;
}