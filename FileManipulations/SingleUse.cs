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
    class SingleUse
    {
        // Client Specific Tasks
        public static void CSTProfileIDMapping() // not finished
        {
            //maps new profile names from first file with second file names/ids/info to new file.

            //old profiles - with names changed.
            Console.WriteLine("Current Profile List: ");
            string old_file = FunctionTools.GetAFile();
            char delimiter1 = FunctionTools.GetDelimiter();
            Console.Write("Profile Id column name: ");
            string profile_id1 = Console.ReadLine();
            Console.Write("Profile Name column name: ");
            string profile_name1 = Console.ReadLine();

            profile_id1 = profile_id1.Trim().ToUpper();
            profile_name1 = profile_name1.Trim().ToUpper();

            //new profiles.
            Console.WriteLine();
            Console.WriteLine("NEW Profile List: ");
            string new_file = FunctionTools.GetAFile();
            char delimiter2 = FunctionTools.GetDelimiter();
            Console.Write("Profile Id column name: ");
            string profile_id2 = Console.ReadLine();
            Console.Write("Profile Name column name: ");
            string profile_name2 = Console.ReadLine();

            profile_id2 = profile_id2.Trim().ToUpper();
            profile_name2 = profile_name2.Trim().ToUpper();

            string new_list_file = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(new_file) + "_newnames.txt";

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

        public static void CSTUsageMetricsFilter() //mostly finished
        {

            Console.Write("File: ");
            string File = Console.ReadLine();

            string new_file = FunctionTools.GetDesktopDirectory() + "\\neustar_users.txt";

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

        public static void BGToZipUrbanicityAverage() //read for info.
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

            string new_file = FunctionTools.GetDesktopDirectory() + "\\zip_urbanicity.txt";

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

                    average_code = (FunctionTools.SumOfIntArray(urban_codes) / urban_codes.Length);

                    string write_code = average_code.ToString();

                    // write new line to file.
                    writefile.WriteLine("{0}{1}{2}{3}{4}", new_zip, "|", new_zip, "|", write_code);
                }

            }

        }

        public static void BehaviorAnalyzerSorting() //used for HBO & WB deliverable.
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

            string new_file = FunctionTools.GetDesktopDirectory() + "\\greatest_index_per_profile.txt";

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
        public static void FindDatesBeforeX() //custom, one use. needsto be standardized.
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

            string outfile = FunctionTools.GetDesktopDirectory() + "\\old_dates.txt";

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
                        int[] date2 = FunctionTools.StringToIntArray(line_array[index], '-');

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

        public static void FixedWidthToPipeDelimited() // needs work.
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

        public static void ReadTwoLines() //what does this do? 
        {
            Console.Write("File: ");
            string file = Console.ReadLine();

            string new_file = FunctionTools.GetDesktopDirectory() + "\\new_lines.txt";

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

        public static void FindIDsInTwoFiles() //compares two lists of IDs. two files each with one column of IDs.
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

            string new_file = FunctionTools.GetDesktopDirectory() + "\\new_lines.txt";

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

        public static void NumericValueCheck() // checks for number value in user defined column.
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.ResetColor();

            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

            string processcolumn = string.Empty;
            while (processcolumn != "n" || processcolumn != "N")
            {
                Console.Write("Enter Column Name: ");
                string column = Console.ReadLine();

                string onlynumbers = FunctionTools.GetDesktopDirectory() + "\\" + FunctionTools.GetFileNameWithoutExtension(file) + "_" + column + ".txt";

                using (StreamReader readfile = new StreamReader(file))
                {
                    using (StreamWriter writefile = new StreamWriter(onlynumbers))
                    {
                        string header = readfile.ReadLine();

                        string[] columns = FunctionTools.LineStringToArray(header, txtq, delimiter);
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
                            string[] splitline = FunctionTools.LineStringToArray(line, txtq, delimiter);

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

        public static void SwitchDateFormatInColumns()
        {
            // accepts user input date foramat to change
            // accepts user input for new date format to use

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Change Date Format in target column(s)");
            Console.ResetColor();

            Console.WriteLine("-Target File-");
            string file = FunctionTools.GetAFile();

            char delimeter = FunctionTools.GetDelimiter();
            char txtq = FunctionTools.GetTXTQualifier();

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



        // Methods not in menu.
        public static void TestStringLength() // only keeps records that have a char_length < 30.   
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

            string outfile = FunctionTools.GetDesktopDirectory() + "\\good.txt";
            string badrecords = FunctionTools.GetDesktopDirectory() + "\\bad.txt";

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

        public static void FindValueInColumn() //prints line with valid value in column to file, else prints to different file.
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

            string outfile = FunctionTools.GetDesktopDirectory() + "\\found_lines.txt";
            string outfile2 = FunctionTools.GetDesktopDirectory() + "\\extra_lines.txt";

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

        public static void ValuePull() // pulls specified values in columns chosen by user.
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
            string outfile = FunctionTools.GetDesktopDirectory() + "\\columns.txt";

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

        public static void AddUniqueIDColumnToFile() // Not Used
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

            string outfile = FunctionTools.GetDesktopDirectory() + "\\file_plus_IDs.txt";

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

        public static void PullUniqueRows() //not done yet.
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

            string newfile = FunctionTools.GetDesktopDirectory() + "\\deduped_records.txt";
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

        public static void EditLineInListOfFiles()
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

        public static void SkipUserSpecifiedLines() // copies lines to new file (skips user defined lines, manually entered)
        {
            string file = FunctionTools.GetAFile();
            char delimiter = FunctionTools.GetDelimiter();

            Console.Write("Enter line to not read: ");

            string line_to_replace = Console.ReadLine();
            line_to_replace = line_to_replace.Trim().ToUpper();

            string new_file = FunctionTools.GetDesktopDirectory() + "\\lines_removed.txt";

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

    }
}
