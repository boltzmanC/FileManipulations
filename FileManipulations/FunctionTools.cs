using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Data;
using FluentFTP;

namespace FileManipulations
{
    public class FunctionTools
    {
        // Function Tools
         public static string GetAFile()
        {
            Console.Write("File:");

            string path = Console.ReadLine().Replace("\"", "");

            Console.WriteLine();

            return path;
        }

        public static char GetDelimiter()
        {
            Console.Write("Enter Delimeter: ");
            var delimeter = Console.ReadLine();

            char split_char;

            while (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Enter Delimiter");
                delimeter = Console.ReadLine();
            }

            //Console.WriteLine();

            return split_char;
        }

        public static char GetTXTQualifier()
        {
            Console.Write("Enter Txt Qualifier: ");
            var delimeter = Console.ReadLine();

            char splitchar;

            while (!char.TryParse(delimeter, out splitchar))
            {
                Console.Write("Entry Invalid");
                delimeter = Console.ReadLine();
            }

            Console.WriteLine();

            return splitchar;
        }

        public static string GetColumn() //removes ", trims, toupper 
        {
            Console.Write("Enter Column Name: ");
            string column_name = Console.ReadLine();

            column_name = column_name.Replace("\"", string.Empty);
            column_name = column_name.Trim();
            column_name = column_name.ToUpper();

            Console.WriteLine();

            return column_name;
        }

        public static int ColumnIndexWithQualifier(string line, char del, char qualifier, string columnname)
        {
            columnname = columnname.ToUpper().Trim();

            string[] linesplit = SplitLineWithTxtQualifier(line, del, qualifier, false);
            //linesplit = ArrayWithNoTxtQualifier(linesplit, qualifier);

            //int length = linesplit.Length;
            int columnindex = 0;
            for (int x = 0; x <= linesplit.Length - 1; x++)
            {
                if (columnname == linesplit[x].ToUpper().Trim().Replace(qualifier.ToString(), string.Empty))
                {
                    columnindex = x;
                }

            }
            return columnindex;
        }

        public static int ColumnIndex(string line, char del, string columnname)
        {
            columnname = columnname.ToUpper().Trim();

            string[] line_split = line.Split(del);

            int length = line_split.Length;

            int col = 0;
            for (int x = 0; x <= length - 1; x++)
            {
                if (columnname == line_split[x].ToUpper().Replace("\"", string.Empty).Trim())
                {
                    col = x;
                }

            }
            return col;
        }

        public static int ColumnIndexNew(string line, char del, string columnname, char txtq)
        {
            List<string> headerlinebuilder = new List<string>();
            if (line.Contains(txtq))
            {
                headerlinebuilder.AddRange(SplitLineWithTxtQualifier(line, del, txtq, false));
            }
            else
            {
                headerlinebuilder.AddRange(line.Split(del));
            }

            string[] splitline = headerlinebuilder.ToArray();

            int length = splitline.Length;

            int columnindex = 0;
            for (int x = 0; x <= length - 1; x++)
            {
                if (columnname.ToUpper() == splitline[x].ToUpper().Replace("\"", string.Empty).Trim())
                {
                    columnindex = x;
                }

            }
            return columnindex;
        }

        public static string[] LineStringToArray(string readline, char textqualifier, char delimiter)
        {
            List<string> splitlinebuilder = new List<string>();
            if (readline.Contains(textqualifier))
            {
                splitlinebuilder.AddRange(SplitLineWithTxtQualifier(readline, delimiter, textqualifier, false));
            }
            else
            {
                splitlinebuilder.AddRange(readline.Split(delimiter));
            }

            string[] splitline = splitlinebuilder.ToArray();

            return splitline;
        }

        public static string GetDesktopDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        public static string GetFileNameWithoutExtension(string filepath)
        {
            string filename = Path.GetFileNameWithoutExtension(@filepath);

            return filename;
        }

        public static int[] StringToIntArray(string value, char delimiter)
        {
            string[] array_info = value.Split(delimiter);
            int[] new_array = new int[array_info.Length];

            for (int i = 0; i < new_array.Length; ++i)
            {
                int number;
                string var = array_info[i];

                if (int.TryParse(var, out number))
                {
                    new_array[i] = number;
                }
            }

            return new_array;
        }

