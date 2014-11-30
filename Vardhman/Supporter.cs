using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
namespace Vardhman
{
    static class Supporter
    {
        /// <summary>
        /// converts given string in to title case.
        /// this function converts first letter of each word in to capital letter and rest all in small letter
        /// </summary>
        /// <param name="input"></param>
        /// <returns><value><c>output</c>string in title case</value></returns>
        public static string title_case(string x)
        {
            CultureInfo info = new CultureInfo("en-US");
            return info.TextInfo.ToTitleCase(x.Trim());
        }
        /// <summary>
        /// shows an error message box
        /// contains an warning icon
        /// header contain error text
        /// body contains error message as given by user
        /// </summary>
        /// <param name="input"></param>
        public static void message_error(string x)
        {
            MessageBox.Show(x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }
        /// <summary>
        /// shows warning message box
        /// contains an warning icon
        /// header contain error text
        /// body contains warning message as given by user
        /// </summary>
        /// <param name="x"></param>
        public static void message_warning(string x)
        {
            MessageBox.Show(x, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// shows information message box
        /// contains an information icon
        /// header contain information text
        /// body contains informative message as given by user
        /// </summary>
        /// <param name="x"></param>
        public static void message_info(string x)
        {
            MessageBox.Show(x, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// shows critical messages
        /// contains an error icon
        /// header contain error text
        /// body contains critical error message as given by user
        /// </summary>
        /// <param name="x"></param>
        public static void message_critical(string x)
        {
            MessageBox.Show(x, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// returns null whenever given string is blank used for filling data in the backend
        /// -checks weather string is blank or not
        /// -if blank than returns NULL
        /// -return input otherwise
        /// -used for storing data in sql server database where null takes no space in contrast to blank which takes more space
        /// </summary>
        /// <param name="input"></param>
        /// <returns><value><c>output</c> NULL if string is blank , if not then input as it is</value></returns>
        public static string blank_to_null(string x)
        {
            if (x.Trim() == "" || x.Trim() == "null")
                return "NULL";
            return x.Trim();
        }
        /// <summary>
        /// returnd the start date of current financial year
        /// finantial year is different from normal english year in a way it starts and ends
        /// financial year starts at 1st april of every year and ends at 31st march of every year
        /// check current month if le 3 then year = previous year
        /// else year = current year
        /// date = 1/4/year
        /// </summary>
        /// <returns><value><c>Output</c> 1/4/year</value></returns>
        public static string financial_year_start_date()
        {
            string date = "01/04/";
            if (DateTime.Now.Month <= 3)
                date += DateTime.Now.Year - 1;
            else
                date += DateTime.Now.Year;
            return date;
        }
        /// <summary>
        /// returns the end date of current financial yearfinantial year is different from normal english year in a way it starts and ends
        /// financial year starts at 1st april of every year and ends at 31st march of every year
        /// check current month if le 3 then year = previous year
        /// else year = current year
        /// date = 31/3/year
        /// </summary>
        /// <returns><value><c>Output</c>31/3/year</value></returns>
        public static string financial_year_end_date()
        {
            string date = "31/03/";
            if (DateTime.Now.Month <= 3)
                date += DateTime.Now.Year;
            else
                date += DateTime.Now.Year+1;
            return date;
        }
        /// <summary>
        /// checks weather current key pressed results to numeric string or not if not then returns true , false otherwise
        /// this function is used to check that a textbox value along with current key press makes value at text box numeric or not
        /// this is helpfull in the sense that it dosenot allow any character which is not numeric
        /// moreever it also checks constraints like is user entering a specified numbet of digits and also is number of values after decimal is le 2 or not
        /// </summary>
        /// <param name="text"></param>
        /// <param name="event args"></param>
        /// <param name="cursorpos"></param>
        /// <returns><value><c>True</c>if text along with current character forms valid numeric
        /// <c>false</c>Otherwise</value></returns>
        public static bool isnot_numeric(string text, KeyPressEventArgs e , int cursorpos)
        {//true for wrong string ie handle = true , false for right string
            if(cursorpos == -1)
                cursorpos = text.Length;
            if (!((e.KeyChar >= 8 && e.KeyChar <= 12) || (e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.'))
                return true;
            string[] x = text.Split('.');
            if (x.Length >= 2 && e.KeyChar == '.')
                return true;
            if (x.Length == 2 && (cursorpos >x[0].Length))
                if (x[1].Length >= 2 && e.KeyChar>=48 && e.KeyChar <=57)
                    return true;
            if (x[0].Length == 12 && e.KeyChar >= 48 && e.KeyChar <= 57 && cursorpos <=12)
                return true;
            return false;
        }
        /// <summary>
        /// checks weather current key pressed results to integer string or not if not then returns true , false otherwise
        /// this function is used to check that a textbox value along with current key press makes value at text box integer or not
        /// this is helpfull in the sense that it dosenot allow any character which is not integer
        /// moreever it also checks constraints like is user entering a specified numbet of digits and also is number of values after decimal is le 2 or not
        /// </summary>
        /// <param name="text"></param>
        /// <param name="event args"></param>
        /// <param name="cursorpos"></param>
        /// <returns><value><c>True</c>if text along with current character forms valid integer
        /// <c>false</c>Otherwise</value></returns>
        public static bool isnot_integer(string text, KeyPressEventArgs e, int length)
        {
            if (!((e.KeyChar >= 8 && e.KeyChar <= 12) || (e.KeyChar >= 48 && e.KeyChar <= 57)))
                return true;
            if (text.Length == length && e.KeyChar >= 48 && e.KeyChar <= 57)
                return true;
            return false;
        }
        /// <summary>
        /// this procedures appends appropriote zeros to the given amount and rounds them
        /// -check if input string has 2 zeroc after the decimal or not if not then make them
        /// -if input >100 then round the input to get an integer value
        /// -if input le 100 then round input to nearest of 0 , 0.50 , 1
        /// </summary>
        /// <param name="number"></param>
        /// <param name="result"></param>
        /// <returns><value><c>Output</c> Rounded String</value></returns>
        public static bool set_two_digit_precision(string number, out string result)
        {
            result = "0.00";
            string[] delimiter = { "." };
            double f;
            number = number.Trim();
            if (!double.TryParse(number, out f))
                return false;
            string[] num = number.Split(delimiter, StringSplitOptions.None);
            
            if (num[0] == "")
                num[0] = "0";


            if (num.Length == 1)//integral number
            {
                result = num[0] + ".00";
            }
            else
            {    //length must be 2
                if (num[1].Length > 4)
                    num[1] = num[1].Substring(0, 3);
                if (num[1] == "")
                    num[1] = "00";

                int after_dp;
                int before_dp;

                if (!int.TryParse(num[1], out after_dp) || !int.TryParse(num[0], out before_dp))
                    return false;
                if (num[1].Length == 1)//convert single digit to 2 digits
                    after_dp *= 10;
                else if (after_dp > 99) //ignore more than 2 digits
                    after_dp %= 100;
                if (after_dp < 50)
                    result = before_dp + ".00";
                else
                {
                    result = (before_dp + 1) + ".00";
                }
            }
            return true;
        }
        public static bool find_and_decode_item_code(string input, out string result ,out string itemname)
        {
            itemname = input;
            result = "";         //return empty string in case of error
            input = input.Trim();  //remove blank spaces that are prefix or suffix of input

            string[] str_arr = input.Split(' ', '\t');
            string code = "";
            long code_num = 0;
            bool valid = false;
            //code=str_arr[str_arr.Length-1];   //the last part of the space separated 
            //      string is fetched
            int position = 0;
            for (int i = str_arr.Length - 1; i >= 0; i--)
            {
                code = str_arr[i];
                if (long.TryParse(code, out code_num))
                {
                    if (code[0] == '5' && code[code.Length - 1] == '5')
                    {
                        code = code.Substring(1, code.Length - 2); //remove prefix and suffix 5
                        long.TryParse(code, out code_num);

                        //Decoding
                        if (code_num > 100)
                        {
                            position = i;
                            valid = true;
                            break;
                        }
                    }
                }
            }
            //check for the prefix and suffix 5 in the code
            if (!valid)
                return false;



            itemname = "";
            for (int i = 0; i < str_arr.Length; i++)
            {
                if (i != position)
                {
                    itemname += str_arr[i];
                    if (i != str_arr.Length - 1)
                        itemname += " ";
                }
            }

            if (code.Length != 5)
                result = Convert.ToString(code_num - 100);
            else
                result = Convert.ToString(code_num / 100.0 - 100);
            return true;

        }
        public static bool parse_item_detail(string val, out  DataTable dt)
        {
            dt = new DataTable();
            dt.Columns.Add("a");
            dt.Columns.Add("b");
            double num;
            double a, b;
            int start;
            bool result= IsCodeExists(val , out start);
            if (result)    //there is float data
            {


                string s = val.Substring(start);

                string[] exp = s.Split(',');

                foreach (string t in exp)
                {

                    string x = t.Trim();
                    if (x.Equals(""))
                        continue;

                    string[] ele = x.Split('*');


                    string z = ele[0].Trim();
                    if (convertTodouble(z, out num))
                    {
                        a = num;

                        if (ele.Length == 1)
                            b = 1;
                        else
                        {
                            int inum;
                            z = ele[1].Trim();
                            if (convertToInt(z, out inum))
                                b = inum;
                            else
                                return false;

                        }
                        dt.Rows.Add(a, b);

                    }
                    else
                        return false;

                }
                return true;

            }
            return true;
        }
        public static bool IsCodeExists(string val , out int start)
        {
            start = 0; int len;

            double numb;
            while (start < val.Length)
            {
                len = 0;
                for (int j = start; j < val.Length && !char.IsWhiteSpace(val[j]) && val[j] != ',' && val[j] != '*'; j++)
                    len++;

                string s = val.Substring(start, len);
                s = s.Trim();

                if (convertTodouble(s, out numb))

                    break;
                else
                    start += len + 1;//+1 to ignore the whitespace

            }
            if (start < val.Length)
                return true;
            return false;
        }
        public static bool IsCodeExists(string val)
        {
            int start;
            return IsCodeExists(val, out start);
        }
        public static bool convertToInt(string s, out int i)
        {
            try
            {
                i = Convert.ToInt32(s);
            }
            catch
            {
                i = -1;
                return false;
                throw;
            }

            return true;
        }

        public static bool convertTodouble(string s, out double i)
        {
            try
            {
                i = Convert.ToDouble(s);
            }
            catch
            {
                i = -1;
                return false;
                throw;
            }

            return true;
        }

        /// <summary>
        /// this function outputs value in an out parameter named result 
        /// it returns value with two digits after decimal if input is appripriote
        /// otherwise it returns 0.00
        /// </summary>
        /// <param name="number"></param>
        /// <param name="result"></param>
        /// <returns><c>Result</c>result contains value with only two digits after decimal without rounding off</returns>
        public static bool set_zero(string number, out string result)
        {
            double x;
            result = "0.00";
            if (double.TryParse(number, out x) == false)
            {
                string [] a = number.Split('.');
                if (!(a.Length == 1 && double.TryParse(a[0], out x) == true))
                {
                    result = "0.00";
                    return false;
                }
            }
            if (number.Trim() == "")
            {
                result = "0.00";
                return true;
            }
            string[] split = number.Split('.');
            if (split.Length == 1 || (split.Length == 2 && split[1] == ""))
            {
                result = split[0] + ".00";
                return true;
            }
            if (split[1].Length == 1)
            {
                result = split[0] + "." + split[1] + "0";
            }
            if (split[1].Length == 2)
            {
                result = split[0] + "." + split[1];
            }
            if (split[1].Length > 2)
            {
                result = split[0] + "." + split[1].Substring(0 , 2);
            }
            return true;

        }
        /// <summary>
        /// grabs data table from the database
        /// compares each data to check if the given string and current string can be formed with minimum character change
        /// or it counts similarity between strings and shows all string with most probable character
        /// calls a form to show thoes values
        /// returns string selected by user
        /// </summary>
        /// <param name="x"></param>
        /// <param name="query"></param>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static string compare(string x, string query , int mat)
        {
            Connection con = new Connection();
            con.connent();
            DataTable dt = con.getTable(query);
            if (dt == null) return "";
            DataTable output = new DataTable();
            output.Columns.Add("account_name" , Type.GetType("System.String"));
            output.Columns.Add("charmatch", Type.GetType("System.Int32"));
            output.Columns.Add("permatch", Type.GetType("System.Double"));
            int count = 0;
            ////////////////////////////////////////////
            foreach (DataRow dr in dt.Rows)
            {
                double match , charmatch = 0;
                if (x != dr[0].ToString())
                {
                    charmatch = LevenshteinDistance(x, dr[0].ToString());
                    match = 1-charmatch / ((double)x.Length);
                }
                else
                {
                    match = 1;
                }
                if (charmatch <= mat || (match >= 0.7 && match <= 1))
                {
                    output.Rows.Add(dr[0], charmatch, match);
                    count++;
                }

            }
            ///////////////////////////////////////////
            if (output.Rows.Count == 0)
                return "";
            output.DefaultView.Sort = "permatch ASC";
            Match m = new Match();
            m.Dt = output;
            m.ShowDialog();
            return m.Output;
        }
        /// <summary>
        /// used to count number of character changes requited to convert firststring to second string
        /// This is a wellknown distance calculation formula which counts number of value change required to make firststring same as second string
        /// this tells similarity between two given string
        /// </summary>
        /// <param name="firstString"></param>
        /// <param name="secondString"></param>
        /// <returns></returns>
        private static int LevenshteinDistance(string firstString, string secondString)
        {
            if (firstString == null)
                throw new ArgumentNullException("firstString");
            if (secondString == null)
                throw new ArgumentNullException("secondString");
            if (firstString == secondString)
                return firstString.Length;
            firstString = firstString.ToLower(); secondString = secondString.ToLower();
            firstString.Replace(" ", "");
            secondString.Replace(" ", "");
            int[,] matrix = new int[firstString.Length + 1, secondString.Length + 1];

            for (int i = 0; i <= firstString.Length; i++)
                matrix[i, 0] = i; // deletion
            for (int j = 0; j <= secondString.Length; j++)
                matrix[0, j] = j; // insertion

            for (int i = 0; i < firstString.Length; i++)
                for (int j = 0; j < secondString.Length; j++)
                    if (firstString[i] == secondString[j])
                        matrix[i + 1, j + 1] = matrix[i, j];
                    else
                    {
                        matrix[i + 1, j + 1] = Math.Min(matrix[i, j + 1] + 1, matrix[i + 1, j] + 1); //deletion or insertion
                        matrix[i + 1, j + 1] = Math.Min(matrix[i + 1, j + 1], matrix[i, j] + 1); //substitution
                    }
            return matrix[firstString.Length, secondString.Length];
        }
        /// <summary>
        /// in notes user can enter various things but most of the time prefix of those things are similar to user current input
        /// using this function we calculates all those prefix which user can enter 
        /// these prefix is then used in drop down list to show to the user
        /// </summary>
        /// <param name="Datatable"></param>
        /// <returns>Datatable - contains prefix of all thoes which user has entered till now</returns>
        public static DataTable GetThroughList(DataTable dt)
        {
            string text1;
            string text2 = "";
            string[] text;
            DataRow dr = null;
            DataTable dt2 = new DataTable("Temporary");
            DataColumn col1 = new DataColumn("cbill_through_choice", typeof(string));
            col1.Unique = true;
            dt2.Columns.Add(col1);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                text1 = dt.Rows[j][0].ToString();
                text = text1.Split();
                for (int i = 0; i < text.Length; i++)
                {
                    if (i == 0)
                    {
                        text2 = text2 + text[i];
                    }
                    else
                    {
                        text2 = text2 + " " + text[i];
                    }
                    dr = dt2.NewRow();
                    dr["cbill_through_choice"] = text2;
                    try
                    {
                        dt2.Rows.Add(dr);
                    }
                    catch (Exception e)
                    {

                    }
                }
                text2 = "";
            }
            return dt2;
        }

    }
}
