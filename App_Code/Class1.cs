using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    public static string GetRandomPassword(int length)
    {
        char[] chars = "abcdefghijklmnoprstuvwzyz1234567890ABCDEFGHIJKLMNOPRSTUVWXYZ".ToCharArray();
        string password = string.Empty;
        Random random = new Random();

        for (int i=0; i< length; i++)
        {
            int x = random.Next(1, chars.Length);
            //unikanie tych samych znaków
            if (!password.Contains(chars.GetValue(x).ToString()))
                password += chars.GetValue(x);
            else
                i = i - 1;
        }
        return password;         
    }
}