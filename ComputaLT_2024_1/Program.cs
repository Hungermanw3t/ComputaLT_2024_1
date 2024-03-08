using System.Globalization;

namespace ComputaLT_2024_1
{
    internal class Signs
    {
        internal static string starSign(int day, string month)
        {
            string astro_sign = "";

            // checks month and date within the  
            // valid range of a specified zodiac 
            if (month == "december")
            {

                if (day < 22)
                    astro_sign = "Sagittarius";
                else
                    astro_sign = "capricorn";
            }

            else if (month == "january")
            {
                if (day < 20)
                    astro_sign = "Capricorn";
                else
                    astro_sign = "aquarius";
            }

            else if (month == "february")
            {
                if (day < 19)
                    astro_sign = "Aquarius";
                else
                    astro_sign = "pisces";
            }

            else if (month == "march")
            {
                if (day < 21)
                    astro_sign = "Pisces";
                else
                    astro_sign = "aries";
            }

            else if (month == "april")
            {
                if (day < 20)
                    astro_sign = "Aries";
                else
                    astro_sign = "taurus";
            }

            else if (month == "may")
            {
                if (day < 21)
                    astro_sign = "Taurus";
                else
                    astro_sign = "gemini";
            }

            else if (month == "june")
            {
                if (day < 21)
                    astro_sign = "Gemini";
                else
                    astro_sign = "cancer";
            }

            else if (month == "july")
            {
                if (day < 23)
                    astro_sign = "Cancer";
                else
                    astro_sign = "leo";
            }

            else if (month == "august")
            {
                if (day < 23)
                    astro_sign = "Leo";
                else
                    astro_sign = "virgo";
            }

            else if (month == "september")
            {
                if (day < 23)
                    astro_sign = "Virgo";
                else
                    astro_sign = "libra";
            }

            else if (month == "october")
            {
                if (day < 23)
                    astro_sign = "Libra";
                else
                    astro_sign = "scorpio";
            }

            else if (month == "november")
            {
                if (day < 22)
                    astro_sign = "scorpio";
                else
                    astro_sign = "sagittarius";
            }

            return astro_sign;
        }

        internal static string ChineseZodiac(System.DateTime date)
        {
            EastAsianLunisolarCalendar cc = new ChineseLunisolarCalendar();
            int sexagenaryYear = cc.GetSexagenaryYear(date);
            int terrestrialBranch = cc.GetTerrestrialBranch(sexagenaryYear);

            string[] years = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            return years[terrestrialBranch - 1];
        }
    }

    internal class Program
    {
        #region(methods)
        static string UsrInptString(string Prompt)
        {
            string? usrOtPt;
            while (true)
            {
                Console.WriteLine(Prompt);
                usrOtPt = Console.ReadLine();

                if (usrOtPt != null && usrOtPt.Length != 0) { break; }
                Console.Clear();
            }
            Console.Clear();
            return usrOtPt;
        }

        static double UsrInptInt(string Prompt)
        {
            double usrOtPt;
            while (true)
            {
                Console.WriteLine(Prompt);
                usrOtPt = Convert.ToDouble(Console.ReadLine());
                if (usrOtPt != 0) { break; }
                Console.Clear();
            }
            Console.Clear();
            return usrOtPt;
        }

        struct Group
        {
            internal static string? name;
            internal static string? heightFeet;
            internal static string? heightInches;
            internal static string? age;
            internal static string? ageDog;
            internal static string? starsign;
            internal static string? season = "";
            internal static string? chineseZodiac;
            internal static string? outStr;
        }

        private static void Name()
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string[] userName = UsrInptString("Your Name [First Last]").Split(" ");
            string[] celebName = UsrInptString("Your celebrity crushes name [First Last]").Split(" ");
            userName[1] = celebName[1];
            string newName = $"{userName[0]} {userName[1]}";

            Group.name = textInfo.ToTitleCase(newName);
        }

        private static void Height()
        {
            double usrHgt = UsrInptInt("Your height in cm: ");
            int inchesPerFoot = 12;
            double inches = usrHgt / 2.54;
            double feet = Math.Floor(inches / inchesPerFoot);
            inches -= (feet * 12);

            Group.heightFeet = Convert.ToString(feet);
            Group.heightInches = Convert.ToString(Math.Round(inches));
        }

        private static void BirthdateStuff()
        {
            DateTime dateTime = DateTime.Now;
            DateTime birthday = DateTime.Parse(UsrInptString("Your Birthday [D/M/Year]: "));

            //getting user age and converting it into dog years
            Group.age = Convert.ToString(dateTime.Year - birthday.Year);
            double DogYrs = 0;
            for (int i = 1; i <= Convert.ToInt32(Group.age); i++) { if (i <= 2) { DogYrs += 10.5; } else { DogYrs += 4; } }
            Group.ageDog = Convert.ToString(DogYrs);


            //get starsign
            Group.starsign = Signs.starSign(birthday.Day, birthday.ToString("MMMM"));
            //get chinese zodiac
            Group.chineseZodiac = Signs.ChineseZodiac(birthday);

            //getting season
            if (1 <= birthday.Month || birthday.Month <= 2 || birthday.Month == 12) { Group.season = "summer"; }
            else if (3 <= birthday.Month && birthday.Month <= 5) { Group.season = "autmn"; }
            else if (6 <= birthday.Month && birthday.Month <= 8) { Group.season = "winter"; }
            else if (9 <= birthday.Month && birthday.Month <= 11) { Group.season = "spring"; }
        }

        private static void StringConstructor()
        {
            Group.outStr = $"Hello, My new name is {Group.name}.\n" +
                $"I am {Group.heightFeet}'{Group.heightInches}\".\n" +
                $"My age in human years is {Group.age}, but in dog years I would be {Group.ageDog}.\n" +
                $"I was born during {Group.season}.\n" +
                $"My Chinese Zodiac is {Group.chineseZodiac} and my starsign is {Group.starsign}";
        }
        #endregion


        static void Main(string[] args)
        {
            Name();
            Height();
            BirthdateStuff();

            StringConstructor();

            Console.WriteLine(Group.outStr);
        }
    }
}