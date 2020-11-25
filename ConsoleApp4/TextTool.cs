using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    public class output
    {
        public string Name;
        public string Phone;
        public string Address;
        public string Error;
    }

    public static class TextTool
    {

        public static String stringDecoder(string value)
        {
            string []xx = value.Split("WUB"); 
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < xx.Length; i++)
            {  if (xx[i] == "")
                    continue;
                stringBuilder.Append(xx[i]+" ");
        
            }
            return stringBuilder.ToString().Trim(); 
        }
       
        public static output phone(string phonebook, string phone)
        {

            if (phone[0] != '+')
                phone = "+" + phone;
            output o = new output();
            o.Phone = phone;
            string[] listxx = phonebook.Split("\n");
            int count = 0;
            int index = 0;
            string name = "";
            string address = "";
            string find = phone;
            for (int i = 0; i < listxx.Length; i++)
            {
                int key = listxx[i].IndexOf(find);
                if (key != -1)
                {
                    index = i;
                    count++;
                }
            }

            if (count == 0)
            {
                o.Error = "Not Found";
                return o;
            }
            if (count > 1)
            {
                o.Error = "Too many people";
                return o;
            }
            var result1 = Regex.Match(listxx[index], "<.*>");
            if (!result1.Success)
            {
                o.Error = "Format Name Not correct format";
            }
            o.Name = result1.Value.Replace("<", "").Replace(">", "").Trim(); ;
            o.Address = RemoveSpecialCharacters(listxx[index].Replace(result1.Value, "").Replace(find, "")).Trim();
            return o;
        }

        private static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_' || c == ' ' || c == '-' || c == '.')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