        public static string CombineTwoValuesInArray(string line, char delimiter, int column1, int column2)
        {
            string[] array = line.Split(delimiter);

            array[column1] = array[column1] + "_" + array[column2];

            List<string> values = new List<string>();

            for (int y = 0; y <= array.Length - 1; y++)
            {
                if (y != column2)
                {
                    values.Add(array[y]);
                }
            }

            string[] newarray = values.ToArray();
            string separator = delimiter.ToString();

            return string.Join(separator, newarray);
        }

        public static int SumOfIntArray(params int[] intarray)
        {
            int result = 0;

            for (int i = 0; i < intarray.Length; i++)
            {
                result += intarray[i];
            }

            return result;
        }

        public static int randomnumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string[] SplitLineWithTxtQualifier(string expression, char delimiter, char qualifier, bool ignoreCase) //true -> sets everything to lower.
        {
            if (ignoreCase)
            {
                expression = expression.ToLower();
                delimiter = char.ToLower(delimiter);
                qualifier = char.ToLower(qualifier);
            }

            int len = expression.Length;
            char symbol;
            List<string> list = new List<string>();
            string newField = null;

            for (int begin = 0; begin < len; ++begin)
            {
                symbol = expression[begin];

                if (symbol == delimiter || symbol == '\n')
                {
                    list.Add(string.Empty);
                }
                else
                {
                    newField = null;
                    int end = begin;

                    for (end = begin; end < len; ++end)
                    {
                        symbol = expression[end];
                        if (symbol == qualifier)
                        {
                            // bypass the unsplitable block of text
                            bool foundClosingSymbol = false;
                            for (end = end + 1; end < len; ++end)
                            {
                                symbol = expression[end];
                                if (symbol == qualifier)
                                {
                                    foundClosingSymbol = true;
                                    break;
                                }
                            }

                            if (false == foundClosingSymbol)
                            {
                                throw new ArgumentException("expression contains an unclosed qualifier symbol");
                            }

                            continue;
                        }

                        if (symbol == delimiter || symbol == '\n')
                        {
                            newField = expression.Substring(begin, end - begin);
                            begin = end;
                            break;
                        }
                    }

                    if (newField == null)
                    {
                        newField = expression.Substring(begin);
                        begin = end;
                    }

                    list.Add(newField.Replace("\"", string.Empty)); //added to remove " for simplification.
                }
            }
            return list.ToArray();
        }

        public static string[] ArrayWithNoTxtQualifier(string[] array, char qualifier)
        {
            List<string> values = new List<string>();

            foreach (string v in array)
            {
                string newvalue = v.Replace(qualifier.ToString(), string.Empty);

                values.Add(newvalue);
            }

            return values.ToArray();
        }


        // File formatting.
        public static void StringStrip() //remove string from lines in file.
        {
            // remove string from each line of file.
            // uses function line_strip, takes (line to edit, string to remove, char delimiter)
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deletes user designated string or character as string (string example: \"word\", char example: \"). Can be used to remove all \" quotes from a file.");
            Console.ResetColor();

            string file = GetAFile();

            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.Write("String: ");
            string toremove = Console.ReadLine().Trim();

            string outfile = Directory.GetParent(file) + "\\" + GetFileNameWithoutExtension(file) + "_stringremoved.txt";

            Console.WriteLine("Processing...");

            using (StreamWriter writeto = new StreamWriter(outfile))
            {
                using (StreamReader readfile = new StreamReader(file))
                {
                    string lines;
                    int count = 0;
                    while ((lines = readfile.ReadLine()) != null)
                    {
                        if (lines.Contains(toremove))
                        {
                            count++;
                            lines = lines.Replace(toremove, string.Empty);
                        }

                        writeto.WriteLine(lines);
                    }
                    Console.WriteLine(count);
                }
            }
        }

        public static void SuperStringStripper()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deletes user designated LIST of strings");
            Console.ResetColor();

            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char deli;
            if (!char.TryParse(delimeter, out deli))
            {
                Console.Write("Invalid Char");
                return;
            }

            Console.Write("Enter pipe delimited strings to delete from file:");
            string userstrings = Console.ReadLine().Trim();

            string[] stringstodelete = userstrings.Split(deli);


            string filename = GetFileNameWithoutExtension(file);

            string outfile = (GetDesktopDirectory() + "\\" + filename + "_stringremoved.txt");

