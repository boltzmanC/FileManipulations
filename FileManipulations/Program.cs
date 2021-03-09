using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Data;
using FluentFTP;
//using ExcelDataReader;


namespace FileManipulations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 45);
            int bufferwidth = Console.BufferWidth;
            int bufferheight = 600;
            Console.SetBufferSize(bufferwidth, bufferheight);

            //DeleteDelmitedValue();

            FileFormatCheckerFixer();
            //FileInfo();

            // Manual running-------------

            //AddStringToColumnValues();
            //AddStringAsNewColumnValue();
            //AppendValueToEachLineInFile();
            //BGToZipUrbanicityAverage();
            //BehaviorAnalyzerSorting();
            //CopyColumnToNewFile();
            //CopyColumnsToNewFile(); //better.
            //CombineFiles();
            //CSTUsageMetricsFilter();
            //Dedupesaveextravalues();
            //EditLineInListOfFiles();
            //FileInfo();
            //FindDatesBeforeX();
            //FindIDsInTwoFiles();
            //FixedWidthToPipeDelimited();
            //FormatDateColumn();
            //FormatZipCodesAddLeadingZeroes();
            //NumericValueCheck();
            //PullBlankEmptyOrZeroValueRecords();
            //PullRecordsWithORListofStringorChars();
            //PullRecordsWithValueInColumn_s();
            //PullRecordsWithValueXInColumnY();
            //PullRandomSubsetofLengthX();
            //ReadTwoLines();
            //RemoveDataFromColumn();
            //UniqueValueCheck();
            //SkipUserSpecifiedLines();
            //SuperStringStripper();
            //TestColumnNamesFromDefinitionFile();
            //VlookupAppendColumn(); //does not accept files with text qualifiers
            //VLookupAppendColumnRows();
            //VlookupKeepNotFoundFromOriginalFile();
            //XLSXToCSV();


            //CostarPointsFiles(); //add check for unique variable IDS first.
            //CostarPointsFilesManualCheck();

            //CostarAreaFiles();
            //CostarAreaFilesManualCheck();
            //CostarAreaFilesSummaries(); //sums total variable values.. should be less than or eqaul to national totals.

            //CoStarUSManualTestGapFile();

            //CostarCanadaTestGapFile();
            //CostarCanadaManualTestGapfile();
            //CostarCanadaReformatNightlyFeedOutput();

            //CostarSumDataColumns();

            //Michelin Monthly testing...
            //MichelinMonthlyFileCleaner();

            //Michelin Polk tables
            //MichelinPOLKZipReaderMultiTask();
            //
            //MichelinPOLKNewZipFinder();
            //
            //MichelinPOLKZipCountsDiffReader();
            //MichelinPOLKPolkKeyCountsDiffReader();
            //MichelinPOLKStateCountsDiffReader();
            //
            //MichelinPOLKVehicleInfoFileCleaner();
            //MichelinPOLKMichelintoPolkCrossWalk();
            //MichelinPOLKTirePotentialSegmentChecker();
            //
            //MichelinPOLKGroupCatChecker();
            //
            //michelin canada
            //MichelinCanadaPOLKReaderMultiTask();

            //MichelinCanadaPOLKNewfsaFinder();
            //MichelinCanadaPOLKfsaCountsDiffReader();
            //MichelinCanadaPOLKPolkKeyCountsDiffReader();
            //MichelinCanadaPOLKProvinceCountsDiffReader();
            //MichelinCanadaPOLKVehicleInfoFileCleaner();
            //MichelinCanadaPOLKMichelintoPolkCrossWalk();
            //MichelinCanadaPOLKTirePotentialSegmentChecker();
            //MichelinCanadaPOLKTirePotentialSegmentCheckerWINTER();
            //MichelinCanadaPOLKGroupCatChecker();

            //foreach (KeyValuePair<string, List<string>> entry in dict)

            //Collapse all methods -> CTRL + M CTRL + O
        }

        static void FileFormatCheckerFixer()
        {
            // this will launch the default browser    
            //System.Diagnostics.Process.Start("https://confluence.nexgen.neustar.biz/display/E1/File+Format+Checker+Fixer");

            string choice = string.Empty;

            while (choice != "exit" || choice != "Exit")
            {
                Console.WriteLine();

                Console.WriteLine("File Formatting: ");
                Console.WriteLine("{0,5}{1,-10}", "1. ", "String Stripper.");
                Console.WriteLine("{0,5}{1,-10}", "2. ", "Verify Line Length.");
                Console.WriteLine("{0,5}{1,-10}", "3. ", "Trim Whitespace.");
                Console.WriteLine("{0,5}{1,-10}", "4. ", "Change Delimiter.");
                Console.WriteLine("{0,5}{1,-10}", "5. ", "Combine Two Columns.");
                Console.WriteLine();

                Console.WriteLine("File Manipulation");
                Console.WriteLine("{0,5}{1,-10}", "6. ", "Combine Files"); // promts user for files and if it has headers. (files MUST BE IN THE SAME FORMAT)
                Console.WriteLine("{0,5}{1,-10}", "7. ", "Copy File"); //copies file, use to get rid of hidden formats within the file.
                Console.WriteLine("{0,5}{1,-10}", "8. ", "Dedupe column");
                Console.WriteLine("{0,5}{1,-10}", "9. ", "Vlookup Append Column");
                Console.WriteLine("{0,5}{1,-10}", "10. ", "Vlookup Append Column Rows");
                Console.WriteLine("{0,5}{1,-10}", "11. ", "Add String to Column Values");
                Console.WriteLine("{0,5}{1,-10}", "12. ", "Add String As New Column Value");
                Console.WriteLine("{0,5}{1,-10}", "13. ", "Remove Data From Column");
                Console.WriteLine();

                Console.WriteLine("Pull Data from File");
                Console.WriteLine("{0,5}{1,-10}", "14. ", "Get Subset of Records");
                Console.WriteLine("{0,5}{1,-10}", "15. ", "Break File Into # of Subsets.");
                Console.WriteLine("{0,5}{1,-10}", "16. ", "Copy Column(s) with value to New File.");
                Console.WriteLine("{0,5}{1,-10}", "17. ", "Copy Columns to New File.");
                Console.WriteLine("{0,5}{1,-10}", "18. ", "Pull Blank Empty or Zero Value Records"); //broken
                Console.WriteLine("{0,5}{1,-10}", "19. ", "Pull Random Subet of Length x");
                Console.WriteLine("{0,5}{1,-10}", "20. ", "Pull Records with Value x in column y.");
                Console.WriteLine("{0,5}{1,-10}", "21. ", "Pull Records with value in column_s.");
                Console.WriteLine("{0,5}{1,-10}", "22. ", "Pull records with OR list of strings or chars.");
                Console.WriteLine();

                Console.WriteLine("Monthly File Processes");
                Console.WriteLine("{0,5}{1,-10}", "23. ", "Check format and build new .definition file");

                //Console.WriteLine("CST Specific Tasks:");
                //Console.WriteLine("{0,5}{1,-10}", "10. ", "BG to Zip Urbanicity Average"); //report for this exisits in e1support instance.

                Console.WriteLine();
                Console.WriteLine("{0,5}{1,-10}", "exit. ", "To close the console.");
                Console.WriteLine();

                Console.Write("Your choice: ");

                //Get user input.
                string input = Console.ReadLine();

                //Switch Statements.
                switch (input)
                {
                    // File Formatting.
                    case "1":
                        StringStrip();
                        break;
                    case "2":
                        VerifyLineLength();
                        break;
                    case "3":
                        TrimWhitespace();
                        break;
                    case "4":
                        ChangeDelimeter();
                        break;
                    case "5":
                        CombineTwoColumns();
                        break;

                    // File Manipulation.
                    case "6":
                        CombineFiles();
                        break;
                    case "7":
                        CopyFile();
                        break;
                    case "8":
                        UniqueValueCheck();
                        break;
                    case "9":
                        VlookupAppendColumn();
                        break;
                    case "10":
                        VLookupAppendColumnRows();
                        break;
                    case "11":
                        AddStringToColumnValues();
                        break;
                    case "12":
                        AddStringAsNewColumnValue();
                        break;
                    case "13":
                        RemoveDataFromColumn();
                        break;

                    //Pull Data From File.
                    case "14":
                        GetSubsetOfRecords();
                        break;
                    case "15":
                        BreakOneFileIntoMany();
                        break;
                    case "16":
                        CopyColumnsWithValueToNewFile();
                        break;
                    case "17":
                        CopyColumnsToNewFile();
                        break;
                    case "18":
                        PullBlankEmptyOrZeroValueRecords();
                        break;
                    case "19":
                        PullRandomSubsetofLengthX(); // not really working.
                        break;
                    case "20":
                        PullRecordsWithValueXInColumnY();
                        break;
                    case "21":
                        PullRecordsWithValueInColumn_s();
                        break;
                    case "22":
                        PullRecordsWithORListofStringorChars();
                        break;

                    case "23":
                        TestColumnNamesFromDefinitionFile();
                        break;

                    //end
                    case "Exit":
                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("not a valid input");
                        FileFormatCheckerFixer(); //start over
                        break;
                }
            }
        }


        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
        // Most used functions.? 
        static public string GetAFile()
        {
            Console.Write("File:");

            string path = Console.ReadLine().Replace("\"", "");

            Console.WriteLine();

            return path;
        }

        static public char GetDelimiter()
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

        static public char GetTXTQualifier()
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

        static public string GetColumn() //removes ", trims, toupper 
        {
            Console.Write("Enter Column Name: ");
            string column_name = Console.ReadLine();

            column_name = column_name.Replace("\"", string.Empty);
            column_name = column_name.Trim();
            column_name = column_name.ToUpper();

            Console.WriteLine();

            return column_name;
        }

        static public int ColumnIndexWithQualifier(string line, char del, char qualifier, string columnname)
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

        static public int ColumnIndex(string line, char del, string columnname)
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

        static public int ColumnIndexNew(string line, char del, string columnname, char txtq)
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

        static public string[] LineStringToArray(string readline, char textqualifier, char delimiter)
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

        static public string GetDesktopDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        static public string GetFileNameWithoutExtension(string filepath)
        {
            string filename = Path.GetFileNameWithoutExtension(@filepath);

            return filename;
        }

        static int[] StringToIntArray(string value, char delimiter)
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

        static public string CombineTwoValuesInArray(string line, char delimiter, int column1, int column2)
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

        static int SumOfIntArray(params int[] intarray)
        {
            int result = 0;

            for (int i = 0; i < intarray.Length; i++)
            {
                result += intarray[i];
            }

            return result;
        }

        static public int randomnumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static public string[] SplitLineWithTxtQualifier(string expression, char delimiter, char qualifier, bool ignoreCase) //true -> sets everything to lower.
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

        static public string[] ArrayWithNoTxtQualifier(string[] array, char qualifier)
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
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
        static public void StringStrip() //remove string from lines in file.
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

        static public void SuperStringStripper()
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

        static public void VerifyLineLength() // checks and outputs only records that match the header length. outputs non-matching to gargabe file?
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

        static public void TrimWhitespace()
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

        static public void ChangeDelimeter()
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

        static public void CombineTwoColumns() //combines two user designated columns. User input is SPACE delimited. 
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


        // File manipulation.
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
        static public void CombineFiles()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Combines files that have the same column headers.");
            Console.ResetColor();

            Console.WriteLine("-Enter files as prompted, headers must match, number of columns must match-");

            List<string> files = new List<string>();
            List<char> delimiters = new List<char>();

            string answer = string.Empty;

            while (answer != "n")
            {
                Console.WriteLine();
                string file = GetAFile();
                char delimiter = GetDelimiter();

                files.Add(file);
                delimiters.Add(delimiter);

                Console.WriteLine();
                Console.Write("Enter another file? (y/n): ");
                answer = Console.ReadLine().Trim().ToLower();
            }

            string[] filepaths = files.ToArray();

            string header = string.Empty;
            using (StreamReader headerfile = new StreamReader(filepaths[0]))
            {
                header = headerfile.ReadLine();
            }

            // if all columns match...
            string newfile = GetDesktopDirectory() + "\\combined-file.txt";

            int totallines = 0;

            using (StreamWriter writefile = new StreamWriter(newfile))
            {
                writefile.WriteLine(header);

                foreach (var file in filepaths)
                {
                    using (StreamReader readfile = new StreamReader(file))
                    {
                        string readheader = readfile.ReadLine();

                        string line = string.Empty;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            writefile.WriteLine(line);
                            totallines++;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("{0} - combined file", newfile);
            Console.WriteLine("{0} - records in new file", totallines);
            Console.WriteLine();
        }

        static public void CopyFile() // line by line copy file.
        {
            // splits and recombines lines of file. 
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Copies a file line by line. This is done to get rid of hidden EOL or EOF formatting which occurs sometimes when creating a file on a MAC and transfering it to PC.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();
            Console.Write("Processing...");

            string filename = GetFileNameWithoutExtension(file);
            string outfile = GetDesktopDirectory() + "\\" + filename + "_copy.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    string header = readfile.ReadLine();
                    newfile.WriteLine(header);
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] linearray = LineStringToArray(line, txtq, delimiter);

                        string newline = string.Join(delimiter.ToString(), linearray);

                        //newline = newline.Replace(toreplace, neweol);
                        //newline = newline.Replace(toreplace2, neweol);

                        newfile.WriteLine(newline);
                    }
                }
            }
        }

        static public void UniqueValueCheck() // checks for duplicate values in user entered column, writes unique values and count of each occurance.
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Checks for duplicate values in user entered column. Writes unique values and count of each occurrence to new file.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string columnname = GetColumn();
            string newfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_uniquevalues.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                Dictionary<string, int> uniquevalues = new Dictionary<string, int>();

                string header = readfile.ReadLine();
                int columnindex = ColumnIndexNew(header, delimiter, columnname, txtq);

                int count = 0;
                int countunique = 0;
                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    Console.Write("\r {0}", count++);
                    string[] splitline = LineStringToArray(line, txtq, delimiter);

                    if (!uniquevalues.ContainsKey(splitline[columnindex]))
                    {
                        uniquevalues.Add(splitline[columnindex], 1);
                    }
                    else
                    {
                        uniquevalues[splitline[columnindex]] += 1;
                    }
                }

                using (StreamWriter writefile = new StreamWriter(newfile))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    countunique = uniquevalues.Count;
                    Console.WriteLine("{0} - unique values", countunique);

                    writefile.WriteLine("Value|Count");

                    foreach (KeyValuePair<string, int> values in uniquevalues)
                    {
                        writefile.WriteLine("{0}|{1}", values.Key, values.Value);
                    }
                }
            }
        }

        static public void VlookupAppendColumn() //adds 1 column to a file. both files need matching unique ID column. 
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("vlookup_append_column(): adds 1 column to a file. Both files need matching Unique ID columns.");
            Console.ResetColor();
            Console.WriteLine();

            //original file.
            Console.Write("File being added to: ");
            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine("ID Column Name:");
            string idcolumnname = GetColumn();
            Console.WriteLine();
            Console.WriteLine();

            //data to add.
            Console.Write("File With New Column: ");
            string grabfromfile = GetAFile();
            char toadddelimiter = GetDelimiter();
            char toaddtxtq = GetTXTQualifier();

            Console.WriteLine("ID Column Name: ");
            string toaddidcolumnname = GetColumn();

            Console.Write("Column To Add Name: ");
            string toaddcolumnname = GetColumn();

            //returned file.
            string outfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_" + toaddcolumnname + "_appended.txt";
            Console.WriteLine("Processing...");

            // Process...
            Dictionary<string, string> idvalues = new Dictionary<string, string>();

            // Read the column file.
            using (StreamReader toaddcolumnfile = new StreamReader(grabfromfile))
            {
                string header = toaddcolumnfile.ReadLine();
                string[] headercolumns = LineStringToArray(header, toaddtxtq, toadddelimiter);
                int length = headercolumns.Length;

                int toaddidcolumn = ColumnIndexNew(header, toadddelimiter, toaddidcolumnname, toaddtxtq);
                int toaddvaluecolumn = ColumnIndexNew(header, toadddelimiter, toaddcolumnname, toaddtxtq);

                string line;
                while ((line = toaddcolumnfile.ReadLine()) != null)
                {
                    string[] linesplit = LineStringToArray(line, toaddtxtq, toadddelimiter);

                    if (!idvalues.ContainsKey(linesplit[toaddidcolumn]))
                    {
                        idvalues.Add(linesplit[toaddidcolumn], linesplit[toaddvaluecolumn]);

                    }
                    else
                    {
                        Console.WriteLine("Duplicate: {0}", linesplit[toaddidcolumn]);
                    }
                }
            }

            // Read file to add too.
            using (StreamWriter writefile = new StreamWriter(outfile))
            {
                using (StreamReader originalfile = new StreamReader(file))
                {
                    string header = originalfile.ReadLine();
                    string[] headervalues = header.Split(delimiter);
                    int length = headervalues.Length;

                    int idcolumnindex = ColumnIndexNew(header, delimiter, idcolumnname, txtq);
                    writefile.WriteLine("{0}{1} {2}", header, delimiter, toaddcolumnname);

                    string line = string.Empty;
                    while ((line = originalfile.ReadLine()) != null)
                    {
                        string[] linesplit = LineStringToArray(line, txtq, delimiter);

                        if (idvalues.ContainsKey(linesplit[idcolumnindex]))
                        {
                            string value = idvalues[linesplit[idcolumnindex]];

                            writefile.WriteLine("{0}{1} {2}", line, delimiter, value);
                        }
                    }
                }
            }
        }

        static public void VLookupAppendColumnRows()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Appends all columns from records with matching from File2 to File1 that have matching \"ID\" values.");
            Console.ResetColor();

            //output char to elminate issues with , tabs etc...
            char newdelimiter = '|';

            //file that is being appeneded.
            Console.WriteLine("File being appended: ");
            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();
            Console.Write("ID Column Name: ");
            string idcolumn = GetColumn();

            //file with data to append.
            Console.WriteLine("File with data to append: ");
            string toappendfile = GetAFile();
            char toappenddelimiter = GetDelimiter();
            char toappendtxtq = GetTXTQualifier();
            Console.Write("ID Column Name: ");
            string toappendidcolumn = GetColumn();

            //Dictionary for data from append data file.
            Dictionary<string, string> ToAppendValues = new Dictionary<string, string>();

            //List of headers from data to append file.
            List<string> toappendheaderstorage = new List<string>();

            //new file.
            string appendedfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_appended.txt";

            //read to append data file.
            using (StreamReader toappenddata = new StreamReader(toappendfile))
            {
                string header = toappenddata.ReadLine();
                string[] headervalues = LineStringToArray(header, toappendtxtq, toappenddelimiter);

                //idcolumn index
                int toappendidcolumnindex = ColumnIndexNew(header, toappenddelimiter, toappendidcolumn, toappendtxtq);

                //add headers to storage list.
                foreach (var h in headervalues)
                {
                    if (h != headervalues[toappendidcolumnindex])
                    {
                        toappendheaderstorage.Add(h);
                    }
                }

                //read site_ids into dict.
                string toappendline = string.Empty;
                while ((toappendline = toappenddata.ReadLine()) != null)
                {
                    string[] toappendsplitline = LineStringToArray(toappendline, toappendtxtq, toappenddelimiter);

                    if (!ToAppendValues.ContainsKey(toappendsplitline[toappendidcolumnindex]))
                    {
                        //add not idcolumn to list.
                        List<string> dictvalues = new List<string>();
                        foreach (var s in toappendsplitline)
                        {
                            if (s != toappendsplitline[toappendidcolumnindex])
                            {
                                dictvalues.Add(s);
                            }
                        }
                        //list -> array -> string. with new delimiter.
                        string newdictvalues = string.Join(newdelimiter.ToString(), dictvalues.ToArray()); // pipe delimited string.

                        //add to dictionary.
                        ToAppendValues.Add(toappendsplitline[toappendidcolumnindex], newdictvalues);
                    }
                }
            }

            //read the file to be appended.
            using (StreamReader filebeingappended = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(appendedfile))
                {
                    string header = filebeingappended.ReadLine();
                    string[] headervalues = LineStringToArray(header, txtq, delimiter);

                    //write new header to new file. Using new delimiter.
                    string newfileheader = string.Join(newdelimiter.ToString(), headervalues) + newdelimiter.ToString() + string.Join(newdelimiter.ToString(), toappendheaderstorage.ToArray());
                    newfile.WriteLine(newfileheader);

                    //Find idcolumn index.
                    int idcolumnindex = ColumnIndexNew(header, delimiter, idcolumn, txtq);
                    //int length = ogheadervalues.Length;

                    //read ogfile.
                    string line = string.Empty;
                    try
                    {
                        while ((line = filebeingappended.ReadLine()) != null)
                        {
                            string[] splitline = LineStringToArray(line, txtq, delimiter);

                            if (ToAppendValues.ContainsKey(splitline[idcolumnindex]))
                            {
                                string newline = string.Join(newdelimiter.ToString(), splitline);

                                string newfilewriteline = newline + newdelimiter.ToString() + ToAppendValues[splitline[idcolumnindex]];

                                //write new line.
                                newfile.WriteLine(newfilewriteline);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }
        }

        static public void AddStringToColumnValues() // adds user entered string to values in user selected column in file.
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Adds user designated string to column \"empty\" column. IF the column does have data in it. The values will be overwritten and replaced with the user designated values.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.Write("Column Name: ");
            string columnname = GetColumn();

            Console.Write("Value to add: ");
            string valuetoadd = Console.ReadLine().Replace("\"", string.Empty).Trim().ToUpper();

            string newfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_" + valuetoadd + "_added.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                string header = readfile.ReadLine();
                string[] headervalues = LineStringToArray(header, txtq, delimiter);
                int length = headervalues.Length;

                int columnindex = ColumnIndexNew(header, delimiter, columnname, txtq);

                using (StreamWriter writefile = new StreamWriter(newfile))
                {
                    writefile.WriteLine(header);

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = LineStringToArray(line, txtq, delimiter);

                        if (splitline[columnindex] != valuetoadd)
                        {
                            splitline[columnindex] = valuetoadd;
                            string newline = string.Join(delimiter.ToString(), splitline);
                            writefile.WriteLine(newline);
                        }
                        else
                        {
                            writefile.WriteLine(line);
                        }
                    }
                }
            }
        }

        static public void AddStringAsNewColumnValue()
        {
            // adds user specified string to every row as a new "column" value.
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Adds new Column and user designated string to every row as a new \"column\" value.");
            Console.ResetColor();

            Console.WriteLine("-Add string as new column value-");

            string file = GetAFile();
            char deli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.Write("New Column name: ");
            string columnname = Console.ReadLine().Trim();
            Console.WriteLine();
            Console.Write("Value to add: ");
            string valuetoadd = Console.ReadLine().Trim();

            string appendedfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_columnvalueadded.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(appendedfile))
                {
                    string header = readfile.ReadLine();
                    string[] headersplit = LineStringToArray(header, txtq, deli);
                    List<string> headerbuilder = headersplit.ToList();
                    headerbuilder.Add(columnname);

                    // write new header
                    writefile.WriteLine(string.Join(deli.ToString(), headerbuilder));

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        splitlinebuilder.AddRange(LineStringToArray(line, txtq, deli));

                        // add new value
                        splitlinebuilder.Add(valuetoadd);

                        // write new line
                        writefile.WriteLine(string.Join(deli.ToString(), splitlinebuilder.ToArray()));
                    }
                }
            }
        }

        static public void RemoveDataFromColumn()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Delete all data in user designated column.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.Write("Enter Column Name: ");
            string columnname = Console.ReadLine();

            string columndataremoved = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_columndataremoved.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter outfile = new StreamWriter(columndataremoved))
                {
                    string header = readfile.ReadLine();
                    outfile.WriteLine(header);

                    int columnindex = ColumnIndexNew(header, delimiter, columnname, txtq);

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = LineStringToArray(line, txtq, delimiter);

                        splitline[columnindex] = string.Empty; //target value deleted.

                        outfile.WriteLine(string.Join(delimiter.ToString(), splitline));
                    }
                }
            }
        }


        // PUll data from File.
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
        static public void GetSubsetOfRecords()  //get subset of file.
        {
            //Gets user desigmated number of lines from file.
            //use to get subset of records.
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Get user designated # of records from file. Count starts at the beginning of the file.");
            Console.ResetColor();

            string file = GetAFile();

            Console.Write("Records to skip: ");
            string skiplines = Console.ReadLine();

            int skipnumber;
            if (!int.TryParse(skiplines, out skipnumber))
            {
                Console.Write("Invalid number");
                return;
            }

            Console.Write("Number of Records to pull: ");
            string numberofrecords = Console.ReadLine();

            int numbertoread;
            if (!int.TryParse(numberofrecords, out numbertoread))
            {
                Console.Write("Invalid number");
                return;
            }
            numbertoread -= 1;

            Console.Write("Processing...");


            string filename = GetFileNameWithoutExtension(file);
            string outfile = Directory.GetParent(file) + "\\" + filename + "_subset" + "_" + numberofrecords + ".txt";

            using (StreamWriter writeto = new StreamWriter(outfile))
            {
                using (StreamReader readfile = new StreamReader(file))
                {
                    string header = readfile.ReadLine();
                    writeto.WriteLine(header);

                    int countlines = 0;
                    string line;
                    while ((line = readfile.ReadLine()) != null && countlines <= numbertoread)
                    {
                        writeto.WriteLine(line);

                        countlines++;
                    }

                    if (countlines < numbertoread)
                    {
                        Console.WriteLine("Lines requested - {0}. Lines read - {1}", numbertoread, countlines);
                    }

                }
            }

        }

        static private void BreakOneFileIntoMany() // breaks up a file into user defined number.
        {
            // Written by Khoa Le.
            //editted by dylan white on 5/8/2018.
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Breaks target file into user designated # of parts.");
            Console.ResetColor();

            Int64 sourceRecordCount, iRecordCount, NoOutputFiles;

            Console.Write("File: ");
            var inFile = new FileInfo(Console.ReadLine());

            Console.Write("Source Record Count (Enter nothing for auto count): ");

            if (Int64.TryParse(Console.ReadLine(), out iRecordCount))
                sourceRecordCount = iRecordCount;
            else
                sourceRecordCount = File.ReadLines(inFile.FullName).LongCount();

            Console.Write("No. of Output Files: ");
            NoOutputFiles = Int64.Parse(Console.ReadLine());

            Int64 linesWritten;
            double maxBreakoutRecordsPerFile = Math.Ceiling((double)sourceRecordCount / (double)NoOutputFiles);
            string readLine;

            Console.WriteLine("Running...");

            using (var reader = new StreamReader(inFile.OpenRead()))
            {
                string header = reader.ReadLine();

                for (int i = 1; i <= NoOutputFiles; i++)
                {
                    // edit: added Directory.GetParent(inFile.ToString()). places new files on in parent directory of target file instead of .exe location.
                    using (var writer = new StreamWriter(Directory.GetParent(inFile.ToString()) + "\\" + (inFile.Name.Replace(inFile.Extension, "").ToString() + "_split_" + i + inFile.Extension.ToString())))
                    {
                        writer.WriteLine(header);
                        linesWritten = 0;

                        while (linesWritten < maxBreakoutRecordsPerFile && (readLine = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(readLine);
                            linesWritten++;
                        }
                    }
                }
            }
        }

        static public void CopyColumnsToNewFile()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-Copies user designated column(s) to new file-");
            Console.ResetColor();

            string file = GetAFile();
            char deli = GetDelimiter();
            char txtq = GetTXTQualifier();

            string outfile = Directory.GetParent(file) + "\\" + GetFileNameWithoutExtension(file) + "_selectedcolumns.txt";

            Console.WriteLine();
            Console.WriteLine("Column list file, pipe delimited names on one line: ");
            string columnfile = GetAFile();

            string columnsentered = string.Empty;
            using (StreamReader columnlist = new StreamReader(columnfile))
            {
                columnsentered = columnlist.ReadLine();
            }

            string[] columnarray = columnsentered.Split('|');

            Console.WriteLine();
            Console.WriteLine("Processing...");

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(outfile))
                {
                    string header = readfile.ReadLine();
                    string[] headersplit = SplitLineWithTxtQualifier(header, deli, txtq, false);

                    writefile.WriteLine(string.Join(deli.ToString(), columnarray)); //new header

                    List<int> columnindexlist = new List<int>();
                    foreach (var item in columnarray)
                    {
                        int index = Array.IndexOf(headersplit, item);

                        columnindexlist.Add(index);
                    }

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        List<string> linebuilder = new List<string>();
                        string[] linesplit = line.Split(deli);

                        foreach (var c in columnindexlist)
                        {
                            linebuilder.Add(linesplit[c]);
                        }

                        //write new line to new file.
                        writefile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        static public void CopyColumnsWithValueToNewFile()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-Copies user designated column(s) with values to new file-");
            Console.ResetColor();

            string file = GetAFile();
            char deli = GetDelimiter();
            char txtq = GetTXTQualifier();

            string outfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_selectedcolumns.txt";

            Console.WriteLine();
            Console.Write("Enter Pipe Delimited Column(s): ");
            string columnsentered = Console.ReadLine().Trim();
            string[] columnarray = columnsentered.Split('|');

            Console.WriteLine();
            Console.Write("Enter logic to be used - (OR/AND): ");
            string logic = Console.ReadLine().Trim();

            Console.WriteLine();
            Console.WriteLine("Processing...");

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(outfile))
                {
                    string header = readfile.ReadLine();
                    writefile.WriteLine(string.Join(deli.ToString(), columnarray)); //new header

                    List<int> columnindexlist = new List<int>();
                    foreach (var item in columnarray)
                    {
                        int index = Array.IndexOf(header.Split(deli), item);

                        columnindexlist.Add(index);
                    }

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = LineStringToArray(line, txtq, deli);

                        if (logic.ToUpper() == "AND")
                        {
                            List<bool> toadd = new List<bool>();
                            foreach (var item in columnindexlist)
                            {
                                if (string.IsNullOrWhiteSpace(splitline[item]) != true && splitline[item].Length > 0)
                                {
                                    toadd.Add(true);
                                }
                                else
                                {
                                    toadd.Add(false);
                                }
                            }

                            if (!toadd.Contains(false))
                            {
                                List<string> valuestocopy = new List<string>();

                                foreach (var item in columnindexlist)
                                {
                                    valuestocopy.Add(splitline[item]);
                                }

                                writefile.WriteLine(string.Join(deli.ToString(), valuestocopy.ToArray()));
                            }
                        }

                        if (logic.ToUpper() == "OR")
                        {
                            List<bool> toadd = new List<bool>();
                            foreach (var item in columnindexlist)
                            {
                                if (string.IsNullOrWhiteSpace(splitline[item]) != true && splitline[item].Length > 0)
                                {
                                    toadd.Add(true);
                                }
                                else
                                {
                                    toadd.Add(false);
                                }
                            }

                            if (toadd.Contains(true))
                            {
                                List<string> valuestocopy = new List<string>();

                                foreach (var item in columnindexlist)
                                {
                                    valuestocopy.Add(splitline[item]);
                                }

                                writefile.WriteLine(string.Join(deli.ToString(), valuestocopy.ToArray()));
                            }
                        }
                    }
                }
            }
        }

        static public void PullBlankEmptyOrZeroValueRecords() // broken af.
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do not remember what this does - Dylan 10/10/2019.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.Write("Id Column Name: ");
            string idcolumn = GetColumn();

            Console.Write("Enter BlankEmptyorZero character: ");
            string valuetofind = Console.ReadLine();

            char blankemptyorzero;
            bool result;
            result = char.TryParse(valuetofind, out blankemptyorzero);

            if (result != true)
            {
                valuetofind = blankemptyorzero.ToString();
            }

            string newfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_blankemptyorzero.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(newfile))
                {

                    string line;
                    int count = 0;
                    int linecount = 0;

                    string header = readfile.ReadLine();
                    writefile.WriteLine(header);

                    while ((line = readfile.ReadLine()) != null)
                    {
                        List<string> foundvalues = new List<string>();
                        int columnindex = ColumnIndex(line, delimiter, idcolumn);

                        int tempvalue = 0;

                        string[] splitline = LineStringToArray(line, txtq, delimiter);

                        for (int x = 0; x <= splitline.Length - 1; x++)
                        {
                            if ((x != columnindex) && (splitline[x] == valuetofind))
                            {
                                foundvalues.Add(splitline[x]);
                                tempvalue++;
                            }
                        }

                        if (tempvalue == splitline.Length - 1)
                        {
                            count++;
                        }

                        if (foundvalues.Count() == splitline.Length - 2) // -1 by default -2 to account for id column.
                        {
                            writefile.WriteLine(line);
                        }

                        linecount++;
                    }

                    Console.WriteLine("BlankEmptyorZero: {0}", count);
                    Console.WriteLine("Total Lines: {0}", linecount);
                    double percent = (double)count / linecount * 100;
                    Console.WriteLine("Percent: {0}%", percent);
                }
            }
        }

        static public void PullRandomSubsetofLengthX()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pulls user designated number of random records from a target file.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.Write("Enter record id column name: ");
            string id = Console.ReadLine().Trim().ToUpper();


            Console.Write("Number of randomly selected records to pull: ");
            long recordstopull = 0;
            if (!Int64.TryParse(Console.ReadLine(), out recordstopull))
            {
                Console.WriteLine("Invalid number");
                return;
            }
            Console.WriteLine();

            string newfile = Directory.GetParent(file) + "\\" + GetFileNameWithoutExtension(file) + "_rsubset_" + recordstopull + ".txt";
            Console.WriteLine();

            long totalrecords = 0;
            using (StreamReader countingread = new StreamReader(file))
            {
                string line = string.Empty;
                while ((line = countingread.ReadLine()) != null)
                {
                    totalrecords++;
                }
            }

            //math
            double dividend = totalrecords / recordstopull;
            int roundeddividend = (int)Math.Round(dividend) - 1;

            Console.WriteLine("Total Records: {0}", totalrecords);
            Console.WriteLine("Skip counter: {0}", roundeddividend);

            //start file loop.
            using (StreamWriter writefile = new StreamWriter(newfile))
            {
                Dictionary<string, int> recordkeeper = new Dictionary<string, int>();

                using (StreamReader readfile = new StreamReader(file))
                {
                    string header = readfile.ReadLine();
                    int idindex = ColumnIndexWithQualifier(header, delimiter, txtq, id);
                    writefile.WriteLine(header);


                    int lineskip = roundeddividend;

                    for (long r = recordstopull; r > 0; r--)
                    {
                        //read lines to skip
                        for (int c = lineskip; c > 0; c--)
                        {
                            readfile.ReadLine();
                        }

                        //readline to copy over
                        string line = readfile.ReadLine();
                        string[] linesplit = SplitLineWithTxtQualifier(line, delimiter, txtq, false);

                        if (!recordkeeper.ContainsKey(linesplit[idindex])) //test if duplicate
                        {
                            recordkeeper.Add(linesplit[idindex], 0); //add id to dictionary checker
                            writefile.WriteLine(line); //write line to new file
                        }
                    }
                }
            }
        }

        static public void PullRecordsWithValueXInColumnY()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pull records with value x in column y.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string moveon = string.Empty;

            while (moveon != "n")
            {
                Console.Write("Enter Column Name with Value: ");
                string columnname = GetColumn();

                Console.Write("Enter Value to find: ");
                string valuetofind = Console.ReadLine().Trim();

                Console.WriteLine();
                Console.Write("Processing...");

                string newfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_" + columnname + "_" + valuetofind + ".txt";

                using (StreamReader readfile = new StreamReader(file))
                {
                    using (StreamWriter writefile = new StreamWriter(newfile))
                    {
                        string header = readfile.ReadLine();
                        string[] headersplit = LineStringToArray(header, txtq, delimiter);
                        int length = headersplit.Length;

                        int columnindex = ColumnIndexNew(header, delimiter, columnname, txtq);

                        writefile.WriteLine(header);

                        string line;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            string[] splitline = LineStringToArray(line, txtq, delimiter);

                            if (splitline[columnindex] == valuetofind)
                            {
                                writefile.WriteLine(line);
                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Pull additional records?: ");
                moveon = Console.ReadLine().ToLower().Trim();
            }
        }

        static public void PullRecordsWithValueInColumn_s()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pulls records with value in user specified column(s). Pulls based on AND/OR logic.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string outfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_foundrecords.txt";

            Console.WriteLine();
            Console.Write("Enter Pipe Delimited Column(s): ");
            string columnsentered = Console.ReadLine().Trim();
            string[] columnarray = columnsentered.Split('|');

            Console.WriteLine();
            Console.Write("Enter logic to be used - (OR/AND): ");
            string logic = Console.ReadLine().Trim();

            Console.WriteLine();
            Console.Write("Processing...");

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(outfile))
                {
                    string header = readfile.ReadLine();
                    writefile.WriteLine(header);

                    List<int> columnindexlist = new List<int>();
                    foreach (var item in columnarray)
                    {
                        int index = ColumnIndexNew(header, delimiter, item, txtq);

                        columnindexlist.Add(index);
                    }

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = LineStringToArray(line, txtq, delimiter);

                        if (logic.ToUpper() == "AND")
                        {
                            List<bool> toadd = new List<bool>();
                            foreach (var item in columnindexlist)
                            {
                                if (string.IsNullOrWhiteSpace(splitline[item]) != true && splitline[item].Length > 0)
                                {
                                    toadd.Add(true);
                                }
                                else
                                {
                                    toadd.Add(false);
                                }
                            }

                            if (!toadd.Contains(false))
                            {
                                writefile.WriteLine(line);
                            }

                        }

                        if (logic.ToUpper() == "OR")
                        {
                            List<bool> toadd = new List<bool>();
                            foreach (var item in columnindexlist)
                            {
                                if (string.IsNullOrWhiteSpace(splitline[item]) != true && splitline[item].Length > 0)
                                {
                                    toadd.Add(true);
                                }
                                else
                                {
                                    toadd.Add(false);
                                }
                            }

                            if (toadd.Contains(true))
                            {
                                writefile.WriteLine(line);
                            }
                        }
                    }
                }
            }
        }

        static public void PullRecordsWithORListofStringorChars()
        {
            // pull records that have a character from the list a user enters
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pulls all records that contain the specific string character sequence entered by the user.");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string pulledrecords = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_pulledrecords.txt";
            string leftovers = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_leftovers.txt";

            Console.WriteLine();
            Console.WriteLine("-Enter space delimited characters or strings to find-");
            Console.Write("Chars: ");

            string enteredchars = Console.ReadLine();
            string[] charstofind = enteredchars.Split(' ');

            using (StreamWriter outfileleftovers = new StreamWriter(leftovers))
            {
                using (StreamWriter outfile = new StreamWriter(pulledrecords))
                {
                    using (StreamReader readfile = new StreamReader(file))
                    {
                        string header = readfile.ReadLine();
                        outfile.WriteLine(header);
                        outfileleftovers.WriteLine(header);

                        string line = string.Empty;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            bool written = false;

                            foreach (string item in charstofind)
                            {
                                if (line.Contains(item) && written == false)
                                {
                                    outfile.WriteLine(line);
                                    written = true;
                                }
                            }

                            if (written == false)
                            {
                                outfileleftovers.WriteLine(line);
                            }
                        }
                    }
                }
            }
        }

        static public void TestColumnNamesFromDefinitionFile()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Compares file header, order of columns, to order of columns in definition files.");
            Console.ResetColor();

            // login to ftp site
            FtpClient client = new FtpClient();
            client.Host = "download.targusinfo.com";
            client.Credentials = new System.Net.NetworkCredential("e1platform", "Tu5wq$m4loPav");
            client.Connect();
            Console.WriteLine("Connected {0}.", client.IsConnected); //https://github.com/robinrodricks/FluentFTP/wiki/FTPS-Connection


            string input = string.Empty;
            string definitionfilepath = string.Empty;

            Console.WriteLine();
            Console.WriteLine("Select definition file:");
            Console.WriteLine("{0,5}{1,-10}", "1. ", "CCNA");
            Console.WriteLine("{0,5}{1,-10}", "2. ", "Chickfila");
            Console.WriteLine("{0,5}{1,-10}", "3. ", "Discount Tire");
            Console.WriteLine("{0,5}{1,-10}", "4. ", "Discover Deposits");
            Console.WriteLine("{0,5}{1,-10}", "5. ", "Entercom ALLHH");
            Console.WriteLine("{0,5}{1,-10}", "6. ", "Entercom");
            Console.WriteLine("{0,5}{1,-10}", "7. ", "Progressive");
            Console.WriteLine("{0,5}{1,-10}", "8. ", "Santander");
            Console.WriteLine("{0,5}{1,-10}", "9. ", "Verizon");
            Console.WriteLine("{0,5}{1,-10}", "10. ", "Edelman - StatSocial");
            Console.WriteLine("{0,5}{1,-10}", "11. ", "michelin");

            Console.WriteLine("{0,5}", "exit");

            Console.WriteLine();
            Console.Write("Definition File: ");
            input = Console.ReadLine().ToUpper();

            switch (input)
            {
                case "1":
                    definitionfilepath = @"/users/data/e1platform/CCNA/nightly/tccc_newcustomers_hh_reload.definition";
                    break;

                case "2":
                    definitionfilepath = @"/users/data/e1platform/chickfila/nightly/cfa_hh_reload.definition";
                    break;

                case "3":
                    definitionfilepath = @"/users/data/e1platform/discounttire/nightly/discounttire_hh_reload.definition";
                    break;

                case "4":
                    definitionfilepath = @"/users/data/e1platform/discover_deposits/nightly/discover_deposits_hh_fixed_reload.definition";
                    break;

                case "5":
                    definitionfilepath = @"/users/data/e1platform/entercom/nightly/entercom_allhh_reload.definition";
                    break;

                case "6":
                    definitionfilepath = @"/users/data/e1platform/entercom/nightly/entercom_hh_reload.definition";
                    break;

                case "7":
                    definitionfilepath = @"/users/data/e1platform/progressive/nightly/progressive_hh_reload.definition";
                    break;

                case "8":
                    definitionfilepath = @"/users/data/e1platform/santander/nightly/santander_hh_reload.definition";
                    break;

                case "9":
                    definitionfilepath = @"/users/data/e1platform/verizon/nightly/verizoncustomer_hh_reload.definition";
                    break;

                case "10":
                    definitionfilepath = @"/users/data/e1platform/edelman/nightly/EDELMAN_STATSOCIAL_HH_reload.definition";
                    break;

                case "11":
                    definitionfilepath = @"/users/data/e1platform/Michelin/nightly/michelin_crm_reload.definition";
                    break;

                default:
                    Console.WriteLine("Not valid input.");
                    TestColumnNamesFromDefinitionFile(); //start over.
                    break;
            }

            //download definition file.
            string tempdefinitionfile = "tempdefintionfile.definition"; //saved in debug folder.
            client.DownloadFile(tempdefinitionfile, definitionfilepath);

            List<string> fileinfo = new List<string>();
            List<string> columnnames = new List<string>();

            using (StreamReader readdefinitionfile = new StreamReader(tempdefinitionfile))
            {
                string line = string.Empty;
                while ((line = readdefinitionfile.ReadLine()) != null)
                {
                    if (line.Contains(".fieldname"))
                    {
                        string[] linevalues = line.Split('=');
                        string columnname = linevalues.Last().Trim();
                        columnnames.Add(columnname);
                    }
                    else
                    {
                        fileinfo.Add(line);
                    }
                }
            }

            List<string> columnnamesupper = new List<string>();
            foreach (var c in columnnames)
            {
                columnnamesupper.Add(c.ToUpper());
            }

            //delete temp definition file.
            if (File.Exists(@"tempdefintionfile.definition"))
            {
                File.Delete(@"tempdefintionfile.definition");
            }

            Console.WriteLine("File to Test.");
            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            using (StreamReader readfile = new StreamReader(file))
            {
                bool matched = true;
                bool morecolumns = false;
                bool lesscolumns = false;

                string header = readfile.ReadLine();
                string[] headersplit = SplitLineWithTxtQualifier(header, delimiter, txtq, false);

                List<string> headersplitupper = new List<string>();
                foreach (var c in headersplit)
                {
                    headersplitupper.Add(c.ToUpper());
                }

                if (columnnamesupper.Count() == headersplitupper.Count())
                {
                    Console.WriteLine("File number of columns EQUAL definition columns.");

                    foreach (var column in headersplit)
                    {
                        int index = Array.IndexOf(headersplit, column);

                        if (column.ToUpper() != columnnamesupper[index].ToUpper()) //upper
                        {
                            Console.WriteLine("file column -{2}- no match: {0} - {1}", column, columnnames[index], index + 1);
                            matched = false;
                        }
                    }
                }
                else if (columnnamesupper.Count() <= headersplitupper.Count())
                {
                    int columndiff = headersplitupper.Count() - columnnamesupper.Count();

                    Console.WriteLine("File number of columns GREATER THAN definition columns.");
                    Console.WriteLine("{0} - extra columns in new file.", columndiff);

                    int columncount = 1;
                    foreach (var column in headersplit)
                    {
                        if (!columnnamesupper.Contains(column.ToUpper())) //upper
                        {
                            Console.WriteLine("Column {1}, not in definition file: {0}", column, columncount);
                        }
                        columncount += 1;
                    }

                    morecolumns = true;
                }
                else
                {
                    Console.WriteLine("File number of columns LESS THAN definition columns.");

                    int columncount = 1;
                    foreach (var column in columnnamesupper)
                    {
                        if (!headersplitupper.Contains(column))
                        {
                            Console.WriteLine("Column {1}, not in target file: {0}", column, columncount);
                        }
                        columncount += 1;
                    }

                    lesscolumns = true;
                }

                if (matched == false) //same number of columns but different order or +/- column.
                {
                    Console.Write("Generating new .definition from file headers? (y/n): ");
                    string yesno = Console.ReadLine().ToUpper();

                    if (yesno.ToUpper() == "y".ToUpper())
                    {
                        Console.Write("Keep definition file column names? (y/n): ");
                        string keepdefinitioncolumn = Console.ReadLine().ToUpper();

                        if (keepdefinitioncolumn == "y".ToUpper())
                        {
                            for (int i = 0; i < headersplit.Count(); i++)
                            {
                                if (headersplit[i].ToUpper() != columnnames[i].ToUpper())
                                {
                                    headersplit[i] = columnnames[i].ToUpper();
                                }
                            }
                        }

                        using (StreamWriter newdefinitionfile = new StreamWriter(GetDesktopDirectory() + "\\" + definitionfilepath.Split('/').Last()))
                        {
                            foreach (var value in fileinfo)
                            {
                                newdefinitionfile.WriteLine(value);
                            }

                            int columnnumber = 1;
                            foreach (var column in headersplit)
                            {
                                string linebuilder = "column" + columnnumber + ".fieldname = ";
                                newdefinitionfile.WriteLine(linebuilder + column);
                                columnnumber += 1;
                            }
                        }

                    }
                }

                if (morecolumns == true || lesscolumns == true)
                {
                    Console.Write("Generating list of columns from target file headers? (y/n): ");
                    string yesno = Console.ReadLine().ToUpper();

                    if (yesno.ToUpper() == "y".ToUpper())
                    {
                        using (StreamWriter newdefinitionfile = new StreamWriter(GetDesktopDirectory() + "\\newcolumnlistfordefinitionfile.txt"))
                        {
                            newdefinitionfile.WriteLine("Target file column List");
                            newdefinitionfile.WriteLine();
                            newdefinitionfile.WriteLine();
                            newdefinitionfile.WriteLine();

                            foreach (var value in fileinfo)
                            {
                                newdefinitionfile.WriteLine(value);
                            }

                            int columnnumber = 1;
                            foreach (var column in headersplit)
                            {
                                string linebuilder = "column" + columnnumber + ".fieldname = ";
                                newdefinitionfile.WriteLine(linebuilder + column);
                                columnnumber += 1;
                            }
                        }
                    }
                }


            }

        }

        // Client Specific Tasks
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
        static public void CSTProfileIDMapping() // not finished
        {
            //maps new profile names from first file with second file names/ids/info to new file.

            //old profiles - with names changed.
            Console.WriteLine("Current Profile List: ");
            string old_file = GetAFile();
            char delimiter1 = GetDelimiter();
            Console.Write("Profile Id column name: ");
            string profile_id1 = Console.ReadLine();
            Console.Write("Profile Name column name: ");
            string profile_name1 = Console.ReadLine();

            profile_id1 = profile_id1.Trim().ToUpper();
            profile_name1 = profile_name1.Trim().ToUpper();

            //new profiles.
            Console.WriteLine();
            Console.WriteLine("NEW Profile List: ");
            string new_file = GetAFile();
            char delimiter2 = GetDelimiter();
            Console.Write("Profile Id column name: ");
            string profile_id2 = Console.ReadLine();
            Console.Write("Profile Name column name: ");
            string profile_name2 = Console.ReadLine();

            profile_id2 = profile_id2.Trim().ToUpper();
            profile_name2 = profile_name2.Trim().ToUpper();

            string new_list_file = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(new_file) + "_newnames.txt";

            Dictionary<string, string> file1_dict = new Dictionary<string, string>();
            Dictionary<string, string> file2_dict = new Dictionary<string, string>();
            //int key_count = 0;

            string[] current_prefixes = { "S16", "U17Q2", "I17Q1P", "I17Q1V", "N15", "R13Q4", "E17Q1" };
            string[] new_prefixes = { "S16", "U18Q2", "I18Q1P", "I18Q1V", "N16", "R13Q4", "E18Q1" };

            string header = string.Empty;

            //------------------------------------------
            using (StreamReader file1 = new StreamReader(old_file))
            {
                //2016 file
                // if contains 1string 16 or 17. change. to 16 and 18 respectively



                using (StreamReader file2 = new StreamReader(new_file))
                {
                    using (StreamWriter write_file = new StreamWriter(new_list_file))
                    {


                    }
                }
            }
        }

        static public void CSTUsageMetricsFilter() //mostly finished
        {

            Console.Write("File: ");
            string File = Console.ReadLine();

            string new_file = GetDesktopDirectory() + "\\neustar_users.txt";

            using (StreamWriter newfile = new StreamWriter(new_file))
            {
                using (StreamReader file = new StreamReader(File))
                {

                    string line;
                    //string Email = "@neustar.biz";
                    //string Email2 = "@targusinfo";
                    //string E1support = "E1support@neustar.biz";
                    //string e1support = "e1support@team.neustar";
                    //string e1support2 = "e1support@neustar.biz";
                    //string Description = "Neustar";
                    //string Description2 = "neustar";

                    string[] filter = new string[] { "neustar.biz", "targusinfo", "team.neustar" };

                    while ((line = file.ReadLine()) != null)
                    {
                        if (!line.Contains(filter[0]) || !line.Contains(filter[1]) || !line.Contains(filter[2]))
                        {
                            newfile.WriteLine(line);
                        }
                    }
                }
            }

        }

        static public void BGToZipUrbanicityAverage() //read for info.
        {
            // input file columns: bg name| bg id| urbanicity code| urbanicity label| zip code code (parent zip)

            // creates a dictionary to store all urbanicity code per sip code into a dict(string, int list[])
            // values in dict int list will be averaged and then output to a new file, columns: zipcode| urbaincity code

            //Dictionary<string, string> first_IDS = new Dictionary<string, string>();

            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }

            string new_file = GetDesktopDirectory() + "\\zip_urbanicity.txt";

            Console.Write("Processing...");

            Dictionary<string, List<string>> zip_codes = new Dictionary<string, List<string>>();

            string header;



            using (StreamReader readfile = new StreamReader(file))
            {
                string lines;

                header = readfile.ReadLine();

                string[] values = new string[] { "0", "1", "2", "3", "4", "5" };

                while ((lines = readfile.ReadLine()) != null)
                {
                    string[] splitline = lines.Split(split_char);

                    string zip_code_code = splitline[4];
                    string urbanicity_code = splitline[2];

                    // dict key = zip code, add urbanicity code.

                    // check for existing zip code (key)
                    if (!zip_codes.ContainsKey(zip_code_code))
                    {
                        // if it doesnt exist, add key and add new list to that key
                        zip_codes.Add(zip_code_code, new List<string>());

                        if (!values.Contains(urbanicity_code))
                        {
                            urbanicity_code = "0";
                        }

                        // add to the string list (dict value)
                        zip_codes[zip_code_code].Add(urbanicity_code);

                    }
                    else
                    {
                        if (!values.Contains(urbanicity_code))
                        {
                            urbanicity_code = "0";
                        }
                        // dictionary["key"].Add("string to your list");
                        zip_codes[zip_code_code].Add(urbanicity_code);
                    }

                }
            }

            using (StreamWriter writefile = new StreamWriter(new_file))
            {
                writefile.WriteLine("Zip_Code_Code|Zip_Code_Name|Urbanicity_Score");

                int[] urban_codes = new int[] { };

                int average_code = 0;

                foreach (KeyValuePair<string, List<string>> pair in zip_codes)
                {
                    string[] codes = pair.Value.ToArray();

                    string new_zip = pair.Key;

                    List<int> list = new List<int>();

                    foreach (string val in codes)
                    {
                        // add new int values to list.

                        int number;
                        int.TryParse(val, out number);

                        list.Add(number);

                        urban_codes = list.ToArray();
                    }

                    average_code = (SumOfIntArray(urban_codes) / urban_codes.Length);

                    string write_code = average_code.ToString();

                    // write new line to file.
                    writefile.WriteLine("{0}{1}{2}{3}{4}", new_zip, "|", new_zip, "|", write_code);
                }

            }

        }

        static public void BehaviorAnalyzerSorting() //used for HBO & WB deliverable.
        {
            // take the output of the Descibe Targets Module in E1 and reformat it.
            //    specifically, find the highest indexing segment for each Profile.
            // output:
            //    profile, profile_category, profile_type (left blank here), Segment, index, %pen

            // read line > line => string array > 2 new arrays, index & pen arrays
            //       array index - 1 is segment number.
            // find the max index value. string => int array. find index of the max value. 
            // new string => index, segment index, seg %pen 
            // add profile column things to new string.
            //pring line to new file. 

            //int[] anArray = { 1, 5, 2, 7 };

            //// Finding max
            //int m = anArray.Max();

            //// Positioning max
            //int p = Array.IndexOf(anArray, m);

            // FILE FORMAT!!!!!!!!!!!!!!!!!!!!!!!!!
            //    column_1 (ei, profile name), column_2 , column_3, s1 index, s1 pen, ... s172 index s172 pen
            // format will almost be this straight from describe targets
            // data in columns 1-3 will be preserved and output. 
            // result will be --> "attribute_name, attribute_category, attribute_type, segment, index, %pen"
            // File must have a header.


            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }

            string new_file = GetDesktopDirectory() + "\\greatest_index_per_profile.txt";

            Console.Write("Processing...");

            //Dictionary<string, List<string>> zip_codes = new Dictionary<string, List<string>>();

            // header of the file
            string header;


            using (StreamReader readfile = new StreamReader(file))
            {

                string lines;

                header = readfile.ReadLine();

                using (StreamWriter writefile = new StreamWriter(new_file))
                {
                    writefile.WriteLine("attribute_name, attribute_category, attribute_type, segment, index, %pen");

                    while ((lines = readfile.ReadLine()) != null)
                    {
                        //split arrays.
                        string[] split_lines = lines.Split(split_char);

                        //List<int> termsList = new List<int>();

                        List<string> indexes = new List<string>();
                        List<string> pen_rates = new List<string>();

                        for (int x = 3; x <= split_lines.Length - 1; x++)
                        {
                            indexes.Add(split_lines[x]);

                            x++;

                            pen_rates.Add(split_lines[x]);
                        }

                        string[] index_vals = indexes.ToArray();
                        string[] pen_rates_vals = pen_rates.ToArray();

                        // string array to int array.
                        int[] index_arr = Array.ConvertAll(index_vals, int.Parse);

                        int max_val = index_arr.Max();

                        int position = Array.IndexOf(index_arr, max_val);

                        // segment, index, %pen

                        string index = max_val.ToString();
                        string pen = pen_rates[position];

                        position = position + 1;
                        string segment = position.ToString();

                        List<string> new_line_vals = new List<string>();

                        for (int i = 0; i <= 2; i++)
                        {
                            new_line_vals.Add(split_lines[i]);
                        }

                        new_line_vals.Add(segment);
                        new_line_vals.Add(index);
                        new_line_vals.Add(pen);

                        string[] new_line_arr = new_line_vals.ToArray();

                        string new_line = string.Join(delimeter, new_line_arr);

                        writefile.WriteLine(new_line);
                    }

                }

            }


        }


        // Custom one use methods
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
        static public void FindDatesBeforeX() //custom, one use. needsto be standardized.
        {
            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }

            //Console.Write("Enter date as yyyy-dd-MM: ");
            //string entered_date = Console.ReadLine().Trim();

            //string pattern = "yyyy-MM-dd";
            //DateTime user_date;
            //if (!DateTime.TryParseExact(entered_date, pattern, null, System.Globalization.DateTimeStyles.None, out user_date))
            //{
            //   Console.WriteLine("Invalid Date.");
            //   return;
            //}

            //Console.Write("Enter Column Name: ");
            //string column = Console.ReadLine();
            //column = column.ToUpper();

            Console.Write("Processing...");

            string outfile = GetDesktopDirectory() + "\\old_dates.txt";

            using (StreamReader read_file = new StreamReader(file))
            {
                using (StreamWriter new_file = new StreamWriter(outfile))
                {
                    string header = read_file.ReadLine();
                    string[] split_header = header.Split(split_char);

                    new_file.WriteLine(header);

                    int index = 5;
                    //string date1 = "2017-04-01";

                    //string[] date1 = new string[] { "2017", "04", "01" };

                    int[] date1 = new int[] { 2017, 4, 1 };

                    string lines;

                    while ((lines = read_file.ReadLine()) != null)
                    {
                        string[] line_array = lines.Split(split_char);
                        int[] date2 = StringToIntArray(line_array[index], '-');

                        //pattern "yyyy-MM-dd";
                        if (date2[0] < date1[0])
                        {
                            new_file.WriteLine(lines);
                        }
                        else if (date2[0] == date1[0] && date2[1] < date1[1])
                        {
                            new_file.WriteLine(lines);
                        }
                        else if (date2[0] == date1[0] && date2[1] == date1[1] && date2[2] <= date1[2])
                        {
                            new_file.WriteLine(lines);
                        }
                    }

                }
            }

        }

        static public void FixedWidthToPipeDelimited() // needs work.
        {
            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }

            string new_file = "C:\\Users\\dwhite\\desktop\\delimited_file.txt";

            Console.Write("Processing...");

            // open file.
            //    read line -> string.
            //    string -> substring
            //       substring -> string[]
            //       string.join
            //       write line to new file
            // close file




            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(new_file))
                {


                    string lines;

                    while ((lines = readfile.ReadLine()) != null)
                    {
                        string field1 = lines.Substring(1, 8).Trim();
                        string field2 = lines.Substring(9, 10).Trim();
                        string field3 = lines.Substring(11, 11).Trim();
                        string field4 = lines.Substring(12, 19).Trim();
                        string field5 = lines.Substring(20, 29).Trim();
                        string field6 = lines.Substring(30, 119).Trim();
                        string field7 = lines.Substring(120, 139).Trim();
                        string field8 = lines.Substring(140, 159).Trim();
                        string field9 = lines.Substring(160, 199).Trim();
                        string field10 = lines.Substring(200, 209).Trim();
                        string field11 = lines.Substring(210, 210).Trim();
                        string field12 = lines.Substring(211, 250).Trim();
                        string field13 = lines.Substring(251, 290).Trim();
                        string field14 = lines.Substring(291, 320).Trim();
                        string field15 = lines.Substring(321, 322).Trim();
                        string field16 = lines.Substring(323, 332).Trim();
                        string field17 = lines.Substring(333, 336).Trim();
                        string field18 = lines.Substring(337, 340).Trim();
                        string field19 = lines.Substring(341, 341).Trim();
                        string field20 = lines.Substring(342, 343).Trim();
                        string field21 = lines.Substring(344, 353).Trim();
                        string field22 = lines.Substring(354, 354).Trim();
                        string field23 = lines.Substring(355, 355).Trim();
                        string field24 = lines.Substring(356, 363).Trim();
                        string field25 = lines.Substring(364, 364).Trim();
                        string field26 = lines.Substring(365, 366).Trim();
                        string field27 = lines.Substring(367, 375).Trim();
                        string field28 = lines.Substring(376, 405).Trim();
                        string field29 = lines.Substring(406, 413).Trim();
                        string field30 = lines.Substring(414, 414).Trim();
                        string field31 = lines.Substring(415, 416).Trim();
                        string field32 = lines.Substring(417, 417).Trim();
                        string field33 = lines.Substring(418, 419).Trim();
                        string field34 = lines.Substring(420, 427).Trim();
                        string field35 = lines.Substring(428, 431).Trim();
                        string field36 = lines.Substring(432, 433).Trim();
                        string field37 = lines.Substring(434, 435).Trim();
                        string field38 = lines.Substring(436, 443).Trim();
                        string field39 = lines.Substring(444, 446).Trim();
                        string field40 = lines.Substring(447, 447).Trim();
                        string field41 = lines.Substring(448, 459).Trim();
                        string field42 = lines.Substring(460, 500).Trim();

                        string[] values = new string[] { field1, field2, field3, field4, field5, field6, field7, field8, field9, field10, field11, field12, field13, field14, field15, field16, field17, field18, field19, field20, field21, field22, field23, field24, field25, field26, field27, field28, field29, field30, field31, field32, field33, field34, field35, field36, field37, field38, field39, field40, field41, field42 };

                        string newline = string.Join(delimeter, values);

                        newfile.WriteLine(newline);

                    }

                }
            }


        }

        static public void ReadTwoLines() //what does this do? 
        {
            Console.Write("File: ");
            string file = Console.ReadLine();

            string new_file = GetDesktopDirectory() + "\\new_lines.txt";

            Console.Write("Processing...");

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(new_file))
                {
                    string line_1;
                    string line_2;

                    while ((line_1 = readfile.ReadLine()) != null)
                    {
                        line_2 = readfile.ReadLine();

                        string new_line = "[" + line_1 + ", " + line_2 + "] ";

                        newfile.WriteLine(new_line);

                    }
                }
            }
            ReadTwoLines();
        }

        static public void FindIDsInTwoFiles() //compares two lists of IDs. two files each with one column of IDs.
        {
            //both files must be a list of the IDs.         

            Console.Write("File: "); // memeber_id list.
            string file = Console.ReadLine();

            Console.Write("File: ");
            string file2 = Console.ReadLine();

            //Console.Write("Delimeter: ");
            //string delimeter = Console.ReadLine();
            //char split_char;
            //if (!char.TryParse(delimeter, out split_char))
            //{
            //   Console.Write("Invalid Char");
            //   return;
            //}

            string new_file = GetDesktopDirectory() + "\\new_lines.txt";

            Console.Write("Processing...");

            Dictionary<string, string> first_IDS = new Dictionary<string, string>();
            Dictionary<string, string> second_IDS = new Dictionary<string, string>();

            Dictionary<string, int> both_IDS = new Dictionary<string, int>();

            int count = 0;

            using (StreamReader readfile = new StreamReader(file))
            {
                string lines;
                string lines2;
                while ((lines = readfile.ReadLine()) != null)
                {
                    if (!first_IDS.ContainsKey(lines))
                    {
                        first_IDS.Add(lines, "0");
                    }
                }

                using (StreamReader readfile2 = new StreamReader(file2))
                {
                    while ((lines2 = readfile2.ReadLine()) != null)
                    {
                        if (!first_IDS.ContainsKey(lines2))
                        {
                            second_IDS.Add(lines2, "0");
                        }
                        else
                        {
                            both_IDS.Add(lines2, 1);
                            count++;
                        }
                    }
                    Console.WriteLine(count);
                    using (StreamWriter newfile = new StreamWriter(new_file))
                    {
                        List<string> double_keys = both_IDS.Keys.ToList();

                        foreach (var v in double_keys)
                        {
                            newfile.WriteLine(v);
                        }
                        Console.WriteLine("{0} - duplicate keys", count);
                    }
                }
            }
        }

        static public void Dedupesaveextravalues()
        {
            string file = GetAFile();
            string column = GetColumn();
            char delimeter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string newfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_uniquekeyrows.txt";
            string newfileheader = string.Empty;

            Dictionary<string, List<string>> rowkeys = new Dictionary<string, List<string>>();

            using (StreamReader readfile = new StreamReader(file))
            {
                string header = readfile.ReadLine();
                List<string> headerlinebuilder = new List<string>();
                if (header.Contains(txtq))
                {
                    headerlinebuilder.AddRange(SplitLineWithTxtQualifier(header, delimeter, txtq, false));
                }
                else
                {
                    headerlinebuilder.AddRange(header.Split(delimeter));
                }

                // PACU 2018, PACU 2017, ORMC Reg, ORMC 2016, ORMC 2015
                headerlinebuilder.Add("Extra Value1");
                headerlinebuilder.Add("Extra Value2");
                headerlinebuilder.Add("Extra Value3");
                headerlinebuilder.Add("Extra Value4");
                headerlinebuilder.Add("Extra Value5");
                newfileheader = string.Join(delimeter.ToString(), headerlinebuilder.ToArray());

                int columnid = ColumnIndex(header, delimeter, column);

                int count = 0;
                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    Console.Write("\r {0}", count++);

                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, delimeter, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(delimeter));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    if (!rowkeys.ContainsKey(splitline[columnid]))
                    {
                        List<string> templist = new List<string>();
                        for (int i = 0; i < splitline.Length; i++)
                        {
                            if (i != columnid)
                            {
                                templist.Add(splitline[i]);
                            }
                        }

                        rowkeys.Add(splitline[columnid], templist);
                    }
                    else // new stuff.
                    {
                        //CUSTID,pid,File Identifier
                        // save file identifier. 
                        // PACU 2018, PACU 2017, ORMC Reg, ORMC 2016, ORMC 2015
                        string valuetotest = splitline[2];

                        //List<string> values = new List<string> {"PACU 2018", "PACU 2017", "ORMC Reg", "ORMC 2016", "ORMC 2015"};

                        if (!rowkeys[splitline[columnid]].Contains(valuetotest))
                        {
                            rowkeys[splitline[columnid]].Add(valuetotest);
                        }
                    }
                }

                using (StreamWriter writefile = new StreamWriter(newfile))
                {
                    writefile.WriteLine(newfileheader);



                    foreach (var key in rowkeys.Keys)
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(key);
                        foreach (var item in rowkeys[key])
                        {
                            linebuilder.Add(item);
                        }

                        writefile.WriteLine(string.Join(delimeter.ToString(), linebuilder.ToArray()));
                    }

                }
            }


        }

        static public void VlookupKeepNotFoundFromOriginalFile()
        {
            //output char to elminate issues with , tabs etc...
            char newdelimiter = '|';

            //file that is being appeneded.
            Console.WriteLine("File being appended: ");
            string ogfile = GetAFile();
            char ogdelimiter = GetDelimiter();
            Console.Write("ID Column Name: ");
            string ogidcolumn = Console.ReadLine().Trim().ToUpper();

            //file with data to append.
            Console.WriteLine("File with data to append: ");
            string toappendfile = GetAFile();
            char toappenddelimiter = GetDelimiter();
            Console.Write("ID Column Name: ");
            string toappendidcolumn = Console.ReadLine().Trim().ToUpper();

            //Dictionary for data from append data file.
            Dictionary<string, string> ToAppendValues = new Dictionary<string, string>();

            //List of headers from data to append file.
            List<string> toappendheaderstorage = new List<string>();

            //new file.
            string appendedfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(ogfile) + "_appended.txt";

            //qualifier?????
            Console.Write("Files have txt qualifier? (y/n): ");
            string answer = Console.ReadLine().ToUpper().Trim();

            if (answer == "Y")
            {
                char qualifier = GetTXTQualifier();

                //read to append data file.
                using (StreamReader toappenddata = new StreamReader(toappendfile))
                {
                    string header = toappenddata.ReadLine();
                    string[] headervalues = SplitLineWithTxtQualifier(header, toappenddelimiter, qualifier, true);
                    string[] cleanheader = ArrayWithNoTxtQualifier(headervalues, qualifier);

                    //idcolumn index
                    int toappendidcolumnindex = ColumnIndexWithQualifier(header, toappenddelimiter, qualifier, toappendidcolumn);

                    //add headers to storage list.
                    foreach (var h in cleanheader)
                    {
                        if (h != cleanheader[toappendidcolumnindex])
                        {
                            toappendheaderstorage.Add(h);
                        }
                    }

                    //read site_ids into dict.
                    string toappendline = string.Empty;
                    while ((toappendline = toappenddata.ReadLine()) != null)
                    {
                        string[] toappendsplitline = SplitLineWithTxtQualifier(toappendline, toappenddelimiter, qualifier, true);
                        string[] cleantoappendsplitline = ArrayWithNoTxtQualifier(toappendsplitline, qualifier);

                        if (!ToAppendValues.ContainsKey(cleantoappendsplitline[toappendidcolumnindex]))
                        {
                            //add not idcolumn to list.
                            List<string> dictvalues = new List<string>();
                            foreach (var s in cleantoappendsplitline)
                            {
                                if (s != cleantoappendsplitline[toappendidcolumnindex])
                                {
                                    dictvalues.Add(s);
                                }
                            }
                            //list -> array -> string. with new delimiter.
                            string newdictvalues = string.Join(newdelimiter.ToString(), dictvalues.ToArray()); // pipe delimited string.

                            //add to dictionary.
                            ToAppendValues.Add(cleantoappendsplitline[toappendidcolumnindex], newdictvalues);
                        }
                    }
                }

                //read the file to be appended.
                using (StreamReader filebeingappended = new StreamReader(ogfile))
                {
                    using (StreamWriter newfile = new StreamWriter(appendedfile))
                    {
                        string ogheader = filebeingappended.ReadLine();
                        string[] ogheadervalues = SplitLineWithTxtQualifier(ogheader, ogdelimiter, qualifier, false);

                        //clean headers
                        ogheadervalues = ArrayWithNoTxtQualifier(ogheadervalues, qualifier);

                        //write new header to new file. Using new delimiter.
                        string newfileheader = string.Join(newdelimiter.ToString(), ogheadervalues) + newdelimiter.ToString() + string.Join(newdelimiter.ToString(), toappendheaderstorage.ToArray());
                        newfile.WriteLine(newfileheader);

                        //Find idcolumn index.
                        int ogidcolumnindex = ColumnIndexWithQualifier(ogheader, ogdelimiter, qualifier, ogidcolumn);
                        //int length = ogheadervalues.Length;

                        //read ogfile.
                        string ogline = string.Empty;
                        try
                        {
                            while ((ogline = filebeingappended.ReadLine()) != null)
                            {
                                string[] ogsplitline = SplitLineWithTxtQualifier(ogline, ogdelimiter, qualifier, false);
                                //clean qualifiers our of data
                                ogsplitline = ArrayWithNoTxtQualifier(ogsplitline, qualifier);

                                if (ToAppendValues.ContainsKey(ogsplitline[ogidcolumnindex]))
                                {
                                    string ognewline = string.Join(newdelimiter.ToString(), ogsplitline);

                                    string newfilewriteline = ognewline + newdelimiter.ToString() + ToAppendValues[ogsplitline[ogidcolumnindex]];

                                    //write new line.
                                    newfile.WriteLine(newfilewriteline);
                                }
                                else // added to include non matches in file being appended.
                                {
                                    newfile.WriteLine(string.Join(newdelimiter.ToString(), ogsplitline));
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                    }
                }

            }
            else
            {
                //NO TXT qualifier.
                //read to append data file.
                using (StreamReader toappenddata = new StreamReader(toappendfile))
                {
                    string header = toappenddata.ReadLine();
                    string[] headervalues = header.Split(toappenddelimiter);

                    //idcolumn index
                    int toappendidcolumnindex = ColumnIndex(header, toappenddelimiter, toappendidcolumn);

                    //add headers to storage list.
                    foreach (var h in headervalues)
                    {
                        if (h != headervalues[toappendidcolumnindex])
                        {
                            toappendheaderstorage.Add(h);
                        }
                    }

                    //read site_ids into dict.
                    string toappendline = string.Empty;
                    while ((toappendline = toappenddata.ReadLine()) != null)
                    {
                        string[] toappendsplitline = toappendline.Split(toappenddelimiter);

                        if (!ToAppendValues.ContainsKey(toappendsplitline[toappendidcolumnindex]))
                        {
                            //add not idcolumn to list.
                            List<string> dictvalues = new List<string>();
                            foreach (var s in toappendsplitline)
                            {
                                if (s != toappendsplitline[toappendidcolumnindex])
                                {
                                    dictvalues.Add(s);
                                }
                            }
                            //list -> array -> string. with new delimiter.
                            string newdictvalues = string.Join(newdelimiter.ToString(), dictvalues.ToArray()); // pipe delimited string.

                            //add to dictionary.
                            ToAppendValues.Add(toappendsplitline[toappendidcolumnindex], newdictvalues);
                        }
                    }
                }

                //read the file to be appended.
                using (StreamReader filebeingappended = new StreamReader(ogfile))
                {
                    using (StreamWriter newfile = new StreamWriter(appendedfile))
                    {
                        string ogheader = filebeingappended.ReadLine();
                        string[] ogheadervalues = ogheader.Split(ogdelimiter);

                        //write new header to new file. Using new delimiter.
                        string newfileheader = string.Join(newdelimiter.ToString(), ogheadervalues) + newdelimiter.ToString() + string.Join(newdelimiter.ToString(), toappendheaderstorage.ToArray());
                        newfile.WriteLine(newfileheader);

                        //Find idcolumn index.
                        int ogidcolumnindex = ColumnIndex(ogheader, ogdelimiter, ogidcolumn);
                        //int length = ogheadervalues.Length;

                        //read ogfile.
                        string ogline = string.Empty;
                        try
                        {
                            while ((ogline = filebeingappended.ReadLine()) != null)
                            {
                                string[] ogsplitline = ogline.Split(ogdelimiter);

                                if (ToAppendValues.ContainsKey(ogsplitline[ogidcolumnindex]))
                                {
                                    string ognewline = string.Join(newdelimiter.ToString(), ogsplitline);

                                    string newfilewriteline = ognewline + newdelimiter.ToString() + ToAppendValues[ogsplitline[ogidcolumnindex]];

                                    //write new line.
                                    newfile.WriteLine(newfilewriteline);
                                }
                                else // added to include non matches in file being appended.
                                {
                                    newfile.WriteLine(string.Join(newdelimiter.ToString(), ogsplitline));
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                    }
                }

            }

        }

        static public void AppendValueToEachLineInFile()
        {
            Console.WriteLine();
            Console.WriteLine("Append Value to Each Line in File.");

            string file = GetAFile();
            char delimeter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string appendedfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_appended.txt";

            Console.WriteLine();

            Console.Write("Value to append: ");
            string value = Console.ReadLine().Trim().ToUpper();

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter outfile = new StreamWriter(appendedfile))
                {
                    string header = readfile.ReadLine();
                    string newheader = header + delimeter.ToString() + "Appendedvalue";

                    outfile.WriteLine(newheader);

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        outfile.WriteLine(line + delimeter.ToString() + value);
                    }
                }
            }
        }

        static public void FormatDateColumn() //changes date format. uses user defined original format to convert to mm/dd/yyyy 
        {
            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string columnname = GetColumn(); //toupper,trim,removed"
            string newfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_" + columnname + ".txt";

            using (StreamWriter writefile = new StreamWriter(newfile))
            {
                using (StreamReader readfile = new StreamReader(file))
                {
                    string header = readfile.ReadLine();
                    writefile.WriteLine(header);
                    string[] columns = LineStringToArray(header, txtq, delimiter);
                    int length = columns.Length;

                    int columnindex = ColumnIndexNew(header, delimiter, columnname, txtq);

                    //Get Date format.
                    Console.WriteLine("Accepts formats user defined format.");
                    Console.WriteLine("Outputs: MM/DD/YYYY");

                    Console.Write("Enter Date Format:");
                    string date_format = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("Processing...");

                    //string pattern = "MM/DD/YYYY";
                    string line = string.Empty;

                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] linesplit = LineStringToArray(line, txtq, delimiter);

                        string date = linesplit[columnindex].Replace(delimiter.ToString(), string.Empty);

                        DateTime parsedDate;
                        CultureInfo originalCulture = new CultureInfo("fr-FR");

                        if (DateTime.TryParseExact(date, date_format, null, DateTimeStyles.None, out parsedDate))
                        {
                            //converted_date = parsedDate.ToString();
                            //string new_format = parsedDate.ToShortDateString();
                            string newformat = parsedDate.ToString("mm/dd/yyyy");
                            linesplit[columnindex] = newformat;
                            string delimitier = delimiter.ToString();
                            string newline = string.Join(delimitier, linesplit);

                            writefile.WriteLine(newline);
                        }
                        else
                        {
                            Console.WriteLine("Unable to convert '{0}' to date and time.", date);
                        }
                    }
                }
            }
        }

        static public void FormatZipCodesAddLeadingZeroes()
        {
            Console.WriteLine("Enter File and Zip Code Column Name That Needs to be Reformatted.");
            Console.WriteLine();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string zipcolumn = GetColumn();
            string formattedfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_zipformatted.txt";

            int padded = 0;

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(formattedfile))
                {
                    string header = readfile.ReadLine();
                    writefile.WriteLine(header);
                    int columnindex = ColumnIndexNew(header, delimiter, zipcolumn, txtq);

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = LineStringToArray(line, txtq, delimiter);

                        //test zipcolumn
                        string zipcode = splitline[columnindex].Trim().Replace("\"", string.Empty);

                        if ((zipcode.Length != 5) && (string.IsNullOrWhiteSpace(zipcode) == false))
                        {
                            string fixedzip = zipcode.PadRight(5, '0');

                            splitline[columnindex] = fixedzip;
                            padded++;
                        }

                        writefile.WriteLine(string.Join(delimiter.ToString(), splitline));
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("{0} - Zip Codes Fixed", padded);
        }

        static public void NumericValueCheck() // checks for number value in user defined column.
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.ResetColor();

            string file = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            string processcolumn = string.Empty;
            while (processcolumn != "n" || processcolumn != "N")
            {
                Console.Write("Enter Column Name: ");
                string column = Console.ReadLine();

                string onlynumbers = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_" + column + ".txt";

                using (StreamReader readfile = new StreamReader(file))
                {
                    using (StreamWriter writefile = new StreamWriter(onlynumbers))
                    {
                        string header = readfile.ReadLine();

                        string[] columns = LineStringToArray(header, txtq, delimiter);
                        int length = columns.Length;

                        int col = 0;

                        for (int x = 0; x < length - 1; x++)
                        {
                            if (column == columns[x].ToUpper().Replace(delimiter.ToString(), string.Empty))
                            {
                                col = x;
                            }
                        }
                        writefile.WriteLine(header);

                        string line = string.Empty;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            string[] splitline = LineStringToArray(line, txtq, delimiter);

                            int number = 0;
                            if (!int.TryParse(splitline[col], out number))
                            {
                                writefile.WriteLine(line);
                            }
                        }
                    }
                }
                Console.Write("Another Column (y/n): ");
                processcolumn = Console.ReadLine();
            }
        }

        static public void SwitchDateFormatInColumns()
        {
            // accepts user input date foramat to change
            // accepts user input for new date format to use

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Change Date Format in target column(s)");
            Console.ResetColor();

            Console.WriteLine("-Target File-");
            string file = GetAFile();

            char delimeter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.Write("-Enter Pipe \"|\" delimited columns to change date format in.-");
            string enteredcolumnnames = Console.ReadLine();
            string[] columnnames = enteredcolumnnames.Split('|');

            foreach (var column in columnnames) //clean
            {
                column.Trim().ToUpper();
            }

            Console.Write("Enter date format from file: ");
            string dateformat = Console.ReadLine();

            Console.Write("Enter new date format: ");
            string newdateformat = Console.ReadLine();




        }


        // Michelin Monthly File Testing
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
        static void MichelinMonthlyFileCleaner()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("This is to test the Monthly US files for Michelin.");
            Console.WriteLine();
            Console.WriteLine("Please be sure to only run this program from your desktop.");
            Console.ResetColor();

            string choice = string.Empty;
            while (choice != "exit" || choice != "Exit")
            {
                Console.WriteLine();
                Console.WriteLine("Enter Country you would like to test: ");
                Console.WriteLine("{0,5}{1,-10}", "1. ", "Test US Files");
                Console.WriteLine("{0,5}{1,-10}", "2. ", "Test Canada Files");
                Console.WriteLine();
                Console.WriteLine("\"exit\" - Closes the program.");
                Console.WriteLine();
                Console.Write("Your choice: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        MichelinTestUSMonthlyFileFormats();
                        break;

                    case "2":
                        MichelinCanadaTestMontlyFileFormats();
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static public void MichelinTestUSMonthlyFileFormats() // michelin monthly file formatting.
        {

            // EDIT NOTES:
            // 12/5/18 - added line = line.Replace(",", string.Empty); to each while read line statement. this is to remove all , in the data to avoid conflicts in the e1 platform data formating.


            // add test to verify that the program is on a users desktop. notify user if this is not true. 
            //string path = Directory.GetCurrentDirectory();
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("This is to test the 8 Monthly US files for Michelin.");
            Console.WriteLine();
            Console.WriteLine("Please save all Michelin Monthly files to a folder on your DESKTOP.");
            Console.WriteLine("Please REMOVE ALL SPACES in the FILE NAMES and FILE PATHS.");
            Console.WriteLine("Please verify that ALL files are TAB DELIMITED.");
            Console.ResetColor();

            string path = GetDesktopDirectory() + @"\michelin_us_results";

            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            string choice = string.Empty;
            while (choice != "exit" || choice != "Exit")
            {
                Console.WriteLine();
                Console.WriteLine("Enter test number you would like to run: ");
                Console.WriteLine("{0,5}{1,-10}", "1. ", "Test ADD File.");
                Console.WriteLine("{0,5}{1,-10}", "2. ", "Test DIR File.");
                Console.WriteLine("{0,5}{1,-10}", "3. ", "Test Gap Price File.");
                Console.WriteLine("{0,5}{1,-10}", "4. ", "Test OM File.");
                Console.WriteLine("{0,5}{1,-10}", "5. ", "Test DT LAM Batch File.");
                Console.WriteLine("{0,5}{1,-10}", "6. ", "Test and Combine GAP Files");
                Console.WriteLine("{0,5}{1,-10}", "7. ", "KickOutMonth File Update.");
                Console.WriteLine();
                Console.WriteLine("\"exit\" - Closes the program.");
                Console.WriteLine();
                Console.Write("Your choice: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        MichelinTestMonthlyFilesADD();
                        break;

                    case "2":
                        MichelinTestMonthlyFilesDIR();
                        break;

                    case "3":
                        MichelinTestMonthlyFilesGAPPrice();
                        break;

                    case "4":
                        MichelinTestMonthlyFilesOM();
                        break;

                    case "5":
                        MichelinDealerTireLAMMonthly();
                        break;

                    case "6":
                        MichelinTestAndCombineMonthlyGapFiles();
                        break;

                    case "7":
                        MonthlyKickoutFile();
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        // individual tests.
        static public void MichelinTestMonthlyFilesADD()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the ADD file.");
            string file = GetAFile();
            string filename = GetFileNameWithoutExtension(file);
            char del = GetDelimiter();
            Console.Write("Enter the file Month first 3 letters(ex. JAN): ");
            string month = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            month = month + year;

            string testedoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + filename + "_" + month + "_good_columns.txt";

            // error storage
            List<string> missingcolumnlist = new List<string>(); //save the list.
            HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
            Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            int errorlinecount = 0;
            int errordelimitercount = 0;
            int blankvaluesadded = 0;

            //colum lists... they are in order of matching file -> table.
            string[] expectedfilecolumns = { "Plan Channel Member Group ID", "Plan Channel Member Group DESC", "Unique Customer AAD HQ# ID", "Unique Customer AAD HQ# DESC", "Unique Customer Class", "Unique Customer ID", "Unique Customer DESC", "Unique Customer Address 1",
                                               "Unique Customer State/Province", "Unique Customer City", "Unique Customer Zip/Postal", "Brand Group", "Year", "Month", "SELLOUT UNITS" };
            string[] newcolumns = { "PLAN_CHANNEL_MEMBER_GROUP_ID", "PLAN_CHANNEL_MEMBER_GROUP_DESC", "UNIQUE_CUSTOMER_AAD_HQ_ID", "UNIQUE_CUSTOMER_AAD_HQ_DESC", "UNIQUE_CUSTOMER_CLASS", "UNIQUE_CUSTOMER_ID", "UNIQUE_CUSTOMER_DESC", "UNIQUE_CUSTOMER_ADDRESS_1",
                                                "UNIQUE_CUSTOMER_STATE", "UNIQUE_CUSTOMER_CITY", "UNIQUE_CUSTOMER_ZIP", "BRAND", "YEAR", "MONTH", "SELLOUT_UNITS" };


            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
                {
                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(del);
                    int linelength = expectedfilecolumns.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int>();

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, del, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    //Column being checked indexes.
                    int uniquecustidcolumn = ColumnIndex(header, del, "Unique Customer Id");
                    int yearcolumn = ColumnIndex(header, del, "Year");
                    int monthcolumn = ColumnIndex(header, del, "Month");

                    //write new header -> with new column headers that match the table to be reloaded.
                    string newheader = string.Join(del.ToString(), newcolumns);
                    passedtestfile.WriteLine(newheader);

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;

                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(del);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(del);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        // unique customer id
                        int number = 0;
                        if (!int.TryParse(splitline[uniquecustidcolumn], out number))
                        {
                            failreport.Add("Unique Customer Id, not a number - " + splitline[uniquecustidcolumn]);
                        }

                        // year.
                        if (splitline[yearcolumn] != year)
                        {
                            failreport.Add("Year, does not match - " + splitline[yearcolumn]);
                        }

                        // month.
                        if (splitline[monthcolumn] != month)
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            List<string> newlinebuilder = new List<string>();
                            foreach (var val in columnindexes)
                            {
                                newlinebuilder.Add(splitline[val]);
                            }

                            if (splitlength < linelength) //if the line is not long enough. we just add the value.
                            {
                                while (splitlength < linelength)
                                {
                                    newlinebuilder.Add(string.Empty);

                                    //reassign array values
                                    splitline = newlinebuilder.ToArray();
                                    blankvaluesadded++;
                                    splitlength = splitline.Length;
                                }
                            }

                            passedtestfile.WriteLine(string.Join(del.ToString(), newlinebuilder.ToArray()));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }
                }

                // test results
                MichelinMonthlyFilesTestReport(file, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);

            }
        }

        static public void MichelinTestMonthlyFilesDIR()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the DIR file.");
            string file = GetAFile();
            string filename = GetFileNameWithoutExtension(file);
            char del = GetDelimiter();
            Console.Write("Enter the file Month first 3 letters(ex. JAN): ");
            string month = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            month = month + year;

            string testedoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + filename + "_" + month + "_good_columns.txt";

            // error storage
            List<string> missingcolumnlist = new List<string>(); //save the list.
            HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
            Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            int errorlinecount = 0;
            int errordelimitercount = 0;
            int blankvaluesadded = 0;

            //colum lists... they are in order of matching file -> table.
            string[] expectedfilecolumns = { "Country", "Level 2 Sales Position ID", "Level 2 Sales Position Name", "Plan Channel Member Group ID", "Plan Channel Member Group DESC", "Bill To Customer ID", "Bill To Customer DESC", "Bill To Cust Chnl ID", "Bill To Cust Chnl DESC", "Ship To Number #", "Ship To Number DESC", "Ship To Cust Chnl ID", "Ship To Cust Chnl DESC", "Ship To Address 1", "Ship To City", "Ship To State/Province", "Ship To Zip/Postal", "Brand Group", "Year", "Month", "Ship To Phone Number", "NAR UNITS", "SELLOUT UNITS w/o BIB EXP for TCI" };

            string[] newcolumns = { "COUNTRY_DESC", "LEVEL_2_SALES_POSITION_ID", "LEVEL_2_SALES_POSITION_NAME", "PLAN_CHANNEL_MEMBER_GROUP_ID", "PLAN_CHANNEL_MEMBER_GROUP_DESC", "BILL_TO_CUSTOMER_ID", "BILL_TO_CUSTOMER_DESC", "BILL_TO_CUST_CHNL_ID", "BILL_TO_CUST_CHNL_DESC", "SHIP_TO_NUMBER_ID", "SHIP_TO_NUMBER_DESC", "SHIP_TO_CUST_CHNL_ID", "SHIP_TO_CUST_CHNL_DESC", "SHIP_TO_ADDRESS_1_ID", "SHIP_TO_CITY_ID", "SHIP_TO_STATE", "SHIP_TO_ZIP", "BRAND", "YEAR", "MONTH", "UNK1", "NAR_UNITS", "SELLOUT_UNITS" };

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
                {
                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(del);
                    int linelength = headersplit.Length;

                    //Are all the columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int> { };

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, del, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, del, "Month".ToUpper());
                    int yearcolumn = ColumnIndex(header, del, "Year".ToUpper());

                    int billcustomerid = ColumnIndex(header, del, "Bill To Customer Id".ToUpper());
                    int billcustomerchannelid = ColumnIndex(header, del, "Bill To Cust Chnl Id".ToUpper());
                    int shiptonumberid = ColumnIndex(header, del, "Ship To Number #".ToUpper());
                    int shiptocustomerchnlid = ColumnIndex(header, del, "Ship To Cust Chnl Id".ToUpper());
                    int narunits = ColumnIndex(header, del, "Nar Units".ToUpper());
                    int selloutunits = ColumnIndex(header, del, "SELLOUT UNITS w/o BIB EXP for TCI".ToUpper());

                    List<int> numbercolumnslist = new List<int> { billcustomerchannelid, billcustomerid, shiptocustomerchnlid, shiptonumberid, narunits, selloutunits };

                    //write new header -> with new column headers that match the table to be reloaded.
                    string newheader = string.Join(del.ToString(), newcolumns);
                    passedtestfile.WriteLine(newheader);

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(del);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(del);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        //number columns
                        foreach (var index in numbercolumnslist)
                        {
                            int number = 0;
                            if (!string.IsNullOrWhiteSpace(splitline[index]))
                            {
                                if (!int.TryParse(splitline[index], out number))
                                {
                                    failreport.Add(newcolumns[index] + ", not a number - " + splitline[index]);
                                }
                            }
                        }

                        // year.
                        if (splitline[yearcolumn] != year)
                        {
                            failreport.Add("Year, does not match - " + splitline[yearcolumn]);
                        }

                        // month.
                        if (splitline[monthcolumn] != month)
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            List<string> newlinebuilder = new List<string>();
                            foreach (var val in columnindexes)
                            {
                                newlinebuilder.Add(splitline[val]);
                            }

                            if (splitlength < linelength) //if the line is not long enough. we just add the value.
                            {
                                while (splitlength < linelength)
                                {
                                    newlinebuilder.Add(string.Empty);

                                    //reassign array values
                                    splitline = newlinebuilder.ToArray();
                                    blankvaluesadded++;
                                    splitlength = splitline.Length;
                                }
                            }

                            passedtestfile.WriteLine(string.Join(del.ToString(), newlinebuilder.ToArray()));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    MichelinMonthlyFilesTestReport(file, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);

                }
            }
        }

        static public void MichelinTestMonthlyFilesGAPPrice()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the GAP PRICE file.");
            string file = GetAFile();
            string filename = GetFileNameWithoutExtension(file);
            char del = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string month = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            month = year + month;

            string testedoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + filename + "_" + month + "_good_columns.txt";

            // error storage
            List<string> missingcolumnlist = new List<string>(); //save the list.
            HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
            Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            int errorlinecount = 0;
            int errordelimitercount = 0;
            int blankvaluesadded = 0;

            string[] expectedfilecolumns = { "Bill To Number", "MSPN", "Month", "AVG NET NET PRICE AMT", "AVG INVC PRICE AMT" };
            string[] newcolumns = { "BILL_TO_NUMBER", "MSPN", "MONTH", "AVG_NET_NET_PRICE_AMT", "AVG_INVC_PRICE_AMT" };

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
                {
                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(del);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int>();

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, del, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }


                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, del, "Month".ToUpper());

                    //numbertests.
                    int avgnetnetprice = ColumnIndex(header, del, "AVG NET NET PRICE AMT".ToUpper());
                    int avginvcprice = ColumnIndex(header, del, "AVG INVC PRICE AMT".ToUpper());
                    List<int> numbercolumnslist = new List<int> { avginvcprice, avgnetnetprice };

                    //write new header -> with new column headers that match the table to be reloaded.
                    string newheader = string.Join(del.ToString(), newcolumns);
                    passedtestfile.WriteLine(newheader);

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(del);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(del);
                            splitlength = splitline.Length;
                        }


                        //test column values.
                        List<string> failreport = new List<string>();

                        //number columns
                        foreach (var index in numbercolumnslist)
                        {
                            decimal number = 0;
                            if (!string.IsNullOrWhiteSpace(splitline[index]))
                            {
                                if (!decimal.TryParse(splitline[index], out number))
                                {
                                    failreport.Add(newcolumns[index] + ", not a number - " + splitline[index]);
                                }
                            }
                        }

                        // month.
                        if (splitline[monthcolumn] != month)
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            List<string> newlinebuilder = new List<string>();
                            foreach (var val in columnindexes)
                            {
                                newlinebuilder.Add(splitline[val]);
                            }

                            if (splitlength < linelength) //if the line is not long enough. we just add the value.
                            {
                                while (splitlength < linelength)
                                {
                                    newlinebuilder.Add(string.Empty);

                                    //reassign array values
                                    splitline = newlinebuilder.ToArray();
                                    blankvaluesadded++;
                                    splitlength = splitline.Length;
                                }
                            }

                            passedtestfile.WriteLine(string.Join(del.ToString(), newlinebuilder.ToArray()));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    MichelinMonthlyFilesTestReport(file, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }
            }
        }

        static public void MichelinTestMonthlyFilesOM()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the OM file.");
            string file = GetAFile();
            string filename = GetFileNameWithoutExtension(file);
            char del = GetDelimiter();
            Console.Write("Enter the file Month first 3 letters(ex. JAN): ");
            string month = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            month = month + year;

            string testedoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + filename + "_" + month + "_good_columns.txt";

            // error storage
            List<string> missingcolumnlist = new List<string>(); //save the list.
            HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
            Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            int errorlinecount = 0;
            int errordelimitercount = 0;
            int blankvaluesadded = 0;

            //colum lists... they are in order of matching file -> table.
            string[] expectedfilecolumns = { "Plan Channel Member Group ID", "Plan Channel Member Group DESC", "Unique Customer Class", "Unique Customer ID", "Unique Customer DESC", "Unique Customer Address 1", "Unique Customer State/Province", "Unique Customer City", "Unique Customer Zip/Postal", "Brand Group", "Year", "Month", "SELLOUT UNITS" };
            string[] newcolumns = { "PLAN_CHANNEL_MEMBER_GROUP_ID", "PLAN_CHANNEL_MEMBER_GROUP_DESC", "UNIQUE_CUSTOMER_CLASS", "UNIQUE_CUSTOMER_ID", "UNIQUE_CUSTOMER_DESC", "UNIQUE_CUSTOMER_ADDRESS_1", "UNIQUE_CUSTOMER_STATE", "UNIQUE_CUSTOMER_CITY", "UNIQUE_CUSTOMER_ZIP", "BRAND", "YEAR", "MONTH", "SELLOUT_UNITS" };

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
                {
                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(del);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int> { };

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, del, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    //Column being checked indexes.
                    int uniquecustidcolumn = ColumnIndex(header, del, "Unique Customer Id");
                    int yearcolumn = ColumnIndex(header, del, "Year");
                    int monthcolumn = ColumnIndex(header, del, "Month");


                    //write new header -> with new column headers that match the table to be reloaded.
                    string newheader = string.Join(del.ToString(), newcolumns);
                    passedtestfile.WriteLine(newheader);

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(del);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(del);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        // unique customer id
                        int number = 0;
                        if (!int.TryParse(splitline[uniquecustidcolumn], out number))
                        {
                            failreport.Add("Unique Customer Id, not a number - " + splitline[uniquecustidcolumn]);
                        }

                        // year.
                        if (splitline[yearcolumn] != year)
                        {
                            failreport.Add("Year, does not match - " + splitline[yearcolumn]);
                        }

                        // month.
                        if (splitline[monthcolumn] != month)
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            List<string> newlinebuilder = new List<string>();
                            foreach (var val in columnindexes)
                            {
                                newlinebuilder.Add(splitline[val]);
                            }

                            if (splitlength < linelength) //if the line is not long enough. we just add the value.
                            {
                                while (splitlength < linelength)
                                {
                                    newlinebuilder.Add(string.Empty);

                                    //reassign array values
                                    splitline = newlinebuilder.ToArray();
                                    blankvaluesadded++;
                                    splitlength = splitline.Length;
                                }
                            }

                            passedtestfile.WriteLine(string.Join(del.ToString(), newlinebuilder.ToArray()));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    MichelinMonthlyFilesTestReport(file, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }
            }
        }

        static public void MichelinDealerTireLAMMonthly()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the US Dealer Tire Lam Batch file.");
            string file = GetAFile();
            string filename = GetFileNameWithoutExtension(file);
            char del = GetDelimiter();
            Console.Write("Enter the file Month first 3 letters(ex. JAN): ");
            string month = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            month = month + year;

            string testedoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + filename + "_" + month + "_good_columns.txt";

            // error storage
            List<string> missingcolumnlist = new List<string>(); //save the list.
            HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
            Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            int errorlinecount = 0;
            int errordelimitercount = 0;
            int blankvaluesadded = 0;

            //colum lists... they are in order of matching file -> table.
            string[] expectedfilecolumns = { "Plan Channel Member Group ID", "Plan Channel Member Group DESC", "Indirect Customer Indirect Customer ID", "Indirect Customer DESC", "Indirect Customer Address 1", "Indirect Customer State/Province", "Indirect Customer City", "Indirect Customer Zip/Postal", "Brand", "Year", "Month", "SELLOUT UNITS" };
            string[] newcolumns = { "PLAN_CHANNEL_MEMBER_GROUP_ID", "PLAN_CHANNEL_MEMBER_GROUP_DESC", "UNIQUE_CUSTOMER_ID", "UNIQUE_CUSTOMER_DESC", "UNIQUE_CUSTOMER_ADDRESS_1", "UNIQUE_CUSTOMER_STATE", "UNIQUE_CUSTOMER_CITY", "UNIQUE_CUSTOMER_ZIP", "BRAND", "YEAR", "MONTH", "SELLOUT_UNITS" };

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
                {
                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(del);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int> { };

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, del, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    //Column being checked indexes.
                    //int uniquecustidcolumn = ColumnIndex(usdtlamheader, usdtlamdel, "Plan Channel Member Group ID");
                    int yearcolumn = ColumnIndex(header, del, "Year");
                    int monthcolumn = ColumnIndex(header, del, "Month");

                    //write new header -> with new column headers that match the table to be reloaded.
                    string newheader = string.Join(del.ToString(), newcolumns);
                    passedtestfile.WriteLine(newheader);

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.
                                       //line = line.Replace(",", string.Empty);
                        string[] splitline = line.Split(del);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(del);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();
                        // year.
                        if (splitline[yearcolumn] != year)
                        {
                            failreport.Add("Year, does not match - " + splitline[yearcolumn]);
                        }

                        // month.
                        if (splitline[monthcolumn] != month)
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            List<string> newlinebuilder = new List<string>();
                            foreach (var val in columnindexes)
                            {
                                newlinebuilder.Add(splitline[val]);
                            }

                            if (splitlength < linelength) //if the line is not long enough. we just add the value.
                            {
                                while (splitlength < linelength)
                                {
                                    newlinebuilder.Add(string.Empty);

                                    //reassign array values
                                    splitline = newlinebuilder.ToArray();
                                    blankvaluesadded++;
                                    splitlength = splitline.Length;
                                }
                            }

                            passedtestfile.WriteLine(string.Join(del.ToString(), newlinebuilder.ToArray()));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    MichelinMonthlyFilesTestReport(file, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }
            }
        }

        static public void MichelinTestAndCombineMonthlyGapFiles()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("This will test and combine all three US GAP files provided by Michelin.");
            Console.WriteLine();

            Console.WriteLine("Please enter the US Dealer Tire GAP Monthly Batch File.");
            string gapbatchfile = GetAFile();
            char gapbatchdel = GetDelimiter();
            Console.Write("Enter the file Month first 3 letters(ex. JAN): ");
            string gapbatchmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the file Month number (ex. 01): ");
            string gapbatchmonthnumber = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string gapbatchyear = Console.ReadLine().Trim().ToUpper();

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Please enter the GAP US TCAR PS Extract File.");
            string gaptcarfile = GetAFile();
            char gaptcardel = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string gaptcarmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string gaptcaryear = Console.ReadLine().Trim().ToUpper();

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Please enter the MSPN ST AAD US OMA For ZONE LAM File.");
            string mspnfile = GetAFile();
            char mspndel = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string mspnmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string mspnyear = Console.ReadLine().Trim().ToUpper();

            //new file
            string testedoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + "USGAPFILE_" + gapbatchmonth + "_good_columns.txt";
            char passedtestfiledel = '|';

            // platform table column order. output file will have these columns.
            string[] platformtablecolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "NET_SALES_UNITS", "SELLOUT_UNITS", "NET_INVC_UNITS", "BIB_X_UNITS" };

            using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
            {
                //write header
                passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), platformtablecolumns));

                //gap batch file
                using (StreamReader readfile = new StreamReader(gapbatchfile))
                {
                    // error storage
                    List<string> missingcolumnlist = new List<string>(); //save the list.
                    HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
                    Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
                    int errorlinecount = 0;
                    int errordelimitercount = 0;
                    int blankvaluesadded = 0;

                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(gapbatchdel);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int>();

                    //string[] expectedfilecolumns = { "Indirect Customer", "MSPN", "Month", "Year", "SELLOUT UNITS" }; //expected column order
                    string[] expectedfilecolumns = { "Indirect Customer", "MSPN", "Month", "SELLOUT UNITS" };
                    string[] newcolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "SELLOUT_UNITS" };

                    //old MMMyyyy
                    gapbatchmonth = gapbatchmonth + gapbatchyear;
                    //new month format
                    gapbatchmonthnumber = gapbatchyear + gapbatchmonthnumber;

                    foreach (var column in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(column))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, gapbatchdel, column));
                        }
                        else
                        {
                            missingcolumnlist.Add(column);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    if (columnindexes.Count != expectedfilecolumns.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} - File does not contain all expected columns. Please check file headers then restart this process.", GetFileNameWithoutExtension(gapbatchfile));
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine("Expected Columns: ");
                        foreach (var column in expectedfilecolumns)
                        {
                            Console.WriteLine(column);
                        }

                        Console.ResetColor();

                        MichelinMonthlyFileCleaner();
                    }

                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, gapbatchdel, "Month");

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(gapbatchdel);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(gapbatchdel);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        // month.
                        if (splitline[monthcolumn] == gapbatchmonth || splitline[monthcolumn] == gapbatchmonthnumber)
                        {
                            //hard set change to user entered values.
                            splitline[monthcolumn] = gapbatchmonthnumber;
                        }
                        else
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            //write to passtedtestfile, but have to match indexes first.
                            string[] newlinevaluearray = new string[platformtablecolumns.Length];

                            for (int i = 0; i <= newcolumns.Length - 1; i++)
                            {
                                foreach (var platformcolumn in platformtablecolumns)
                                {
                                    if (newcolumns[i] == platformcolumn)
                                    {
                                        //add value with index saved in columnindexes.
                                        int platformheadercolumnindex = Array.IndexOf(platformtablecolumns, platformcolumn);

                                        newlinevaluearray[platformheadercolumnindex] = splitline[columnindexes[i]];
                                    }
                                }
                            }

                            passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), newlinevaluearray));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    MichelinMonthlyFilesTestReport(gapbatchfile, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }

                //gap tcar file
                using (StreamReader readfile = new StreamReader(gaptcarfile))
                {
                    // error storage
                    List<string> missingcolumnlist = new List<string>(); //save the list.
                    HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
                    Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
                    int errorlinecount = 0;
                    int errordelimitercount = 0;
                    int blankvaluesadded = 0;

                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(gapbatchdel);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int>();

                    string[] expectedfilecolumns = { "Ship To Number", "MSPN", "Month", "NET SLS UNITS w TCI Bibx", "SELLOUT UNITS w/o BIB EXP for TCI", "NET INVC UNITS", "BIB EXPRESS TS UNITS Plus" };
                    string[] newcolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "NET_SALES_UNITS", "SELLOUT_UNITS", "NET_INVC_UNITS", "BIB_X_UNITS" };

                    gaptcarmonth = gaptcaryear + gaptcarmonth;

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, gaptcardel, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    if (columnindexes.Count != expectedfilecolumns.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} - File does not contain all expected columns. Please check file headers then restart this process.", GetFileNameWithoutExtension(gaptcarfile));
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine("Expected Columns: ");
                        foreach (var column in expectedfilecolumns)
                        {
                            Console.WriteLine(column);
                        }
                        Console.ResetColor();

                        MichelinMonthlyFileCleaner();
                    }

                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, gaptcardel, "Month");

                    //number test.
                    int etslsunitscolumn = ColumnIndex(header, gaptcardel, "ET SLS UNITS w TCI Bibx".ToUpper());
                    int selloutunitscolumn = ColumnIndex(header, gaptcardel, "SELLOUT UNITS w/o BIB EXP for TCI".ToUpper());
                    int netinvcunitscolumn = ColumnIndex(header, gaptcardel, "NET INVC UNITS".ToUpper());
                    int bibexpresscolumn = ColumnIndex(header, gaptcardel, "BIB EXPRESS TS UNITS".ToUpper());

                    List<int> numbercolumnslist = new List<int> { etslsunitscolumn, selloutunitscolumn, netinvcunitscolumn, bibexpresscolumn };

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(gaptcardel);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(gaptcardel);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        foreach (var index in numbercolumnslist)
                        {
                            int number = 0;
                            if (!string.IsNullOrWhiteSpace(splitline[index]))
                            {
                                if (!int.TryParse(splitline[index].Replace(",", string.Empty), out number))
                                {
                                    failreport.Add(newcolumns[index] + ", not a number - " + splitline[index]);
                                }
                            }
                        }

                        // month.
                        if (splitline[monthcolumn] != gaptcarmonth) //test both formats.
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            //write to passtedtestfile, but have to match indexes first.
                            string[] newlinevaluearray = new string[platformtablecolumns.Length];

                            for (int i = 0; i <= newcolumns.Length - 1; i++)
                            {
                                foreach (var platformcolumn in platformtablecolumns)
                                {
                                    if (newcolumns[i] == platformcolumn)
                                    {
                                        //add value with index saved in columnindexes.
                                        int platformheadercolumnindex = Array.IndexOf(platformtablecolumns, platformcolumn);

                                        newlinevaluearray[platformheadercolumnindex] = splitline[columnindexes[i]];
                                    }
                                }
                            }

                            passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), newlinevaluearray));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    MichelinMonthlyFilesTestReport(gaptcarfile, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }

                //MSPN ST AAD US OMA For ZONE LAM
                using (StreamReader readfile = new StreamReader(mspnfile))
                {
                    // error storage
                    List<string> missingcolumnlist = new List<string>(); //save the list.
                    HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
                    Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
                    int errorlinecount = 0;
                    int errordelimitercount = 0;
                    int blankvaluesadded = 0;

                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(mspndel);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int>();

                    string[] expectedfilecolumns = { "Unique Customer", "MSPN", "Month", "SELLOUT UNITS" };
                    string[] newcolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "SELLOUT_UNITS" };

                    mspnmonth = mspnyear + mspnmonth;

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, mspndel, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    if (columnindexes.Count != expectedfilecolumns.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} - File does not contain all expected columns. Please check file headers then restart this process.", GetFileNameWithoutExtension(mspnfile));
                        Console.WriteLine("************************************************************************************");
                        Console.WriteLine("Expected Columns: ");
                        foreach (var column in expectedfilecolumns)
                        {
                            Console.WriteLine(column);
                        }
                        Console.ResetColor();

                        MichelinMonthlyFileCleaner();
                    }

                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, mspndel, "Month");

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(mspndel);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(mspndel);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        // month.
                        if (splitline[monthcolumn] != mspnmonth) //test both formats.
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            //write to passtedtestfile, but have to match indexes first.
                            string[] newlinevaluearray = new string[platformtablecolumns.Length];

                            for (int i = 0; i <= newcolumns.Length - 1; i++)
                            {
                                foreach (var platformcolumn in platformtablecolumns)
                                {
                                    if (newcolumns[i] == platformcolumn)
                                    {
                                        //add value with index saved in columnindexes.
                                        int platformheadercolumnindex = Array.IndexOf(platformtablecolumns, platformcolumn);

                                        newlinevaluearray[platformheadercolumnindex] = splitline[columnindexes[i]];
                                    }
                                }
                            }

                            passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), newlinevaluearray));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    MichelinMonthlyFilesTestReport(mspnfile, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }
            }
        }

        static public void MonthlyKickoutFile()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine();
            Console.WriteLine("Entered required values to generate this months Kickout Out Month File");
            Console.WriteLine();
            Console.Write("Enter the new Month, first 3 letters(ex. JAN): ");
            string monthyear = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the new files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            Console.WriteLine("Processing..");

            string newkickoutmonthfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\KickOutMonth_updated.txt";
            string path = GetDesktopDirectory() + @"\michelin_us_results";

            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            // month dictionary
            Dictionary<int, string> monthdict = new Dictionary<int, string>();
            monthdict.Add(1, "JAN");
            monthdict.Add(2, "FEB");
            monthdict.Add(3, "MAR");
            monthdict.Add(4, "APR");
            monthdict.Add(5, "MAY");
            monthdict.Add(6, "JUN");
            monthdict.Add(7, "JUL");
            monthdict.Add(8, "AUG");
            monthdict.Add(9, "SEP");
            monthdict.Add(10, "OCT");
            monthdict.Add(11, "NOV");
            monthdict.Add(12, "DEC");

            // set value for day. month. use these to determine "todays" month.
            int daynumber = 1;

            int monthnumber = 0;
            foreach (var key in monthdict.Keys)
            {
                if (monthdict[key] == monthyear.ToUpper())
                {
                    monthnumber = key;
                }
            }

            int yearnumber = 0;
            if (!int.TryParse(year, out yearnumber))
            {
                Console.WriteLine("Invalid year entered.");
                Console.WriteLine();
                MichelinMonthlyFileCleaner();
            }

            // Find past months.
            List<string> monthyears = new List<string>();

            DateTime entereddate = new DateTime(yearnumber, monthnumber, daynumber);
            monthyears.Add(entereddate.ToString("MMMyyyy")); // adds month abbreviation + year.

            DateTime pastmonths = entereddate;
            // find all 12 date times.
            int d = 12;
            while (d > 1)
            {
                pastmonths = pastmonths.AddMonths(-1);
                monthyears.Add(pastmonths.ToString("MMMyyyy"));
                d--;
            }

            using (StreamWriter kickoutfile = new StreamWriter(newkickoutmonthfile))
            {
                kickoutfile.WriteLine("NAME,VALUE");

                monthyears.Reverse();

                foreach (var value in monthyears)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(value.ToUpper());
                    linebuilder.Add(value.ToUpper());
                    kickoutfile.WriteLine(string.Join(",", linebuilder.ToArray()));
                }
            }


            Console.WriteLine();
            Console.WriteLine("Done.");

        }

        static public void MichelinMonthlyFilesTestReport(string file, string testedoutfile, List<string> missingcolumnlist, HashSet<string> unmatchedfilecolumnlist, Dictionary<int, List<string>> failedrecordsdict, int errorlinecount, int errordelimitercount, int blankvaluesadded)
        {
            // error storage
            //List<string> missingcolumnlist = new List<string>(); //save the list.
            //HashSet<string> unmatchedfilecolumnlist = new HashSet<string>(); 
            //Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            //int errorlinecount = 0;
            //int errordelimitercount = 0;
            //int blankvaluesadded = 0;

            // test results
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} - Test Results:", GetFileNameWithoutExtension(file));
            Console.ResetColor();

            if (errordelimitercount > 0)
            {
                // read report.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} - Delimiter errors fixed.", errordelimitercount);
                Console.ResetColor();
            }

            if (blankvaluesadded > 0)
            {
                // read report.
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} - Blank values added.", blankvaluesadded);
                Console.ResetColor();
            }

            if (failedrecordsdict.Count != 0 || missingcolumnlist.Count != 0)
            {
                string failoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + GetFileNameWithoutExtension(file) + "_failreport.txt";

                using (StreamWriter failreportfile = new StreamWriter(failoutfile))
                {
                    if (missingcolumnlist.Count != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Some columns are missing. Expected columns listed here - {0}", failoutfile);
                        Console.ResetColor();

                        failreportfile.WriteLine("Expected Column(s):");
                        foreach (var column in missingcolumnlist)
                        {
                            failreportfile.WriteLine(column); //outputs missing expected columns.
                        }

                        failreportfile.WriteLine(); //blank line.
                        failreportfile.WriteLine("Recieved Column(s):");
                        foreach (var column in unmatchedfilecolumnlist)
                        {
                            failreportfile.WriteLine(column); //output unmatched columns from file
                        }
                    }

                    if (failedrecordsdict.Count > 0)
                    {
                        failreportfile.WriteLine(); //blank line.
                        failreportfile.WriteLine("Record Number|FailedColumns:");
                        char faildel = '|';
                        foreach (var key in failedrecordsdict.Keys)
                        {
                            List<string> linebuilder = new List<string>();
                            linebuilder.Add(key.ToString());
                            foreach (var s in failedrecordsdict[key])
                            {
                                linebuilder.Add(s);
                            }
                            failreportfile.WriteLine(string.Join(faildel.ToString(), linebuilder.ToArray()));
                        }

                        // failed error message
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} - records failed tests.", errorlinecount);
                        Console.WriteLine("Bad records placed in - {0}", failoutfile);
                        Console.ResetColor();

                        Console.WriteLine();
                        Console.WriteLine("Cleaned records placed in - {0}", testedoutfile);
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                //passed no error message
                Console.WriteLine();
                Console.WriteLine("File Passed testing, cleaned records placed in - {0}", testedoutfile);
                Console.WriteLine();
            }
        }

        // Michelin Monthly File Testing Canada
        static public void MichelinCanadaTestMontlyFileFormats()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("This is to test 3 of the Monthly CANADA files for Michelin.");
            Console.WriteLine();
            Console.WriteLine("Please save all Michelin Monthly files to a folder on your DESKTOP.");
            Console.WriteLine("Please REMOVE ALL SPACES in the FILE NAMES and FILE PATHS.");
            Console.WriteLine("Please verify that ALL files are TAB DELIMITED.");
            Console.ResetColor();

            string path = GetDesktopDirectory() + @"\michelin_canada_results\";

            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            string choice = string.Empty;
            while (choice != "exit" || choice != "Exit")
            {
                Console.WriteLine();
                Console.WriteLine("Enter test number you would like to run: ");
                Console.WriteLine("{0,5}{1,-10}", "1. ", "Test Gap Price File.");
                Console.WriteLine("{0,5}{1,-10}", "2. ", "Test and Combine GAP Files");
                //Console.WriteLine("{0,5}{1,-10}", "3. ", "Test MSPN File.");
                Console.WriteLine();
                Console.WriteLine("\"exit\" - Closes the program.");
                Console.WriteLine();
                Console.Write("Your choice: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        MichelinCanadaTestMonthlyFilesGAPPrice();
                        break;

                    case "2":
                        MichelinCanadaTestAndCombineGapFiles();
                        break;

                    //case "3":
                    //   MichelinCanadaTestMonthlyFilesMSPN();
                    //   break;

                    case "exit":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static public void MichelinCanadaTestMonthlyFilesGAPPrice()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the GAP Price CA TCAR file.");
            string file = GetAFile();
            string filename = GetFileNameWithoutExtension(file);
            char del = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string month = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            month = year + month;

            string testedoutfile = GetDesktopDirectory() + @"\michelin_canada_results" + "\\" + filename + "_" + month + "_good_columns.txt";

            // error storage
            List<string> missingcolumnlist = new List<string>(); //save the list.
            HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
            Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            int errorlinecount = 0;
            int errordelimitercount = 0;
            int blankvaluesadded = 0;

            //colum lists... they are in order of matching file -> table.
            string[] expectedfilecolumns = { "Bill To Number", "MSPN", "Month", "CA AVG INVC PRICE AMT", "CA AVG NET NET PRICE AMT" };
            string[] newcolumns = expectedfilecolumns; //columns match for now.


            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
                {

                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(del);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int> { };

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, del, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    //Column indexes.
                    int monthcolumn = ColumnIndex(header, del, "Month");

                    //numbertests.
                    int number1 = ColumnIndex(header, del, "CA AVG INVC PRICE AMT".ToUpper());
                    int number2 = ColumnIndex(header, del, "CA AVG NET NET PRICE AMT".ToUpper());
                    List<int> numbercolumnslist = new List<int> { number1, number2 };

                    //write new header -> with new column headers that match the table to be reloaded.
                    string newheader = string.Join(del.ToString(), newcolumns);
                    passedtestfile.WriteLine(newheader);

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(del);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(del);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        //number columns
                        foreach (var index in numbercolumnslist)
                        {
                            splitline[index] = splitline[index].Replace(",", string.Empty);

                            //negatives test
                            if (splitline[index].Contains(')') || splitline[index].Contains('('))
                            {
                                splitline[index] = splitline[index].Replace(")", string.Empty);
                                splitline[index] = splitline[index].Replace("(", string.Empty);
                                splitline[index] = "-" + splitline[index];
                            }

                            decimal number = 0;
                            if (!string.IsNullOrWhiteSpace(splitline[index]))
                            {
                                if (!decimal.TryParse(splitline[index], out number))
                                {
                                    failreport.Add(newcolumns[index] + ", not a number - " + splitline[index]);
                                }
                            }
                        }

                        // month.
                        if (splitline[monthcolumn] != month)
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }


                        //outputs.
                        if (failreport.Count == 0)
                        {
                            List<string> newlinebuilder = new List<string>();
                            foreach (var val in columnindexes)
                            {
                                newlinebuilder.Add(splitline[val]);
                            }

                            if (splitlength < linelength) //if the line is not long enough. we just add the value.
                            {
                                while (splitlength < linelength)
                                {
                                    newlinebuilder.Add(string.Empty);

                                    //reassign array values
                                    splitline = newlinebuilder.ToArray();
                                    blankvaluesadded++;
                                    splitlength = splitline.Length;
                                }
                            }

                            passedtestfile.WriteLine(string.Join(del.ToString(), newlinebuilder.ToArray()));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }
                    // test results
                    MichelinMonthlyFilesTestReport(file, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }
            }
        }

        static public void MichelinCanadaTestAndCombineGapFiles()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the MSPN ST  AAD CA OMA For Zone LAM file.");
            string mspnfile = GetAFile();

            char mspndel = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string mspnmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string mspnyear = Console.ReadLine().Trim().ToUpper();

            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the GAP CA TCAR PS Extract file.");
            string gapfile = GetAFile();

            char gapdel = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string gapmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string gapyear = Console.ReadLine().Trim().ToUpper();

            //new file
            string testedoutfile = GetDesktopDirectory() + @"\michelin_canada_results" + "\\" + "CanadaGAPFILE_" + gapmonth + "_good_columns.txt";
            char passedtestfiledel = '|';

            // platform table column order. output file will have these columns.
            //string[] platformtablecolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "NET_SALES_UNITS", "SELLOUT_UNITS", "NET_INVC_UNITS", "SITE_TYPE", "BIB_X_UNITS" };
            string[] platformtablecolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "NET_SALES_UNITS", "SELLOUT_UNITS", "NET_INVC_UNITS", "BIB_X_UNITS" }; // removed Site_Type. does not need to be here

            using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
            {
                //write header
                passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), platformtablecolumns));

                //mspn file
                using (StreamReader readfile = new StreamReader(mspnfile))
                {
                    // error storage
                    List<string> missingcolumnlist = new List<string>(); //save the list.
                    HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
                    Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
                    int errorlinecount = 0;
                    int errordelimitercount = 0;
                    int blankvaluesadded = 0;

                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(mspndel);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int>();

                    //colum lists... they are in order of matching file -> table.
                    string[] expectedfilecolumns = { "Unique Customer", "MSPN", "Month", "SELLOUT UNITS" };
                    string[] newcolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "SELLOUT_UNITS" }; //columns match for now.

                    //yyyyMM format
                    mspnmonth = mspnyear + mspnmonth;

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, mspndel, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    if (columnindexes.Count != expectedfilecolumns.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} - File does not contain all expected columns. Please check file headers then restart this process.", GetFileNameWithoutExtension(mspnfile));
                        Console.WriteLine("************************************************************************************");
                        Console.ResetColor();

                        MichelinMonthlyFileCleaner();
                    }

                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, mspndel, "Month");

                    //numbertests.
                    int selloutunitscolumn = ColumnIndex(header, mspndel, "SELLOUT UNITS".ToUpper());
                    List<int> numbercolumnslist = new List<int> { selloutunitscolumn };

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(mspndel);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(mspndel);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        foreach (var index in numbercolumnslist)
                        {
                            //remove commas.
                            splitline[index] = splitline[index].Replace(",", string.Empty);

                            //negatives test
                            if (splitline[index].Contains(')') || splitline[index].Contains('('))
                            {
                                splitline[index] = splitline[index].Replace(")", string.Empty);
                                splitline[index] = splitline[index].Replace("(", string.Empty);
                                splitline[index] = "-" + splitline[index];
                            }

                            int number = 0;
                            if (!string.IsNullOrWhiteSpace(splitline[index]))
                            {
                                if (!int.TryParse(splitline[index].Replace(",", string.Empty), out number))
                                {
                                    failreport.Add(newcolumns[index] + ", not a number - " + splitline[index]);
                                }
                            }
                        }

                        // month.
                        if (splitline[monthcolumn] != mspnmonth) //test both formats.
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs. OLD
                        //if (failreport.Count == 0)
                        //{
                        //   //write to passtedtestfile, but have to match indexes first.
                        //   List<string> newlinebuilder = new List<string>();

                        //   for (int i = 0; i <= newcolumns.Length - 1; i++)
                        //   {
                        //      foreach (var platformheader in platformtablecolumns)
                        //      {
                        //         if (newcolumns[i] == platformheader)
                        //         {
                        //            newlinebuilder.Add(splitline[columnindexes[i]]); //add value with index saved in columnindexes.
                        //         }
                        //      }
                        //   }

                        //   if (splitlength < platformtablecolumns.Length) //if the line is not long enough. we just add the value.
                        //   {
                        //      while (splitlength < platformtablecolumns.Length)
                        //      {
                        //         newlinebuilder.Add(string.Empty);

                        //         //reassign array values
                        //         splitline = newlinebuilder.ToArray();
                        //         blankvaluesadded++;
                        //         splitlength = splitline.Length;
                        //      }
                        //   }

                        //   passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), newlinebuilder.ToArray()));
                        //}
                        //else
                        //{
                        //   errorlinecount++; // there are errors in this line.
                        //   failedrecordsdict.Add(recordcount, failreport);
                        //}

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            //write to passtedtestfile, but have to match indexes first.
                            string[] newlinevaluearray = new string[platformtablecolumns.Length];

                            for (int i = 0; i <= newcolumns.Length - 1; i++)
                            {
                                foreach (var platformcolumn in platformtablecolumns)
                                {
                                    if (newcolumns[i] == platformcolumn)
                                    {
                                        //add value with index saved in columnindexes.
                                        int platformheadercolumnindex = Array.IndexOf(platformtablecolumns, platformcolumn);

                                        newlinevaluearray[platformheadercolumnindex] = splitline[columnindexes[i]];
                                    }
                                }
                            }

                            passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), newlinevaluearray));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }

                    }
                    // test results
                    MichelinMonthlyFilesTestReport(mspnfile, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }

                // gap file
                using (StreamReader readfile = new StreamReader(gapfile))
                {
                    // error storage
                    List<string> missingcolumnlist = new List<string>(); //save the list.
                    HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
                    Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
                    int errorlinecount = 0;
                    int errordelimitercount = 0;
                    int blankvaluesadded = 0;

                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(gapdel);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int>();

                    string[] expectedfilecolumns = { "Ship To Number", "MSPN", "Month", "NET SLS UNITS w TCI Bibx", "SELLOUT UNITS w/o BIB EXP for TCI", "NET INVC UNITS", "BIB EXPRESS TS UNITS Plus" };
                    string[] newcolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "NET_SALES_UNITS", "SELLOUT_UNITS", "NET_INVC_UNITS", "BIB_X_UNITS" }; //columns match for now.

                    //yyyyMM
                    gapmonth = gapyear + gapmonth;

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, gapdel, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    if (columnindexes.Count != expectedfilecolumns.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} - File does not contain all expected columns. Please check file headers then restart this process.", GetFileNameWithoutExtension(gapfile));
                        Console.WriteLine("************************************************************************************");

                        Console.WriteLine("Expected Columns: ");
                        foreach (var column in expectedfilecolumns)
                        {
                            Console.WriteLine(column);
                        }
                        Console.ResetColor();

                        MichelinMonthlyFileCleaner();
                    }

                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, gapdel, "Month");

                    //numbertests.
                    int number1 = ColumnIndex(header, gapdel, "NET SLS UNITS w TCI Bibx".ToUpper());
                    int number2 = ColumnIndex(header, gapdel, "SELLOUT UNITS w/o BIB EXP for TCI".ToUpper());
                    int number3 = ColumnIndex(header, gapdel, "NET INVC UNITS".ToUpper());
                    int number4 = ColumnIndex(header, gapdel, "BIB EXPRESS TS UNITS Plus".ToUpper());
                    List<int> numbercolumnslist = new List<int> { number1, number2, number3, number4 };

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(gapdel);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(gapdel);
                            splitlength = splitline.Length;
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        foreach (var index in numbercolumnslist)
                        {
                            //remove commas.
                            splitline[index] = splitline[index].Replace(",", string.Empty);

                            //negatives test
                            if (splitline[index].Contains(')') || splitline[index].Contains('('))
                            {
                                splitline[index] = splitline[index].Replace(")", string.Empty);
                                splitline[index] = splitline[index].Replace("(", string.Empty);
                                splitline[index] = "-" + splitline[index];
                            }

                            int number = 0;
                            if (!string.IsNullOrWhiteSpace(splitline[index]))
                            {
                                if (!int.TryParse(splitline[index].Replace(",", string.Empty), out number))
                                {
                                    failreport.Add(newcolumns[index] + ", not a number - " + splitline[index]);
                                }
                            }
                        }

                        // month.
                        if (splitline[monthcolumn] != gapmonth) //test both formats.
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs. OLD
                        //if (failreport.Count == 0)
                        //{
                        //   //write to passtedtestfile, but have to match indexes first.
                        //   List<string> newlinebuilder = new List<string>();

                        //   for (int i = 0; i <= newcolumns.Length - 1; i++)
                        //   {
                        //      foreach (var platformheader in platformtablecolumns)
                        //      {
                        //         if (newcolumns[i] == platformheader)
                        //         {
                        //            newlinebuilder.Add(splitline[columnindexes[i]]); //add value with index saved in columnindexes.
                        //         }
                        //      }
                        //   }

                        //   if (splitlength < platformtablecolumns.Length) //if the line is not long enough. we just add the value.
                        //   {
                        //      while (splitlength < platformtablecolumns.Length)
                        //      {
                        //         newlinebuilder.Add(string.Empty);

                        //         //reassign array values
                        //         splitline = newlinebuilder.ToArray();
                        //         blankvaluesadded++;
                        //         splitlength = splitline.Length;
                        //      }
                        //   }

                        //   passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), newlinebuilder.ToArray()));
                        //}
                        //else
                        //{
                        //   errorlinecount++; // there are errors in this line.
                        //   failedrecordsdict.Add(recordcount, failreport);
                        //}

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            //write to passtedtestfile, but have to match indexes first.
                            string[] newlinevaluearray = new string[platformtablecolumns.Length];

                            for (int i = 0; i <= newcolumns.Length - 1; i++)
                            {
                                foreach (var platformcolumn in platformtablecolumns)
                                {
                                    if (newcolumns[i] == platformcolumn)
                                    {
                                        //add value with index saved in columnindexes.
                                        int platformheadercolumnindex = Array.IndexOf(platformtablecolumns, platformcolumn);

                                        newlinevaluearray[platformheadercolumnindex] = splitline[columnindexes[i]];
                                    }
                                }
                            }

                            passedtestfile.WriteLine(string.Join(passedtestfiledel.ToString(), newlinevaluearray));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    MichelinMonthlyFilesTestReport(gapfile, testedoutfile, missingcolumnlist, unmatchedfilecolumnlist, failedrecordsdict, errorlinecount, errordelimitercount, blankvaluesadded);
                }
            }
        }


        //old versions.
        static public void MichelinDealerTireGapMonthly()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the US Dealer Tire GAP Batch file.");
            string usdtgapfile = GetAFile();
            string usdtgapfilename = GetFileNameWithoutExtension(usdtgapfile);
            string usdtgapoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + usdtgapfilename + "_good_columns.txt";
            string usdtgapoutfile2 = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + usdtgapfilename + "_bad_columns.txt";

            char usdtgapdel = GetDelimiter();
            Console.Write("Enter the file Month first 3 letters(ex. JAN): ");
            string usdtgapoldmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the file Month number (ex. 01): ");
            string usdtgapmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string usdtgapyear = Console.ReadLine().Trim().ToUpper();

            //new month, yyyymm all numbers.
            usdtgapmonth = usdtgapyear + usdtgapmonth;
            //old MMMyyyy
            usdtgapoldmonth = usdtgapoldmonth + usdtgapyear;

            using (StreamReader readfile = new StreamReader(usdtgapfile))
            {
                using (StreamWriter outfile1 = new StreamWriter(usdtgapoutfile))
                {
                    using (StreamWriter outfile2 = new StreamWriter(usdtgapoutfile2))
                    {
                        //column definitions.
                        string[] expectedcolumnnames = { "Indirect Customer", "MSPN", "Month", "Year", "SELLOUT UNITS" };
                        string[] newcolumnnames = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "SELLOUT_UNITS" };

                        //get header.
                        string usdtgapheader = readfile.ReadLine();
                        string[] columns = usdtgapheader.Split(usdtgapdel);
                        int usdtgaplength = columns.Length;

                        //are all columns there? 
                        List<string> columnchecker = new List<string> { };
                        List<int> columnindexes = new List<int> { };

                        foreach (var s in columns)
                        {
                            columnchecker.Add(s);
                        }

                        bool columnsmissing = false;
                        foreach (var s in expectedcolumnnames)
                        {
                            if (!columnchecker.Contains(s))
                            {
                                columnsmissing = true;
                                Console.WriteLine("US Dealer Tire GAP File missing column - {0}", s);
                            }
                            else
                            {
                                //save column index in order they appear in the expected column list - > order matches new header write order.
                                columnindexes.Add(ColumnIndex(usdtgapheader, usdtgapdel, s));
                            }
                        }

                        if (columnsmissing == true)
                        {
                            List<string> outcolumns = expectedcolumnnames.ToList();
                            foreach (var s in outcolumns)
                            {
                                outfile2.WriteLine(s);
                            }

                            Console.WriteLine("Some columns are missing, please check the File, program will now close.");
                            Console.WriteLine("Expected columns listed here - {0}", outfile2);

                        }

                        //write new header -> with new column headers that match the table to be reloaded.
                        string newheader = string.Join(usdtgapdel.ToString(), newcolumnnames);
                        outfile1.WriteLine(newheader);

                        //write to error file
                        outfile2.WriteLine("fail_report\t" + newheader);

                        //Column indexes.
                        //int uniquecustid = ColumnIndex(usdtlamheader, usdtlamdel, "Plan Channel Member Group ID");
                        int year = ColumnIndex(usdtgapheader, usdtgapdel, "Year");
                        int Month = ColumnIndex(usdtgapheader, usdtgapdel, "Month");

                        string line = string.Empty;
                        int count = 0;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            line = line.Replace(",", string.Empty);
                            string[] splitline = line.Split(usdtgapdel);
                            int splitlength = splitline.Length;

                            //test line Length.
                            while (splitlength != usdtgaplength)
                            {
                                //line = line.Replace("\t\t", "\t");
                                splitline = line.Split(usdtgapdel);
                                splitlength = splitline.Length;
                            }

                            //test column values.
                            //int number = 0;
                            string failreport = string.Empty;
                            // unique customer id
                            //if (!int.TryParse(splitline[uniquecustid], out number))
                            //{
                            //   failreport = failreport + "Unique Customer Id: Not a Number -> ";
                            //}

                            // year.
                            if (splitline[year] != usdtgapyear)
                            {
                                failreport = failreport + "Year: does not match " + year + " -> ";
                            }

                            // month.
                            if (splitline[Month] != usdtgapoldmonth && splitline[Month] != usdtgapmonth)
                            {
                                failreport = failreport + splitline[Month] + " does not match expected" + usdtgapoldmonth + " -> ";
                            }

                            //outputs.
                            if (failreport == string.Empty)
                            {
                                //if everything checks out. write the line in the order of new columns -> from columnindexes.
                                List<string> newlinebuilder = new List<string> { };

                                //change the month column to yyyymm.
                                splitline[Month] = usdtgapmonth;

                                //from og line. get 0,1,2,4. skip the year column. 
                                foreach (int i in columnindexes)
                                {
                                    if (i != year)
                                    {
                                        newlinebuilder.Add(splitline[i]);
                                    }
                                }

                                string newline = string.Join(usdtgapdel.ToString(), newlinebuilder.ToArray());

                                outfile1.WriteLine(newline);
                            }
                            else
                            {
                                outfile2.WriteLine(failreport + "\t" + line);
                                count++;
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine("Good records placed in - {0}", GetFileNameWithoutExtension(usdtgapoutfile));
                        Console.WriteLine("{1} - Bad records placed in - {0}", GetFileNameWithoutExtension(usdtgapoutfile2), count);
                        Console.WriteLine();
                    }
                }
            }
        }

        static public void TestMonthlyFilesGAPTCAR()
        {
            //added splitline[x] = splitline[x].Replace(",", string.Empty); in foreach loop of columns to check 12/10/18

            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the GAP TCAR file.");
            string gapfile = GetAFile();
            string gapfilename = GetFileNameWithoutExtension(gapfile);
            string gapoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + gapfilename + "_good_columns.txt";
            string gapoutfile2 = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + gapfilename + "_bad_columns.txt";

            char gapdel = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string gapmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string gapyear = Console.ReadLine().Trim().ToUpper();

            gapmonth = gapyear + gapmonth;







            using (StreamReader readgapfile = new StreamReader(gapfile))
            {
                using (StreamWriter writegap1 = new StreamWriter(gapoutfile))
                {
                    using (StreamWriter writegap2 = new StreamWriter(gapoutfile2))
                    {
                        string[] expectedfilecolumns = { "Ship To Number", "MSPN", "Month", "NET SLS UNITS w TCI Bibx", "SELLOUT UNITS w/o BIB EXP for TCI", "NET INVC UNITS", "BIB EXPRESS TS UNITS Plus" };
                        string[] newcolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "NET_SALES_UNITS", "SELLOUT_UNITS", "NET_INVC_UNITS", "BIB_X_UNITS" };

                        //List<int> commacleaner = new List<int>{}

                        //get header.
                        string gapheader = readgapfile.ReadLine();
                        string[] columns = gapheader.Split(gapdel);
                        int gaplength = columns.Length;

                        //are all columns there? 
                        List<string> columnchecker = new List<string> { };
                        List<int> columnindexes = new List<int> { };

                        foreach (var s in columns)
                        {
                            columnchecker.Add(s);
                        }

                        bool columnsmissing = false;
                        foreach (var s in expectedfilecolumns)
                        {
                            if (!columnchecker.Contains(s))
                            {
                                columnsmissing = true;
                                Console.WriteLine("GAPTCAR File missing column - {0}", s);
                            }
                            else
                            {
                                //save column index in order they appear in the expected column list - > order matches new header write order.
                                columnindexes.Add(ColumnIndex(gapheader, gapdel, s));
                            }
                        }

                        if (columnsmissing == true)
                        {
                            List<string> outcolumns = expectedfilecolumns.ToList();
                            foreach (var s in outcolumns)
                            {
                                writegap2.WriteLine(s);
                            }

                            Console.WriteLine("Some columns are missing, please check the File, program will now close.");
                            Console.WriteLine("Expected columns listed here - {0}", gapoutfile2);

                        }

                        //write new header -> with new column headers that match the table to be reloaded.
                        string newheader = string.Join(gapdel.ToString(), newcolumns);
                        writegap1.WriteLine(newheader);

                        //write to error file
                        writegap2.WriteLine("fail_report\t" + newheader);


                        //Column indexes.
                        int Month = ColumnIndex(gapheader, gapdel, "Month".ToUpper());

                        //numbertests.
                        int etslsunits = ColumnIndex(gapheader, gapdel, "ET SLS UNITS w TCI Bibx".ToUpper());
                        int selloutunits = ColumnIndex(gapheader, gapdel, "SELLOUT UNITS w/o BIB EXP for TCI".ToUpper());
                        int netinvcunits = ColumnIndex(gapheader, gapdel, "NET INVC UNITS".ToUpper());
                        int bibexpress = ColumnIndex(gapheader, gapdel, "BIB EXPRESS TS UNITS".ToUpper());

                        List<int> columnslist = new List<int> { etslsunits, selloutunits, netinvcunits, bibexpress };

                        //read rest of file and check columns.
                        int count = 0;
                        int linesread = 0;
                        //char tab = '\u0009';
                        string line = string.Empty;
                        while ((line = readgapfile.ReadLine()) != null)
                        {
                            //line = line.Replace(",", string.Empty);
                            string[] splitline = line.Split(gapdel);
                            int splitlength = splitline.Length;

                            //test line Length.
                            while (splitlength != gaplength)
                            {
                                line = line.Replace("\t\t", "\t");
                                splitline = line.Split(gapdel);
                                splitlength = splitline.Length;
                            }

                            //test column values.
                            int number = 0;
                            string failreport = string.Empty;
                            //number tests.
                            foreach (var x in columnslist)
                            {
                                splitline[x] = splitline[x].Replace(",", string.Empty);
                                if (!string.IsNullOrWhiteSpace(splitline[x]))
                                {
                                    if (!int.TryParse(splitline[x], out number))
                                    {
                                        failreport = failreport + columns[x] + ": Not a Number -> ";
                                    }
                                }
                            }

                            // month.
                            if (splitline[Month] != gapmonth)
                            {
                                failreport = failreport + "Month: does not match " + gapmonth + " -> ";
                            }

                            //outputs.
                            if (failreport == string.Empty)
                            {
                                //if everything checks out. write the line in the order of new columns -> from columnindexes.
                                List<string> newlinebuilder = new List<string> { };

                                foreach (int i in columnindexes)
                                {
                                    newlinebuilder.Add(splitline[i]);
                                }

                                string newline = string.Join(gapdel.ToString(), newlinebuilder.ToArray());

                                writegap1.WriteLine(newline);
                            }
                            else
                            {
                                writegap2.WriteLine(failreport + "\t" + line);
                                count++;
                            }
                            linesread++;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Good records placed in - {0}", GetFileNameWithoutExtension(gapoutfile));
                        Console.WriteLine("{1} - Bad records placed in - {0}", GetFileNameWithoutExtension(gapoutfile2), count);
                        Console.WriteLine();
                    }
                }
            }

        }

        static public void MichelinTestMonthlyFilesMSPN()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the MSPN file.");
            string file = GetAFile();
            string filename = GetFileNameWithoutExtension(file);
            string testedoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + filename + "_good_columns.txt";


            char del = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string month = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            month = year + month;

            // error storage
            List<string> missingcolumnlist = new List<string>(); //save the list.
            HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
            Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            int errorlinecount = 0;
            int errordelimitercount = 0;
            int blankvaluesadded = 0;

            //colum lists... they are in order of matching file -> table.
            string[] expectedfilecolumns = { "Unique Customer", "MSPN", "Month", "SELLOUT UNITS" };
            string[] newcolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "SELLOUT_UNITS" };

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
                {
                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(del);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = headersplit.ToList();
                    List<int> columnindexes = new List<int> { };

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, del, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, del, "Month".ToUpper());


                    //write new header -> with new column headers that match the table to be reloaded.
                    string newheader = string.Join(del.ToString(), newcolumns);
                    passedtestfile.WriteLine(newheader);

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(del);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(del);
                            splitlength = splitline.Length;
                        }

                        if (splitlength < linelength) //if the line is not long enough. we just add the value.
                        {
                            List<string> newsplitline = new List<string>();
                            foreach (var value in splitline)
                            {
                                value.Trim();
                                newsplitline.Add(value);
                            }

                            while (splitlength < linelength)
                            {
                                newsplitline.Add(string.Empty);

                                //reassign array values
                                splitline = newsplitline.ToArray();
                                blankvaluesadded++;
                                splitlength = splitline.Length;
                            }

                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        // month.
                        if (splitline[monthcolumn] != month)
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            List<string> newlinebuilder = new List<string>();
                            foreach (var val in columnindexes)
                            {
                                newlinebuilder.Add(splitline[val]);
                            }

                            passedtestfile.WriteLine(string.Join(del.ToString(), newlinebuilder.ToArray()));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} - Test Results:", GetFileNameWithoutExtension(file));
                    Console.ResetColor();

                    if (errordelimitercount > 0)
                    {
                        // read report.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} - Delimiter errors fixed.", errordelimitercount);
                        Console.WriteLine("{0} - Blank values added.", blankvaluesadded);
                        Console.ResetColor();
                    }

                    if (failedrecordsdict.Count != 0 || missingcolumnlist.Count != 0)
                    {
                        string failoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + filename + "_failreport.txt";

                        using (StreamWriter failreportfile = new StreamWriter(failoutfile))
                        {
                            if (missingcolumnlist.Count != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Some columns are missing. Expected columns listed here - {0}", failoutfile);
                                Console.ResetColor();

                                failreportfile.WriteLine("Expected Column(s):");
                                foreach (var column in missingcolumnlist)
                                {
                                    failreportfile.WriteLine(column); //outputs missing expected columns.
                                }

                                failreportfile.WriteLine(); //blank line.
                                failreportfile.WriteLine("Recieved Column(s):");
                                foreach (var column in unmatchedfilecolumnlist)
                                {
                                    failreportfile.WriteLine(column); //output unmatched columns from file
                                }

                            }

                            if (failedrecordsdict.Count > 0)
                            {
                                failreportfile.WriteLine(); //blank line.
                                failreportfile.WriteLine("Record Number|FailedColumns:");
                                char faildel = '|';
                                foreach (var key in failedrecordsdict.Keys)
                                {
                                    List<string> linebuilder = new List<string>();
                                    linebuilder.Add(key.ToString());
                                    foreach (var s in failedrecordsdict[key])
                                    {
                                        linebuilder.Add(s);
                                    }
                                    failreportfile.WriteLine(string.Join(faildel.ToString(), linebuilder.ToArray()));
                                }

                                // failed error message
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("{0} - records failed tests.", errorlinecount);
                                Console.WriteLine("Bad records placed in - {0}", failoutfile);
                                Console.ResetColor();

                                Console.WriteLine();
                                Console.WriteLine("Cleaned records placed in - {0}", testedoutfile);
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        //passed no error message
                        Console.WriteLine();
                        Console.WriteLine("File Passed testing, cleaned records placed in - {0}", testedoutfile);
                        Console.WriteLine();
                    }
                }
            }
        }

        static public void MichelinCanadaTestMonthlyFilesMSPN()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the MSPN file.");
            string file = GetAFile();
            string filename = GetFileNameWithoutExtension(file);
            string testedoutfile = GetDesktopDirectory() + @"\michelin_canada_results" + "\\" + filename + "_good_columns.txt";

            char del = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string month = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string year = Console.ReadLine().Trim().ToUpper();

            month = year + month;

            // error storage
            List<string> missingcolumnlist = new List<string>(); //save the list.
            HashSet<string> unmatchedfilecolumnlist = new HashSet<string>();
            Dictionary<int, List<string>> failedrecordsdict = new Dictionary<int, List<string>>();
            int errorlinecount = 0;
            int errordelimitercount = 0;
            int blankvaluesadded = 0;

            //colum lists... they are in order of matching file -> table.
            string[] expectedfilecolumns = { "Unique Customer", "MSPN", "Month", "SELLOUT UNITS" };
            string[] newcolumns = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "SELLOUT_UNITS" }; //columns match for now.

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter passedtestfile = new StreamWriter(testedoutfile))
                {
                    //get header.
                    string header = readfile.ReadLine();
                    string[] headersplit = header.Split(del);
                    int linelength = headersplit.Length;

                    //are all columns there? 
                    List<string> filecolumn = new List<string> { };
                    List<int> columnindexes = new List<int> { };

                    foreach (var s in expectedfilecolumns)
                    {
                        if (filecolumn.Contains(s))
                        {
                            //save column index in order they appear in the expected column list - > order matches new header write order.
                            columnindexes.Add(ColumnIndex(header, del, s));
                        }
                        else
                        {
                            missingcolumnlist.Add(s);
                            //Console.WriteLine("ADD File missing column - {0}", s);
                        }

                        if (missingcolumnlist.Count > 0)
                        {
                            foreach (var c in filecolumn)
                            {
                                if (!expectedfilecolumns.Contains(c))
                                {
                                    unmatchedfilecolumnlist.Add(c); // columns from file that were not matched.
                                }
                            }
                        }
                    }

                    //Column being checked indexes.
                    int monthcolumn = ColumnIndex(header, del, "Month");

                    //numbertests.
                    int number1 = ColumnIndex(header, del, "SELLOUT UNITS".ToUpper());
                    List<int> numbercolumnslist = new List<int> { number1 };

                    //write new header -> with new column headers that match the table to be reloaded.
                    string newheader = string.Join(del.ToString(), newcolumns);
                    passedtestfile.WriteLine(newheader);

                    // read rest of file and check columns.
                    string line = string.Empty;
                    int recordcount = 0;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        recordcount++; //starts at 1.

                        string[] splitline = line.Split(del);
                        int splitlength = splitline.Length;

                        while (splitlength > linelength)
                        {
                            //test line Length.
                            foreach (var value in splitline)
                            {
                                value.Trim();
                            }

                            if (line.Contains("\t\t"))
                            {
                                line = line.Replace("\t\t", "\t");
                                errordelimitercount++;
                            }
                            splitline = line.Split(del);
                            splitlength = splitline.Length;
                        }

                        if (splitlength < linelength) //if the line is not long enough. we just add the value.
                        {
                            List<string> newsplitline = new List<string>();
                            foreach (var value in splitline)
                            {
                                value.Trim();
                                newsplitline.Add(value);
                            }

                            while (splitlength < linelength)
                            {
                                newsplitline.Add(string.Empty);

                                //reassign array values
                                splitline = newsplitline.ToArray();
                                blankvaluesadded++;
                                splitlength = splitline.Length;
                            }
                        }

                        //test column values.
                        List<string> failreport = new List<string>();

                        //number columns (this one is unique to this file).
                        foreach (var index in numbercolumnslist)
                        {
                            //remove commas.
                            splitline[index] = splitline[index].Replace(",", string.Empty);

                            //negatives test
                            if (splitline[index].Contains(')') || splitline[index].Contains('('))
                            {
                                splitline[index] = splitline[index].Replace(")", string.Empty);
                                splitline[index] = splitline[index].Replace("(", string.Empty);
                                splitline[index] = "-" + splitline[index];
                            }

                            decimal number = 0;
                            if (!string.IsNullOrWhiteSpace(splitline[index]))
                            {
                                if (!decimal.TryParse(splitline[index], out number))
                                {
                                    failreport.Add(newcolumns[index] + ", not a number - " + splitline[index]);
                                }
                            }
                        }

                        // month.
                        if (splitline[monthcolumn] != month)
                        {
                            failreport.Add("Month, does not match - " + splitline[monthcolumn]);
                        }

                        //outputs.
                        if (failreport.Count == 0)
                        {
                            List<string> newlinebuilder = new List<string>();
                            foreach (var val in columnindexes)
                            {
                                newlinebuilder.Add(splitline[val]);
                            }

                            passedtestfile.WriteLine(string.Join(del.ToString(), newlinebuilder.ToArray()));
                        }
                        else
                        {
                            errorlinecount++; // there are errors in this line.
                            failedrecordsdict.Add(recordcount, failreport);
                        }
                    }

                    // test results
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} - Test Results:", GetFileNameWithoutExtension(file));
                    Console.ResetColor();

                    if (errordelimitercount > 0)
                    {
                        // read report.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0} - Delimiter errors fixed.", errordelimitercount);
                        Console.WriteLine("{0} - Blank values added.", blankvaluesadded);
                        Console.ResetColor();
                    }

                    if (failedrecordsdict.Count != 0 || missingcolumnlist.Count != 0)
                    {
                        string failoutfile = GetDesktopDirectory() + @"\michelin_us_results" + "\\" + filename + "_failreport.txt";

                        using (StreamWriter failreportfile = new StreamWriter(failoutfile))
                        {
                            if (missingcolumnlist.Count != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Some columns are missing. Expected columns listed here - {0}", failoutfile);
                                Console.ResetColor();

                                failreportfile.WriteLine("Expected Column(s):");
                                foreach (var column in missingcolumnlist)
                                {
                                    failreportfile.WriteLine(column); //outputs missing expected columns.
                                }

                                failreportfile.WriteLine(); //blank line.
                                failreportfile.WriteLine("Recieved Column(s):");
                                foreach (var column in unmatchedfilecolumnlist)
                                {
                                    failreportfile.WriteLine(column); //output unmatched columns from file
                                }

                            }

                            if (failedrecordsdict.Count > 0)
                            {
                                failreportfile.WriteLine(); //blank line.
                                failreportfile.WriteLine("Record Number|FailedColumns:");
                                char faildel = '|';
                                foreach (var key in failedrecordsdict.Keys)
                                {
                                    List<string> linebuilder = new List<string>();
                                    linebuilder.Add(key.ToString());
                                    foreach (var s in failedrecordsdict[key])
                                    {
                                        linebuilder.Add(s);
                                    }
                                    failreportfile.WriteLine(string.Join(faildel.ToString(), linebuilder.ToArray()));
                                }

                                // failed error message
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("{0} - records failed tests.", errorlinecount);
                                Console.WriteLine("Bad records placed in - {0}", failoutfile);
                                Console.ResetColor();

                                Console.WriteLine();
                                Console.WriteLine("Cleaned records placed in - {0}", testedoutfile);
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        //passed no error message
                        Console.WriteLine();
                        Console.WriteLine("File Passed testing, cleaned records placed in - {0}", testedoutfile);
                        Console.WriteLine();
                    }
                }
            }

        }

        static public void MichelinCanadaTestMonthlyFilesGAPTCAR()
        {
            Console.WriteLine();
            Console.WriteLine("************************************************************************************");
            Console.WriteLine("Please enter the Gap TCAR file.");
            string gapfile = GetAFile();
            string gapfilename = GetFileNameWithoutExtension(gapfile);
            string gapoutfile = GetDesktopDirectory() + @"\michelin_canada_results" + "\\" + gapfilename + "_good_columns.txt";
            string gapoutfile2 = GetDesktopDirectory() + @"\michelin_canada_results" + "\\" + gapfilename + "_bad_columns.txt";

            char gapdel = GetDelimiter();
            Console.Write("Enter the file Month number (ex. 01): ");
            string gapmonth = Console.ReadLine().Trim().ToUpper();
            Console.Write("Enter the files Year (YYYY): ");
            string gapyear = Console.ReadLine().Trim().ToUpper();

            gapmonth = gapyear + gapmonth;

            using (StreamReader readfile = new StreamReader(gapfile))
            {
                using (StreamWriter gapgoodfile = new StreamWriter(gapoutfile))
                {
                    using (StreamWriter gapbadfile = new StreamWriter(gapoutfile2))
                    {

                        string[] expectedcolumns = { "Ship To Number", "MSPN", "Month", "NET SLS UNITS w TCI Bibx", "SELLOUT UNITS w/o BIB EXP for TCI", "NET INVC UNITS", "BIB EXPRESS TS UNITS Plus" };
                        string[] newcolumnnames = { "ST_CUST_NBR", "MSPN_NBR", "CALENDAR_CCYYMM_NBR", "NET_SALES_UNITS", "SELLOUT_UNITS", "NET_INVC_UNITS", "BIB_X_UNITS" }; //columns match for now.

                        //get header.
                        string gapheader = readfile.ReadLine();
                        string[] columns = gapheader.Split(gapdel);
                        int gaplength = columns.Length;

                        //are all columns there? 
                        List<string> columnchecker = new List<string> { };
                        List<int> columnindexes = new List<int> { };

                        foreach (var s in columns)
                        {
                            columnchecker.Add(s);
                        }

                        bool columnsmissing = false;
                        foreach (var s in expectedcolumns)
                        {
                            if (!columnchecker.Contains(s))
                            {
                                columnsmissing = true;
                                Console.WriteLine("CA GAP TCAR File missing column - {0}", s);
                            }
                            else
                            {
                                //save column index in order they appear in the expected column list - > order matches new header write order.
                                columnindexes.Add(ColumnIndex(gapheader, gapdel, s));
                            }
                        }

                        if (columnsmissing == true)
                        {
                            List<string> outcolumns = expectedcolumns.ToList();
                            foreach (var s in outcolumns)
                            {
                                gapbadfile.WriteLine(s);
                            }

                            Console.WriteLine("Some columns are missing, please check the File, program will now close.");
                            Console.WriteLine("Expected columns listed here - {0}", gapbadfile);
                        }

                        //write new header -> with new column headers that match the table to be reloaded.
                        string newheader = string.Join(gapdel.ToString(), newcolumnnames);
                        gapgoodfile.WriteLine(newheader);

                        //write to error file
                        gapbadfile.WriteLine("fail_report\t" + newheader);

                        //Column indexes.
                        int month = ColumnIndex(gapheader, gapdel, "Month");

                        //numbertests.
                        int number1 = ColumnIndex(gapheader, gapdel, "NET SLS UNITS w TCI Bibx".ToUpper());
                        int number2 = ColumnIndex(gapheader, gapdel, "SELLOUT UNITS w/o BIB EXP for TCI".ToUpper());
                        int number3 = ColumnIndex(gapheader, gapdel, "NET INVC UNITS".ToUpper());
                        int number4 = ColumnIndex(gapheader, gapdel, "BIB EXPRESS TS UNITS Plus".ToUpper());
                        List<int> columnslist = new List<int> { number1, number2, number3, number4 };

                        string line = string.Empty;
                        int count = 0;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            //line = line.Replace(",", string.Empty);
                            string[] splitline = line.Split(gapdel);
                            int splitlength = splitline.Length;

                            //test line Length.
                            while (splitlength != gaplength)
                            {
                                line = line.Replace("\t\t", "\t");
                                splitline = line.Split(gapdel);
                                splitlength = splitline.Length;
                            }

                            string failreport = string.Empty;
                            decimal number = 0;
                            // year.
                            //if (splitline[year] != usdtlamyear)
                            //{
                            //   failreport = failreport + "Year: does not match " + year + " -> ";
                            //}

                            // month.
                            if (splitline[month] != gapmonth)
                            {
                                failreport = failreport + "Month: does not match " + gapmonth + " -> ";
                            }

                            //number test
                            foreach (var x in columnslist)
                            {
                                splitline[x] = splitline[x].Replace(",", string.Empty);

                                //negatives test
                                if (splitline[x].Contains(')') || splitline[x].Contains('('))
                                {
                                    splitline[x] = splitline[x].Replace(")", string.Empty);
                                    splitline[x] = splitline[x].Replace("(", string.Empty);
                                    splitline[x] = "-" + splitline[x];
                                }

                                if (!string.IsNullOrWhiteSpace(splitline[x]))
                                {
                                    if (!decimal.TryParse(splitline[x], out number))
                                    {
                                        failreport = failreport + columns[x] + ": Not a Number -> ";
                                    }
                                }
                            }

                            //outputs.
                            if (failreport == string.Empty)
                            {
                                //if everything checks out. write the line in the order of new columns -> from columnindexes.
                                List<string> newlinebuilder = new List<string> { };

                                foreach (int i in columnindexes)
                                {
                                    newlinebuilder.Add(splitline[i]);
                                }

                                string newline = string.Join(gapdel.ToString(), newlinebuilder.ToArray());

                                gapgoodfile.WriteLine(newline);
                            }
                            else
                            {
                                gapbadfile.WriteLine(failreport + "\t" + line);
                                count++;
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine("Good records placed in - {0}", GetFileNameWithoutExtension(gapoutfile));
                        Console.WriteLine("{1} - Bad records placed in - {0}", GetFileNameWithoutExtension(gapoutfile2), count);
                        Console.WriteLine();

                    }
                }
            }
        }


        // Michelin MSPN file process. outputs 4 separate files.

        //static public void MichelinXLSXToPipeTXT(string filepath, string newfilepath)
        //{
        //    //Console.WriteLine("Enter XLSX file.");
        //    //string filepath = GetAFile();

        //    DataSet result = null;

        //    using (var stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
        //    {

        //        // Auto-detect format, supports:
        //        //  - Binary Excel files (2.0-2003 format; *.xls)
        //        //  - OpenXml Excel files (2007 format; *.xlsx)
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            result = reader.AsDataSet(new ExcelDataSetConfiguration() { ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true } });
        //        }
        //    }

        //    //first sheet. can itterate to accompdate for each sheet in the excel file.
        //    DataTable firstsheet = result.Tables[0]; //To txt file Tables[0] = first sheet.

        //    //to csv (copied code: http://dotnetmentors.com/adonet/convert-datatable-to-csv-or-list-or-json-string.aspx)
        //    StreamWriter sw = new StreamWriter(newfilepath, false);
        //    //headers  
        //    for (int i = 0; i < firstsheet.Columns.Count; i++)
        //    {
        //        sw.Write(firstsheet.Columns[i]);
        //        if (i < firstsheet.Columns.Count - 1)
        //        {
        //            sw.Write("|"); // comma
        //        }
        //    }
        //    sw.Write(sw.NewLine);
        //    foreach (DataRow dr in firstsheet.Rows)
        //    {
        //        for (int i = 0; i < firstsheet.Columns.Count; i++)
        //        {
        //            if (!Convert.IsDBNull(dr[i]))
        //            {
        //                string value = dr[i].ToString();
        //                //if (value.Contains(','))
        //                //{
        //                //   value = String.Format("\"{0}\"", value);
        //                //   sw.Write(value);
        //                //}
        //                //else
        //                //{
        //                //   sw.Write(dr[i].ToString());
        //                //}

        //                // wrapp all values....
        //                //value = String.Format("\"{0}\"", value);
        //                //sw.Write(value);

        //                //just write the value... no qualifiers.
        //                sw.Write(value);

        //            }
        //            if (i < firstsheet.Columns.Count - 1)
        //            {
        //                sw.Write("|"); //commma
        //            }
        //        }
        //        sw.Write(sw.NewLine);
        //    }
        //    sw.Close();

        //}

        static public void ACTIVEMSPNFormattedFiles() // add catch for missing columns??? 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine("This is to create the 5 MSPN related files needed for Michelin.");
            Console.WriteLine("Please REMOVE ALL SPACES in the file name and file path.");
            Console.WriteLine("!!!!Please DELETE ALL  \"  in the MSPN file before PROCEEDING!!!!");
            Console.WriteLine();
            Console.WriteLine("Please save the provided .xls or .xlsx file as .CSV");
            Console.ResetColor();
            Console.WriteLine("Click and drag the file here.");
            //Create folder for the files.

            string folderpath = GetDesktopDirectory() + @"\MichelinMSPNFiles";

            if (!Directory.Exists(folderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(folderpath);
            }

            //Get the file.
            string filepath = GetAFile();
            string newfilepath = folderpath + "\\" + GetFileNameWithoutExtension(filepath) + "_notouchy.txt"; //.csv

            Console.WriteLine("Michelin magic happening... please standbye...");


            // Uncomment to -> Convert from XLSX or XLS to CSV. Outputs to new Michelin folder
            //MichelinXLSXToPipeTXT(filepath, newfilepath);

            //    Read File format columns. Resave.
            string formattedactivemspn = folderpath + "\\" + GetFileNameWithoutExtension(filepath) + "_ColumnValuesFormatted.txt";


            // if not using XLSX -> CSV converter uncomment this code.
            //
            // add option to use just a csv file instead of starting with the xls.
            //


            // all new files delimiter.
            char mspndel = '|';  //Manually change to PIPE delimited txt file.

            using (StreamReader activemspnfile = new StreamReader(newfilepath))
            {
                //Header
                string header = activemspnfile.ReadLine();
                string[] columnlist = header.Split(mspndel);

                //Find Columns. - > Leading zeroes format - String.Format("{0:000000}", 6); -> 000006
                int mspnid = ColumnIndex(header, mspndel, "MSPN ID");                      //MSPN
                int brandid = ColumnIndex(header, mspndel, "Code Marque ID");              //BRAND
                int productlineid = ColumnIndex(header, mspndel, "Product Line DESC");     //PRODUCTLINE
                int groupcategorynames = ColumnIndex(header, mspndel, "Groupe Category");  //DSS_CATEGORY
                int customerspecificflag = ColumnIndex(header, mspndel, "Customer Specific Flag");

                List<string> grpcategoryvalues = new List<string> { "ENTRY (S,T)", "V", "H", "Z", "REC/COM", "WINTER" }; //Group Category (case sensative)

                //Create Formatted verision of the file.
                using (StreamWriter formatedwritefile = new StreamWriter(formattedactivemspn))
                {
                    formatedwritefile.WriteLine(header);

                    //Format Columns.
                    string line = string.Empty;
                    while ((line = activemspnfile.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(mspndel);

                        //Leading 0 formats.
                        splitline[mspnid] = String.Format("{0:00000}", splitline[mspnid]);
                        splitline[brandid] = String.Format("{0:000}", splitline[brandid]);
                        splitline[productlineid] = String.Format("{0:0000000}", splitline[productlineid]);

                        //Group Category Formats.
                        if (!grpcategoryvalues.Contains(splitline[groupcategorynames].Trim().ToUpper().Replace("\"", string.Empty)))
                        {
                            Console.Write("Group Category column error found, current value - {0}, enter new value: ", splitline[groupcategorynames]);
                            string valuefix = Console.ReadLine().Trim().ToUpper().Replace("\"", string.Empty);

                            splitline[groupcategorynames] = valuefix;
                        }

                        //Customer Specific Flag - formats.
                        if (string.IsNullOrWhiteSpace(splitline[customerspecificflag]))
                        {
                            splitline[customerspecificflag] = "N/A";
                        }

                        //join the formatted strings. write to file.
                        string newline = string.Join(mspndel.ToString(), splitline);
                        formatedwritefile.WriteLine(newline);
                    }
                }
            }

            // Active_MSPN file.
            string activemspnfilereload = folderpath + "\\ActiveMSPNS.txt";

            using (StreamReader readformatedmspns = new StreamReader(formattedactivemspn))
            {
                //header.
                string header = readformatedmspns.ReadLine();

                //E1 Table columns.
                string[] tablecolumns = { "TIRE_SIZE", "DSS_CATEGORY", "MSPN", "PRODUCTLINE", "BRAND", "COMP_FLAG", "DESCRIPTION", "PMET" };
                string[] filecolumnstochange = { "Tire Size", "Groupe Category", "MSPN ID", "Product Line DESC", "Code Marque DESC", "Comp Flag", "GLPC DESC", "P Met Ind" };

                List<int> columnindexes = new List<int> { };

                //Get Column indexes.
                foreach (var s in filecolumnstochange)
                {
                    columnindexes.Add(ColumnIndex(header, mspndel, s));
                }

                using (StreamWriter writemspn = new StreamWriter(activemspnfilereload))
                {
                    //write header
                    string newheader = string.Join(mspndel.ToString(), tablecolumns);
                    writemspn.WriteLine(newheader);

                    //read rest of file, write new lines.
                    string line = string.Empty;
                    while ((line = readformatedmspns.ReadLine()) != null)
                    {
                        List<string> linebuilder = new List<string> { };
                        string[] splitline = line.Split(mspndel);

                        foreach (var i in columnindexes)
                        {
                            linebuilder.Add(splitline[i]);
                        }

                        //combine list and add to string.
                        string newline = string.Join(mspndel.ToString(), linebuilder);

                        //write string to new file.
                        writemspn.WriteLine(newline);
                    }

                }
            }


            // Active_MSPN1 file.
            string activemspnfile1reload = folderpath + "\\ActiveMSPNS1.txt";

            using (StreamReader readformatedmspns = new StreamReader(formattedactivemspn))
            {
                //header.
                string header = readformatedmspns.ReadLine();

                //Column filter.
                int filtercolumn = ColumnIndex(header, mspndel, "Code Marque DESC"); //    Filter the Code Marque DESC column for BFGoodrich, Michelin, Uniroyal Brands. write those rows to new file.
                List<string> filteroptions = new List<string> { "BFGOODRICH", "MICHELIN", "UNIROYAL" };


                using (StreamWriter writemspn1 = new StreamWriter(activemspnfile1reload))
                {
                    //Write Header.
                    writemspn1.WriteLine(header);

                    //read rest of file.
                    string line = string.Empty;
                    while ((line = readformatedmspns.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(mspndel);

                        if (filteroptions.Contains(splitline[filtercolumn].ToUpper().Trim()))
                        {
                            writemspn1.WriteLine(line);
                        }

                    }
                }
            }


            //Group_Category_Lookup - from mspns1 file.
            // https://confluence.nexgen.neustar.biz/pages/viewpage.action?pageId=128004469
            Console.WriteLine();
            Console.WriteLine("Group_Category_Lookup is still unchanged - output generated anyway...");

            string groupcategorylookupfile = folderpath + "\\GroupCategoryLookupNOTUSED.txt";

            using (StreamReader readactivemspn1 = new StreamReader(activemspnfile1reload))
            {
                //header
                string header = readactivemspn1.ReadLine();

                // Customer Specific Flag column.
                string groupcategorycolumn = "Groupe Category";

                //find column.
                int groupcategoryindex = ColumnIndex(header, mspndel, groupcategorycolumn);

                using (StreamWriter writegroupcategory = new StreamWriter(groupcategorylookupfile))
                {
                    //new columns
                    string[] newcolumns = { "LABEL", "VALUE" };

                    //list to store uniqe flags.
                    List<string> uniquegroupcategory = new List<string> { };

                    //write header. 
                    writegroupcategory.WriteLine(string.Join(mspndel.ToString(), newcolumns));

                    string line = string.Empty;
                    while ((line = readactivemspn1.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(mspndel);

                        if (!uniquegroupcategory.Contains(splitline[groupcategoryindex]))
                        {
                            uniquegroupcategory.Add(splitline[groupcategoryindex]);
                        }
                    }

                    string originalvalue = "ENTRY (S,T)";
                    string changevalue = "ENTRY (S T)";

                    foreach (var s in uniquegroupcategory)
                    {
                        if (s == originalvalue)
                        {
                            writegroupcategory.WriteLine(s + mspndel + changevalue);
                        }
                        else
                        {
                            writegroupcategory.WriteLine(s + mspndel + s);
                        }
                    }
                }
            }


            // PRODUCTLINES_LOOKUP file - From the Active_MSPNS1 file.

            string productlineslookup = folderpath + "\\ProductLines.txt";

            using (StreamReader readactivemspns1 = new StreamReader(activemspnfile1reload))
            {
                //list to hold the unique ids from the product ID column.
                List<string> productids = new List<string> { };
                //header.
                string header = readactivemspns1.ReadLine();

                string[] filecolumnstochange = { "Product Line ID", "Groupe Category", "Code Marque ID", "Product Line DESC" };
                //string productlinedesc = "Product Line DESC";
                string[] tablecolumns = { "PRODUCT_ID", "RT_GRP_CAT", "RT_BRAND", "PRODUCTLINEDESC" };
                //create new column by combining 'Product Line ID' + "-" + 'Product Line Desc' -> 'PRODUCTLINEDESC'

                //Get Column indexes.
                List<int> columnindexes = new List<int> { };
                foreach (var s in filecolumnstochange)
                {
                    columnindexes.Add(ColumnIndex(header, mspndel, s));
                }

                using (StreamWriter writeproductlines = new StreamWriter(productlineslookup))
                {
                    //write header.
                    string newheader = string.Join(mspndel.ToString(), tablecolumns);
                    writeproductlines.WriteLine(newheader);

                    //read rest of file.
                    string line = string.Empty;
                    while ((line = readactivemspns1.ReadLine()) != null)
                    {
                        List<string> linebuilder = new List<string> { };
                        string[] splitline = line.Split(mspndel);

                        string productidgroups = splitline[columnindexes[0]] + "_" + splitline[columnindexes[1]]; //Product_ID and Group Category together into new ID -> ProductIDGroups

                        //    select unique ProductIDGroups - this is what eric said to do....
                        if (!productids.Contains(productidgroups))
                        {
                            //add found value to list.
                            productids.Add(productidgroups);

                            //get column data
                            foreach (var i in columnindexes)
                            {
                                if (splitline[i].ToUpper().Trim() == "ENTRY (S,T)") // ENTRY(S,T) changed to ENTRY(S T)
                                {
                                    linebuilder.Add(splitline[i].Replace(',', ' '));
                                }
                                else
                                {
                                    linebuilder.Add(splitline[i]);
                                }
                            }

                            //format 'Product Line ID-DESC'
                            string[] lineformatting = linebuilder.ToArray();
                            // change last value.
                            lineformatting[lineformatting.Length - 1] = lineformatting[0] + "-" + lineformatting[lineformatting.Length - 1];

                            string newline = string.Join(mspndel.ToString(), lineformatting);
                            writeproductlines.WriteLine(newline);
                        }
                    }
                }
            }


            //KEYPRODUCTLINES file - from ActiveMSPNS1
            string keyproductlines = folderpath + "\\KEYPRODUCTLINES.txt";

            using (StreamReader readactivemspns1 = new StreamReader(activemspnfile1reload))
            {
                //list to hold the unique ids from the product ID column.
                List<string> productids = new List<string> { };
                //header.
                string header = readactivemspns1.ReadLine();

                string[] filecolumnstochange = { "Product Line ID", "Product Line DESC" };
                //string productlinedesc = "Product Line DESC";
                string[] tablecolumns = { "PRODUCT_ID", "PRODUCTLINEDESC" };
                //create new column by combining 'Product Line ID' + "-" + 'Product Line Desc' -> 'PRODUCTLINEDESC'

                //Get Column indexes.
                List<int> columnindexes = new List<int> { };
                foreach (var s in filecolumnstochange)
                {
                    columnindexes.Add(ColumnIndex(header, mspndel, s));
                }

                using (StreamWriter writekeyproductlines = new StreamWriter(keyproductlines))
                {
                    //write header.
                    string newheader = string.Join(mspndel.ToString(), tablecolumns);
                    writekeyproductlines.WriteLine(newheader);

                    //read rest of file.
                    string line = string.Empty;
                    while ((line = readactivemspns1.ReadLine()) != null)
                    {
                        List<string> linebuilder = new List<string> { };
                        string[] splitline = line.Split(mspndel);

                        //    select unique Product Line IDs - this is what eric said to do....
                        if (!productids.Contains(splitline[columnindexes[0]]))
                        {
                            //add found value to list.
                            productids.Add(splitline[columnindexes[0]]);

                            //get column data
                            foreach (var i in columnindexes)
                            {
                                linebuilder.Add(splitline[i]);
                            }

                            string[] buildnewline = linebuilder.ToArray();

                            string newline = string.Join(mspndel.ToString(), buildnewline);
                            writekeyproductlines.WriteLine(newline);
                        }
                    }
                }
            }


            // CUSTOMER_SPECIFIC_FLAG_LOOKUP file - from ActiveMSPNS1 file.
            string customerspecificfile = folderpath + "\\CustomerSpecificFlagLookup.txt";


            using (StreamReader readactivemspn1 = new StreamReader(activemspnfile1reload))
            {
                //header
                string header = readactivemspn1.ReadLine();

                // Customer Specific Flag column.
                string custromerflagcolumn = "Customer Specific Flag";

                //find column.
                int flagcolumnindex = ColumnIndex(header, mspndel, custromerflagcolumn);

                using (StreamWriter customerflagfile = new StreamWriter(customerspecificfile))
                {
                    //new columns
                    string[] newcolumns = { "LABEL", "VALUE" };

                    //list to store uniqe flags.
                    List<string> uniqueflags = new List<string> { };

                    //write header. 
                    customerflagfile.WriteLine(string.Join(mspndel.ToString(), newcolumns));

                    string line = string.Empty;
                    while ((line = readactivemspn1.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(mspndel);

                        if (!uniqueflags.Contains(splitline[flagcolumnindex]))
                        {
                            uniqueflags.Add(splitline[flagcolumnindex]);
                        }
                    }

                    foreach (var s in uniqueflags)
                    {
                        //make '2' columns.
                        string newline = s + mspndel + s;

                        //writeline.
                        customerflagfile.WriteLine(newline);
                    }

                    //Add last ALL rows.
                    customerflagfile.WriteLine("ALL" + mspndel + "ALL");
                }
            }

            //What's been done....
            Console.WriteLine();
            Console.WriteLine("Done!");
            Console.WriteLine();
            Console.WriteLine("You should see a new folder on your Desktop Labeled, \"MichelinMSPNFiles\" with the following PIPE Delimited files: ");
            Console.WriteLine();

            string[] filearray = Directory.GetFiles(folderpath);
            foreach (var f in filearray)
            {
                Console.WriteLine(GetFileNameWithoutExtension(f) + ".txt");
            }
            Console.WriteLine();
        }



        //Michelin Polk Files
        //
        // used for annual updates.
        //Reads polk_zip file(90MM records, break into 8 parts) outputs #of original files x2 files and 3 condensed files.
        // polk code + vehicle counts file, state vehicle counts file, zip code vehicle coutns file.
        static public void MichelinPOLKReaderMultiTask()
        {
            // create directory for splitfiles.
            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\splitfiles";
            string zipfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\zipcounts";
            string polkfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\polkcounts";

            if (!Directory.Exists(splitfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(splitfilefolderpath);
            }

            if (!Directory.Exists(polkfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(polkfilefolderpath);
            }

            if (!Directory.Exists(zipfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(zipfilefolderpath);
            }

            // get source file.
            Console.WriteLine("-Enter Polk Zip file-");
            Console.Write("File: ");
            var inFile = new FileInfo(Console.ReadLine());
            //var polkziplistfile = Console.ReadLine();
            char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            //splitfile code. (code copies from BreakOneFileIntoMany)
            Int64 sourceRecordCount, iRecordCount, NoOutputFiles;

            Console.Write("Source Record Count (Enter nothing for auto count): ");

            if (Int64.TryParse(Console.ReadLine(), out iRecordCount))
                sourceRecordCount = iRecordCount;
            else
                sourceRecordCount = File.ReadLines(inFile.FullName).LongCount();

            Console.Write("No. of Output Files: ");
            NoOutputFiles = Int64.Parse(Console.ReadLine());

            Int64 linesWritten;
            double maxBreakoutRecordsPerFile = Math.Ceiling((double)sourceRecordCount / (double)NoOutputFiles);
            string readLine;

            Console.WriteLine("Spliting file...");

            using (var reader = new StreamReader(inFile.OpenRead()))
            {
                string header = reader.ReadLine();

                for (int i = 1; i <= NoOutputFiles; i++)
                {
                    using (var writer = new StreamWriter(splitfilefolderpath + "\\" + (inFile.Name.Replace(inFile.Extension, "").ToString() + "_split_" + i + inFile.Extension.ToString())))
                    {
                        writer.WriteLine(header);
                        linesWritten = 0;

                        while (linesWritten < maxBreakoutRecordsPerFile && (readLine = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(readLine);
                            linesWritten++;
                        }
                    }
                }
            }

            // read splitfiles.
            //Console.WriteLine("-Drag and Drop Michelin Zip Data Files Folder here-");
            //Console.Write("Folder: ");
            //string zipdatadirectory = Console.ReadLine();
            string[] michelinzipdatafilepaths = Directory.GetFiles(@splitfilefolderpath);

            Console.WriteLine("-Enter State file-");
            string statefile = GetAFile();
            char statedeli = GetDelimiter();
            Console.WriteLine();

            Dictionary<string, HashSet<string>> statezipdictionary = new Dictionary<string, HashSet<string>>();

            using (StreamReader statezipfile = new StreamReader(statefile))
            {
                string header = statezipfile.ReadLine();

                string line = string.Empty;
                while ((line = statezipfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, statedeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(statedeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    string statecode = splitline[1].Replace(txtq.ToString(), "");
                    if (string.IsNullOrWhiteSpace(statecode))
                    {
                        statecode = "blank"; //accounts for states or provinces that do not appear in the state/province lookup files
                    }

                    string statename = splitline[2].Replace(txtq.ToString(), "");
                    string zip = splitline[0].Replace(txtq.ToString(), "");

                    if (!statezipdictionary.ContainsKey(statecode))
                    {
                        HashSet<string> temphash = new HashSet<string>();
                        temphash.Add(zip);
                        statezipdictionary.Add(statecode, temphash);
                    }
                    else
                    {
                        statezipdictionary[statecode].Add(zip);
                    }

                }
            }

            List<Task> tasklist = new List<Task>(); //using a task array and a file array was not working.
            try
            {
                foreach (var file in michelinzipdatafilepaths)
                {
                    var task = new Task(async () =>
                    {
                        string returned = await (MichelinPOLKZipDataReader(file, deli, txtq, statezipdictionary));
                        Console.WriteLine(returned);

                    });

                    tasklist.Add(task);
                    task.Start();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            try
            {
                Task.WaitAll(tasklist.ToArray());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            //produces two files with total counts for polkkeys and zipcodes
            MichelinPOLKCountsFileCondenser(polkfilefolderpath, deli);
            MichelinPOLKZipCountsFileCondenser(zipfilefolderpath, deli); //by zip code file and by state code file.

        }

        static public Task<string> MichelinPOLKZipDataReader(string file1, char deli1, char txtq, Dictionary<string, HashSet<string>> statelookup)
        {
            string zipfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\zipcounts";
            string polkfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\polkcounts";

            string zipcountsfile = zipfilefolderpath + "\\" + GetFileNameWithoutExtension(file1) + "zip_counts.txt"; // list of zips, appended with counts
            string polkcountsfile = polkfilefolderpath + "\\" + GetFileNameWithoutExtension(file1) + "polk_counts.txt";

            Dictionary<string, int> ziplist = new Dictionary<string, int>();
            Dictionary<string, int> polkkeysums = new Dictionary<string, int>();

            int rowcount = 0;

            using (StreamReader readfile = new StreamReader(file1))
            {
                // read and save header.
                string header = readfile.ReadLine();

                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli1, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(deli1));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    string zip = splitline[0].Replace(txtq.ToString(), "");
                    string polk = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));

                    // ADD check for polk + zip combo. using a list made the process run for EVER!!!!! use a dict instead, or hashset.

                    if (!ziplist.ContainsKey(zip))
                    {
                        ziplist.Add(zip, vehiclecount);
                    }
                    else
                    {
                        ziplist[zip] += vehiclecount;
                    }


                    if (!polkkeysums.ContainsKey(polk))
                    {
                        polkkeysums.Add(polk, vehiclecount);
                    }
                    else
                    {
                        polkkeysums[polk] += vehiclecount;
                    }

                    rowcount++;
                }
            }

            using (StreamWriter zipcountoutfile = new StreamWriter(zipcountsfile))
            {
                HashSet<string> zipwasfound = new HashSet<string>();

                zipcountoutfile.WriteLine("State, Zipcode,VehicleCount");

                foreach (var state in statelookup.Keys)
                {
                    foreach (var value in statelookup[state])
                    {
                        foreach (var zip in ziplist.Keys)
                        {
                            if (value.Contains(zip))
                            {
                                zipwasfound.Add(zip);

                                List<string> linebuilder = new List<string>();
                                linebuilder.Add(state);
                                linebuilder.Add(zip);
                                linebuilder.Add(ziplist[zip].ToString());

                                zipcountoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                            }
                        }
                    }
                }

                foreach (var zip in ziplist.Keys) //check for zips that where not matched to a state.
                {
                    if (!zipwasfound.Contains(zip))
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add("99"); // set artificial state code to 99. indicates zip was not found in state-zip lookup.
                        linebuilder.Add(zip);
                        linebuilder.Add(ziplist[zip].ToString());
                        zipcountoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                    }
                }
            }

            using (StreamWriter polkcountsoutfile = new StreamWriter(polkcountsfile))
            {
                polkcountsoutfile.WriteLine("Polkkey,VehicleCount");

                foreach (var polkkey in polkkeysums.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(polkkey);
                    linebuilder.Add(polkkeysums[polkkey].ToString());

                    polkcountsoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                }
            }

            string returnstring = rowcount.ToString();

            return Task.FromResult(returnstring);

        }

        static public void MichelinPOLKCountsFileCondenser(string polkdatadirectory, char deli)
        {
            //Console.Write("Drag and Drop Michelin Polk Count Data Files Folder here: ");
            //string polkdatadirectory = Console.ReadLine();
            string[] michelinpolkdatafilepaths = Directory.GetFiles(polkdatadirectory);
            //char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\";
            string polkcountsfile = splitfilefolderpath + "\\" + "polk_counts.txt";

            Dictionary<string, int> uspolkcounts = new Dictionary<string, int>();

            foreach (var file in michelinpolkdatafilepaths)
            {
                using (StreamReader polkcountfile = new StreamReader(file))
                {
                    polkcountfile.ReadLine();

                    string line = string.Empty;
                    while ((line = polkcountfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();
                        string polkkey = splitline[0].Replace(txtq.ToString(), "");
                        int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                        if (!uspolkcounts.ContainsKey(polkkey))
                        {
                            uspolkcounts.Add(polkkey, vehiclecount);
                        }
                        else
                        {
                            uspolkcounts[polkkey] += vehiclecount;
                        }
                    }
                }
            }

            using (StreamWriter polkcountsoutfile = new StreamWriter(polkcountsfile))
            {
                var totalvehicles = uspolkcounts.Sum(vehiclecount => vehiclecount.Value);

                polkcountsoutfile.WriteLine("Polkkey,VehicleCount - {0}", totalvehicles);

                foreach (var polkkey in uspolkcounts.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(polkkey);
                    linebuilder.Add(uspolkcounts[polkkey].ToString());

                    polkcountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                }
            }
        }

        static public void MichelinPOLKZipCountsFileCondenser(string zipdatadirectory, char deli)
        {
            //Console.Write("Drag and Drop Michelin Zip Count Data Files Folder here: ");
            //string zipdatadirectory = Console.ReadLine();
            string[] michelinzipdatafilepaths = Directory.GetFiles(@zipdatadirectory);
            //char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts\";
            string zipcountsfile = splitfilefolderpath + "\\" + "zip_counts.txt";
            string statecountsfile = splitfilefolderpath + "\\" + "state_counts.txt";

            // state key, zipcode key, vehicle count
            Dictionary<string, Dictionary<string, int>> uszipcounts = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> usstatescounts = new Dictionary<string, int>();

            foreach (var file in michelinzipdatafilepaths)
            {
                using (StreamReader zipcountfile = new StreamReader(file))
                {
                    zipcountfile.ReadLine(); //read headers.

                    string line = string.Empty;
                    while ((line = zipcountfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();
                        string statecode = splitline[0].Replace(txtq.ToString(), "");
                        string zip = splitline[1].Replace(txtq.ToString(), "");
                        int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));

                        if (!uszipcounts.ContainsKey(statecode)) // if the state dictionary does not have the state.
                        {
                            Dictionary<string, int> tempdict = new Dictionary<string, int>();
                            tempdict.Add(zip, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                            uszipcounts.Add(statecode, tempdict);
                        }
                        else
                        {
                            if (!uszipcounts[statecode].ContainsKey(zip)) //if the nested dictionary doesnt contain the zip.
                            {
                                uszipcounts[statecode].Add(zip, vehiclecount);
                            }
                            else
                            {
                                uszipcounts[statecode][zip] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                            }
                        }

                        if (!usstatescounts.ContainsKey(statecode))
                        {
                            usstatescounts.Add(statecode, vehiclecount);
                        }
                        else
                        {
                            usstatescounts[statecode] += vehiclecount;
                        }
                    }
                }
            }

            using (StreamWriter zipcountsoutfile = new StreamWriter(zipcountsfile))
            {
                long totalvehiclecount = 0;

                foreach (var state in uszipcounts.Keys)
                {
                    Dictionary<string, int> tempdict = uszipcounts[state];

                    totalvehiclecount += tempdict.Sum(vehiclecount => vehiclecount.Value);
                }

                zipcountsoutfile.WriteLine("StateCode,ZipCode,VehicleCount - {0}", totalvehiclecount);

                foreach (var statecode in uszipcounts.Keys)
                {
                    foreach (var zip in uszipcounts[statecode].Keys)
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(statecode);
                        linebuilder.Add(zip);
                        linebuilder.Add(uszipcounts[statecode][zip].ToString());

                        zipcountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                    }
                }
            }

            using (StreamWriter statecountsoutfile = new StreamWriter(statecountsfile)) // unsorted output. can sort using hash or list of the keys, output based on that.
            {
                statecountsoutfile.WriteLine("StateCode,VehicleCount");
                foreach (var state in usstatescounts.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(state);
                    linebuilder.Add(usstatescounts[state].ToString());

                    statecountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                }
            }
        }

        // looks for added or dropped zip codes.
        static public void MichelinPOLKNewZipFinder()
        {
            // use previously created zip counts files.

            Console.WriteLine("-Enter Current Year Zip Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year Zip Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            char txtq = '"';
            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(splitfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(splitfilefolderpath);
            }

            string newziplist = splitfilefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_newzips.txt";
            string droppedziplist = splitfilefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_drops.txt";

            HashSet<string> newzips = new HashSet<string>();
            HashSet<string> droppedzips = new HashSet<string>();

            HashSet<string> currentuniquezips = new HashSet<string>();
            HashSet<string> lastuniquezips = new HashSet<string>();
            int currentuniquecounter = 0;
            int lastuniquecounter = 0;
            string header = string.Empty;

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                header = currentfile.ReadLine(); // header read

                //add check to find the zip_code column.

                string line = string.Empty;
                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();

                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    int geoidindex = 1; // add checks for if contains txtqs requires rewrite of alot of methods.

                    currentuniquezips.Add(splitline[geoidindex]);

                    currentuniquecounter = currentuniquezips.Count;
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                lastfile.ReadLine(); // header read

                //add check to find the zip_code column.

                string line = string.Empty;
                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();

                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    int geoidindex = 1; // add checks for if contains txtqs requires rewrite of alot of methods.

                    lastuniquezips.Add(splitline[geoidindex]);

                    lastuniquecounter = lastuniquezips.Count;
                }
            }

            foreach (var zip in currentuniquezips)
            {
                if (!lastuniquezips.Contains(zip))
                {
                    newzips.Add(zip);
                }
            }

            foreach (var zip in lastuniquezips)
            {
                if (!currentuniquezips.Contains(zip))
                {
                    droppedzips.Add(zip);
                }
            }

            using (StreamWriter newzipsfile = new StreamWriter(newziplist))
            {
                List<string> splitlinebuilder = new List<string>();

                if (header.Contains(txtq))
                {
                    splitlinebuilder.AddRange(SplitLineWithTxtQualifier(header, currentyeardeli, txtq, false));
                }
                else
                {
                    splitlinebuilder.AddRange(header.Split(currentyeardeli));
                }

                string[] splitheader = splitlinebuilder.ToArray();
                string geoname = splitheader[1].Trim();
                newzipsfile.WriteLine("{0}", geoname); //header

                foreach (var zip in newzips)
                {
                    newzipsfile.WriteLine(zip);
                }
            }

            using (StreamWriter droppedzipsfile = new StreamWriter(droppedziplist))
            {
                List<string> splitlinebuilder = new List<string>();

                if (header.Contains(txtq))
                {
                    splitlinebuilder.AddRange(SplitLineWithTxtQualifier(header, currentyeardeli, txtq, false));
                }
                else
                {
                    splitlinebuilder.AddRange(header.Split(currentyeardeli));
                }

                string[] splitheader = splitlinebuilder.ToArray();
                string geoname = splitheader[1].Trim();
                droppedzipsfile.WriteLine("{0}", geoname); //header

                foreach (var zip in droppedzips)
                {
                    droppedzipsfile.WriteLine(zip);
                }
            }
        }


        // summarize outputs from file condensers and compare to last year.
        static public void MichelinPOLKZipCountsDiffReader()
        {
            Console.WriteLine("-Enter Current Year Zip Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year Zip Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            //Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> currentyeardata = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> lastyeardata = new Dictionary<string, Dictionary<string, int>>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string statecode = splitline[0].Replace(txtq.ToString(), "");
                    string zip = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));


                    if (!currentyeardata.ContainsKey(statecode)) // if the state dictionary does not have the state.
                    {
                        Dictionary<string, int> tempdict = new Dictionary<string, int>();
                        tempdict.Add(zip, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                        currentyeardata.Add(statecode, tempdict);
                    }
                    else
                    {
                        if (!currentyeardata[statecode].ContainsKey(zip)) //if the nested dictionary doesnt contain the zip.
                        {
                            currentyeardata[statecode].Add(zip, vehiclecount);
                        }
                        else
                        {
                            currentyeardata[statecode][zip] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                        }
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string lastheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string statecode = splitline[0].Replace(txtq.ToString(), "");
                    string zip = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));


                    if (!lastyeardata.ContainsKey(statecode)) // if the state dictionary does not have the state.
                    {
                        Dictionary<string, int> tempdict = new Dictionary<string, int>();
                        tempdict.Add(zip, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                        lastyeardata.Add(statecode, tempdict);
                    }
                    else
                    {
                        if (!lastyeardata[statecode].ContainsKey(zip)) //if the nested dictionary doesnt contain the zip.
                        {
                            lastyeardata[statecode].Add(zip, vehiclecount);
                        }
                        else
                        {
                            lastyeardata[statecode][zip] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                        }
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("StateCode, ZipCode, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var state in currentyeardata.Keys)
                {
                    foreach (var zip in currentyeardata[state].Keys)
                    {
                        if (lastyeardata.ContainsKey(state))
                        {
                            if (lastyeardata[state].ContainsKey(zip))
                            {
                                double percentdiff = 0;

                                if (lastyeardata[state][zip] != 0)
                                {
                                    // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                                    double currentvalue = currentyeardata[state][zip];
                                    double lastvalue = lastyeardata[state][zip];

                                    percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                                }
                                else
                                {
                                    percentdiff = currentyeardata[state][zip] * 100;
                                }

                                List<string> linebuilder = new List<string>();
                                linebuilder.Add(state); // state
                                linebuilder.Add(zip); // zip
                                linebuilder.Add(lastyeardata[state][zip].ToString());
                                linebuilder.Add(currentyeardata[state][zip].ToString());
                                linebuilder.Add(percentdiff.ToString() + "%");

                                percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                            }
                        }
                    }
                }
            }
        }

        static public void MichelinPOLKPolkKeyCountsDiffReader()
        {
            Console.WriteLine("-Enter Current Year PolkKey Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year PolkKey Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, int> lastyeardata = new Dictionary<string, int>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string polkkey = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!currentyeardata.ContainsKey(polkkey)) //if the nested dictionary doesnt contain the zip.
                    {
                        currentyeardata.Add(polkkey, vehiclecount);
                    }
                    else
                    {
                        currentyeardata[polkkey] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string currentheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string polkkey = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!lastyeardata.ContainsKey(polkkey)) //if the nested dictionary doesnt contain the zip.
                    {
                        lastyeardata.Add(polkkey, vehiclecount);
                    }
                    else
                    {
                        lastyeardata[polkkey] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("PolkKey, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var polkkey in currentyeardata.Keys)
                {
                    if (lastyeardata.ContainsKey(polkkey))
                    {
                        double percentdiff = 0;

                        if (lastyeardata[polkkey] != 0)
                        {
                            // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                            double currentvalue = currentyeardata[polkkey];
                            double lastvalue = lastyeardata[polkkey];

                            percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                        }
                        else
                        {
                            percentdiff = currentyeardata[polkkey] * 100;
                        }

                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(polkkey); // state
                        linebuilder.Add(lastyeardata[polkkey].ToString());
                        linebuilder.Add(currentyeardata[polkkey].ToString());
                        linebuilder.Add(percentdiff.ToString() + "%");

                        percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        static public void MichelinPOLKStateCountsDiffReader() // same code as MIchelinPolkKeyCountsDiffReader() just uses state names instead of polk key.
        {
            Console.WriteLine("-Enter Current Year State Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year State Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, int> lastyeardata = new Dictionary<string, int>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string statecode = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!currentyeardata.ContainsKey(statecode)) //if the nested dictionary doesnt contain the zip.
                    {
                        currentyeardata.Add(statecode, vehiclecount);
                    }
                    else
                    {
                        currentyeardata[statecode] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string currentheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string statecode = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!lastyeardata.ContainsKey(statecode)) //if the nested dictionary doesnt contain the zip.
                    {
                        lastyeardata.Add(statecode, vehiclecount);
                    }
                    else
                    {
                        lastyeardata[statecode] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("StateCode, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var statecode in currentyeardata.Keys)
                {
                    if (lastyeardata.ContainsKey(statecode))
                    {
                        double percentdiff = 0;

                        if (lastyeardata[statecode] != 0)
                        {
                            // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                            double currentvalue = currentyeardata[statecode];
                            double lastvalue = lastyeardata[statecode];

                            percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                        }
                        else
                        {
                            percentdiff = currentyeardata[statecode] * 100;
                        }

                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(statecode); // state
                        linebuilder.Add(lastyeardata[statecode].ToString());
                        linebuilder.Add(currentyeardata[statecode].ToString());
                        linebuilder.Add(percentdiff.ToString() + "%");

                        percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        // other qa tasks.
        static public void MichelinPOLKVehicleInfoFileCleaner() // clean the new vehicle file first
        {
            // expected header: POLK_KEY,YEAR_MODEL,MAKE_NAME,MODEL_NAME,TRIM_NAME,SEGMENT_NAME

            // add check for 'blanks' -> change blanks to 'N/A'

            Console.WriteLine("-Enter Current Year Vehicle Data file-");
            string file = GetAFile();
            char deli = GetDelimiter();
            char txtq = GetTXTQualifier();
            Console.WriteLine();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string cleanedfile = filefolderpath + "\\" + GetFileNameWithoutExtension(file) + "cleaned.txt";

            using (StreamReader vehiclecountsfile = new StreamReader(file))
            {
                using (StreamWriter cleanedvehiclefile = new StreamWriter(cleanedfile))
                {
                    string header = vehiclecountsfile.ReadLine();
                    cleanedvehiclefile.WriteLine(header);
                    List<string> headersplitbuilder = new List<string>();

                    if (header.Contains(txtq))
                    {
                        headersplitbuilder.AddRange(SplitLineWithTxtQualifier(header, deli, txtq, false));
                    }
                    else
                    {
                        headersplitbuilder.AddRange(header.Split(deli));
                    }

                    string year = "YEAR_MODEL"; // find the index of this column. hard coded for now.

                    int yearindex = headersplitbuilder.IndexOf(year); // trying out new method. shorter.

                    string line = string.Empty;
                    int counter = 0;
                    while ((line = vehiclecountsfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();

                        if (splitline[yearindex].ToCharArray().Count() != 4)
                        {
                            splitline[yearindex] = "0001";
                            counter++;
                        }

                        cleanedvehiclefile.WriteLine(string.Join(deli.ToString(), splitline));
                    }

                    Console.WriteLine();
                    Console.WriteLine("Records changed - {0}", counter);
                }
            }
        }

        static public void MichelinPOLKMichelintoPolkCrossWalk() // do the vehicle file crosswalk 
        {
            // uses vehicle data file from polk and the 
            // e1platform tables (make, model, year, trim) should match
            //    stage_polk_lookup -> michelin_vehicle_data_201810.csv (from polk)
            //
            //    mich_polk_lookup -> 2019 US Polk Summary Final - Nuestar.csv (from michelin)   

            //check the unique (make, model, year, trim) from each new file against eachother
            // check the unique (make, model, year, trim) from new to old data????? 


            // stage_polk_lookup -> michelin_vehicle_data_201810.csv
            Console.WriteLine("- Enter Polk Vehicle Count File -");
            string polkdatafile = GetAFile();
            char polkdeli = GetDelimiter();

            Console.WriteLine("- Enter Michelin Vehicle Count File -");
            string michelindatafile = GetAFile();
            char michelindeli = GetDelimiter();

            char txtq = GetTXTQualifier(); // "

            Console.Write("Current Vintage Year: ");
            string currentyear = Console.ReadLine().Trim();

            Dictionary<string, int> polkvehicledata = new Dictionary<string, int>(); //concatenated (make, model, year, trim) will be the string, count of will be int.
            Dictionary<string, int> michelinvehicledata = new Dictionary<string, int>(); // concatenated (make, model, year, trim) will be the string, count of will be int.

            Dictionary<string, List<string>> polkvehiclenames = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> michelinvehiclenames = new Dictionary<string, List<string>>();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string vehicleinfofile = filefolderpath + "\\" + currentyear + "_vehicleinfo.csv";

            using (StreamReader readpolkfile = new StreamReader(polkdatafile))
            {
                string header = readpolkfile.ReadLine();

                //add check to verify that the columns are in the same position.... hard coding for now.
                // need to have the whole header in order to print out and verify on screen.

                string year = "YEAR_MODEL";
                string make = "Make_NAME";
                string model = "MODEL_NAME";
                string trim = "TRIM_NAME";

                int yearindex = ColumnIndex(header, polkdeli, year);
                int makeindex = ColumnIndex(header, polkdeli, make);
                int modelindex = ColumnIndex(header, polkdeli, model);
                int trimindex = ColumnIndex(header, polkdeli, trim);

                string line = string.Empty;
                int linecount = 0;
                while ((line = readpolkfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, polkdeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(polkdeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string concateddictkey = splitline[yearindex] + splitline[makeindex] + splitline[modelindex] + splitline[trimindex];

                    List<string> vehiclenameinfo = new List<string>();
                    vehiclenameinfo.Add(splitline[yearindex]);
                    vehiclenameinfo.Add(splitline[makeindex]);
                    vehiclenameinfo.Add(splitline[modelindex]);
                    vehiclenameinfo.Add(splitline[trimindex]);


                    if (!polkvehicledata.ContainsKey(concateddictkey))
                    {
                        polkvehicledata.Add(concateddictkey, 1);
                    }
                    else
                    {
                        polkvehicledata[concateddictkey] += 1;
                    }

                    if (!polkvehiclenames.ContainsKey(concateddictkey))
                    {
                        polkvehiclenames.Add(concateddictkey, vehiclenameinfo);
                    }

                    linecount++;
                }

                Console.WriteLine("{0} - record count - {1}", polkdatafile, linecount);
            }

            using (StreamReader readmichelindatafile = new StreamReader(michelindatafile))
            {
                string header = readmichelindatafile.ReadLine();
                //add check to verify that the columns are in the same position.... hard coding for now.
                // need to have the whole header in order to print out and verify on screen.

                string year = "YEAR_MODEL";
                string make = "Make_NAME";
                string model = "MODEL_NAME";
                string trim = "TRIM_NAME";

                int yearindex = ColumnIndex(header, polkdeli, year);
                int makeindex = ColumnIndex(header, polkdeli, make);
                int modelindex = ColumnIndex(header, polkdeli, model);
                int trimindex = ColumnIndex(header, polkdeli, trim);

                string line = string.Empty;
                int linecount = 0;
                while ((line = readmichelindatafile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, michelindeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(michelindeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string concateddictkey = splitline[yearindex] + splitline[makeindex] + splitline[modelindex] + splitline[trimindex];

                    List<string> vehiclenameinfo = new List<string>();
                    vehiclenameinfo.Add(splitline[yearindex]);
                    vehiclenameinfo.Add(splitline[makeindex]);
                    vehiclenameinfo.Add(splitline[modelindex]);
                    vehiclenameinfo.Add(splitline[trimindex]);

                    if (!michelinvehicledata.ContainsKey(concateddictkey))
                    {
                        michelinvehicledata.Add(concateddictkey, 1);
                    }
                    else
                    {
                        michelinvehicledata[concateddictkey] += 1;
                    }

                    if (!michelinvehiclenames.ContainsKey(concateddictkey))
                    {
                        michelinvehiclenames.Add(concateddictkey, vehiclenameinfo);
                    }

                    linecount++;
                }

                Console.WriteLine("{0} - record count - {1}", michelindatafile, linecount);
            }

            Dictionary<string, List<string>> michelinonly = new Dictionary<string, List<string>>();

            using (StreamWriter vehicleinfooutfile = new StreamWriter(vehicleinfofile))
            {
                List<string> headerlinebuilder = new List<string>();
                headerlinebuilder.Add("VehicleInfo");
                headerlinebuilder.Add("Count");
                headerlinebuilder.Add("SingleSource");
                headerlinebuilder.Add("PolkTrim");
                headerlinebuilder.Add("MichelinTrim");

                vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), headerlinebuilder.ToArray()));

                //Dictionary<string, int> tempdict = new Dictionary<string, int>();

                foreach (var vehicle in polkvehicledata.Keys)
                {
                    if (michelinvehicledata.ContainsKey(vehicle))
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(vehicle);
                        linebuilder.Add(polkvehicledata[vehicle].ToString());
                        linebuilder.Add("both");
                        linebuilder.Add("");
                        linebuilder.Add("");

                        vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));

                        //tempdict.Add(vehicle, polkvehicledata[vehicle]); //found
                    }
                    else
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(vehicle);
                        linebuilder.Add(polkvehicledata[vehicle].ToString());
                        linebuilder.Add("polkonly");
                        linebuilder.Add("");
                        linebuilder.Add("");

                        vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                    }
                }

                foreach (var vehicle in michelinvehicledata.Keys)
                {

                    if (!polkvehicledata.ContainsKey(vehicle))
                    {
                        List<string> tempmichelinname = michelinvehiclenames[vehicle];

                        bool found = false;

                        foreach (var polkvehicle in polkvehiclenames.Keys) // loop through the name list dict. compare list values. if at least 3 values match output.
                        {
                            List<string> temppolkname = polkvehiclenames[polkvehicle];

                            int year = 0; // all are previously found. add code to save the list indexes when they are added to the lsits.
                            int make = 1;
                            int model = 2;
                            int trim = 3;

                            if (temppolkname[year] == temppolkname[year] && temppolkname[make] == temppolkname[make] && temppolkname[model] == temppolkname[model])
                            {
                                if (temppolkname[trim] != temppolkname[trim])
                                {
                                    found = true;
                                    List<string> linebuilder = new List<string>();
                                    linebuilder.Add(vehicle);
                                    linebuilder.Add(michelinvehicledata[vehicle].ToString());
                                    linebuilder.Add("michelinonly");
                                    linebuilder.Add(temppolkname[trim]);
                                    linebuilder.Add(tempmichelinname[trim]);

                                    vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                                }
                            }
                        }

                        if (found == false)
                        {
                            michelinonly.Add(vehicle, tempmichelinname);

                            List<string> linebuilder = new List<string>();
                            linebuilder.Add(vehicle);
                            linebuilder.Add(michelinvehicledata[vehicle].ToString());
                            linebuilder.Add("michelinonly");
                            linebuilder.Add("");
                            linebuilder.Add("");

                            vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                        }
                    }
                }
            }

            string michelinonlyfile = filefolderpath + "\\michelinonly-vehicles.csv";
            using (StreamWriter michelinonlyoutfile = new StreamWriter(michelinonlyfile))
            {
                List<string> headerlinebuilder = new List<string>();
                headerlinebuilder.Add("VehicleInfo");
                headerlinebuilder.Add("Year");
                headerlinebuilder.Add("Make");
                headerlinebuilder.Add("Model");
                headerlinebuilder.Add("Trim");

                michelinonlyoutfile.WriteLine(string.Join(polkdeli.ToString(), headerlinebuilder.ToArray()));

                foreach (var vehicle in michelinonly.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(vehicle);

                    foreach (var value in michelinonly[vehicle])
                    {
                        linebuilder.Add(value);
                    }

                    michelinonlyoutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                }
            }

            int polkunique = polkvehicledata.Count;
            int michelinunique = michelinvehicledata.Count;

            Console.WriteLine();
            Console.WriteLine("{0} - Polk Unique Vehicles", polkunique);
            Console.WriteLine("{0} - Michelin Unique Vehicles", michelinunique);

        }

        static public void MichelinPOLKTirePotentialSegmentChecker() // check the TP_SEG columns 
        {
            // e1platform mich_polk_lookup table tp_seg column should match us_usage_table table tp_seg column
            // mich_polk_lookup table is updated with the "2019 US Polk Summary Final - Nuestar.csv" file from michelin.
            // us_usage_table table is updated with the "2019 US Usage-v1.csv" file from michelin.
            // TP_SEG is Group_Cat and Standard_Tire_Size concatenated 


            // Each TP_SEG entry in the US Usage file should be unique...
            // Compare uniques from both files. 
            // Output a file with two columns, matching ... US-Usage-TPseg , Summary-File-TPSEG
            // non-matches are listed as "tpseg" , "no match" in appropriate columns

            Console.WriteLine("-Enter US Usage File-");
            string ususagefile = GetAFile();
            char ususagedeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter US Summary File-");
            string ussummaryfile = GetAFile();
            char ussummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tpsegfile = filefolderpath + "\\tpsegments.txt";
            char newdeli = '\t'; // tab

            HashSet<string> ususagetpsegs = new HashSet<string>();
            HashSet<string> ussummarytpsegs = new HashSet<string>();

            int matches = 0;
            int ussummaryrecords = 0;
            int ususagerecords = 0;

            using (StreamReader ususagereadfile = new StreamReader(ususagefile))
            {
                string header = ususagereadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, ususagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ususagereadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, ususagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(ususagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = ususagetpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        ususagerecords++;
                    }
                }
            }

            using (StreamReader ussummaryreadfile = new StreamReader(ussummaryfile))
            {
                string header = ussummaryreadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, ususagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ussummaryreadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, ususagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(ususagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = ussummarytpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        ussummaryrecords++;
                    }
                }
            }


            using (StreamWriter tpsegoutfile = new StreamWriter(tpsegfile))
            {
                tpsegoutfile.WriteLine("{0}{1}{2}", "US_Summary_TP_SEG", newdeli, "US_Usage_TP_SEG");

                foreach (var x in ussummarytpsegs)
                {
                    if (ususagetpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, x);
                        matches++;
                    }
                    else
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, "");
                    }
                }

                foreach (var x in ususagetpsegs)
                {
                    if (!ussummarytpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", "", newdeli, x);
                    }
                }
            }

            Console.WriteLine("{0} - US Usage Tp_Segs", ususagerecords);
            Console.WriteLine("{0} - US Summary Tp_Segs", ussummaryrecords);
            Console.WriteLine("{0} - Matches", matches);
        }

        static public void MichelinPOLKGroupCatChecker() // Check if the Group_Categories align between the active_mspns1 and mich_polk_lookup files
        {
            // ACTIVE_MSPNS1 table, columns "GROUPE_CATEGORY", "TIRE_SIZE"
            // 2019-US-PolkSummary-Final.csv file, columns "Group_Cat", "Standard_Tire_Size"

            // look at TIRE_SIZES. then compare on tire size + group category,

            Console.WriteLine("-Enter ACTIVE MSPN File-");
            string activemspnfile = GetAFile();
            char activemspndeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter US Summary File-");
            string ussummaryfile = GetAFile();
            char ussummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_uspolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tiresizegroupcatfile = filefolderpath + "\\tiresizegroupcatcheckfile.txt";
            char newdeli = '\t'; // tab

            // active mspn columns GROUPE_CATEGORY TIRE_SIZE
            // summary file columns Group_Cat Standard_Tire_Size
            // group category only has 6 possible values - Rec/Com, V, Z, Winter, "ENTRY (S,T)", H.
            // "ENTRY (S,T)" - might cause issues, need to maintain the , in the data  in order to be accurate.

            // tire size will be key, categories will go into the list 
            Dictionary<string, List<string>> activemspntiregroupcategories = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> ussummarytiregroupcategories = new Dictionary<string, List<string>>();
            string[] groupcategories = { "REC/COM", "V", "Z", "Winter", "ENTRY (S,T)", "H" };

            //int matches = 0;
            //int amspntiregroups = 0;
            //int ussummarytiregroups = 0;

            using (StreamReader amspnfile = new StreamReader(activemspnfile))
            {
                string header = amspnfile.ReadLine();

                string tirecolumnname = "TIRE_SIZE";
                string groupcolumnname = "GROUPE_CATEGORY";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = amspnfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!activemspntiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        activemspntiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!activemspntiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        activemspntiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }
            }

            using (StreamReader summaryfile = new StreamReader(ussummaryfile))
            {
                string header = summaryfile.ReadLine();

                string tirecolumnname = "Standard_Tire_Size";
                string groupcolumnname = "Group_Cat";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = summaryfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!ussummarytiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        ussummarytiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!ussummarytiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        ussummarytiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }

            }

            using (StreamWriter outfile = new StreamWriter(tiresizegroupcatfile))
            {
                // return only records from the summary file that are not found in the active mspn file.
                // group category only has 6 possible values - Rec/Com, V, Z, Winter, "ENTRY (S,T)", H.

                List<string> header = new List<string>();
                header.Add("GroupMatchError");
                header.Add("TireSize");
                header.Add("Rec/Com");
                header.Add("V");
                header.Add("Z");
                header.Add("Winter");
                header.Add("ENTRY (S,T)");
                header.Add("H");
                outfile.WriteLine(string.Join(newdeli.ToString(), header.ToArray()));

                foreach (var tiresize in ussummarytiregroupcategories.Keys)
                {
                    if (!activemspntiregroupcategories.ContainsKey(tiresize)) // if the tire size is not found.
                    {
                        //output the tire size and the group categories.
                        string[] categories = new string[6];
                        string error = string.Empty;
                        bool matchfound = false;

                        //for (int index = 0; index < groupcategories.Length; index++)
                        //{
                        //   if (ussummarytiregroupcategories[tiresize].Contains(groupcategories[index])) 
                        //   {
                        //      categories[index] = groupcategories[index];
                        //      matchfound = true; //shows that we found at least one match.
                        //   }
                        //}

                        foreach (var category in groupcategories) //loop through all possible matches. any matches get added 
                        {
                            if (ussummarytiregroupcategories[tiresize].Contains(category))
                            {
                                int index = Array.IndexOf(groupcategories, category);
                                categories[index] = category;

                                matchfound = true;
                            }
                        }

                        if (matchfound == true)
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTire"; // new tire has been added.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories)
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                        else
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTireNotValidCategory"; // new tire added and group category does NOT match what it should.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in ussummarytiregroupcategories[tiresize]) //just write existing group categories in order they appear.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                    }
                    else //tire exists.
                    {
                        string[] categories = new string[6];
                        List<string> badcategory = new List<string>();
                        string error = string.Empty;
                        string categoryvaliderror = string.Empty;
                        bool matchfound = true;
                        bool newcategory = false;

                        foreach (var category in ussummarytiregroupcategories[tiresize]) //tire exists, so compare group categories from both dictionaries.
                        {
                            if (activemspntiregroupcategories[tiresize].Contains(category)) // category found in both dicts.
                            {
                                if (!groupcategories.Contains(category)) // validate it is a good group categories. if it is good and matches do nothing.
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                            else //category not found in original file
                            {
                                if (groupcategories.Contains(category)) // validate it is a good group categories.
                                {
                                    int index = Array.IndexOf(groupcategories, category);
                                    categories[index] = category;

                                    newcategory = true;
                                }
                                else
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                        }

                        if (matchfound == false)
                        {
                            List<string> linebuilder = new List<string>();
                            categoryvaliderror = "NotValidCategory";
                            linebuilder.Add(categoryvaliderror);
                            linebuilder.Add(tiresize);
                            foreach (var category in badcategory) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                        if (newcategory == true)
                        {
                            //tire exists but there is a new category.
                            List<string> linebuilder = new List<string>();
                            error = "NewCategory";
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                    }
                }
            }
        }


        // Canada Polk
        static public void MichelinCanadaPOLKReaderMultiTask()
        {
            // create directory for splitfiles.
            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\splitfiles";
            string fsafilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\fsacounts";
            string polkfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\polkcounts";

            if (!Directory.Exists(splitfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(splitfilefolderpath);
            }

            if (!Directory.Exists(polkfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(polkfilefolderpath);
            }

            if (!Directory.Exists(fsafilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(fsafilefolderpath);
            }

            // get source file.
            Console.WriteLine("-Enter Polk FSA file-");
            Console.Write("File: ");
            var inFile = new FileInfo(Console.ReadLine());
            //var polkziplistfile = Console.ReadLine();
            char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            //splitfile code. (code copies from BreakOneFileIntoMany)
            Int64 sourceRecordCount, iRecordCount, NoOutputFiles;

            Console.Write("Source Record Count (Enter nothing for auto count): ");

            if (Int64.TryParse(Console.ReadLine(), out iRecordCount))
                sourceRecordCount = iRecordCount;
            else
                sourceRecordCount = File.ReadLines(inFile.FullName).LongCount();

            Console.Write("No. of Output Files: ");
            NoOutputFiles = Int64.Parse(Console.ReadLine());

            Int64 linesWritten;
            double maxBreakoutRecordsPerFile = Math.Ceiling((double)sourceRecordCount / (double)NoOutputFiles);
            string readLine;

            Console.WriteLine("Spliting file...");

            using (var reader = new StreamReader(inFile.OpenRead()))
            {
                string header = reader.ReadLine();

                for (int i = 1; i <= NoOutputFiles; i++)
                {
                    using (var writer = new StreamWriter(splitfilefolderpath + "\\" + (inFile.Name.Replace(inFile.Extension, "").ToString() + "_split_" + i + inFile.Extension.ToString())))
                    {
                        writer.WriteLine(header);
                        linesWritten = 0;

                        while (linesWritten < maxBreakoutRecordsPerFile && (readLine = reader.ReadLine()) != null)
                        {
                            writer.WriteLine(readLine);
                            linesWritten++;
                        }
                    }
                }
            }

            // read splitfiles.
            //Console.WriteLine("-Drag and Drop Michelin Zip Data Files Folder here-");
            //Console.Write("Folder: ");
            //string zipdatadirectory = Console.ReadLine();
            string[] michelinfsadatafilepaths = Directory.GetFiles(@splitfilefolderpath);

            Console.WriteLine("-Enter Province file-");
            string statefile = GetAFile();
            char statedeli = GetDelimiter();
            Console.WriteLine();

            Dictionary<string, HashSet<string>> provincefsadictionary = new Dictionary<string, HashSet<string>>();

            using (StreamReader statezipfile = new StreamReader(statefile))
            {
                string header = statezipfile.ReadLine();

                string line = string.Empty;
                while ((line = statezipfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, statedeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(statedeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    string provincecode = splitline[1].Replace(txtq.ToString(), ""); //hard coded to report output.
                    if (string.IsNullOrWhiteSpace(provincecode))
                    {
                        provincecode = "blank"; //accounts for states or provinces that do not appear in the province lookup files
                    }

                    string provincename = splitline[2].Replace(txtq.ToString(), "");
                    string fsa = splitline[0].Replace(txtq.ToString(), "");

                    if (!provincefsadictionary.ContainsKey(provincecode))
                    {
                        HashSet<string> temphash = new HashSet<string>();
                        temphash.Add(fsa);
                        provincefsadictionary.Add(provincecode, temphash);
                    }
                    else
                    {
                        provincefsadictionary[provincecode].Add(fsa);
                    }

                }
            }

            List<Task> tasklist = new List<Task>(); //using a task array and a file array was not working.
            try
            {
                foreach (var file in michelinfsadatafilepaths)
                {
                    var task = new Task(async () =>
                    {
                        string returned = await (MichelinCanadaPOLKfsaDataReader(file, deli, txtq, provincefsadictionary));
                        Console.WriteLine(returned);

                    });

                    tasklist.Add(task);
                    task.Start();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            try
            {
                Task.WaitAll(tasklist.ToArray());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            //produces two files with total counts for polkkeys and zipcodes
            MichelinCanadaPOLKCountsFileCondenser(polkfilefolderpath, deli);
            MichelinCanadaPOLKfsaCountsFileCondenser(fsafilefolderpath, deli); //by zip code file and by state code file.

        }

        static public Task<string> MichelinCanadaPOLKfsaDataReader(string file1, char deli1, char txtq, Dictionary<string, HashSet<string>> provincelookup)
        {
            string fsafilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\fsacounts";
            string polkfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\polkcounts";

            string fsacountsfile = fsafilefolderpath + "\\" + GetFileNameWithoutExtension(file1) + "fsa_counts.txt"; // list of zips, appended with counts
            string polkcountsfile = polkfilefolderpath + "\\" + GetFileNameWithoutExtension(file1) + "polk_counts.txt";

            Dictionary<string, int> fsalist = new Dictionary<string, int>();
            Dictionary<string, int> polkkeysums = new Dictionary<string, int>();

            int rowcount = 0;

            using (StreamReader readfile = new StreamReader(file1))
            {
                // read and save header.
                string header = readfile.ReadLine();

                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli1, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(deli1));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    string fsa = splitline[0].Replace(txtq.ToString(), "");
                    string polk = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));

                    // ADD check for polk + zip combo. using a list made the process run for EVER!!!!! use a dict instead, or hashset.

                    if (!fsalist.ContainsKey(fsa))
                    {
                        fsalist.Add(fsa, vehiclecount);
                    }
                    else
                    {
                        fsalist[fsa] += vehiclecount;
                    }


                    if (!polkkeysums.ContainsKey(polk))
                    {
                        polkkeysums.Add(polk, vehiclecount);
                    }
                    else
                    {
                        polkkeysums[polk] += vehiclecount;
                    }

                    rowcount++;
                }
            }

            using (StreamWriter fsacountoutfile = new StreamWriter(fsacountsfile))
            {
                HashSet<string> fsawasfound = new HashSet<string>();

                fsacountoutfile.WriteLine("Province, FSA,VehicleCount");

                foreach (var province in provincelookup.Keys)
                {
                    foreach (var value in provincelookup[province])
                    {
                        foreach (var zip in fsalist.Keys)
                        {
                            if (value.Contains(zip))
                            {
                                fsawasfound.Add(zip);

                                List<string> linebuilder = new List<string>();
                                linebuilder.Add(province);
                                linebuilder.Add(zip);
                                linebuilder.Add(fsalist[zip].ToString());

                                fsacountoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                            }
                        }
                    }
                }

                foreach (var fsa in fsalist.Keys) //check for zips that where not matched to a state.
                {
                    if (!fsawasfound.Contains(fsa))
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add("00"); // set artificial state code to 00. indicates zip was not found in state-zip lookup.
                        linebuilder.Add(fsa);
                        linebuilder.Add(fsalist[fsa].ToString());
                        fsacountoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                    }
                }
            }

            using (StreamWriter polkcountsoutfile = new StreamWriter(polkcountsfile))
            {
                polkcountsoutfile.WriteLine("Polkkey,VehicleCount");

                foreach (var polkkey in polkkeysums.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(polkkey);
                    linebuilder.Add(polkkeysums[polkkey].ToString());

                    polkcountsoutfile.WriteLine(string.Join(deli1.ToString(), linebuilder.ToArray()));
                }
            }

            string returnstring = rowcount.ToString();

            return Task.FromResult(returnstring);

        }

        static public void MichelinCanadaPOLKCountsFileCondenser(string polkdatadirectory, char deli)
        {
            //Console.Write("Drag and Drop Michelin Polk Count Data Files Folder here: ");
            //string polkdatadirectory = Console.ReadLine();
            string[] michelincanadapolkdatafilepaths = Directory.GetFiles(polkdatadirectory);
            //char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\";
            string polkcountsfile = splitfilefolderpath + "\\" + "polk_counts.txt";

            Dictionary<string, int> canadapolkcounts = new Dictionary<string, int>();

            foreach (var file in michelincanadapolkdatafilepaths)
            {
                using (StreamReader polkcountfile = new StreamReader(file))
                {
                    polkcountfile.ReadLine();

                    string line = string.Empty;
                    while ((line = polkcountfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();
                        string polkkey = splitline[0].Replace(txtq.ToString(), "");
                        int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                        if (!canadapolkcounts.ContainsKey(polkkey))
                        {
                            canadapolkcounts.Add(polkkey, vehiclecount);
                        }
                        else
                        {
                            canadapolkcounts[polkkey] += vehiclecount;
                        }
                    }
                }
            }

            using (StreamWriter polkcountsoutfile = new StreamWriter(polkcountsfile))
            {
                var totalvehicles = canadapolkcounts.Sum(vehiclecount => vehiclecount.Value);

                polkcountsoutfile.WriteLine("Polkkey,VehicleCount - {0}", totalvehicles);

                foreach (var polkkey in canadapolkcounts.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(polkkey);
                    linebuilder.Add(canadapolkcounts[polkkey].ToString());

                    polkcountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                }
            }
        }

        static public void MichelinCanadaPOLKfsaCountsFileCondenser(string fsadatadirectory, char deli)
        {
            //Console.Write("Drag and Drop Michelin Zip Count Data Files Folder here: ");
            //string zipdatadirectory = Console.ReadLine();
            string[] michelinfsadatafilepaths = Directory.GetFiles(fsadatadirectory);
            //char deli = GetDelimiter();
            char txtq = '"';
            Console.WriteLine();

            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts\";
            string fsacountsfile = splitfilefolderpath + "\\" + "fsa_counts.txt";
            string provincecountsfile = splitfilefolderpath + "\\" + "province_counts.txt";

            // state key, zipcode key, vehicle count
            Dictionary<string, Dictionary<string, int>> canadafsacounts = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> canadaprovincecounts = new Dictionary<string, int>();

            foreach (var file in michelinfsadatafilepaths)
            {
                using (StreamReader fsacountfile = new StreamReader(file))
                {
                    fsacountfile.ReadLine(); //read headers.

                    string line = string.Empty;
                    while ((line = fsacountfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();
                        string provincecode = splitline[0].Replace(txtq.ToString(), "");
                        string fsa = splitline[1].Replace(txtq.ToString(), "");
                        int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));

                        if (!canadafsacounts.ContainsKey(provincecode)) // if the state dictionary does not have the state.
                        {
                            Dictionary<string, int> tempdict = new Dictionary<string, int>();
                            tempdict.Add(fsa, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                            canadafsacounts.Add(provincecode, tempdict);
                        }
                        else
                        {
                            if (!canadafsacounts[provincecode].ContainsKey(fsa)) //if the nested dictionary doesnt contain the zip.
                            {
                                canadafsacounts[provincecode].Add(fsa, vehiclecount);
                            }
                            else
                            {
                                canadafsacounts[provincecode][fsa] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                            }
                        }

                        if (!canadaprovincecounts.ContainsKey(provincecode))
                        {
                            canadaprovincecounts.Add(provincecode, vehiclecount);
                        }
                        else
                        {
                            canadaprovincecounts[provincecode] += vehiclecount;
                        }
                    }
                }
            }

            using (StreamWriter fsacountsoutfile = new StreamWriter(fsacountsfile))
            {
                long totalvehiclecount = 0;

                foreach (var province in canadafsacounts.Keys)
                {
                    Dictionary<string, int> tempdict = canadafsacounts[province];

                    totalvehiclecount += tempdict.Sum(vehiclecount => vehiclecount.Value);
                }

                fsacountsoutfile.WriteLine("ProvinceCode,FSACode,VehicleCount - {0}", totalvehiclecount);

                foreach (var provincecode in canadafsacounts.Keys)
                {
                    foreach (var fsa in canadafsacounts[provincecode].Keys)
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(provincecode);
                        linebuilder.Add(fsa);
                        linebuilder.Add(canadafsacounts[provincecode][fsa].ToString());

                        fsacountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                    }
                }
            }

            using (StreamWriter provincecountsoutfile = new StreamWriter(provincecountsfile)) // unsorted output. can sort using hash or list of the keys, output based on that.
            {
                provincecountsoutfile.WriteLine("ProvinceCode,VehicleCount");
                foreach (var province in canadaprovincecounts.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(province);
                    linebuilder.Add(canadaprovincecounts[province].ToString());

                    provincecountsoutfile.WriteLine(string.Join(deli.ToString(), linebuilder.ToArray()));
                }
            }
        }

        static public void MichelinCanadaPOLKNewfsaFinder() //look for added or dropped fsas.
        {
            // use previously created fsa counts files.

            Console.WriteLine("-Enter Current Year FSA Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year FSA Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            char txtq = '"';
            string splitfilefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(splitfilefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(splitfilefolderpath);
            }

            string newfsalist = splitfilefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_newfsas.txt";
            string droppedfsalist = splitfilefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_drops.txt";

            HashSet<string> newfsas = new HashSet<string>();
            HashSet<string> droppedfsas = new HashSet<string>();

            HashSet<string> currentuniquefsas = new HashSet<string>();
            HashSet<string> lastuniquefsas = new HashSet<string>();
            int currentuniquecounter = 0;
            int lastuniquecounter = 0;
            string header = string.Empty;

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                header = currentfile.ReadLine(); // header read

                //add check to find the zip_code column.

                string line = string.Empty;
                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();

                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    int geoidindex = 1; // add checks for if contains txtqs requires rewrite of alot of methods.

                    currentuniquefsas.Add(splitline[geoidindex]);

                    currentuniquecounter = currentuniquefsas.Count;
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                lastfile.ReadLine(); // header read

                //add check to find the zip_code column.

                string line = string.Empty;
                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();

                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();
                    int geoidindex = 1; // add checks for if contains txtqs requires rewrite of alot of methods.

                    lastuniquefsas.Add(splitline[geoidindex]);

                    lastuniquecounter = lastuniquefsas.Count;
                }
            }

            foreach (var fsa in currentuniquefsas)
            {
                if (!lastuniquefsas.Contains(fsa))
                {
                    newfsas.Add(fsa);
                }
            }

            foreach (var fsa in lastuniquefsas)
            {
                if (!currentuniquefsas.Contains(fsa))
                {
                    droppedfsas.Add(fsa);
                }
            }

            using (StreamWriter newfsasfile = new StreamWriter(newfsalist))
            {
                List<string> splitlinebuilder = new List<string>();

                if (header.Contains(txtq))
                {
                    splitlinebuilder.AddRange(SplitLineWithTxtQualifier(header, currentyeardeli, txtq, false));
                }
                else
                {
                    splitlinebuilder.AddRange(header.Split(currentyeardeli));
                }

                string[] splitheader = splitlinebuilder.ToArray();
                string geoname = splitheader[1].Trim();
                newfsasfile.WriteLine("{0}", geoname); //header

                foreach (var fsa in newfsas)
                {
                    newfsasfile.WriteLine(fsa);
                }
            }

            using (StreamWriter droppedfsasfile = new StreamWriter(droppedfsalist))
            {
                List<string> splitlinebuilder = new List<string>();

                if (header.Contains(txtq))
                {
                    splitlinebuilder.AddRange(SplitLineWithTxtQualifier(header, currentyeardeli, txtq, false));
                }
                else
                {
                    splitlinebuilder.AddRange(header.Split(currentyeardeli));
                }

                string[] splitheader = splitlinebuilder.ToArray();
                string geoname = splitheader[1].Trim();
                droppedfsasfile.WriteLine("{0}", geoname); //header

                foreach (var fsa in droppedfsas)
                {
                    droppedfsasfile.WriteLine(fsa);
                }
            }
        }

        static public void MichelinCanadaPOLKfsaCountsDiffReader()
        {
            Console.WriteLine("-Enter Current Year fsa Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year fsa Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            //Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> currentyeardata = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, Dictionary<string, int>> lastyeardata = new Dictionary<string, Dictionary<string, int>>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string provincecode = splitline[0].Replace(txtq.ToString(), "");
                    string fsa = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));


                    if (!currentyeardata.ContainsKey(provincecode)) // if the state dictionary does not have the state.
                    {
                        Dictionary<string, int> tempdict = new Dictionary<string, int>();
                        tempdict.Add(fsa, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                        currentyeardata.Add(provincecode, tempdict);
                    }
                    else
                    {
                        if (!currentyeardata[provincecode].ContainsKey(fsa)) //if the nested dictionary doesnt contain the zip.
                        {
                            currentyeardata[provincecode].Add(fsa, vehiclecount);
                        }
                        else
                        {
                            currentyeardata[provincecode][fsa] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                        }
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string lastheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string provincecode = splitline[0].Replace(txtq.ToString(), "");
                    string fsa = splitline[1].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[2].Replace(txtq.ToString(), ""));


                    if (!lastyeardata.ContainsKey(provincecode)) // if the state dictionary does not have the state.
                    {
                        Dictionary<string, int> tempdict = new Dictionary<string, int>();
                        tempdict.Add(fsa, vehiclecount); // zip code and vehicle count new state line saved to temp dict. copied into uslevel dict.
                        lastyeardata.Add(provincecode, tempdict);
                    }
                    else
                    {
                        if (!lastyeardata[provincecode].ContainsKey(fsa)) //if the nested dictionary doesnt contain the zip.
                        {
                            lastyeardata[provincecode].Add(fsa, vehiclecount);
                        }
                        else
                        {
                            lastyeardata[provincecode][fsa] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                        }
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("ProvinceCode, FSACode, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var province in currentyeardata.Keys)
                {
                    foreach (var fsa in currentyeardata[province].Keys)
                    {
                        if (lastyeardata.ContainsKey(province))
                        {
                            if (lastyeardata[province].ContainsKey(fsa))
                            {
                                double percentdiff = 0;

                                if (lastyeardata[province][fsa] != 0)
                                {
                                    // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                                    double currentvalue = currentyeardata[province][fsa];
                                    double lastvalue = lastyeardata[province][fsa];

                                    percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                                }
                                else
                                {
                                    percentdiff = currentyeardata[province][fsa] * 100;
                                }

                                List<string> linebuilder = new List<string>();
                                linebuilder.Add(province); // state
                                linebuilder.Add(fsa); // zip
                                linebuilder.Add(lastyeardata[province][fsa].ToString());
                                linebuilder.Add(currentyeardata[province][fsa].ToString());
                                linebuilder.Add(percentdiff.ToString() + "%");

                                percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                            }
                        }
                    }
                }
            }
        }

        static public void MichelinCanadaPOLKPolkKeyCountsDiffReader() //mirror code of us method
        {
            Console.WriteLine("-Enter Current Year PolkKey Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year PolkKey Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, int> lastyeardata = new Dictionary<string, int>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string polkkey = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!currentyeardata.ContainsKey(polkkey)) //if the nested dictionary doesnt contain the zip.
                    {
                        currentyeardata.Add(polkkey, vehiclecount);
                    }
                    else
                    {
                        currentyeardata[polkkey] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string currentheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string polkkey = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!lastyeardata.ContainsKey(polkkey)) //if the nested dictionary doesnt contain the zip.
                    {
                        lastyeardata.Add(polkkey, vehiclecount);
                    }
                    else
                    {
                        lastyeardata[polkkey] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("PolkKey, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var polkkey in currentyeardata.Keys)
                {
                    if (lastyeardata.ContainsKey(polkkey))
                    {
                        double percentdiff = 0;

                        if (lastyeardata[polkkey] != 0)
                        {
                            // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                            double currentvalue = currentyeardata[polkkey];
                            double lastvalue = lastyeardata[polkkey];

                            percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                        }
                        else
                        {
                            percentdiff = currentyeardata[polkkey] * 100;
                        }

                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(polkkey); // state
                        linebuilder.Add(lastyeardata[polkkey].ToString());
                        linebuilder.Add(currentyeardata[polkkey].ToString());
                        linebuilder.Add(percentdiff.ToString() + "%");

                        percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        static public void MichelinCanadaPOLKProvinceCountsDiffReader() // same code as MIchelinCanadaPolkKeyCountsDiffReader() just uses province names instead of polk key.
        {
            Console.WriteLine("-Enter Current Year Province Counts file-");
            string currentyearfile = GetAFile();
            char currentyeardeli = GetDelimiter();
            Console.WriteLine();

            Console.WriteLine("-Enter Last Year Province Counts file-");
            string lasatyearfile = GetAFile();
            char lastyeardeli = GetDelimiter();
            Console.WriteLine();

            //Console.Write("Current Vintage Year: ");
            //string currentyear = Console.ReadLine().Trim();

            char txtq = '"';

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string percentdifffile = filefolderpath + "\\" + GetFileNameWithoutExtension(currentyearfile) + "_difs.csv";

            Dictionary<string, int> currentyeardata = new Dictionary<string, int>();
            Dictionary<string, int> lastyeardata = new Dictionary<string, int>();

            using (StreamReader currentfile = new StreamReader(currentyearfile))
            {
                string currentheader = currentfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = currentfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string provincecode = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!currentyeardata.ContainsKey(provincecode)) //if the nested dictionary doesnt contain the zip.
                    {
                        currentyeardata.Add(provincecode, vehiclecount);
                    }
                    else
                    {
                        currentyeardata[provincecode] += vehiclecount;
                    }
                }
            }

            using (StreamReader lastfile = new StreamReader(lasatyearfile))
            {
                string currentheader = lastfile.ReadLine(); // read header

                string line = string.Empty;

                while ((line = lastfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, currentyeardeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(currentyeardeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string provincecode = splitline[0].Replace(txtq.ToString(), "");
                    int vehiclecount = Int32.Parse(splitline[1].Replace(txtq.ToString(), ""));

                    if (!lastyeardata.ContainsKey(provincecode)) //if the nested dictionary doesnt contain the zip.
                    {
                        lastyeardata.Add(provincecode, vehiclecount);
                    }
                    else
                    {
                        lastyeardata[provincecode] += vehiclecount; //if the zipcode is already in the us level dict. add to vehicle count.
                    }
                }
            }

            using (StreamWriter percentdiffoutfile = new StreamWriter(percentdifffile))
            {
                percentdiffoutfile.WriteLine("ProvinceCode, LastYearVehicleCount, CurrentyearVehicleCount, %Diff");

                foreach (var provincecode in currentyeardata.Keys)
                {
                    if (lastyeardata.ContainsKey(provincecode))
                    {
                        double percentdiff = 0;

                        if (lastyeardata[provincecode] != 0)
                        {
                            // [(V2-V1) / |V1|) *100] (V1 = last year value, V2 = current year value)
                            double currentvalue = currentyeardata[provincecode];
                            double lastvalue = lastyeardata[provincecode];

                            percentdiff = ((currentvalue - lastvalue) / Math.Abs(lastvalue)) * 100;
                        }
                        else
                        {
                            percentdiff = currentyeardata[provincecode] * 100;
                        }

                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(provincecode); // state
                        linebuilder.Add(lastyeardata[provincecode].ToString());
                        linebuilder.Add(currentyeardata[provincecode].ToString());
                        linebuilder.Add(percentdiff.ToString() + "%");

                        percentdiffoutfile.WriteLine(string.Join(currentyeardeli.ToString(), linebuilder.ToArray()));
                    }
                }
            }
        }

        // other qa tasks.
        static public void MichelinCanadaPOLKVehicleInfoFileCleaner() // clean the new vehicle file first
        {
            // expected header: POLK_KEY,YEAR_MODEL,MAKE_NAME,MODEL_NAME,TRIM_NAME,SEGMENT_NAME

            // add check for 'blanks' -> change blanks to 'N/A'
            Console.WriteLine("-Enter Current Year Vehicle Data file-");
            string file = GetAFile();
            char deli = GetDelimiter();
            char txtq = GetTXTQualifier();
            Console.WriteLine();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string cleanedfile = filefolderpath + "\\" + GetFileNameWithoutExtension(file) + "cleaned.txt";

            using (StreamReader vehiclecountsfile = new StreamReader(file))
            {
                using (StreamWriter cleanedvehiclefile = new StreamWriter(cleanedfile))
                {
                    string header = vehiclecountsfile.ReadLine();
                    cleanedvehiclefile.WriteLine(header);
                    List<string> headersplitbuilder = new List<string>();

                    if (header.Contains(txtq))
                    {
                        headersplitbuilder.AddRange(SplitLineWithTxtQualifier(header, deli, txtq, false));
                    }
                    else
                    {
                        headersplitbuilder.AddRange(header.Split(deli));
                    }

                    string year = "YEAR_MODEL"; // find the index of this column. hard coded for now.

                    int yearindex = headersplitbuilder.IndexOf(year); // trying out new method. shorter.

                    string line = string.Empty;
                    int counter = 0;
                    while ((line = vehiclecountsfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        if (line.Contains(txtq))
                        {
                            splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                        }
                        else
                        {
                            splitlinebuilder.AddRange(line.Split(deli));
                        }

                        string[] splitline = splitlinebuilder.ToArray();

                        if (splitline[yearindex].ToCharArray().Count() != 4)
                        {
                            splitline[yearindex] = "0001";
                            counter++;
                        }

                        cleanedvehiclefile.WriteLine(string.Join(deli.ToString(), splitline));
                    }

                    Console.WriteLine();
                    Console.WriteLine("Records changed - {0}", counter);
                }
            }
        }

        static public void MichelinCanadaPOLKMichelintoPolkCrossWalk() // do the vehicle file crosswalk (mirror code of us)
        {
            // uses vehicle data file from polk and the 
            // e1platform tables (make, model, year, trim) should match
            //    stage_polk_lookup -> michelin_vehicle_data_201810.csv (from polk)
            //
            //    mich_polk_lookup -> 2019 US Polk Summary Final - Nuestar.csv (from michelin)   

            //check the unique (make, model, year, trim) from each new file against eachother
            // check the unique (make, model, year, trim) from new to old data????? 


            // stage_polk_lookup -> michelin_vehicle_data_201810.csv
            Console.WriteLine("- Enter Polk Vehicle Count File -");
            string polkdatafile = GetAFile();
            char polkdeli = GetDelimiter();

            Console.WriteLine("- Enter Michelin Vehicle Count File -");
            string michelindatafile = GetAFile();
            char michelindeli = GetDelimiter();

            char txtq = GetTXTQualifier(); // "

            Console.Write("Current Vintage Year: ");
            string currentyear = Console.ReadLine().Trim();

            Dictionary<string, int> polkvehicledata = new Dictionary<string, int>(); //concatenated (make, model, year, trim) will be the string, count of will be int.
            Dictionary<string, int> michelinvehicledata = new Dictionary<string, int>(); // concatenated (make, model, year, trim) will be the string, count of will be int.

            Dictionary<string, List<string>> polkvehiclenames = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> michelinvehiclenames = new Dictionary<string, List<string>>();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string vehicleinfofile = filefolderpath + "\\" + currentyear + "_vehicleinfo.csv";

            using (StreamReader readpolkfile = new StreamReader(polkdatafile))
            {
                string header = readpolkfile.ReadLine();

                //add check to verify that the columns are in the same position.... hard coding for now.
                // need to have the whole header in order to print out and verify on screen.

                string year = "YEAR_MODEL";
                string make = "MAKE_NAME";
                string model = "MODEL_NAME";
                string trim = "TRIM_NAME";

                int yearindex = ColumnIndex(header, polkdeli, year);
                int makeindex = ColumnIndex(header, polkdeli, make);
                int modelindex = ColumnIndex(header, polkdeli, model);
                int trimindex = ColumnIndex(header, polkdeli, trim);

                string line = string.Empty;
                int linecount = 0;
                while ((line = readpolkfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, polkdeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(polkdeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string concateddictkey = splitline[yearindex] + splitline[makeindex] + splitline[modelindex] + splitline[trimindex];

                    List<string> vehiclenameinfo = new List<string>();
                    vehiclenameinfo.Add(splitline[yearindex]);
                    vehiclenameinfo.Add(splitline[makeindex]);
                    vehiclenameinfo.Add(splitline[modelindex]);
                    vehiclenameinfo.Add(splitline[trimindex]);


                    if (!polkvehicledata.ContainsKey(concateddictkey))
                    {
                        polkvehicledata.Add(concateddictkey, 1);
                    }
                    else
                    {
                        polkvehicledata[concateddictkey] += 1;
                    }

                    if (!polkvehiclenames.ContainsKey(concateddictkey))
                    {
                        polkvehiclenames.Add(concateddictkey, vehiclenameinfo);
                    }

                    linecount++;
                }

                Console.WriteLine("{0} - record count - {1}", polkdatafile, linecount);
            }

            using (StreamReader readmichelindatafile = new StreamReader(michelindatafile))
            {
                string header = readmichelindatafile.ReadLine();
                //add check to verify that the columns are in the same position.... hard coding for now.
                // need to have the whole header in order to print out and verify on screen.

                string year = "YEAR_MODEL";
                string make = "MAKE_NAME";
                string model = "MODEL_NAME";
                string trim = "TRIM_NAME";

                int yearindex = ColumnIndex(header, polkdeli, year);
                int makeindex = ColumnIndex(header, polkdeli, make);
                int modelindex = ColumnIndex(header, polkdeli, model);
                int trimindex = ColumnIndex(header, polkdeli, trim);

                string line = string.Empty;
                int linecount = 0;
                while ((line = readmichelindatafile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, michelindeli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(michelindeli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    string concateddictkey = splitline[yearindex] + splitline[makeindex] + splitline[modelindex] + splitline[trimindex];

                    List<string> vehiclenameinfo = new List<string>();
                    vehiclenameinfo.Add(splitline[yearindex]);
                    vehiclenameinfo.Add(splitline[makeindex]);
                    vehiclenameinfo.Add(splitline[modelindex]);
                    vehiclenameinfo.Add(splitline[trimindex]);

                    if (!michelinvehicledata.ContainsKey(concateddictkey))
                    {
                        michelinvehicledata.Add(concateddictkey, 1);
                    }
                    else
                    {
                        michelinvehicledata[concateddictkey] += 1;
                    }

                    if (!michelinvehiclenames.ContainsKey(concateddictkey))
                    {
                        michelinvehiclenames.Add(concateddictkey, vehiclenameinfo);
                    }

                    linecount++;
                }

                Console.WriteLine("{0} - record count - {1}", michelindatafile, linecount);
            }

            Dictionary<string, List<string>> michelinonly = new Dictionary<string, List<string>>();

            using (StreamWriter vehicleinfooutfile = new StreamWriter(vehicleinfofile))
            {
                List<string> headerlinebuilder = new List<string>();
                headerlinebuilder.Add("VehicleInfo");
                headerlinebuilder.Add("Count");
                headerlinebuilder.Add("SingleSource");
                headerlinebuilder.Add("PolkTrim");
                headerlinebuilder.Add("MichelinTrim");

                vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), headerlinebuilder.ToArray()));

                //Dictionary<string, int> tempdict = new Dictionary<string, int>();

                foreach (var vehicle in polkvehicledata.Keys)
                {
                    if (michelinvehicledata.ContainsKey(vehicle))
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(vehicle);
                        linebuilder.Add(polkvehicledata[vehicle].ToString());
                        linebuilder.Add("both");
                        linebuilder.Add("");
                        linebuilder.Add("");

                        vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));

                        //tempdict.Add(vehicle, polkvehicledata[vehicle]); //found
                    }
                    else
                    {
                        List<string> linebuilder = new List<string>();
                        linebuilder.Add(vehicle);
                        linebuilder.Add(polkvehicledata[vehicle].ToString());
                        linebuilder.Add("polkonly");
                        linebuilder.Add("");
                        linebuilder.Add("");

                        vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                    }
                }

                foreach (var vehicle in michelinvehicledata.Keys)
                {

                    if (!polkvehicledata.ContainsKey(vehicle))
                    {
                        List<string> tempmichelinname = michelinvehiclenames[vehicle];

                        bool found = false;

                        foreach (var polkvehicle in polkvehiclenames.Keys) // loop through the name list dict. compare list values. if at least 3 values match output.
                        {
                            List<string> temppolkname = polkvehiclenames[polkvehicle];

                            int year = 0; // all are previously found. add code to save the list indexes when they are added to the lsits.
                            int make = 1;
                            int model = 2;
                            int trim = 3;

                            if (temppolkname[year] == temppolkname[year] && temppolkname[make] == temppolkname[make] && temppolkname[model] == temppolkname[model])
                            {
                                if (temppolkname[trim] != temppolkname[trim])
                                {
                                    found = true;
                                    List<string> linebuilder = new List<string>();
                                    linebuilder.Add(vehicle);
                                    linebuilder.Add(michelinvehicledata[vehicle].ToString());
                                    linebuilder.Add("michelinonly");
                                    linebuilder.Add(temppolkname[trim]);
                                    linebuilder.Add(tempmichelinname[trim]);

                                    vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                                }
                            }
                        }

                        if (found == false)
                        {
                            michelinonly.Add(vehicle, tempmichelinname);

                            List<string> linebuilder = new List<string>();
                            linebuilder.Add(vehicle);
                            linebuilder.Add(michelinvehicledata[vehicle].ToString());
                            linebuilder.Add("michelinonly");
                            linebuilder.Add("");
                            linebuilder.Add("");

                            vehicleinfooutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                        }
                    }
                }
            }

            string michelinonlyfile = filefolderpath + "\\michelinonly-vehicles.csv";
            using (StreamWriter michelinonlyoutfile = new StreamWriter(michelinonlyfile))
            {
                List<string> headerlinebuilder = new List<string>();
                headerlinebuilder.Add("VehicleInfo");
                headerlinebuilder.Add("Year");
                headerlinebuilder.Add("Make");
                headerlinebuilder.Add("Model");
                headerlinebuilder.Add("Trim");

                michelinonlyoutfile.WriteLine(string.Join(polkdeli.ToString(), headerlinebuilder.ToArray()));

                foreach (var vehicle in michelinonly.Keys)
                {
                    List<string> linebuilder = new List<string>();
                    linebuilder.Add(vehicle);

                    foreach (var value in michelinonly[vehicle])
                    {
                        linebuilder.Add(value);
                    }

                    michelinonlyoutfile.WriteLine(string.Join(polkdeli.ToString(), linebuilder.ToArray()));
                }
            }

            int polkunique = polkvehicledata.Count;
            int michelinunique = michelinvehicledata.Count;

            Console.WriteLine();
            Console.WriteLine("{0} - Polk Unique Vehicles", polkunique);
            Console.WriteLine("{0} - Michelin Unique Vehicles", michelinunique);

        }

        static public void MichelinCanadaPOLKTirePotentialSegmentChecker() // check the TP_SEG columns 
        {
            // e1platform mich_polk_lookup table tp_seg column should match us_usage_table table tp_seg column

            // mich_polk_lookup table is updated with the "2019 US Polk Summary Final - Nuestar.csv" file from michelin.

            // us_usage_table table is updated with the "2019 US Usage-v1.csv" file from michelin.

            // TP_SEG is Group_Cat and Standard_Tire_Size concatenated 


            // Each TP_SEG entry in the US Usage file should be unique...
            // Compare uniques from both files. 
            // Output a file with two columns, matching ... US-Usage-TPseg , Summary-File-TPSEG
            // non-matches are listed as "tpseg" , "no match" in appropriate columns

            Console.WriteLine("-Enter Canada Usage File-");
            string canadausagefile = GetAFile();
            char canadausagedeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter Canada Summary File-");
            string canadasummaryfile = GetAFile();
            char canadasummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tpsegfile = filefolderpath + "\\tpsegments.txt";
            char newdeli = '\t'; // tab

            HashSet<string> canadausagetpsegs = new HashSet<string>();
            HashSet<string> canadasummarytpsegs = new HashSet<string>();

            int matches = 0;
            int canadasummaryrecords = 0;
            int canadausagerecords = 0;

            using (StreamReader canadausagereadfile = new StreamReader(canadausagefile))
            {
                string header = canadausagereadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, canadausagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = canadausagereadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, canadausagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(canadausagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = canadausagetpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        canadausagerecords++;
                    }
                }
            }

            using (StreamReader ussummaryreadfile = new StreamReader(canadasummaryfile))
            {
                string header = ussummaryreadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, canadausagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ussummaryreadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, canadausagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(canadausagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = canadasummarytpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        canadasummaryrecords++;
                    }
                }
            }


            using (StreamWriter tpsegoutfile = new StreamWriter(tpsegfile))
            {
                tpsegoutfile.WriteLine("{0}{1}{2}", "Canada_Summary_TP_SEG", newdeli, "Canada_Usage_TP_SEG");

                foreach (var x in canadasummarytpsegs)
                {
                    if (canadausagetpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, x);
                        matches++;
                    }
                    else
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, "");
                    }
                }

                foreach (var x in canadausagetpsegs)
                {
                    if (!canadasummarytpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", "", newdeli, x);
                    }
                }
            }

            Console.WriteLine("{0} - Canada Usage Tp_Segs", canadausagerecords);
            Console.WriteLine("{0} - Canada Summary Tp_Segs", canadasummaryrecords);
            Console.WriteLine("{0} - Matches", matches);
        }

        static public void MichelinCanadaPOLKTirePotentialSegmentCheckerWINTER() // check the TP_SEG columns 
        {
            // e1platform mich_polk_lookup table tp_seg column should match TP_REGION_SEG_USAGE table tp_seg column
            // e1platform michelin_polk_lookup_winter table tp_seg column should match usage_winter table tp_seg column

            // Each TP_SEG entry in the canada Usage file should be unique...
            // Compare uniques from both files. 
            // Output a file with two columns, matching ... Canada-Usage-TPseg , Summary-File-TPSEG
            // non-matches are listed as "tpseg" , "no match" in appropriate columns

            Console.WriteLine("-Enter Canada Winter Usage File-");
            string canadausagefile = GetAFile();
            char canadausagedeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter Canada Winter Summary File-");
            string canadasummaryfile = GetAFile();
            char canadasummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tpsegfile = filefolderpath + "\\tpsegmentsWINTER.txt";
            char newdeli = '\t'; // tab

            HashSet<string> canadausagetpsegs = new HashSet<string>();
            HashSet<string> canadasummarytpsegs = new HashSet<string>();

            int matches = 0;
            int canadasummaryrecords = 0;
            int canadausagerecords = 0;

            using (StreamReader ususagereadfile = new StreamReader(canadausagefile))
            {
                string header = ususagereadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, canadausagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ususagereadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, canadausagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(canadausagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = canadausagetpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        canadausagerecords++;
                    }
                }
            }

            using (StreamReader ussummaryreadfile = new StreamReader(canadasummaryfile))
            {
                string header = ussummaryreadfile.ReadLine();

                string tpsegname = "TP_SEG"; //column index finder puts everything .toupper().

                //Int32 tpsegindex; //system.int32
                int tpsegindex = 0; // primative data type. does not allow for null values.

                try
                {
                    tpsegindex = ColumnIndexWithQualifier(header, canadausagedeli, txtq, tpsegname);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                string line = string.Empty;
                while ((line = ussummaryreadfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, canadausagedeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(canadausagedeli));
                    }

                    string[] splitline = arraybuilder.ToArray();
                    bool added = canadasummarytpsegs.Add(splitline[tpsegindex]);

                    if (added == true)
                    {
                        canadasummaryrecords++;
                    }
                }
            }


            using (StreamWriter tpsegoutfile = new StreamWriter(tpsegfile))
            {
                tpsegoutfile.WriteLine("{0}{1}{2}", "Canada_Summary_TP_SEG", newdeli, "Canada_Usage_TP_SEG");

                foreach (var x in canadasummarytpsegs)
                {
                    if (canadausagetpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, x);
                        matches++;
                    }
                    else
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", x, newdeli, "");
                    }
                }

                foreach (var x in canadausagetpsegs)
                {
                    if (!canadasummarytpsegs.Contains(x))
                    {
                        tpsegoutfile.WriteLine("{0}{1}{2}", "", newdeli, x);
                    }
                }
            }

            Console.WriteLine("{0} - Canada Usage Tp_Segs", canadausagerecords);
            Console.WriteLine("{0} - Canada Summary Tp_Segs", canadasummaryrecords);
            Console.WriteLine("{0} - Matches", matches);
        }

        static public void MichelinCanadaPOLKGroupCatChecker() // Check if the Group_Categories align between the active_mspns1 and mich_polk_lookup files
        {
            // ACTIVE_MSPNS1 table, columns "GROUPE_CATEGORY", "TIRE_SIZE"
            // 2019-US-PolkSummary-Final.csv file, columns "Group_Cat", "Standard_Tire_Size"

            // look at TIRE_SIZES. then compare on tire size + group category,

            Console.WriteLine("-Enter ACTIVE MSPN File-");
            string activemspnfile = GetAFile();
            char activemspndeli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter Canada Summary File-");
            string canadasummaryfile = GetAFile();
            char canadasummarydeli = GetDelimiter();
            // char txtq = GetTXTQualifier();

            Console.WriteLine();
            Console.WriteLine("-Enter Canada Winter Summary File-");
            string canadasummarywinterfile = GetAFile();
            char canadasummarywinterdeli = GetDelimiter();


            string filefolderpath = GetDesktopDirectory() + @"\michelin_canadapolk_counts";
            if (!Directory.Exists(filefolderpath))
            {
                DirectoryInfo di = Directory.CreateDirectory(filefolderpath);
            }

            string tiresizegroupcatfile = filefolderpath + "\\tiresizegroupcatcheckfile.txt";
            char newdeli = '\t'; // tab

            // active mspn columns GROUPE_CATEGORY TIRE_SIZE
            // summary file columns Group_Cat Standard_Tire_Size
            // group category only has 6 possible values - Rec/Com, V, Z, Winter, "ENTRY (S,T)", H.
            // "ENTRY (S,T)" - might cause issues, need to maintain the , in the data  in order to be accurate.

            // tire size will be key, categories will go into the list 
            Dictionary<string, List<string>> activemspntiregroupcategories = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> canadasummarytiregroupcategories = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> canadasummarywintertiregroupcategories = new Dictionary<string, List<string>>();
            string[] groupcategories = { "REC/COM", "V", "Z", "Winter", "ENTRY (S,T)", "H" };

            using (StreamReader amspnfile = new StreamReader(activemspnfile))
            {
                string header = amspnfile.ReadLine();

                string tirecolumnname = "TIRE_SIZE";
                string groupcolumnname = "GROUPE_CATEGORY";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = amspnfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!activemspntiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        activemspntiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!activemspntiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        activemspntiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }
            }

            using (StreamReader summaryfile = new StreamReader(canadasummaryfile))
            {
                string header = summaryfile.ReadLine();

                string tirecolumnname = "Standard_Tire_Size";
                string groupcolumnname = "Group Cat";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = summaryfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!canadasummarytiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        canadasummarytiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!canadasummarytiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        canadasummarytiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }
            }

            using (StreamReader wintersummaryfile = new StreamReader(canadasummarywinterfile))
            {
                string header = wintersummaryfile.ReadLine();

                string tirecolumnname = "Standard_Tire_Size";
                string groupcolumnname = "Group Cat";
                int tiresizecolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, tirecolumnname);
                int groupcolumn = ColumnIndexWithQualifier(header, activemspndeli, txtq, groupcolumnname);

                string line = string.Empty;
                while ((line = wintersummaryfile.ReadLine()) != null)
                {
                    List<string> arraybuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        arraybuilder.AddRange(SplitLineWithTxtQualifier(line, activemspndeli, txtq, false));
                    }
                    else
                    {
                        arraybuilder.AddRange(line.Split(activemspndeli));
                    }

                    string[] splitline = arraybuilder.ToArray();

                    string keytocheck = splitline[tiresizecolumn];
                    string valuetocheck = splitline[groupcolumn];

                    if (!canadasummarywintertiregroupcategories.ContainsKey(keytocheck))
                    {
                        List<string> templist = new List<string>();
                        templist.Add(valuetocheck);

                        canadasummarywintertiregroupcategories.Add(keytocheck, templist);
                    }

                    if (!canadasummarywintertiregroupcategories[keytocheck].Contains(valuetocheck))
                    {
                        canadasummarywintertiregroupcategories[keytocheck].Add(valuetocheck);
                    }
                }
            }

            using (StreamWriter outfile = new StreamWriter(tiresizegroupcatfile))
            {
                // return only records from the summary file that are not found in the active mspn file.
                // group category only has 6 possible values - Rec/Com, V, Z, Winter, "ENTRY (S,T)", H.

                List<string> header = new List<string>();
                header.Add("GroupMatchError");
                header.Add("TireSize");
                header.Add("Rec/Com");
                header.Add("V");
                header.Add("Z");
                header.Add("Winter");
                header.Add("ENTRY (S,T)");
                header.Add("H");
                outfile.WriteLine(string.Join(newdeli.ToString(), header.ToArray()));

                foreach (var tiresize in canadasummarytiregroupcategories.Keys)
                {
                    if (!activemspntiregroupcategories.ContainsKey(tiresize)) // if the tire size is not found.
                    {
                        //output the tire size and the group categories.
                        string[] categories = new string[6];
                        string error = string.Empty;
                        bool matchfound = false;

                        //for (int index = 0; index < groupcategories.Length; index++)
                        //{
                        //   if (ussummarytiregroupcategories[tiresize].Contains(groupcategories[index])) 
                        //   {
                        //      categories[index] = groupcategories[index];
                        //      matchfound = true; //shows that we found at least one match.
                        //   }
                        //}

                        foreach (var category in groupcategories) //loop through all possible matches. any matches get added 
                        {
                            if (canadasummarytiregroupcategories[tiresize].Contains(category))
                            {
                                int index = Array.IndexOf(groupcategories, category);
                                categories[index] = category;

                                matchfound = true;
                            }
                        }

                        if (matchfound == true)
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTire"; // new tire has been added.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories)
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                        else
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTireNotValidCategory"; // new tire added and group category does NOT match what it should.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in canadasummarytiregroupcategories[tiresize]) //just write existing group categories in order they appear.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                    }
                    else //tire exists.
                    {
                        string[] categories = new string[6];
                        List<string> badcategory = new List<string>();
                        string error = string.Empty;
                        string categoryvaliderror = string.Empty;
                        bool matchfound = true;
                        bool newcategory = false;

                        foreach (var category in canadasummarytiregroupcategories[tiresize]) //tire exists, so compare group categories from both dictionaries.
                        {
                            if (activemspntiregroupcategories[tiresize].Contains(category)) // category found in both dicts.
                            {
                                if (!groupcategories.Contains(category)) // validate it is a good group categories. if it is good and matches do nothing.
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                            else //category not found in original file
                            {
                                if (groupcategories.Contains(category)) // validate it is a good group categories.
                                {
                                    int index = Array.IndexOf(groupcategories, category);
                                    categories[index] = category;

                                    newcategory = true;
                                }
                                else
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                        }

                        if (matchfound == false)
                        {
                            List<string> linebuilder = new List<string>();
                            categoryvaliderror = "NotValidCategory";
                            linebuilder.Add(categoryvaliderror);
                            linebuilder.Add(tiresize);
                            foreach (var category in badcategory) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                        if (newcategory == true)
                        {
                            //tire exists but there is a new category.
                            List<string> linebuilder = new List<string>();
                            error = "NewCategory";
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                    }
                }

                foreach (var tiresize in canadasummarywintertiregroupcategories.Keys)
                {
                    if (!activemspntiregroupcategories.ContainsKey(tiresize)) // if the tire size is not found.
                    {
                        //output the tire size and the group categories.
                        string[] categories = new string[6];
                        string error = string.Empty;
                        bool matchfound = false;

                        //for (int index = 0; index < groupcategories.Length; index++)
                        //{
                        //   if (ussummarytiregroupcategories[tiresize].Contains(groupcategories[index])) 
                        //   {
                        //      categories[index] = groupcategories[index];
                        //      matchfound = true; //shows that we found at least one match.
                        //   }
                        //}

                        foreach (var category in groupcategories) //loop through all possible matches. any matches get added 
                        {
                            if (canadasummarywintertiregroupcategories[tiresize].Contains(category))
                            {
                                int index = Array.IndexOf(groupcategories, category);
                                categories[index] = category;

                                matchfound = true;
                            }
                        }

                        if (matchfound == true)
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTireWinter"; // new tire has been added.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories)
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                        else
                        {
                            List<string> linebuilder = new List<string>();
                            error = "NewTireNotValidCategoryWinter"; // new tire added and group category does NOT match what it should.
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in canadasummarywintertiregroupcategories[tiresize]) //just write existing group categories in order they appear.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                    }
                    else //tire exists.
                    {
                        string[] categories = new string[6];
                        List<string> badcategory = new List<string>();
                        string error = string.Empty;
                        string categoryvaliderror = string.Empty;
                        bool matchfound = true;
                        bool newcategory = false;

                        foreach (var category in canadasummarywintertiregroupcategories[tiresize]) //tire exists, so compare group categories from both dictionaries.
                        {
                            if (activemspntiregroupcategories[tiresize].Contains(category)) // category found in both dicts.
                            {
                                if (!groupcategories.Contains(category)) // validate it is a good group categories. if it is good and matches do nothing.
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                            else //category not found in original file
                            {
                                if (groupcategories.Contains(category)) // validate it is a good group categories.
                                {
                                    int index = Array.IndexOf(groupcategories, category);
                                    categories[index] = category;

                                    newcategory = true;
                                }
                                else
                                {
                                    badcategory.Add(category);
                                    matchfound = false;
                                }
                            }
                        }

                        if (matchfound == false)
                        {
                            List<string> linebuilder = new List<string>();
                            categoryvaliderror = "NotValidCategoryWinter";
                            linebuilder.Add(categoryvaliderror);
                            linebuilder.Add(tiresize);
                            foreach (var category in badcategory) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }

                        if (newcategory == true)
                        {
                            //tire exists but there is a new category.
                            List<string> linebuilder = new List<string>();
                            error = "NewCategoryWinter";
                            linebuilder.Add(error);
                            linebuilder.Add(tiresize);
                            foreach (var category in categories) // write categories that do not match template.
                            {
                                linebuilder.Add(category);
                            }

                            string newline = string.Join(newdeli.ToString(), linebuilder.ToArray());

                            outfile.WriteLine(newline);
                        }
                    }
                }
            }
        }





        // Methods not in menu.
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
        static public void TestStringLength() // only keeps records that have a char_length < 30.   
        {
            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }
            Console.Write("Processing...");

            string outfile = GetDesktopDirectory() + "\\good.txt";
            string badrecords = GetDesktopDirectory() + "\\bad.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter good = new StreamWriter(outfile))
                {
                    using (StreamWriter bad = new StreamWriter(badrecords))
                    {
                        string lines;
                        //int count = 0;

                        string firstline = readfile.ReadLine();
                        string[] firstarray = firstline.Split(split_char);
                        int firstlength = firstarray.Length;

                        good.WriteLine(firstline);
                        bad.WriteLine(firstline);

                        while ((lines = readfile.ReadLine()) != null)
                        {
                            // Replace characters that cause problems. 
                            //lines = lines.Replace(",", "");
                            //lines = lines.Replace(".", "");
                            lines = lines.Replace("\"", "");

                            //
                            string[] splitline = lines.Split(split_char);
                            string newline = string.Join(delimeter, splitline);
                            int length = splitline.Length;

                            int test1 = 0;
                            int test2 = 0;

                            //Equal too!
                            if (length == firstlength)
                            {
                                foreach (var a in splitline)
                                {
                                    if (a.Length >= 30)
                                    {
                                        test1 = 1;
                                    }
                                }
                            }

                            //Greater Than.
                            if (length >= firstlength)
                            {
                                string[] editnewline = new string[length];
                                for (int x = 0; x < length; x++)
                                {
                                    editnewline[x] = splitline[x];
                                }
                                foreach (var b in editnewline)
                                {
                                    if (b.Length >= 30)
                                    {
                                        test2 = 1;
                                    }
                                }
                                string editline = string.Join(delimeter, editnewline);
                                newline = editline;
                            }

                            if (test1 == 0 || test2 == 0)
                            {
                                good.WriteLine(newline);
                            }
                            else
                            {
                                bad.WriteLine(newline);
                            }
                        }

                    }
                }
            }
        }

        static public void FindValueInColumn() //prints line with valid value in column to file, else prints to different file.
        {
            // work in progress... rethink logic a bit.
            Console.WriteLine("Find lines with string x in column y.");
            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }

            Console.Write("Enter Column Name: ");
            string column = Console.ReadLine();
            column = column.ToUpper();

            //Strings to find.
            Console.Write("Enter string: ");
            string input = Console.ReadLine();
            input = input.Trim();

            int count = 0;

            Console.Write("Processing...");

            string outfile = GetDesktopDirectory() + "\\found_lines.txt";
            string outfile2 = GetDesktopDirectory() + "\\extra_lines.txt";

            using (StreamReader read_file = new StreamReader(file))
            {
                using (StreamWriter new_file = new StreamWriter(outfile))
                {
                    using (StreamWriter new_file2 = new StreamWriter(outfile2))
                    {
                        string header = read_file.ReadLine();
                        string[] split_header = header.Split(split_char);

                        new_file.WriteLine(header);
                        new_file2.WriteLine(header);

                        int index = 0;
                        for (int i = 0; i < split_header.Length - 1; i++)
                        {

                            if (column == split_header[i].ToUpper())
                            {
                                index = i;
                                break;
                            }
                        }

                        string lines;
                        while ((lines = read_file.ReadLine()) != null)
                        {
                            string[] split_line = lines.Split(split_char);

                            if (split_line[index] == column)
                            {
                                new_file.WriteLine(lines);
                                count++;
                            }
                            else
                            {
                                new_file2.WriteLine(lines);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("{0} - lines found to contain {1}", count, input);
        }

        static public void ValuePull() // pulls specified values in columns chosen by user.
        {
            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }

            Console.Write("Column number to pull values from: ");
            string column = Console.ReadLine();
            int ID_Column;
            if (!int.TryParse(column, out ID_Column))
            {
                Console.WriteLine("Invalid number");
                return;
            }

            Console.Write("Enter additional column numbers to pull as space separated ints: ");
            string more_columns = Console.ReadLine(); // read column values

            string[] edit_columns = more_columns.Split(' '); // put into array.

            int[] append = Array.ConvertAll(edit_columns, int.Parse); // convert string array to ints.


            Console.Write("Processing...");
            string outfile = GetDesktopDirectory() + "\\columns.txt";

            using (StreamWriter write_to = new StreamWriter(outfile))
            {
                using (StreamReader readfile = new StreamReader(file))
                {
                    string lines;

                    while ((lines = readfile.ReadLine()) != null)
                    {
                        string[] split_line = lines.Split(split_char);

                        string newline = split_line[ID_Column - 1];
                        foreach (var i in append)
                        {
                            newline = newline + delimeter + split_line[i - 1];
                        }

                        write_to.WriteLine(newline);
                    }
                }
            }
        }

        static public void AddUniqueIDColumnToFile() // Not Used
        {
            int my_number = 1000000;


            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }

            // Get record count or count records.
            Console.Write("Record Count? (Leave Blank for Auto Count): ");
            string input = Console.ReadLine();
            int number_of_records = 0;
            if (!int.TryParse(input, out number_of_records))
            {
                using (StreamReader read_file = new StreamReader(file))
                {
                    string lines;
                    while ((lines = read_file.ReadLine()) != null)
                    {
                        number_of_records++;
                    }
                }
            }


            if (number_of_records < my_number)
            {
                number_of_records = my_number;
            }
            else if (number_of_records < (my_number * 10))
            {
                number_of_records = my_number * 10;
            }
            else
            {
                number_of_records = my_number * 1000;
            }

            Console.Write("Processing...");

            string outfile = GetDesktopDirectory() + "\\file_plus_IDs.txt";

            using (StreamReader read_file = new StreamReader(file))
            {
                using (StreamWriter new_file = new StreamWriter(outfile))
                {
                    string lines;
                    string header = read_file.ReadLine();
                    header = "Id" + delimeter + header;
                    new_file.WriteLine(header);

                    while ((lines = read_file.ReadLine()) != null)
                    {
                        number_of_records += 1;
                        string id = number_of_records.ToString();

                        lines = id + delimeter + lines;

                        new_file.WriteLine(lines);
                    }
                }
            }
        }

        static public void PullUniqueRows() //not done yet.
        {
            Console.Write("File: ");
            string file = Console.ReadLine();

            Console.Write("Delimeter: ");
            string delimeter = Console.ReadLine();
            char split_char;
            if (!char.TryParse(delimeter, out split_char))
            {
                Console.Write("Invalid Char");
                return;
            }

            Console.Write("Enter Column Name: ");
            string column_name = Console.ReadLine();


            Console.Write("Processing...");

            column_name = column_name.Trim();
            column_name = column_name.ToUpper();

            Dictionary<string, string> ID_values = new Dictionary<string, string>();

            string newfile = GetDesktopDirectory() + "\\deduped_records.txt";
            string line;
            int count_lines = 0;

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(newfile))
                {
                    string header = readfile.ReadLine();
                    string[] columns = header.Split(split_char);
                    int length = columns.Length;
                    writefile.WriteLine(header);

                    int column = 0;
                    for (int x = 0; x < length; x++)
                    {
                        if (column_name == columns[x].ToUpper())
                        {
                            column = x;
                        }
                    }

                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] split_line = line.Split(split_char);

                        if (split_line[column] != string.Empty)
                        {
                            if (!ID_values.ContainsKey(split_line[column]))
                            {
                                ID_values.Add(split_line[column], "1");
                            }
                            else
                            {
                                writefile.WriteLine(line);
                                count_lines++;
                            }
                        }

                    }
                }

            }
            Console.WriteLine("{0} - duplicate values", count_lines);


        }

        static public void EditLineInListOfFiles()
        {
            Console.Write("Folder: ");
            string txt_file_folder = Console.ReadLine();

            string[] filepaths = Directory.GetFiles(@txt_file_folder);

            List<string> file_names = new List<string>();

            Console.Write("Unique String in line to replace: ");
            string to_replace = Console.ReadLine();

            Console.Write("New Line: ");
            string replace_with = Console.ReadLine();

            // For each file, open, replace target line, write info to changed file.
            foreach (var file in filepaths)
            {
                string new_name = file.Replace(@".", "_new.");

                using (StreamReader read_file = new StreamReader(file))
                {
                    using (StreamWriter new_file = new StreamWriter(new_name))
                    {
                        string line = string.Empty;
                        while ((line = read_file.ReadLine()) != null)
                        {
                            if (line.Contains(to_replace))
                            {
                                new_file.WriteLine(replace_with);
                            }
                            else
                            {
                                new_file.WriteLine(line);
                            }
                        }
                    }
                }
            }

            Console.WriteLine("All files edited, saved with _new added to each file name.");

        }

        static public void SkipUserSpecifiedLines() // copies lines to new file (skips user defined lines, manually entered)
        {
            string file = GetAFile();
            char delimiter = GetDelimiter();

            Console.Write("Enter line to not read: ");

            string line_to_replace = Console.ReadLine();
            line_to_replace = line_to_replace.Trim().ToUpper();

            string new_file = GetDesktopDirectory() + "\\lines_removed.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(new_file))
                {
                    string lines = string.Empty;
                    int count = 0;
                    while ((lines = readfile.ReadLine()) != null)
                    {
                        if (lines.Trim().ToUpper() == line_to_replace)
                        {
                            count++;
                            Console.WriteLine("Lines skipped: {0}", count);
                        }
                        else
                        {
                            writefile.WriteLine(lines);
                        }
                    }
                }
            }

        }





        //COSTAR File Processes.
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************

        // ADD CHECKS FOR UNIQUE COLUMNS IN DATA PULL.

        // Every year the Costar Deliverable consists of two main file groups. 
        //    Points Files - Site Data.
        //    Area Files - Standard Geos. 
        //
        // Then later in the year we process the Catchup file. Smaller set of Points.
        //    Catchup File - Site Data

        // All data that is delivered to Costar is Processed on the Backend and delivered to E1 Support via SDFILER.
        // To test. Compare values of files delivered to Platform values. Custom report were created. 


        // Annual Points Files Deliverable
        static public void CostarPointsFiles()
        {
            // Points are delievered in a .csv file on sdfiler.
            //    upload into the costar instance.
            //
            // 1. Build reports. Format:
            //    Only able to use 3 radii at a time. thats fine. but still need a way to test.
            //    s1 | r1 | data
            //    s1 | r2 | data
            //    s1 | r3 | data
            //
            // 2. Costar Data Format: 1,2,3,5,10 mile radii
            //    s1 | r1 | data
            //    s1 | r2 | data
            //    s1 | r3 | data
            //    s1 | r4 | data
            //    s1 | r5 | data

            // BEGIN
            //Console.SetWindowSize(150, 60);

            Console.Write("Drag and Drop Costar Points Folder Here (CEX, BUSSUM, or DMGRA): ");
            string costardirectory = Console.ReadLine();

            Console.Write("Drag and Drop E1 Points Folder Here (CEX, BUSSUM, or DMGRA): ");
            string e1directory = Console.ReadLine();
            char e1deli = GetDelimiter();
            string[] costarfilepaths = Directory.GetFiles(@costardirectory);
            string[] e1filepaths = Directory.GetFiles(@e1directory);

            // Use dicts. One for each Radii. 1-3 and 4-5.
            Dictionary<string, string[]> e1radii1info = new Dictionary<string, string[]>();
            Dictionary<string, string[]> e1radii2info = new Dictionary<string, string[]>();
            Dictionary<string, string[]> e1radii3info = new Dictionary<string, string[]>();

            Dictionary<string, string[]> e1radii4info = new Dictionary<string, string[]>();
            Dictionary<string, string[]> e1radii5info = new Dictionary<string, string[]>();

            List<Dictionary<string, string[]>> dictionariestotest = new List<Dictionary<string, string[]>>();
            List<int> radiinumbertotest = new List<int>();

            int radii123fileindex = 0;
            int radii45fileindex = 0;

            // Read e1 radii files. 
            if (e1filepaths.Length >= 2)
            {
                Console.WriteLine();
                Console.WriteLine("E1 Files: ");
                int filenumber = 1;
                foreach (var file in e1filepaths)
                {
                    Console.WriteLine("{0} - {1}", filenumber++, GetFileNameWithoutExtension(file));
                }

                Console.Write("Enter number for radi 1-3 file: ");
                string answer = Console.ReadLine().Trim();
                Console.Write("Enter number for radi 4-5 file: ");
                string answer2 = Console.ReadLine().Trim();

                //convert endered numbers.
                bool parsedanswer = Int32.TryParse(answer, out radii123fileindex);
                bool parsedanswer2 = Int32.TryParse(answer2, out radii45fileindex);
                //correct numbers for index.
                radii123fileindex -= 1;
                radii45fileindex -= 1;

                // read the e1 files.
                for (int x = 0; x <= e1filepaths.Length - 1; x++)
                {
                    if (x == radii123fileindex)
                    {
                        CostarReadE1Radii123PointsFile(e1filepaths[radii123fileindex], e1deli, e1radii1info, e1radii2info, e1radii3info);

                        //Dictionaries to Test.
                        dictionariestotest.Add(e1radii1info);
                        dictionariestotest.Add(e1radii2info);
                        dictionariestotest.Add(e1radii3info);

                        //radii to test.
                        radiinumbertotest.Add(1);
                        radiinumbertotest.Add(2);
                        radiinumbertotest.Add(3);
                    }

                    if (x == radii45fileindex)
                    {
                        CostarReadE1Radii45PointsFile(e1filepaths[radii45fileindex], e1deli, e1radii4info, e1radii5info);
                        dictionariestotest.Add(e1radii4info);
                        dictionariestotest.Add(e1radii5info);
                        radiinumbertotest.Add(4);
                        radiinumbertotest.Add(5);
                    }
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("E1 File: ");
                Console.WriteLine(GetFileNameWithoutExtension(e1filepaths[0]));
                Console.WriteLine();
                Console.Write("Radii123 File (1) or Radii45 File (2), Enter 1 or 2: ");
                string answer = Console.ReadLine().Trim();
                int filenumber = 0;
                bool parsedanswer = Int32.TryParse(answer, out filenumber);

                if (filenumber == 1)
                {
                    CostarReadE1Radii123PointsFile(e1filepaths[radii123fileindex], e1deli, e1radii1info, e1radii2info, e1radii3info);
                    dictionariestotest.Add(e1radii1info);
                    dictionariestotest.Add(e1radii2info);
                    dictionariestotest.Add(e1radii3info);
                    radiinumbertotest.Add(1);
                    radiinumbertotest.Add(2);
                    radiinumbertotest.Add(3);
                }
                else
                {
                    CostarReadE1Radii45PointsFile(e1filepaths[radii45fileindex], e1deli, e1radii4info, e1radii5info);
                    dictionariestotest.Add(e1radii4info);
                    dictionariestotest.Add(e1radii5info);
                    radiinumbertotest.Add(4);
                    radiinumbertotest.Add(5);
                }
            }

            // Done with E1 files. Everything stored in memory.
            //*****************************************************************

            // Read the Costar File.

            Console.WriteLine();
            Console.WriteLine("Reading Costar Files...");
            char costardeli = GetDelimiter();

            int costarfilesprocesses = 0;
            List<string> failedsitesmasterlist = new List<string>();

            Dictionary<string, List<int>> failedsitesandvalues = new Dictionary<string, List<int>>(); // list SiteID, column index

            foreach (var file in costarfilepaths)
            {
                using (StreamReader costarfile = new StreamReader(file))
                {
                    // Example line from Costar Data File.
                    // AREA_ID,    ID,       RING, RING_DEFN, LAT,         LON,           ALCOHOLIC_BEVERAGES_CY
                    // 10000060_1, 10000060, 1,    1,         39.7577442,  -87.1055097,   18342
                    string readline = string.Empty;
                    string header = costarfile.ReadLine().Replace("\"", string.Empty);
                    string[] headervalues = header.Split(costardeli);
                    //List<string> failedsites = new List<string>();

                    while ((readline = costarfile.ReadLine()) != null)
                    {
                        // Find radii number and ID.
                        readline = readline.Replace("\"", string.Empty);

                        string[] splitreadline = readline.Split(costardeli);

                        string siteidwithring = splitreadline[0];
                        string siteid = splitreadline[1];   // consistent across deliverables. no need to change.
                        string ring = splitreadline[2]; //this is used to find the radii dictionaries.
                        int ringnumber = 0;
                        bool ringparse = Int32.TryParse(ring, out ringnumber); //get radii number 1-5.

                        // if fileformat changes.
                        //char radditotest = siteidradii[siteidradii.Length - 1]; //get the last character of the siteid. this will match the radii number.
                        //int radiinumber = 0;
                        //bool radiinumberparse = Int32.TryParse(radditotest.ToString(), out radiinumber);

                        if (radiinumbertotest.Contains(ringnumber))
                        {
                            int index = radiinumbertotest.IndexOf(ringnumber); //get index of ring value from the radiinumber list. index will match dictionarytotest list becuase they added in the same order.

                            string failedsiteinfo = CostarTestCostarRadiiXLine(dictionariestotest[index], siteid, ring, splitreadline, file);
                            if (!failedsitesmasterlist.Contains(failedsiteinfo))
                            {
                                failedsitesmasterlist.Add(failedsiteinfo);
                            }
                        }
                    }
                }

                costarfilesprocesses++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rCostar Files Processed - {0}.", costarfilesprocesses);
                Console.ResetColor();
            }

            string failedlist = GetDesktopDirectory() + "\\failedsites.txt";
            using (StreamWriter failures = new StreamWriter(failedlist))
            {
                foreach (var f in failedsitesmasterlist)
                {
                    failures.WriteLine(f);
                }
            }

            // again
            Console.WriteLine();
            Console.Write("Run again (y/n): ");
            string again = Console.ReadLine().Trim().ToUpper();

            if (again == "Y")
            {
                CostarPointsFiles();
            }


        }

        static public void CostarReadE1Radii123PointsFile(string filepath, char delimiter, Dictionary<string, string[]> radii1, Dictionary<string, string[]> radii2, Dictionary<string, string[]> radii3)
        {
            //read the one file into memory. same as old program. THIS WILL ONLY READ THE RADII 1-3 file
            using (StreamReader e1file = new StreamReader(filepath))
            {
                string line;
                // Read past header lines.
                e1file.ReadLine(); //reads report name line.
                e1file.ReadLine(); //reads area name line.
                e1file.ReadLine(); //reads the header line.

                while ((line = e1file.ReadLine()) != null)
                {
                    line = line.Replace("\"", string.Empty); //removes all " from the line if they are present in the file. no address just unformatted numbers so its fine.
                    string[] splitline = line.Split(delimiter);
                    int linelength = splitline.Length;
                    string key = splitline[0];

                    if (!radii1.ContainsKey(key)) //check for radii 1 info.
                    {
                        List<string> listvalues = new List<string>();
                        for (int v = 1; v < linelength; v++)
                        {
                            listvalues.Add(splitline[v]);
                        }
                        string[] values = listvalues.ToArray();
                        radii1.Add(key, values);

                        //*****************************************************************
                        string line2 = e1file.ReadLine();
                        string line3 = e1file.ReadLine();
                        line2 = line2.Replace("\"", string.Empty); //removes all " from the line if they are present in the file. no address just unformatted numbers so its fine.
                        line3 = line3.Replace("\"", string.Empty);
                        string[] splitline2 = line2.Split(delimiter);
                        string[] splitline3 = line3.Split(delimiter);
                        string key2 = splitline2[0];
                        string key3 = splitline3[0];

                        if (!radii2.ContainsKey(key2))
                        {
                            List<string> listvalues2 = new List<string>();
                            for (int v = 1; v < linelength; v++)
                            {
                                listvalues2.Add(splitline2[v]);
                            }
                            string[] values2 = listvalues2.ToArray();
                            radii2.Add(key2, values2);
                        }

                        if (!radii3.ContainsKey(key3))
                        {
                            List<string> list_values3 = new List<string>();
                            for (int v = 1; v < linelength; v++)
                            {
                                list_values3.Add(splitline3[v]);
                            }
                            string[] values3 = list_values3.ToArray();
                            radii3.Add(key3, values3);
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("E1 file - {0} - Processed.", filepath);
            Console.WriteLine("Radii 1 - {0}, unique values", radii1.Count());
            Console.WriteLine("Radii 2 - {0}, unique values", radii2.Count());
            Console.WriteLine("Radii 3 - {0}, unique values", radii3.Count());
            Console.WriteLine();
            Console.ResetColor();
        }

        static public void CostarReadE1Radii45PointsFile(string filepath, char delimiter, Dictionary<string, string[]> radii1, Dictionary<string, string[]> radii2)
        {
            //read the one file into memory. same as old program. THIS WILL ONLY READ THE RADII 1-3 file
            using (StreamReader e1file = new StreamReader(filepath))
            {
                string line;
                // Read past header lines.
                e1file.ReadLine(); //reads report name line.
                e1file.ReadLine(); //reads area name line.
                e1file.ReadLine(); //reads the header line.

                while ((line = e1file.ReadLine()) != null)
                {
                    line = line.Replace("\"", string.Empty); //removes all " from the line if they are present in the file. no address just unformatted numbers so its fine.
                    string[] splitline = line.Split(delimiter);
                    int linelength = splitline.Length;
                    string key = splitline[0];

                    if (!radii1.ContainsKey(key)) //check for radii 1 info.
                    {
                        List<string> listvalues = new List<string>();
                        for (int v = 1; v < linelength; v++)
                        {
                            listvalues.Add(splitline[v]);
                        }
                        string[] values = listvalues.ToArray();
                        radii1.Add(key, values);

                        //*****************************************************************
                        string line2 = e1file.ReadLine();
                        line2 = line2.Replace("\"", string.Empty); //removes all " from the line if they are present in the file. no address just unformatted numbers so its fine.
                        string[] splitline2 = line2.Split(delimiter);
                        string key2 = splitline2[0];

                        if (!radii2.ContainsKey(key2))
                        {
                            List<string> listvalues2 = new List<string>();
                            for (int v = 1; v < linelength; v++)
                            {
                                listvalues2.Add(splitline2[v]);
                            }
                            string[] values2 = listvalues2.ToArray();
                            radii2.Add(key2, values2);
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("E1 file - {0} - Processed.", filepath);
            Console.WriteLine("Radii 4 - {0}, unique values", radii1.Count());
            Console.WriteLine("Radii 5 - {0}, unique values", radii2.Count());
            Console.WriteLine();
            Console.ResetColor();
        }

        static public string CostarTestCostarRadiiXLine(Dictionary<string, string[]> radiidictionary, string siteid, string radiinumber, string[] splitline, string currentfile)
        {
            //string failstate = "fail";

            if (radiidictionary.ContainsKey(siteid))
            {
                int splitlinelength = splitline.Length - 7; // data to test starts at splitline[6].
                for (int v = 0; v < splitlinelength; v++)
                {
                    int radiidictindex = v + 6;

                    if (radiidictionary[siteid][v] != splitline[radiidictindex] && (radiidictionary[siteid][v] != string.Empty || splitline[radiidictindex] != string.Empty))
                    {
                        //tests individual values that arent equal
                        long costarvalue = Convert.ToInt64(Convert.ToDouble(radiidictionary[siteid][v]));
                        long e1value = Convert.ToInt64(Convert.ToDouble(splitline[radiidictindex]));

                        if (costarvalue != e1value && (costarvalue + 1) != e1value && (costarvalue - 1) != e1value)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("File: {0}", GetFileNameWithoutExtension(currentfile));
                            Console.Write(" SiteID: {0:10}, Radii: {1}, Column: {2} CValue: {3}, E1Value: {4}", siteid, radiinumber, radiidictindex, splitline[radiidictindex], radiidictionary[siteid][v]);
                            Console.WriteLine();
                            Console.ResetColor();

                            string badsiteinfo = siteid + "_" + radiinumber + "_" + radiidictindex + "_" + splitline[radiidictindex] + "_" + radiidictionary[siteid][v];

                            return badsiteinfo;
                        }
                    }
                }
            }

            return "siteid_radiinumber_columnnumber_costarvalue_e1value";
        }

        static public void CostarPointsFilesManualCheck()
        {
            // Output all variables for user specified site, also output all radii values.

            // Costar Data Format: 1,2,3,5,10 mile radii
            //    s1 | r1 | data
            //    s1 | r2 | data
            //    s1 | r3 | data
            //    s1 | r4 | data
            //    s1 | r5 | data

            Console.WriteLine();
            Console.WriteLine("Drag and Drop Costar Points Folder Here (CEX, BUSSUM, or DMGRA): ");
            string costardirectory = Console.ReadLine();
            string[] costarfilepaths = Directory.GetFiles(@costardirectory);
            char deli = GetDelimiter();
            //char qualifier = GetTXTQualifier();

            Dictionary<string, List<string>> radiivalues = new Dictionary<string, List<string>>();
            List<string> columnnames = new List<string>();

            Console.Write("Enter Radii # to test: ");
            string ringtotest = Console.ReadLine().Trim(); //out of memory exception when testing all radii. change to test just 1.

            using (StreamReader columnnamereader = new StreamReader(costarfilepaths[0]))
            {
                string header = columnnamereader.ReadLine();
                //string[] headervalues = SplitLineWithTxtQualifier(header, deli, qualifier, false);
                string[] headervalues = header.Split(deli);

                for (int v = 6; v <= headervalues.Length - 1; v++)
                {
                    columnnames.Add(headervalues[v]);
                }
            }

            int pointsadded = 0;
            int filesread = 0;
            foreach (var f in costarfilepaths)
            {
                using (StreamReader file = new StreamReader(f))
                {
                    string line = string.Empty;
                    file.ReadLine();

                    while ((line = file.ReadLine()) != null)
                    {
                        // Example line from Costar Data File.
                        // AREA_ID,    ID,       RING, RING_DEFN, LAT,         LON,           ALCOHOLIC_BEVERAGES_CY
                        // 10000060_1, 10000060, 1,    1,         39.7577442,  -87.1055097,   18342
                        line = line.Replace("\"", string.Empty);
                        string[] splitline = line.Split(deli);

                        string sitekey = splitline[1];
                        string sitering = splitline[2];

                        if (sitering == ringtotest)
                        {
                            if (!radiivalues.ContainsKey(sitekey))
                            {
                                List<string> valuestoadd = new List<string>();
                                for (int i = 6; i <= splitline.Length - 1; i++)
                                {
                                    valuestoadd.Add(splitline[i]);
                                }
                                radiivalues.Add(sitekey, valuestoadd);
                                pointsadded++;
                            }
                        }
                    }
                }
                filesread++;
                Console.WriteLine("\rFiles Read - {0}", filesread);
            }

            Console.WriteLine("Points read - {0}", pointsadded);

            int bufferwidth = Console.BufferWidth;
            int bufferheight = 600;
            Console.SetBufferSize(bufferwidth, bufferheight);

            string answer = string.Empty;
            Console.Write("Enter Site ID to search or \"exit\" to close the program: ");
            answer = Console.ReadLine();

            while (answer != "exit")
            {
                if (radiivalues.ContainsKey(answer))
                {
                    string[] columnarray = columnnames.ToArray();
                    List<string> keyvalues = radiivalues[answer];
                    string[] valuearray = keyvalues.ToArray();

                    //line builder
                    for (int v = 0; v <= columnarray.Length - 1; v++)
                    {
                        Console.WriteLine("{0,10} | {1,-30} | {2,-10}", answer, columnarray[v], valuearray[v]);
                    }
                    Console.WriteLine();
                }
                Console.Write("Enter Site ID to search or \"exit\" to close the program: ");
                answer = Console.ReadLine();
            }

            //close.
            if (answer == "exit")
            {
                Environment.Exit(0);
            }
        }

        static public void CoStarUSManualTestGapFile()
        {
            Console.Write("Drag and Drop the variable group folder here: ");
            string bussumdirectory = Console.ReadLine();
            //Console.Write("Drag and Drop the CEX folder here: ");
            //string cexdirectory = Console.ReadLine();
            //Console.Write("Drag and Drop the DMGRA folder here: ");
            //string dmgradirectory = Console.ReadLine();
            //Console.Write("Drag and Drop the DMGRB folder here: ");
            //string dmgrbdirectory = Console.ReadLine();

            //string[] bussumfilepaths = Directory.GetFiles(bussumdirectory);
            //string[] cexfilepaths = Directory.GetFiles(cexdirectory);
            //string[] dmgrafilepaths = Directory.GetFiles(dmgradirectory);
            //string[] dmgrbfilepaths = Directory.GetFiles(dmgrbdirectory);

            //List<string>allfilepaths = new List<string>();
            //allfilepaths.AddRange(Directory.GetFiles(bussumdirectory));
            //allfilepaths.AddRange(Directory.GetFiles(cexdirectory));
            //allfilepaths.AddRange(Directory.GetFiles(dmgradirectory));
            //allfilepaths.AddRange(Directory.GetFiles(dmgrbdirectory));

            string[] costarfilepaths = Directory.GetFiles(bussumdirectory);//allfilepaths.ToArray();

            char deli = GetDelimiter();
            //string[] costarfilepaths = Directory.GetFiles(costardirectory);

            // gap file dictionary.
            Dictionary<string, Dictionary<string, List<string>>> gapsitesinfo = new Dictionary<string, Dictionary<string, List<string>>>();
            HashSet<string> variablelist = new HashSet<string>();

            //read each file....
            foreach (var file in costarfilepaths)
            {
                // save all site info to dictionary

                using (StreamReader readfile = new StreamReader(file))
                {
                    string header = readfile.ReadLine();
                    header = header.Replace("\"", string.Empty);
                    string[] headersplit = header.Split(deli);
                    headersplit = headersplit.Skip(6).ToArray(); //remove area_id, id, ring, ring_defn, lat, lon

                    List<string> variablecolumns = new List<string>();

                    foreach (var variable in headersplit)
                    {
                        variablelist.Add(variable); // only uniques can be added.
                        variablecolumns.Add(variable); // current file variables, can use index of these as they are in order of file.
                    }

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        line = line.Replace("\"", string.Empty);
                        string[] splitline = line.Split(deli);

                        string propertykey = splitline[1];

                        if (!gapsitesinfo.ContainsKey(propertykey))
                        {
                            string line2 = readfile.ReadLine();
                            string line3 = readfile.ReadLine();
                            string line4 = readfile.ReadLine();
                            string line5 = readfile.ReadLine();
                            line2 = line2.Replace("\"", string.Empty);
                            line3 = line3.Replace("\"", string.Empty);
                            line4 = line4.Replace("\"", string.Empty);
                            line5 = line5.Replace("\"", string.Empty);

                            string[] splitline2 = line2.Split(deli);
                            string[] splitline3 = line3.Split(deli);
                            string[] splitline4 = line4.Split(deli);
                            string[] splitline5 = line5.Split(deli);

                            if ((splitline2[1] == propertykey) && (splitline3[1] == propertykey) && (splitline5[1] == propertykey) && (splitline4[1] == propertykey))
                            {
                                Dictionary<string, List<string>> tempdict = new Dictionary<string, List<string>>();
                                string[] variablearray = variablecolumns.ToArray();

                                foreach (var v in variablecolumns)
                                {
                                    List<string> templist = new List<string>();
                                    int index = Array.IndexOf(variablearray, v);

                                    int valueindex = index + 6;

                                    templist.Add(splitline[valueindex]);
                                    templist.Add(splitline2[valueindex]);
                                    templist.Add(splitline3[valueindex]);
                                    templist.Add(splitline4[valueindex]);
                                    templist.Add(splitline5[valueindex]);

                                    tempdict.Add(v, templist);
                                }

                                gapsitesinfo.Add(propertykey, tempdict);
                            }
                            else
                            {
                                Console.WriteLine("E1 keys do not match");
                            }
                        }
                        else
                        {
                            string line2 = readfile.ReadLine();
                            string line3 = readfile.ReadLine();
                            string line4 = readfile.ReadLine();
                            string line5 = readfile.ReadLine();
                            line2 = line2.Replace("\"", string.Empty);
                            line3 = line3.Replace("\"", string.Empty);
                            line4 = line4.Replace("\"", string.Empty);
                            line5 = line5.Replace("\"", string.Empty);

                            string[] splitline2 = line2.Split(deli);
                            string[] splitline3 = line3.Split(deli);
                            string[] splitline4 = line4.Split(deli);
                            string[] splitline5 = line5.Split(deli);

                            if ((splitline2[1] == propertykey) && (splitline3[1] == propertykey) && (splitline5[1] == propertykey) && (splitline4[1] == propertykey))
                            {
                                Dictionary<string, List<string>> tempdict = new Dictionary<string, List<string>>();
                                string[] variablearray = variablecolumns.ToArray();

                                foreach (var variablekey in variablecolumns)
                                {
                                    if (!gapsitesinfo[propertykey].ContainsKey(variablekey))
                                    {
                                        List<string> templist = new List<string>();
                                        int index = Array.IndexOf(variablearray, variablekey);

                                        int valueindex = index + 1;

                                        templist.Add(splitline[valueindex]);
                                        templist.Add(splitline2[valueindex]);
                                        templist.Add(splitline3[valueindex]);

                                        tempdict.Add(variablekey, templist);
                                    }
                                }

                                foreach (var variablekey in tempdict.Keys)
                                {
                                    gapsitesinfo[propertykey].Add(variablekey, tempdict[variablekey]);
                                }

                            }
                            else
                            {
                                Console.WriteLine("123 - E1 keys do not match");
                            }
                        }
                    }
                }
            }

            // user input
            string answer = string.Empty;
            Console.Write("Enter Site ID to search or \"exit\" to close the program: ");
            answer = Console.ReadLine().Trim().Replace("\"", string.Empty);

            while (answer != "exit")
            {
                // radii to check
                Console.Write("Enter Site Radii to test (1-5): ");
                string radiientry = Console.ReadLine().Trim();

                int radiitotest = 0;
                Int32.TryParse(radiientry, out radiitotest);
                radiitotest -= 1; // 0 - 4

                if (gapsitesinfo.ContainsKey(answer))
                {
                    foreach (var variable in variablelist)
                    {
                        // output id | variable | r
                        Console.WriteLine("{0,10} | {1,-35} | {2,-10}", answer, variable, gapsitesinfo[answer][variable][radiitotest]);
                    }
                }

                Console.WriteLine();
                Console.Write("Enter Site ID to search or \"exit\" to close the program: ");
                answer = Console.ReadLine().Trim().Replace("\"", string.Empty);
            }
        }

        static public void CostarTotalPointsCount()
        {
            Console.Write("Drag and Drop Costar Points Folder Here (CEX, BUSSUM, or DMGRA): ");
            string costardirectory = Console.ReadLine();

            string[] costarfilepaths = Directory.GetFiles(@costardirectory);
            char costardeli = GetDelimiter();

            Dictionary<string, string> totalsites = new Dictionary<string, string>();
            Dictionary<string, string> totalsiteradii = new Dictionary<string, string>();

            int costarfilesprocesses = 0;
            int totalnumsites = 0;
            int totalnumsiteradii = 0;
            int dupechecksitecount = 0;

            foreach (var file in costarfilepaths)
            {
                using (StreamReader costarfile = new StreamReader(file))
                {
                    // Example line from Costar Data File.
                    // AREA_ID,    ID,       RING, RING_DEFN, LAT,         LON,           ALCOHOLIC_BEVERAGES_CY
                    // 10000060_1, 10000060, 1,    1,         39.7577442,  -87.1055097,   18342
                    string readline = string.Empty;
                    string header = costarfile.ReadLine().Replace("\"", string.Empty);
                    string[] headervalues = header.Split(costardeli);

                    while ((readline = costarfile.ReadLine()) != null)
                    {
                        // Find radii number and ID.
                        readline = readline.Replace("\"", string.Empty);
                        string[] splitreadline = readline.Split(costardeli);

                        string siteidwithring = splitreadline[0];
                        string siteid = splitreadline[1];   // consistent across deliverables. no need to change.
                                                            //string ring = splitreadline[2]; //this is used to find the radii dictionaries.
                                                            //int ringnumber = 0;
                                                            //bool ringparse = Int32.TryParse(ring, out ringnumber); //get radii number 1-5.

                        if (!totalsites.ContainsKey(siteid))
                        {
                            totalsites.Add(siteid, "1");
                            totalnumsites++;
                        }

                        if (!totalsiteradii.ContainsKey(siteidwithring))
                        {
                            totalsiteradii.Add(siteidwithring, "1");
                            totalnumsiteradii++;
                        }
                        else
                        {
                            dupechecksitecount++;
                        }
                    }
                }

                costarfilesprocesses++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rCostar Files Processed - {0}.", costarfilesprocesses);
                Console.ResetColor();

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Total Sites - {0}", totalnumsites);
            Console.WriteLine("Total Radii - {0}", totalnumsiteradii);
            Console.WriteLine("Total Dupes - {0}", dupechecksitecount);
            Console.WriteLine();
        }

        static public void CostarPointsDupeRemove()
        {
            Console.Write("Drag and Drop Costar Points Folder Here (CEX, BUSSUM, or DMGRA): ");
            string costardirectory = Console.ReadLine();

            string[] costarfilepaths = Directory.GetFiles(@costardirectory);
            char costardeli = GetDelimiter();

            Dictionary<string, string> records = new Dictionary<string, string>();

            int costarfilesprocesses = 0;
            int totalnumsites = 0;
            int totalnumsiteradii = 0;
            int dupechecksitecount = 0;

            foreach (var file in costarfilepaths)
            {
                string dedupefile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_dedupe.txt";

                Dictionary<string, string> totalsiteradii = new Dictionary<string, string>();

                string header = string.Empty;

                using (StreamReader costarfile = new StreamReader(file))
                {
                    // Example line from Costar Data File.
                    // AREA_ID,    ID,       RING, RING_DEFN, LAT,         LON,           ALCOHOLIC_BEVERAGES_CY
                    // 10000060_1, 10000060, 1,    1,         39.7577442,  -87.1055097,   18342
                    string readline = string.Empty;
                    header = costarfile.ReadLine();

                    while ((readline = costarfile.ReadLine()) != null)
                    {
                        // Find radii number and ID.
                        readline = readline.Replace("\"", string.Empty);
                        string[] splitreadline = readline.Split(costardeli);

                        string siteidwithring = splitreadline[0];
                        //string siteid = splitreadline[1];

                        if (!records.ContainsKey(siteidwithring))
                        {
                            records.Add(siteidwithring, "1");
                            totalnumsites++;
                        }

                        if (!totalsiteradii.ContainsKey(siteidwithring))
                        {
                            totalsiteradii.Add(siteidwithring, readline); //save current file info in here.
                            totalnumsiteradii++;
                        }
                        else
                        {
                            dupechecksitecount++;
                        }
                    }
                }

                using (StreamWriter writefile = new StreamWriter(dedupefile))
                {
                    writefile.WriteLine(header);
                    foreach (KeyValuePair<string, string> record in totalsiteradii)
                    {
                        writefile.WriteLine(record.Value);
                    }
                }

                costarfilesprocesses++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rCostar Files Processed - {0}.", costarfilesprocesses);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("Total Sites - {0}", totalnumsites / 5);
            Console.WriteLine("Total Radii - {0}", totalnumsiteradii);
            Console.WriteLine("Total Dupes - {0}", dupechecksitecount);
            Console.WriteLine();
        }

        static public void CostarRemoveColumnFromFile()
        {
            //only for costar files. no txt qualifier needed.

            Console.Write("Drag and Drop Costar Points Folder Here (CEX, BUSSUM, or DMGRA): ");
            string costardirectory = Console.ReadLine();

            string[] costarfilepaths = Directory.GetFiles(@costardirectory);
            char costardeli = GetDelimiter();

            Console.Write("Column Name: ");
            string columntoremove = Console.ReadLine().Trim().ToUpper();

            Console.WriteLine();
            int costarfilesprocessed = 0;

            foreach (var file in costarfilepaths)
            {
                string removedcolumnfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "_" + columntoremove + "_removed.txt";

                using (StreamWriter writefile = new StreamWriter(removedcolumnfile))
                {
                    using (StreamReader readfile = new StreamReader(file))
                    {
                        string header = readfile.ReadLine();
                        string[] headersplit = header.Split(costardeli);
                        int columntoremoveindex = ColumnIndex(header, costardeli, columntoremove);
                        List<string> newheaderbuilder = new List<string>();

                        for (int x = 0; x <= headersplit.Length - 1; x++)
                        {
                            if (x != columntoremoveindex)
                            {
                                newheaderbuilder.Add(headersplit[x]);
                            }
                        }
                        writefile.WriteLine(string.Join(costardeli.ToString(), newheaderbuilder.ToArray()));

                        string line = string.Empty;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            string[] splitline = line.Split(costardeli);
                            List<string> linebuilder = new List<string>();

                            for (int x = 0; x <= splitline.Length - 1; x++)
                            {
                                if (x != columntoremoveindex)
                                {
                                    linebuilder.Add(splitline[x]);
                                }
                            }

                            string newline = string.Join(costardeli.ToString(), linebuilder.ToArray());

                            writefile.WriteLine(newline);
                        }
                    }
                }

                costarfilesprocessed++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\rCostar Files Processed - {0}.", costarfilesprocessed);
                Console.ResetColor();
            }
            Console.WriteLine();
        }


        //CoStar Canada GAP file
        static public void CostarCanadaTestGapFile()
        {
            // test CoStar Canada Gap File.
            // Steps
            // 1. Get file paths.
            // 2. Read E1 Files (going to be smaller than the costar/deliverable file). 
            // 3. Store E1 File info in memory.
            // 4. Read CoStar File, as reading check E1 Records. 
            // 5. While PropertyId = "____" save in temp list. compare whole list values to E1 File list values.


            // file format
            //PropertyID|Latitude|Longitude|VariableID|Radius1Amount|Radius2Amount|Radius3Amount|Radius4Amount|Radius5Amount

            //CoStar Points Variable List
            HashSet<string> e1variablelist = new HashSet<string>();

            // e1 files dictionary
            Dictionary<string, Dictionary<string, List<string>>> e1gapsitesinfo = new Dictionary<string, Dictionary<string, List<string>>>();

            //Read the E1 Files.
            CostarCanadaReadE1GapFiles(e1gapsitesinfo, e1variablelist);

            // data purge
            List<string> sitestoremove = new List<string>();
            foreach (var site in e1gapsitesinfo.Keys)
            {
                foreach (var variable in e1gapsitesinfo[site].Keys)
                {
                    if (e1gapsitesinfo[site][variable].Count != 5)
                    {
                        //e1gapsitesinfo.Remove(site); // if the site does not have 5 radii for any variable. remove it from the data. this is only targeting data from e1 which pulls sites at random.
                        //break;

                        //edit 12/7/20. error occurs 'Collection was modified; enumeration operation may not execute.' removing can not occur during itterations.
                        sitestoremove.Add(site);
                    }
                }
            }

            // data purge continued.
            if (sitestoremove.Count > 0)
            {
                foreach (string site in sitestoremove)
                {
                    e1gapsitesinfo.Remove(site);
                }
            }

            // status
            Console.WriteLine("E1 files read, beginning data tests.");

            List<string> failedgapdata = new List<string>();
            int failedradii = 0;
            int sitestested = 0;

            Console.WriteLine("-Enter CoStar Gap File-");
            string gapfile = GetAFile();
            char gapdeli = GetDelimiter();
            char txtq = '"';

            using (StreamReader gapdata = new StreamReader(gapfile))
            {
                string header = gapdata.ReadLine();

                int radii1 = ColumnIndexNew(header, gapdeli, "Radius1Amount", txtq); //returns 0 based index.
                int radii2 = ColumnIndexNew(header, gapdeli, "Radius2Amount", txtq);
                int radii3 = ColumnIndexNew(header, gapdeli, "Radius3Amount", txtq);
                int radii4 = ColumnIndexNew(header, gapdeli, "Radius4Amount", txtq);
                int radii5 = ColumnIndexNew(header, gapdeli, "Radius5Amount", txtq);

                List<int> radiivalues = new List<int>();
                radiivalues.Add(radii1);
                radiivalues.Add(radii2);
                radiivalues.Add(radii3);
                radiivalues.Add(radii4);
                radiivalues.Add(radii5);

                // settings
                Dictionary<string, Dictionary<string, List<string>>> tempsitevaluesdict = new Dictionary<string, Dictionary<string, List<string>>>();
                string storedsiteid = string.Empty;
                string notfoundsiteid = string.Empty;

                string line = string.Empty;
                while ((line = gapdata.ReadLine()) != null)
                {
                    string[] splitline = line.Split(gapdeli);

                    string linesiteid = splitline[0];
                    string linevariableid = splitline[3];

                    if (linesiteid == storedsiteid)
                    {
                        // test the row with the temp dictionary
                        if (tempsitevaluesdict[storedsiteid].ContainsKey(linevariableid))
                        {
                            // test the data.
                            // get the line values for the variable. 
                            for (int x = 0; x < tempsitevaluesdict[storedsiteid][linevariableid].Count - 1; x++)
                            {
                                string e1filenumber = tempsitevaluesdict[storedsiteid][linevariableid][x];
                                string gapfilenumber = splitline[radiivalues[x]];

                                if (gapfilenumber != e1filenumber)
                                {
                                    long costarvalue = Convert.ToInt64(Convert.ToDouble(gapfilenumber));
                                    long e1value = Convert.ToInt64(Convert.ToDouble(e1filenumber));

                                    if (costarvalue != e1value && (costarvalue + 1) != e1value && (costarvalue - 1) != e1value)
                                    {
                                        // add gap file info to list.
                                        List<string> linebuilder = new List<string>();
                                        linebuilder.Add(storedsiteid);
                                        linebuilder.Add("radii-" + (x + 1).ToString());
                                        linebuilder.Add(linevariableid);
                                        linebuilder.Add(gapfilenumber);

                                        failedgapdata.Add(string.Join(gapdeli.ToString(), linebuilder.ToArray()));
                                        failedradii++;
                                    }
                                    else
                                    {
                                        sitestested++;
                                    }
                                }
                                else
                                {
                                    sitestested++;
                                }
                            }
                        }
                    }
                    else if (linesiteid != storedsiteid && e1gapsitesinfo.ContainsKey(linesiteid))
                    {
                        // new site id encountered. 
                        // add to temp dictionary and then test.
                        storedsiteid = linesiteid;

                        if (tempsitevaluesdict.Count != 0)
                        {
                            tempsitevaluesdict.Clear();
                        }

                        List<string> listbuilder = new List<string>();
                        Dictionary<string, List<string>> dictbuilder = new Dictionary<string, List<string>>();

                        foreach (var variable in e1gapsitesinfo[storedsiteid].Keys)
                        {
                            dictbuilder.Add(variable, e1gapsitesinfo[storedsiteid][variable]);
                        }

                        tempsitevaluesdict.Add(storedsiteid, dictbuilder);

                        if (tempsitevaluesdict.ContainsKey(linevariableid))
                        {
                            // test the data.

                            // get the line values for the variable. 
                            for (int x = 0; x < tempsitevaluesdict[storedsiteid][linevariableid].Count - 1; x++)
                            {
                                string e1filenumber = tempsitevaluesdict[storedsiteid][linevariableid][x];
                                string gapfilenumber = splitline[radiivalues[x]];

                                if (gapfilenumber != e1filenumber)
                                {
                                    long costarvalue = Convert.ToInt64(Convert.ToDouble(gapfilenumber));
                                    long e1value = Convert.ToInt64(Convert.ToDouble(e1filenumber));

                                    if (costarvalue != e1value && (costarvalue + 1) != e1value && (costarvalue - 1) != e1value)
                                    {
                                        // add gap file info to list.
                                        List<string> linebuilder = new List<string>();
                                        linebuilder.Add(storedsiteid);
                                        linebuilder.Add("radii-" + (x + 1).ToString());
                                        linebuilder.Add(linevariableid);
                                        linebuilder.Add(gapfilenumber);

                                        failedgapdata.Add(string.Join(gapdeli.ToString(), linebuilder.ToArray()));
                                        failedradii++;
                                    }
                                }
                            }
                        }

                        sitestested++;

                        //memory management.
                        e1gapsitesinfo.Remove(linesiteid);
                    }
                    else
                    {
                        // did not find the current id on the line.
                        // clear all data.
                        tempsitevaluesdict.Clear();
                        storedsiteid = string.Empty;
                    }
                }
            }

            if (failedradii > 0)
            {
                string failedlist = GetDesktopDirectory() + "\\failedsites.txt";
                using (StreamWriter failures = new StreamWriter(failedlist))
                {
                    //header
                    //char newdeli = '|';
                    failures.WriteLine("PropertyID|Radii|VariableID|RadiusAmount");

                    foreach (var p in failedgapdata)
                    {
                        failures.WriteLine(p);
                    }
                }
            }

            Console.WriteLine("Failed Radii Values - {0}", failedradii);
            Console.WriteLine("Number of sites tested - {0}", sitestested / 507); // sites tested is variables * number of sites. 507 variables are tested for canada.
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        public static void CostarCanadaReadE1GapFiles(Dictionary<string, Dictionary<string, List<string>>> e1gapsitesinfo, HashSet<string> e1variablelist)
        {
            //bool allmatch = true;
            //HashSet<string> sitesnotfullyexported = new HashSet<string>();

            Console.Write("Drag and Drop E1 123radii report outputs Folder Here: ");
            string directory123 = Console.ReadLine();
            string[] e1filepaths123 = Directory.GetFiles(@directory123);

            Console.Write("Drag and Drop E1 510radii report outputs Folder Here: ");
            string directory510 = Console.ReadLine();
            string[] e1filepaths510 = Directory.GetFiles(@directory510);

            char e1deli = GetDelimiter();

            foreach (var file in e1filepaths123)
            {
                using (StreamReader readfile = new StreamReader(file))
                {
                    // skip standard report output header lines.
                    readfile.ReadLine();
                    readfile.ReadLine();

                    string header = readfile.ReadLine();
                    header = header.Replace("\"", string.Empty);
                    string[] headersplit = header.Split(e1deli);

                    foreach (var variable in headersplit.Skip(1)) //skip property ID.
                    {
                        e1variablelist.Add(variable); // only uniques can be added.
                    }

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = line.Replace("\"", string.Empty).Split(e1deli);
                        string siteid = splitline[0];

                        string line2 = readfile.ReadLine();
                        string line3 = readfile.ReadLine();

                        string[] splitline2 = line2.Replace("\"", string.Empty).Split(e1deli);
                        string[] splitline3 = line3.Replace("\"", string.Empty).Split(e1deli);

                        if (!e1gapsitesinfo.ContainsKey(siteid))
                        {
                            if ((splitline2[0] == siteid) && (splitline3[0] == siteid))
                            {
                                Dictionary<string, List<string>> tempdict = new Dictionary<string, List<string>>();

                                foreach (var variable in headersplit.Skip(1))
                                {
                                    List<string> templist = new List<string>();
                                    int index = Array.IndexOf(headersplit, variable);

                                    templist.Add(splitline[index]);
                                    templist.Add(splitline2[index]);
                                    templist.Add(splitline3[index]);

                                    tempdict.Add(variable, templist);
                                }

                                e1gapsitesinfo.Add(siteid, tempdict);
                            }
                        }
                        else
                        {
                            foreach (var variable in headersplit.Skip(1))
                            {
                                if (!e1gapsitesinfo[siteid].ContainsKey(variable)) //siteid already in file. add additional values
                                {
                                    List<string> templist = new List<string>();
                                    int index = Array.IndexOf(headersplit, variable);

                                    templist.Add(splitline[index]);
                                    templist.Add(splitline2[index]);
                                    templist.Add(splitline3[index]);

                                    e1gapsitesinfo[siteid].Add(variable, templist);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("{0} - file read", GetFileNameWithoutExtension(file));
            }

            foreach (var file in e1filepaths510)
            {
                using (StreamReader readfile = new StreamReader(file))
                {
                    // skip standard report output header lines.
                    readfile.ReadLine();
                    readfile.ReadLine();

                    string header = readfile.ReadLine();
                    header = header.Replace("\"", string.Empty);
                    string[] headersplit = header.Split(e1deli);

                    foreach (var variable in headersplit.Skip(1))
                    {
                        e1variablelist.Add(variable); // only uniques can be added.
                    }

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = line.Replace("\"", string.Empty).Split(e1deli);

                        string siteid = splitline[0];

                        if (e1gapsitesinfo.ContainsKey(siteid))
                        {
                            string line2 = readfile.ReadLine();
                            string[] splitline2 = line2.Replace("\"", string.Empty).Split(e1deli);

                            if ((splitline2[0] == siteid))
                            {
                                foreach (var variable in headersplit)
                                {
                                    int index = Array.IndexOf(headersplit.ToArray(), variable);

                                    if (e1gapsitesinfo[siteid].ContainsKey(variable) && e1gapsitesinfo[siteid][variable].Count == 3)
                                    {
                                        e1gapsitesinfo[siteid][variable].Add(splitline[index]);
                                        e1gapsitesinfo[siteid][variable].Add(splitline2[index]);
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("{0} - file read", GetFileNameWithoutExtension(file));
            }
        }

        public static void CostarCanadaManualTestGapfile()
        {

            // add variable lists so things are in order.

            // gap file dictionary.
            Dictionary<string, Dictionary<string, List<string>>> gapsitesinfo = new Dictionary<string, Dictionary<string, List<string>>>();
            HashSet<string> costarvariablelist = new HashSet<string>();

            Console.WriteLine("-Enter CoStar Gap File-");
            string gapfile = GetAFile();
            char gapdeli = GetDelimiter();

            Console.WriteLine("-Enter CoStar Variable File-");
            string variablefile = GetAFile();
            List<string> tofindvariablelist = new List<string>();

            using (StreamReader consumer = new StreamReader(variablefile))
            {
                string line = string.Empty;

                while ((line = consumer.ReadLine()) != null)
                {
                    tofindvariablelist.Add(line.Trim());
                }
            }

            using (StreamReader gapdata = new StreamReader(gapfile))
            {
                string header = gapdata.ReadLine();

                string line = string.Empty;
                while ((line = gapdata.ReadLine()) != null)
                {
                    string[] splitline = line.Split(gapdeli);

                    // propertykey = property id splitline[0];
                    // variablekey = splitfline[3];

                    string propertykey = splitline[0];
                    string variablekey = splitline[3];

                    // if site not found, add it and clear variable list dict
                    if (!gapsitesinfo.ContainsKey(propertykey))
                    {
                        costarvariablelist.Clear();

                        Dictionary<string, List<string>> tempdict = new Dictionary<string, List<string>>();
                        List<string> templist = new List<string>();

                        if (!costarvariablelist.Contains(variablekey) && tofindvariablelist.Contains(variablekey))
                        {
                            costarvariablelist.Add(variablekey);

                            for (int x = 4; x < splitline.Length; x++)
                            {
                                templist.Add(splitline[x]);
                            }

                            tempdict.Add(variablekey, templist);
                            gapsitesinfo.Add(propertykey, tempdict);
                        }
                    }
                    else if (gapsitesinfo.ContainsKey(propertykey) && tofindvariablelist.Contains(variablekey))
                    {
                        List<string> templist = new List<string>();

                        if (!costarvariablelist.Contains(variablekey))
                        {
                            costarvariablelist.Add(variablekey);

                            for (int x = 4; x < splitline.Length; x++)
                            {
                                templist.Add(splitline[x]);
                            }

                            gapsitesinfo[propertykey].Add(variablekey, templist);
                        }
                    }
                }
            }

            // user input
            string answer = string.Empty;
            Console.Write("Enter Site ID to search or \"exit\" to close the program: ");
            answer = Console.ReadLine().Trim().Replace("\"", string.Empty);

            while (answer != "exit")
            {
                // radii to check
                Console.Write("Enter Site Radii to test (1-5): ");
                string radiientry = Console.ReadLine().Trim();

                int radiitotest = 0;
                Int32.TryParse(radiientry, out radiitotest);
                radiitotest -= 1; // 0 - 4

                if (gapsitesinfo.ContainsKey(answer))
                {
                    foreach (var variable in tofindvariablelist)
                    {
                        // output id | variable | r
                        Console.WriteLine("{0,10} | {1,-35} | {2,-10}", answer, variable, gapsitesinfo[answer][variable][radiitotest]);
                    }
                }
                else
                {
                    Console.WriteLine("Site ID not found.");
                }

                Console.WriteLine();
                Console.Write("Enter Site ID to search or \"exit\" to close the program: ");
                answer = Console.ReadLine().Trim().Replace("\"", string.Empty);
            }
        }

        static public void CostarCanadaReformatNightlyFeedOutput()
        {
            // Reformat the output of the CoStar Nightly feed files
            // Will work for either nightly files or "gap deliverable files". 
            // Output will be Separate files based on Variable Lists.
            // TO CHANGE FOR US FILES just change variable lists.

            // file format
            //PropertyID|Latitude|Longitude|VariableID|Radius1Amount|Radius2Amount|Radius3Amount|Radius4Amount|Radius5Amount

            Console.WriteLine("-Enter CoStar Gap File-");
            string gapfile = GetAFile();
            char gapdeli = GetDelimiter();
            char txtq = '"';

            Console.WriteLine("-Enter File Path to Variable List files-");
            string variablepaths = Console.ReadLine();
            string[] variablefilepaths = Directory.GetFiles(@variablepaths);


            foreach (var file in variablefilepaths)
            {
                Console.WriteLine();
                string outputname = GetFileNameWithoutExtension(file);
                Console.WriteLine("Reading {0}.", outputname);

                List<string> variables = new List<string>();

                using (StreamReader consumer = new StreamReader(file))
                {
                    string line = string.Empty;

                    while ((line = consumer.ReadLine()) != null)
                    {
                        variables.Add(line.Trim());
                    }
                }

                // site deliverable data
                Dictionary<string, Dictionary<string, List<string>>> sitedata = new Dictionary<string, Dictionary<string, List<string>>>();

                // site lat lon
                Dictionary<string, List<string>> sitelatlondata = new Dictionary<string, List<string>>();

                using (StreamReader gapdata = new StreamReader(gapfile))
                {
                    string header = gapdata.ReadLine();

                    int radii1 = ColumnIndexNew(header, gapdeli, "Radius1Amount", txtq); //returns 0 based index.
                    int radii2 = ColumnIndexNew(header, gapdeli, "Radius2Amount", txtq);
                    int radii3 = ColumnIndexNew(header, gapdeli, "Radius3Amount", txtq);
                    int radii4 = ColumnIndexNew(header, gapdeli, "Radius4Amount", txtq);
                    int radii5 = ColumnIndexNew(header, gapdeli, "Radius5Amount", txtq);
                    int propertyid = ColumnIndexNew(header, gapdeli, "PropertyID", txtq);
                    int variableid = ColumnIndexNew(header, gapdeli, "VariableID", txtq);
                    int latindex = ColumnIndexNew(header, gapdeli, "Latitude", txtq);
                    int lonindex = ColumnIndexNew(header, gapdeli, "Longitude", txtq);

                    List<int> radiivalues = new List<int>();
                    radiivalues.Add(radii1);
                    radiivalues.Add(radii2);
                    radiivalues.Add(radii3);
                    radiivalues.Add(radii4);
                    radiivalues.Add(radii5);

                    string line = string.Empty;
                    while ((line = gapdata.ReadLine()) != null)
                    {
                        string[] splitline = line.Split(gapdeli);
                        string siteid = splitline[propertyid];
                        string linevariable = splitline[variableid];


                        if (variables.Contains(linevariable) && !sitedata.ContainsKey(siteid)) // doesnt contain siteid or variableid
                        {
                            Dictionary<string, List<string>> tempvariablevalues = new Dictionary<string, List<string>>();
                            List<string> tempradiivalues = new List<string>();

                            foreach (int radii in radiivalues)
                            {
                                tempradiivalues.Add(splitline[radii]);
                            }

                            // add variable and radii values to temp dict.
                            tempvariablevalues.Add(linevariable, tempradiivalues);

                            // add NEW site and line variable to parent dict.
                            sitedata.Add(siteid, tempvariablevalues);
                        }
                        else if (variables.Contains(linevariable) && sitedata.ContainsKey(siteid) && !sitedata[siteid].ContainsKey(linevariable)) // contains siteid, doesnt contain variableid
                        {
                            List<string> tempradiivalues = new List<string>();

                            foreach (int radii in radiivalues)
                            {
                                tempradiivalues.Add(splitline[radii]);
                            }

                            // add NEW line variable to parent dict.
                            sitedata[siteid].Add(linevariable, tempradiivalues);
                        }

                        if (!sitelatlondata.ContainsKey(siteid))
                        {
                            List<string> latlons = new List<string>();
                            latlons.Add(splitline[latindex]);
                            latlons.Add(splitline[latindex]);

                            // save the site id and lat lon
                            sitelatlondata.Add(siteid, latlons);
                        }
                    }
                }

                // output DICT values to new file.
                string newfile = GetDesktopDirectory() + "\\" + outputname + "_output.txt";

                using (StreamWriter outfile = new StreamWriter(newfile))
                {
                    Console.WriteLine("Generating output for - {0}.", outputname);
                    char e1deli = ',';

                    // Costar Data Format: 1,2,3,5,10 mile radii
                    //    s1 | r1 | data
                    //    s1 | r2 | data
                    //    s1 | r3 | data
                    //    s1 | r4 | data
                    //    s1 | r5 | data

                    // read and reformat gap file.
                    string[] headertofill = { "AREA_ID", "ID", "RING", "RING_DEFN", "LAT", "LON" };

                    //create file header.
                    List<string> headerbuilder = new List<string>();
                    foreach (var item in headertofill)
                    {
                        headerbuilder.Add(item);
                    }

                    foreach (var item in variables) //target deliverable variables.
                    {
                        headerbuilder.Add(item);
                    }

                    outfile.WriteLine(string.Join(e1deli.ToString(), headerbuilder.ToArray()));

                    foreach (var lookupsiteid in sitedata.Keys) // itterate over the site IDs. 
                    {
                        for (int x = 0; x <= 4; x++) // for each radii 0-4
                        {
                            // build the line.
                            List<string> linebuilder = new List<string>();


                            linebuilder.Add(lookupsiteid + "_" + (x + 1)); //areaID

                            linebuilder.Add(lookupsiteid); //siteID

                            linebuilder.Add((x + 1).ToString()); //ring

                            //ring definition
                            string ringdefn = string.Empty;
                            if (x == 3)
                            {
                                ringdefn = "5";
                            }
                            else if (x == 4)
                            {
                                ringdefn = "10";
                            }
                            else
                            {
                                ringdefn = (x + 1).ToString();
                            }
                            linebuilder.Add(ringdefn);

                            linebuilder.Add(sitelatlondata[lookupsiteid][0]); // lat

                            linebuilder.Add(sitelatlondata[lookupsiteid][1]); // lon

                            foreach (var variable in variables) // for each variable using the list to make the header to verify their order.
                            {
                                if (sitedata[lookupsiteid].ContainsKey(variable))
                                {
                                    linebuilder.Add(sitedata[lookupsiteid][variable][x]);
                                }
                                else
                                {
                                    Console.WriteLine("{0} - siteid. {1} - variable missing...", lookupsiteid, variable);
                                }
                            }

                            // output the line to the file.
                            outfile.WriteLine(string.Join(e1deli.ToString(), linebuilder.ToArray()));
                        }
                    }
                }

                //clear the dicts.
                sitedata.Clear();
                sitelatlondata.Clear();


            }


        }

        // CoStar Sum Columns
        public static void CostarSumDataColumns()
        {

            string file = GetAFile();
            char deli = GetDelimiter();
            char txtq = GetTXTQualifier();

            string countsfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(file) + "-variablesums.csv";

            Console.WriteLine();
            Console.Write("Enter column index to start summing at: ");
            string column = Console.ReadLine().Trim();
            int columnindex = Int32.Parse(column);

            //List<int> columnsums = new List<int>();

            using (StreamReader readfile = new StreamReader(file))
            {
                string header = readfile.ReadLine();
                List<string> headerlinebuilder = new List<string>();
                if (header.Contains(txtq))
                {
                    headerlinebuilder.AddRange(SplitLineWithTxtQualifier(header, deli, txtq, false));
                }
                else
                {
                    headerlinebuilder.AddRange(header.Split(deli));
                }

                string[] headersplitline = headerlinebuilder.ToArray();

                //value storage
                long[] columnsums = new long[headersplitline.Length - 1]; //account for geography ID column.

                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(SplitLineWithTxtQualifier(line, deli, txtq, false));
                    }
                    else
                    {
                        splitlinebuilder.AddRange(line.Split(deli));
                    }

                    string[] splitline = splitlinebuilder.ToArray();

                    for (int x = columnindex; x <= splitline.Length - 1; x++)
                    {
                        if (!string.IsNullOrWhiteSpace(splitline[x]))
                        {
                            long value = Int64.Parse(splitline[x]);

                            columnsums[x - 1] += value;
                        }
                    }
                }

                using (StreamWriter sumfile = new StreamWriter(countsfile))
                {
                    List<string> newheader = new List<string>();
                    for (int x = columnindex; x <= headersplitline.Length - 1; x++)
                    {
                        newheader.Add(headersplitline[x]);
                    }

                    sumfile.WriteLine(string.Join(deli.ToString(), newheader.ToArray()));
                    sumfile.WriteLine(string.Join(deli.ToString(), columnsums.ToArray()));
                }
            }
        }


        // Annual Area Files Deliverable.
        static public void CostarAreaFiles()
        {
            // Assumes variables are in the same order in both sets of files.
            Console.Write("Drag and Drop Costar AREA Desktop Folder Here (CEX, BUSSUM, or DMGRA): ");
            string costardirectory = Console.ReadLine();
            Console.Write("Drag and Drop E1 AREA Desktop Folder Here (CEX, BUSSUM, or DMGRA): ");
            string e1directory = Console.ReadLine();
            string[] costarfilepaths = Directory.GetFiles(@costardirectory);
            string[] e1filepaths = Directory.GetFiles(@e1directory);

            char e1deli = GetDelimiter();
            char txtq = GetTXTQualifier();

            Dictionary<string, List<string>> e1areas = new Dictionary<string, List<string>>();
            int areasadded = 0;
            foreach (var file in e1filepaths)
            {
                using (StreamReader e1file = new StreamReader(file))
                {
                    string line = string.Empty;
                    e1file.ReadLine();
                    e1file.ReadLine();
                    string header = e1file.ReadLine().Replace("\"", string.Empty); //get rid of header rows.
                    
                    while ((line = e1file.ReadLine()) != null)
                    {
                        string[] splitline = SplitLineWithTxtQualifier(line, e1deli, txtq, false); //line.Split(e1deli);

                        string e1key = splitline[0];
                        List<string> valuestoadd = new List<string>();
                        for (int v = 1; v <= splitline.Length - 1; v++)
                        {
                            valuestoadd.Add(splitline[v]);
                        }

                        //data starts at splitline[1].
                        if (!e1areas.ContainsKey(e1key))
                        {
                            e1areas.Add(e1key, valuestoadd);
                            areasadded++;
                        }
                    }
                }
            }

            Console.WriteLine("E1Areas read - {0}.", areasadded);

            //Costar Files.
            int areaschecked = 0;
            int areasfailed = 0;

            foreach (var file in costarfilepaths)
            {
                using (StreamReader costarfile = new StreamReader(file))
                {
                    string line = string.Empty;
                    string header = costarfile.ReadLine().Replace("\"", string.Empty); //get rid of header rows.
                    string[] headervalues = header.Split(e1deli);

                    while ((line = costarfile.ReadLine()) != null)
                    {
                        string[] splitline = SplitLineWithTxtQualifier(line, e1deli, txtq, false); //line.Split(e1deli);
                        string costarkey = splitline[0];

                        if (e1areas.ContainsKey(costarkey))
                        {
                            for (int v = 1; v <= splitline.Length - 1; v++)
                            {
                                if ((e1areas[costarkey][v - 1] != splitline[v]) && (e1areas[costarkey][v - 1] != string.Empty) || (splitline[v] != string.Empty))
                                {
                                    //tests individual values that arent equal

                                    long costarvalue = Convert.ToInt64(Convert.ToDouble(e1areas[costarkey][v - 1]));
                                    long e1value = Convert.ToInt64(Convert.ToDouble(splitline[v]));

                                    if (costarvalue != e1value && (costarvalue + 1) != e1value && (costarvalue - 1) != e1value)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("File: {0}", GetFileNameWithoutExtension(file));
                                        Console.Write(" AreaID - {0}, Column - {1} Costar Value - {2}, E1 Value - {3}", costarkey, headervalues[v], splitline[v], e1areas[costarkey][v - 1]);
                                        Console.WriteLine();
                                        Console.ResetColor();
                                        areasfailed++;
                                    }
                                }
                            }
                            if (areasfailed == 0)
                            {
                                areaschecked++;
                            }
                        }
                    }

                }
            }
            Console.WriteLine("Areas checked - {0}.", areaschecked);

            Console.WriteLine();
            Console.Write("Again? (y/n): ");
            string again = Console.ReadLine().ToLower();

            if (again == "y")
            {
                CostarAreaFiles();
            }
        }

        static public void CostarAreaFilesManualCheck()
        {
            Console.WriteLine("Drag and Drop Costar AREA File Here: ");
            string costarfile = GetAFile();
            char delimiter = GetDelimiter();
            char txtq = GetTXTQualifier();

            Dictionary<string, List<string>> costarareas = new Dictionary<string, List<string>>();
            int areasadded = 0;
            List<string> headerlist = new List<string>();

            using (StreamReader costardatafile = new StreamReader(costarfile))
            {
                // test for nick file or e1 export file.
                bool idfound = false;
                string headerline = string.Empty;

                while (idfound == false)
                {
                    string linetest = costardatafile.ReadLine().ToUpper();

                    if (linetest.Contains("AREA_ID") || linetest.Contains("GEOGRAPHY ID"))
                    {
                        idfound = true;
                        headerline = linetest;
                    }
                }

                string[] headernames = LineStringToArray(headerline, txtq, delimiter);
                headerlist = headernames.ToList();

                string line = string.Empty;
                while ((line = costardatafile.ReadLine()) != null)
                {
                    string[] splitline = LineStringToArray(line, txtq, delimiter);

                    //data starts at splitline[1].
                    string e1key = splitline[0];
                    List<string> valuestoadd = new List<string>();
                    for (int v = 1; v <= splitline.Length - 1; v++)
                    {
                        valuestoadd.Add(splitline[v]);
                    }

                    if (!costarareas.ContainsKey(e1key))
                    {
                        costarareas.Add(e1key, valuestoadd);
                        areasadded++;
                    }
                }
            }

            Console.WriteLine("Areas read - {0}.", areasadded);
            Console.WriteLine();

            string userentry = string.Empty;
            while (userentry != "exit")
            {
                Console.Write("Enter Area ID to search, \"exit\" to close or \"new\" to test another file: ");
                userentry = Console.ReadLine();

                //close.
                if (userentry == "exit")
                {
                    Environment.Exit(0);
                }

                if (userentry == "new")
                {
                    CostarAreaFilesManualCheck();
                }

                if (costarareas.ContainsKey(userentry))
                {
                    Console.WriteLine("File: {0}", GetFileNameWithoutExtension(costarfile));

                    string[] columnarray = headerlist.ToArray();
                    //string spacer = " | ";

                    List<string> keyvalues = costarareas[userentry];
                    string[] valuearray = keyvalues.ToArray();

                    //line builder
                    for (int v = 1; v <= columnarray.Length - 1; v++)
                    {
                        //Console.WriteLine(answer + spacer + columnarray[v] + spacer + valuearray[v]);
                        string output = string.Format("{0,10} | {1,-40} | {2,20}", userentry, columnarray[v], valuearray[v - 1]);
                        Console.WriteLine(output);
                    }

                    Console.WriteLine();
                }
            }
        }

        static public void CostarAreaFilesSummaries()
        {
            Console.Write("Drag and Drop Costar AREA Desktop Folder Here (CEX, BUSSUM, or DMGRA): ");
            string costardirectory = Console.ReadLine();
            string[] costarfilepaths = Directory.GetFiles(@costardirectory);
            char e1deli = GetDelimiter();

            Dictionary<string, List<string>> costarareas = new Dictionary<string, List<string>>();
            int areasadded = 0;

            //getcolumns;
            List<string> headervalues = new List<string>();
            using (StreamReader columnreader = new StreamReader(costarfilepaths[0]))
            {
                string header = columnreader.ReadLine().Replace("\"", string.Empty);
                string[] headernames = header.Split(e1deli);
                for (int v = 1; v <= headernames.Length - 1; v++)
                {
                    headervalues.Add(headernames[v]);
                }
            }

            foreach (var file in costarfilepaths)
            {
                using (StreamReader costarfile = new StreamReader(file))
                {
                    string line = string.Empty;
                    costarfile.ReadLine(); //get rid of header rows.

                    while ((line = costarfile.ReadLine()) != null)
                    {
                        line = line.Replace("\"", string.Empty);
                        string[] splitline = line.Split(e1deli);

                        string e1key = splitline[0];
                        List<string> valuestoadd = new List<string>();
                        for (int v = 1; v <= splitline.Length - 1; v++)
                        {
                            valuestoadd.Add(splitline[v]);
                        }

                        //data starts at splitline[1].
                        if (!costarareas.ContainsKey(e1key))
                        {
                            costarareas.Add(e1key, valuestoadd);
                            areasadded++;
                        }
                    }
                }
            }

            Console.WriteLine("Areas read - {0}.", areasadded);

            List<double> summaries = new List<double>();
            //double[] summaries = new double[headervalues.Count - 1];

            foreach (KeyValuePair<string, List<string>> value in costarareas)
            {
                List<string> newlist = value.Value;

                for (int v = 0; v <= newlist.Count - 1; v++)
                {
                    string tempvalue = newlist[v];
                    double valuetoadd = 0.000;
                    double.TryParse(tempvalue, out valuetoadd);

                    if (summaries.Count < newlist.Count)
                    {
                        summaries.Add(valuetoadd);
                    }
                    else
                    {
                        summaries[v] += valuetoadd;
                    }
                }
            }

            List<double> summarizedvalues = summaries.ToList();

            string newfile = GetDesktopDirectory() + "\\" + GetFileNameWithoutExtension(costarfilepaths[0]) + "_summaries.txt";
            using (StreamWriter outfile = new StreamWriter(newfile))
            {
                for (int v = 0; v <= summarizedvalues.Count - 1; v++)
                {
                    //label.Text = String.Format("{0:F3}", dec); // Show 3 Decimel Points

                    outfile.WriteLine("{0,10} | {1,-10}", headervalues[v], summarizedvalues[v]);
                }
            }

        }
    }
}
