using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
           // TextTool.stringDecoder("AWUBWUBWUBBWUBWUBWUBC");
            string dr = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010\n"
+ "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n :+1-321-512-2222 <Paul Dive> Sequoia Alley PQ-67209\n"
+ "+1-741-984-3090 <Peter Reedgrave> _Chicago\n :+1-921-333-2222 <Anna Stevens> Haramburu_Street AA-67209\n"
+ "+1-111-544-8973 <Peter Pan> LA\n +1-921-512-2222 <Wilfrid Stevens> Wild Street AA-67209\n"
+ "<Peter Gone> LA ?+1-121-544-8974 \n <R Steell> Quora Street AB-47209 +1-481-512-2222\n"
+ "<Arthur Clarke> San Antonio $+1-121-504-8974 TT-45120\n <Ray Chandler> Teliman Pk. !+1-681-512-2222! AB-47209,\n"
+ "<Sophia Loren> +1-421-674-8974 Bern TP-46017\n <Peter O'Brien> High Street +1-908-512-2222; CC-47209\n"
+ "<Anastasia> +48-421-674-8974 Via Quirinal Roma\n <P Salinger> Main Street, +1-098-512-2222, Denver\n"
+ "<C Powel> *+19-421-674-8974 Chateau des Fosses Strasbourg F-68000\n <Bernard Deltheil> +1-498-512-2222; Mount Av.Eldorado\n"
+ "+1-099-500-8000 <Peter Crush> Labrador Bd.\n +1-931-512-4855 <William Saurin> Bison Street CQ-23071\n"
+ "<P Salinge> Main Street, +1-098-512-2222, Denve\n";
        // output   o = TextTool.phone(dr, "1-498-512-2222");
            Console.WriteLine("Hello World!");
        }



    }


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
            string[] xx = value.Split("WUB");
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < xx.Length; i++)
            {
                if (xx[i] == "")
                    continue;
                stringBuilder.Append(xx[i] + " ");

            }
            return stringBuilder.ToString().Trim();
        }

        public static output phone(string phonebook, string phone)
        {
            output o = new output();
            o.Phone = phone;
            if (phone[0] != '+')
                phone = "+" + phone;
            
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
                o.Error = "Not Found "+o.Phone;
                return o;
            }
            if (count > 1)
            {
                o.Error = "Too many people " + o.Phone; ;
                return o;
            }
            var result1 = Regex.Match(listxx[index], "<.*>");
            if (!result1.Success)
            {
                o.Error = "Format Name Not correct format";
                return o;
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
