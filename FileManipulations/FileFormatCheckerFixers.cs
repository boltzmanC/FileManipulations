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
    class FileFormatCheckerFixers
    {

        public static void FileFormatCheckerFixer()
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
                        FileFormatCheckerFixers.StringStrip();
                        break;
                    case "2":
                        FileFormatCheckerFixers.VerifyLineLength();
                        break;
                    case "3":
                        FileFormatCheckerFixers.TrimWhitespace();
                        break;
                    case "4":
                        FileFormatCheckerFixers.ChangeDelimeter();
                        break;
                    case "5":
                        FileFormatCheckerFixers.CombineTwoColumns();
                        break;

                    // File Manipulation.
                    case "6":
                        FileFormatCheckerFixers.CombineFiles();
                        break;
                    case "7":
                        FileFormatCheckerFixers.CopyFile();
                        break;
                    case "8":
                        FileFormatCheckerFixers.UniqueValueCheck();
                        break;
                    case "9":
                        FileFormatCheckerFixers.VlookupAppendColumn();
                        break;
                    case "10":
                        FileFormatCheckerFixers.VLookupAppendColumnRows();
                        break;
                    case "11":
                        FileFormatCheckerFixers.AddStringToColumnValues();
                        break;
                    case "12":
                        FileFormatCheckerFixers.AddStringAsNewColumnValue();
                        break;
                    case "13":
                        FileFormatCheckerFixers.RemoveDataFromColumn();
                        break;

                    //Pull Data From File.
                    case "14":
                        FileFormatCheckerFixers.GetSubsetOfRecords();
                        break;
                    case "15":
                        FileFormatCheckerFixers.BreakOneFileIntoMany();
                        break;
                    case "16":
                        FileFormatCheckerFixers.CopyColumnsWithValueToNewFile();
                        break;
                    case "17":
                        FileFormatCheckerFixers.CopyColumnsToNewFile();
                        break;
                    case "18":
                        FileFormatCheckerFixers.PullBlankEmptyOrZeroValueRecords();
                        break;
                    case "19":
                        FileFormatCheckerFixers.PullRandomSubsetofLengthX(); // not really working.
                        break;
                    case "20":
                        FileFormatCheckerFixers.PullRecordsWithValueXInColumnY();
                        break;
                    case "21":
                        FileFormatCheckerFixers.PullRecordsWithValueInColumn_s();
                        break;
                    case "22":
                        FileFormatCheckerFixers.PullRecordsWithORListofStringorChars();
                        break;

                    case "23":
                        FileFormatCheckerFixers.TestColumnNamesFromDefinitionFile();
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

        // File formatting.
        public static void StringStrip() //remove string from lines in file.
        {
            // remove string from each line of file.
            // uses function line_strip, takes (line to edit, string to remove, char delimiter)
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Deletes user designated string or character as string (string example: \"word\", char example: \"). Can be used to remove all \" quotes from a file.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();

            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            Console.Write("String: ");
            string toremove = Console.ReadLine().Trim();

            string outfile = Directory.GetParent(file) + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_stringremoved.txt";

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


            string filename = FunctionTools.GetFileNameWithoutExtension(file);

            string outfile = (FunctionTools.GetDesktopDirectory() + "\\" + filename + "_stringremoved.txt");

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

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string filename = FunctionTools.GetFileNameWithoutExtension(file);

            string outfile = FunctionTools.GetDesktopDirectory() + "\\" + filename + "_good_columns.txt";
            string outfile2 = FunctionTools.GetDesktopDirectory() + "\\" + filename + "_bad_columns.txt";

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

                        string[] headersplit = FunctionTools.LineStringToArray(header, txtq, delimiter);
                        int headlength = headersplit.Length;

                        int badcount = 0;

                        string line;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            string[] linessplit = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();
            Console.Write("Processing...");

            string filename = FunctionTools.GetFileNameWithoutExtension(file);

            string outfile = FunctionTools.GetDesktopDirectory() + "\\" + filename + "_trimmed.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

            string file = FunctionTools.GetAFile();
            char txtq = FunctionTools.GetTXTQualifier();
            char delimiter = FunctionTools.GetDelimiter();
            Console.Write("New: ");
            char newdelimiter = FunctionTools.GetDelimiter();

            string filename = FunctionTools.GetFileNameWithoutExtension(file);
            string outfile = FunctionTools.GetDesktopDirectory() + "\\" + filename + "_newdelimiter.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);
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

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            Console.Write("Space Separated column numbers to combine(start count from 0): ");
            string input = Console.ReadLine();
            string[] format_input = input.Split(' ');
            int column1 = int.Parse(format_input[0]);
            int column2 = int.Parse(format_input[1]);

            Console.Write("Processing...");

            using (StreamReader readfile = new StreamReader(file))
            {
                string header = readfile.ReadLine();
                string[] headersplit = FunctionTools.LineStringToArray(header, txtq, delimiter);
                string col1 = headersplit[column1];
                string col2 = headersplit[column2];

                string filename = FunctionTools.GetFileNameWithoutExtension(file);

                string outfile = FunctionTools.GetDesktopDirectory() + "\\" + filename + "_" + col1 + "_" + col2 + "_combined.txt";

                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    //header format.
                    string newheader = FunctionTools.CombineTwoValuesInArray(header, delimiter, column1, column2);
                    newfile.WriteLine(newheader);

                    // rest of file format.
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string newline = FunctionTools.CombineTwoValuesInArray(line, delimiter, column1, column2);
                        newfile.WriteLine(newline);
                    }
                }

                Console.WriteLine("New File: {0}", outfile);
                Console.WriteLine();
            }
        }



        // File manipulation.
        public static void AddStringAsNewColumnValue()
        {
            // adds user specified string to every row as a new "column" value.
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Adds new Column and user designated string to every row as a new \"column\" value.");
            Console.ResetColor();

            Console.WriteLine("-Add string as new column value-");

            string file = FunctionTools.GetAFile();
            char deli = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            Console.WriteLine();
            Console.Write("New Column name: ");
            string columnname = Console.ReadLine().Trim();
            Console.WriteLine();
            Console.Write("Value to add: ");
            string valuetoadd = Console.ReadLine().Trim();

            string appendedfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_columnvalueadded.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(appendedfile))
                {
                    string header = readfile.ReadLine();
                    string[] headersplit = FunctionTools.LineStringToArray(header, txtq, deli);
                    List<string> headerbuilder = headersplit.ToList();
                    headerbuilder.Add(columnname);

                    // write new header
                    writefile.WriteLine(string.Join(deli.ToString(), headerbuilder));

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        List<string> splitlinebuilder = new List<string>();
                        splitlinebuilder.AddRange(FunctionTools.LineStringToArray(line, txtq, deli));

                        // add new value
                        splitlinebuilder.Add(valuetoadd);

                        // write new line
                        writefile.WriteLine(string.Join(deli.ToString(), splitlinebuilder.ToArray()));
                    }
                }
            }
        }
        
        public static void AppendValueToEachLineInFile()
        {
            Console.WriteLine();
            Console.WriteLine("Append Value to Each Line in File.");

            string file = FunctionTools.GetAFile();
            char delimeter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string appendedfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_appended.txt";

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

        public static void AddStringToColumnValues() // adds user entered string to values in user selected column in file.
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Adds user designated string to column \"empty\" column. IF the column does have data in it. The values will be overwritten and replaced with the user designated values.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            Console.Write("Column Name: ");
            string columnname = FunctionTools.GetColumn();

            Console.Write("Value to add: ");
            string valuetoadd = Console.ReadLine().Replace("\"", string.Empty).Trim().ToUpper();

            string newfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_" + valuetoadd + "_added.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                string header = readfile.ReadLine();
                string[] headervalues = FunctionTools.LineStringToArray(header, txtq, delimiter);
                int length = headervalues.Length;

                int columnindex = FunctionTools.ColumnIndexNew(header, delimiter, columnname, txtq);

                using (StreamWriter writefile = new StreamWriter(newfile))
                {
                    writefile.WriteLine(header);

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void CombineFiles()
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
                string file = FunctionTools.GetAFile();
                char delimiter = FunctionTools.GetDelimiter();

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
            string newfile = FunctionTools.GetDesktopDirectory() + "\\combined-file.txt";

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

        public static void CopyFile() // line by line copy file.
        {
            // splits and recombines lines of file. 
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Copies a file line by line. This is done to get rid of hidden EOL or EOF formatting which occurs sometimes when creating a file on a MAC and transfering it to PC.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();
            Console.Write("Processing...");

            string filename = FunctionTools.GetFileNameWithoutExtension(file);
            string outfile = FunctionTools.GetDesktopDirectory() + "\\" + filename + "_copy.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter newfile = new StreamWriter(outfile))
                {
                    string header = readfile.ReadLine();
                    newfile.WriteLine(header);
                    string line;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] linearray = FunctionTools.LineStringToArray(line, txtq, delimiter);

                        string newline = string.Join(delimiter.ToString(), linearray);

                        //newline = newline.Replace(toreplace, neweol);
                        //newline = newline.Replace(toreplace2, neweol);

                        newfile.WriteLine(newline);
                    }
                }
            }
        }

        public static void Dedupesaveextravalues()
        {
            string file = FunctionTools.GetAFile();
            string column = FunctionTools.GetColumn();
            char delimeter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string newfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_uniquekeyrows.txt";
            string newfileheader = string.Empty;

            Dictionary<string, List<string>> rowkeys = new Dictionary<string, List<string>>();

            using (StreamReader readfile = new StreamReader(file))
            {
                string header = readfile.ReadLine();
                List<string> headerlinebuilder = new List<string>();
                if (header.Contains(txtq))
                {
                    headerlinebuilder.AddRange(FunctionTools.SplitLineWithTxtQualifier(header, delimeter, txtq, false));
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

                int columnid = FunctionTools.ColumnIndex(header, delimeter, column);

                int count = 0;
                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    Console.Write("\r {0}", count++);

                    List<string> splitlinebuilder = new List<string>();
                    if (line.Contains(txtq))
                    {
                        splitlinebuilder.AddRange(FunctionTools.SplitLineWithTxtQualifier(line, delimeter, txtq, false));
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

        public static void FormatDateColumn() //changes date format. uses user defined original format to convert to mm/dd/yyyy 
        {
            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string columnname = FunctionTools.GetColumn(); //toupper,trim,removed"
            string newfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_" + columnname + ".txt";

            using (StreamWriter writefile = new StreamWriter(newfile))
            {
                using (StreamReader readfile = new StreamReader(file))
                {
                    string header = readfile.ReadLine();
                    writefile.WriteLine(header);
                    string[] columns = FunctionTools.LineStringToArray(header, txtq, delimiter);
                    int length = columns.Length;

                    int columnindex = FunctionTools.ColumnIndexNew(header, delimiter, columnname, txtq);

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
                        string[] linesplit = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void FormatZipCodesAddLeadingZeroes()
        {
            Console.WriteLine("Enter File and Zip Code Column Name That Needs to be Reformatted.");
            Console.WriteLine();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string zipcolumn = FunctionTools.GetColumn();
            string formattedfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_zipformatted.txt";

            int padded = 0;

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter writefile = new StreamWriter(formattedfile))
                {
                    string header = readfile.ReadLine();
                    writefile.WriteLine(header);
                    int columnindex = FunctionTools.ColumnIndexNew(header, delimiter, zipcolumn, txtq);

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void RemoveDataFromColumn()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Delete all data in user designated column.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            Console.WriteLine();
            Console.Write("Enter Column Name: ");
            string columnname = Console.ReadLine();

            string columndataremoved = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_columndataremoved.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                using (StreamWriter outfile = new StreamWriter(columndataremoved))
                {
                    string header = readfile.ReadLine();
                    outfile.WriteLine(header);

                    int columnindex = FunctionTools.ColumnIndexNew(header, delimiter, columnname, txtq);

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

                        splitline[columnindex] = string.Empty; //target value deleted.

                        outfile.WriteLine(string.Join(delimiter.ToString(), splitline));
                    }
                }
            }
        }

        public static void UniqueValueCheck() // checks for duplicate values in user entered column, writes unique values and count of each occurance.
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Checks for duplicate values in user entered column. Writes unique values and count of each occurrence to new file.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string columnname = FunctionTools.GetColumn();
            string newfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_uniquevalues.txt";

            using (StreamReader readfile = new StreamReader(file))
            {
                Dictionary<string, int> uniquevalues = new Dictionary<string, int>();

                string header = readfile.ReadLine();
                int columnindex = FunctionTools.ColumnIndexNew(header, delimiter, columnname, txtq);

                int count = 0;
                int countunique = 0;
                string line = string.Empty;
                while ((line = readfile.ReadLine()) != null)
                {
                    Console.Write("\r {0}", count++);
                    string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void VlookupAppendColumn() //adds 1 column to a file. both files need matching unique ID column. 
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("vlookup_append_column(): adds 1 column to a file. Both files need matching Unique ID columns.");
            Console.ResetColor();
            Console.WriteLine();

            //original file.
            Console.Write("File being added to: ");
            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            Console.WriteLine("ID Column Name:");
            string idcolumnname = FunctionTools.GetColumn();
            Console.WriteLine();
            Console.WriteLine();

            //data to add.
            Console.Write("File With New Column: ");
            string grabfromfile = FunctionTools.GetAFile();
            char toadddelimiter = FunctionTools.GetDelimiter();
            char toaddtxtq = FunctionTools.GetTXTQualifier();

            Console.WriteLine("ID Column Name: ");
            string toaddidcolumnname = FunctionTools.GetColumn();

            Console.Write("Column To Add Name: ");
            string toaddcolumnname = FunctionTools.GetColumn();

            //returned file.
            string outfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_" + toaddcolumnname + "_appended.txt";
            Console.WriteLine("Processing...");

            // Process...
            Dictionary<string, string> idvalues = new Dictionary<string, string>();

            // Read the column file.
            using (StreamReader toaddcolumnfile = new StreamReader(grabfromfile))
            {
                string header = toaddcolumnfile.ReadLine();
                string[] headercolumns = FunctionTools.LineStringToArray(header, toaddtxtq, toadddelimiter);
                int length = headercolumns.Length;

                int toaddidcolumn = FunctionTools.ColumnIndexNew(header, toadddelimiter, toaddidcolumnname, toaddtxtq);
                int toaddvaluecolumn = FunctionTools.ColumnIndexNew(header, toadddelimiter, toaddcolumnname, toaddtxtq);

                string line;
                while ((line = toaddcolumnfile.ReadLine()) != null)
                {
                    string[] linesplit = FunctionTools.LineStringToArray(line, toaddtxtq, toadddelimiter);

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

                    int idcolumnindex = FunctionTools.ColumnIndexNew(header, delimiter, idcolumnname, txtq);
                    writefile.WriteLine("{0}{1} {2}", header, delimiter, toaddcolumnname);

                    string line = string.Empty;
                    while ((line = originalfile.ReadLine()) != null)
                    {
                        string[] linesplit = FunctionTools.LineStringToArray(line, txtq, delimiter);

                        if (idvalues.ContainsKey(linesplit[idcolumnindex]))
                        {
                            string value = idvalues[linesplit[idcolumnindex]];

                            writefile.WriteLine("{0}{1} {2}", line, delimiter, value);
                        }
                    }
                }
            }
        }

        public static void VLookupAppendColumnRows()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Appends all columns from records with matching from File2 to File1 that have matching \"ID\" values.");
            Console.ResetColor();

            //output char to elminate issues with , tabs etc...
            char newdelimiter = '|';

            //file that is being appeneded.
            Console.WriteLine("File being appended: ");
            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();
            Console.Write("ID Column Name: ");
            string idcolumn = FunctionTools.GetColumn();

            //file with data to append.
            Console.WriteLine("File with data to append: ");
            string toappendfile = FunctionTools.GetAFile();
            char toappenddelimiter = FunctionTools.GetDelimiter();
            char toappendtxtq = FunctionTools.GetTXTQualifier();
            Console.Write("ID Column Name: ");
            string toappendidcolumn = FunctionTools.GetColumn();

            //Dictionary for data from append data file.
            Dictionary<string, string> ToAppendValues = new Dictionary<string, string>();

            //List of headers from data to append file.
            List<string> toappendheaderstorage = new List<string>();

            //new file.
            string appendedfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_appended.txt";

            //read to append data file.
            using (StreamReader toappenddata = new StreamReader(toappendfile))
            {
                string header = toappenddata.ReadLine();
                string[] headervalues = FunctionTools.LineStringToArray(header, toappendtxtq, toappenddelimiter);

                //idcolumn index
                int toappendidcolumnindex = FunctionTools.ColumnIndexNew(header, toappenddelimiter, toappendidcolumn, toappendtxtq);

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
                    string[] toappendsplitline = FunctionTools.LineStringToArray(toappendline, toappendtxtq, toappenddelimiter);

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
                    string[] headervalues = FunctionTools.LineStringToArray(header, txtq, delimiter);

                    //write new header to new file. Using new delimiter.
                    string newfileheader = string.Join(newdelimiter.ToString(), headervalues) + newdelimiter.ToString() + string.Join(newdelimiter.ToString(), toappendheaderstorage.ToArray());
                    newfile.WriteLine(newfileheader);

                    //Find idcolumn index.
                    int idcolumnindex = FunctionTools.ColumnIndexNew(header, delimiter, idcolumn, txtq);
                    //int length = ogheadervalues.Length;

                    //read ogfile.
                    string line = string.Empty;
                    try
                    {
                        while ((line = filebeingappended.ReadLine()) != null)
                        {
                            string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void VlookupKeepNotFoundFromOriginalFile()
        {
            //output char to elminate issues with , tabs etc...
            char newdelimiter = '|';

            //file that is being appeneded.
            Console.WriteLine("File being appended: ");
            string ogfile = FunctionTools.GetAFile();
            char ogdelimiter = FunctionTools.GetDelimiter();
            Console.Write("ID Column Name: ");
            string ogidcolumn = Console.ReadLine().Trim().ToUpper();

            //file with data to append.
            Console.WriteLine("File with data to append: ");
            string toappendfile = FunctionTools.GetAFile();
            char toappenddelimiter = FunctionTools.GetDelimiter();
            Console.Write("ID Column Name: ");
            string toappendidcolumn = Console.ReadLine().Trim().ToUpper();

            //Dictionary for data from append data file.
            Dictionary<string, string> ToAppendValues = new Dictionary<string, string>();

            //List of headers from data to append file.
            List<string> toappendheaderstorage = new List<string>();

            //new file.
            string appendedfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(ogfile) + "_appended.txt";

            //qualifier?????
            Console.Write("Files have txt qualifier? (y/n): ");
            string answer = Console.ReadLine().ToUpper().Trim();

            if (answer == "Y")
            {
                char qualifier = FunctionTools.GetTXTQualifier();

                //read to append data file.
                using (StreamReader toappenddata = new StreamReader(toappendfile))
                {
                    string header = toappenddata.ReadLine();
                    string[] headervalues = FunctionTools.SplitLineWithTxtQualifier(header, toappenddelimiter, qualifier, true);
                    string[] cleanheader = FunctionTools.ArrayWithNoTxtQualifier(headervalues, qualifier);

                    //idcolumn index
                    int toappendidcolumnindex = FunctionTools.ColumnIndexWithQualifier(header, toappenddelimiter, qualifier, toappendidcolumn);

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
                        string[] toappendsplitline = FunctionTools.SplitLineWithTxtQualifier(toappendline, toappenddelimiter, qualifier, true);
                        string[] cleantoappendsplitline = FunctionTools.ArrayWithNoTxtQualifier(toappendsplitline, qualifier);

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
                        string[] ogheadervalues = FunctionTools.SplitLineWithTxtQualifier(ogheader, ogdelimiter, qualifier, false);

                        //clean headers
                        ogheadervalues = FunctionTools.ArrayWithNoTxtQualifier(ogheadervalues, qualifier);

                        //write new header to new file. Using new delimiter.
                        string newfileheader = string.Join(newdelimiter.ToString(), ogheadervalues) + newdelimiter.ToString() + string.Join(newdelimiter.ToString(), toappendheaderstorage.ToArray());
                        newfile.WriteLine(newfileheader);

                        //Find idcolumn index.
                        int ogidcolumnindex = FunctionTools.ColumnIndexWithQualifier(ogheader, ogdelimiter, qualifier, ogidcolumn);
                        //int length = ogheadervalues.Length;

                        //read ogfile.
                        string ogline = string.Empty;
                        try
                        {
                            while ((ogline = filebeingappended.ReadLine()) != null)
                            {
                                string[] ogsplitline = FunctionTools.SplitLineWithTxtQualifier(ogline, ogdelimiter, qualifier, false);
                                //clean qualifiers our of data
                                ogsplitline = FunctionTools.ArrayWithNoTxtQualifier(ogsplitline, qualifier);

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
                    int toappendidcolumnindex = FunctionTools.ColumnIndex(header, toappenddelimiter, toappendidcolumn);

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
                        int ogidcolumnindex = FunctionTools.ColumnIndex(ogheader, ogdelimiter, ogidcolumn);
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



        // PUll data from File.
        public static void BreakOneFileIntoMany() // breaks up a file into user defined number.
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

        public static void CopyColumnsToNewFile()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-Copies user designated column(s) to new file-");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char deli = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string outfile = Directory.GetParent(file) + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_selectedcolumns.txt";

            Console.WriteLine();
            Console.WriteLine("Column list file, pipe delimited names on one line: ");
            string columnfile = FunctionTools.GetAFile();

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
                    string[] headersplit = FunctionTools.SplitLineWithTxtQualifier(header, deli, txtq, false);

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

            //again
            //CopyColumnsToNewFile();
        }

        public static void CopyColumnsWithValueToNewFile()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-Copies user designated column(s) with values to new file-");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char deli = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string outfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_selectedcolumns.txt";

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
                        string[] splitline = FunctionTools.LineStringToArray(line, txtq, deli);

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

        public static void GetSubsetOfRecords()  //get subset of file.
        {
            //Gets user desigmated number of lines from file.
            //use to get subset of records.
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Get user designated # of records from file. Count starts at the beginning of the file.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();

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


            string filename = FunctionTools.GetFileNameWithoutExtension(file);
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

        public static void PullBlankEmptyOrZeroValueRecords() // broken af.
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Do not remember what this does - Dylan 10/10/2019.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            Console.Write("Id Column Name: ");
            string idcolumn = FunctionTools.GetColumn();

            Console.Write("Enter BlankEmptyorZero character: ");
            string valuetofind = Console.ReadLine();

            char blankemptyorzero;
            bool result;
            result = char.TryParse(valuetofind, out blankemptyorzero);

            if (result != true)
            {
                valuetofind = blankemptyorzero.ToString();
            }

            string newfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_blankemptyorzero.txt";

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
                        int columnindex = FunctionTools.ColumnIndex(line, delimiter, idcolumn);

                        int tempvalue = 0;

                        string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void PullRandomSubsetofLengthX()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pulls user designated number of random records from a target file.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

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

            string newfile = Directory.GetParent(file) + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_rsubset_" + recordstopull + ".txt";
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
                    int idindex = FunctionTools.ColumnIndexWithQualifier(header, delimiter, txtq, id);
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
                        string[] linesplit = FunctionTools.SplitLineWithTxtQualifier(line, delimiter, txtq, false);

                        if (!recordkeeper.ContainsKey(linesplit[idindex])) //test if duplicate
                        {
                            recordkeeper.Add(linesplit[idindex], 0); //add id to dictionary checker
                            writefile.WriteLine(line); //write line to new file
                        }
                    }
                }
            }
        }

        public static void PullRecordsWithValueXInColumnY()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pull records with value x in column y.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string moveon = string.Empty;

            while (moveon != "n")
            {
                Console.Write("Enter Column Name with Value: ");
                string columnname = FunctionTools.GetColumn();

                Console.Write("Enter Value to find: ");
                string valuetofind = Console.ReadLine().Trim();

                Console.WriteLine();
                Console.Write("Processing...");

                string newfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_" + columnname + "_" + valuetofind + ".txt";

                using (StreamReader readfile = new StreamReader(file))
                {
                    using (StreamWriter writefile = new StreamWriter(newfile))
                    {
                        string header = readfile.ReadLine();
                        string[] headersplit = FunctionTools.LineStringToArray(header, txtq, delimiter);
                        int length = headersplit.Length;

                        int columnindex = FunctionTools.ColumnIndexNew(header, delimiter, columnname, txtq);

                        writefile.WriteLine(header);

                        string line;
                        while ((line = readfile.ReadLine()) != null)
                        {
                            string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void PullRecordsWithValueInColumn_s()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pulls records with value in user specified column(s). Pulls based on AND/OR logic.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string outfile = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_foundrecords.txt";

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
                        int index = FunctionTools.ColumnIndexNew(header, delimiter, item, txtq);

                        columnindexlist.Add(index);
                    }

                    string line = string.Empty;
                    while ((line = readfile.ReadLine()) != null)
                    {
                        string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void PullRecordsWithORListofStringorChars()
        {
            // pull records that have a character from the list a user enters
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Pulls all records that contain the specific string character sequence entered by the user.");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string pulledrecords = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_pulledrecords.txt";
            string leftovers = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_leftovers.txt";

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

        public static void TestColumnNamesFromDefinitionFile()
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
            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            using (StreamReader readfile = new StreamReader(file))
            {
                bool matched = true;
                bool morecolumns = false;
                bool lesscolumns = false;

                string header = readfile.ReadLine();
                string[] headersplit = FunctionTools.SplitLineWithTxtQualifier(header, delimiter, txtq, false);

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

                        using (StreamWriter newdefinitionfile = new StreamWriter(FunctionTools.GetDesktopDirectory() + "\\" + definitionfilepath.Split('/').Last()))
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
                        using (StreamWriter newdefinitionfile = new StreamWriter(FunctionTools.GetDesktopDirectory() + "\\newcolumnlistfordefinitionfile.txt"))
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
    }
}
