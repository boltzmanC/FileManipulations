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
        // File manipulation.
        //****************************************************************************************************************************************************
        //****************************************************************************************************************************************************
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

        public static void CopyFile() // line by line copy file.
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

        public static void UniqueValueCheck() // checks for duplicate values in user entered column, writes unique values and count of each occurance.
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

        public static void VlookupAppendColumn() //adds 1 column to a file. both files need matching unique ID column. 
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

        public static void AddStringToColumnValues() // adds user entered string to values in user selected column in file.
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

        public static void AddStringAsNewColumnValue()
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

        public static void RemoveDataFromColumn()
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
        public static void GetSubsetOfRecords()  //get subset of file.
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

        public static void CopyColumnsWithValueToNewFile()
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

        public static void PullBlankEmptyOrZeroValueRecords() // broken af.
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

        public static void PullRandomSubsetofLengthX()
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

        public static void PullRecordsWithValueXInColumnY()
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

        public static void PullRecordsWithValueInColumn_s()
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

        public static void PullRecordsWithORListofStringorChars()
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
    }
}