            Console.WriteLine("Processing...");

            using (StreamWriter writefile = new StreamWriter(outfile))
            {
                using (StreamReader readfile = new StreamReader(file))
                {
                    string header = readfile.ReadLine();
                    writefile.WriteLine(header);

                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        foreach (var s in stringstodelete)
                        {
                            if (line.Contains(s))
                            {
                                line = line.Replace(s, string.Empty);
                            }
                        }

                        writefile.WriteLine(line);
                    }
                }
            }
        }

        public static void VerifyLineLength() // checks and outputs only records that match the header length. outputs non-matching to gargabe file?
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Checks that all records in the file have the same number of columns as the header row. ");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string filename = GetFileNameWithoutExtension(file);

            string outfile = GetDesktopDirectory() + "\\" + filename + "_good_columns.txt";
            string outfile2 = GetDesktopDirectory() + "\\" + filename + "_bad_columns.txt";

            Console.Write("Processing...");

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    using (StreamWriter newfile2 = new StreamWriter(outfile2))
                    {
                        //header info
                        string header = readfile.ReadLine();
                        newfile.WriteLine(header);
                        newfile2.WriteLine(header);

                        string[] headersplit = LineStringToArray(header, txtq, delimiter);
                        int headlength = headersplit.Length;

                        int badcount = 0;

                        string line;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            string[] linessplit = LineStringToArray(line, txtq, delimiter);

                            int linelength = linessplit.Length;

                            if (linelength == headlength)
                            {
                                newfile.WriteLine(line);
                            }
                            else
                            {
                                badcount++;
                                newfile2.WriteLine(line);
                            }

                        }
                        Console.WriteLine();
                        Console.WriteLine("Bad lines {0}", badcount);
                    }
                }
            }
        }

        public static void TrimWhitespace()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Trims / removes all extra white spaces in a file. Any extra spaces or tabs that are present will be removed.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();
            Console.Write("Processing...");

            string filename = GetFileNameWithoutExtension(file);

            string outfile = GetDesktopDirectory() + "\\" + filename + "_trimmed.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = LineStringToArray(line, txtq, delimiter);

                        for (int s = 0; s < splitline.Length; s++)
                        {
                            splitline[s] = splitline[s].Trim();
                        }

                        string newline = string.Join(delimiter.ToString(), splitline);
                        newfile.WriteLine(newline);
                    }
                }
            }
        }

        public static void ChangeDelimeter()
        {
            //Changes delimiter of file.
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Changes the delimiter of a target file.");
            Console.ResetColor();

            string file = GetAFile();
            char txtq = GetTXTQualifier();
            char delimiter = GetDelimiter();
            Console.Write("New: ");
            char newdelimiter = GetDelimiter();

            string filename = GetFileNameWithoutExtension(file);
            string outfile = GetDesktopDirectory() + "\\" + filename + "_newdelimiter.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = LineStringToArray(line, txtq, delimiter);
                        string newline = string.Join(newdelimiter.ToString(), splitline);

                        newfile.WriteLine(newline);
                    }
                }
            }
        }

        public static void CombineTwoColumns() //combines two user designated columns. User input is SPACE delimited. 
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Combines two user designated columns.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.Write("Space Separated column numbers to combine(start count from 0): ");
            string input = Console.ReadLine();
            string[] format_input = input.Split(' ');
            int column1 = int.Parse(format_input[0]);
            int column2 = int.Parse(format_input[1]);

            Console.Write("Processing...");

            using (StreamReader readfile = new StreamReader(file))
            {
                string header = readfile.ReadLine();
                string[] headersplit = LineStringToArray(header, txtq, delimiter);
                string col1 = headersplit[column1];
                string col2 = headersplit[column2];

                string filename = GetFileNameWithoutExtension(file);

                string outfile = GetDesktopDirectory() + "\\" + filename + "_" + col1 + "_" + col2 + "_combined.txt";

                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    //header format.
                    string newheader = CombineTwoValuesInArray(header, delimiter, column1, column2);
                    newfile.WriteLine(newheader);

                    // rest of file format.
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string newline = CombineTwoValuesInArray(line, delimiter, column1, column2);
                        newfile.WriteLine(newline);
                    }
                }

                Console.WriteLine("New File: {0}", outfile);
                Console.WriteLine();
            }
        }




    }
}
